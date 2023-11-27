using System;
using System.Collections.Generic;
using System.Threading;

namespace iCollector.Util;

internal class ListUtils
{
	private static int seed = Environment.TickCount;

	private static readonly ThreadLocal<Random> random = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

	public static bool IsEmpty<T>(List<T> list)
	{
		if (list != null)
		{
			return list.Count == 0;
		}
		return true;
	}

	public static List<List<T>> to2DList<T>(List<T> source, int size)
	{
		List<List<T>> list2 = default(List<List<T>>);
		List<T> list4 = default(List<T>);
		if (0 == 0)
		{
			List<List<T>> list = new List<List<T>>();
			if (4u != 0 && 0 == 0)
			{
				list2 = list;
			}
			List<T> list3 = new List<T>();
			if (0 == 0)
			{
				list4 = list3;
			}
		}
		List<T>.Enumerator enumerator = source.GetEnumerator();
		List<T>.Enumerator enumerator2 = default(List<T>.Enumerator);
		if (0 == 0)
		{
			enumerator2 = enumerator;
		}
		try
		{
			if (5 == 0)
			{
				goto IL_0038;
			}
			goto IL_0058;
			IL_0038:
			List<T> list5 = list4;
			T val = default(T);
			T item = val;
			if (2u != 0 && 8u != 0)
			{
				list5.Add(item);
			}
			if (list4.Count == size)
			{
				List<List<T>> list6 = list2;
				List<T> item2 = list4;
				if (0 == 0 && 0 == 0)
				{
					list6.Add(item2);
				}
				goto IL_004f;
			}
			goto IL_0058;
			IL_004f:
			List<T> list7 = new List<T>();
			if (0 == 0)
			{
				list4 = list7;
			}
			goto IL_0058;
			IL_0058:
			if (enumerator2.MoveNext())
			{
				T current = enumerator2.Current;
				if (0 == 0 && uint.MaxValue != 0)
				{
					val = current;
				}
				goto IL_0038;
			}
			if ((-1 == 0) ? true : false)
			{
				goto IL_004f;
			}
		}
		finally
		{
			((IDisposable)enumerator2).Dispose();
		}
		if (list4.Count > 0)
		{
			List<List<T>> list8 = list2;
			List<T> item3 = list4;
			if (0 == 0)
			{
				list8.Add(item3);
			}
		}
		return list2;
	}

	public static T Rand<T>(List<T> list)
	{
		int index = default(int);
		if (true)
		{
			int num = random.Value.Next(0, list.Count);
			if ((false || 3u != 0 || 1 == 0) && 0 == 0)
			{
				index = num;
			}
		}
		return list[index];
	}

	public static T Rand<T>(List<T> list, List<T> except)
	{
		T val2 = default(T);
		if (3u != 0)
		{
			T val = Rand(list);
			if (5u != 0 && 0 == 0)
			{
				val2 = val;
			}
			goto IL_000d;
		}
		goto IL_0042;
		IL_002b:
		int num;
		if (num != 0)
		{
			goto IL_002d;
		}
		goto IL_0042;
		IL_003d:
		int num2 = default(int);
		if (num2 < 10)
		{
			T val3 = Rand(list);
			if (6u != 0 && 3u != 0)
			{
				val2 = val3;
			}
			num = (except.Contains(val2) ? 1 : 0);
			goto IL_002b;
		}
		goto IL_0042;
		IL_000d:
		int num3;
		if (0 == 0)
		{
			num3 = 0;
			if (num3 != 0)
			{
				goto IL_002e;
			}
			if (0 == 0 && 0 == 0)
			{
				num2 = num3;
			}
		}
		goto IL_0037;
		IL_0042:
		if (0 == 0)
		{
			return val2;
		}
		goto IL_002d;
		IL_0037:
		while (8u != 0)
		{
			if (3 == 0)
			{
				continue;
			}
			goto IL_003d;
		}
		goto IL_000d;
		IL_002d:
		num3 = num2;
		goto IL_002e;
		IL_002e:
		num = num3 + 1;
		if (3 == 0)
		{
			goto IL_002b;
		}
		if (5u != 0 && 7u != 0)
		{
			num2 = num;
		}
		goto IL_0037;
	}
}
