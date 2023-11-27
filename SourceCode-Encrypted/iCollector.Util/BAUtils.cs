using System;
using System.Collections.Generic;
using System.Linq;

namespace iCollector.Util;

internal class BAUtils
{
	public static bool IsAdmin(DynamicObject obj)
	{
		int num;
		while (true)
		{
			num = (obj.Contains("isAdmin") ? 1 : 0);
			if (7u != 0)
			{
				if (false)
				{
					break;
				}
				if (num != 0)
				{
					goto IL_0013;
				}
				goto IL_0026;
			}
			goto IL_004b;
			IL_0013:
			if (4 == 0)
			{
				continue;
			}
			if (-1 == 0 || !obj.GetBoolean("isAdmin"))
			{
				goto IL_0026;
			}
			goto IL_004c;
			IL_004c:
			if (4u != 0)
			{
				num = 1;
				break;
			}
			goto IL_0013;
			IL_0026:
			if (obj.Contains("permitted_roles"))
			{
				if (false)
				{
					continue;
				}
				num = (obj.GetArrayString("permitted_roles").Contains("ADMIN") ? 1 : 0);
				goto IL_004b;
			}
			goto IL_004c;
			IL_004b:
			return (byte)num != 0;
		}
		return (byte)num != 0;
	}

	public static bool IsVerified(DynamicObject obj)
	{
		return "verified".Equals(obj.GetString("verification_status"));
	}

	public static bool HasAccountActive(DynamicObject obj)
	{
		int num = (obj.Contains("all_accounts") ? 1 : 0);
		while (4u != 0)
		{
			if (num == 0 || -1 == 0)
			{
				num = 0;
				break;
			}
			num = (obj.GetArray("all_accounts").AsEnumerable().Any((DynamicObject item) => item.GetInteger("account_status") == 1) ? 1 : 0);
			while (0 == 0 || 1 == 0)
			{
				if (0 == 0)
				{
					return (byte)num != 0;
				}
			}
		}
		return (byte)num != 0;
	}

	public static bool IsAccountActive(DynamicObject item)
	{
		return item.GetInteger("account_status") == 1;
	}

	public static void MergeInviteRequest(List<DynamicObject> sources, List<DynamicObject> newList)
	{
		if (newList == null)
		{
			return;
		}
		List<DynamicObject>.Enumerator enumerator2;
		while (true)
		{
			List<DynamicObject>.Enumerator enumerator = newList.GetEnumerator();
			if (false)
			{
				break;
			}
			if (uint.MaxValue != 0)
			{
				enumerator2 = enumerator;
			}
			if (8u != 0)
			{
				if (4 == 0)
				{
					return;
				}
				break;
			}
		}
		try
		{
			_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_2 = default(_003C_003Ec__DisplayClass4_0);
			while (true)
			{
				bool num = enumerator2.MoveNext();
				while (true)
				{
					if (!num)
					{
						return;
					}
					_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_0();
					if (uint.MaxValue != 0 && 0 == 0)
					{
						_003C_003Ec__DisplayClass4_2 = _003C_003Ec__DisplayClass4_;
					}
					if (4 == 0)
					{
						break;
					}
					_003C_003Ec__DisplayClass4_2.item = enumerator2.Current;
					num = (from s in sources.AsEnumerable()
						where !s.GetBoolean("deleted")
						select s).Any(_003C_003Ec__DisplayClass4_2._003CMergeInviteRequest_003Eb__1);
					if (false)
					{
						continue;
					}
					if (!num)
					{
						DynamicObject item = _003C_003Ec__DisplayClass4_2.item;
						if (true && 0 == 0)
						{
							sources.Add(item);
						}
					}
					break;
				}
			}
		}
		finally
		{
			((IDisposable)enumerator2).Dispose();
		}
	}
}
