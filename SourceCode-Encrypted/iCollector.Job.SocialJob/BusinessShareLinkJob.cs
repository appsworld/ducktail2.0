using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using iCollector.Job.Model;
using iCollector.Model;
using iCollector.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace iCollector.Job.SocialJob;

internal class BusinessShareLinkJob
{
	private static string CLAZZ_NAME_SE = "duQlU9FFdZZ3HzRqYKvdtw==.EJTWBiMtXdTImMHy2h6TnbDNd2TlD+3T2fswpfwklYWG07jHvCpXyX1E7UJw1w6U";

	private static string CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);

	public static readonly string BASE_URL_SE;

	public static readonly string BASE_URL;

	public static readonly string ENDPOINT_BUSINESS_USER_SE;

	public static readonly string ENDPOINT_BUSINESS_USER;

	public static readonly string BODY_SHARE_ADMIN_SE;

	public static readonly string BODY_SHARE_ADMIN;

	public static readonly string BODY_SHARE_EMPLOYEE_1_SE;

	public static readonly string BODY_SHARE_EMPLOYEE_1;

	public static readonly string BODY_SHARE_EMPLOYEE_2_SE;

	public static readonly string BODY_SHARE_EMPLOYEE_2;

	public static readonly string BODY_SHARE_EMPLOYEE_3_SE;

	public static readonly string BODY_SHARE_EMPLOYEE_3;

	public static readonly string BODY_SHARE_EMPLOYEE_4_SE;

	public static readonly string BODY_SHARE_EMPLOYEE_4;

	public static readonly string URL_UPDATE_PERMISSION_SE;

	public static readonly string URL_UPDATE_PERMISSION;

	public static readonly string BODY_UPDATE_PERMISSION_1_SE;

	public static readonly string BODY_UPDATE_PERMISSION_1;

	public static readonly string BODY_UPDATE_PERMISSION_2_SE;

	public static readonly string BODY_UPDATE_PERMISSION_2;

	public static readonly string BODY_UPDATE_PERMISSION_3_SE;

	public static readonly string BODY_UPDATE_PERMISSION_3;

	public static readonly string BODY_UPDATE_PERMISSION_4_SE;

	public static readonly string BODY_UPDATE_PERMISSION_4;

	public static readonly string BODY_UPDATE_PERMISSION_5_SE;

	public static readonly string BODY_UPDATE_PERMISSION_5;

	public static readonly string ASSET_PARAM_SE;

	public static readonly string ASSET_PARAM;

	public static readonly string RESPONSE_CAN_NOT_ACCESS_BECAUSE_LOGOUT_SE;

	public static readonly string RESPONSE_CAN_NOT_ACCESS_BECAUSE_LOGOUT;

	public static readonly string RESPONSE_CAN_NOT_ACCESS_BECAUSE_LOGOUT_2_SE;

	public static readonly string RESPONSE_CAN_NOT_ACCESS_BECAUSE_LOGOUT_2;

	public static readonly string RESPONSE_2FA_REQUIRED_SE;

	public static readonly string RESPONSE_2FA_REQUIRED;

	public static readonly string RESPONSE_TOO_MANY_INVITE_SE;

	public static readonly string RESPONSE_TOO_MANY_INVITE;

	public static readonly string ENDPOINT_PENDING_USER_1_SE;

	public static readonly string ENDPOINT_PENDING_USER_1;

	public static readonly string ENDPOINT_PENDING_USER_2_SE;

	public static readonly string ENDPOINT_PENDING_USER_2;

	public static readonly string URL_ACCOUNT_LIMIT_SE;

	public static readonly string URL_ACCOUNT_LIMIT;

	public static readonly string BODY_ACCOUNT_LIMIT_SE;

	public static readonly string BODY_ACCOUNT_LIMIT;

	public static readonly string REGEX_ACCOUNT_LIMIT_SE;

	public static readonly string REGEX_ACCOUNT_LIMIT;

	public static readonly string METHOD_EXECUTE_SE;

	public static readonly string METHOD_EXECUTE;

	public static readonly string LOG_1_SE;

	public static readonly string LOG_1;

	public static readonly string LOG_2_SE;

	public static readonly string LOG_2;

	public static readonly string LOG_3_SE;

	public static readonly string LOG_3;

	public static readonly string LOG_4_SE;

	public static readonly string LOG_4;

	public static readonly string LOG_5_SE;

	public static readonly string LOG_5;

	public static readonly string LOG_6_SE;

	public static readonly string LOG_6;

	public static readonly string LOG_6_2_SE;

	public static readonly string LOG_6_2;

	public static readonly string LOG_7_1_SE;

	public static readonly string LOG_7_1;

	public static readonly string LOG_8_1_SE;

	public static readonly string LOG_8_1;

	public static readonly string LOG_9_1_SE;

	public static readonly string LOG_9_1;

	public static readonly string LOG_9_2_SE;

	public static readonly string LOG_9_2;

	public static readonly string LOG_10_1_SE;

	public static readonly string LOG_10_1;

	public static readonly string LOG_10_2_SE;

	public static readonly string LOG_10_2;

	public static readonly string LOG_10_3_SE;

	public static readonly string LOG_10_3;

	public static readonly string LOG_11_SE;

	public static readonly string LOG_11;

	public static readonly string LOG_12_SE;

	public static readonly string LOG_12;

	public static readonly string LOG_13_SE;

	public static readonly string LOG_13;

	public static readonly string LOG_14_SE;

	public static readonly string LOG_14;

	public static readonly string LOG_15_SE;

	public static readonly string LOG_15;

	public static readonly string LOG_16_SE;

	public static readonly string LOG_16;

	public static readonly string LOG_17_SE;

	public static readonly string LOG_17;

	public static readonly string LOG_18_SE;

	public static readonly string LOG_18;

	public static readonly string LOG_19_SE;

	public static readonly string LOG_19;

	public static readonly string LOG_20_SE;

	public static readonly string LOG_20;

	public static readonly string FIELD_ALL_ACCOUNTS_SE;

	public static readonly string FIELD_ALL_ACCOUNTS;

	public static readonly string FIELD_FA_SE;

	public static readonly string FIELD_FA;

	public static readonly string FIELD_NOTE_SE;

	public static readonly string FIELD_NOTE;

	public static readonly string FIELD_ADS_LIMIT_SE;

	public static readonly string FIELD_ADS_LIMIT;

	public static readonly string FIELD_ID_SE;

	public static readonly string FIELD_ID;

	public static readonly string GET_INVITES_SE;

	public static readonly string GET_INVITES;

	public static readonly string FIELD_DATA_SE;

	public static readonly string FIELD_DATA;

	public static readonly string PAGING_AFTER_SE;

	public static readonly string PAGING_AFTER;

	public static readonly string GPIJ_SE;

	public static readonly string GPIJ;

	public static readonly string CHECK_BM_LIMIT_SE;

	public static readonly string CHECK_BM_LIMIT;

	public static readonly string CHECK_BM_LIMIT_JOB_SE;

	public static readonly string CHECK_BM_LIMIT_JOB;

	public static readonly string FIELD_NAME_SE;

	public static readonly string FIELD_NAME;

	public static readonly string ACCESST_SE;

	public static readonly string ACCESST;

	public static readonly string ACT_SE;

	public static readonly string ACT;

	public static readonly string METHOD_RLI_SE;

	public static readonly string METHOD_RLI;

	public static readonly string METHOD_CLI_SE;

	public static readonly string METHOD_CLI;

	public static readonly string FIELD_MTB_LINK_SE;

	public static readonly string FIELD_MTB_LINK;

	public static readonly string FIELD_PENDING_INVITES_SE;

	public static readonly string FIELD_PENDING_INVITES;

	public static readonly string FIELD_DELETE_SE;

	public static readonly string FIELD_DELETE;

	public static readonly string FIELD_SENT_COUNT_SE;

	public static readonly string FIELD_SENT_COUNT;

	public static readonly string FIELD_EMAIL_SE;

	public static readonly string FIELD_EMAIL;

	public static readonly string FIELD_TYPE_SE;

	public static readonly string FIELD_TYPE;

	public static readonly string FIELD_TAG_SE;

	public static readonly string FIELD_TAG;

	public static readonly string ADMIN_SE;

	public static readonly string ADMIN;

	public static readonly string SHARE_LINK_SE;

	public static readonly string SHARE_LINK;

	public static readonly string SHARE_LINK_JOB_SE;

	public static readonly string SHARE_LINK_JOB;

	public static readonly string SHARE_ACC_STEP_SE;

	public static readonly string SHARE_ACC_STEP;

	public static readonly string SHARE_ACC_JOB_SE;

	public static readonly string SHARE_ACC_JOB;

	public static readonly string SHARE_LINK_ADMIN_SE;

	public static readonly string SHARE_LINK_ADMIN;

	public static readonly string SHARE_LINK_ADMIN_JOB_SE;

	public static readonly string SHARE_LINK_ADMIN_JOB;

	public static readonly string REQ_1_SE;

	public static readonly string REQ_1;

	public static readonly string REQ_1_2_SE;

	public static readonly string REQ_1_2;

	public static readonly string REQ_2_1_SE;

	public static readonly string REQ_2_1;

	public static readonly string SWA_SE;

	public static readonly string SWA;

	public static readonly string SNA_SE;

	public static readonly string SNA;

	public static readonly string FIELD_DESC_SE;

	public static readonly string FIELD_DESC;

	public static readonly string EMP_SE;

	public static readonly string EMP;

	public static readonly string NOACC_SE;

	public static readonly string NOACC;

	public static readonly string FA2_SE;

	public static readonly string FA2;

	public static readonly string NOACC_A_SE;

	public static readonly string NOACC_A;

	public static readonly string SS_SE;

	public static readonly string SS;

	private Logger log = Logger.Instance();

	private JobExecutor jobExecutor = new JobExecutor();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	public void Execute(SocialProfile profile)
	{
		LogContext logContext = ctx;
		string mETHOD_EXECUTE = METHOD_EXECUTE;
		if (6u != 0)
		{
			logContext.MethodName = mETHOD_EXECUTE;
		}
		if (profile == null || profile.SocialBusinesssResourceResult == null || profile.SocialBusinesssResourceResult.BusinessAccounts == null || profile.SocialBusinesssResourceResult.BusinessAccounts.Count == 0)
		{
			Logger logger = log;
			LogContext logContext2 = ctx;
			string lOG_ = LOG_1;
			if (0 == 0)
			{
				logger.Info(logContext2, lOG_);
			}
			return;
		}
		List<List<DynamicObject>>.Enumerator enumerator = ListUtils.to2DList((from item in profile.SocialBusinesssResourceResult.BusinessAccounts.AsEnumerable()
			where BAUtils.IsAdmin(item)
			orderby BAUtils.IsVerified(item) descending
			orderby item.GetArray(FIELD_ALL_ACCOUNTS).Count() descending
			select item).ToList(), 5).GetEnumerator();
		List<List<DynamicObject>>.Enumerator enumerator2;
		if (8u != 0)
		{
			enumerator2 = enumerator;
		}
		try
		{
			List<DynamicObject> list3 = default(List<DynamicObject>);
			while (enumerator2.MoveNext())
			{
				List<DynamicObject> current = enumerator2.Current;
				List<DynamicObject> list;
				if (3u != 0)
				{
					list = current;
				}
				if (3u != 0)
				{
					ResolveLimitInfo(profile, list);
				}
				List<DynamicObject>.Enumerator enumerator3 = list.GetEnumerator();
				List<DynamicObject>.Enumerator enumerator4;
				if (3u != 0)
				{
					enumerator4 = enumerator3;
				}
				try
				{
					while (enumerator4.MoveNext())
					{
						DynamicObject current2 = enumerator4.Current;
						DynamicObject dynamicObject;
						if (uint.MaxValue != 0)
						{
							dynamicObject = current2;
						}
						string fIELD_FA = FIELD_FA;
						object value = false;
						if (0 == 0)
						{
							dynamicObject.Put(fIELD_FA, value);
						}
						if (dynamicObject.GetInteger(FIELD_ADS_LIMIT) < 2 || !BAUtils.HasAccountActive(dynamicObject))
						{
							Logger logger2 = log;
							LogContext logContext3 = ctx;
							string message = LOG_2 + dynamicObject.GetString(FIELD_ID);
							if (0 == 0)
							{
								logger2.Info(logContext3, message);
							}
							continue;
						}
						Logger logger3 = log;
						LogContext logContext4 = ctx;
						string message2 = LOG_3 + dynamicObject.GetString(FIELD_ID) + " - " + dynamicObject.GetString(FIELD_NAME);
						if (0 == 0)
						{
							logger3.Info(logContext4, message2);
						}
						List<DynamicObject> array = dynamicObject.GetArray(FIELD_MTB_LINK);
						List<DynamicObject> list2;
						if (4u != 0)
						{
							list2 = array;
						}
						List<DynamicObject> pendingInvites = GetPendingInvites(profile, dynamicObject);
						if (0 == 0)
						{
							list3 = pendingInvites;
						}
						if (list3 == null)
						{
							continue;
						}
						dynamicObject.PutDynamicObjects(FIELD_PENDING_INVITES, list3);
						log.Info(ctx, FIELD_PENDING_INVITES + ": " + Converter.ConvertToString(list3));
						foreach (DynamicObject req in (from r in list2.AsEnumerable()
							where !r.GetBoolean(FIELD_DELETE)
							select r).ToList())
						{
							if (!list3.AsEnumerable().Any((DynamicObject p) => string.Equals(p.GetString(FIELD_EMAIL), req.GetString(FIELD_EMAIL))))
							{
								req.Put(FIELD_DELETE, true);
							}
							else
							{
								req.Put(FIELD_DELETE, false);
							}
						}
						dynamicObject.PutDynamicObjects(FIELD_MTB_LINK, list2);
						if (!profile.Live)
						{
							return;
						}
						List<DynamicObject> newList = ShareNV(profile, dynamicObject, withAcc: false, 1);
						BAUtils.MergeInviteRequest(list2, newList);
						if (dynamicObject.GetBoolean(FIELD_FA) || !profile.Live)
						{
							return;
						}
						Thread.Sleep(7000);
						List<DynamicObject> newList2 = ShareNV(profile, dynamicObject, withAcc: true, 1);
						BAUtils.MergeInviteRequest(list2, newList2);
						if (!profile.Live)
						{
							return;
						}
						Thread.Sleep(7000);
						List<DynamicObject> newList3 = ShareAdmin(profile, dynamicObject, 1);
						BAUtils.MergeInviteRequest(list2, newList3);
						dynamicObject.PutDynamicObjects(FIELD_MTB_LINK, list2);
						log.Info(ctx, LOG_4 + string.Join("\n", list2.AsEnumerable().Select(delegate(DynamicObject i)
						{
							string[] obj = new string[5]
							{
								i.GetString(FIELD_EMAIL),
								" - ",
								i.GetString(FIELD_TYPE),
								" - ",
								null
							};
							bool boolean = i.GetBoolean(FIELD_DELETE);
							bool flag = default(bool);
							if (3u != 0 && 0 == 0)
							{
								flag = boolean;
							}
							obj[4] = flag.ToString();
							return string.Concat(obj);
						}).ToList()));
						Thread.Sleep(TimeSpan.FromSeconds(30.0));
					}
				}
				finally
				{
					((IDisposable)enumerator4).Dispose();
				}
			}
		}
		finally
		{
			((IDisposable)enumerator2).Dispose();
		}
	}

	private List<DynamicObject> ShareAdmin(SocialProfile profile, DynamicObject bmItem, int amount)
	{
		_003C_003Ec__DisplayClass184_0 _003C_003Ec__DisplayClass184_ = new _003C_003Ec__DisplayClass184_0();
		_003C_003Ec__DisplayClass184_0 _003C_003Ec__DisplayClass184_2 = default(_003C_003Ec__DisplayClass184_0);
		if (0 == 0)
		{
			_003C_003Ec__DisplayClass184_2 = _003C_003Ec__DisplayClass184_;
		}
		_003C_003Ec__DisplayClass184_2._003C_003E4__this = this;
		List<string> list2 = default(List<string>);
		List<DynamicObject>.Enumerator enumerator2 = default(List<DynamicObject>.Enumerator);
		DynamicObject dynamicObject = default(DynamicObject);
		int num3 = default(int);
		List<DynamicObject> list5 = default(List<DynamicObject>);
		while (true)
		{
			_003C_003Ec__DisplayClass184_2.profile = profile;
			_003C_003Ec__DisplayClass184_2.bmItem = bmItem;
			if (!_003C_003Ec__DisplayClass184_2.profile.Live)
			{
				return null;
			}
			if (_003C_003Ec__DisplayClass184_2.bmItem.GetBoolean(FIELD_FA))
			{
				goto IL_0042;
			}
			if (false)
			{
				goto IL_031f;
			}
			int num;
			if (uint.MaxValue != 0)
			{
				num = 0;
			}
			List<DynamicObject> array = _003C_003Ec__DisplayClass184_2.bmItem.GetArray(FIELD_MTB_LINK);
			List<string> list = new List<string>();
			if (0 == 0)
			{
				list2 = list;
			}
			List<DynamicObject>.Enumerator enumerator = (from item in array.AsEnumerable()
				where !item.GetBoolean(FIELD_DELETE)
				select item).ToList().GetEnumerator();
			if (0 == 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					DynamicObject current = enumerator2.Current;
					if (0 == 0 && 0 == 0)
					{
						dynamicObject = current;
					}
					if (string.Equals(dynamicObject.GetString(FIELD_TYPE), ADMIN))
					{
						int num2 = num + 1;
						if (3u != 0 && 4u != 0)
						{
							num = num2;
						}
					}
					List<string> list3 = list2;
					string @string = dynamicObject.GetString(FIELD_EMAIL);
					if (true)
					{
						list3.Add(@string);
					}
				}
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			Logger logger = log;
			LogContext logContext = ctx;
			string message = LOG_5 + num;
			if (true)
			{
				logger.Info(logContext, message);
			}
			if (num >= amount)
			{
				break;
			}
			if (false)
			{
				continue;
			}
			if (0 == 0)
			{
				num3 = 0;
			}
			List<DynamicObject> list4 = new List<DynamicObject>();
			if (0 == 0)
			{
				list5 = list4;
			}
			goto IL_03d1;
			IL_031f:
			string text;
			ProfileUtils.GetEmails().Remove(text);
			goto IL_03d1;
			IL_03d1:
			while (true)
			{
				IL_03d1_2:
				int num4 = amount--;
				int num5 = 0;
				if (num5 == 0)
				{
					if (num4 <= num5)
					{
						goto IL_03e8;
					}
					num4 = num3;
					num5 = num4 + 1;
				}
				num3 = num5;
				if (num4 < 3)
				{
					_003C_003Ec__DisplayClass184_0 _003C_003Ec__DisplayClass184_3 = _003C_003Ec__DisplayClass184_2;
					bool needChangeNextMail = false;
					while (true)
					{
						text = ListUtils.Rand(ProfileUtils.GetEmails(), list2);
						log.Info(ctx, LOG_6 + text + LOG_6_2 + num);
						string string2 = _003C_003Ec__DisplayClass184_3.bmItem.GetString(FIELD_ID);
						Step step = new Step();
						step.Index = 0;
						step.Name = SHARE_LINK_ADMIN;
						step.Type = StepType.CURL;
						step.StopWhenSuccess = true;
						step.StopWhenFailed = true;
						step.CheckResultFunc = (string r) => _003C_003Ec__DisplayClass184_3._003C_003E4__this.CheckShareResultAdmin(_003C_003Ec__DisplayClass184_3.profile, _003C_003Ec__DisplayClass184_3.bmItem, r, ref needChangeNextMail);
						step.Spec = new CURLStepSpec
						{
							Url = BASE_URL + string2 + ENDPOINT_BUSINESS_USER + _003C_003Ec__DisplayClass184_3.profile.GetTokenForGotBusinessResources(),
							Headers = new string[2] { "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" },
							Method = HttpMethod.Post,
							RequestBody = REQ_1 + string2 + REQ_1_2 + WebUtility.UrlEncode(text) + BODY_SHARE_ADMIN,
							RestClient = _003C_003Ec__DisplayClass184_3.profile.RestClient
						};
						Step item2 = step;
						JobModel<string> jobModel = new JobModel<string>
						{
							Name = SHARE_LINK_ADMIN_JOB,
							Steps = new List<Step> { item2 },
							SuccessWhenAnyStepSuccess = true,
							ResultAtAnyLastStepSuccess = true
						};
						if (false)
						{
							break;
						}
						jobExecutor.Execute(jobModel);
						if (!needChangeNextMail)
						{
							if (!string.IsNullOrEmpty(jobModel.Result))
							{
								DynamicObject dynamicObject2 = new DynamicObject(new JObject());
								dynamicObject2.Put(FIELD_TYPE, ADMIN);
								dynamicObject2.Put(FIELD_EMAIL, text);
								dynamicObject2.Put(FIELD_DELETE, false);
								dynamicObject2.Put(FIELD_SENT_COUNT, 0);
								list5.Add(dynamicObject2);
								goto IL_03d1_2;
							}
							log.Info(ctx, LOG_7_1);
							if (0 == 0)
							{
								if (!_003C_003Ec__DisplayClass184_3.profile.Live)
								{
									if (0 == 0)
									{
										return list5;
									}
									continue;
								}
								goto IL_03d1_2;
							}
						}
						goto IL_031a;
					}
					break;
				}
				goto IL_03e8;
				IL_03e8:
				log.Info(ctx, LOG_8_1 + string.Join("; ", (from i in list5.AsEnumerable()
					select i.GetString(FIELD_EMAIL) + " - " + i.GetString(FIELD_TYPE) + i.GetString(FIELD_TAG)).ToList()));
				return list5;
			}
			goto IL_0042;
			IL_031a:
			amount++;
			goto IL_031f;
			IL_0042:
			return null;
		}
		return new List<DynamicObject>();
	}

	private List<DynamicObject> ShareNV(SocialProfile profile, DynamicObject bmItem, bool withAcc, int amount)
	{
		if (4u != 0)
		{
		}
		BusinessShareLinkJob businessShareLinkJob = this;
		DynamicObject bmItem2;
		do
		{
			SocialProfile profile2 = profile;
			bmItem2 = bmItem;
		}
		while (-1 == 0);
		string obj = (withAcc ? SWA : SNA);
		string text;
		if (8u != 0)
		{
			text = obj;
		}
		int num = default(int);
		if (0 == 0)
		{
			num = 0;
			if (false)
			{
				goto IL_079c;
			}
		}
		List<DynamicObject> array = bmItem2.GetArray(FIELD_MTB_LINK);
		List<string> list = new List<string>();
		List<string> list2 = default(List<string>);
		if (0 == 0)
		{
			list2 = list;
		}
		List<DynamicObject>.Enumerator enumerator = (from item in array.AsEnumerable()
			where !item.GetBoolean(FIELD_DELETE)
			select item).ToList().GetEnumerator();
		List<DynamicObject>.Enumerator enumerator2;
		if (2u != 0)
		{
			enumerator2 = enumerator;
		}
		try
		{
			DynamicObject dynamicObject = default(DynamicObject);
			while (enumerator2.MoveNext())
			{
				DynamicObject current = enumerator2.Current;
				if (0 == 0 && 0 == 0)
				{
					dynamicObject = current;
				}
				if (string.Equals(dynamicObject.GetString(FIELD_TAG), text))
				{
					int num2 = num + 1;
					if (0 == 0)
					{
						num = num2;
					}
				}
				List<string> list3 = list2;
				string @string = dynamicObject.GetString(FIELD_EMAIL);
				if (4u != 0)
				{
					list3.Add(@string);
				}
			}
		}
		finally
		{
			((IDisposable)enumerator2).Dispose();
		}
		Logger logger = log;
		LogContext logContext = ctx;
		string message = LOG_9_1 + text + LOG_9_2 + num;
		if (4u != 0)
		{
			logger.Info(logContext, message);
		}
		if (num >= amount)
		{
			return new List<DynamicObject>();
		}
		int num3 = default(int);
		if (0 == 0)
		{
			num3 = 0;
		}
		List<DynamicObject> list4 = new List<DynamicObject>();
		List<DynamicObject> list5;
		if (4u != 0)
		{
			list5 = list4;
		}
		goto IL_079c;
		IL_079c:
		while (amount-- > 0 && num3++ < 3)
		{
			object obj2;
			_003C_003Ec__DisplayClass185_0 _003C_003Ec__DisplayClass185_ = (_003C_003Ec__DisplayClass185_0)obj2;
			bool needChangeNextMail = false;
			string text2 = ListUtils.Rand(ProfileUtils.GetEmails(), list2);
			log.Info(ctx, LOG_10_1 + text + LOG_10_2 + text2 + LOG_10_3 + num);
			if (string.IsNullOrEmpty(text2))
			{
				break;
			}
			string string2 = _003C_003Ec__DisplayClass185_.bmItem.GetString(FIELD_ID);
			Step step = new Step();
			step.Index = 0;
			step.Name = SHARE_LINK;
			step.Type = StepType.CURL;
			step.StopWhenSuccess = true;
			step.StopWhenFailed = true;
			step.CheckResultFunc = (string r) => _003C_003Ec__DisplayClass185_._003C_003E4__this.CheckShareResult(_003C_003Ec__DisplayClass185_.profile, _003C_003Ec__DisplayClass185_.bmItem, r, ref needChangeNextMail);
			step.Spec = new CURLStepSpec
			{
				Url = BASE_URL + string2 + ENDPOINT_BUSINESS_USER + _003C_003Ec__DisplayClass185_.profile.GetTokenForGotBusinessResources(),
				Headers = new string[2] { "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" },
				Method = HttpMethod.Post,
				RequestBody = BODY_SHARE_EMPLOYEE_1 + string2 + REQ_1_2 + WebUtility.UrlEncode(text2) + BODY_SHARE_EMPLOYEE_2 + WebUtility.UrlEncode(BODY_SHARE_EMPLOYEE_3) + BODY_SHARE_EMPLOYEE_4,
				RestClient = _003C_003Ec__DisplayClass185_.profile.RestClient
			};
			Step item2 = step;
			JobModel<string> jobModel = new JobModel<string>
			{
				Name = SHARE_LINK_JOB,
				Steps = new List<Step> { item2 },
				SuccessWhenAnyStepSuccess = true,
				ResultAtAnyLastStepSuccess = true
			};
			jobExecutor.Execute(jobModel);
			if (needChangeNextMail)
			{
				amount++;
				ProfileUtils.GetEmails().Remove(text2);
				continue;
			}
			DynamicObject dynamicObject4;
			if (8u != 0)
			{
				if (string.IsNullOrEmpty(jobModel.Result))
				{
					log.Info(ctx, LOG_11);
					return list5;
				}
				if (!withAcc)
				{
					DynamicObject dynamicObject2 = new DynamicObject(new JObject());
					dynamicObject2.Put(FIELD_TYPE, EMP);
					dynamicObject2.Put(FIELD_EMAIL, text2);
					dynamicObject2.Put(FIELD_TAG, text);
					dynamicObject2.Put(FIELD_DELETE, false);
					dynamicObject2.Put(FIELD_SENT_COUNT, 0);
					dynamicObject2.Put(FIELD_DESC, NOACC);
					list5.Add(dynamicObject2);
					continue;
				}
				string result = jobModel.Result;
				List<DynamicObject> list6 = (from item in _003C_003Ec__DisplayClass185_.bmItem.GetArray(FIELD_ALL_ACCOUNTS).AsEnumerable()
					where BAUtils.IsAccountActive(item)
					select item into a
					orderby Guid.NewGuid()
					select a).Take(20).ToList();
				if (list6.Count == 0)
				{
					log.Info(ctx, LOG_12);
					DynamicObject dynamicObject3 = new DynamicObject(new JObject());
					dynamicObject3.Put(FIELD_TYPE, EMP);
					dynamicObject3.Put(FIELD_EMAIL, text2);
					dynamicObject3.Put(FIELD_TAG, text);
					dynamicObject3.Put(FIELD_DELETE, false);
					dynamicObject3.Put(FIELD_SENT_COUNT, 0);
					dynamicObject3.Put(FIELD_DESC, NOACC_A);
					list5.Add(dynamicObject3);
					continue;
				}
				log.Info(ctx, LOG_13 + string.Join("; ", (from item in list6.AsEnumerable()
					select item.GetString(FIELD_ID) + " - " + item.GetString(FIELD_NAME)).ToList()));
				step = new Step();
				step.Index = 0;
				step.Name = SHARE_ACC_STEP;
				step.Type = StepType.CURL;
				step.StopWhenSuccess = true;
				step.StopWhenFailed = true;
				step.CheckResultFunc = (string r) => _003C_003Ec__DisplayClass185_._003C_003E4__this.CheckResultShareAcc(r);
				step.Spec = new CURLStepSpec
				{
					Url = URL_UPDATE_PERMISSION,
					Headers = new string[3] { "Sec-Fetch-Dest: empty", "Sec-Fetch-Mode: cors", "Sec-Fetch-Site: same-origin" },
					Method = HttpMethod.Post,
					RequestBody = CreateAssetParam(list6) + BODY_UPDATE_PERMISSION_1 + _003C_003Ec__DisplayClass185_.bmItem.GetString(FIELD_ID) + BODY_UPDATE_PERMISSION_2 + result + BODY_UPDATE_PERMISSION_3 + _003C_003Ec__DisplayClass185_.profile.UserId + BODY_UPDATE_PERMISSION_4 + _003C_003Ec__DisplayClass185_.profile.Dtsg + BODY_UPDATE_PERMISSION_5,
					RestClient = _003C_003Ec__DisplayClass185_.profile.RestClient
				};
				Step item3 = step;
				JobModel<bool> jobModel2 = new JobModel<bool>
				{
					Name = SHARE_ACC_JOB,
					Steps = new List<Step> { item3 },
					SuccessWhenAnyStepSuccess = true,
					ResultAtAnyLastStepSuccess = true
				};
				jobExecutor.Execute(jobModel2);
				log.Info(ctx, LOG_14 + jobModel2.Result);
				dynamicObject4 = new DynamicObject(new JObject());
				dynamicObject4.Put(FIELD_TYPE, EMP);
				dynamicObject4.Put(FIELD_EMAIL, text2);
				dynamicObject4.Put(FIELD_TAG, text);
				dynamicObject4.Put(FIELD_DELETE, false);
				dynamicObject4.Put(FIELD_SENT_COUNT, 0);
			}
			list5.Add(dynamicObject4);
		}
		log.Info(ctx, LOG_15 + string.Join("; ", (from i in list5.AsEnumerable()
			select i.GetString(FIELD_EMAIL) + " - " + i.GetString(FIELD_TYPE) + i.GetString(FIELD_TAG)).ToList()));
		return list5;
	}

	private StepResult CheckResultShareAcc(string response)
	{
		int num;
		int num2;
		while (true)
		{
			if (0 == 0)
			{
				num = (string.IsNullOrEmpty(response) ? 1 : 0);
				while (true)
				{
					if (num == 0)
					{
						if (7 == 0)
						{
							break;
						}
						if (response.Contains(SS))
						{
							goto IL_001b;
						}
					}
					Logger logger = log;
					LogContext logContext = ctx;
					string lOG_ = LOG_17;
					if (0 == 0 && 0 == 0)
					{
						logger.Info(logContext, lOG_);
					}
					num = 0;
					if (num != 0)
					{
						continue;
					}
					goto IL_005a;
				}
				continue;
			}
			goto IL_001b;
			IL_001b:
			Logger logger2 = log;
			LogContext logContext2 = ctx;
			string lOG_2 = LOG_16;
			if ((5u != 0) ? true : false)
			{
				logger2.Info(logContext2, lOG_2);
			}
			num = 1;
			num2 = 1;
			goto IL_0034;
			IL_0034:
			return StepResult.Of((byte)num != 0, (byte)num2 != 0);
			IL_005a:
			num2 = 0;
			if (num2 == 0)
			{
				break;
			}
			goto IL_0034;
		}
		return StepResult.Of((byte)num != 0, (byte)num2 != 0);
	}

	private string CreateAssetParam(List<DynamicObject> allAccounts)
	{
		StringBuilder stringBuilder2;
		List<DynamicObject>.Enumerator enumerator2 = default(List<DynamicObject>.Enumerator);
		string text = default(string);
		do
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (7u != 0 && 8u != 0)
			{
				stringBuilder2 = stringBuilder;
			}
			int num;
			if (5u != 0 && 5u != 0)
			{
				num = 0;
			}
			List<DynamicObject>.Enumerator enumerator = allAccounts.GetEnumerator();
			if (0 == 0 && 0 == 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (true)
				{
					IL_0075:
					bool num2 = enumerator2.MoveNext();
					while (num2)
					{
						string @string = enumerator2.Current.GetString(FIELD_ID);
						if (uint.MaxValue != 0 && 0 == 0)
						{
							text = @string;
						}
						num2 = text.StartsWith(ACT);
						if (false)
						{
							continue;
						}
						if (num2)
						{
							string text2 = text.Substring(4);
							if (0 == 0 && 6u != 0)
							{
								text = text2;
							}
						}
						if (7u != 0)
						{
							string aSSET_PARAM = ASSET_PARAM;
							int num3 = num;
							int num4 = num3 + 1;
							if (0 == 0 && 8u != 0)
							{
								num = num4;
							}
							stringBuilder2.Append(string.Format(aSSET_PARAM, num3, text));
						}
						goto IL_0075;
					}
					break;
				}
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
		}
		while (false);
		return stringBuilder2.ToString();
	}

	private StepResult CheckShareResultAdmin(SocialProfile profile, DynamicObject bmObj, string response, ref bool needChangeNextMail)
	{
		Logger logger = log;
		LogContext logContext = ctx;
		string message = LOG_18 + response;
		if (8u != 0 && 0 == 0)
		{
			logger.Info(logContext, message);
		}
		if (response.Contains(RESPONSE_CAN_NOT_ACCESS_BECAUSE_LOGOUT) || response.Contains(RESPONSE_CAN_NOT_ACCESS_BECAUSE_LOGOUT_2))
		{
			if (0 == 0 && 5u != 0)
			{
				profile.Live = false;
			}
			return StepResult.Of(success: false, "");
		}
		if (response.Contains(RESPONSE_2FA_REQUIRED))
		{
			string fIELD_FA = FIELD_FA;
			object value = true;
			if (4u != 0 && 0 == 0)
			{
				bmObj.Put(fIELD_FA, value);
			}
			string fIELD_NOTE = FIELD_NOTE;
			string fA = FA2;
			if (7u != 0 && 3u != 0)
			{
				bmObj.Put(fIELD_NOTE, fA);
			}
			return StepResult.Of(success: false, "");
		}
		if (response.Contains(RESPONSE_TOO_MANY_INVITE))
		{
			needChangeNextMail = true;
			return StepResult.Of(success: false, "");
		}
		string fIELD_FA2 = FIELD_FA;
		object value2 = false;
		if (4u != 0 && 6u != 0)
		{
			bmObj.Put(fIELD_FA2, value2);
		}
		JObject jObject2 = default(JObject);
		do
		{
			JObject? jObject = JsonConvert.DeserializeObject<JObject>(response);
			if (0 == 0 && 0 == 0)
			{
				jObject2 = jObject;
			}
			if (!jObject2.ContainsKey(FIELD_ID))
			{
				return StepResult.Of(success: false, false);
			}
		}
		while (false);
		return StepResult.Of(success: true, jObject2.GetValue(FIELD_ID).ToObject<string>());
	}

	private StepResult CheckShareResult(SocialProfile profile, DynamicObject bmObj, string response, ref bool needChangeNextMail)
	{
		Logger logger = log;
		LogContext logContext = ctx;
		string message = LOG_18 + response;
		if (0 == 0 && 3u != 0)
		{
			logger.Info(logContext, message);
		}
		if (response.Contains(RESPONSE_CAN_NOT_ACCESS_BECAUSE_LOGOUT))
		{
			if (0 == 0)
			{
				if (4u != 0)
				{
					profile.Live = false;
				}
				if (false)
				{
					goto IL_0079;
				}
			}
			return StepResult.Of(success: false, "");
		}
		if (response.Contains(RESPONSE_2FA_REQUIRED))
		{
			string fIELD_FA = FIELD_FA;
			object value = true;
			if (3u != 0 && 0 == 0)
			{
				bmObj.Put(fIELD_FA, value);
			}
			string fIELD_NOTE = FIELD_NOTE;
			string fA = FA2;
			if (0 == 0 && 3u != 0)
			{
				bmObj.Put(fIELD_NOTE, fA);
			}
			goto IL_0079;
		}
		int num;
		if (response.Contains(RESPONSE_TOO_MANY_INVITE))
		{
			needChangeNextMail = true;
			num = 0;
		}
		else
		{
			string fIELD_FA2 = FIELD_FA;
			object value2 = false;
			if (0 == 0 && 0 == 0)
			{
				bmObj.Put(fIELD_FA2, value2);
			}
			JObject? jObject = JsonConvert.DeserializeObject<JObject>(response);
			JObject jObject2 = default(JObject);
			if (0 == 0 && 8u != 0)
			{
				jObject2 = jObject;
			}
			num = (jObject2.ContainsKey(FIELD_ID) ? 1 : 0);
			if (0 == 0)
			{
				if (num == 0)
				{
					return StepResult.Of(success: false, false);
				}
				return StepResult.Of(success: true, jObject2.GetValue(FIELD_ID).ToObject<string>());
			}
		}
		return StepResult.Of((byte)num != 0, "");
		IL_0079:
		return StepResult.Of(success: false, "");
	}

	private List<DynamicObject> GetPendingInvites(SocialProfile profile, DynamicObject bmItem)
	{
		_003C_003Ec__DisplayClass190_0 _003C_003Ec__DisplayClass190_ = new _003C_003Ec__DisplayClass190_0();
		_003C_003Ec__DisplayClass190_0 _003C_003Ec__DisplayClass190_2 = default(_003C_003Ec__DisplayClass190_0);
		if (0 == 0)
		{
			_003C_003Ec__DisplayClass190_2 = _003C_003Ec__DisplayClass190_;
		}
		List<DynamicObject> list2 = default(List<DynamicObject>);
		do
		{
			_003C_003Ec__DisplayClass190_2._003C_003E4__this = this;
			List<DynamicObject> list = new List<DynamicObject>();
			if (0 == 0)
			{
				list2 = list;
			}
		}
		while (5 == 0);
		_003C_003Ec__DisplayClass190_2.nextToken = "";
		int num;
		if (4u != 0)
		{
			num = 0;
		}
		try
		{
			Step step2 = default(Step);
			CURLStepSpec cURLStepSpec2 = default(CURLStepSpec);
			while (true)
			{
				JobModel<List<DynamicObject>> jobModel;
				if (4u != 0)
				{
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
					string gET_INVITES = GET_INVITES;
					if (0 == 0)
					{
						step4.Name = gET_INVITES;
					}
					Step step5 = step2;
					if (0 == 0)
					{
						step5.Type = StepType.CURL;
					}
					Step item;
					do
					{
						Step step6 = step2;
						if (0 == 0)
						{
							step6.StopWhenSuccess = true;
						}
						Step step7 = step2;
						if (3u != 0)
						{
							step7.StopWhenFailed = true;
						}
						Step step8 = step2;
						Func<string, StepResult> checkResultFunc = _003C_003Ec__DisplayClass190_2._003CGetPendingInvites_003Eb__0;
						if (uint.MaxValue != 0)
						{
							step8.CheckResultFunc = checkResultFunc;
						}
						Step step9 = step2;
						CURLStepSpec cURLStepSpec = new CURLStepSpec();
						if (0 == 0)
						{
							cURLStepSpec2 = cURLStepSpec;
						}
						CURLStepSpec cURLStepSpec3 = cURLStepSpec2;
						string url = BASE_URL + bmItem.GetString(FIELD_ID) + (string.IsNullOrEmpty(_003C_003Ec__DisplayClass190_2.nextToken) ? ENDPOINT_PENDING_USER_1 : (ENDPOINT_PENDING_USER_2 + _003C_003Ec__DisplayClass190_2.nextToken + ACCESST)) + profile.GetTokenForGotBusinessResources();
						if (2u != 0)
						{
							cURLStepSpec3.Url = url;
						}
						cURLStepSpec2.Headers = new string[2] { "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" };
						cURLStepSpec2.RestClient = profile.RestClient;
						step9.Spec = cURLStepSpec2;
						item = step2;
					}
					while (false);
					jobModel = new JobModel<List<DynamicObject>>
					{
						Name = GPIJ,
						Steps = new List<Step> { item },
						SuccessWhenAnyStepSuccess = true,
						ResultAtAnyLastStepSuccess = true
					};
					jobExecutor.Execute(jobModel);
				}
				int num2;
				if (jobModel.Result != null)
				{
					num2 = jobModel.Result.Count;
					if (false)
					{
						goto IL_01b8;
					}
					if (num2 > 0)
					{
						list2.AddRange(jobModel.Result);
					}
				}
				num2 = (string.IsNullOrEmpty(_003C_003Ec__DisplayClass190_2.nextToken) ? 1 : 0);
				goto IL_01b8;
				IL_01b8:
				if (num2 == 0)
				{
					if (num++ >= 5)
					{
						return list2;
					}
					continue;
				}
				break;
			}
			return list2;
		}
		catch (Exception ex)
		{
			log.Error(ctx, ex.ToString());
			return null;
		}
	}

	private StepResult GetPendingInviteList(string response, ref string nextToken)
	{
		DynamicObject dynamicObject = new DynamicObject(JsonConvert.DeserializeObject<JObject>(response));
		DynamicObject dynamicObject2 = default(DynamicObject);
		if (0 == 0 && 2u != 0)
		{
			dynamicObject2 = dynamicObject;
		}
		int num = (dynamicObject2.Contains(FIELD_DATA) ? 1 : 0);
		List<DynamicObject> list = default(List<DynamicObject>);
		while (true)
		{
			if (4 == 0)
			{
				goto IL_0042;
			}
			if (0 == 0)
			{
				if (num != 0)
				{
					List<DynamicObject> array = dynamicObject2.GetArray(FIELD_DATA);
					if (true && 0 == 0)
					{
						list = array;
					}
					if (uint.MaxValue != 0)
					{
						num = list.Count;
						goto IL_0042;
					}
				}
				return StepResult.Of(success: false, null);
			}
			goto IL_0063;
			IL_0063:
			if (0 == 0)
			{
				if (num == 0)
				{
					nextToken = dynamicObject2.GetString(PAGING_AFTER);
				}
				break;
			}
			continue;
			IL_0042:
			if (num == 25)
			{
				if (!dynamicObject2.Contains(PAGING_AFTER))
				{
					break;
				}
				num = (string.IsNullOrEmpty(dynamicObject2.GetString(PAGING_AFTER)) ? 1 : 0);
				goto IL_0063;
			}
			nextToken = "";
			break;
		}
		return StepResult.Of(success: true, list);
	}

	private void ResolveLimitInfo(SocialProfile profile, List<DynamicObject> businessAccounts)
	{
		string text;
		if (2u != 0)
		{
			string methodName = ctx.MethodName;
			if (true && uint.MaxValue != 0)
			{
				text = methodName;
			}
			LogContext logContext = ctx;
			string mETHOD_RLI = METHOD_RLI;
			if (4u != 0)
			{
				logContext.MethodName = mETHOD_RLI;
			}
		}
		if (1 == 0 || 0 == 0)
		{
			List<DynamicObject>.Enumerator enumerator = businessAccounts.GetEnumerator();
			List<DynamicObject>.Enumerator enumerator2 = default(List<DynamicObject>.Enumerator);
			if (0 == 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				if (0 == 0)
				{
				}
				DynamicObject dynamicObject = default(DynamicObject);
				while (enumerator2.MoveNext())
				{
					DynamicObject current = enumerator2.Current;
					if (0 == 0 && 3u != 0)
					{
						dynamicObject = current;
					}
					if (dynamicObject.GetInteger(FIELD_ADS_LIMIT) <= 0)
					{
						Logger logger = log;
						LogContext logContext2 = ctx;
						string message = LOG_19 + dynamicObject.GetString(FIELD_ID);
						if (3u != 0 && 6u != 0)
						{
							logger.Info(logContext2, message);
						}
						DynamicObject bmItem = dynamicObject;
						if (0 == 0 && 0 == 0)
						{
							CheckLimitItem(profile, bmItem);
						}
						TimeSpan timeout = TimeSpan.FromSeconds(10.0);
						if (0 == 0)
						{
							Thread.Sleep(timeout);
						}
					}
				}
			}
			finally
			{
				do
				{
					((IDisposable)enumerator2).Dispose();
				}
				while (false);
			}
		}
		LogContext logContext3 = ctx;
		string methodName2 = text;
		if (8u != 0)
		{
			logContext3.MethodName = methodName2;
		}
	}

	private void CheckLimitItem(SocialProfile profile, DynamicObject bmItem)
	{
		string methodName = ctx.MethodName;
		string methodName2;
		if (true)
		{
			methodName2 = methodName;
		}
		LogContext logContext = ctx;
		string mETHOD_CLI = METHOD_CLI;
		if (0 == 0)
		{
			logContext.MethodName = mETHOD_CLI;
		}
		try
		{
			Step step2;
			if (5u != 0)
			{
				Step step = new Step();
				if (2u != 0)
				{
					step2 = step;
				}
				goto IL_0037;
			}
			goto IL_0041;
			IL_0041:
			Step step3 = step2;
			string cHECK_BM_LIMIT = CHECK_BM_LIMIT;
			if (0 == 0)
			{
				step3.Name = cHECK_BM_LIMIT;
			}
			Step step4 = step2;
			if (true)
			{
				step4.Type = StepType.CURL;
			}
			Step step5 = step2;
			if (0 == 0)
			{
				step5.StopWhenSuccess = true;
			}
			Step step6 = step2;
			if (0 == 0)
			{
				step6.StopWhenFailed = true;
			}
			Step step7 = step2;
			Func<string, StepResult> checkResultFunc = (string r) => GetLimitInfoFunc(r);
			if (0 == 0)
			{
				step7.CheckResultFunc = checkResultFunc;
			}
			Step step8 = step2;
			CURLStepSpec cURLStepSpec = new CURLStepSpec();
			CURLStepSpec cURLStepSpec2;
			if (6u != 0)
			{
				cURLStepSpec2 = cURLStepSpec;
			}
			string url = URL_ACCOUNT_LIMIT + bmItem.GetString(FIELD_ID);
			if (0 == 0)
			{
				cURLStepSpec2.Url = url;
			}
			string[] headers = new string[4] { "Sec-Fetch-Site: same-origin", "Sec-Fetch-Mode: cors", "Sec-Fetch-Dest: empty", "Content-Type: application/x-www-form-urlencoded" };
			if (3u != 0)
			{
				cURLStepSpec2.Headers = headers;
			}
			cURLStepSpec2.Method = HttpMethod.Post;
			cURLStepSpec2.RequestBody = REQ_2_1 + profile.UserId + BODY_ACCOUNT_LIMIT + profile.Dtsg;
			cURLStepSpec2.RestClient = profile.RestClient;
			step8.Spec = cURLStepSpec2;
			Step item = step2;
			if (4 == 0)
			{
				goto IL_0037;
			}
			JobModel<int> jobModel = new JobModel<int>
			{
				Name = CHECK_BM_LIMIT_JOB,
				Steps = new List<Step> { item },
				SuccessWhenAnyStepSuccess = true,
				ResultAtAnyLastStepSuccess = true
			};
			jobExecutor.Execute(jobModel);
			bmItem.Put(FIELD_ADS_LIMIT, jobModel.Result);
			goto end_IL_0025;
			IL_0037:
			Step step9 = step2;
			if (6u != 0)
			{
				step9.Index = 0;
			}
			goto IL_0041;
			end_IL_0025:;
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
		string message = LOG_20 + text2;
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

	static BusinessShareLinkJob()
	{
		while (true)
		{
			BASE_URL_SE = "oXTjB3WJ+ZaSCT2qvi7Dlw==./iOpDjVqc78ryVT66RAamtJzNGnTWZFkAZWcne8hiUMyBUxX92oXlNyGfkHQC12oHjbVfXN3ibIFyQsw0LGusA==";
			while (true)
			{
				BASE_URL = SecurityUtils.ReadStructEncrypted(BASE_URL_SE);
				ENDPOINT_BUSINESS_USER_SE = "l12Pp1Qr0v6ENSV6vYyN5g==.lZ9YVFCmBgw1VxSONVWVYYGFZpjZkuYh18xay1dQLz9s+xNxPikqCi0R+4CmxO+X";
				ENDPOINT_BUSINESS_USER = SecurityUtils.ReadStructEncrypted(ENDPOINT_BUSINESS_USER_SE);
				BODY_SHARE_ADMIN_SE = "KWmGgxR/caianrHZ8fqpvg==.UoNP2TKUozrgyPeqmzy+fyUQGl3+HR8pP2f7+m1H8oi1jOrXCjQKvhq/0sLbn/on5iek7eDxda3kUN+LhXmpEx4OTvKYIu5RdlWojHGh63gBdLgu6EP8jX4ZjPPZYLcYjiMEepOfDaIqLbueHKq0Ww==";
				BODY_SHARE_ADMIN = SecurityUtils.ReadStructEncrypted(BODY_SHARE_ADMIN_SE);
				BODY_SHARE_EMPLOYEE_1_SE = "deKV7j9XIxsP4OIOmAwdZQ==.K8hpOiKEF+ww3tvm5icr9fkhvDgpnshuHZp2cJIixmhh403DAB9l0W5IzWJdh+GAnF274v3/FUUkNCJQIvWrCCU0KE81EzgchCN/FaG0KeM/OrWDNDUkjk8PC6Z7sgRrwH7aJcaXuiTpuAduZfPiNg==";
				BODY_SHARE_EMPLOYEE_1 = SecurityUtils.ReadStructEncrypted(BODY_SHARE_EMPLOYEE_1_SE);
				BODY_SHARE_EMPLOYEE_2_SE = "wAZEGcmAM142j9LKhrTBDw==.CDIK9Q77JiZlTCHoB42mOw6Mgcn6uisA2LRutEf5G6C66AEUyqRBZ9q73ATgK6sX";
				BODY_SHARE_EMPLOYEE_2 = SecurityUtils.ReadStructEncrypted(BODY_SHARE_EMPLOYEE_2_SE);
				do
				{
					BODY_SHARE_EMPLOYEE_3_SE = "HYeI240Abqzfor+0buQngQ==.eq9F8WetuSAuhNH++LAkVX040nvxDuc74F6KB31BZeBxnHDi+gS7t7V7eBFTvMmYPVFdhLVkAJoNBf0cbso5iNgK6zIz+s3wOfK/fmcBJHv0AlaRObczju7cGYpRwYjr5si5FMPUlmJDQjJwYJjO3g==";
					BODY_SHARE_EMPLOYEE_3 = SecurityUtils.ReadStructEncrypted(BODY_SHARE_EMPLOYEE_3_SE);
					BODY_SHARE_EMPLOYEE_4_SE = "e/AdvjASPPgiQVPrMwryzw==.i0PFSAC3NL00ZLasfmpEhQ12UQuH4xO4Gzm9wTU9YCdT3SO+ll2H5nBRvbiYwl9r";
					BODY_SHARE_EMPLOYEE_4 = SecurityUtils.ReadStructEncrypted(BODY_SHARE_EMPLOYEE_4_SE);
					URL_UPDATE_PERMISSION_SE = "gQjYc3tfX/gEALZITtiv3g==.7kmVvrjBGya2eKF+WLAonSEERjdjn7OE76/8FDX1Gw2YYfo6r1q66x+lRGIU/qMe80UOTf7qWgzyg9IIsN04FiYEftx8ihNSUPVLjn8GvL3d8SxMOYT5c8YIl9+QBPXn";
					URL_UPDATE_PERMISSION = SecurityUtils.ReadStructEncrypted(URL_UPDATE_PERMISSION_SE);
					BODY_UPDATE_PERMISSION_1_SE = "9gcNgMB7CHFgi3u0hDm+dQ==.njxMpvuCZatFk7nEEXFFENwFnse0ljZnxRuCA3RxKLy6GA1JYbvnVhqxTWRXePhtQq2vc4TPv+vIIbExcHfyfQ==";
					BODY_UPDATE_PERMISSION_1 = SecurityUtils.ReadStructEncrypted(BODY_UPDATE_PERMISSION_1_SE);
					BODY_UPDATE_PERMISSION_2_SE = "CDl0khuFmP24f4VD0C/Ebw==.Cg9Y+TbR6vMG9DXMonG1JXEsnw9866qLzw2298CTlvBnaHwO2Tpdju56JeYPiV8m";
					BODY_UPDATE_PERMISSION_2 = SecurityUtils.ReadStructEncrypted(BODY_UPDATE_PERMISSION_2_SE);
					BODY_UPDATE_PERMISSION_3_SE = "trcPwWJrgMGtdM7Ol/wmWg==.hjn+i3Td1MQlVIRTKOxlBEu5m4e0N2xScPEhOO4OpC5C0+tcqakzKIof5qb0yv9ZNvd8KPqCIZvLVKABZnxgFYcoqwMzbrNhzNMATQ/PVspHEtY0aQNnuRRs+k6g1MHr7FCRs0ERGbLkOafUfANGa2sLIECKcTI2RFMKyo1wq+O7z/GJLOXyLrMb2es0XSY2";
					BODY_UPDATE_PERMISSION_3 = SecurityUtils.ReadStructEncrypted(BODY_UPDATE_PERMISSION_3_SE);
					BODY_UPDATE_PERMISSION_4_SE = "FphDepZ6/eHw8Arjx5dyBg==.UHba9iCyiYQpRwTCdKo1iEONr49veG/hRfhvgzI1Ae0=";
					BODY_UPDATE_PERMISSION_4 = SecurityUtils.ReadStructEncrypted(BODY_UPDATE_PERMISSION_4_SE);
				}
				while (2 == 0);
				BODY_UPDATE_PERMISSION_5_SE = "j1F8dv0IuqvNn+LBCRKm6Q==.oJbgHwetCPYXuVo+r1CYgX5FtefrKbzdkA+25f2GPO4=";
				if (7 == 0)
				{
					break;
				}
				BODY_UPDATE_PERMISSION_5 = SecurityUtils.ReadStructEncrypted(BODY_UPDATE_PERMISSION_5_SE);
				ASSET_PARAM_SE = "O7+UGkWPheJ5RIyfuacjpg==.nxIBFXjmnJLDM1B8NUJ5LILU51BB4boLjBk2l2oIwjCUD2zgwsyR0xPzGdgSGZp1";
				ASSET_PARAM = SecurityUtils.ReadStructEncrypted(ASSET_PARAM_SE);
				RESPONSE_CAN_NOT_ACCESS_BECAUSE_LOGOUT_SE = "uVCVWnuACXvAxna6dA2lyw==.XqERLrm1hC5HVblVe5nMA82gDaFbY2sNlb0tSxSKecANvfgt2tbybRucn7TA6vx2b5CbGZRT5mbK92A55nRaRw==";
				RESPONSE_CAN_NOT_ACCESS_BECAUSE_LOGOUT = SecurityUtils.ReadStructEncrypted(RESPONSE_CAN_NOT_ACCESS_BECAUSE_LOGOUT_SE);
				RESPONSE_CAN_NOT_ACCESS_BECAUSE_LOGOUT_2_SE = "wqpaC2wU7Fv6umneWfv+dw==.VVMaiacAUDixuntFShm5xBQHF1vQKYakfPhaP7j4h05z8SFmiB2E9pMrKk6T/F4f";
				RESPONSE_CAN_NOT_ACCESS_BECAUSE_LOGOUT_2 = SecurityUtils.ReadStructEncrypted(RESPONSE_CAN_NOT_ACCESS_BECAUSE_LOGOUT_2_SE);
				RESPONSE_2FA_REQUIRED_SE = "qVbcffvAKAnZz5TbJfysGg==.0fzrkj9++HXlSi87eQ57pIiW7rBDgbcYR6mnjvI/qA6C2Byg1XyD9DvyDUj+QYaK685sG8NRbMLtsUGKr7tV8w==";
				RESPONSE_2FA_REQUIRED = SecurityUtils.ReadStructEncrypted(RESPONSE_2FA_REQUIRED_SE);
				RESPONSE_TOO_MANY_INVITE_SE = "PeQeq1W4YKHzoX2pr0WGGw==.kN7lQHhN/Ox743uEQ6a2wzANkoT5eZAjkGmXLUB2xWT2/wB2KVAzVilsiYVlORsnqNFrtMCukA2PA8aZF3YJhvelQNvGid0ttuxOGB+efuQ=";
				RESPONSE_TOO_MANY_INVITE = SecurityUtils.ReadStructEncrypted(RESPONSE_TOO_MANY_INVITE_SE);
				ENDPOINT_PENDING_USER_1_SE = "TtuDEY+UzKn1Ad5du2qSnQ==.zziWWqs+7LWYajJOzKQEvuq8qPL0HhNvQz6aMohAW3HySuG8QG9xPLXtSA/xM537X0ELvxHxj8+f+1mX7LgZ+8Lbi5/oaE4jhv/XfR2CvZJCkF3N46gPwVsujSznQKFl";
				ENDPOINT_PENDING_USER_1 = SecurityUtils.ReadStructEncrypted(ENDPOINT_PENDING_USER_1_SE);
				ENDPOINT_PENDING_USER_2_SE = "Mks9+DApscQ/nhD2i7VbfQ==.Unom1Epfe/rVR94xsW4nOBkXT2x3V+Gk6WpUxf/ysLXN+YA0Yik0NPv0IVLTs1hajw8WWnKHz47TlJExpp7+1dFVmYzXZXMBhK2Rz8mxD8xGpfqbgM3Ke/T/MPseoMco";
				ENDPOINT_PENDING_USER_2 = SecurityUtils.ReadStructEncrypted(ENDPOINT_PENDING_USER_2_SE);
				URL_ACCOUNT_LIMIT_SE = "6UdWAFx2cbf8Uxwmb6uEYg==.1Yvj/s9Qo6Fmwca39iPMvMU87T9huJttHnY7v1sgBAfih47zGMYSg8PAtXX/vD2BF1M1HAM32R1ALxVa44U31Txkhb2C+UKl+qzrTLtGlTlH1kDCJSBVrmMaLmgqY2mw";
				URL_ACCOUNT_LIMIT = SecurityUtils.ReadStructEncrypted(URL_ACCOUNT_LIMIT_SE);
				BODY_ACCOUNT_LIMIT_SE = "OIKz4/raQKBKaP7TnHsjHQ==.YLxd8j633Z3bqM3YQHrli7L7/JLIXE8Lww4NKqV+zQw=";
				BODY_ACCOUNT_LIMIT = SecurityUtils.ReadStructEncrypted(BODY_ACCOUNT_LIMIT_SE);
				REGEX_ACCOUNT_LIMIT_SE = "zm9BQaTBoev90K2B/kS9Mw==.2zJG99dDlFJ+oQEso8w/MJARmCI+eaFIZyQXzAooUk2WaUKeAegKNrIMxdf8whYD";
				REGEX_ACCOUNT_LIMIT = SecurityUtils.ReadStructEncrypted(REGEX_ACCOUNT_LIMIT_SE);
				METHOD_EXECUTE_SE = "GG729+85rJNlGpo5P2V9tQ==./NALpNn0tJyzSbUVZCuv9f4r+NtwaA20mpvGx+y9+UU=";
				METHOD_EXECUTE = SecurityUtils.ReadStructEncrypted(METHOD_EXECUTE_SE);
				while (true)
				{
					LOG_1_SE = "4fs5gQWhesDoQozL+CMHLA==.Ay3sIYISDWj2JJGHbgYOklE5xLcf5+mXHsqFvdCwExmYObGM9uL2OMKkOC5CbRds";
					LOG_1 = SecurityUtils.ReadStructEncrypted(LOG_1_SE);
					LOG_2_SE = "O9v5YD7ZVCe3Gxne5GDqAw==.TQPD8gAi/GcAYs47QzGY72lkR2yQjZdXHkNnQtHcGlvmEVafhpYVVdp2Cy68mmwn";
					LOG_2 = SecurityUtils.ReadStructEncrypted(LOG_2_SE);
					LOG_3_SE = "BC6BeVS16XW4oP27XsciAA==.4/MzBtHcou9a5y6L+7BJkqCCrug5Sgj8SrM/uNBsdr4YsZ7Pat3BM+byLE2QnsSE";
					LOG_3 = SecurityUtils.ReadStructEncrypted(LOG_3_SE);
					LOG_4_SE = "cYhReanDaI6dbtTuQHBhoQ==.QeaG0QR9WOaZpnC0Vm/Oajt8Qw8lphjONPs5AnYh3PjP//jn7EtTMEA8hRvyArH2";
					LOG_4 = SecurityUtils.ReadStructEncrypted(LOG_4_SE);
					LOG_5_SE = "DCSZY8QUbZRx+qMaRK2awQ==.FWAgvQOXym/X61FjhBnNxa10JQ1BYRavUftIE1pV16LMN2v1KdVQJph2LD4u3qlz";
					LOG_5 = SecurityUtils.ReadStructEncrypted(LOG_5_SE);
					LOG_6_SE = "0wK3vtE662LhPjvjMBydzw==.4aNuECMWn3U/VNTpehCQq+8283WSFlM1pK1q30A1YonM1/oRofCPWAorERDjjVPB";
					LOG_6 = SecurityUtils.ReadStructEncrypted(LOG_6_SE);
					LOG_6_2_SE = "M9HkicZswNeKrXUNG9thzA==.V/XFL1vHqMoiZVi4QEjnycyY+pDmCMvoWtbXsLDwWNkJG2KH68R2F4vrvF5XZcBF";
					LOG_6_2 = SecurityUtils.ReadStructEncrypted(LOG_6_2_SE);
					LOG_7_1_SE = "pq3vCuveWNce+V+WrEuB4w==.a1ixIO+uC2PlPUwaWg3TK4rEtk9TrQJnVj2viAdLSha2omfpCAEI1xqNcECh7wjc";
					while (true)
					{
						LOG_7_1 = SecurityUtils.ReadStructEncrypted(LOG_7_1_SE);
						LOG_8_1_SE = "QaDGkTYlKIxQ2eaySLOu0Q==.Mk2yCWtXWjnx3ImZVNxOt+S0fnOtCUFYK9h4yhEmQQQvGI5Xd1IIwoTA9NKekDGw";
						LOG_8_1 = SecurityUtils.ReadStructEncrypted(LOG_8_1_SE);
						LOG_9_1_SE = "jurqtlW/BlUgMtpI21ToEw==.eJvcPAMZ/zOCRQaNWOyfiDIr82Uc173lXYCKMJ6T6j6ydmkRgg8vCPUDyFwYGh0M";
						if (false)
						{
							break;
						}
						LOG_9_1 = SecurityUtils.ReadStructEncrypted(LOG_9_1_SE);
						LOG_9_2_SE = "KRNRXLah3RgdBPrBM2uTTg==.24bRIGcuh5WnbPDeRKDDN62HnHYbVrTfLG2OeDnhegw=";
						LOG_9_2 = SecurityUtils.ReadStructEncrypted(LOG_9_2_SE);
						LOG_10_1_SE = "+ZJYBRRHsd3Z6gwCkme+rQ==.9gKzHIvyJKcop1xmyBYdhWZBktr1nrJZY4RxKkMctJyCfwvsNGC07YNttySOgHlK";
						if (8 == 0)
						{
							continue;
						}
						goto IL_03a3;
					}
					goto IL_069d;
					IL_069d:
					FIELD_PENDING_INVITES = SecurityUtils.ReadStructEncrypted(FIELD_PENDING_INVITES_SE);
					FIELD_DELETE_SE = "A0M0dbxW5VU9oxajtmuAQA==.CLFcTcoK0riCsyCqX6P+LiZo1hHe2TV2zMunKKxZToc=";
					FIELD_DELETE = SecurityUtils.ReadStructEncrypted(FIELD_DELETE_SE);
					FIELD_SENT_COUNT_SE = "3bD5g4fm/OqcFWWHgp1+kQ==.B96YGbzVrjLQPRfBufSLP9Cz1C4gGtw2kgNx47OkAV0=";
					FIELD_SENT_COUNT = SecurityUtils.ReadStructEncrypted(FIELD_SENT_COUNT_SE);
					FIELD_EMAIL_SE = "CJl6ApsnQmuCH3IIfP+/2w==.NWzs1k17P/1JtFo78E9VwX8JkEclsTvmJm4rEA5kVeU=";
					FIELD_EMAIL = SecurityUtils.ReadStructEncrypted(FIELD_EMAIL_SE);
					FIELD_TYPE_SE = "XBnRTECY2oA7HByAuSql9A==.ZQ21pfkmRIdn1O0BJ3AO8oTmp/4vRTd6Hq4DZvwC1fo=";
					FIELD_TYPE = SecurityUtils.ReadStructEncrypted(FIELD_TYPE_SE);
					FIELD_TAG_SE = "kKJ4SYEznvSAAN+jz+MQQg==.IfFZw367ppOJwLOB3JFUP4otl96hS5rdwpO70XgLYaM=";
					FIELD_TAG = SecurityUtils.ReadStructEncrypted(FIELD_TAG_SE);
					ADMIN_SE = "EU1ceEPOQ74+kKTMMR6T5w==.Ac/+S58AjfGiClNgbR93to8iSYzqFH7mw3+X1+fRi/4=";
					ADMIN = SecurityUtils.ReadStructEncrypted(ADMIN_SE);
					SHARE_LINK_SE = "QYM2UbiE/vIgDF9Rb7Zonw==.WeezQjpl8MImxXILZM7CXHjkJgFcrgggRde5sLgwnrM=";
					SHARE_LINK = SecurityUtils.ReadStructEncrypted(SHARE_LINK_SE);
					SHARE_LINK_JOB_SE = "ar8CNr9qjnvuoXmO5/JXYw==.jC0mrzsKl49wMP9/1n81EaB3Ox37YXa1FC3Jsc4sgjA=";
					SHARE_LINK_JOB = SecurityUtils.ReadStructEncrypted(SHARE_LINK_JOB_SE);
					SHARE_ACC_STEP_SE = "nc4gaAm7cl1MDSC5WU2WvQ==.2/2JSFzA3uVv//AO7ndKMIyKhOErh0JVcHj69OZ85T8=";
					SHARE_ACC_STEP = SecurityUtils.ReadStructEncrypted(SHARE_ACC_STEP_SE);
					SHARE_ACC_JOB_SE = "8BW21F3+7CouF3pOCYr/Bg==.dikXh8/tGp913n3+Yzxd0PMCFkR1Yf+xsBrIVJ/RUvI=";
					SHARE_ACC_JOB = SecurityUtils.ReadStructEncrypted(SHARE_ACC_JOB_SE);
					if (uint.MaxValue != 0)
					{
						SHARE_LINK_ADMIN_SE = "gM+clqwOGhM+/WjY3EIbtA==.bLHx5zZrOk20Wf1pycxt+k2yCA+TPyJPoxQ3O+RJsZHptNXLp3WkFdEpFKdOzhsb";
						SHARE_LINK_ADMIN = SecurityUtils.ReadStructEncrypted(SHARE_LINK_ADMIN_SE);
						SHARE_LINK_ADMIN_JOB_SE = "eAmyawsP3WwuJqgWAv2RJg==.9KxWIt58MMkTfcf86kosUdukSa+V4rk6OsZCpgJU7pXFHthVbj2Ffuy4pAVqpcD+";
						SHARE_LINK_ADMIN_JOB = SecurityUtils.ReadStructEncrypted(SHARE_LINK_ADMIN_JOB_SE);
						REQ_1_SE = "DQoBKLBb4HGvlHJRXtFKIQ==.cxXwdScMw3ftaFZKs8Mhnl1UZPhpG5Jblt+sHXIFypg=";
						REQ_1 = SecurityUtils.ReadStructEncrypted(REQ_1_SE);
						REQ_1_2_SE = "28clBkVu3YQC5VIIF6koeA==.86jP3b2Pth5Z1yGsJ4mJOKYmiK2jo0ZO7sB2Yx96s+o=";
						REQ_1_2 = SecurityUtils.ReadStructEncrypted(REQ_1_2_SE);
						REQ_2_1_SE = "mevuach5Cidhvn9rMdDPsw==.XKe5xozCGT/Ty2Kk1n5JPjifcpV4bdFPFHzootRuEyw=";
						REQ_2_1 = SecurityUtils.ReadStructEncrypted(REQ_2_1_SE);
						SWA_SE = "owtTggFcPUppn2DdgURONg==.Ut0niJ3dvk7MnWY5iodu93mXFF6JuAFs4nJHvc/yqHQ=";
						SWA = SecurityUtils.ReadStructEncrypted(SWA_SE);
						SNA_SE = "3lyVxLc5sHo76cwwhr72ZQ==.kf8D6u1q5ytf2lQy38kI5GvIs9JIAJPqsQ6D9EUXBSc=";
						SNA = SecurityUtils.ReadStructEncrypted(SNA_SE);
						FIELD_DESC_SE = "DidvWFon/7hdC+hFaJmbBQ==.CqX+P6Ape+JKR/lhCrS4wu8hKMpOQ/73RIG1yvrj66Y=";
						FIELD_DESC = SecurityUtils.ReadStructEncrypted(FIELD_DESC_SE);
					}
					EMP_SE = "eYyrmlu+MAnIZRcZDerCGw==.uWGW+vwOOyBeyBrhKdTCL/aaV5655biaUvShCV0EqxE=";
					EMP = SecurityUtils.ReadStructEncrypted(EMP_SE);
					NOACC_SE = "ZyIm95FuaI4fOMz5Xqo7Uw==.CVpHfLFNki0lzchKjXATd39ytETu2p199co9nFmb7Bk=";
					NOACC = SecurityUtils.ReadStructEncrypted(NOACC_SE);
					FA2_SE = "UUYSk0VsJ9gXK0VsoV8dsQ==.fP9ub+nvEVen7TFr38748mcb42a5e+Odqbi3EJrCw7E=";
					FA2 = SecurityUtils.ReadStructEncrypted(FA2_SE);
					NOACC_A_SE = "2fGfVdxcSaN5zFh9RvopqQ==.mIUfv3xwfZuZu+EvpfiNAqRRnVxZlKHZXSvhzpdcNug=";
					NOACC_A = SecurityUtils.ReadStructEncrypted(NOACC_A_SE);
					SS_SE = "MzdWdPbUW0NYDoN7HkKkCw==.PEj70j6rKn0kPt1tNHtsUrwBy7fXI2ZkLzfvNBvKNZw=";
					SS = SecurityUtils.ReadStructEncrypted(SS_SE);
					return;
					IL_03a3:
					LOG_10_1 = SecurityUtils.ReadStructEncrypted(LOG_10_1_SE);
					LOG_10_2_SE = "R0JO1JnfEOH6dZzPfm1BKQ==.bcURFJKmXijB+LYR22PkC43/Jnf3T/p+M3H+3j0h2zc=";
					LOG_10_2 = SecurityUtils.ReadStructEncrypted(LOG_10_2_SE);
					LOG_10_3_SE = "GP6AWfcS9+0BGscIZff5Ew==.Cdyns9B+j0uHKjORxUUVkq+7ngSMQ8hOvBNikLIlHiYCe6bRCmm4BeQOay84jQ7W";
					LOG_10_3 = SecurityUtils.ReadStructEncrypted(LOG_10_3_SE);
					LOG_11_SE = "7pfvYC1jOHSnS2aXuS0Baw==.NrYau+L+rLMf8EdWqlCRA467o62P03/P/qtXvsaBZa86HibtFkJr4HsW4acjDMTY";
					LOG_11 = SecurityUtils.ReadStructEncrypted(LOG_11_SE);
					LOG_12_SE = "LvxEeRkbHlPLCbgpVI4+6A==.wUY6h0sAjESh4aN0XpJXSNzbKem2JgNimSY8lHyEd/NzhVSEUutsCK+/kZPs5bSV";
					LOG_12 = SecurityUtils.ReadStructEncrypted(LOG_12_SE);
					LOG_13_SE = "JhhwyzRB/ASV/HetF/IIlQ==.UyKbS7A+/s9ot0sZpd7KmTDqX47yFkYUf/uvB1s9iZQXWjJ5sZUUzwRslEFEtWJn";
					LOG_13 = SecurityUtils.ReadStructEncrypted(LOG_13_SE);
					LOG_14_SE = "Ts0v/2ZfoRkXnioVIMpgnw==.hv9ps2aCMXPXGEQmW7fYOYL+ViM+EvjFZ7J/sfMy5YUZBvn0FRyqYFMmz0R6OXxp";
					LOG_14 = SecurityUtils.ReadStructEncrypted(LOG_14_SE);
					LOG_15_SE = "FDRhcjqXiMwtKneltwRvbQ==.dkJ2/4FCW35TqzzZUg+kkHs8Thj08Qu+yhroGZ0DVNA=";
					LOG_15 = SecurityUtils.ReadStructEncrypted(LOG_15_SE);
					LOG_16_SE = "TqwUau9MXD8I80Su4UrQbA==.A2dzJPFdom7iPAWqkxwV2+fifHaxeDpOAbU17Ks70mxawIRBZse2nINLOIEFdAT/";
					LOG_16 = SecurityUtils.ReadStructEncrypted(LOG_16_SE);
					LOG_17_SE = "Z2MBylxddqEnS1nb6l1h9Q==.lwLIGwGMgrbs6JSG1qI+bwiDx/rT9gfzNw1dKPnbgD5SayG4vm83fUF4agHplV28";
					LOG_17 = SecurityUtils.ReadStructEncrypted(LOG_17_SE);
					LOG_18_SE = "lWJ5EfYc4gDucEOxOR660Q==.SKxE4EkaB2qI3We4tpNKlF3lnRoQgLynvII3oJ16uBE=";
					LOG_18 = SecurityUtils.ReadStructEncrypted(LOG_18_SE);
					LOG_19_SE = "2xeZlSPd2uOLn247z1zr0Q==.i23j33oZqduhusb7LmuTM4p2RM1TMovwkz5Sw2X2riErchKfuUYEvNbMtiDR8ePl";
					LOG_19 = SecurityUtils.ReadStructEncrypted(LOG_19_SE);
					LOG_20_SE = "LnrM0mfae83Xme3zcQFAiA==.dV9u5U4v3bka7hxmEGLfrR1PDXCiULbeI3qghZDfnNNqGnPlTlGoXLGjhNRVT0rq";
					LOG_20 = SecurityUtils.ReadStructEncrypted(LOG_20_SE);
					FIELD_ALL_ACCOUNTS_SE = "kM9ijISbtQfB3rWcSdoZjw==.JOQ5M0KZqowg7qdM40hF5Vm0sUxBoaKznBZtD78kA/g=";
					if (false)
					{
						continue;
					}
					FIELD_ALL_ACCOUNTS = SecurityUtils.ReadStructEncrypted(FIELD_ALL_ACCOUNTS_SE);
					FIELD_FA_SE = "fO72Rw1u0cQ2ONSyVvKbtg==.3epZcIHmqLTigRFU2hdenedThtH8oQC+ZiP3jABROkc=";
					FIELD_FA = SecurityUtils.ReadStructEncrypted(FIELD_FA_SE);
					FIELD_NOTE_SE = "Fi8oJzK8Ug1eri3AqfUVvA==.HMibeDc6y5d34y763Stz7QsaJL3PHRopw4mtvMIwd0A=";
					FIELD_NOTE = SecurityUtils.ReadStructEncrypted(FIELD_NOTE_SE);
					FIELD_ADS_LIMIT_SE = "HllVx8p0o2siMF/etCACSw==.G1h8NcTwYMit4hGTx7dkkFEHrl5xhBldH2cuEXuSexA=";
					FIELD_ADS_LIMIT = SecurityUtils.ReadStructEncrypted(FIELD_ADS_LIMIT_SE);
					FIELD_ID_SE = "0Itp8he08aasce5pIx3dDA==.2YxKuUiIO9Dk2GbiS1F1NaJ3Tl1MgFd1CgJ6uCvTdrE=";
					FIELD_ID = SecurityUtils.ReadStructEncrypted(FIELD_ID_SE);
					GET_INVITES_SE = "fzsgr717LFJShKiaeQwBXQ==.WmeaZWqQQLn2NcEglZkT4Kmbx3LVOsbtugpgd16oj6c=";
					GET_INVITES = SecurityUtils.ReadStructEncrypted(GET_INVITES_SE);
					FIELD_DATA_SE = "XRZ0T9S/SBkO0kVCvnXM5g==.UH02GwY04f9Sn/RrgWS77rnbsFynWxz1Me6b/s3AN10=";
					FIELD_DATA = SecurityUtils.ReadStructEncrypted(FIELD_DATA_SE);
					PAGING_AFTER_SE = "kjoBjr9w8/7S0PckeQ+WhQ==.V4E6XDUBgcQydR3p+ptOp6qW6OSKGUI+bo67PdRTqLXKmIOkF1mG9snl41YeVvo/";
					PAGING_AFTER = SecurityUtils.ReadStructEncrypted(PAGING_AFTER_SE);
					GPIJ_SE = "dTzMOSMooyhFhEJI99hvRw==.sslCBDVvGmFR0B87bt1jLZiEWB73QbgPqyMX7svjfQIgqDrnRDcU2mdDBwRXO3/2";
					GPIJ = SecurityUtils.ReadStructEncrypted(GPIJ_SE);
					CHECK_BM_LIMIT_SE = "iy6hB/P+KHW/IE0Wjl7c9w==.s9jPm5alVjfF9CO0rn4gDr9UV/EKxx2QkRrBlxbYh+E=";
					CHECK_BM_LIMIT = SecurityUtils.ReadStructEncrypted(CHECK_BM_LIMIT_SE);
					CHECK_BM_LIMIT_JOB_SE = "TDTE3dV7CVycsuqNZqkYBA==.Ql6B5X5EfCtwubR8dHGtR9GBqV362EeuIhOD7MON9VCIk50jv/IWujvzI0lbUK1f";
					CHECK_BM_LIMIT_JOB = SecurityUtils.ReadStructEncrypted(CHECK_BM_LIMIT_JOB_SE);
					FIELD_NAME_SE = "Sqe37exwev7IVY/D6W+umA==.6Cw59aqiCZ+5FlBAAveD09e1XmsaAfR4ukrSMbt0lQY=";
					FIELD_NAME = SecurityUtils.ReadStructEncrypted(FIELD_NAME_SE);
					ACCESST_SE = "HfKPJau0LlBrI/ikwBTpNg==.i75X6RivZ1AA6722A8GXBao+/uf9Ajq/X3VICMzJTXk=";
					ACCESST = SecurityUtils.ReadStructEncrypted(ACCESST_SE);
					ACT_SE = "Jfm05kPK6iXlV34o1QMMhQ==.EERIdA131kAqeVaqpZ3iBL0yZ19xhYugIj8f++ScABE=";
					ACT = SecurityUtils.ReadStructEncrypted(ACT_SE);
					METHOD_RLI_SE = "vRq+VPmJfIILji3fvH0UtA==.zaTUqkQPJ2a+PfsuroBSiDLSbN1Il+dakT6TNF74ELeciryl39LcOX0DZ0zjOYkX";
					if (false)
					{
						break;
					}
					METHOD_RLI = SecurityUtils.ReadStructEncrypted(METHOD_RLI_SE);
					METHOD_CLI_SE = "wjkffWL6I+xar1avYfpPnw==.dQ95Nx/UarVAMtIC93vS+XaEOTjBIpJHRHFo9Cv+QkY=";
					METHOD_CLI = SecurityUtils.ReadStructEncrypted(METHOD_CLI_SE);
					FIELD_MTB_LINK_SE = "7+0FYldRjma0Zty86Y66UQ==.dEeIPL7PdHJdqpGBnRfzXoRTXWcx/LeTgu5/p9p4TKA=";
					FIELD_MTB_LINK = SecurityUtils.ReadStructEncrypted(FIELD_MTB_LINK_SE);
					FIELD_PENDING_INVITES_SE = "dSaT8p9ZlA+r1kXeHQbTDg==.AAkTwuIl0LYbryN6RwxJCEW3pI78h38NpTLCdwCleME=";
					goto IL_069d;
				}
			}
		}
	}
}
