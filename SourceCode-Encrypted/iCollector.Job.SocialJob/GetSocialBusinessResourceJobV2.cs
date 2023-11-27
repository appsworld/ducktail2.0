using System;
using System.Collections.Generic;
using System.Threading;
using iCollector.Job.Model;
using iCollector.Model;
using iCollector.RestClient.Model;
using iCollector.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace iCollector.Job.SocialJob;

internal class GetSocialBusinessResourceJobV2
{
	private static string CLAZZ_NAME_SE = "QWEYx+rRJ/TB39ihL/QDhQ==.QtBqJNTT+6w5mVqZRabdEQ3MCbvi7TR+COXU3Jyb4FymLu/fixiOPztdHWLePlMA";

	private static string CLAZZ_NAME;

	private static readonly string URL_1_SE;

	private static readonly string URL_1;

	private static readonly string URL_2_SE;

	private static readonly string URL_2;

	private Logger log = Logger.Instance();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	private JobExecutor jobExecutor = new JobExecutor();

	public SocialBusinessResourceResult Execute(SocialProfile profile)
	{
		_003C_003Ec__DisplayClass9_0 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_0();
		_003C_003Ec__DisplayClass9_0 _003C_003Ec__DisplayClass9_2 = default(_003C_003Ec__DisplayClass9_0);
		if (0 == 0)
		{
			_003C_003Ec__DisplayClass9_2 = _003C_003Ec__DisplayClass9_;
		}
		_003C_003Ec__DisplayClass9_2._003C_003E4__this = this;
		if (uint.MaxValue != 0)
		{
			bool flag = true;
		}
		try
		{
			LogContext logContext = ctx;
			if (3u != 0)
			{
				logContext.MethodName = "Execute";
			}
			if (profile.SocialBusinesssResourceResult != null && !profile.SocialBusinesssResourceResult.needFetchAgain)
			{
				Logger logger = log;
				LogContext logContext2 = ctx;
				if (7u != 0)
				{
					logger.Info(logContext2, "don't need run again this job. skip process");
				}
				SocialBusinessResourceResult socialBusinesssResourceResult = profile.SocialBusinesssResourceResult;
				SocialBusinessResourceResult result;
				if (6u != 0)
				{
					result = socialBusinesssResourceResult;
					if (3 == 0)
					{
						return result;
					}
					return result;
				}
				return result;
			}
			string tokenForGotBusinessResources = profile.GetTokenForGotBusinessResources();
			string text;
			if (3u != 0)
			{
				text = tokenForGotBusinessResources;
			}
			if (string.IsNullOrEmpty(text))
			{
				Logger logger2 = log;
				LogContext logContext3 = ctx;
				if (5u != 0)
				{
					logger2.Info(logContext3, "token empty. skip process");
				}
				if (5u != 0)
				{
					return null;
				}
				SocialBusinessResourceResult result;
				return result;
			}
			SocialBusinessResourceResult socialBusinessResourceResult = new SocialBusinessResourceResult();
			SocialBusinessResourceResult socialBusinessResourceResult2;
			if (5u != 0)
			{
				socialBusinessResourceResult2 = socialBusinessResourceResult;
			}
			_ = profile.RestClient;
			_003C_003Ec__DisplayClass9_2.url = string.Format(URL_1, RestConst.RESOURCES_BUSINESSS_SHORT_FIELDS, text);
			int num;
			if (3u != 0)
			{
				num = 7;
			}
			List<DynamicObject> list = new List<DynamicObject>();
			List<DynamicObject> list2;
			if (2u != 0)
			{
				list2 = list;
			}
			bool flag2;
			if (8u != 0)
			{
				flag2 = true;
			}
			bool flag;
			while (true)
			{
				if (num-- > 0)
				{
					string url = _003C_003Ec__DisplayClass9_2.url;
					Step step = new Step();
					step.Index = 0;
					step.Name = "GET_BM_V2";
					step.Type = StepType.CURL;
					step.StopWhenSuccess = true;
					step.StopWhenFailed = true;
					step.CheckResultFunc = _003C_003Ec__DisplayClass9_2._003CExecute_003Eb__0;
					step.Spec = new CURLStepSpec
					{
						Url = _003C_003Ec__DisplayClass9_2.url,
						Headers = new string[2] { "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" },
						RestClient = profile.RestClient
					};
					Step item = step;
					JobModel<List<DynamicObject>> jobModel = new JobModel<List<DynamicObject>>
					{
						Name = "GET_BM_JOB_V2",
						Steps = new List<Step> { item },
						SuccessWhenAllStepSuccess = true,
						ResultAtLastStepSuccess = true
					};
					jobExecutor.Execute(jobModel);
					if (jobModel.Result != null && jobModel.Result.Count > 0)
					{
						list2.AddRange(jobModel.Result);
					}
					log.Info(ctx, "businessAccountsData size: " + list2.Count);
					log.Info(ctx, "url after resolve: " + _003C_003Ec__DisplayClass9_2.url);
					if (jobModel.Result == null)
					{
						flag2 = false;
						if (false)
						{
							break;
						}
						goto IL_0283;
					}
					if (!url.Equals(_003C_003Ec__DisplayClass9_2.url) && list2.Count <= 100)
					{
						goto IL_0283;
					}
				}
				flag = !flag2 || list2.Count == 0;
				socialBusinessResourceResult2.BusinessAccounts = list2;
				if (list2 == null || list2.Count <= 0)
				{
					break;
				}
				List<DynamicObject>.Enumerator enumerator = list2.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						DynamicObject current = enumerator.Current;
						if (!GetAccountsForBM(profile, current))
						{
							flag2 = false;
						}
						Thread.Sleep(TimeSpan.FromSeconds(30.0));
					}
				}
				finally
				{
					if (6u != 0)
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				break;
				IL_0283:
				Thread.Sleep(3000);
			}
			socialBusinessResourceResult2.needFetchAgain = flag;
			return socialBusinessResourceResult2;
		}
		catch (Exception ex)
		{
			log.Error(ctx, ex.ToString());
			return null;
		}
	}

	private bool GetAccountsForBM(SocialProfile profile, DynamicObject bm)
	{
		_003C_003Ec__DisplayClass10_0 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_0();
		_003C_003Ec__DisplayClass10_0 _003C_003Ec__DisplayClass10_2 = default(_003C_003Ec__DisplayClass10_0);
		if (0 == 0)
		{
			_003C_003Ec__DisplayClass10_2 = _003C_003Ec__DisplayClass10_;
		}
		_003C_003Ec__DisplayClass10_2._003C_003E4__this = this;
		_003C_003Ec__DisplayClass10_2.bm = bm;
		try
		{
			string tokenForGotBusinessResources = profile.GetTokenForGotBusinessResources();
			string arg;
			if (5u != 0)
			{
				arg = tokenForGotBusinessResources;
			}
			string text = string.Format(URL_2, _003C_003Ec__DisplayClass10_2.bm.GetString("id"), RestConst.RESOURCES_BUSINESSS_DETAIL_SHORT_FIELDS, arg);
			string url;
			if (uint.MaxValue != 0)
			{
				url = text;
			}
			Step step = new Step();
			Step step2 = default(Step);
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
			if (0 == 0)
			{
				step4.Name = "GET_BM_DETAIL_V2";
			}
			Step step5 = step2;
			if (0 == 0)
			{
				step5.Type = StepType.CURL;
			}
			Step step6 = step2;
			if (0 == 0)
			{
				step6.StopWhenSuccess = true;
			}
			Step step7 = step2;
			if (0 == 0)
			{
				step7.StopWhenFailed = true;
			}
			Step step8 = step2;
			Func<string, StepResult> checkResultFunc = _003C_003Ec__DisplayClass10_2._003CGetAccountsForBM_003Eb__0;
			if (uint.MaxValue != 0)
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
			if (0 == 0)
			{
				cURLStepSpec3.Url = url;
			}
			cURLStepSpec2.Headers = new string[2] { "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" };
			cURLStepSpec2.RestClient = profile.RestClient;
			step9.Spec = cURLStepSpec2;
			Step item = step2;
			JobModel<DynamicObject> jobModel = new JobModel<DynamicObject>
			{
				Name = "GET_BM_JOB_DETAIL_V2",
				Steps = new List<Step> { item },
				SuccessWhenAllStepSuccess = true,
				ResultAtLastStepSuccess = true
			};
			jobExecutor.Execute(jobModel);
			return jobModel.Result != null;
		}
		catch (Exception ex)
		{
			log.Info(ctx, ex.ToString());
			return false;
		}
	}

	private StepResult ResolveBM(ref string url, string response)
	{
		DynamicObject dynamicObject2 = default(DynamicObject);
		List<DynamicObject> list = default(List<DynamicObject>);
		List<DynamicObject>.Enumerator enumerator2 = default(List<DynamicObject>.Enumerator);
		DynamicObject dynamicObject3 = default(DynamicObject);
		while (true)
		{
			if (0 == 0)
			{
				Logger logger = log;
				LogContext logContext = ctx;
				string message = "response bm: " + response;
				if (5u != 0 && 0 == 0)
				{
					logger.Info(logContext, message);
				}
				DynamicObject dynamicObject = new DynamicObject(JsonConvert.DeserializeObject<JObject>(response));
				if (0 == 0)
				{
					if (0 == 0)
					{
						dynamicObject2 = dynamicObject;
					}
					if (false)
					{
						break;
					}
				}
			}
			int num;
			if (uint.MaxValue != 0 && !dynamicObject2.Contains("data"))
			{
				num = 0;
				if (num == 0)
				{
					return StepResult.Of((byte)num != 0, null);
				}
			}
			else
			{
				List<DynamicObject> array = dynamicObject2.GetArray("data");
				if (0 == 0 && 5u != 0)
				{
					list = array;
				}
				if (list.Count <= 0 || !dynamicObject2.Contains("paging.next"))
				{
					goto IL_009d;
				}
				if (4 == 0)
				{
					continue;
				}
				num = (string.IsNullOrEmpty(dynamicObject2.GetString("paging.next")) ? 1 : 0);
			}
			if (num == 0)
			{
				url = dynamicObject2.GetString("paging.next");
			}
			goto IL_009d;
			IL_009d:
			List<DynamicObject>.Enumerator enumerator = list.GetEnumerator();
			if (0 == 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					DynamicObject current = enumerator2.Current;
					if (6u != 0 && 0 == 0)
					{
						dynamicObject3 = current;
					}
					DynamicObject dynamicObject4 = dynamicObject3;
					object value = BAUtils.IsAdmin(dynamicObject3);
					if (0 == 0 && uint.MaxValue != 0)
					{
						dynamicObject4.Put("is_admin", value);
					}
					DynamicObject dynamicObject5 = dynamicObject3;
					object value2 = BAUtils.IsVerified(dynamicObject3);
					if (0 == 0)
					{
						dynamicObject5.Put("is_verified", value2);
					}
				}
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			break;
		}
		return StepResult.Of(success: true, list);
	}

	private StepResult ResolveBMDetail(string response, DynamicObject refBm)
	{
		Logger logger = log;
		LogContext logContext = ctx;
		string message = "response bm detail for: " + refBm.GetString("id") + ": " + response;
		if (4u != 0)
		{
			logger.Info(logContext, message);
		}
		while (string.IsNullOrEmpty(response))
		{
			if (0 == 0)
			{
				return StepResult.Of(success: false, null);
			}
		}
		List<DynamicObject> list4 = default(List<DynamicObject>);
		List<DynamicObject> list6 = default(List<DynamicObject>);
		List<DynamicObject> list7 = default(List<DynamicObject>);
		List<DynamicObject>.Enumerator enumerator = default(List<DynamicObject>.Enumerator);
		while (true)
		{
			DynamicObject dynamicObject2;
			List<DynamicObject> list2;
			if (0 == 0)
			{
				DynamicObject dynamicObject = new DynamicObject(JsonConvert.DeserializeObject<JObject>(response));
				if (true)
				{
					dynamicObject2 = dynamicObject;
				}
				if (!dynamicObject2.Contains("id"))
				{
					if (0 == 0)
					{
						break;
					}
					continue;
				}
				List<DynamicObject> list = new List<DynamicObject>();
				if (6u != 0)
				{
					list2 = list;
				}
				List<DynamicObject> list3 = new List<DynamicObject>();
				if (0 == 0)
				{
					list4 = list3;
				}
				List<DynamicObject> list5 = new List<DynamicObject>();
				if (0 == 0)
				{
					list6 = list5;
				}
				if (dynamicObject2.Contains("clients.data"))
				{
					List<DynamicObject> array = dynamicObject2.GetArray("clients.data");
					if (0 == 0)
					{
						list7 = array;
					}
					goto IL_00b9;
				}
				goto IL_0168;
			}
			goto IL_0178;
			IL_020b:
			while (true)
			{
				refBm.PutDynamicObjects("all_accounts", list2);
				refBm.PutDynamicObjects("mta_accounts", list6);
				if (5 == 0)
				{
					break;
				}
				if (5u != 0)
				{
					refBm.PutDynamicObjects("mta_clients", list4);
					return StepResult.Of(success: true, refBm);
				}
			}
			goto IL_00b9;
			IL_0168:
			if (dynamicObject2.Contains("owned_ad_accounts.data"))
			{
				goto IL_0178;
			}
			goto IL_020b;
			IL_0178:
			List<DynamicObject> array2 = dynamicObject2.GetArray("owned_ad_accounts.data");
			enumerator = array2.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.Put("business", new JObject
					{
						{
							"id",
							dynamicObject2.GetString("id")
						},
						{
							"name",
							dynamicObject2.GetString("name")
						}
					});
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			list2.AddRange(array2);
			list6.AddRange(array2);
			goto IL_020b;
			IL_00b9:
			List<DynamicObject>.Enumerator enumerator2 = list7.GetEnumerator();
			if (0 == 0)
			{
				enumerator = enumerator2;
			}
			try
			{
				while (true)
				{
					if (enumerator.MoveNext())
					{
						DynamicObject current = enumerator.Current;
						JObject jObject = new JObject();
						JObject jObject2;
						if (3u != 0)
						{
							jObject2 = jObject;
						}
						JToken value = dynamicObject2.GetString("id");
						if (0 == 0)
						{
							jObject2.Add("id", value);
						}
						JToken value2 = dynamicObject2.GetString("name");
						if (7u != 0)
						{
							jObject2.Add("name", value2);
						}
						if (5u != 0)
						{
							current.Put("business", jObject2);
						}
					}
					else if (7u != 0)
					{
						break;
					}
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			List<DynamicObject> collection = list7;
			if (true)
			{
				list2.AddRange(collection);
			}
			list4.AddRange(list7);
			goto IL_0168;
		}
		return StepResult.Of(success: false, null);
	}

	static GetSocialBusinessResourceJobV2()
	{
		do
		{
			CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);
		}
		while (false);
		URL_1_SE = "O+ahX6owyDKqaUjUSJ/5kA==.xeWC4SFWHghMeERhNcozbozJqraMn2I5KqlDYCO1ErK8khgNOMxxnbf3VJNTeUCK8c3EwB+GYGc1VTdV7fziunS7EJDwHpi1wPiqwohgU977t5bKWpddrOSwHgcKfqOJJ4VaW14NpqsK94A7xXZdow==";
		do
		{
			if (0 == 0)
			{
				if (false)
				{
					goto IL_0054;
				}
				URL_1 = SecurityUtils.ReadStructEncrypted(URL_1_SE);
				URL_2_SE = "bsMdzsSpaFa7ZIH2JMVSZQ==.wfDOkOmQvW0+R27UGwjTJktHuJNFi18LOeqQ5dgGTbK7eMWN2QSKsYRu/vvLn7xDI1fzyJdOvr9m3Gnf4GCkLSMfzzCJFgNDErIjf2woFK5XGhLPwIGsMYI+SAEyaxwXq+Qi5ofsz0ajFQB8IMBIdg==";
			}
			else if (0 == 0)
			{
				continue;
			}
			goto IL_0045;
			IL_0045:
			URL_2 = SecurityUtils.ReadStructEncrypted(URL_2_SE);
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
