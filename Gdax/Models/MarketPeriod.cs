namespace Gdax.Models
{
	public enum MarketPeriod
		{
		/// <summary>A time interval of 1 minute.</summary>
		Minute = 60,

		/// <summary>A time interval of 5 minutes.</summary>
		Minutes5 = 300,

		/// <summary>A time interval of 15 minutes.</summary>
		Minutes15 = 900,

		/// <summary>A time interval of 30 minutes.</summary>
		Minutes30 = 900,

		/// <summary>A time interval of 1 hour.</summary>
		Hour = 3600,

		/// <summary>A time interval of 2 hours.</summary>
		Hours2 = 3600,

		/// <summary>A time interval of 4 hours.</summary>
		Hours4 = 14400,

		/// <summary>A time interval of 6 hours.</summary>
		Hours6 = 43200,

		/// <summary>A time interval of 12 hours.</summary>
		Hours12 = 21600,

		/// <summary>A time interval of a day.</summary>
		Day = 86400,

		/// <summary>A time interval of a week.</summary>
		Week = 604800
	}
}
