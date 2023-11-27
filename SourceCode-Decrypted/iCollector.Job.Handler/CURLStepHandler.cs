using System.Net.Http;
using System.Threading;
using iCollector.Function.CURL.Model;
using iCollector.Job.Model;
using iCollector.RestClient;
using iCollector.RestClient.Model;
using iCollector.Util;

namespace iCollector.Job.Handler;

internal class CURLStepHandler : IStepHandler
{
	private static string CLAZZ_NAME_SE = "CURLStepHandler";

	private static string CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);

	private static readonly string LOG_01_1_SE = "Start process step ";

	private static readonly string LOG_01_1 = SecurityUtils.ReadStructEncrypted(LOG_01_1_SE);

	private static readonly string LOG_01_2_SE;

	private static readonly string LOG_01_2;

	private static readonly string LOG_01_3_SE;

	private static readonly string LOG_01_3;

	private static readonly string LOG_02_1_SE;

	private static readonly string LOG_02_1;

	private static readonly string LOG_02_2_SE;

	private static readonly string LOG_02_2;

	private static readonly string LOG_03_1_SE;

	private static readonly string LOG_03_1;

	private static readonly string LOG_03_2_SE;

	private static readonly string LOG_03_2;

	private static readonly string LOG_03_3_SE;

	private static readonly string LOG_03_3;

	private static readonly string METHOD_HANDLE_SE;

	private static readonly string METHOD_HANDLE;

	private readonly Logger log = Logger.Instance();

	private readonly LogContext ctx = new LogContext(CLAZZ_NAME);

	public void Handle(JobContext jobCtx, Step step)
	{
		LogContext logContext = ctx;
		string mETHOD_HANDLE = METHOD_HANDLE;
		if (0 == 0)
		{
			logContext.MethodName = mETHOD_HANDLE;
		}
		CURLStepSpec obj = (CURLStepSpec)step.Spec;
		CURLStepSpec cURLStepSpec = default(CURLStepSpec);
		if (0 == 0)
		{
			cURLStepSpec = obj;
		}
		IRestClient obj2 = ((cURLStepSpec.RestClient == null) ? CreateClient(cURLStepSpec) : cURLStepSpec.RestClient);
		IRestClient restClient;
		if (5u != 0)
		{
			restClient = obj2;
		}
		CurlResponse<string> curlResponse;
		if (true)
		{
			curlResponse = null;
		}
		bool flag = default(bool);
		while (true)
		{
			bool num2;
			bool num3;
			if (2u != 0)
			{
				Logger logger = log;
				LogContext logContext2 = ctx;
				string[] obj3 = new string[6] { LOG_01_1, null, null, null, null, null };
				int index = step.Index;
				int num;
				if (8u != 0)
				{
					num = index;
				}
				obj3[1] = num.ToString();
				obj3[2] = LOG_01_2;
				obj3[3] = step.Name;
				obj3[4] = LOG_01_3;
				obj3[5] = cURLStepSpec?.ToString();
				string message = string.Concat(obj3);
				if (0 == 0)
				{
					logger.Info(logContext2, message);
				}
				if (4u != 0)
				{
					step.Status = StepStatus.PROCESSING;
				}
				num2 = cURLStepSpec.Method == null;
				if (-1 == 0)
				{
					goto IL_0171;
				}
				if (!num2)
				{
					num3 = cURLStepSpec.Method == HttpMethod.Get;
					while (!num3)
					{
						num3 = cURLStepSpec.Method == HttpMethod.Post;
						if (2 == 0)
						{
							continue;
						}
						goto IL_011d;
					}
				}
			}
			if (false)
			{
				continue;
			}
			CurlResponse<string> curlResponse2 = restClient.Get(cURLStepSpec.Url, cURLStepSpec.Headers);
			if (2u != 0)
			{
				curlResponse = curlResponse2;
			}
			goto IL_014a;
			IL_0250:
			step.StepResult = new StepResult
			{
				Success = flag
			};
			break;
			IL_0171:
			if (num2 && step.CheckResultFunc != null)
			{
				StepResult stepResult = step.CheckResultFunc(curlResponse.Body);
				if (0 == 0)
				{
					step.StepResult = stepResult;
				}
				flag = step.StepResult.Success;
			}
			if (flag)
			{
				log.Info(ctx, LOG_02_1 + step.Index + LOG_02_2 + step.Name);
				step.Status = StepStatus.SUCCESS;
			}
			else
			{
				step.Status = StepStatus.FAILED;
				log.Info(ctx, LOG_03_1 + step.Index + LOG_03_2 + step.Name + LOG_03_3 + curlResponse);
			}
			if (step.StepResult != null)
			{
				break;
			}
			goto IL_0250;
			IL_014a:
			int num4;
			if (curlResponse.Success)
			{
				num4 = ((!string.IsNullOrEmpty(curlResponse.Body)) ? 1 : 0);
			}
			else
			{
				if (false)
				{
					goto IL_0250;
				}
				num4 = 0;
			}
			if (0 == 0)
			{
				flag = (byte)num4 != 0;
			}
			num2 = flag;
			goto IL_0171;
			IL_011d:
			if (num3)
			{
				CurlResponse<string> curlResponse3 = restClient.Post(cURLStepSpec.Url, cURLStepSpec.RequestBody, cURLStepSpec.Headers);
				if (8u != 0)
				{
					curlResponse = curlResponse3;
				}
				if (0 == 0)
				{
					Thread.Sleep(7000);
				}
			}
			goto IL_014a;
		}
	}

	public StepType GetStepType()
	{
		return StepType.CURL;
	}

	private IRestClient CreateClient(CURLStepSpec spec)
	{
		string uA2 = default(string);
		do
		{
			string uA = spec.UA;
			if (0 == 0 && 0 == 0)
			{
				uA2 = uA;
			}
		}
		while (8 == 0);
		string identityHeader = spec.IdentityHeader;
		string identityHeader2;
		if (8u != 0 && 4u != 0)
		{
			identityHeader2 = identityHeader;
		}
		RestOptions obj = new RestOptions
		{
			UA = uA2
		};
		if (4u != 0 && 0 == 0)
		{
			obj.IdentityHeader = identityHeader2;
		}
		return new DefaultRestClient(obj);
	}

	static CURLStepHandler()
	{
		do
		{
			LOG_01_2_SE = " Name=";
			LOG_01_2 = SecurityUtils.ReadStructEncrypted(LOG_01_2_SE);
			LOG_01_3_SE = ", Spec: ";
			LOG_01_3 = SecurityUtils.ReadStructEncrypted(LOG_01_3_SE);
			LOG_02_1_SE = "Success process step ";
		}
		while (false);
		LOG_02_1 = SecurityUtils.ReadStructEncrypted(LOG_02_1_SE);
		LOG_02_2_SE = " Name=";
		LOG_02_2 = SecurityUtils.ReadStructEncrypted(LOG_02_2_SE);
		LOG_03_1_SE = "Failed process step ";
		LOG_03_1 = SecurityUtils.ReadStructEncrypted(LOG_03_1_SE);
		LOG_03_2_SE = " Name=";
		LOG_03_2 = SecurityUtils.ReadStructEncrypted(LOG_03_2_SE);
		LOG_03_3_SE = ", Response: ";
		LOG_03_3 = SecurityUtils.ReadStructEncrypted(LOG_03_3_SE);
		METHOD_HANDLE_SE = "Handle";
		METHOD_HANDLE = SecurityUtils.ReadStructEncrypted(METHOD_HANDLE_SE);
	}
}
