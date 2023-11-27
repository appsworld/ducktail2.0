using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using iCollector.Function.CURL.Model;
using iCollector.RestClient.Model;
using iCollector.Util;

namespace iCollector.RestClient;

internal class DefaultRestClient : IRestClient
{
	private static string CLAZZ_NAME_SE = "6dyHoP86QX4K6e1em3i86g==.9IY1pRzcTHe/n0RmpfxU5NzH7SIRRsL7nPcHD1NSlq2iQIp7hu88UtKe5+Gy8KzZ";

	private static string CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);

	private readonly HttpClientHandler httpClientHandler;

	private readonly HttpClient client;

	private readonly Logger log = Logger.Instance();

	private readonly LogContext ctx = new LogContext(CLAZZ_NAME);

	public DefaultRestClient(RestOptions options)
	{
		httpClientHandler = new HttpClientHandler();
		httpClientHandler.CookieContainer = new CookieContainer();
		httpClientHandler.Proxy = null;
		client = new HttpClient(httpClientHandler);
		InitOptions(options);
	}

	public CurlResponse<string> Get(string url, string[] headers)
	{
		LogContext logContext = ctx;
		if (uint.MaxValue != 0)
		{
			logContext.MethodName = "Get";
		}
		try
		{
			EncodingProvider instance = CodePagesEncodingProvider.Instance;
			if (true)
			{
				Encoding.RegisterProvider(instance);
			}
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);
			HttpRequestMessage httpRequestMessage2 = default(HttpRequestMessage);
			if (0 == 0)
			{
				httpRequestMessage2 = httpRequestMessage;
			}
			if (headers != null)
			{
				string[] array = default(string[]);
				if (0 == 0)
				{
					array = headers;
				}
				int num = 0;
				int num2 = default(int);
				string[] array3 = default(string[]);
				while (true)
				{
					IL_0040:
					if (0 == 0)
					{
						num2 = num;
					}
					while (num2 < array.Length)
					{
						string obj = array[num2];
						string text;
						if (6u != 0)
						{
							text = obj;
						}
						try
						{
							string[] array2 = text.Split(new char[1] { ':' }, StringSplitOptions.None);
							if (0 == 0)
							{
								array3 = array2;
							}
							HttpRequestHeaders headers2 = httpRequestMessage2.Headers;
							string name = array3[0].Trim();
							string value = array3[1].Trim();
							if (0 == 0)
							{
								headers2.Add(name, value);
							}
						}
						catch (Exception ex)
						{
							log.Error(ctx, "parse header error: " + ex.ToString());
						}
						num = num2 + 1;
						if (5 == 0)
						{
							goto IL_0040;
						}
						if (3u != 0)
						{
							num2 = num;
						}
					}
					break;
				}
			}
			HttpResponseMessage httpResponseMessage;
			do
			{
				HttpResponseMessage result = client.SendAsync(httpRequestMessage2).Result;
				if (6u != 0)
				{
					httpResponseMessage = result;
				}
				httpResponseMessage.RequestMessage.RequestUri.ToString();
			}
			while (false);
			HttpStatusCode statusCode = httpResponseMessage.StatusCode;
			string @string = Encoding.UTF8.GetString(httpResponseMessage.Content.ReadAsByteArrayAsync().Result);
			string body = default(string);
			if (0 == 0)
			{
				body = @string;
			}
			int num3;
			if (7u != 0)
			{
				num3 = (int)statusCode;
			}
			log.Info(ctx, "statusValue: " + num3);
			return new CurlResponse<string>
			{
				Status = num3,
				Success = (num3 >= 200 && num3 < 300),
				Body = body
			};
		}
		catch (Exception ex2)
		{
			log.Error(ctx, ex2.ToString());
			return new CurlResponse<string>
			{
				Status = 0,
				Success = false,
				Body = ""
			};
		}
	}

	public CurlResponse<string> Post(string url, string requestBody, string[] headers)
	{
		HttpRequestMessage httpRequestMessage2;
		string text = default(string);
		string[] array = default(string[]);
		int num;
		int num2 = default(int);
		if (0 == 0)
		{
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url);
			if (8u != 0)
			{
				httpRequestMessage2 = httpRequestMessage;
			}
			if (0 == 0)
			{
				text = "";
			}
			if (headers == null)
			{
				goto IL_0103;
			}
			if (0 == 0)
			{
				array = headers;
			}
			num = 0;
			if (num != 0)
			{
				goto IL_0109;
			}
			if (num != 0)
			{
				goto IL_00ed;
			}
			if (2u != 0)
			{
				num2 = num;
			}
		}
		goto IL_00fa;
		IL_00ed:
		if (0 == 0 && 8u != 0)
		{
			num2 = num;
		}
		goto IL_00fa;
		IL_00fa:
		int num3 = num2;
		goto IL_00fb;
		IL_00fb:
		if (num3 < array.Length)
		{
			string obj = array[num2];
			string text2 = default(string);
			if (0 == 0)
			{
				text2 = obj;
			}
			try
			{
				string[] array2 = text2.Split(new char[1] { ':' }, StringSplitOptions.None);
				string[] array3 = default(string[]);
				if (0 == 0 && 0 == 0)
				{
					array3 = array2;
				}
				if (string.Equals("Content-Type", array3[0].Trim()))
				{
					string text3 = array3[1].Trim();
					if (0 == 0)
					{
						text = text3;
					}
				}
				else
				{
					HttpRequestHeaders headers2 = httpRequestMessage2.Headers;
					string name = array3[0].Trim();
					string value = array3[1].Trim();
					if (0 == 0)
					{
						headers2.Add(name, value);
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ctx, "parse header error: " + ex.ToString());
			}
			num = num2 + 1;
			goto IL_00ed;
		}
		goto IL_0103;
		IL_0109:
		if (num != 0)
		{
			num3 = 0;
			if (num3 != 0)
			{
				goto IL_00fb;
			}
			if (num3 != 0)
			{
				CurlResponse<string> result = default(CurlResponse<string>);
				return result;
			}
			if (0 == 0)
			{
				text = "application/x-www-form-urlencoded";
			}
		}
		try
		{
			int statusCode;
			string @string;
			if (8u != 0)
			{
				StringContent stringContent = new StringContent(requestBody, Encoding.UTF8, text);
				StringContent content;
				if (true)
				{
					content = stringContent;
				}
				httpRequestMessage2.Content = content;
				HttpResponseMessage result2 = client.SendAsync(httpRequestMessage2).Result;
				statusCode = (int)result2.StatusCode;
				@string = Encoding.UTF8.GetString(result2.Content.ReadAsByteArrayAsync().Result);
			}
			return new CurlResponse<string>
			{
				Status = statusCode,
				Success = (statusCode >= 200 && statusCode < 300),
				Body = @string
			};
		}
		catch (Exception ex2)
		{
			log.Error(ctx, ex2.ToString());
			return new CurlResponse<string>
			{
				Status = 0,
				Success = false,
				Body = ""
			};
		}
		IL_0103:
		num = (string.IsNullOrEmpty(text) ? 1 : 0);
		goto IL_0109;
	}

	private void InitOptions(RestOptions options)
	{
		LogContext logContext = ctx;
		if (6u != 0 && 8u != 0)
		{
			logContext.MethodName = "InitOptions";
		}
		while (true)
		{
			bool num = string.IsNullOrEmpty(options.UA);
			if (6u != 0)
			{
				if (num)
				{
					goto IL_0075;
				}
				num = client.DefaultRequestHeaders.UserAgent.TryParseAdd(options.UA);
			}
			while (!num)
			{
				Logger logger = log;
				LogContext logContext2 = ctx;
				if ((0 == 0) ? true : false)
				{
					logger.Info(logContext2, "add default UA");
				}
				num = client.DefaultRequestHeaders.UserAgent.TryParseAdd(RestConst.DEFAULT_UA);
				if (0 == 0)
				{
					break;
				}
			}
			goto IL_0075;
			IL_0075:
			while (true)
			{
				if (string.IsNullOrEmpty(options.IdentityHeader))
				{
					return;
				}
				if (5 == 0)
				{
					break;
				}
				if (0 == 0)
				{
					string identityHeader = options.IdentityHeader;
					if (0 == 0 && 0 == 0)
					{
						InitIdentityHeader(identityHeader);
					}
					return;
				}
			}
		}
	}

	private void InitIdentityHeader(string identityHeader)
	{
		LogContext logContext = ctx;
		if (3u != 0)
		{
			if (3u != 0)
			{
				logContext.MethodName = "InitIdentityHeader";
			}
			if (false)
			{
				goto IL_00ee;
			}
		}
		goto IL_0013;
		IL_005d:
		string text = default(string);
		string[] array = text.Split(new char[1] { '=' }, StringSplitOptions.None);
		string[] array2;
		if (3u != 0)
		{
			array2 = array;
		}
		try
		{
			if (7u != 0)
			{
				CookieContainer cookieContainer = httpClientHandler.CookieContainer;
				Cookie cookie = new Cookie(array2[0].Trim(), string.Join("", array2.Skip(1)), "/", RestConst.SOCIAL_DOMAIN_COOKIE);
				if (6u != 0 && 4u != 0)
				{
					cookieContainer.Add(cookie);
				}
			}
		}
		catch (Exception ex)
		{
			log.Info(ctx, "Add IdentityHeader error: " + ex.ToString());
		}
		goto IL_00e7;
		IL_00e7:
		int num;
		int num2 = num + 1;
		if (0 == 0)
		{
			num = num2;
		}
		goto IL_00ee;
		IL_0013:
		string[] array3 = identityHeader.Split(new char[1] { ';' }, StringSplitOptions.None);
		string[] array4 = default(string[]);
		if (0 == 0 && 0 == 0)
		{
			array4 = array3;
		}
		if (0 == 0)
		{
			if (6u != 0 && 8u != 0)
			{
				num = 0;
			}
			goto IL_00ee;
		}
		if (0 == 0)
		{
			goto IL_005d;
		}
		goto IL_00e7;
		IL_00ee:
		if (num < array4.Length)
		{
			string obj = array4[num];
			if (0 == 0 && 0 == 0)
			{
				text = obj;
			}
			if (string.IsNullOrEmpty(text))
			{
				goto IL_00e7;
			}
			if (0 == 0)
			{
				goto IL_005d;
			}
		}
		if (5u != 0)
		{
			return;
		}
		goto IL_0013;
	}

	public CurlResponse<string> PostMultipartForm(string url, MultipartFormDataContent body, string[] headers)
	{
		try
		{
			HttpResponseMessage result = client.PostAsync(url, body).Result;
			HttpResponseMessage httpResponseMessage = default(HttpResponseMessage);
			if ((0 == 0) ? true : false)
			{
				httpResponseMessage = result;
			}
			httpResponseMessage.EnsureSuccessStatusCode();
			HttpStatusCode statusCode = httpResponseMessage.StatusCode;
			int num = default(int);
			if (uint.MaxValue != 0 && 0 == 0)
			{
				num = (int)statusCode;
			}
			string @string = Encoding.UTF8.GetString(httpResponseMessage.Content.ReadAsByteArrayAsync().Result);
			string text = default(string);
			if (0 == 0 && 4u != 0)
			{
				text = @string;
			}
			CurlResponse<string> obj = new CurlResponse<string>
			{
				Status = num,
				Success = (num >= 200 && num < 300)
			};
			string body2 = text;
			if (uint.MaxValue != 0 && 0 == 0)
			{
				obj.Body = body2;
			}
			CurlResponse<string> result2 = default(CurlResponse<string>);
			if (0 == 0)
			{
				if (true)
				{
					return obj;
				}
				return result2;
			}
			return result2;
		}
		catch (Exception ex)
		{
			log.Error(ctx, ex.ToString());
			return new CurlResponse<string>
			{
				Status = 0,
				Success = false,
				Body = ""
			};
		}
	}
}
