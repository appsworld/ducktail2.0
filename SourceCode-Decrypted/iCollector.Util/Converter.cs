using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace iCollector.Util;

internal class Converter
{
	public static string ConvertToString(DynamicObject obj)
	{
		while (obj == null || obj.Root == null)
		{
			if (0 == 0)
			{
				return null;
			}
		}
		return JsonConvert.SerializeObject(obj.Root);
	}

	public static string ConvertToString(List<DynamicObject> objs)
	{
		if (objs == null)
		{
			goto IL_000e;
		}
		int count = objs.Count;
		JArray jArray2 = default(JArray);
		if (5u != 0)
		{
			if (count == 0)
			{
				goto IL_000e;
			}
			JArray jArray = new JArray();
			if (8u != 0 && 0 == 0)
			{
				jArray2 = jArray;
			}
		}
		else if (count == 0)
		{
			goto IL_0088;
		}
		List<DynamicObject>.Enumerator enumerator = objs.GetEnumerator();
		List<DynamicObject>.Enumerator enumerator2;
		if (4u != 0 && 3u != 0)
		{
			enumerator2 = enumerator;
		}
		try
		{
			while (7u != 0)
			{
				while (true)
				{
					int num = 6;
					while (num != 0)
					{
						num = (enumerator2.MoveNext() ? 1 : 0);
						if (false)
						{
							continue;
						}
						goto IL_0053;
					}
					break;
					IL_0053:
					if (num == 0)
					{
						break;
					}
					DynamicObject current = enumerator2.Current;
					DynamicObject dynamicObject;
					if (8u != 0 && 8u != 0)
					{
						dynamicObject = current;
					}
					JArray jArray3 = jArray2;
					JObject root = dynamicObject.Root;
					if (2u != 0)
					{
						if (true)
						{
							jArray3.Add(root);
						}
						if (5u != 0 && false)
						{
							continue;
						}
					}
					goto IL_0043;
				}
				break;
				IL_0043:;
			}
		}
		finally
		{
			((IDisposable)enumerator2).Dispose();
		}
		goto IL_0088;
		IL_0088:
		return JsonConvert.SerializeObject(jArray2);
		IL_000e:
		return "[]";
	}

	public static List<DynamicObject> MergeAllAccounts(List<DynamicObject> accounts, List<DynamicObject> businessAccounts)
	{
		if (accounts == null)
		{
			List<DynamicObject> list = new List<DynamicObject>();
			if (0 == 0)
			{
				accounts = list;
			}
		}
		List<DynamicObject> list2 = accounts;
		List<DynamicObject> list3 = default(List<DynamicObject>);
		if (0 == 0)
		{
			list3 = list2;
		}
		if (businessAccounts == null)
		{
			return list3;
		}
		Hashtable hashtable = new Hashtable();
		Hashtable hashtable2;
		if (6u != 0)
		{
			hashtable2 = hashtable;
		}
		List<DynamicObject>.Enumerator enumerator = list3.GetEnumerator();
		List<DynamicObject>.Enumerator enumerator2 = default(List<DynamicObject>.Enumerator);
		if (0 == 0)
		{
			enumerator2 = enumerator;
		}
		try
		{
			if (0 == 0)
			{
				DynamicObject dynamicObject = default(DynamicObject);
				while (true)
				{
					bool num = enumerator2.MoveNext();
					if (uint.MaxValue != 0)
					{
						if (!num)
						{
							break;
						}
						DynamicObject current = enumerator2.Current;
						if (6u != 0 && 0 == 0)
						{
							dynamicObject = current;
						}
						num = hashtable2.ContainsKey(dynamicObject.GetString("id"));
					}
					if (!num)
					{
						string @string = dynamicObject.GetString("id");
						object value = true;
						if (2u != 0 && 0 == 0)
						{
							hashtable2.Add(@string, value);
						}
					}
				}
			}
		}
		finally
		{
			((IDisposable)enumerator2).Dispose();
		}
		List<DynamicObject>.Enumerator enumerator3 = businessAccounts.GetEnumerator();
		if (0 == 0)
		{
			enumerator2 = enumerator3;
		}
		try
		{
			List<DynamicObject>.Enumerator enumerator5 = default(List<DynamicObject>.Enumerator);
			while (enumerator2.MoveNext())
			{
				List<DynamicObject> array = enumerator2.Current.GetArray("all_accounts");
				List<DynamicObject> list4;
				if (true)
				{
					list4 = array;
				}
				if (list4 == null)
				{
					continue;
				}
				List<DynamicObject>.Enumerator enumerator4 = list4.GetEnumerator();
				if (0 == 0)
				{
					enumerator5 = enumerator4;
				}
				try
				{
					while (true)
					{
						if (false)
						{
							goto IL_0101;
						}
						goto IL_0121;
						IL_0101:
						DynamicObject dynamicObject2;
						hashtable2.Add(dynamicObject2.GetString("id"), true);
						list3.Add(dynamicObject2);
						goto IL_0121;
						IL_0121:
						while (true)
						{
							int num2 = 0;
							if (num2 == 0)
							{
								if (num2 != 0)
								{
									break;
								}
								num2 = (enumerator5.MoveNext() ? 1 : 0);
							}
							if (num2 != 0)
							{
								DynamicObject current2 = enumerator5.Current;
								if (uint.MaxValue != 0)
								{
									dynamicObject2 = current2;
								}
								if (hashtable2.ContainsKey(dynamicObject2.GetString("id")))
								{
									continue;
								}
								goto IL_0101;
							}
							goto end_IL_00dd;
						}
						continue;
						end_IL_00dd:
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator5).Dispose();
				}
			}
			return list3;
		}
		finally
		{
			((IDisposable)enumerator2).Dispose();
		}
	}
}
