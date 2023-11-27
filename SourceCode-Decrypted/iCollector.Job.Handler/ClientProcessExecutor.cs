using System;
using System.Diagnostics;
using System.IO;
using iCollector.Job.Model;
using iCollector.Util;

namespace iCollector.Job.Handler;

internal class ClientProcessExecutor
{
	private Logger log = Logger.Instance();

	private static string CLAZZ_NAME_SE;

	private static string CLAZZ_NAME;

	private static string ARGS_PARAM_SE;

	private static string ARGS_PARAM;

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	public string RequestGet(ClientProcess cp, string url)
	{
		Process process = new Process();
		ProcessStartInfo obj = new ProcessStartInfo
		{
			FileName = cp.ExecutorPath,
			Arguments = ARGS_PARAM + url,
			RedirectStandardOutput = true,
			CreateNoWindow = true,
			WindowStyle = ProcessWindowStyle.Hidden,
			WorkingDirectory = Path.GetTempPath()
		};
		if (0 == 0 && 5u != 0)
		{
			obj.UseShellExecute = false;
		}
		if (4u != 0 && 3u != 0)
		{
			process.StartInfo = obj;
		}
		Process process2;
		if (6u != 0 && 5u != 0)
		{
			process2 = process;
		}
		try
		{
			process2.Start();
			string result = process2.StandardOutput.ReadToEnd();
			string result2 = default(string);
			if (4u != 0)
			{
				if (0 == 0)
				{
					return result;
				}
				return result2;
			}
			return result2;
		}
		catch (Exception ex)
		{
			log.Error(ctx, ex.ToString());
			return "";
		}
	}

	static ClientProcessExecutor()
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
			CLAZZ_NAME_SE = "ClientProcessExecutor";
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
				ARGS_PARAM_SE = "--headless --disable-gpu --disable-logging --dump-dom ";
				if (3 == 0)
				{
					goto IL_0006;
				}
				ARGS_PARAM = SecurityUtils.ReadStructEncrypted(ARGS_PARAM_SE);
				num = 0;
			}
			goto IL_0042;
		}
	}
}
