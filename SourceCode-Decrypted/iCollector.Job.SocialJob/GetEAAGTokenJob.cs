using System;
using System.Collections.Generic;
using System.Linq;
using iCollector.Job.Model;
using iCollector.Model;
using iCollector.RestClient;
using iCollector.Util;
using Newtonsoft.Json.Linq;

namespace iCollector.Job.SocialJob;

internal class GetEAAGTokenJob
{
	private static string CLAZZ_NAME_SE = "GetEAAGTokenJob";

	private static string CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);

	private static string METHOD_EXEC_SE = "Execute";

	private static string METHOD_EXEC = SecurityUtils.ReadStructEncrypted(METHOD_EXEC_SE);

	private static string GET_EAAG_SE;

	private static string GET_EAAG;

	private static string GET_MBID_SE;

	private static string GET_MBID;

	private static string FAE_SE;

	private static string FAE;

	private static string REGEX_1_SE;

	private static string REGEX_1;

	private static string EAAG_SE;

	private static string EAAG;

	private static string REGEX_2_SE;

	private static string REGEX_2;

	private static string REGEX_3_SE;

	private static string REGEX_3;

	private static string LOG_1_SE;

	private static string LOG_1;

	private static string LOG_2_SE;

	private static string LOG_2;

	private static string LOG_3_SE;

	private static string LOG_3;

	private static string LOG_4_SE;

	private static string LOG_4;

	private static string LOG_5_SE;

	private static string LOG_5;

	private static string FIELD_ADNUM_SE;

	private static string FIELD_ADNUM;

	private static string FIELD_IS_ADMIN_SE;

	private static string FIELD_IS_ADMIN;

	public static readonly string URL_1_SE;

	public static readonly string URL_1;

	public static readonly string URL_2_SE;

	public static readonly string URL_2;

	public static readonly string URL_3_SE;

	public static readonly string URL_3;

	public static readonly string RESPONSE_1_SE;

	public static readonly string RESPONSE_1;

	private Logger log = Logger.Instance();

	private JobExecutor jobExecutor = new JobExecutor();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	public string Execute(SocialProfile profile)
	{
		LogContext logContext = ctx;
		string mETHOD_EXEC = METHOD_EXEC;
		if (uint.MaxValue != 0)
		{
			logContext.MethodName = mETHOD_EXEC;
		}
		List<string> mbIds = profile.MbIds;
		List<string> list;
		if (6u != 0)
		{
			list = mbIds;
		}
		if (list == null || list.Count == 0)
		{
			List<string> list2 = ResolveMBIDS(profile);
			if (0 == 0)
			{
				list = list2;
			}
			List<string> mbIds2 = list;
			if (6u != 0)
			{
				profile.MbIds = mbIds2;
			}
		}
		if (list.Count == 0)
		{
			return "";
		}
		List<Step> list3 = new List<Step>();
		List<Step> list4;
		if (2u != 0)
		{
			list4 = list3;
		}
		List<string>.Enumerator enumerator = list.GetEnumerator();
		List<string>.Enumerator enumerator2;
		if (true)
		{
			enumerator2 = enumerator;
		}
		try
		{
			_003C_003Ec__DisplayClass43_0 _003C_003Ec__DisplayClass43_2 = default(_003C_003Ec__DisplayClass43_0);
			Step step2 = default(Step);
			while (enumerator2.MoveNext())
			{
				_003C_003Ec__DisplayClass43_0 _003C_003Ec__DisplayClass43_ = new _003C_003Ec__DisplayClass43_0();
				if (0 == 0)
				{
					_003C_003Ec__DisplayClass43_2 = _003C_003Ec__DisplayClass43_;
				}
				_003C_003Ec__DisplayClass43_2._003C_003E4__this = this;
				_003C_003Ec__DisplayClass43_2.mbId = enumerator2.Current;
				Step step = new Step();
				if (0 == 0)
				{
					step2 = step;
				}
				Step step3 = step2;
				if (4u != 0)
				{
					step3.Index = 1;
				}
				Step step4 = step2;
				string gET_EAAG = GET_EAAG;
				if (8u != 0)
				{
					step4.Name = gET_EAAG;
				}
				Step step5 = step2;
				if (6u != 0)
				{
					step5.Type = StepType.CURL;
				}
				Step step6 = step2;
				if (3u != 0)
				{
					step6.StopWhenSuccess = true;
				}
				step2.StopWhenFailed = false;
				step2.CheckResultFunc = _003C_003Ec__DisplayClass43_2._003CExecute_003Eb__0;
				step2.Spec = new CURLStepSpec
				{
					Url = URL_1 + _003C_003Ec__DisplayClass43_2.mbId,
					Headers = new string[3] { "accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7", "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" },
					RestClient = profile.RestClient
				};
				list4.Add(step2);
			}
		}
		finally
		{
			((IDisposable)enumerator2).Dispose();
		}
		list4.Add(new Step
		{
			Index = 1,
			Name = GET_EAAG,
			Type = StepType.CURL,
			StopWhenSuccess = true,
			StopWhenFailed = false,
			CheckResultFunc = (string r) => ResolveEAAGLocation(r),
			Spec = new CURLStepSpec
			{
				Url = URL_2,
				Headers = new string[3] { "accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7", "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" },
				RestClient = profile.RestClient
			}
		});
		JobModel<string> jobModel = new JobModel<string>
		{
			Name = GET_EAAG,
			Steps = list4,
			SuccessWhenAnyStepSuccess = true,
			ResultAtAnyLastStepSuccess = true
		};
		jobExecutor.Execute(jobModel);
		log.Info(ctx, GET_EAAG + jobModel.Result);
		return jobModel.Result;
	}

	private List<string> ResolveMBIDS(SocialProfile profile)
	{
		if (3u != 0)
		{
		}
		GetEAAGTokenJob getEAAGTokenJob = this;
		SocialProfile profile2 = profile;
		Step step = new Step();
		Step step2;
		if (2u != 0)
		{
			step2 = step;
		}
		JobModel<List<string>> jobModel = default(JobModel<List<string>>);
		if (true)
		{
			if (0 == 0)
			{
				step2.Index = 0;
			}
			string gET_MBID = GET_MBID;
			if (2u != 0)
			{
				step2.Name = gET_MBID;
			}
			if (6u != 0)
			{
				step2.Type = StepType.CURL;
			}
			if (0 == 0)
			{
				step2.StopWhenSuccess = true;
			}
			if (0 == 0)
			{
				step2.StopWhenFailed = true;
			}
			Func<string, StepResult> checkResultFunc = (string r) => getEAAGTokenJob.ResolveListBMID(profile2, r);
			if (true)
			{
				step2.CheckResultFunc = checkResultFunc;
			}
			CURLStepSpec cURLStepSpec = new CURLStepSpec();
			CURLStepSpec cURLStepSpec2 = default(CURLStepSpec);
			if (0 == 0)
			{
				cURLStepSpec2 = cURLStepSpec;
			}
			CURLStepSpec cURLStepSpec3 = cURLStepSpec2;
			string uRL_ = URL_3;
			if (3u != 0)
			{
				cURLStepSpec3.Url = uRL_;
			}
			CURLStepSpec cURLStepSpec4 = cURLStepSpec2;
			string[] headers = new string[3] { "accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7", "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" };
			if (0 == 0)
			{
				cURLStepSpec4.Headers = headers;
			}
			CURLStepSpec cURLStepSpec5 = cURLStepSpec2;
			IRestClient restClient = profile2.RestClient;
			if (8u != 0)
			{
				cURLStepSpec5.RestClient = restClient;
			}
			step2.Spec = cURLStepSpec2;
			Step item = step2;
			if (0 == 0)
			{
				jobModel = new JobModel<List<string>>
				{
					Name = GET_MBID,
					Steps = new List<Step> { item },
					SuccessWhenAllStepSuccess = true,
					ResultAtLastStepSuccess = true
				};
				jobExecutor.Execute(jobModel);
			}
			log.Info(ctx, GET_MBID + ((jobModel.Result != null) ? string.Join(",", jobModel.Result) : null));
			if (jobModel.Result == null)
			{
				return new List<string>();
			}
		}
		return jobModel.Result;
	}

	private StepResult ResolveEAAG(string mtbId, string response)
	{
		string text = RegexUtils.FindRegex(response, REGEX_1);
		string text2;
		if (6u != 0 && 2u != 0)
		{
			text2 = text;
		}
		if (string.IsNullOrEmpty(text2))
		{
			if (response.Contains(RESPONSE_1 + mtbId + FAE))
			{
				Logger logger = log;
				LogContext logContext = ctx;
				string message = LOG_1 + mtbId;
				if (0 == 0 && 0 == 0)
				{
					logger.Info(logContext, message);
				}
			}
			if (0 == 0)
			{
				Logger logger2 = log;
				LogContext logContext2 = ctx;
				string message2 = LOG_2 + mtbId;
				if (8u != 0 && 5u != 0)
				{
					logger2.Info(logContext2, message2);
				}
			}
			return StepResult.Of(success: false, "");
		}
		return StepResult.Of(success: true, EAAG + text2);
	}

	private StepResult ResolveEAAGLocation(string response)
	{
		string text = RegexUtils.FindRegex(response, REGEX_1);
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
				string lOG_ = LOG_2;
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
				return StepResult.Of((byte)num != 0, EAAG + text2);
			}
		}
		return StepResult.Of((byte)num != 0, "");
	}

	private StepResult ResolveListBMID(SocialProfile profile, string response)
	{
		List<string> list2 = default(List<string>);
		if (6u != 0)
		{
			List<string> list4 = default(List<string>);
			if (0 == 0)
			{
				List<string> list = RegexUtils.FindRegexes(response, REGEX_2);
				if (6u != 0)
				{
					list2 = list;
				}
				if (list2 == null || list2.Count == 0)
				{
					Logger logger = log;
					LogContext logContext = ctx;
					string lOG_ = LOG_3;
					if (0 == 0)
					{
						logger.Info(logContext, lOG_);
					}
					if (uint.MaxValue != 0)
					{
						return StepResult.Of(success: false, new List<string>());
					}
				}
				List<string> list3 = RegexUtils.FindRegexesMatchAll(response, REGEX_3);
				if (0 == 0)
				{
					list4 = list3;
				}
				Logger logger2 = log;
				LogContext logContext2 = ctx;
				string lOG_2 = LOG_4;
				int count = list4.Count;
				int num;
				if (5u != 0)
				{
					num = count;
				}
				string message = lOG_2 + num;
				if (0 == 0)
				{
					logger2.Info(logContext2, message);
				}
			}
			List<DynamicObject> list5 = new List<DynamicObject>();
			List<DynamicObject> list6 = default(List<DynamicObject>);
			if (0 == 0)
			{
				list6 = list5;
			}
			List<string>.Enumerator enumerator = list4.GetEnumerator();
			List<string>.Enumerator enumerator2;
			if (6u != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				JObject jObject2 = default(JObject);
				while (enumerator2.MoveNext())
				{
					JObject jObject = JObject.Parse(enumerator2.Current);
					if (0 == 0)
					{
						jObject2 = jObject;
					}
					if (jObject2 == null)
					{
						continue;
					}
					DynamicObject dynamicObject = new DynamicObject(jObject2);
					DynamicObject dynamicObject2;
					if (3u != 0)
					{
						dynamicObject2 = dynamicObject;
					}
					List<DynamicObject> list7 = list6;
					DynamicObject item2 = new DynamicObject(jObject2);
					if (true)
					{
						list7.Add(item2);
					}
					if (!dynamicObject2.Contains(FIELD_ADNUM) || string.IsNullOrEmpty(dynamicObject2.GetString(FIELD_ADNUM)))
					{
						string fIELD_ADNUM = FIELD_ADNUM;
						object value = -1;
						if (0 == 0)
						{
							dynamicObject2.Put(fIELD_ADNUM, value);
						}
					}
					if (!dynamicObject2.Contains(FIELD_IS_ADMIN) || string.IsNullOrEmpty(dynamicObject2.GetString(FIELD_IS_ADMIN)))
					{
						string fIELD_IS_ADMIN = FIELD_IS_ADMIN;
						object value2 = false;
						if (8u != 0)
						{
							dynamicObject2.Put(fIELD_IS_ADMIN, value2);
						}
					}
					log.Info(ctx, LOG_5 + jObject2.ToString());
				}
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			profile.MbTempList = (from item in list6.AsEnumerable()
				orderby item.Contains(FIELD_ADNUM) ? item.GetInteger(FIELD_ADNUM) : 0 descending
				select item).ToList();
		}
		return StepResult.Of(success: true, list2);
	}

	static GetEAAGTokenJob()
	{
		if (3 == 0)
		{
			goto IL_00b8;
		}
		GET_EAAG_SE = "GET_EAAG";
		if (false)
		{
			goto IL_0179;
		}
		if (0 == 0)
		{
			GET_EAAG = SecurityUtils.ReadStructEncrypted(GET_EAAG_SE);
			GET_MBID_SE = "GET_MBID";
			GET_MBID = SecurityUtils.ReadStructEncrypted(GET_MBID_SE);
			FAE_SE = "\",\"twoFacEnabled\":true";
			goto IL_0080;
		}
		goto IL_0205;
		IL_0105:
		LOG_1_SE = "Get EAAG 2FA id: ";
		goto IL_010f;
		IL_0080:
		FAE = SecurityUtils.ReadStructEncrypted(FAE_SE);
		REGEX_1_SE = "EAAG(.*?)\"";
		REGEX_1 = SecurityUtils.ReadStructEncrypted(REGEX_1_SE);
		if (0 == 0)
		{
			EAAG_SE = "EAAG";
			goto IL_00b8;
		}
		goto IL_013a;
		IL_012b:
		LOG_2 = SecurityUtils.ReadStructEncrypted(LOG_2_SE);
		goto IL_013a;
		IL_00b8:
		EAAG = SecurityUtils.ReadStructEncrypted(EAAG_SE);
		while (true)
		{
			REGEX_2_SE = "\?business_id=(\d+)";
			while (6u != 0)
			{
				REGEX_2 = SecurityUtils.ReadStructEncrypted(REGEX_2_SE);
				if (false)
				{
					continue;
				}
				goto IL_00e6;
			}
			break;
			IL_00e6:
			REGEX_3_SE = "{"adAccountNumber".*?business\.facebook\.com\\/settings.*?}";
			if (-1 == 0)
			{
				goto IL_0080;
			}
			REGEX_3 = SecurityUtils.ReadStructEncrypted(REGEX_3_SE);
			if (false)
			{
				continue;
			}
			goto IL_0105;
		}
		goto IL_0121;
		IL_0121:
		LOG_2_SE = "Get EAAG empty id: ";
		goto IL_012b;
		IL_010f:
		if (2u != 0)
		{
			LOG_1 = SecurityUtils.ReadStructEncrypted(LOG_1_SE);
			goto IL_0121;
		}
		goto IL_012b;
		IL_013a:
		LOG_3_SE = "Get listIId empty";
		LOG_3 = SecurityUtils.ReadStructEncrypted(LOG_3_SE);
		if (2 == 0)
		{
			goto IL_010f;
		}
		LOG_4_SE = "bmInfos size: ";
		LOG_4 = SecurityUtils.ReadStructEncrypted(LOG_4_SE);
		LOG_5_SE = "jobject: ";
		goto IL_0179;
		IL_0205:
		RESPONSE_1_SE = "continueUri":"https:\/\/business.facebook.com\/settings\/people?business_id=";
		RESPONSE_1 = SecurityUtils.ReadStructEncrypted(RESPONSE_1_SE);
		return;
		IL_0179:
		LOG_5 = SecurityUtils.ReadStructEncrypted(LOG_5_SE);
		FIELD_ADNUM_SE = "adAccountNumber";
		FIELD_ADNUM = SecurityUtils.ReadStructEncrypted(FIELD_ADNUM_SE);
		FIELD_IS_ADMIN_SE = "isAdmin";
		FIELD_IS_ADMIN = SecurityUtils.ReadStructEncrypted(FIELD_IS_ADMIN_SE);
		URL_1_SE = "https://business.facebook.com/settings/people?business_id=";
		URL_1 = SecurityUtils.ReadStructEncrypted(URL_1_SE);
		URL_2_SE = "https://business.facebook.com/business_locations/?nav_source=mega_menu";
		URL_2 = SecurityUtils.ReadStructEncrypted(URL_2_SE);
		URL_3_SE = "https://business.facebook.com/settings/people";
		URL_3 = SecurityUtils.ReadStructEncrypted(URL_3_SE);
		goto IL_0205;
	}
}
