using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using iCollector.Job.Model;
using iCollector.Util;
using Microsoft.Win32;

namespace iCollector.Job.Handler;

internal class ClientInternetResolver
{
	private static readonly string QUERY_1_SE;

	private static readonly string QUERY_1;

	private static readonly string QUERY_2_SE;

	private static readonly string QUERY_2;

	private static readonly string QUERY_3_SE;

	private static readonly string QUERY_3;

	private static string ME_NAME_SE;

	private static string ME_NAME;

	private static string GC_NAME_SE;

	private static string GC_NAME;

	private static string BV_NAME_SE;

	private static string BV_NAME;

	private static string MF_NAME_SE;

	private static string MF_NAME;

	private static string CLAZZ_NAME_SE;

	private static string CLAZZ_NAME;

	private Logger log = Logger.Instance();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	private Hashtable MapClient = new Hashtable();

	public void InitMap()
	{
		List<ClientProcess> clientProcessInfo = GetClientProcessInfo();
		List<ClientProcess> list;
		if (8u != 0)
		{
			if (5u != 0)
			{
				list = clientProcessInfo;
			}
			if (3 == 0)
			{
			}
		}
		string[] obj = new string[4] { ME_NAME, GC_NAME, BV_NAME, MF_NAME };
		string[] array = default(string[]);
		if (7u != 0 && 0 == 0)
		{
			array = obj;
		}
		string[] obj2 = new string[4]
		{
			CKType.EMB,
			CKType.HCB,
			CKType.RBB,
			CKType.ZIF
		};
		string[] array2;
		if (uint.MaxValue != 0)
		{
			array2 = obj2;
		}
		List<ClientProcess>.Enumerator enumerator = list.GetEnumerator();
		List<ClientProcess>.Enumerator enumerator2;
		if (7u != 0)
		{
			enumerator2 = enumerator;
		}
		try
		{
			ClientProcess clientProcess = default(ClientProcess);
			int num = default(int);
			while (true)
			{
				if (0 == 0)
				{
					if (enumerator2.MoveNext())
					{
						ClientProcess current = enumerator2.Current;
						if (0 == 0 && 6u != 0)
						{
							clientProcess = current;
						}
						goto IL_0084;
					}
					break;
				}
				goto IL_00c3;
				IL_00c3:
				while (true)
				{
					if (8 == 0)
					{
						return;
					}
					int num2 = num;
					int num3 = array.Length;
					if (0 == 0)
					{
						if (num2 >= num3)
						{
							break;
						}
						while (true)
						{
							if (string.Equals(clientProcess.Name, array[num]))
							{
								Hashtable mapClient = MapClient;
								string key = array2[num];
								ClientProcess value = clientProcess;
								if (4u != 0)
								{
									mapClient.Add(key, value);
								}
							}
							if (-1 == 0)
							{
								break;
							}
							if (false)
							{
								continue;
							}
							goto IL_00bb;
						}
						goto IL_0084;
					}
					goto IL_00be;
					IL_00be:
					int num4 = num2 + num3;
					if (4u != 0)
					{
						num = num4;
					}
					continue;
					IL_00bb:
					num2 = num;
					num3 = 1;
					goto IL_00be;
				}
				continue;
				IL_0084:
				if (4u != 0 && 0 == 0)
				{
					num = 0;
				}
				if (false)
				{
				}
				goto IL_00c3;
			}
		}
		finally
		{
			((IDisposable)enumerator2).Dispose();
		}
	}

	public List<ClientProcess> GetClientProcessInfo()
	{
		List<ClientProcess> list = new List<ClientProcess>();
		List<ClientProcess> list2 = default(List<ClientProcess>);
		if (0 == 0)
		{
			list2 = list;
		}
		RegistryKey? obj = Registry.LocalMachine.OpenSubKey(QUERY_1) ?? Registry.LocalMachine.OpenSubKey(QUERY_2);
		RegistryKey registryKey;
		if (3u != 0)
		{
			registryKey = obj;
		}
		do
		{
			if (registryKey == null)
			{
				return list2;
			}
		}
		while (false);
		try
		{
			string[] subKeyNames = registryKey.GetSubKeyNames();
			string[] array;
			if (6u != 0)
			{
				array = subKeyNames;
			}
			int num;
			if (8u != 0)
			{
				num = 0;
			}
			RegistryKey registryKey3 = default(RegistryKey);
			string text2 = default(string);
			string text3 = default(string);
			while (true)
			{
				int num2 = num;
				if (5 == 0)
				{
					goto IL_0139;
				}
				int num3 = array.Length;
				if (0 == 0)
				{
					if (num2 >= num3)
					{
						break;
					}
					RegistryKey? registryKey2 = registryKey.OpenSubKey(array[num]);
					if (0 == 0)
					{
						registryKey3 = registryKey2;
					}
					if (registryKey3 != null)
					{
						string name;
						if (0 == 0)
						{
							string obj2 = (string)registryKey3.GetValue(null);
							if (uint.MaxValue != 0)
							{
								name = obj2;
							}
							RegistryKey? registryKey4 = registryKey3.OpenSubKey(QUERY_3);
							RegistryKey registryKey5;
							if (true)
							{
								registryKey5 = registryKey4;
							}
							if (registryKey5 == null)
							{
								goto IL_0136;
							}
							string? text = registryKey5.GetValue(null).ToString();
							if (0 == 0)
							{
								text2 = text;
							}
						}
						if (0 == 0)
						{
							text3 = "";
						}
						try
						{
							string? productVersion = FileVersionInfo.GetVersionInfo(text2.StartsWith("\"") ? text2.Substring(1, text2.Length - 2) : text2).ProductVersion;
							if (0 == 0)
							{
								text3 = productVersion;
							}
						}
						catch (Exception ex)
						{
							log.Error(ctx, ex.ToString());
						}
						List<ClientProcess> list3 = list2;
						ClientProcess obj3 = new ClientProcess
						{
							Name = name,
							ExecutorPath = text2
						};
						string version = text3;
						if (0 == 0)
						{
							obj3.Version = version;
						}
						if (6u != 0)
						{
							list3.Add(obj3);
						}
					}
					goto IL_0136;
				}
				goto IL_0138;
				IL_0139:
				num = num2;
				continue;
				IL_0136:
				num2 = num;
				num3 = 1;
				goto IL_0138;
				IL_0138:
				num2 += num3;
				goto IL_0139;
			}
			return list2;
		}
		catch (Exception ex2)
		{
			log.Error(ctx, ex2.StackTrace);
			return list2;
		}
	}

