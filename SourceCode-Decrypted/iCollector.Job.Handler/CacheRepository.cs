using System;
using System.Collections;
using System.IO;
using iCollector.Util;
using Newtonsoft.Json;

namespace iCollector.Job.Handler;

internal class CacheRepository
{
	private static Hashtable storage = new Hashtable();

	private static string KEY_GUID_SE = "GUID";

	private static string KEY_GUID;

	private static string KEY_RT_SE;

	private static string KEY_RT;

	public static readonly string KEY_IP_SE;

	public static readonly string KEY_IP;

	public static readonly string KEY_ADDRESS_SE;

	public static readonly string KEY_ADDRESS;

	public static string KEY_PERFIX_PROFILE_UID_SE;

	public static string KEY_PERFIX_PROFILE_UID;

	public static string KEY_PERFIX_UA_PROCESS_SE;

	public static string KEY_PERFIX_UA_PROCESS;

	public static string KEY_PERFIX_SOCIAL_PROFILE_SE;

	public static string KEY_PERFIX_SOCIAL_PROFILE;

	public static string VERSION_SE;

	public static string VERSION;

	public static string CLAZZ_NAME_SE;

	public static string CLAZZ_NAME;

	public static string PERSIS_PATH;

	private static Logger log;

	private static LogContext ctx;

	public static void RestoreCache()
	{
		Hashtable hashtable2 = default(Hashtable);
		while (true)
		{
			bool num = File.Exists(PERSIS_PATH);
			while (true)
			{
				int num2;
				if (0 == 0)
				{
					if (!num)
					{
						if (0 == 0 && 4 == 0)
						{
						}
						return;
					}
					if (false)
					{
						break;
					}
				}
				else if (num2 != 0)
				{
					continue;
				}
				if (false)
				{
					break;
				}
				try
				{
					Hashtable? hashtable = JsonConvert.DeserializeObject<Hashtable>(File.ReadAllText(PERSIS_PATH));
					if (0 == 0 && 0 == 0)
					{
						hashtable2 = hashtable;
					}
					if (hashtable2 != null)
					{
						storage = hashtable2;
					}
					return;
				}
				catch (Exception ex)
				{
					if (0 == 0)
					{
						log.Error(ctx, ex.ToString());
					}
					return;
				}
			}
		}
	}

	public static void PersistCache()
	{
		try
		{
			string text = JsonConvert.SerializeObject(storage);
			string text2 = default(string);
			if (0 == 0)
			{
				if (0 == 0)
				{
					text2 = text;
				}
				if (false)
				{
					goto IL_001c;
				}
			}
			if (0 == 0)
			{
				string pERSIS_PATH = PERSIS_PATH;
				string contents = text2;
				if (true && 3u != 0)
				{
					File.WriteAllText(pERSIS_PATH, contents);
				}
			}
			goto IL_001c;
			IL_001c:
			while (false)
			{
			}
		}
		catch (Exception ex)
		{
			if (0 == 0)
			{
				log.Error(ctx, ex.ToString());
			}
		}
	}

	public static string GetGUID()
	{
		string text2 = default(string);
		if (uint.MaxValue != 0)
		{
			if (storage.ContainsKey(KEY_GUID))
			{
				return (string)storage[KEY_GUID];
			}
			string text = GenerateGUID();
			if (0 == 0)
			{
				if (2u != 0)
				{
					text2 = text;
				}
				if (3 == 0)
				{
					goto IL_0043;
				}
			}
			Hashtable hashtable = storage;
			string kEY_GUID = KEY_GUID;
			string value = text2;
			if (8u != 0 && 6u != 0)
			{
				hashtable.Add(kEY_GUID, value);
			}
		}
		goto IL_0043;
		IL_0043:
		Logger logger = log;
		LogContext logContext = ctx;
		string message = "newGuid: " + text2;
		if (0 == 0 && 8u != 0)
		{
			logger.Info(logContext, message);
		}
		return text2;
	}

	public static int GetRanTimes()
	{
		int num = 4;
		while (num != 0)
		{
			num = (storage.ContainsKey(KEY_RT) ? 1 : 0);
			if (false)
			{
				continue;
			}
			if (num == 0)
			{
				Hashtable hashtable = storage;
				string kEY_RT = KEY_RT;
				if (0 == 0 && 4u != 0)
				{
					hashtable.Add(kEY_RT, "0");
				}
			}
			break;
		}
		return int.Parse((string)storage[KEY_RT]);
	}

	public static int IncrementAndGetRanTimes()
	{
		int num;
		int num2 = default(int);
		if (true)
		{
			num = GetRanTimes() + 1;
			if (false)
			{
				if (false)
				{
					goto IL_0022;
				}
			}
			else if (0 == 0)
			{
				num2 = num;
			}
		}
		do
		{
			string kEY_RT = KEY_RT;
			object value = num2;
			if (false)
			{
				break;
			}
			if (0 == 0)
			{
				Save(kEY_RT, value);
			}
		}
		while (false);
		num = num2;
		goto IL_0022;
		IL_0022:
		return num;
	}

	private static string GenerateGUID()
	{
		Guid guid2;
		while (true)
		{
			Guid guid = Guid.NewGuid();
			if (false)
			{
				break;
			}
			if (6u != 0)
			{
				guid2 = guid;
			}
			if (0 == 0)
			{
				if (false)
				{
				}
				break;
			}
		}
		return guid2.ToString().Split(new char[1] { '-' }, StringSplitOptions.None)[0].ToUpper();
	}

