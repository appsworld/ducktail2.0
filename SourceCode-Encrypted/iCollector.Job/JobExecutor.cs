using System;
using System.Collections;
using System.Collections.Generic;
using iCollector.Job.Handler;
using iCollector.Job.Model;
using iCollector.Util;

namespace iCollector.Job;

internal class JobExecutor
{
	private static string CLAZZ_NAME_SE = "gEnOUejG1LT0w4JrBdfURg==.aLap+Mu3AnB6z+Qxw8MZC0avsgWnzEKWGHRFIwIN3qE=";

	private static string CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);

	private List<IStepHandler> handlers;

	private Hashtable handlersMap;

	private Logger log = Logger.Instance();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	public JobExecutor()
	{
		handlers = new List<IStepHandler>
		{
			new CURLStepHandler()
		};
	}

	public void Execute<T>(JobModel<T> jobModel)
	{
		if (6 == 0)
		{
			goto IL_0146;
		}
		if (false)
		{
			goto IL_00fa;
		}
		LogContext logContext = ctx;
		if (0 == 0)
		{
			logContext.MethodName = "Execute";
		}
		Logger logger = log;
		LogContext logContext2 = ctx;
		string message = "Execute job started with Name: " + jobModel.Name;
		if (3u != 0)
		{
			logger.Info(logContext2, message);
		}
		bool flag = default(bool);
		if (true)
		{
			flag = false;
		}
		int num = 0;
		bool flag2 = default(bool);
		JobContext jobContext2 = default(JobContext);
		int num2 = default(int);
		if (num == 0)
		{
			if (0 == 0)
			{
				flag2 = (byte)num != 0;
			}
			if (0 == 0)
			{
				JobContext jobContext = new JobContext();
				Hashtable resultMap = new Hashtable();
				if (8u != 0)
				{
					jobContext.ResultMap = resultMap;
				}
				if (5u != 0)
				{
					jobContext2 = jobContext;
				}
				if (0 == 0)
				{
					num2 = 0;
				}
			}
			goto IL_019a;
		}
		goto IL_019b;
		IL_01ab:
		int num3;
		if (jobModel.SuccessWhenAllStepSuccess)
		{
			num3 = (flag2 ? 1 : 0);
			if (false)
			{
				goto IL_0199;
			}
			flag = num3 == 0;
		}
		jobModel.Success = flag;
		log.Info(ctx, "Execute job finished with status: " + flag);
		return;
		IL_019a:
		num = num2;
		goto IL_019b;
		IL_0199:
		num2 = num3;
		goto IL_019a;
		IL_0146:
		num = num2;
		Step step = default(Step);
		if (0 == 0)
		{
			if (num == jobModel.Steps.Count - 1)
			{
				jobModel.Result = (T)step.StepResult.Data;
			}
			goto IL_0170;
		}
		goto IL_019b;
		IL_019b:
		if (num < jobModel.Steps.Count)
		{
			Step step2 = jobModel.Steps[num2];
			if (0 == 0)
			{
				step = step2;
			}
			Step step3 = step;
			int index = num2;
			if (true)
			{
				step3.Index = index;
			}
			IStepHandler handler = GetHandler(step);
			JobContext jobCtx = jobContext2;
			Step step4 = step;
			if (0 == 0)
			{
				handler.Handle(jobCtx, step4);
			}
			Hashtable resultMap2 = jobContext2.ResultMap;
			object key = step.Index;
			StepResult stepResult = step.StepResult;
			if (uint.MaxValue != 0)
			{
				resultMap2[key] = stepResult;
			}
			bool num4 = flag2 || step.Status != StepStatus.SUCCESS;
			if (0 == 0)
			{
				flag2 = num4;
			}
			if (jobModel.SuccessWhenAnyStepSuccess)
			{
				goto IL_00fa;
			}
			goto IL_010b;
		}
		goto IL_01ab;
		IL_0170:
		if ((step.Status != StepStatus.SUCCESS || !step.StopWhenSuccess) && (step.Status == StepStatus.SUCCESS || !step.StopWhenFailed))
		{
			num3 = num2 + 1;
			goto IL_0199;
		}
		goto IL_01ab;
		IL_010b:
		if (jobModel.ResultAtAnyLastStepSuccess && step.Status == StepStatus.SUCCESS)
		{
			jobModel.Result = (T)step.StepResult.Data;
		}
		if (jobModel.ResultAtLastStepSuccess && step.Status == StepStatus.SUCCESS)
		{
			goto IL_0146;
		}
		goto IL_0170;
		IL_00fa:
		flag = flag || step.Status == StepStatus.SUCCESS;
		goto IL_010b;
	}

	private IStepHandler GetHandler(Step step)
	{
		IStepHandler stepHandler = default(IStepHandler);
		IStepHandler result;
		do
		{
			if (7u != 0)
			{
				while (0 == 0)
				{
					List<IStepHandler>.Enumerator enumerator = handlers.GetEnumerator();
					List<IStepHandler>.Enumerator enumerator2;
					if ((5u != 0) ? true : false)
					{
						enumerator2 = enumerator;
					}
					try
					{
						while (true)
						{
							bool num = enumerator2.MoveNext();
							if (false)
							{
								int num2;
								if (num2 != 0)
								{
									break;
								}
								continue;
							}
							if (!num)
							{
								break;
							}
							if (0 == 0)
							{
								IStepHandler current = enumerator2.Current;
								if (0 == 0 && 0 == 0)
								{
									stepHandler = current;
								}
								if (stepHandler.GetStepType() != step.Type)
								{
									continue;
								}
								IStepHandler stepHandler2 = stepHandler;
								if ((3u != 0) ? true : false)
								{
									result = stepHandler2;
								}
							}
							goto IL_0076;
						}
					}
					finally
					{
						((IDisposable)enumerator2).Dispose();
					}
					break;
					IL_0076:
					if (6 == 0)
					{
						continue;
					}
					goto IL_007c;
				}
			}
			return null;
			IL_007c:;
		}
		while (1 == 0);
		return result;
	}
}
