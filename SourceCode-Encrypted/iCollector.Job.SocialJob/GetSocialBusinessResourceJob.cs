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

internal class GetSocialBusinessResourceJob
{
	private static string CLAZZ_NAME_SE;

	private static string CLAZZ_NAME;

	private static readonly string URL_1_SE;

	private static readonly string URL_1;

	private Logger log = Logger.Instance();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	private JobExecutor jobExecutor = new JobExecutor();

	public SocialBusinessResourceResult Execute(SocialProfile profile)
	{
		if (7u != 0)
		{
		}
		GetSocialBusinessResourceJob getSocialBusinessResourceJob = this;
		if (0 == 0)
		{
			bool flag = true;
		}
		try
		{
			LogContext logContext = ctx;
			if (0 == 0)
			{
				logContext.MethodName = "Execute";
			}
			int num;
			SocialBusinessResourceResult result;
			if (profile.SocialBusinesssResourceResult != null)
			{
				num = (profile.SocialBusinesssResourceResult.needFetchAgain ? 1 : 0);
				if (false)
				{
					goto IL_02bd;
				}
				if (num == 0)
				{
					Logger logger = log;
					LogContext logContext2 = ctx;
					if (uint.MaxValue != 0)
					{
						logger.Info(logContext2, "don't need run again this job. skip process");
					}
					SocialBusinessResourceResult socialBusinesssResourceResult = profile.SocialBusinesssResourceResult;
					if (6u != 0)
					{
						return socialBusinesssResourceResult;
					}
					return result;
				}
			}
			SocialBusinessResourceResult socialBusinessResourceResult2;
			List<DynamicObject> list2;
			if (0 == 0)
			{
				string tokenForGotBusinessResources = profile.GetTokenForGotBusinessResources();
				string text;
				if (3u != 0)
				{
					text = tokenForGotBusinessResources;
				}
				if (!string.IsNullOrEmpty(text))
				{
					SocialBusinessResourceResult socialBusinessResourceResult = new SocialBusinessResourceResult();
					if (8u != 0)
					{
						socialBusinessResourceResult2 = socialBusinessResourceResult;
					}
					_ = profile.RestClient;
					string url = string.Format(URL_1, RestConst.RESOURCES_BUSINESSS_FIELDS, text);
					int num2 = default(int);
					if (0 == 0)
					{
						num2 = 7;
					}
					List<DynamicObject> list = new List<DynamicObject>();
					if (5u != 0)
					{
						list2 = list;
					}
					bool flag2 = default(bool);
					if (0 == 0)
					{
						flag2 = true;
					}
					while (true)
					{
						int num3 = num2--;
						int num4;
						while (true)
						{
							num4 = 0;
							while (true)
							{
								string text2;
								JobModel<List<DynamicObject>> jobModel;
								int count;
								int num5;
								if (num3 > num4)
								{
									text2 = url;
									Step step = new Step();
									step.Index = 0;
									step.Name = "GET_BM";
									step.Type = StepType.CURL;
									step.StopWhenSuccess = true;
									step.StopWhenFailed = true;
									step.CheckResultFunc = (string r) => getSocialBusinessResourceJob.ResolveBM(ref url, r);
									step.Spec = new CURLStepSpec
									{
										Url = url,
										Headers = new string[2] { "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" },
										RestClient = profile.RestClient
									};
									Step item = step;
									jobModel = new JobModel<List<DynamicObject>>
									{
										Name = "GET_BM_JOB",
										Steps = new List<Step> { item },
										SuccessWhenAllStepSuccess = true,
										ResultAtLastStepSuccess = true
									};
									jobExecutor.Execute(jobModel);
									if (jobModel.Result != null)
									{
										count = jobModel.Result.Count;
										num5 = 0;
										goto IL_0202;
									}
									goto IL_0212;
								}
								goto IL_02a9;
								IL_0212:
								log.Info(ctx, "businessAccountsData size: " + list2.Count);
								log.Info(ctx, "url after resolve: " + url);
								int num6;
								if (jobModel.Result == null)
								{
									num6 = 0;
									if (num6 == 0)
									{
										flag2 = (byte)num6 != 0;
										break;
									}
									goto IL_02ab;
								}
								if (!text2.Equals(url))
								{
									count = list2.Count;
									num5 = 100;
									if (num5 == 0)
									{
										goto IL_0202;
									}
									if (count <= num5)
									{
										break;
									}
								}
								goto IL_02a9;
								IL_0202:
								if (count > num5)
								{
									list2.AddRange(jobModel.Result);
								}
								goto IL_0212;
								IL_02ab:
								if (num6 == 0)
								{
									goto end_IL_02a3;
								}
								num3 = list2.Count;
								num4 = 0;
								if (num4 != 0)
								{
									continue;
								}
								goto IL_02b8;
								IL_02a9:
								num6 = (flag2 ? 1 : 0);
								goto IL_02ab;
							}
							num3 = 3000;
							if (num3 != 0)
							{
								goto IL_0297;
							}
							continue;
							end_IL_02a3:
							break;
						}
						num = 1;
						break;
						IL_02b8:
						num = ((num3 == num4) ? 1 : 0);
						break;
						IL_0297:
						Thread.Sleep(num3);
					}
					goto IL_02bd;
				}
				Logger logger2 = log;
				LogContext logContext3 = ctx;
				if (5u != 0)
				{
					logger2.Info(logContext3, "token empty. skip process");
				}
			}
			if (2u != 0)
			{
				return null;
			}
			return result;
			IL_02bd:
			bool flag = (byte)num != 0;
			socialBusinessResourceResult2.BusinessAccounts = list2;
			socialBusinessResourceResult2.needFetchAgain = flag;
			return socialBusinessResourceResult2;
		}
		catch (Exception ex)
		{
			log.Error(ctx, ex.ToString());
			SocialBusinessResourceResult result;
			do
			{
				result = null;
			}
			while (3 == 0);
			return result;
		}
	}

