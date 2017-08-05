using System;
using System.Collections.Generic;
using System.Linq;

namespace Gdax.CommonModels
{
	public class PaginatedResult<T>
	{
		private readonly GdaxResponse<IEnumerable<T>> response;

		public PaginatedResult(GdaxResponse<IEnumerable<T>> response)
		{
			this.response = response;
		}

		public IEnumerable<T> Results => this.response.Value;

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
				Value = after.Value.First()
			};
		}
	}
}
