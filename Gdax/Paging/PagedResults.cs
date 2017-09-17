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
				throw new GdaxException("Cannot determine previous page.");
			}

			return new PagingOptions<TCursor>
			{
				Limit = this.paging?.Limit,
				Before = this.encoder.Decode(before.Value.First())
			};
		}

		public PagingOptions<TCursor> NextPage()
		{
			var after = this.response.Headers.FirstOrDefault(x => x.Key.Equals("CB-AFTER", StringComparison.OrdinalIgnoreCase));
			if (after.Value == null || after.Value.Count() != 1)
			{
				throw new GdaxException("Cannot determine next page.");
			}

			return new PagingOptions<TCursor>
			{
				Limit = this.paging?.Limit,
				After = this.encoder.Decode(after.Value.First())
			};
		}

		public Boolean HasPreviousPage()
		{
			var before = this.response.Headers.FirstOrDefault(x => x.Key.Equals("CB-BEFORE", StringComparison.OrdinalIgnoreCase));
			if (before.Value == null || before.Value.Count() != 1)
			{
				return false;
			}

			if (this.Results.Count() >= (this.paging?.Limit ?? 100))
			{
				return true;
			}

			var value = this.paging == null ? default(TCursor) : this.paging.Before;
			if (!before.Value.Any(x => x.Equals(this.encoder.Encode(value), StringComparison.OrdinalIgnoreCase)))
			{
				return true;
			}

			return false;
		}

		public Boolean HasNextPage()
		{
			var after = this.response.Headers.FirstOrDefault(x => x.Key.Equals("CB-AFTER", StringComparison.OrdinalIgnoreCase));
			if (after.Value == null || after.Value.Count() != 1)
			{
				return false;
			}
			
			if (this.Results.Count() >= (this.paging?.Limit ?? 100))
			{
				return true;
			}

			var value = this.paging == null ? default(TCursor) : this.paging.After;
			if (after.Value.Any(x => x.Equals(this.encoder.Encode(value), StringComparison.OrdinalIgnoreCase)))
			{
				return true;
			}

			return false;
		}
	}
}
