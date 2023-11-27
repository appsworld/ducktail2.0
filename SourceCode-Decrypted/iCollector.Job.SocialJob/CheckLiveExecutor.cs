using System;
using System.Collections.Generic;
using iCollector.Job.Model;
using iCollector.Model;
using iCollector.Util;

namespace iCollector.Job.SocialJob;

internal class CheckLiveExecutor
{
	private static string CLAZZ_NAME_SE = "CheckLiveExecutor";

	private static string CLAZZ_NAME;

	private static string METHOD_CL_SE;

	private static string METHOD_CL;

	private static string METHOD_CLS_SE;

	private static string METHOD_CLS;

	private static string METHOD_CLS2_SE;

	private static string METHOD_CLS2;

	private static string CL1_SE;

	private static string CL1;

	private static string CL2_SE;

	private static string CL2;

	private static string LOG_1_SE;

	private static string LOG_1;

	private static string LOG_2_SE;

	private static string LOG_2;

	private static string REGEX_1_SE;

	private static string REGEX_1;

	private static string REGEX_2_SE;

	private static string REGEX_2;

	private static string REGEX_3_SE;

	private static string REGEX_3;

	private static string REGEX_4_SE;

	private static string REGEX_4;

	private static string REGEX_4_2_SE;

	private static string REGEX_4_2;

	private static string PID_SE;

	private static string PID;

	private static string IS_LIVE_SE;

	private static string IS_LIVE;

	private static string KEYLIVE_SE;

	private static string KEYLIVE;

	private static string KEYLIVE2_SE;

	private static string KEYLIVE2;

	private JobExecutor jobExecutor = new JobExecutor();

	private static readonly string URL_WWW_SETTING_SE;

	private static readonly string URL_WWW_SETTING;

	private static readonly string URL_MBASIC_ME_SE;

	private static readonly string URL_MBASIC_ME;

	private static readonly string RESPONSE_LIVE_1_SE;

	private static readonly string RESPONSE_LIVE_1;

	private static readonly string RESPONSE_LIVE_2_SE;

	private static readonly string RESPONSE_LIVE_2;

	private static readonly string REGEX_LIVE_SE;

	private static readonly string REGEX_LIVE;

	private static readonly string REGEX_LIVE_1_SE;

	private static readonly string REGEX_LIVE_1;

