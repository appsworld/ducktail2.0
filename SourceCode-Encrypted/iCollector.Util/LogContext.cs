namespace iCollector.Util;

internal class LogContext
{
	public static string Profile { get; set; }

	public string ClassName { get; set; }

	public string MethodName { get; set; }

	public LogContext(string ClassName)
	{
		this.ClassName = ClassName;
	}

	public string Log()
	{
		return ClassName + "." + MethodName + " [" + Profile + "]";
	}
}
