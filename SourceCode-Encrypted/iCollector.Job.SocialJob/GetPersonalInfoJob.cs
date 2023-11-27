using System;
using System.Collections.Generic;
using iCollector.Job.Model;
using iCollector.Model;
using iCollector.Util;
using Newtonsoft.Json;

namespace iCollector.Job.SocialJob;

internal class GetPersonalInfoJob
{
	private static string CLAZZ_NAME_SE = "OAzSwd9TtpeckZ3Qf5mKAw==.1DjB1MX/VTWxYdaIf7kGNwjFmtu+xB7MIsWVIDcuwVPBm8LpYP3rXM4vgY5/qYZC";

	private static string CLAZZ_NAME;

	private static string METHOD_EXEC_SE;

	private static string METHOD_EXEC;

	private static string BASE_URL_SE;

	private static string BASE_URL;

	private static string URL_ENDP_SE;

	private static string URL_ENDP;

	private static string REGEX_01_SE;

	private static string REGEX_01;

	private static string REGEX_02_SE;

	private static string REGEX_02;

	private static string REGEX_03_SE;

	private static string REGEX_03;

	private static string REGEX_04_SE;

	private static string REGEX_04;

	private static string LOG_1_SE;

	private static string LOG_1;

	private static string FIELD_NAME_SE;

	private static string FIELD_NAME;

	private static string FIELD_TEXT_SE;

	private static string FIELD_TEXT;

	private static readonly string URL_1_SE;

	private static readonly string URL_1;

	private static readonly string URL_2_SE;

	private static readonly string URL_2;

	private static readonly string DOB_LINK_SE;

	private static readonly string DOB_LINK;

	private static readonly string PHONE_LINK_SE;

	private static readonly string PHONE_LINK;

	private static readonly string BODM_LINK_SE;

	private static readonly string BODM_LINK;

	private static readonly string PHONEM_LINK_SE;

	private static readonly string PHONEM_LINK;

	private Logger log = Logger.Instance();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	private JobExecutor jobExecutor = new JobExecutor();

	public PersonalInfoResult Execute(SocialProfile profile)
	{
		if (5u != 0)
		{
		}
		GetPersonalInfoJob getPersonalInfoJob = this;
		SocialProfile profile2 = profile;
		try
		{
			if (0 == 0)
			{
				LogContext logContext = ctx;
				string mETHOD_EXEC = METHOD_EXEC;
				if (2u != 0)
				{
					logContext.MethodName = mETHOD_EXEC;
				}
				if (profile2.PersonalInfo != null)
				{
					goto IL_0040;
				}
				goto IL_0071;
			}
			goto IL_00b8;
			IL_00b8:
			Step step = default(Step);
			Step step2 = step;
			if (0 == 0)
			{
				step2.Index = 0;
			}
			Step step3 = step;
			if (0 == 0)
			{
				step3.Name = "GET_ME_INFO";
			}
			Step step4 = step;
			if (0 == 0)
			{
				step4.Type = StepType.CURL;
			}
			string url = default(string);
			JobModel<DynamicObject> jobModel;
			do
			{
				Step step5 = step;
				if (0 == 0)
				{
					step5.StopWhenSuccess = true;
				}
				Step step6 = step;
				if (8u != 0)
				{
					step6.StopWhenFailed = true;
				}
				Step step7 = step;
				Func<string, StepResult> checkResultFunc = (string r) => getPersonalInfoJob.ResolveMe(ref url, r, profile2);
				if (8u != 0)
				{
					step7.CheckResultFunc = checkResultFunc;
				}
				step.Spec = new CURLStepSpec
				{
					Url = url,
					Headers = new string[3] { "accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7", "Sec-Fetch-Dest: document", "Sec-Fetch-Mode: navigate" },
					RestClient = profile2.RestClient
				};
				Step item = step;
				jobModel = new JobModel<DynamicObject>
				{
					Name = "GET_ME_INFO_JOB",
					Steps = new List<Step> { item },
					SuccessWhenAllStepSuccess = true,
					ResultAtLastStepSuccess = true
				};
			}
			while (3 == 0);
			jobExecutor.Execute(jobModel);
			PersonalInfoResult personalInfoResult;
			personalInfoResult.PersonalInfo = jobModel.Result;
			if (0 == 0)
			{
				return personalInfoResult;
			}
			goto IL_0071;
			IL_0071:
			if (6 == 0)
			{
				goto IL_0040;
			}
			_ = profile2.RestClient;
			url = BASE_URL + profile2.Username + URL_ENDP;
			PersonalInfoResult personalInfoResult2 = new PersonalInfoResult();
			if (8u != 0)
			{
				personalInfoResult = personalInfoResult2;
			}
			Step step8 = new Step();
			if (0 == 0)
			{
				step = step8;
			}
			goto IL_00b8;
			IL_0040:
			Logger logger = log;
			LogContext logContext2 = ctx;
			if (8u != 0)
			{
				logger.Info(logContext2, "don't need run again this job. skip process");
			}
			PersonalInfoResult personalInfo = profile2.PersonalInfo;
			if (2u != 0)
			{
				return personalInfo;
			}
			PersonalInfoResult result;
			return result;
		}
		catch (Exception ex)
		{
			log.Error(ctx, ex.ToString());
			return null;
		}
	}

