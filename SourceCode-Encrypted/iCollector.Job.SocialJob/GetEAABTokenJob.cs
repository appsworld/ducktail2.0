using System;
using System.Collections.Generic;
using iCollector.Job.Model;
using iCollector.Model;
using iCollector.Util;

namespace iCollector.Job.SocialJob;

internal class GetEAABTokenJob
{
	private static string CLAZZ_NAME_SE = "B6zN9UuLAPqZ6Gz0P5uEmQ==.vL9+1bRxVhQfOkAT6YfnYMNfPV6dx6AOavEEKiqjYtc=";

	private static string CLAZZ_NAME;

	private static string METHOD_EXEC_SE;

	private static string METHOD_EXEC;

	private static string METHOD_RPEID_SE;

	private static string METHOD_RPEID;

	private static string METHOD_RAAAB_SE;

	private static string METHOD_RAAAB;

	private static string GET_PEID_SE;

	private static string GET_PEID;

	private static string GET_PEID_JOB_SE;

	private static string GET_PEID_JOB;

	private static string GET_EAAB_SE;

	private static string GET_EAAB;

	private static string REGEX_1_SE;

	private static string REGEX_1;

	private static string REGEX_2_SE;

	private static string REGEX_2;

	private static string REGEX_3_SE;

	private static string REGEX_3;

	private static string REGEX_4_SE;

	private static string REGEX_4;

	private static string LOG_1_SE;

	private static string LOG_1;

	private static string EAAB_SE;

	private static string EAAB;

	public static readonly string URL_1_SE;

	public static readonly string URL_1;

	public static readonly string URL_2_SE;

	public static readonly string URL_2;

	public static readonly string URL_3_SE;

	public static readonly string URL_3;

	public static readonly string URL_4_SE;

	public static readonly string URL_4;

	private Logger log = Logger.Instance();

	private JobExecutor jobExecutor = new JobExecutor();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	public string Execute(SocialProfile profile)
	{
		try
		{
			LogContext logContext = ctx;
			string mETHOD_EXEC = METHOD_EXEC;
			if (5u != 0)
			{
				logContext.MethodName = mETHOD_EXEC;
			}
			string adAccountId = profile.AdAccountId;
			string text;
			if (3u != 0)
			{
				text = adAccountId;
			}
			Step step2;
			if (string.IsNullOrEmpty(text))
			{
				Step step = new Step();
				if (2u != 0)
				{
					step2 = step;
				}
				Step step3 = step2;
				if (true)
				{
					step3.Index = 0;
				}
				Step step4 = step2;
				string gET_PEID = GET_PEID;
				if (8u != 0)
				{
					step4.Name = gET_PEID;
				}
				Step step5 = step2;
				if (uint.MaxValue != 0)
				{
					step5.Type = StepType.CURL;
				}
				Step step6 = step2;
				if (uint.MaxValue != 0)
				{
					step6.StopWhenSuccess = true;
				}
				Step step7 = step2;
				if (0 == 0)
				{
					step7.StopWhenFailed = true;
				}
				Step step8 = step2;
				Func<string, StepResult> checkResultFunc = (string r) => ResolvePEID(r);
				if (0 == 0)
				{
					step8.CheckResultFunc = checkResultFunc;
				}
				Step step9 = step2;
				CURLStepSpec cURLStepSpec = new CURLStepSpec();
				CURLStepSpec cURLStepSpec2 = default(CURLStepSpec);
				if (0 == 0)
				{
					cURLStepSpec2 = cURLStepSpec;
				}
				CURLStepSpec cURLStepSpec3 = cURLStepSpec2;
				string uRL_ = URL_1;
				if (4u != 0)
				{
					cURLStepSpec3.Url = uRL_;
				}
				CURLStepSpec cURLStepSpec4 = cURLStepSpec2;
				string[] headers = new string[2] { "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" };
				if (0 == 0)
				{
					cURLStepSpec4.Headers = headers;
				}
				cURLStepSpec2.RestClient = profile.RestClient;
				step9.Spec = cURLStepSpec2;
				Step item = step2;
				step2 = new Step();
				step2.Index = 0;
				step2.Name = GET_PEID;
				step2.Type = StepType.CURL;
				step2.StopWhenSuccess = true;
				step2.StopWhenFailed = true;
				step2.CheckResultFunc = (string r) => ResolvePEIDV2(r);
				step2.Spec = new CURLStepSpec
				{
					Url = URL_2,
					Headers = new string[2] { "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" },
					RestClient = profile.RestClient
				};
				Step item2 = step2;
				JobModel<string> jobModel = new JobModel<string>
				{
					Name = GET_PEID_JOB,
					Steps = new List<Step> { item, item2 },
					SuccessWhenAnyStepSuccess = true,
					ResultAtAnyLastStepSuccess = true
				};
				jobExecutor.Execute(jobModel);
				log.Info(ctx, GET_PEID_JOB + jobModel.Result);
				profile.AdAccountId = jobModel.Result;
				text = profile.AdAccountId;
			}
			if (string.IsNullOrEmpty(text))
			{
				return "";
			}
			step2 = new Step();
			step2.Index = 0;
			step2.Name = GET_EAAB;
			step2.Type = StepType.CURL;
			step2.StopWhenSuccess = true;
			step2.StopWhenFailed = true;
			step2.CheckResultFunc = (string r) => ResolveEAAB(r);
			step2.Spec = new CURLStepSpec
			{
				Url = URL_3 + text,
				Headers = new string[2] { "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" },
				RestClient = profile.RestClient
			};
			Step item3 = step2;
			step2 = new Step();
			step2.Index = 0;
			step2.Name = GET_EAAB;
			step2.Type = StepType.CURL;
			step2.StopWhenSuccess = true;
			step2.StopWhenFailed = true;
			step2.CheckResultFunc = (string r) => ResolveEAAB(r);
			step2.Spec = new CURLStepSpec
			{
				Url = URL_4 + text,
				Headers = new string[2] { "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" },
				RestClient = profile.RestClient
			};
			Step item4 = step2;
			JobModel<string> jobModel2 = new JobModel<string>
			{
				Name = GET_EAAB,
				Steps = new List<Step> { item3, item4 },
				SuccessWhenAnyStepSuccess = true,
				ResultAtAnyLastStepSuccess = true
			};
			jobExecutor.Execute(jobModel2);
			return jobModel2.Result;
		}
		catch (Exception ex)
		{
			log.Error(ctx, ex.ToString());
			return null;
		}
	}