	internal ClientProcess GetProcess(string type)
	{
		while (true)
		{
			if (5u != 0 && MapClient.ContainsKey(type))
			{
				goto IL_0011;
			}
			goto IL_0026;
			IL_0011:
			if (uint.MaxValue != 0)
			{
				return (ClientProcess)MapClient[type];
			}
			goto IL_0026;
			IL_0026:
			if (0 == 0 && 0 == 0)
			{
				if (0 == 0)
				{
					break;
				}
				continue;
			}
			goto IL_0011;
		}
		return null;
	}

	static ClientInternetResolver()
	{
		while (true)
		{
			QUERY_1_SE = "Wv/R2I0GnMhCQ7AzRxWq2w==.CtDFAEinftrtDQxa+zIAgMEg5Wc7n5ON75gszkixFLRPji3ry3klkTCg5YFyTTV1jDqR9Su7sOxXeMM0EnaU/Q==";
			QUERY_1 = SecurityUtils.ReadStructEncrypted(QUERY_1_SE);
			int num = 0;
			while (true)
			{
				if (num == 0)
				{
					QUERY_2_SE = "cwYeDn3biizR1L9wuxa/uQ==.F5d+P2KWf0KEJ+M5qzRYOzHpptAqM42Esfz+nRK+mFtVQgDv8UAxk5DQEDN0yUwGcRKhkVrGlP650TfD8C9nGQ==";
					if (false)
					{
						break;
					}
					QUERY_2 = SecurityUtils.ReadStructEncrypted(QUERY_2_SE);
					while (true)
					{
						QUERY_3_SE = "eTU4tQBelb5ERWCZQobqGA==.MCin55dCtQpCj9qUbdWNEAHf6QYnIeT+LSvsYZiX4uvaJC151uPzz/Heo3oQ5zUd";
						QUERY_3 = SecurityUtils.ReadStructEncrypted(QUERY_3_SE);
						num = 0;
						if (num != 0)
						{
							goto IL_00a0;
						}
						if (num != 0)
						{
							break;
						}
						if (num != 0)
						{
							continue;
						}
						if (0 == 0)
						{
							ME_NAME_SE = "ouhK9KWxW3CgryMSYPnPBQ==.57uCBahvv9kKGHWTb5JgiSJMsQzS8101sOTFtnB5YVc=";
							do
							{
								ME_NAME = SecurityUtils.ReadStructEncrypted(ME_NAME_SE);
							}
							while (7 == 0);
							GC_NAME_SE = "S2s0y3Q6sK5HiYm7+bm+nw==.B5VESw6KOwDQBA5pzLhfJIwpcQGUiz8Sh7pvhf1xHLk=";
							GC_NAME = SecurityUtils.ReadStructEncrypted(GC_NAME_SE);
							goto IL_0095;
						}
						goto IL_00a2;
						IL_00a0:
						if (num != 0)
						{
							goto IL_0095;
						}
						goto IL_00a2;
						IL_0095:
						BV_NAME_SE = "uEOzfa2cmUmnheu5VoB2oA==.gVN7NFQXm4ykUbSbZTqh3OMfU4Foiql7WbGtYgZUBw4=";
						num = 0;
						goto IL_00a0;
					}
					continue;
				}
				goto IL_00ca;
				IL_00ca:
				CLAZZ_NAME_SE = "zuoL6XI2y+yIFfsayRvhzQ==.7tXp0rkvTMt3zIPXhllbTb21rWXCuXtpYi3GuZpY6vttyxCmqQt46+3pn94I7yZ3";
				CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);
				return;
				IL_00a2:
				BV_NAME = SecurityUtils.ReadStructEncrypted(BV_NAME_SE);
				MF_NAME_SE = "vaz8d259rByWhfiVcX4H7A==.Ak2I+TxpWLamsMP1iIFc/9rXbTORtj3mbHN5Q5vshbA=";
				MF_NAME = SecurityUtils.ReadStructEncrypted(MF_NAME_SE);
				goto IL_00ca;
			}
		}
	}
}
