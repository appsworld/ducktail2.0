using System;
using System.Collections;
using System.Collections.Generic;
using iCollector.Job.Model;
using iCollector.Util;
using Microsoft.Data.Sqlite;

namespace iCollector.Job.Handler;

internal class ReadHisHandler
{
	private static string CLAZZ_NAME_SE;

	private static string CLAZZ_NAME;

	private static readonly string Q1_SE;

	private static readonly string Q1;

	private static readonly string Q2_SE;

	private static readonly string Q2;

	private static readonly string LOG_01_1_SE;

	private static readonly string LOG_01_1;

	private static readonly string LOG_02_1_SE;

	private static readonly string LOG_02_1;

	private static readonly string DATEFM_SE;

	private static readonly string DATEFM;

	private static readonly string TITLE_SE;

	private static readonly string TITLE;

	private static readonly string URL_SE;

	private static readonly string URL;

	private static readonly string VS_SE;

	private static readonly string VS;

	private Logger log = Logger.Instance();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	public void Enrich(CKModel model)
	{
		if (model.Profiles == null || model.Profiles.Count == 0 || 5 == 0)
		{
			return;
		}
		List<CKProfile>.Enumerator enumerator = model.Profiles.GetEnumerator();
		List<CKProfile>.Enumerator enumerator2 = default(List<CKProfile>.Enumerator);
		if (0 == 0)
		{
			enumerator2 = enumerator;
		}
		try
		{
			SqliteConnection sqliteConnection = default(SqliteConnection);
			CKProfile cKProfile = default(CKProfile);
			while (true)
			{
				if (0 == 0)
				{
					if (0 == 0)
					{
						goto IL_0120;
					}
					goto IL_00ae;
				}
				goto IL_004d;
				IL_00ae:
				try
				{
					if (sqliteConnection != null && 5u != 0)
					{
						DataSourceHelper.ExecuteQuery(sqliteConnection, Q1, CreateConsumer(sqliteConnection, cKProfile), 500);
						Logger logger = log;
						LogContext logContext = ctx;
						string lOG_02_ = LOG_02_1;
						int count = cKProfile.HisValues.Count;
						int num;
						if ((7u != 0) ? true : false)
						{
							num = count;
						}
						string message = lOG_02_ + num;
						if (0 == 0)
						{
							logger.Info(logContext, message);
						}
					}
				}
				finally
				{
					do
					{
						((IDisposable)sqliteConnection)?.Dispose();
					}
					while (false);
				}
				goto IL_0120;
				IL_004d:
				while (true)
				{
					Logger logger2 = log;
					LogContext logContext2 = ctx;
					string message2 = LOG_01_1 + cKProfile.Path;
					if (0 == 0 && 0 == 0)
					{
						logger2.Info(logContext2, message2);
					}
					do
					{
						CKProfile cKProfile2 = cKProfile;
						List<DynamicObject> hisValues = new List<DynamicObject>();
						if (0 == 0 && 0 == 0)
						{
							cKProfile2.HisValues = hisValues;
						}
					}
					while (false);
					if (6 == 0)
					{
						break;
					}
					if (false)
					{
						continue;
					}
					goto IL_0089;
				}
				goto IL_009c;
				IL_0089:
				if (!string.IsNullOrEmpty(cKProfile.HisPath))
				{
					if (7 == 0)
					{
						continue;
					}
					goto IL_009c;
				}
				goto IL_0120;
				IL_0120:
				if (enumerator2.MoveNext())
				{
					CKProfile current = enumerator2.Current;
					if ((0 == 0) ? true : false)
					{
						cKProfile = current;
					}
					goto IL_004d;
				}
				break;
				IL_009c:
				SqliteConnection sqliteConnection2 = DataSourceHelper.OpenConnection(cKProfile.HisPath);
				if (3u != 0 && 0 == 0)
				{
					sqliteConnection = sqliteConnection2;
				}
				goto IL_00ae;
			}
		}
		finally
		{
			((IDisposable)enumerator2).Dispose();
		}
	}

	private Consumer<SqliteDataReader>.Accept CreateConsumer(SqliteConnection connection, CKProfile profile)
	{
		SqliteConnection connection2 = connection;
		Consumer<SqliteDataReader>.Accept consumerDetail = CreateConsumerDetail(profile);
		return delegate(SqliteDataReader reader)
		{
			string text = default(string);
			string sql = default(string);
			while (true)
			{
				string @string = reader.GetString(0);
				if (0 == 0 && 0 == 0)
				{
					text = @string;
				}
				while (true)
				{
					if (0 == 0)
					{
						string text2 = Q2 + text;
						if (false)
						{
							goto IL_001d;
						}
						if (3u != 0)
						{
							sql = text2;
						}
					}
					if (false)
					{
						break;
					}
					if (false)
					{
						continue;
					}
					goto IL_001d;
					IL_001d:
					DataSourceHelper.ExecuteQuery(connection2, sql, consumerDetail, 500);
					return;
				}
			}
		};
	}

