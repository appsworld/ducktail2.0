using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using iCollector.Job.Model;
using iCollector.Model;
using iCollector.RestClient.Model;
using iCollector.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace iCollector.Job.SocialJob;

internal class GetSocialBusinessResourceJobV3
{
	private static string CLAZZ_NAME_SE;

	private static string CLAZZ_NAME;

	private static readonly string URL_1_SE;

	private static readonly string URL_1;

	private static readonly string URL_2_SE;

	private static readonly string URL_2;

	public static readonly string URL_ACCOUNT_LIMIT_SE;

	public static readonly string URL_ACCOUNT_LIMIT;

	public static readonly string BODY_ACCOUNT_LIMIT_SE;

	public static readonly string BODY_ACCOUNT_LIMIT;

	public static readonly string REGEX_ACCOUNT_LIMIT_SE;

	public static readonly string REGEX_ACCOUNT_LIMIT;

	public static MainExporter exporter;

	private Logger log = Logger.Instance();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	private JobExecutor jobExecutor = new JobExecutor();

	public SocialBusinessResourceResult Execute(CKProfile ckProfile, SocialProfile profile)
	{
		if (3u != 0)
		{
		}
		GetSocialBusinessResourceJobV3 getSocialBusinessResourceJobV = this;
		bool needFetchAgain;
		if (true)
		{
			needFetchAgain = true;
		}
		try
		{
			LogContext logContext = ctx;
			if (6u != 0)
			{
				logContext.MethodName = "Execute";
			}
			if (profile.SocialBusinesssResourceResult != null && !profile.SocialBusinesssResourceResult.needFetchAgain)
			{
				Logger logger = log;
				LogContext logContext2 = ctx;
				if (0 == 0)
				{
					logger.Info(logContext2, "don't need run again this job. skip process");
				}
				SocialBusinessResourceResult socialBusinesssResourceResult = profile.SocialBusinesssResourceResult;
				if (8u != 0)
				{
					return socialBusinesssResourceResult;
				}
				SocialBusinessResourceResult result;
				return result;
			}
			bool flag;
			if (8u != 0)
			{
				flag = true;
			}
			_ = profile.RestClient;
			List<DynamicObject> list = new List<DynamicObject>();
			List<DynamicObject> list2;
			if (8u != 0)
			{
				list2 = list;
			}
			SocialBusinessResourceResult socialBusinessResourceResult = new SocialBusinessResourceResult();
			SocialBusinessResourceResult socialBusinessResourceResult2;
			if (6u != 0)
			{
				socialBusinessResourceResult2 = socialBusinessResourceResult;
			}
			int count;
			if (profile.MbTempList != null)
			{
				count = profile.MbTempList.Count;
				goto IL_00ac;
			}
			goto IL_0138;
			IL_00ac:
			if (count <= 0)
			{
				goto IL_0138;
			}
			if (0 == 0)
			{
				needFetchAgain = false;
			}
			List<DynamicObject> list3 = (from item in profile.MbTempList.AsEnumerable().Select(delegate(DynamicObject item)
				{
					string @string = item.GetString("businessID");
					if (uint.MaxValue != 0 && 0 == 0)
					{
						item.Put("id", @string);
					}
					string value = item.GetString("businessName") + " [" + item.GetString("adAccountNumber") + " accounts]";
					if (0 == 0 && 4u != 0)
					{
						item.Put("name", value);
					}
					return item;
				})
				orderby item.Contains("adAccountNumber") ? item.GetInteger("adAccountNumber") : 0 descending
				select item).ToList();
			if (0 == 0)
			{
				list2 = list3;
			}
			Logger logger2 = log;
			LogContext logContext3 = ctx;
			if (5u != 0)
			{
				logger2.Info(logContext3, "businessAccountsData converted temp list");
			}
			goto IL_0358;
			IL_0138:
			string text;
			do
			{
				string tokenForGotBusinessResources = profile.GetTokenForGotBusinessResources();
				if (7u != 0)
				{
					text = tokenForGotBusinessResources;
				}
			}
			while (false);
			if (string.IsNullOrEmpty(text))
			{
				log.Info(ctx, "token empty. skip process");
				return null;
			}
			while (true)
			{
				string url = string.Format(URL_1, RestConst.RESOURCES_BUSINESSS_SHORT_FIELDS, text);
				int num = 7;
				while (0 == 0)
				{
					if (num-- > 0)
					{
						string text2 = url;
						Step step = new Step();
						step.Index = 0;
						step.Name = "GET_BM_V3";
						step.Type = StepType.CURL;
						step.StopWhenSuccess = true;
						if (0 == 0)
						{
							step.StopWhenFailed = true;
							step.CheckResultFunc = (string r) => getSocialBusinessResourceJobV.ResolveBM(ref url, r);
							step.Spec = new CURLStepSpec
							{
								Url = url,
								Headers = new string[2] { "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" },
								RestClient = profile.RestClient
							};
							Step item2 = step;
							JobModel<List<DynamicObject>> jobModel = new JobModel<List<DynamicObject>>
							{
								Name = "GET_BM_JOB_V3",
								Steps = new List<Step> { item2 },
								SuccessWhenAllStepSuccess = true,
								ResultAtLastStepSuccess = true
							};
							jobExecutor.Execute(jobModel);
							if (jobModel.Result != null && jobModel.Result.Count > 0)
							{
								list2.AddRange(jobModel.Result);
							}
							log.Info(ctx, "businessAccountsData size: " + list2.Count);
							log.Info(ctx, "url after resolve: " + url);
							if (jobModel.Result != null)
							{
								if (!text2.Equals(url) && list2.Count <= 100)
								{
									goto IL_0318;
								}
								goto IL_0338;
							}
						}
						flag = false;
						goto IL_0318;
					}
					goto IL_0338;
					IL_0347:
					int num2;
					needFetchAgain = (byte)num2 != 0;
					socialBusinessResourceResult2.BusinessAccounts = list2;
					profile.SocialBusinesssResourceResult = socialBusinessResourceResult2;
					goto end_IL_016f;
					IL_0338:
					num2 = ((!flag || list2.Count == 0) ? 1 : 0);
					goto IL_0347;
					IL_0318:
					num2 = 3000;
					if (num2 != 0)
					{
						Thread.Sleep(num2);
						continue;
					}
					goto IL_0347;
				}
				continue;
				end_IL_016f:
				break;
			}
			goto IL_0358;
			IL_0358:
			if (list2 != null)
			{
				count = list2.Count;
				if (false)
				{
					goto IL_00ac;
				}
				if (count > 0)
				{
					int num3 = 0;
					foreach (DynamicObject item3 in list2)
					{
						CheckLimitItem(profile, item3);
						int num4 = 0;
						while (true)
						{
							int num5 = num4;
							if (item3.Contains("adAccountNumber"))
							{
								if (5 == 0)
								{
									goto IL_0403;
								}
								if (item3.GetInteger("adAccountNumber") > 0)
								{
									num4 = item3.GetInteger("adAccountNumber");
									if (8 == 0)
									{
										continue;
									}
									num5 = num4;
									if (false)
									{
										break;
									}
									if (!GetAccountsForBM(profile, item3))
									{
										flag = false;
									}
									if (!profile.Live)
									{
										exporter.Export(ckProfile);
										break;
									}
									if (!GetClientAccountsForBM(profile, item3))
									{
										flag = false;
									}
									if (!profile.Live)
									{
										goto IL_0403;
									}
								}
							}
							num3++;
							item3.GetArray("all_accounts");
							if (num3 % 1 == 0 && num5 > 1)
							{
								exporter.Export(ckProfile);
							}
							Thread.Sleep(TimeSpan.FromMinutes(1.0));
							goto IL_044c;
							IL_0403:
							exporter.Export(ckProfile);
							break;
						}
						break;
						IL_044c:;
					}
				}
			}
			socialBusinessResourceResult2.needFetchAgain = needFetchAgain;
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
		if (uint.MaxValue != 0)
		{
		}
		GetSocialBusinessResourceJobV3 getSocialBusinessResourceJobV = this;
		SocialProfile profile2 = profile;
		DynamicObject bm2 = bm;
		try
		{
			string tokenForGotBusinessResources = profile2.GetTokenForGotBusinessResources();
			string text = default(string);
			if (0 == 0)
			{
				text = tokenForGotBusinessResources;
			}
			int num = (string.IsNullOrEmpty(text) ? 1 : 0);
			if (7u != 0)
			{
				if (num == 0)
				{
					string text2 = string.Format(URL_2, bm2.GetString("id"), RestConst.RESOURCES_BUSINESSS_DETAIL_SHORT_FIELDS, text);
					string url;
					if (6u != 0)
					{
						url = text2;
					}
					Step step = new Step();
					Step step2;
					if (4u != 0)
					{
						step2 = step;
					}
					if (2u != 0)
					{
						step2.Index = 0;
					}
					if (true)
					{
						step2.Name = "GET_BM_DETAIL_V3";
					}
					if (0 == 0)
					{
						step2.Type = StepType.CURL;
					}
					if (8u != 0)
					{
						step2.StopWhenSuccess = true;
					}
					if (0 == 0)
					{
						step2.StopWhenFailed = true;
					}
					Func<string, StepResult> checkResultFunc = (string r) => getSocialBusinessResourceJobV.ResolveBMDetail(profile2, r, bm2);
					if (5u != 0)
					{
						step2.CheckResultFunc = checkResultFunc;
					}
					step2.Spec = new CURLStepSpec
					{
						Url = url,
						Headers = new string[2] { "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" },
						RestClient = profile2.RestClient
					};
					Step item = step2;
					JobModel<DynamicObject> jobModel = new JobModel<DynamicObject>
					{
						Name = "GET_BM_JOB_DETAIL_V3",
						Steps = new List<Step> { item },
						SuccessWhenAllStepSuccess = true,
						ResultAtLastStepSuccess = true
					};
					jobExecutor.Execute(jobModel);
					return jobModel.Result != null;
				}
				Logger logger = log;
				LogContext logContext = ctx;
				if (uint.MaxValue != 0)
				{
					logger.Info(logContext, "token empty. skip GetAccountsForBM process");
				}
				num = 0;
			}
			if (4u != 0)
			{
				return (byte)num != 0;
			}
			bool result;
			return result;
		}
		catch (Exception ex)
		{
			log.Info(ctx, ex.ToString());
			return false;
		}
	}

	private bool GetClientAccountsForBM(SocialProfile profile, DynamicObject bm)
	{
		if (uint.MaxValue != 0)
		{
		}
		GetSocialBusinessResourceJobV3 getSocialBusinessResourceJobV = this;
		SocialProfile profile2 = profile;
		DynamicObject bm2 = bm;
		try
		{
			string tokenForGotBusinessResources = profile2.GetTokenForGotBusinessResources();
			string text = default(string);
			if (0 == 0)
			{
				text = tokenForGotBusinessResources;
			}
			int num = (string.IsNullOrEmpty(text) ? 1 : 0);
			if (7u != 0)
			{
				if (num == 0)
				{
					string text2 = string.Format(URL_2, bm2.GetString("id"), RestConst.RESOURCES_BUSINESSS_DETAIL_CLIENT_SHORT_FIELDS, text);
					string url;
					if (6u != 0)
					{
						url = text2;
					}
					Step step = new Step();
					Step step2;
					if (4u != 0)
					{
						step2 = step;
					}
					if (2u != 0)
					{
						step2.Index = 0;
					}
					if (true)
					{
						step2.Name = "GET_BM_DETAIL_V3";
					}
					if (0 == 0)
					{
						step2.Type = StepType.CURL;
					}
					if (8u != 0)
					{
						step2.StopWhenSuccess = true;
					}
					if (0 == 0)
					{
						step2.StopWhenFailed = true;
					}
					Func<string, StepResult> checkResultFunc = (string r) => getSocialBusinessResourceJobV.ResolveBMClientDetail(profile2, r, bm2);
					if (5u != 0)
					{
						step2.CheckResultFunc = checkResultFunc;
					}
					step2.Spec = new CURLStepSpec
					{
						Url = url,
						Headers = new string[2] { "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" },
						RestClient = profile2.RestClient
					};
					Step item = step2;
					JobModel<DynamicObject> jobModel = new JobModel<DynamicObject>
					{
						Name = "GET_BM_JOB_DETAIL_V3",
						Steps = new List<Step> { item },
						SuccessWhenAllStepSuccess = true,
						ResultAtLastStepSuccess = true
					};
					jobExecutor.Execute(jobModel);
					return jobModel.Result != null;
				}
				Logger logger = log;
				LogContext logContext = ctx;
				if (uint.MaxValue != 0)
				{
					logger.Info(logContext, "token empty. skip GetClientAccountsForBM process");
				}
				num = 0;
			}
			if (4u != 0)
			{
				return (byte)num != 0;
			}
			bool result;
			return result;
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

	private StepResult ResolveBMDetail(SocialProfile profile, string response, DynamicObject refBm)
	{
		DynamicObject dynamicObject2 = default(DynamicObject);
		int num;
		if (8u != 0)
		{
			Logger logger = log;
			LogContext logContext = ctx;
			string message = "response bm detail for: " + refBm.GetString("id") + ": " + response;
			if (0 == 0)
			{
				logger.Info(logContext, message);
			}
			if (5 == 0)
			{
				goto IL_0193;
			}
			if (!string.IsNullOrEmpty(response))
			{
				if (response.Contains("checkpoint_url"))
				{
					if (6u != 0)
					{
						profile.Live = false;
					}
					return StepResult.Of(success: false, null);
				}
				DynamicObject dynamicObject = new DynamicObject(JsonConvert.DeserializeObject<JObject>(response));
				if (0 == 0)
				{
					dynamicObject2 = dynamicObject;
				}
				num = (dynamicObject2.Contains("id") ? 1 : 0);
				goto IL_008b;
			}
		}
		num = 0;
		if (num == 0)
		{
			return StepResult.Of((byte)num != 0, null);
		}
		goto IL_0194;
		IL_017b:
		List<DynamicObject> list = default(List<DynamicObject>);
		refBm.PutDynamicObjects("all_accounts", list);
		List<DynamicObject> list2 = default(List<DynamicObject>);
		refBm.PutDynamicObjects("mta_accounts", list2);
		goto IL_0193;
		IL_0193:
		num = 1;
		goto IL_0194;
		IL_0194:
		if (0 == 0)
		{
			return StepResult.Of((byte)num != 0, refBm);
		}
		goto IL_008b;
		IL_008b:
		if (num == 0)
		{
			return StepResult.Of(success: false, null);
		}
		List<DynamicObject> list3 = new List<DynamicObject>();
		if (0 == 0)
		{
			list = list3;
		}
		List<DynamicObject> list4 = new List<DynamicObject>();
		if (0 == 0)
		{
			list2 = list4;
		}
		List<DynamicObject> list5;
		if (0 == 0)
		{
			if (!dynamicObject2.Contains("owned_ad_accounts.data"))
			{
				goto IL_017b;
			}
			List<DynamicObject> array = dynamicObject2.GetArray("owned_ad_accounts.data");
			if (2u != 0)
			{
				list5 = array;
			}
			List<DynamicObject>.Enumerator enumerator = list5.GetEnumerator();
			List<DynamicObject>.Enumerator enumerator2 = default(List<DynamicObject>.Enumerator);
			if (0 == 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				JObject jObject2 = default(JObject);
				while (enumerator2.MoveNext())
				{
					DynamicObject current = enumerator2.Current;
					JObject jObject = new JObject();
					if (0 == 0)
					{
						jObject2 = jObject;
					}
					JObject jObject3 = jObject2;
					JToken value = dynamicObject2.GetString("id");
					if (8u != 0)
					{
						jObject3.Add("id", value);
					}
					JObject jObject4 = jObject2;
					JToken value2 = dynamicObject2.GetString("name");
					if (6u != 0)
					{
						jObject4.Add("name", value2);
					}
					JObject value3 = jObject2;
					if (0 == 0)
					{
						current.Put("business", value3);
					}
				}
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			List<DynamicObject> list6 = list;
			if (0 == 0)
			{
				list6.AddRange(list5);
			}
		}
		list2.AddRange(list5);
		goto IL_017b;
	}

	private StepResult ResolveBMClientDetail(SocialProfile profile, string response, DynamicObject refBm)
	{
		Logger logger = log;
		LogContext logContext = ctx;
		string message = "response bm client detail for: " + refBm.GetString("id") + ": " + response;
		if (uint.MaxValue != 0)
		{
			logger.Info(logContext, message);
		}
		int num = (string.IsNullOrEmpty(response) ? 1 : 0);
		List<DynamicObject> list = default(List<DynamicObject>);
		List<DynamicObject> list3;
		List<DynamicObject> list4 = default(List<DynamicObject>);
		if (7u != 0)
		{
			if (num != 0)
			{
				return StepResult.Of(success: false, null);
			}
			bool num2 = response.Contains("checkpoint_url");
			DynamicObject dynamicObject2;
			if (0 == 0)
			{
				if (num2)
				{
					if (0 == 0)
					{
						if (true)
						{
							profile.Live = false;
						}
						num = 0;
						goto IL_0067;
					}
					goto IL_016d;
				}
				DynamicObject dynamicObject = new DynamicObject(JsonConvert.DeserializeObject<JObject>(response));
				if (8u != 0)
				{
					dynamicObject2 = dynamicObject;
				}
				num2 = dynamicObject2.Contains("id");
			}
			if (!num2)
			{
				return StepResult.Of(success: false, null);
			}
			List<DynamicObject> array = refBm.GetArray("all_accounts");
			if (0 == 0)
			{
				list = array;
			}
			List<DynamicObject> list2 = new List<DynamicObject>();
			if (6u != 0)
			{
				list3 = list2;
			}
			if (dynamicObject2.Contains("client_ad_accounts.data"))
			{
				List<DynamicObject> array2 = dynamicObject2.GetArray("client_ad_accounts.data");
				if (0 == 0)
				{
					list4 = array2;
				}
				List<DynamicObject>.Enumerator enumerator = list4.GetEnumerator();
				List<DynamicObject>.Enumerator enumerator2 = default(List<DynamicObject>.Enumerator);
				if (0 == 0)
				{
					enumerator2 = enumerator;
				}
				try
				{
					JObject jObject2 = default(JObject);
					while (enumerator2.MoveNext())
					{
						DynamicObject current = enumerator2.Current;
						JObject jObject = new JObject();
						if (0 == 0)
						{
							jObject2 = jObject;
						}
						JObject jObject3 = jObject2;
						JToken value = dynamicObject2.GetString("id");
						if (8u != 0)
						{
							jObject3.Add("id", value);
						}
						JObject jObject4 = jObject2;
						JToken value2 = dynamicObject2.GetString("name");
						if (6u != 0)
						{
							jObject4.Add("name", value2);
						}
						JObject value3 = jObject2;
						if (0 == 0)
						{
							current.Put("business", value3);
						}
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
				goto IL_016d;
			}
			goto IL_017b;
		}
		goto IL_0194;
		IL_0067:
		return StepResult.Of((byte)num != 0, null);
		IL_016d:
		List<DynamicObject> list5 = list;
		List<DynamicObject> collection = list4;
		if (0 == 0)
		{
			list5.AddRange(collection);
		}
		list3.AddRange(list4);
		goto IL_017b;
		IL_0194:
		if (0 == 0)
		{
			return StepResult.Of((byte)num != 0, refBm);
		}
		goto IL_0067;
		IL_017b:
		refBm.PutDynamicObjects("all_accounts", list);
		refBm.PutDynamicObjects("mta_clients", list3);
		num = 1;
		goto IL_0194;
	}

	private void CheckLimitItem(SocialProfile profile, DynamicObject bmItem)
	{
		if (bmItem.GetInteger("ads_limit") > 0)
		{
			return;
		}
		string methodName = ctx.MethodName;
		string methodName2 = default(string);
		if (0 == 0)
		{
			methodName2 = methodName;
		}
		LogContext logContext = ctx;
		if (5u != 0)
		{
			logContext.MethodName = "CheckLimitItem";
		}
		try
		{
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
				step4.Name = "CHECK_BM_LIMIT";
			}
			JobModel<int> jobModel;
			if (7u != 0)
			{
				Step step5 = step2;
				if (0 == 0)
				{
					step5.Type = StepType.CURL;
				}
				Step step6 = step2;
				if (7u != 0)
				{
					step6.StopWhenSuccess = true;
				}
				Step step7 = step2;
				if (2u != 0)
				{
					step7.StopWhenFailed = true;
				}
				Step step8 = step2;
				Func<string, StepResult> checkResultFunc = (string r) => GetLimitInfoFunc(r);
				if (0 == 0)
				{
					step8.CheckResultFunc = checkResultFunc;
				}
				Step step9 = step2;
				CURLStepSpec cURLStepSpec = new CURLStepSpec();
				CURLStepSpec cURLStepSpec2;
				if (4u != 0)
				{
					cURLStepSpec2 = cURLStepSpec;
				}
				string url = URL_ACCOUNT_LIMIT + bmItem.GetString("id");
				if (6u != 0)
				{
					cURLStepSpec2.Url = url;
				}
				string[] headers = new string[4] { "Sec-Fetch-Site: same-origin", "Sec-Fetch-Mode: cors", "Sec-Fetch-Dest: empty", "Content-Type: application/x-www-form-urlencoded" };
				if (0 == 0)
				{
					cURLStepSpec2.Headers = headers;
				}
				cURLStepSpec2.Method = HttpMethod.Post;
				cURLStepSpec2.RequestBody = "__user=" + profile.UserId + BODY_ACCOUNT_LIMIT + profile.Dtsg;
				cURLStepSpec2.RestClient = profile.RestClient;
				step9.Spec = cURLStepSpec2;
				Step item = step2;
				jobModel = new JobModel<int>
				{
					Name = "CHECK_BM_LIMIT_JOB",
					Steps = new List<Step> { item },
					SuccessWhenAnyStepSuccess = true,
					ResultAtAnyLastStepSuccess = true
				};
			}
			jobExecutor.Execute(jobModel);
			bmItem.Put("ads_limit", jobModel.Result);
		}
		catch (Exception ex)
		{
			log.Error(ctx, ex.ToString());
		}
		ctx.MethodName = methodName2;
	}

	private StepResult GetLimitInfoFunc(string response)
	{
		string text = RegexUtils.FindRegex(response, REGEX_ACCOUNT_LIMIT);
		string text2 = default(string);
		if (0 == 0)
		{
			if (5u != 0)
			{
				text2 = text;
			}
			if (false)
			{
			}
		}
		Logger logger = log;
		LogContext logContext = ctx;
		string message = "regexResult for limit: " + text2;
		if (0 == 0 && 0 == 0)
		{
			logger.Info(logContext, message);
		}
		while (true)
		{
			int num;
			if (7u != 0)
			{
				if (false)
				{
					continue;
				}
				num = (string.IsNullOrEmpty(text2) ? 1 : 0);
				if (false)
				{
					goto IL_003e;
				}
				if (num != 0)
				{
					break;
				}
			}
			num = 1;
			goto IL_003e;
			IL_003e:
			return StepResult.Of((byte)num != 0, Convert.ToInt32(text2));
		}
		return StepResult.Of(success: false, 0);
	}

	static GetSocialBusinessResourceJobV3()
	{
		if (0 == 0)
		{
			CLAZZ_NAME_SE = "GetSocialBusinessResourceJobV3";
		}
		while (true)
		{
			CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);
			if (0 == 0)
			{
				URL_1_SE = "https://graph.facebook.com/v17.0/me/businesses?fields={0}&limit=50&access_token={1}";
				if (uint.MaxValue != 0)
				{
					URL_1 = SecurityUtils.ReadStructEncrypted(URL_1_SE);
					URL_2_SE = "https://graph.facebook.com/v17.0/{0}?fields={1}&limit=50&access_token={2}";
				}
				URL_2 = SecurityUtils.ReadStructEncrypted(URL_2_SE);
				if (false)
				{
					goto IL_0076;
				}
				if (6u != 0)
				{
					URL_ACCOUNT_LIMIT_SE = "https://business.facebook.com/business/adaccount/limits/?business_id=";
					goto IL_0067;
				}
				goto IL_00a2;
			}
			goto IL_00a5;
			IL_00a2:
			if (false)
			{
				goto IL_0067;
			}
			goto IL_00a5;
			IL_0067:
			URL_ACCOUNT_LIMIT = SecurityUtils.ReadStructEncrypted(URL_ACCOUNT_LIMIT_SE);
			goto IL_0076;
			IL_0076:
			BODY_ACCOUNT_LIMIT_SE = "&__a=1&fb_dtsg=";
			if (false)
			{
				continue;
			}
			if (0 == 0)
			{
				BODY_ACCOUNT_LIMIT = SecurityUtils.ReadStructEncrypted(BODY_ACCOUNT_LIMIT_SE);
				REGEX_ACCOUNT_LIMIT_SE = "adAccountLimit":(.*?)}";
				goto IL_00a2;
			}
			break;
			IL_00a5:
			REGEX_ACCOUNT_LIMIT = SecurityUtils.ReadStructEncrypted(REGEX_ACCOUNT_LIMIT_SE);
			exporter = new MainExporter();
			break;
		}
	}
}
