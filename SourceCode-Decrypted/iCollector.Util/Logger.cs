using System;
using System.Text;
using System.Threading;

namespace iCollector.Util;

internal class Logger
{
	private static readonly object _lock = new object();

	private static Logger INSTANCE;

	private StringBuilder buffer = new StringBuilder();

	public static Logger Instance()
	{
		object obj = default(object);
		if (true)
		{
			if (-1 == 0 || INSTANCE != null)
			{
				goto IL_005d;
			}
			object @lock = _lock;
			if (6u != 0 && 0 == 0)
			{
				obj = @lock;
			}
		}
		bool lockTaken = default(bool);
		if (((6u != 0) ? true : false) && 0 == 0)
		{
			lockTaken = false;
		}
		try
		{
			object obj2 = obj;
			if (2 == 0)
			{
				goto IL_0026;
			}
			if (0 == 0)
			{
				Monitor.Enter(obj2, ref lockTaken);
			}
			goto IL_0041;
			IL_0026:
			if (INSTANCE == null)
			{
				goto IL_002d;
			}
			goto end_IL_001e;
			IL_002d:
			if (8 == 0)
			{
				goto IL_0041;
			}
			INSTANCE = new Logger();
			goto end_IL_001e;
			IL_0041:
			if (uint.MaxValue != 0)
			{
				goto IL_0026;
			}
			goto IL_002d;
			end_IL_001e:;
		}
		finally
		{
			if (0 == 0 && 0 == 0 && lockTaken)
			{
				Monitor.Exit(obj);
			}
		}
		goto IL_005d;
		IL_005d:
		return INSTANCE;
	}

	public void Clear()
	{
		buffer = new StringBuilder();
	}

	public void Info(LogContext ctx, string message)
	{
		if (0 == 0 && 8u != 0)
		{
			WriteLine(ctx, "INFO", message);
		}
	}

	public void Error(LogContext ctx, string message)
	{
		if (0 == 0 && 8u != 0)
		{
			WriteLine(ctx, "ERROR", message);
		}
	}

	private void WriteLine(LogContext ctx, string level, string message)
	{
		DateTime utcNow = DateTime.UtcNow;
		DateTime dateTime = default(DateTime);
		if (2u != 0 && 0 == 0)
		{
			dateTime = utcNow;
		}
		DateTime dateTime2 = dateTime.AddHours(7.0);
		if (0 == 0 && 5u != 0)
		{
			dateTime = dateTime2;
		}
		string text = dateTime.ToString("dd-MM-yyyy hh:mm:ss");
		string text2;
		if (5u != 0 && 5u != 0)
		{
			text2 = text;
		}
		buffer.AppendLine($"{text2} {level} {ctx.Log()}: {message}");
		string value = $"{text2} {level} {ctx.Log()}: {message}";
		if (6u != 0 && 0 == 0)
		{
			Console.WriteLine(value);
		}
	}

	public string GetLogContent()
	{
		return buffer.ToString();
	}
}