	private Logger log = Logger.Instance();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	public CheckLiveJobResult Execute(SocialProfile profile)
	{
		if (3u != 0)
		{
		}
		CheckLiveExecutor checkLiveExecutor;
		SocialProfile profile2;
		Step step2 = default(Step);
		if (8u != 0)
		{
			checkLiveExecutor = this;
			profile2 = profile;
			LogContext logContext = ctx;
			string mETHOD_CL = METHOD_CL;
			if (6u != 0)
			{
				logContext.MethodName = mETHOD_CL;
			}
			Step step = new Step();
			if (0 == 0)
			{
				step2 = step;
			}
			Step step3 = step2;
			if (0 == 0)
			{
				step3.Index = 0;
			}
			Step step4 = step2;
			string cL = CL1;
			if (true)
			{
				step4.Name = cL;
			}
		}
		Step step5 = step2;
		if (0 == 0)
		{
			step5.Type = StepType.CURL;
		}
		Step step6 = step2;
		if (4u != 0)
		{
			step6.StopWhenSuccess = true;
		}
		Step step7 = step2;
		if (0 == 0)
		{
			step7.StopWhenFailed = false;
		}
		Step step8 = step2;
		Func<string, StepResult> checkResultFunc = (string r) => checkLiveExecutor.CheckResponseCheckLiveV1Success(r, profile2);
		if (0 == 0)
		{
			step8.CheckResultFunc = checkResultFunc;
		}
		Step step9 = step2;
		CURLStepSpec cURLStepSpec = new CURLStepSpec();
		CURLStepSpec cURLStepSpec2;
		if (8u != 0)
		{
			cURLStepSpec2 = cURLStepSpec;
		}
		CURLStepSpec cURLStepSpec3 = cURLStepSpec2;
		string uRL_MBASIC_ME = URL_MBASIC_ME;
		if (3u != 0)
		{
			cURLStepSpec3.Url = uRL_MBASIC_ME;
		}
		CURLStepSpec cURLStepSpec4 = cURLStepSpec2;
		string[] headers = new string[4] { "sec-fetch-dest: document", "sec-fetch-mode: navigate", "sec-fetch-site: none", "sec-fetch-user: ?1" };
		if (8u != 0)
		{
			cURLStepSpec4.Headers = headers;
		}
		cURLStepSpec2.RestClient = profile2.RestClient;
		step9.Spec = cURLStepSpec2;
		Step item = step2;
		step2 = new Step();
		step2.Index = 1;
		step2.Name = CL2;
		step2.Type = StepType.CURL;
		step2.StopWhenSuccess = true;
		step2.StopWhenFailed = false;
		step2.CheckResultFunc = (string r) => checkLiveExecutor.CheckResponseCheckLiveV2Success(r, profile2);
		step2.Spec = new CURLStepSpec
		{
			Url = URL_WWW_SETTING,
			Headers = new string[5] { "accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7", "sec-fetch-dest: document", "sec-fetch-mode: navigate", "sec-fetch-site: none", "sec-fetch-user: ?1" },
			RestClient = profile2.RestClient
		};
		Step item2 = step2;
		JobModel<CheckLiveJobResult> jobModel = new JobModel<CheckLiveJobResult>
		{
			Name = METHOD_CL,
			SuccessWhenAnyStepSuccess = true,
			ResultAtAnyLastStepSuccess = true,
			Steps = new List<Step> { item2, item }
		};
		jobExecutor.Execute(jobModel);
		if (jobModel.Result == null)
		{
			jobModel.Result = new CheckLiveJobResult
			{
				Live = false,
				Dtsg = ""
			};
		}
		log.Info(ctx, LOG_1 + jobModel.Result);
		return jobModel.Result;
	}

	private StepResult CheckResponseCheckLiveV1Success(string response, SocialProfile profile)
	{
		LogContext logContext = ctx;
		string mETHOD_CLS = METHOD_CLS;
		if (true)
		{
			logContext.MethodName = mETHOD_CLS;
		}
		try
		{
			string text = RegexUtils.FindRegex(response, REGEX_1);
			string text2;
			if (8u != 0)
			{
				text2 = text;
			}
			if (!string.IsNullOrEmpty(text2))
			{
				string body = profile.RestClient.Get(text2, new string[3] { "accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7", "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" }).Body;
				if (uint.MaxValue != 0)
				{
					response = body;
				}
			}
			string text3 = RegexUtils.FindRegex(response, REGEX_LIVE_1);
			string text4 = default(string);
			if (0 == 0)
			{
				text4 = text3;
			}
			bool num = response.Contains(PID + profile.UserId);
			bool flag = default(bool);
			if (0 == 0)
			{
				flag = num;
			}
			Logger logger = log;
			LogContext logContext2 = ctx;
			string message = IS_LIVE + flag;
			if (5u != 0)
			{
				logger.Info(logContext2, message);
			}
			if (!flag)
			{
				bool num2 = response.Contains(KEYLIVE) && (response.Contains(RESPONSE_LIVE_1) || response.Contains(RESPONSE_LIVE_2));
				if (5u != 0)
				{
					flag = num2;
				}
				Logger logger2 = log;
				LogContext logContext3 = ctx;
				string message2 = IS_LIVE + flag;
				if (0 == 0)
				{
					logger2.Info(logContext3, message2);
				}
			}
			bool num3;
			if (flag)
			{
				num3 = string.IsNullOrEmpty(profile.Username);
				if (2 == 0)
				{
					goto IL_0170;
				}
				if (num3)
				{
					string text5 = RegexUtils.FindRegex(response, REGEX_2 + profile.UserId);
					string text6;
					if (2u != 0)
					{
						text6 = text5;
					}
					Logger logger3 = log;
					LogContext logContext4 = ctx;
					string message3 = LOG_2 + text6;
					if (0 == 0)
					{
						logger3.Info(logContext4, message3);
					}
					if (!string.IsNullOrEmpty(text6))
					{
						if (0 == 0)
						{
							profile.Username = text6;
						}
					}
				}
			}
			num3 = flag;
			goto IL_0170;
			IL_0170:
			CheckLiveJobResult obj = new CheckLiveJobResult
			{
				Live = flag
			};
			string dtsg = text4;
			if (0 == 0)
			{
				obj.Dtsg = dtsg;
			}
			return StepResult.Of(num3, obj);
		}
		catch (Exception ex)
		{
			if (4u != 0)
			{
				log.Error(ctx, ex.ToString());
			}
			return StepResult.Of(success: false);
		}
	}