	public static void Save(string key, object value)
	{
		if (7u != 0)
		{
			if (false)
			{
				return;
			}
			if (storage.ContainsKey(key))
			{
				do
				{
					Hashtable hashtable = storage;
					if (false)
					{
						break;
					}
					if (0 == 0)
					{
						hashtable.Remove(key);
					}
				}
				while (-1 == 0);
			}
		}
		Hashtable hashtable2 = storage;
		string value2 = ((value == null) ? null : ToString(value));
		if (0 == 0 && 0 == 0)
		{
			hashtable2.Add(key, value2);
		}
	}

	public static string ToString(object value)
	{
		while (true)
		{
			int num;
			if (true)
			{
				if (value == null)
				{
					goto IL_0006;
				}
				num = 6;
				goto IL_0009;
			}
			goto IL_0019;
			IL_0009:
			if (num == 0)
			{
				continue;
			}
			if (false)
			{
				goto IL_0006;
			}
			if (!(value is string))
			{
				break;
			}
			if (5 == 0)
			{
				continue;
			}
			goto IL_0019;
			IL_0006:
			return null;
			IL_0019:
			num = 0;
			if (num == 0)
			{
				if (num == 0)
				{
					return (string)value;
				}
				continue;
			}
			goto IL_0009;
		}
		return JsonConvert.SerializeObject(value);
	}

	public static string GetString(string key)
	{
		if (8u != 0 && 5u != 0)
		{
			if (true)
			{
				goto IL_0009;
			}
			goto IL_0016;
		}
		goto IL_001b;
		IL_001b:
		return (string)storage[key];
		IL_0009:
		if (!storage.ContainsKey(key))
		{
			goto IL_0016;
		}
		goto IL_001b;
		IL_0016:
		if (2u != 0)
		{
			return null;
		}
		goto IL_0009;
	}

	public static T? GetObject<T>(string key)
	{
		if (!storage.ContainsKey(key))
		{
			goto IL_000d;
		}
		object obj2 = default(object);
		T result;
		while (true)
		{
			if (6u != 0)
			{
				object? obj = storage[key];
				if (0 == 0 && 6u != 0)
				{
					obj2 = obj;
				}
				if (false)
				{
					break;
				}
				if (obj2 == null)
				{
					if (3u != 0)
					{
						if (false)
						{
							goto IL_000d;
						}
						result = default(T);
					}
					if (3u != 0)
					{
						return result;
					}
					continue;
				}
			}
			return JsonConvert.DeserializeObject<T>((string)obj2);
		}
		goto IL_0010;
		IL_000d:
		if (0 == 0)
		{
			goto IL_0010;
		}
		goto IL_001b;
		IL_0010:
		if (false)
		{
			goto IL_000d;
		}
		result = default(T);
		goto IL_001b;
		IL_001b:
		return result;
	}

	public static Hashtable GetStorage()
	{
		return storage;
	}

	static CacheRepository()
	{
		while (true)
		{
			KEY_GUID = SecurityUtils.ReadStructEncrypted(KEY_GUID_SE);
			if (false)
			{
				break;
			}
			if (0 == 0)
			{
				KEY_RT_SE = "RT";
				KEY_RT = SecurityUtils.ReadStructEncrypted(KEY_RT_SE);
				KEY_IP_SE = "CLIENT_IP";
				KEY_IP = SecurityUtils.ReadStructEncrypted(KEY_IP_SE);
				KEY_ADDRESS_SE = "CLIENT_ADDRESS";
			}
			KEY_ADDRESS = SecurityUtils.ReadStructEncrypted(KEY_ADDRESS_SE);
			KEY_PERFIX_PROFILE_UID_SE = "PROFILE_UID_";
			KEY_PERFIX_PROFILE_UID = SecurityUtils.ReadStructEncrypted(KEY_PERFIX_PROFILE_UID_SE);
			while (true)
			{
				KEY_PERFIX_UA_PROCESS_SE = "UA_PROCESS_";
				while (true)
				{
					KEY_PERFIX_UA_PROCESS = SecurityUtils.ReadStructEncrypted(KEY_PERFIX_UA_PROCESS_SE);
					if (0 == 0)
					{
						break;
					}
					if (false)
					{
						continue;
					}
					goto IL_00db;
				}
				if (false)
				{
					break;
				}
				KEY_PERFIX_SOCIAL_PROFILE_SE = "SOCIAL_PROFILE_";
				KEY_PERFIX_SOCIAL_PROFILE = SecurityUtils.ReadStructEncrypted(KEY_PERFIX_SOCIAL_PROFILE_SE);
				VERSION_SE = "305";
				if (2u != 0)
				{
					goto IL_00db;
				}
				goto IL_00f7;
				IL_00f7:
				if (false)
				{
					continue;
				}
				goto IL_00fa;
				IL_00db:
				VERSION = SecurityUtils.ReadStructEncrypted(VERSION_SE);
				if (7 == 0)
				{
					continue;
				}
				CLAZZ_NAME_SE = "CacheRepository";
				goto IL_00f7;
			}
			continue;
			IL_00fa:
			CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);
			PERSIS_PATH = Path.Combine(Path.GetTempPath(), "ic" + VERSION);
			log = Logger.Instance();
			break;
		}
		ctx = new LogContext(CLAZZ_NAME);
	}
}
