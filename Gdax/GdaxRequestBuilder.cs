using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Gdax.CommonModels;

namespace Gdax
{
	internal class GdaxRequestBuilder
	{
		private HttpMethod method;
		private String relativePath;
		private Dictionary<String, String> queryParameters;
		private Int32? limit;
		private CursorType cursorType;
		private String cursorValue;

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

		public GdaxRequestBuilder SetPageLimit(Int32? limit)
		{
			this.limit = limit;
			return this;
		}

		public GdaxRequestBuilder SetCursor(CursorType type, String value)
		{
			this.cursorType = type;
			this.cursorValue = value;
			return this;
		}

		public GdaxRequest Build()
		{
			var uriBuilder = new StringBuilder(this.relativePath);
			var isFirstParameter = true;

			void AppendParameter(String key, String value)
			{
				if (isFirstParameter)
				{
					uriBuilder.Append("?");
					isFirstParameter = false;
				}
				else
				{
					uriBuilder.Append("&");
				}

				uriBuilder.Append(key);
				uriBuilder.Append("=");
				uriBuilder.Append(value);
			}

			foreach (var queryParameter in this.queryParameters)
			{
				AppendParameter(queryParameter.Key, queryParameter.Value);
			}

			if (this.limit.HasValue)
			{
				AppendParameter("limit", this.limit.Value.ToString());
			}

			if (!String.IsNullOrWhiteSpace(this.cursorValue))
			{
				AppendParameter(this.cursorType.ToString().ToLower(), this.cursorValue);
			}

			var uri = uriBuilder.ToString();

			return new GdaxRequest(this.method, uri);
		}
	}
}