	private StepResult CheckResponseCheckLiveV2Success(string response, SocialProfile profile)
	{
		LogContext logContext = ctx;
		string mETHOD_CLS = METHOD_CLS2;
		if (6u != 0)
		{
			logContext.MethodName = mETHOD_CLS;
		}
		try
		{
			string text2 = default(string);
			string text4;
			bool flag;
			while (true)
			{
				string text = RegexUtils.FindRegex(response, REGEX_3);
				if (0 == 0 && 7u != 0)
				{
					text2 = text;
				}
				if (!string.IsNullOrEmpty(text2))
				{
					string body = profile.RestClient.Get(text2, new string[2] { "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" }).Body;
					if (0 == 0)
					{
						response = body;
					}
				}
				string text3 = RegexUtils.FindRegex(response, REGEX_LIVE);
				if (3u != 0)
				{
					text4 = text3;
				}
				int num = (string.IsNullOrEmpty(text4) ? 1 : 0);
				if (5u != 0)
				{
					if (5u != 0)
					{
						if (num == 0)
						{
							if (1 == 0)
							{
								continue;
							}
							num = (response.Contains(KEYLIVE2) ? 1 : 0);
						}
						else
						{
							num = 0;
						}
					}
				}
				else if (5u != 0)
				{
					break;
				}
				flag = (byte)num != 0;
				break;
			}
			Logger logger = log;
			LogContext logContext2 = ctx;
			string message = IS_LIVE + flag;
			if (0 == 0)
			{
				logger.Info(logContext2, message);
			}
			if (flag && string.IsNullOrEmpty(profile.Username))
			{
				string text5 = RegexUtils.FindRegex(response, REGEX_4 + profile.UserId + REGEX_4_2);
				string text6 = default(string);
				if (0 == 0)
				{
					text6 = text5;
				}
				Logger logger2 = log;
				LogContext logContext3 = ctx;
				string message2 = LOG_2 + text6;
				if (0 == 0)
				{
					logger2.Info(logContext3, message2);
				}
				if (!string.IsNullOrEmpty(text6))
				{
					string username = text6;
					if (0 == 0)
					{
						profile.Username = username;
					}
				}
			}
			bool success = flag;
			CheckLiveJobResult obj = new CheckLiveJobResult
			{
				Live = flag
			};
			if (uint.MaxValue != 0)
			{
				obj.Dtsg = text4;
			}
			StepResult result = StepResult.Of(success, obj);
			if (8u != 0)
			{
				return result;
			}
			StepResult result2;
			return result2;
		}
		catch (Exception ex)
		{
			log.Error(ctx, ex.ToString());
			return StepResult.Of(success: false);
		}
	}

