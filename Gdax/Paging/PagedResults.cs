using System;
using System.Collections.Generic;
using System.Linq;

namespace Gdax
{
	public class PagedResults<T, TCursor>
	{
		private readonly GdaxResponse<IList<T>> response;
		private readonly ICursorEncoder<TCursor> encoder;
		private readonly PagingOptions<TCursor> paging;

		public PagedResults(GdaxResponse<IList<T>> response, ICursorEncoder<TCursor> encoder, PagingOptions<TCursor> paging = null)
		{
			this.response = response;
			this.encoder = encoder;
			this.paging = paging;
		}

		public IList<T> Results => this.response.Value;
		
		public PagingOptions<TCursor> PreviousPage()
		{
			var before = this.response.Headers.FirstOrDefault(x => x.Key.Equals("CB-BEFORE", StringComparison.OrdinalIgnoreCase));
			if (before.Value == null || before.Value.Count() != 1)
			{
				throw new GdaxException("Cannot determine before page.");
			}

			return new PagingOptions<TCursor>
			{
				Limit = this.paging?.Limit,
				SortBy = this.paging?.SortBy,
				SortOrder = this.paging?.SortOrder,
				NewerThan = this.encoder.Decode(before.Value.First())
			};
		}

		public PagingOptions<TCursor> NextPage()
		{
			var after = this.response.Headers.FirstOrDefault(x => x.Key.Equals("CB-AFTER", StringComparison.OrdinalIgnoreCase));
			if (after.Value == null || after.Value.Count() != 1)
			{
				throw new GdaxException("Cannot determine after page.");
			}

			return new PagingOptions<TCursor>
			{
				Limit = this.paging?.Limit,
				SortBy = this.paging?.SortBy,
				SortOrder = this.paging?.SortOrder,
				OlderThan = this.encoder.Decode(after.Value.First())
			};
		}

		public Boolean HasPreviousPage()
		{
			var before = this.response.Headers.FirstOrDefault(x => x.Key.Equals("CB-BEFORE", StringComparison.OrdinalIgnoreCase)).Value;
			if (before == null || before.Count() != 1)
			{
				return false;
			}

			if (this.Results.Count() >= (this.paging?.Limit ?? 100))
			{
				return true;
			}
			
			return false;
		}

		public Boolean HasNextPage()
		{
			var after = this.response.Headers.FirstOrDefault(x => x.Key.Equals("CB-AFTER", StringComparison.OrdinalIgnoreCase)).Value;
			if (after == null || after.Count() != 1)
			{
				return false;
			}
			
			if (this.Results.Count() >= (this.paging?.Limit ?? 100))
			{
				return true;
			}
			
			return false;
		}

		private Object ToDump() => new
		{
			CurrentPage = this.paging,
			HasPreviousPage = this.HasPreviousPage(),
			HasNextPage = this.HasNextPage(),
			PreviousPage = this.HasPreviousPage() ? this.PreviousPage() : null,
			NextPage = this.HasNextPage() ? this.NextPage() : null,
			PreviousHeader = this.response.Headers.FirstOrDefault(x => x.Key.Equals("CB-BEFORE", StringComparison.OrdinalIgnoreCase)).Value?.FirstOrDefault(),
			NextHeader = this.response.Headers.FirstOrDefault(x => x.Key.Equals("CB-AFTER", StringComparison.OrdinalIgnoreCase)).Value?.FirstOrDefault(),
			Results = this.Results,
		};
	}
}
