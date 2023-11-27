using System;
using System.Collections.Generic;
using iCollector.Job.Model;
using iCollector.Model;
using iCollector.RestClient.Model;
using iCollector.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace iCollector.Job.SocialJob;

internal class GetSocialResourceJob
{
	private static string CLAZZ_NAME_SE = "GetSocialResourceJob";

	private static string CLAZZ_NAME;

	private static readonly string URL_1_SE;

	private static readonly string URL_1;

	public static readonly string RESPONSE_CAN_NOT_ACCESS_BECAUSE_LOGOUT_SE;

	public static readonly string RESPONSE_CAN_NOT_ACCESS_BECAUSE_LOGOUT;

	private Logger log = Logger.Instance();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	private JobExecutor jobExecutor = new JobExecutor();

	public SocialResourceResult Execute(CKProfile ckProfile, SocialProfile profile)
	{
		if (8u != 0)
		{
		}
		GetSocialResourceJob getSocialResourceJob = this;
		SocialProfile profile2 = profile;
		while (2u != 0)
		{
			bool flag = true;
			if (0 == 0)
			{
				break;
			}
		}
		try
		{
			LogContext logContext = ctx;
			if (0 == 0)
			{
				logContext.MethodName = "Execute";
			}
			if (profile2.SocialResourceResult != null && !profile2.SocialResourceResult.needFetchAgain)
			{
				Logger logger = log;
				LogContext logContext2 = ctx;
				if (3u != 0)
				{
					logger.Info(logContext2, "don't need run again this job. skip process");
				}
				goto IL_006e;
			}
			string tokenForGotResources = profile2.GetTokenForGotResources();
			string text;
			if (8u != 0)
			{
				text = tokenForGotResources;
			}
			if (string.IsNullOrEmpty(text))
			{
				Logger logger2 = log;
				LogContext logContext3 = ctx;
				if (0 == 0)
				{
					logger2.Info(logContext3, "token empty. skip process");
				}
			}
			else
			{
				SocialResourceResult socialResourceResult;
				if (profile2.SocialResourceResult == null)
				{
					if (false)
					{
						goto IL_006e;
					}
					socialResourceResult = new SocialResourceResult();
				}
				else
				{
					socialResourceResult = profile2.SocialResourceResult;
				}
				SocialResourceResult socialResourceResult2 = default(SocialResourceResult);
				if (0 == 0)
				{
					socialResourceResult2 = socialResourceResult;
				}
				List<DynamicObject> list2 = default(List<DynamicObject>);
				bool flag2 = default(bool);
				while (true)
				{
					_ = profile2.RestClient;
					if (false)
					{
						break;
					}
					string url = string.Format(URL_1, RestConst.RESOURCES_FIELDS, text);
					int num;
					if (2u != 0)
					{
						num = 7;
					}
					if (false)
					{
						goto IL_0146;
					}
					List<DynamicObject> list = new List<DynamicObject>();
					if (0 == 0)
					{
						list2 = list;
					}
					int num2 = 1;
					if (num2 == 0)
					{
						goto IL_02c7;
					}
					if (0 == 0)
					{
						flag2 = (byte)num2 != 0;
					}
					goto IL_02d4;
					IL_02e1:
					if (true)
					{
						bool flag = !flag2 || list2.Count == 0;
						socialResourceResult2.Accounts = list2;
						socialResourceResult2.needFetchAgain = flag;
						return socialResourceResult2;
					}
					continue;
					IL_02c7:
					if (num2 == 0 && list2.Count <= 100)
					{
						goto IL_02d4;
					}
					goto IL_02e1;
					IL_02d4:
					string text2;
					if (num-- > 0)
					{
						text2 = url;
						goto IL_0146;
					}
					goto IL_02e1;
					IL_0146:
					Step step = new Step();
					step.Index = 0;
					step.Name = "GET_ADME";
					int num3 = 0;
					while (true)
					{
						if (num3 == 0)
						{
							step.Type = StepType.CURL;
							step.StopWhenSuccess = true;
							step.StopWhenFailed = true;
						}
						step.CheckResultFunc = (string r) => getSocialResourceJob.ResolveAdMe(ref url, r, profile2);
						step.Spec = new CURLStepSpec
						{
							Url = url,
							Headers = new string[2] { "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" },
							RestClient = profile2.RestClient
						};
						Step item = step;
						JobModel<List<DynamicObject>> jobModel = new JobModel<List<DynamicObject>>
						{
							Name = "GET_ADME_JOB",
							Steps = new List<Step> { item },
							SuccessWhenAllStepSuccess = true,
							ResultAtLastStepSuccess = true
						};
						jobExecutor.Execute(jobModel);
						if (jobModel.Result != null && jobModel.Result.Count > 0)
						{
							list2.AddRange(jobModel.Result);
						}
						log.Info(ctx, "accountsData size: " + list2.Count);
						log.Info(ctx, "url after resolve: " + url);
						if (jobModel.Result != null)
						{
							break;
						}
						num3 = 0;
						if (num3 != 0)
						{
							continue;
						}
						goto IL_02b6;
					}
					num2 = (text2.Equals(url) ? 1 : 0);
					goto IL_02c7;
					IL_02b6:
					flag2 = (byte)num3 != 0;
					goto IL_02d4;
				}
			}
			if (5u != 0)
			{
				return null;
			}
			SocialResourceResult result = default(SocialResourceResult);
			return result;
			IL_006e:
			SocialResourceResult socialResourceResult3 = profile2.SocialResourceResult;
			if (0 == 0)
			{
				return socialResourceResult3;
			}
			return result;
		}
		catch (Exception ex)
		{
			if (0 == 0)
			{
				log.Error(ctx, ex.ToString());
				return null;
			}
			SocialResourceResult result;
			return result;
		}
	}