	private StepResult ResolveMe(ref string url, string response, SocialProfile socialProfile)
	{
		DynamicObject dynamicObject = new DynamicObject();
		DynamicObject dynamicObject2;
		if (5u != 0)
		{
			dynamicObject2 = dynamicObject;
		}
		string text = RegexUtils.FindRegex(response, REGEX_01);
		string text2 = default(string);
		if (0 == 0)
		{
			text2 = text;
		}
		List<string> list3 = default(List<string>);
		List<string>.Enumerator enumerator2 = default(List<string>.Enumerator);
		string text6 = default(string);
		while (true)
		{
			if (6u != 0)
			{
				List<string> list = RegexUtils.FindRegexesMatchAll(response, REGEX_02);
				List<string> list2 = new List<string>();
				if (0 == 0)
				{
					list3 = list2;
				}
				List<string>.Enumerator enumerator = list.GetEnumerator();
				if (0 == 0)
				{
					enumerator2 = enumerator;
				}
				goto IL_0047;
			}
			goto IL_00f1;
			IL_0047:
			try
			{
				if (true && false)
				{
					goto IL_004f;
				}
				goto IL_0092;
				IL_004f:
				string current = enumerator2.Current;
				string text3 = RegexUtils.FindRegex(current, REGEX_03);
				string text4;
				if (2u != 0 && 5u != 0)
				{
					text4 = text3;
				}
				string text5 = RegexUtils.FindRegex(current, REGEX_04);
				if ((0 == 0) ? true : false)
				{
					text6 = text5;
				}
				string key = text6;
				if (0 == 0)
				{
					dynamicObject2.Put(key, text4);
				}
				List<string> list4 = list3;
				string item = text6 + "=" + text4;
				if (4u != 0)
				{
					list4.Add(item);
				}
				goto IL_0092;
				IL_0092:
				if (enumerator2.MoveNext())
				{
					goto IL_004f;
				}
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			string fIELD_NAME = FIELD_NAME;
			string value = text2;
			if (2u != 0)
			{
				dynamicObject2.Put(fIELD_NAME, value);
			}
			string fIELD_TEXT = FIELD_TEXT;
			string value2 = string.Join(", ", list3);
			if (5u != 0)
			{
				dynamicObject2.Put(fIELD_TEXT, value2);
			}
			goto IL_00f1;
			IL_00f1:
			if (0 == 0)
			{
				if (0 == 0)
				{
					break;
				}
				goto IL_0047;
			}
		}
		log.Info(ctx, LOG_1 + JsonConvert.SerializeObject(dynamicObject2));
		return StepResult.Of(success: true, dynamicObject2);
	}

	static GetPersonalInfoJob()
	{
		if (8 == 0)
		{
			goto IL_0119;
		}
		CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);
		METHOD_EXEC_SE = "3xJcoFWXCSdIm6X6Uz2RMQ==.DVngHCEU7c8KWUfcp+wyeSUxKbGisr14CUaxiRuGcB4=";
		METHOD_EXEC = SecurityUtils.ReadStructEncrypted(METHOD_EXEC_SE);
		BASE_URL_SE = "FqdDVpabi6Pym7uVoHlHow==.wihk8XHloxxKdMZUSAKTuqtTEPz4qqv/+ATOLjacdhwPDrsji4nbtdVkiYQtYzUG";
		BASE_URL = SecurityUtils.ReadStructEncrypted(BASE_URL_SE);
		if (0 == 0)
		{
			URL_ENDP_SE = "K97vtxPbbAim0Ed3PmpHsA==.3mWf8sFcpIeaASxWoDEwk4+pH7FWtBaSE7tKc66lZYL7/hxty229qB0V5sFqojJ7";
			URL_ENDP = SecurityUtils.ReadStructEncrypted(URL_ENDP_SE);
			REGEX_01_SE = "14Ll8bUCGmKsacDFqFwASg==.6sNcwLWLbPaTFxVhum8TF3VaOWubCasQym2d9Vt4zZSYWXpSpxl9kUphfX6R7Pp9";
			REGEX_01 = SecurityUtils.ReadStructEncrypted(REGEX_01_SE);
			REGEX_02_SE = "+xvO3WSMkzAvXiPUbHnMkA==.cdsNM0+xwwg+uDv8MBa2okSKarURGL/6NtPmsAcP9iBkoQhdRx4GYDtAvfBzoTUECVsPYwqjnhr+S1ArTl0H+qNJ0tEiBemOOWKyJ26voy4=";
			REGEX_02 = SecurityUtils.ReadStructEncrypted(REGEX_02_SE);
			REGEX_03_SE = "a9Jiu0qkwVBwgtD8akjyPA==.ZPf7DT21IrUVPWF3CxNBfyD5lm8iNvbhgXL/RgGeq1I=";
			REGEX_03 = SecurityUtils.ReadStructEncrypted(REGEX_03_SE);
			goto IL_00bb;
		}
		goto IL_0160;
		IL_01b4:
		PHONEM_LINK_SE = "WDBL4XcuhYWZEBoKTjyEmA==.+LnZQ62WFAEkzr/ZM8nevxlPjVtX8GlWsd7LLkNv+w18wVsgB7PRkqcmZksq64ndYhvlnQLpJZahHscA+NAMAA==";
		PHONEM_LINK = SecurityUtils.ReadStructEncrypted(PHONEM_LINK_SE);
		return;
		IL_00bb:
		REGEX_04_SE = "7ImLWvyvnIOORrygcVccqw==.DXqJNdSUHUAC8rK52+qF9T84YlDMhZAHzZk6inONZ+fDmiHMoBu1GgflFeOCCvc4";
		if (8u != 0)
		{
			REGEX_04 = SecurityUtils.ReadStructEncrypted(REGEX_04_SE);
			LOG_1_SE = "rsCCzbqo+oicWFFoLncZ/g==.EhCJcMroet4gx8U5NjdrblQIvQgdvKP5RwdLcwxPC6H2T8lJm8sKmvxPEGd6UBL3";
			LOG_1 = SecurityUtils.ReadStructEncrypted(LOG_1_SE);
			FIELD_NAME_SE = "rgQqcAfk6mhnouRqB/5XaA==.R0mq9rq4iYIGIsijK8Y4hQ5yTHTJFAiL2Vk2RckYXwM=";
			if (false)
			{
				goto IL_019b;
			}
			FIELD_NAME = SecurityUtils.ReadStructEncrypted(FIELD_NAME_SE);
		}
		goto IL_010f;
		IL_0119:
		FIELD_TEXT = SecurityUtils.ReadStructEncrypted(FIELD_TEXT_SE);
		if (true)
		{
			if (1 == 0)
			{
				goto IL_010f;
			}
			URL_1_SE = "V8Xh+bWocvbPBnrqCUqYpw==.0w/BrXP9aIuHKuK8M779G0va4z7J0ltqGsXJzWVo5Yw+GD5hIhLxCm1sxIFMnObXm5hYbNWW7TT86l7FS9kpVSdj9ZpcrfvNw7GGHyGCnGjjlG/yQ3frimbD9j5UVHiEheZrgKmDOTB6kw7pyXmiew==";
			URL_1 = SecurityUtils.ReadStructEncrypted(URL_1_SE);
			URL_2_SE = "9mQR9/NYVYgxlyFbntVgUA==.CkpU+x6FrYIkO5g8Gs0l3Wkgc83EnOzYd+74EtAwJoR99u/LyICsFiSjgt984LCmc0KRk/OrARFv+yU2bx1n/Q==";
			URL_2 = SecurityUtils.ReadStructEncrypted(URL_2_SE);
			goto IL_0160;
		}
		if (1 == 0)
		{
			goto IL_019b;
		}
		goto IL_01b4;
		IL_019b:
		BODM_LINK_SE = "RtR0QRPiUoWIvL1bCAWPHg==.dPfcr+C8ADEpxBZXan1YjhJj9aDQ6RUZcm+yu3L6k+eirYmFVvu+nWkMQ0MlPHUpyAwkpu1yEToJspy5/dYKcjELfJRYQwWyFfgzDeS7AZCMzMi1z2kJBQb6ClIRwZRn";
		BODM_LINK = SecurityUtils.ReadStructEncrypted(BODM_LINK_SE);
		goto IL_01b4;
		IL_010f:
		FIELD_TEXT_SE = "dOS9T2vJUFSPoknKq7fF4w==.wsBAWI/VFH0jovfiqugBvDi5CSm8Jou5OmmicAlPz78=";
		goto IL_0119;
		IL_0160:
		DOB_LINK_SE = "h5UoImdrk698opqxu1qAkQ==.ud+tW2EBgNkovgHT7LHWbR5ncvyTgbDFatMugA2NrLI=";
		DOB_LINK = SecurityUtils.ReadStructEncrypted(DOB_LINK_SE);
		PHONE_LINK_SE = "9OKVd/7nk8A/ke5tSZ4wEQ==.HUbuvI+I4hr8snnzKh9L4CKO9Qt40iWkdok6JGC5pSWtIfGwyO/0d6GsGzQehQWa";
		if (false)
		{
			goto IL_00bb;
		}
		PHONE_LINK = SecurityUtils.ReadStructEncrypted(PHONE_LINK_SE);
		goto IL_019b;
	}
}