	private StepResult ResolvePEID(string response)
	{
		if (0 == 0)
		{
			LogContext logContext = ctx;
			string mETHOD_RPEID = METHOD_RPEID;
			if (7u != 0 && 2u != 0)
			{
				logContext.MethodName = mETHOD_RPEID;
			}
		}
		string text = RegexUtils.FindRegex(response, REGEX_1);
		string text2 = default(string);
		if (6u != 0 && 0 == 0)
		{
			text2 = text;
		}
		int num = -1;
		while (true)
		{
			if (num != 0)
			{
				num = (string.IsNullOrEmpty(text2) ? 1 : 0);
				if (3 == 0)
				{
					goto IL_0045;
				}
				if (num == 0)
				{
					goto IL_003f;
				}
			}
			string text3 = RegexUtils.FindRegex(response, REGEX_2);
			if (0 == 0 && 6u != 0)
			{
				text2 = text3;
			}
			goto IL_003f;
			IL_003f:
			num = (string.IsNullOrEmpty(text2) ? 1 : 0);
			goto IL_0045;
			IL_0045:
			while (0 == 0)
			{
				if (num != 0)
				{
					return StepResult.Of(success: false, "");
				}
				num = 1;
				if (num != 0)
				{
					return StepResult.Of((byte)num != 0, text2);
				}
			}
		}
	}

	private StepResult ResolvePEIDV2(string response)
	{
		string text2 = default(string);
		int num;
		if (true)
		{
			LogContext logContext = ctx;
			string mETHOD_RPEID = METHOD_RPEID;
			if (2u != 0 && 0 == 0)
			{
				logContext.MethodName = mETHOD_RPEID;
			}
			string text = RegexUtils.FindRegex(response, REGEX_3);
			if (0 == 0 && 4u != 0)
			{
				text2 = text;
			}
			num = (string.IsNullOrEmpty(text2) ? 1 : 0);
			goto IL_0028;
		}
		goto IL_002a;
		IL_0028:
		if (num == 0)
		{
			return StepResult.Of(success: true, text2);
		}
		goto IL_002a;
		IL_002a:
		num = 0;
		if (num == 0)
		{
			return StepResult.Of((byte)num != 0, "");
		}
		goto IL_0028;
	}