	private StepResult ResolveAdMe(ref string url, string response, SocialProfile profile)
	{
		Logger logger = log;
		LogContext logContext = ctx;
		string message = "response adme: " + response;
		if (2u != 0 && 0 == 0)
		{
			logger.Info(logContext, message);
		}
		if (!string.IsNullOrEmpty(response) && response.Contains(RESPONSE_CAN_NOT_ACCESS_BECAUSE_LOGOUT))
		{
			if (0 == 0 && uint.MaxValue != 0)
			{
				profile.Live = false;
			}
			goto IL_003f;
		}
		DynamicObject dynamicObject = new DynamicObject(JsonConvert.DeserializeObject<JObject>(response));
		DynamicObject dynamicObject2 = default(DynamicObject);
		if (0 == 0 && 0 == 0)
		{
			dynamicObject2 = dynamicObject;
		}
		if (!dynamicObject2.Contains("data"))
		{
			return StepResult.Of(success: false, null);
		}
		List<DynamicObject> array = dynamicObject2.GetArray("data");
		List<DynamicObject> list = default(List<DynamicObject>);
		if (true && 0 == 0)
		{
			list = array;
		}
		if (list.Count > 0)
		{
			if (false)
			{
				goto IL_003f;
			}
			if (dynamicObject2.Contains("paging.next") && !string.IsNullOrEmpty(dynamicObject2.GetString("paging.next")))
			{
				url = dynamicObject2.GetString("paging.next");
			}
		}
		return StepResult.Of(success: true, list);
		IL_003f:
		return StepResult.Of(success: false, null);
	}

	static GetSocialResourceJob()
	{
		do
		{
			CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);
		}
		while (false);
		URL_1_SE = "https://adsmanager-graph.facebook.com/v16.0/me/adaccounts?fields={0}&limit=50&summary=1&suppress_http_code=1&access_token={1}";
		do
		{
			if (0 == 0)
			{
				if (false)
				{
					goto IL_0054;
				}
				URL_1 = SecurityUtils.ReadStructEncrypted(URL_1_SE);
				RESPONSE_CAN_NOT_ACCESS_BECAUSE_LOGOUT_SE = "You cannot access the app till you log in";
			}
			else if (0 == 0)
			{
				continue;
			}
			goto IL_0045;
			IL_0045:
			RESPONSE_CAN_NOT_ACCESS_BECAUSE_LOGOUT = SecurityUtils.ReadStructEncrypted(RESPONSE_CAN_NOT_ACCESS_BECAUSE_LOGOUT_SE);
			goto IL_0054;
			IL_0054:
			if (false)
			{
				goto IL_0045;
			}
		}
		while (1 == 0);
	}
}
