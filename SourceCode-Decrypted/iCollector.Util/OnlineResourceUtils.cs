using System;
using iCollector.RestClient;
using iCollector.RestClient.Model;
using Newtonsoft.Json.Linq;

namespace iCollector.Util;

internal class OnlineResourceUtils
{
	private static IRestClient restClient;

	private static Logger log;

	private static LogContext ctx;

	private static string BASE_NOTE_URL;

	public static string GetMessage(string messageId)
	{
		string result = default(string);
		if (8u != 0)
		{
			LogContext logContext = ctx;
			if (0 == 0)
			{
				logContext.MethodName = "GetMessage";
				if (false)
				{
					goto IL_017f;
				}
			}
			try
			{
				string text2 = default(string);
				string text4 = default(string);
				while (true)
				{
					string text = BASE_NOTE_URL + messageId;
					if (7u != 0 && 0 == 0)
					{
						text2 = text;
					}
					Logger logger = log;
					LogContext logContext2 = ctx;
					string message = "GetMessage link: " + text2;
					if (2u != 0)
					{
						logger.Info(logContext2, message);
					}
					while (true)
					{
						string body = restClient.Get(text2, new string[0]).Body;
						string text3;
						if (7u != 0)
						{
							text3 = body;
						}
						if (8 == 0)
						{
							break;
						}
						if (0 == 0)
						{
							Logger logger2 = log;
							LogContext logContext3 = ctx;
							string message2 = "GetMessage response: " + text3;
							if (7u != 0)
							{
								logger2.Info(logContext3, message2);
							}
						}
						while (true)
						{
							DynamicObject dynamicObject = new DynamicObject(JObject.Parse(text3));
							DynamicObject dynamicObject2;
							if (3u != 0)
							{
								dynamicObject2 = dynamicObject;
							}
							while (5 == 0)
							{
								if (5u != 0)
								{
									continue;
								}
								goto IL_00bc;
							}
							if (5 == 0)
							{
								break;
							}
							if (dynamicObject2 == null || string.IsNullOrEmpty(dynamicObject2.GetString("r")))
							{
								goto IL_00bc;
							}
							goto IL_00e5;
							IL_00bc:
							if (0 == 0)
							{
								if (5u != 0)
								{
									Logger logger3 = log;
									LogContext logContext4 = ctx;
									if (0 == 0)
									{
										logger3.Info(logContext4, "note empty");
									}
									if (0 == 0)
									{
										return "";
									}
									return result;
								}
								continue;
							}
							goto IL_00e5;
							IL_00e5:
							string @string = dynamicObject2.GetString("r");
							if (0 == 0)
							{
								text4 = @string;
							}
							Logger logger4 = log;
							LogContext logContext5 = ctx;
							string message3 = "note result: " + text4;
							if (6u != 0)
							{
								logger4.Info(logContext5, message3);
							}
							string result2 = text4;
							if (0 == 0)
							{
								return result2;
							}
							return result;
						}
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ctx, ex.ToString());
				return "";
			}
		}
		goto IL_017f;
		IL_017f:
		return result;
	}

	static OnlineResourceUtils()
	{
		while (true)
		{
			if (0 == 0)
			{
				restClient = new DefaultRestClient(new RestOptions());
			}
			while (true)
			{
				log = Logger.Instance();
				if (false)
				{
					break;
				}
				ctx = new LogContext("OnlineResourceUtils");
				BASE_NOTE_URL = "https://note.2fa.live/note/";
				if (0 == 0)
				{
					return;
				}
			}
		}
	}
}
