using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Gdax
{
	internal class GdaxRequestBuilder
	{
		private HttpMethod method;
		private String relativePath;
		private Dictionary<String, String> queryParameters;

		public GdaxRequestBuilder()
			: this("/", HttpMethod.Get)
		{
		}

		public GdaxRequestBuilder(String relativePath)
			: this(relativePath, HttpMethod.Get)
		{
		}

		public GdaxRequestBuilder(String relativePath, HttpMethod method)
		{
			this.method = Check.NotNull(method, nameof(method));
			this.relativePath = Check.NotNull(relativePath, nameof(relativePath));
			this.queryParameters = new Dictionary<String, String>();
		}

		public GdaxRequestBuilder AddParameterIfNotNull(String key, String value)
		{
			Check.NotNullOrWhiteSpace(key, nameof(key));

			if (String.IsNullOrWhiteSpace(value))
			{
				return this;
			}

			this.queryParameters.Add(key, value);

			return this;
		}

		public GdaxRequest Build()
		{
			var uriBuilder = new StringBuilder(this.relativePath);

			if (this.queryParameters.Any())
			{
				uriBuilder.Append("?");
			}

			var isFirst = true;
			foreach (var queryParameter in this.queryParameters)
			{
				if (!isFirst)
				{
					uriBuilder.Append("&");
					isFirst = false;
				}

				uriBuilder.Append(queryParameter.Key);
				uriBuilder.Append("=");
				uriBuilder.Append(queryParameter.Value);
			}

			var uri = uriBuilder.ToString();

			return new GdaxRequest(this.method, uri);
		}
	}
}
