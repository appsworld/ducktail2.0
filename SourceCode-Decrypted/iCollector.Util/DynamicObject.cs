using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace iCollector.Util;

internal class DynamicObject
{
	public JObject Root { get; set; }

	public DynamicObject()
	{
		Root = new JObject();
	}

	public DynamicObject(JObject root)
	{
		Root = root;
	}

	public void PutDynamicObject(string key, DynamicObject value)
	{
		if (Root.ContainsKey(key))
		{
			Root.Remove(key);
		}
		JObject root = Root;
		JToken value2 = JToken.FromObject(value.Root);
		if (2u != 0 && 4u != 0)
		{
			root.Add(key, value2);
		}
	}

	public void PutDynamicObjects(string key, List<DynamicObject> values)
	{
		bool num = Root.ContainsKey(key);
		if (0 == 0)
		{
			if (true)
			{
				if (num)
				{
					if (false)
					{
						goto IL_0095;
					}
					Root.Remove(key);
				}
				goto IL_0027;
			}
			if (!num)
			{
				goto IL_0039;
			}
			goto IL_0095;
		}
		goto IL_0096;
		IL_0027:
		JArray jArray = new JArray();
		JArray jArray2 = default(JArray);
		if (0 == 0 && 4u != 0)
		{
			jArray2 = jArray;
		}
		goto IL_0039;
		IL_0096:
		if (uint.MaxValue != 0)
		{
			JObject root = Root;
			JToken value = JToken.FromObject(jArray2);
			if (6u != 0 && 5u != 0)
			{
				root.Add(key, value);
			}
			return;
		}
		goto IL_0027;
		IL_0039:
		List<DynamicObject>.Enumerator enumerator = values.GetEnumerator();
		List<DynamicObject>.Enumerator enumerator2 = default(List<DynamicObject>.Enumerator);
		if (2u != 0 && 0 == 0)
		{
			enumerator2 = enumerator;
		}
		try
		{
			if (false)
			{
				goto IL_004b;
			}
			goto IL_0065;
			IL_004b:
			DynamicObject current = enumerator2.Current;
			DynamicObject dynamicObject;
			if (8u != 0 && 8u != 0)
			{
				dynamicObject = current;
			}
			if (0 == 0)
			{
				JArray jArray3 = jArray2;
				JObject root2 = dynamicObject.Root;
				if (0 == 0 && 0 == 0)
				{
					jArray3.Add(root2);
				}
			}
			goto IL_0065;
			IL_0065:
			if (enumerator2.MoveNext())
			{
				goto IL_004b;
			}
		}
		finally
		{
			((IDisposable)enumerator2).Dispose();
		}
		goto IL_0095;
		IL_0095:
		goto IL_0096;
	}

	public void Put(string key, object value)
	{
		while (true)
		{
			bool num;
			if (value == null)
			{
				if (4 == 0 || 1 == 0)
				{
					goto IL_003e;
				}
				if (0 == 0)
				{
					num = Root.Remove(key);
					if (0 == 0)
					{
						break;
					}
					goto IL_003a;
				}
				goto IL_0051;
			}
			num = Root.ContainsKey(key);
			goto IL_0029;
			IL_0029:
			if (num)
			{
				goto IL_002b;
			}
			goto IL_003e;
			IL_002b:
			if (8 == 0)
			{
				continue;
			}
			num = Root.Remove(key);
			goto IL_003a;
			IL_003a:
			if (4 == 0)
			{
				goto IL_0029;
			}
			goto IL_003e;
			IL_0051:
			if (6u != 0)
			{
				break;
			}
			goto IL_002b;
			IL_003e:
			JObject root = Root;
			JToken value2 = JToken.FromObject(value);
			if (5u != 0 && 0 == 0)
			{
				root.Add(key, value2);
			}
			goto IL_0051;
		}
	}

	public bool Contains(string path)
	{
		return Root.SelectToken(path) != null;
	}

	public T GetObject<T>(string path)
	{
		return default(T);
	}

	public string GetString(string path)
	{
		if (0 == 0)
		{
			if (Root == null)
			{
				goto IL_000b;
			}
			goto IL_000d;
		}
		goto IL_001d;
		IL_000b:
		return null;
		IL_001d:
		JToken jToken = default(JToken);
		if (true)
		{
			if (7u != 0)
			{
				if (jToken != null)
				{
					goto IL_002b;
				}
				if (0 == 0)
				{
					goto IL_0029;
				}
			}
			goto IL_000b;
		}
		goto IL_002b;
		IL_002b:
		if (8 == 0)
		{
			goto IL_000d;
		}
		if (2u != 0)
		{
			return jToken.ToObject<string>();
		}
		goto IL_0029;
		IL_0029:
		return null;
		IL_000d:
		JToken? jToken2 = Root.SelectToken(path);
		if (0 == 0 && 0 == 0)
		{
			jToken = jToken2;
		}
		goto IL_001d;
	}

