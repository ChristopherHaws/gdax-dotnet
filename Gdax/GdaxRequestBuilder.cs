using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using Gdax.Serialization;

namespace Gdax
{
	public class GdaxRequestBuilder
	{
		private HttpMethod method;
		private String relativePath;
		private Dictionary<String, String> queryParameters;
		private String body;

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

		public GdaxRequestBuilder AddEnumParameterIfNotNull<T>(String key, T? value)
			where T : struct, IConvertible
		{
			Check.NotNullOrWhiteSpace(key, nameof(key));

			if (value == null)
			{
				return this;
			}
			
			var typeInfo = typeof(T).GetTypeInfo();
			
			if (!typeInfo.IsEnum)
			{
				throw new ArgumentException("Value is not a valid enum.", nameof(value));
			}
			
			var values = typeInfo.IsDefined(typeof(FlagsAttribute), true)
				? value.ToString().Split(',').Select(flag => (T)Enum.Parse(typeof(T), flag)).ToList()
				: new List<T>() { value.Value };

			foreach (var enumValue in values)
			{
				this.queryParameters.Add(key, Enum.GetName(typeof(T), enumValue).ToLower());
			}
			
			return this;
		}

		public GdaxRequestBuilder AddPagingOptions<TCursor>(PagingOptions<TCursor> paging, ICursorEncoder<TCursor> encoder)
		{
			if (paging == null)
			{
				return this;
			}

			this.AddParameterIfNotNull("limit", paging.Limit?.ToString());
			this.AddParameterIfNotNull("before", encoder.Encode(paging.NewerThan));
			this.AddParameterIfNotNull("after", encoder.Encode(paging.OlderThan));

			return this;
		}


		public GdaxRequestBuilder AddBody<T>(T value, ISerialzer serialzer)
		{
			this.body = serialzer.Serialize(value);

			return this;
		}

		protected virtual IDictionary<String, String> GetAdditionalParameters()
		{
			return null;
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

				uriBuilder.Append(WebUtility.UrlEncode(key));
				uriBuilder.Append("=");
				uriBuilder.Append(WebUtility.UrlEncode(value));
			}

			void AppendParameters(IDictionary<String, String> parameters)
			{
				foreach (var parameter in parameters)
				{
					AppendParameter(parameter.Key, parameter.Value);
				}
			}

			AppendParameters(this.queryParameters);

			var additionalParameters = this.GetAdditionalParameters();
			if (additionalParameters != null)
			{
				AppendParameters(additionalParameters);
			}

			var request = new GdaxRequest(this.method, uriBuilder.ToString());

			if (this.body != null)
			{
				request.RequestBody = this.body;
			}

			return request;
		}
	}
}
