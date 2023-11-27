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
	private static string CLAZZ_NAME_SE = "k8y35ZJuJ48Zw1Kd0uIjZg==.USx27tgfR4/BF759MssOBh/oSNk3TogPKykGTx7Z3bM=";

	private static string CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);

	private static readonly string LOG_01_1_SE = "4cLaoCANSswqdMeY/VXo8Q==.LfLFBRDuB6L9c4EMCZA06kNB9/G8q1eFphpPXTaeV41VmiRAgxVoYp96B1KXnDu0";

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
			LOG_01_2_SE = "AljM4AtPjinl27sa8dVU8Q==.V+rUuiOEptUsV5Vs/8f7iFA5dazqeqlySq2FYOdE4kI=";
			LOG_01_2 = SecurityUtils.ReadStructEncrypted(LOG_01_2_SE);
			LOG_01_3_SE = "xaJvvd9RKVCs2nnN8tLKrw==.OUD4/T/U/NBi6wOaXuFZlbdQun9cSa6V00pp64ooYCQ=";
			LOG_01_3 = SecurityUtils.ReadStructEncrypted(LOG_01_3_SE);
			LOG_02_1_SE = "xSPjV+WNdRORC5w0NVvxHA==.wcYW7/amBabwJZF8lTKsw9fnkuOEWJKxfAZLMeg8VKfWBtlfVUmyzub4jr2UOOME";
		}
		while (false);
		LOG_02_1 = SecurityUtils.ReadStructEncrypted(LOG_02_1_SE);
		LOG_02_2_SE = "dEs0SFWLKhCNrlYeXuRD/w==.Gq7sVL0NWMmapClbU/hW+eSAxoZOtGl4v6vhuA7oo3w=";
		LOG_02_2 = SecurityUtils.ReadStructEncrypted(LOG_02_2_SE);
		LOG_03_1_SE = "frDy85zgSj71dQ2yoTjNgA==.n/0TipbJfAw8IlX98og0Y3jy7teyO1N85VWjqJkIN2cRt97L/gv/nSpw++GSE0tM";
		LOG_03_1 = SecurityUtils.ReadStructEncrypted(LOG_03_1_SE);
		LOG_03_2_SE = "3nDJcwxkPAqzb4N8mIBH4A==.esvShIkWwo2+NsiXfC+vvPlyKJ7bQoATAnHCIDMFj4U=";
		LOG_03_2 = SecurityUtils.ReadStructEncrypted(LOG_03_2_SE);
		LOG_03_3_SE = "dFh6HeK8xcfDbr7mbI7kTw==.3F2lu/5GWyULu1TyYe6IEwTP7bGRgf0N+7AyWFAGHYI=";
		LOG_03_3 = SecurityUtils.ReadStructEncrypted(LOG_03_3_SE);
		METHOD_HANDLE_SE = "dkVf2CO9rSSOYRt7osV7ew==.RiKpNd//V4BQpIUiKcb5GgJl1bQUyri+rnkWzseQTlg=";
		METHOD_HANDLE = SecurityUtils.ReadStructEncrypted(METHOD_HANDLE_SE);
	}
}
