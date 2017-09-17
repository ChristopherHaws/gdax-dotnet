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
		
		public PagingOptions<TCursor> NewerPage()
		{
			var before = this.response.Headers.FirstOrDefault(x => x.Key.Equals("CB-BEFORE", StringComparison.OrdinalIgnoreCase));
			if (before.Value == null || before.Value.Count() != 1)
			{
				throw new GdaxException("Cannot determine newer page.");
			}

			return new PagingOptions<TCursor>
			{
				Limit = this.paging?.Limit,
				NewerThan = this.encoder.Decode(before.Value.First())
			};
		}

		public PagingOptions<TCursor> OlderPage()
		{
			var after = this.response.Headers.FirstOrDefault(x => x.Key.Equals("CB-AFTER", StringComparison.OrdinalIgnoreCase));
			if (after.Value == null || after.Value.Count() != 1)
			{
				throw new GdaxException("Cannot determine older page.");
			}

			return new PagingOptions<TCursor>
			{
				Limit = this.paging?.Limit,
				OlderThan = this.encoder.Decode(after.Value.First())
			};
		}

		public Boolean HasNewerPage()
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

		public Boolean HasOlderPage()
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

		private Object ToDump()
		{
			return new
			{
				HasOlderPage = this.HasOlderPage(),
				HasNewerPage = this.HasNewerPage(),
				OlderPageOptions = this.HasOlderPage() ? this.OlderPage() : null,
				NewerPageOptions = this.HasNewerPage() ? this.NewerPage() : null,
				OlderHeader = this.response.Headers.FirstOrDefault(x => x.Key.Equals("CB-AFTER", StringComparison.OrdinalIgnoreCase)).Value?.FirstOrDefault(),
				NewerHeader = this.response.Headers.FirstOrDefault(x => x.Key.Equals("CB-BEFORE", StringComparison.OrdinalIgnoreCase)).Value?.FirstOrDefault(),
				Results = this.Results,
			};
		}
	}
}