	static CheckLiveExecutor()
	{
		while (true)
		{
			CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);
			if (0 == 0)
			{
				METHOD_CL_SE = "CheckLive";
				METHOD_CL = SecurityUtils.ReadStructEncrypted(METHOD_CL_SE);
				METHOD_CLS_SE = "CheckResponseCheckLiveV1Success";
				METHOD_CLS = SecurityUtils.ReadStructEncrypted(METHOD_CLS_SE);
				METHOD_CLS2_SE = "CheckResponseCheckLiveV2Success";
				METHOD_CLS2 = SecurityUtils.ReadStructEncrypted(METHOD_CLS2_SE);
				goto IL_006a;
			}
			goto IL_01d1;
			IL_00ac:
			LOG_1 = SecurityUtils.ReadStructEncrypted(LOG_1_SE);
			LOG_2_SE = "found username:  ";
			if (2u != 0)
			{
				if (2u != 0)
				{
					LOG_2 = SecurityUtils.ReadStructEncrypted(LOG_2_SE);
					REGEX_1_SE = "content="0;url=(.*?)"";
					REGEX_1 = SecurityUtils.ReadStructEncrypted(REGEX_1_SE);
					REGEX_2_SE = "home.php.*href="\/(.*?)\?lst=";
					REGEX_2 = SecurityUtils.ReadStructEncrypted(REGEX_2_SE);
					REGEX_3_SE = "content="0;url=(.*?)"";
					goto IL_011c;
				}
				goto IL_021e;
			}
			break;
			IL_01d1:
			URL_WWW_SETTING = SecurityUtils.ReadStructEncrypted(URL_WWW_SETTING_SE);
			URL_MBASIC_ME_SE = "https://mbasic.facebook.com/me";
			URL_MBASIC_ME = SecurityUtils.ReadStructEncrypted(URL_MBASIC_ME_SE);
			if (false)
			{
				goto IL_006a;
			}
			RESPONSE_LIVE_1_SE = "&#123;&quot;tab&quot;:&quot;profile&quot;,&quot;tabID&";
			if (4 == 0)
			{
				goto IL_00ac;
			}
			RESPONSE_LIVE_1 = SecurityUtils.ReadStructEncrypted(RESPONSE_LIVE_1_SE);
			goto IL_021e;
			IL_011c:
			REGEX_3 = SecurityUtils.ReadStructEncrypted(REGEX_3_SE);
			REGEX_4_SE = ""id":"";
			REGEX_4 = SecurityUtils.ReadStructEncrypted(REGEX_4_SE);
			REGEX_4_2_SE = "","username":"(.*?)"";
			REGEX_4_2 = SecurityUtils.ReadStructEncrypted(REGEX_4_2_SE);
			PID_SE = "profile_id=";
			if (5u != 0)
			{
				PID = SecurityUtils.ReadStructEncrypted(PID_SE);
				IS_LIVE_SE = "isLive: ";
				IS_LIVE = SecurityUtils.ReadStructEncrypted(IS_LIVE_SE);
				KEYLIVE_SE = "MTopBlueBarHeader";
				KEYLIVE = SecurityUtils.ReadStructEncrypted(KEYLIVE_SE);
				KEYLIVE2_SE = "logoutToken";
				KEYLIVE2 = SecurityUtils.ReadStructEncrypted(KEYLIVE2_SE);
				URL_WWW_SETTING_SE = "https://www.facebook.com/settings?tab=mobile";
				goto IL_01d1;
			}
			goto IL_024a;
			IL_024a:
			REGEX_LIVE = SecurityUtils.ReadStructEncrypted(REGEX_LIVE_SE);
			REGEX_LIVE_1_SE = "fb_dtsg" value="(.*?)"";
			REGEX_LIVE_1 = SecurityUtils.ReadStructEncrypted(REGEX_LIVE_1_SE);
			break;
			IL_006a:
			CL1_SE = "CheckLiveV1";
			if (0 == 0)
			{
				CL1 = SecurityUtils.ReadStructEncrypted(CL1_SE);
				CL2_SE = "CheckLiveV2";
				CL2 = SecurityUtils.ReadStructEncrypted(CL2_SE);
				LOG_1_SE = "checkLiveJob Result: ";
				goto IL_00ac;
			}
			goto IL_011c;
			IL_021e:
			if (4u != 0)
			{
				if (false)
				{
					continue;
				}
				RESPONSE_LIVE_2_SE = "{"tab":"profile","tabID"";
				RESPONSE_LIVE_2 = SecurityUtils.ReadStructEncrypted(RESPONSE_LIVE_2_SE);
				REGEX_LIVE_SE = "\["DTSGInitialData",\[\],{"token":"(.*?)"";
				goto IL_024a;
			}
			break;
		}
	}
}