	private StepResult ResolveBM(ref string url, string response)
	{
		Logger logger = log;
		LogContext logContext = ctx;
		string message = "response bm: " + response;
		if (5u != 0)
		{
			logger.Info(logContext, message);
		}
		DynamicObject dynamicObject2;
		List<DynamicObject> list;
		if (0 == 0)
		{
			DynamicObject dynamicObject = new DynamicObject(JsonConvert.DeserializeObject<JObject>(response));
			if (4u != 0)
			{
				dynamicObject2 = dynamicObject;
			}
			if (!dynamicObject2.Contains("data"))
			{
				return StepResult.Of(success: false, null);
			}
			List<DynamicObject> array = dynamicObject2.GetArray("data");
			if (6u != 0)
			{
				list = array;
			}
			if (list.Count <= 0 || !dynamicObject2.Contains("paging.next") || string.IsNullOrEmpty(dynamicObject2.GetString("paging.next")))
			{
				goto IL_0091;
			}
		}
		url = dynamicObject2.GetString("paging.next");
		goto IL_0091;
		IL_0091:
		List<DynamicObject>.Enumerator enumerator = list.GetEnumerator();
		List<DynamicObject>.Enumerator enumerator2 = default(List<DynamicObject>.Enumerator);
		if (0 == 0)
		{
			enumerator2 = enumerator;
		}
		try
		{
			DynamicObject dynamicObject3 = default(DynamicObject);
			List<DynamicObject> list3 = default(List<DynamicObject>);
			List<DynamicObject> list5 = default(List<DynamicObject>);
			List<DynamicObject> list8 = default(List<DynamicObject>);
			List<DynamicObject>.Enumerator enumerator4 = default(List<DynamicObject>.Enumerator);
			while (enumerator2.MoveNext())
			{
				while (true)
				{
					DynamicObject current = enumerator2.Current;
					if (0 == 0)
					{
						dynamicObject3 = current;
					}
					DynamicObject dynamicObject4 = dynamicObject3;
					object value = BAUtils.IsAdmin(dynamicObject3);
					if (uint.MaxValue != 0)
					{
						dynamicObject4.Put("is_admin", value);
					}
					DynamicObject dynamicObject5 = dynamicObject3;
					object value2 = BAUtils.IsVerified(dynamicObject3);
					if (0 == 0)
					{
						dynamicObject5.Put("is_verified", value2);
					}
					List<DynamicObject> list2 = new List<DynamicObject>();
					if (0 == 0)
					{
						list3 = list2;
					}
					List<DynamicObject> list4 = new List<DynamicObject>();
					if (0 == 0)
					{
						list5 = list4;
					}
					List<DynamicObject> list6 = new List<DynamicObject>();
					List<DynamicObject> list7;
					if (2u != 0)
					{
						list7 = list6;
					}
					if (dynamicObject3.Contains("clients.data"))
					{
						List<DynamicObject> array2 = dynamicObject3.GetArray("clients.data");
						if (0 == 0)
						{
							list8 = array2;
						}
						List<DynamicObject>.Enumerator enumerator3 = list8.GetEnumerator();
						if (0 == 0)
						{
							enumerator4 = enumerator3;
						}
						try
						{
							while (enumerator4.MoveNext())
							{
								enumerator4.Current.Put("business", new JObject
								{
									{
										"id",
										dynamicObject3.GetString("id")
									},
									{
										"name",
										dynamicObject3.GetString("name")
									}
								});
							}
						}
						finally
						{
							((IDisposable)enumerator4).Dispose();
						}
						list3.AddRange(list8);
						list5.AddRange(list8);
					}
					if (dynamicObject3.Contains("owned_ad_accounts.data"))
					{
						List<DynamicObject> array3 = dynamicObject3.GetArray("owned_ad_accounts.data");
						if (8 == 0)
						{
							if (8u != 0)
							{
								break;
							}
							continue;
						}
						if (8 == 0)
						{
							goto IL_0282;
						}
						enumerator4 = array3.GetEnumerator();
						try
						{
							while (true)
							{
								if (enumerator4.MoveNext() && 0 == 0)
								{
									enumerator4.Current.Put("business", new JObject
									{
										{
											"id",
											dynamicObject3.GetString("id")
										},
										{
											"name",
											dynamicObject3.GetString("name")
										}
									});
								}
								else if (0 == 0)
								{
									break;
								}
							}
						}
						finally
						{
							((IDisposable)enumerator4).Dispose();
						}
						list3.AddRange(array3);
						list7.AddRange(array3);
					}
					dynamicObject3.PutDynamicObjects("all_accounts", list3);
					goto IL_0282;
					IL_0282:
					dynamicObject3.PutDynamicObjects("mta_accounts", list7);
					break;
				}
				dynamicObject3.PutDynamicObjects("mta_clients", list5);
			}
		}
		finally
		{
			((IDisposable)enumerator2).Dispose();
		}
		return StepResult.Of(success: true, list);
	}