	public bool GetBoolean(string path)
	{
		int num;
		if (Root == null)
		{
			num = 0;
			goto IL_0009;
		}
		goto IL_0010;
		IL_0009:
		if (2u != 0)
		{
			if (0 == 0)
			{
				return (byte)num != 0;
			}
			goto IL_002a;
		}
		if (num != 0)
		{
			goto IL_0023;
		}
		goto IL_002b;
		IL_0010:
		JToken? jToken = Root.SelectToken(path);
		JToken jToken2 = default(JToken);
		if (2u != 0 && 0 == 0)
		{
			jToken2 = jToken;
		}
		goto IL_0023;
		IL_002a:
		return (byte)num != 0;
		IL_0026:
		num = 0;
		if (num != 0)
		{
			goto IL_0009;
		}
		goto IL_002a;
		IL_0023:
		if (jToken2 == null)
		{
			goto IL_0026;
		}
		goto IL_002b;
		IL_002b:
		if (8 == 0)
		{
			goto IL_0010;
		}
		if (2u != 0)
		{
			return jToken2.ToObject<bool>();
		}
		goto IL_0026;
	}

	public int GetInteger(string path)
	{
		int num;
		if (Root == null)
		{
			num = 0;
			goto IL_0009;
		}
		goto IL_0010;
		IL_0009:
		if (2u != 0)
		{
			if (0 == 0)
			{
				return num;
			}
			goto IL_002a;
		}
		if (num != 0)
		{
			goto IL_0023;
		}
		goto IL_002b;
		IL_0010:
		JToken? jToken = Root.SelectToken(path);
		JToken jToken2 = default(JToken);
		if (2u != 0 && 0 == 0)
		{
			jToken2 = jToken;
		}
		goto IL_0023;
		IL_002a:
		return num;
		IL_0026:
		num = 0;
		if (num != 0)
		{
			goto IL_0009;
		}
		goto IL_002a;
		IL_0023:
		if (jToken2 == null)
		{
			goto IL_0026;
		}
		goto IL_002b;
		IL_002b:
		if (8 == 0)
		{
			goto IL_0010;
		}
		if (2u != 0)
		{
			return jToken2.ToObject<int>();
		}
		goto IL_0026;
	}

	public double GetDouble(string path)
	{
		double result;
		if (Root == null)
		{
			result = 0.0;
			goto IL_0011;
		}
		JToken jToken2 = default(JToken);
		while (true)
		{
			JToken? jToken = Root.SelectToken(path);
			if (0 == 0 && 0 == 0)
			{
				jToken2 = jToken;
			}
			if (true && jToken2 == null)
			{
				break;
			}
			if (8u != 0)
			{
				if (2 == 0)
				{
					break;
				}
				return jToken2.ToObject<double>();
			}
		}
		result = 0.0;
		goto IL_0037;
		IL_0011:
		if (2 == 0)
		{
			goto IL_0037;
		}
		if (0 == 0)
		{
			return result;
		}
		goto IL_003a;
		IL_0037:
		if (false)
		{
			goto IL_0011;
		}
		goto IL_003a;
		IL_003a:
		return result;
	}

	public List<string> GetArrayString(string path)
	{
		JToken jToken2;
		while (true)
		{
			JToken? jToken = Root.SelectToken(path);
			if (3u != 0)
			{
				if (uint.MaxValue != 0)
				{
					jToken2 = jToken;
				}
				if (5 == 0)
				{
					goto IL_0013;
				}
			}
			if (jToken2 != null)
			{
				break;
			}
			goto IL_0013;
			IL_0013:
			if (2u != 0)
			{
				return new List<string>();
			}
		}
		return (from item in jToken2.ToObject<JArray>().ToList().AsEnumerable()
			select item.ToObject<string>()).ToList();
	}

	public List<DynamicObject> GetArray(string path)
	{
		JToken jToken2;
		while (true)
		{
			JToken? jToken = Root.SelectToken(path);
			if (3u != 0)
			{
				if (uint.MaxValue != 0)
				{
					jToken2 = jToken;
				}
				if (5 == 0)
				{
					goto IL_0013;
				}
			}
			if (jToken2 != null)
			{
				break;
			}
			goto IL_0013;
			IL_0013:
			if (2u != 0)
			{
				return new List<DynamicObject>();
			}
		}
		return (from item in jToken2.ToObject<JArray>().ToList().AsEnumerable()
			select new DynamicObject(item.ToObject<JObject>())).ToList();
	}
}
