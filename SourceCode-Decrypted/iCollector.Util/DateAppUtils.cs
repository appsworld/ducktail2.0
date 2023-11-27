using System;

namespace iCollector.Util;

internal class DateAppUtils
{
	public static DateTime NewDateTime(int year, int month, int day)
	{
		return new DateTime(year, month, day);
	}

	public static DateTime AdMcs(DateTime source, long microseconds)
	{
		return source.AddMilliseconds(microseconds / 1000);
	}
}
