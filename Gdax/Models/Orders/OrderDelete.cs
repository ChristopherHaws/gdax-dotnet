using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Gdax.Models.Orders
{
    public class OrderDelete
    {
		[JsonProperty("")]
		public Guid Id { get; set; }
	}
}