	static GetSocialBusinessResourceJob()
	{
		while (true)
		{
			int num = 0;
			if (num == 0)
			{
				if (num == 0)
				{
					goto IL_0006;
				}
				goto IL_0010;
			}
			goto IL_0042;
			IL_0006:
			CLAZZ_NAME_SE = "hkWySujOIB8HJrDRIUxwjw==.T30h/huGcJso7DFnoRE0oYDCITD1Lko65riYBEZAlaNEwccRDjLo/F+1uLw7BeFk";
			goto IL_0010;
			IL_0042:
			if (num == 0)
			{
				break;
			}
			goto IL_0010;
			IL_0010:
			CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);
			num = 0;
			if (num == 0)
			{
				if (num != 0)
				{
					continue;
				}
				URL_1_SE = "yE1FXAjxAv+SFLmkQp7x3g==.OX4NgL03hsJWg+eG2mQJlPF8ZRLXwt+QZRrWa1wdLUWwozi/GD0NGq8UeMpd6U0nOf+tjx2jvR+mqTsnA8TydGmyXNaK772hjx4TsRiB7Nn0qYbuzVDk9acb2gqYHrvtQOqLqaWjRt+q3DIthc67eQ==";
				if (3 == 0)
				{
					goto IL_0006;
				}
				URL_1 = SecurityUtils.ReadStructEncrypted(URL_1_SE);
				num = 0;
			}
			goto IL_0042;
		}
	}
}
