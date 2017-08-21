using System;
using System.Collections.Generic;
using System.Linq;

namespace Gdax
{
	public class PaginatedResult<T>
	{
		private readonly GdaxResponse<IList<T>> response;
		private readonly PaginationOptions paging;

		public PaginatedResult(GdaxResponse<IList<T>> response, PaginationOptions paging = null)
		{
			this.response = response;
			this.paging = paging;
		}

		public IList<T> Results => this.response.Value;
		
		public PaginationOptions PreviousPage()
		{
			var before = this.response.Headers.FirstOrDefault(x => x.Key.Equals("CB-BEFORE", StringComparison.OrdinalIgnoreCase));
			if (before.Value == null || before.Value.Count() != 1)
			{
				throw new GdaxException("Cannot determine previous page.");
			}

			return new PaginationOptions
			{
				CursorType = CursorType.Before,
				Limit = this.paging?.Limit,
				Value = before.Value.First()
			};
		}

		public PaginationOptions NextPage()
		{
			var after = this.response.Headers.FirstOrDefault(x => x.Key.Equals("CB-AFTER", StringComparison.OrdinalIgnoreCase));
			if (after.Value == null || after.Value.Count() != 1)
			{
				throw new GdaxException("Cannot determine next page.");
			}

			return new PaginationOptions
			{
				CursorType = CursorType.After,
				Limit = this.paging?.Limit,
				Value = after.Value.First()
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

			if (!before.Value.Any(x => x.Equals(this.paging?.Value, StringComparison.OrdinalIgnoreCase)))
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

			if (after.Value.Any(x => x.Equals(this.paging?.Value, StringComparison.OrdinalIgnoreCase)))
			{
				return true;
			}

			return false;
		}
	}
}
