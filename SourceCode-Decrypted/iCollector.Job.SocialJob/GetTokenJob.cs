using System.Collections.Generic;
using iCollector.Job.Model;
using iCollector.Model;
using iCollector.Util;

namespace iCollector.Job.SocialJob;

internal class GetTokenJob
{
	private static string CLAZZ_NAME_SE = "GetTokenJob";

	private static string CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);

	private Logger log = Logger.Instance();

	private JobExecutor executor = new JobExecutor();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	public GetTokenResult Execute(SocialProfile profile)
	{
		if (false)
		{
			goto IL_0036;
		}
		if (4u != 0)
		{
			if (4u != 0)
			{
				LogContext logContext = ctx;
				if (0 == 0 && 0 == 0)
				{
					logContext.MethodName = "Execute";
				}
				goto IL_001c;
			}
			goto IL_0065;
		}
		if (4 == 0)
		{
			goto IL_0082;
		}
		goto IL_0096;
		IL_0036:
		string text = new GetEAAGTokenJob().Execute(profile);
		string text2 = default(string);
		if (0 == 0 && 0 == 0)
		{
			text2 = text;
		}
		GetTokenResult getTokenResult = default(GetTokenResult);
		string text4 = default(string);
		if (true)
		{
			if (!string.IsNullOrEmpty(text2))
			{
				List<string> tokens = getTokenResult.Tokens;
				string item = text2;
				if (0 == 0)
				{
					tokens.Add(item);
				}
				goto IL_0065;
			}
			string text3 = new GetEAABTokenJob().Execute(profile);
			if (0 == 0)
			{
				text4 = text3;
			}
			if (0 == 0)
			{
				goto IL_0082;
			}
			goto IL_0096;
		}
		goto IL_0028;
		IL_0065:
		if (0 == 0)
		{
			goto IL_0096;
		}
		goto IL_001c;
		IL_0082:
		if (!string.IsNullOrEmpty(text4))
		{
			List<string> tokens2 = getTokenResult.Tokens;
			string item2 = text4;
			if (0 == 0)
			{
				tokens2.Add(item2);
			}
		}
		goto IL_0096;
		IL_0096:
		Logger logger = log;
		LogContext logContext2 = ctx;
		string message = "TokenResult: " + string.Join("\n", getTokenResult.Tokens);
		if (3u != 0)
		{
			logger.Info(logContext2, message);
		}
		return getTokenResult;
		IL_0028:
		GetTokenResult getTokenResult2 = getTokenResult;
		List<string> tokens3 = new List<string>();
		if (4u != 0 && 0 == 0)
		{
			getTokenResult2.Tokens = tokens3;
		}
		goto IL_0036;
		IL_001c:
		GetTokenResult getTokenResult3 = new GetTokenResult();
		if (0 == 0 && uint.MaxValue != 0)
		{
			getTokenResult = getTokenResult3;
		}
		goto IL_0028;
	}
}