	private StepResult ResolveEAAB(string response)
	{
		int num = 0;
		if (num == 0)
		{
			if (num == 0)
			{
				LogContext logContext = ctx;
				string mETHOD_RAAAB = METHOD_RAAAB;
				if (4u != 0)
				{
					if (0 == 0)
					{
						logContext.MethodName = mETHOD_RAAAB;
					}
					if (7 == 0)
					{
						goto IL_0025;
					}
					if (8 == 0)
					{
						goto IL_0044;
					}
				}
				goto IL_0016;
			}
			goto IL_0056;
		}
		goto IL_005a;
		IL_002d:
		Logger logger = log;
		LogContext logContext2 = ctx;
		string lOG_ = LOG_1;
		if (0 == 0 && 7u != 0)
		{
			logger.Info(logContext2, lOG_);
		}
		goto IL_0044;
		IL_0016:
		string text = RegexUtils.FindRegex(response, REGEX_4);
		string text2 = default(string);
		if (4u != 0 && 5u != 0)
		{
			text2 = text;
		}
		goto IL_0025;
		IL_004b:
		return StepResult.Of((byte)num != 0, "");
		IL_005a:
		return StepResult.Of((byte)num != 0, EAAB + text2);
		IL_0044:
		if (false)
		{
			goto IL_0016;
		}
		if (-1 == 0)
		{
			goto IL_002d;
		}
		num = 0;
		goto IL_004b;
		IL_0056:
		num = 1;
		if (num == 0)
		{
			goto IL_004b;
		}
		goto IL_005a;
		IL_0025:
		if (string.IsNullOrEmpty(text2))
		{
			goto IL_002d;
		}
		goto IL_0056;
	}