	private Consumer<SqliteDataReader>.Accept CreateConsumerDetail(CKProfile profile)
	{
		CKProfile profile2 = profile;
		Hashtable checkExisted = new Hashtable();
		return delegate(SqliteDataReader reader)
		{
			string text = default(string);
			string text4 = default(string);
			string text6 = default(string);
			DynamicObject dynamicObject2 = default(DynamicObject);
			while (true)
			{
				string text2;
				if (true)
				{
					if (8 == 0)
					{
						break;
					}
					string @string = reader.GetString(0);
					if (0 == 0)
					{
						text = @string;
					}
					string string2 = reader.GetString(1);
					if (2u != 0)
					{
						text2 = string2;
					}
				}
				long @int = reader.GetInt64(2);
				long microseconds;
				if (6u != 0)
				{
					microseconds = @int;
				}
				while (true)
				{
					DateTime dateTime = DateAppUtils.AdMcs(DateAppUtils.NewDateTime(1601, 1, 1), microseconds);
					DateTime dateTime2;
					if (uint.MaxValue != 0)
					{
						dateTime2 = dateTime;
					}
					if (false)
					{
						break;
					}
					string text3 = dateTime2.ToString(DATEFM);
					if (0 == 0)
					{
						text4 = text3;
					}
					while (true)
					{
						if (5u != 0)
						{
							string text5 = text + text4;
							if (0 == 0)
							{
								text6 = text5;
							}
							if (string.IsNullOrEmpty(text) || checkExisted.ContainsKey(text6))
							{
								break;
							}
							Hashtable hashtable = checkExisted;
							string key = text6;
							object value = true;
							if (6u != 0)
							{
								hashtable.Add(key, value);
							}
						}
						if (1 == 0)
						{
							break;
						}
						DynamicObject dynamicObject = new DynamicObject();
						if (8u != 0)
						{
							dynamicObject2 = dynamicObject;
						}
						if (8 == 0)
						{
							continue;
						}
						goto IL_00b5;
					}
					if (0 == 0)
					{
						return;
					}
				}
				continue;
				IL_00b5:
				DynamicObject dynamicObject3 = dynamicObject2;
				string tITLE = TITLE;
				string value2 = text2;
				if (0 == 0)
				{
					dynamicObject3.Put(tITLE, value2);
				}
				break;
			}
			DynamicObject dynamicObject4 = dynamicObject2;
			string uRL = URL;
			string value3 = text;
			if (0 == 0)
			{
				dynamicObject4.Put(uRL, value3);
			}
			DynamicObject dynamicObject5 = dynamicObject2;
			string vS = VS;
			string value4 = text4;
			if (0 == 0)
			{
				dynamicObject5.Put(vS, value4);
			}
			List<DynamicObject> hisValues = profile2.HisValues;
			DynamicObject item = dynamicObject2;
			if (0 == 0)
			{
				hisValues.Add(item);
			}
		};
	}

	static ReadHisHandler()
	{
		while (true)
		{
			CLAZZ_NAME_SE = "TkbnOCSTfJr4NvwXRuOJbA==.MB4JhUxXAuzcoSE4h1uQ47pBzn3NwDUBDn4NsKHHlt0=";
			CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);
			Q1_SE = "gnn1wpHYpOM0tBKi4OvImw==.vAWeU0Q9Hcmd4gBoAlOvQid4RkC5KiTSx4mwmW3W4IsnbS9jCcEPIMbM1oMiQQMPRiFMFCqoI0/XqB554Pksaw==";
			Q1 = SecurityUtils.ReadStructEncrypted(Q1_SE);
			while (true)
			{
				IL_0032:
				Q2_SE = "gwTxm10UfrcbaYLnANr/IA==.e2WztbRb+TWCO/WJdLq8/YdzeRv4auo5ZE89BQwfZVGYb4QY5htyb6p931DV/+SVZJeECC6LrhxXXU44uh8VDRh+YAT98FwnO6xFXxu3u8M=";
				while (true)
				{
					IL_003c:
					if (uint.MaxValue != 0)
					{
						Q2 = SecurityUtils.ReadStructEncrypted(Q2_SE);
						goto IL_0051;
					}
					goto IL_00ea;
					IL_0051:
					LOG_01_1_SE = "+G+V696b3uC8YglehOeEug==.RajCQK4TwJ8ipdkcrXrML+doUuWVdDw5AzrdqpDzZngsAMMZ7N5hCQgpS4UwIC46";
					LOG_01_1 = SecurityUtils.ReadStructEncrypted(LOG_01_1_SE);
					LOG_02_1_SE = "RizrjJWqfKJPxM23QhJizA==.EkKjTP0QIJw/uOJiyJfapaoWP8Ulc5KchkhdYpf1lCf+DQJoPRicw9bb8UNBNugd";
					while (true)
					{
						LOG_02_1 = SecurityUtils.ReadStructEncrypted(LOG_02_1_SE);
						if (false)
						{
							break;
						}
						DATEFM_SE = "9ZcXl/OSOYp5F92ccMEkpQ==.OmwlaZkxXupmLuA2gmHDi0BEM0C9a95xOHPWmDHmGoPtLcgY3q4cCFigq+xGLuiz";
						DATEFM = SecurityUtils.ReadStructEncrypted(DATEFM_SE);
						if (false)
						{
							goto IL_0032;
						}
						TITLE_SE = "pdRHrxSXTbWwKoM3O88WHQ==.o0w51tFLlsLmwiSWEUIQ7u7HkJa7XV13Cso+niLyhTw=";
						TITLE = SecurityUtils.ReadStructEncrypted(TITLE_SE);
						URL_SE = "7+rIW8vu0WtjgJlb5iGCNQ==.BLCCQ21UnPEThBWZpp5J5j2dzB7jIynSI5gTkOGYXg4=";
						if (false)
						{
							goto IL_003c;
						}
						URL = SecurityUtils.ReadStructEncrypted(URL_SE);
						if (2 == 0)
						{
							continue;
						}
						goto IL_00e0;
					}
					break;
					IL_00ea:
					if (6u != 0)
					{
						VS = SecurityUtils.ReadStructEncrypted(VS_SE);
						return;
					}
					goto IL_0051;
					IL_00e0:
					VS_SE = "29R+1VelKDwQTA/Q0aI/pw==.Awmctn2Kvr99HsxlHCS+hqWqlpz2fyrmFUVlntAr0xU=";
					goto IL_00ea;
				}
				break;
			}
		}
	}
}
