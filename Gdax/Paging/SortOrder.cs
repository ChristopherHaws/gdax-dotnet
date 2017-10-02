using System.Runtime.Serialization;

namespace Gdax
{
	public enum SortOrder
	{
		[EnumMember(Value = "asc")]
		Ascending,

		[EnumMember(Value = "des")]
		Descending
	}
}
