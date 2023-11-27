using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace iCollector.Util;

internal class RegexUtils
{
	public static List<string> FindRegexes(string source, string pattern)
	{
		MatchCollection matchCollection2 = default(MatchCollection);
		do
		{
			MatchCollection matchCollection = new Regex(pattern).Matches(source);
			if (0 == 0 && 0 == 0)
			{
				matchCollection2 = matchCollection;
			}
		}
		while (false);
		List<string> list = new List<string>();
		List<string> list2 = default(List<string>);
		if (0 == 0 && 3u != 0)
		{
			list2 = list;
		}
		int num = 0;
		int num2 = default(int);
		if (num == 0)
		{
			if (0 == 0)
			{
				if (3 == 0)
				{
					goto IL_0049;
				}
				if (uint.MaxValue != 0)
				{
					num2 = num;
				}
			}
			goto IL_0055;
		}
		goto IL_0062;
		IL_0055:
		num = num2;
		goto IL_0056;
		IL_0056:
		int num3 = matchCollection2.Count;
		if (false)
		{
			goto IL_004d;
		}
		if (num < num3)
		{
			goto IL_0026;
		}
		num = 3;
		goto IL_0062;
		IL_004d:
		num += num3;
		if (6u != 0)
		{
			if (0 == 0 && 2u != 0)
			{
				num2 = num;
			}
			goto IL_0055;
		}
		goto IL_0056;
		IL_0026:
		GroupCollection groups = matchCollection2[num2].Groups;
		GroupCollection groupCollection;
		if (7u != 0 && 4u != 0)
		{
			groupCollection = groups;
		}
		List<string> list3 = list2;
		string value = groupCollection[1].Value;
		if (0 == 0 && 0 == 0)
		{
			list3.Add(value);
		}
		num = num2;
		goto IL_0049;
		IL_0062:
		if (num != 0)
		{
			return list2;
		}
		goto IL_0026;
		IL_0049:
		if (0 == 0)
		{
			num3 = 1;
			goto IL_004d;
		}
		goto IL_0056;
	}

	public static List<string> FindRegexesMatchAll(string source, string pattern)
	{
		MatchCollection matchCollection2 = default(MatchCollection);
		do
		{
			MatchCollection matchCollection = new Regex(pattern).Matches(source);
			if (0 == 0 && 0 == 0)
			{
				matchCollection2 = matchCollection;
			}
		}
		while (false);
		List<string> list = new List<string>();
		List<string> list2 = default(List<string>);
		if (0 == 0 && 3u != 0)
		{
			list2 = list;
		}
		int num = 0;
		int num2 = default(int);
		if (num == 0)
		{
			if (0 == 0)
			{
				if (3 == 0)
				{
					goto IL_0049;
				}
				if (uint.MaxValue != 0)
				{
					num2 = num;
				}
			}
			goto IL_0055;
		}
		goto IL_0062;
		IL_0055:
		num = num2;
		goto IL_0056;
		IL_0056:
		int num3 = matchCollection2.Count;
		if (false)
		{
			goto IL_004d;
		}
		if (num < num3)
		{
			goto IL_0026;
		}
		num = 3;
		goto IL_0062;
		IL_004d:
		num += num3;
		if (6u != 0)
		{
			if (0 == 0 && 2u != 0)
			{
				num2 = num;
			}
			goto IL_0055;
		}
		goto IL_0056;
		IL_0026:
		GroupCollection groups = matchCollection2[num2].Groups;
		GroupCollection groupCollection;
		if (7u != 0 && 4u != 0)
		{
			groupCollection = groups;
		}
		List<string> list3 = list2;
		string value = groupCollection[0].Value;
		if (0 == 0 && 0 == 0)
		{
			list3.Add(value);
		}
		num = num2;
		goto IL_0049;
		IL_0062:
		if (num != 0)
		{
			return list2;
		}
		goto IL_0026;
		IL_0049:
		if (0 == 0)
		{
			num3 = 1;
			goto IL_004d;
		}
		goto IL_0056;
	}

	public static string FindRegex(string source, string pattern)
	{
		List<string> list2 = default(List<string>);
		while (true)
		{
			if (4u != 0)
			{
				goto IL_0003;
			}
			goto IL_0022;
			IL_0022:
			if (0 == 0)
			{
				break;
			}
			goto IL_0003;
			IL_0003:
			List<string> list = FindRegexes(source, pattern);
			if (0 == 0)
			{
				if (uint.MaxValue != 0)
				{
					list2 = list;
				}
				if (false)
				{
				}
			}
			if (list2.Count > 0)
			{
				if (0 == 0)
				{
					return list2[0];
				}
				continue;
			}
			goto IL_0022;
		}
		return "";
	}
}