	static GetEAABTokenJob()
	{
		if (8 == 0)
		{
			goto IL_0119;
		}
		CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);
		METHOD_EXEC_SE = "YBO6gQE0bcyfPDAPF5F23w==.iWXza3yyyMiUJx3KVekrkMRMLVMP5M2tQt1eVCKlHng=";
		METHOD_EXEC = SecurityUtils.ReadStructEncrypted(METHOD_EXEC_SE);
		METHOD_RPEID_SE = "TIpmLKvfwcwtd0VvrqQbrA==.1jLifXJ/x3Pxf7dn79wv1dRi4GPZWd7g+pumaHpYaZc=";
		METHOD_RPEID = SecurityUtils.ReadStructEncrypted(METHOD_RPEID_SE);
		if (0 == 0)
		{
			METHOD_RAAAB_SE = "uf8JnuLH3A0bheY/gce4hA==.LDwihqyrQFEFlUuGpEpY6PwCXq/Beh0M4UUmIb4VMis=";
			METHOD_RAAAB = SecurityUtils.ReadStructEncrypted(METHOD_RAAAB_SE);
			GET_PEID_SE = "ZjvBDFdBVXks9YZWXfLyTg==.L0J2T2WPGC8Q+VVOXYkr+nNUQ7A0D3bjM9fAIHdrzYw=";
			GET_PEID = SecurityUtils.ReadStructEncrypted(GET_PEID_SE);
			GET_PEID_JOB_SE = "pU1qTrckywYx7ijzLp51xA==.HheGLAsnkTYmWwQoPGsm2goCYKQrNU9onHIxyS1vyPc=";
			GET_PEID_JOB = SecurityUtils.ReadStructEncrypted(GET_PEID_JOB_SE);
			GET_EAAB_SE = "P5+/2XCt0Njofa7MwR/3IQ==.wpjb2tSNiJ4Uzu3d+saRULS4NiWza5oAgsZCIRs09kU=";
			GET_EAAB = SecurityUtils.ReadStructEncrypted(GET_EAAB_SE);
			goto IL_00bb;
		}
		goto IL_0160;
		IL_01b4:
		URL_4_SE = "tg5NNfYByhpdaQvc5iobRA==.S8mbt2Dcic1FmLnrmtybVmX6C2AGnIINBeM0yPfVuaJezU14wPQMRSz3fon2nB+2/QvtDxGASkkztoh7Wa8RaHuf0dBDFYLuhyEsYunvF7g=";
		URL_4 = SecurityUtils.ReadStructEncrypted(URL_4_SE);
		return;
		IL_00bb:
		REGEX_1_SE = "MkewBwdY3jMiKTFjU7LYoA==.Ejc8sFFx7+TAhBHBoNpkFkev5csp5FpCfV6QdTAQ2GkW6uMicLHfxUmkcQxa4aJs";
		if (8u != 0)
		{
			REGEX_1 = SecurityUtils.ReadStructEncrypted(REGEX_1_SE);
			REGEX_2_SE = "CRoyUG1+a3q6ECcHRkgimw==.5LS+k/uLf0J51+R8IwiL2XsjKX9Q870yAgOZQ7aUmPQ68bHrX4Lci083sso0HoCz";
			REGEX_2 = SecurityUtils.ReadStructEncrypted(REGEX_2_SE);
			REGEX_3_SE = "FDt8fyTul7TCs2eOX2TdmA==.bJJA6/mO5TiidYxwCt+wpCeh74CcArgV/7Ios/3eF8MyD3wgFHrtFL7dDe5W/9Gr";
			if (false)
			{
				goto IL_019b;
			}
			REGEX_3 = SecurityUtils.ReadStructEncrypted(REGEX_3_SE);
		}
		goto IL_010f;
		IL_0119:
		REGEX_4 = SecurityUtils.ReadStructEncrypted(REGEX_4_SE);
		if (true)
		{
			if (1 == 0)
			{
				goto IL_010f;
			}
			LOG_1_SE = "FfpBVUv9UzMLu87SQ3UkNQ==.pFfrcWAk8U+iAWV06WmmJNcLLoKEBxrUekXubY6SLqAfZvIIEyMQcacJlzKiIS7h";
			LOG_1 = SecurityUtils.ReadStructEncrypted(LOG_1_SE);
			EAAB_SE = "16nyf/3zSuEWbCmjA7oW5g==.SVNUtsCMBPM+RdXRLxlPpl9rgwGPJxScQLmE/KmsQN4=";
			EAAB = SecurityUtils.ReadStructEncrypted(EAAB_SE);
			goto IL_0160;
		}
		if (1 == 0)
		{
			goto IL_019b;
		}
		goto IL_01b4;
		IL_019b:
		URL_3_SE = "xbx7F0uNANM3JlXbTrGE3g==.OlZeLXbO+g/t3ETJwKcquwLDfjqKU6ZrTCOpMvoze2hcvVPidrktUqB+pIjR1iuIcbUW7ytU5Guq1F0EiLyT2K2Qgh6hZXcYWkFHYkzUesA=";
		URL_3 = SecurityUtils.ReadStructEncrypted(URL_3_SE);
		goto IL_01b4;
		IL_010f:
		REGEX_4_SE = "VslnIJYyaOauPkBxudS4fA==.HEjPY1yAwV5Vfv8oHQoabhb4V7dky+GgzCfbdkdawxU=";
		goto IL_0119;
		IL_0160:
		URL_1_SE = "s+D85M2Q2khk2a9egwXusw==.ScDkiQIGjrfxWWzGVs4xakONsrvzr4+JGnZ16LBEohhpWCEjlVkZZfsruTWXxo4hFswSli1s3i0D0IhZAxlIivkAyPsZ6wetqgxYxIhxKGA=";
		URL_1 = SecurityUtils.ReadStructEncrypted(URL_1_SE);
		URL_2_SE = "km+KVVCv/6SOw7UFq2+WcA==.gKawmuVLa3J7oOs4QbehnNU1SN5c/2dPPfewPHk/ynVALvBzRk6d8RsSa/jaWn9sAXiD7H83lo8Bf7oVxstLq/KIONx7kJ/Dg3wmf7VUjCE=";
		if (false)
		{
			goto IL_00bb;
		}
		URL_2 = SecurityUtils.ReadStructEncrypted(URL_2_SE);
		goto IL_019b;
	}
}
