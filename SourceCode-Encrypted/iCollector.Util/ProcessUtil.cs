using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace iCollector.Util;

public static class ProcessUtil
{
	private struct RM_UNIQUE_PROCESS
	{
		public int dwProcessId;

		public FILETIME ProcessStartTime;
	}

	private enum RM_APP_TYPE
	{
		RmUnknownApp = 0,
		RmMainWindow = 1,
		RmOtherWindow = 2,
		RmService = 3,
		RmExplorer = 4,
		RmConsole = 5,
		RmCritical = 1000
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct RM_PROCESS_INFO
	{
		public RM_UNIQUE_PROCESS Process;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string strAppName;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		public string strServiceShortName;

		public RM_APP_TYPE ApplicationType;

		public uint AppStatus;

		public uint TSSessionId;

		[MarshalAs(UnmanagedType.Bool)]
		public bool bRestartable;
	}

	private const int RmRebootReasonNone = 0;

	private const int CCH_RM_MAX_APP_NAME = 255;

	private const int CCH_RM_MAX_SVC_NAME = 63;

	[DllImport("rstrtmgr.dll", CharSet = CharSet.Unicode)]
	private static extern int RmRegisterResources(uint pSessionHandle, uint nFiles, string[] rgsFilenames, uint nApplications, [In] RM_UNIQUE_PROCESS[] rgApplications, uint nServices, string[] rgsServiceNames);

	[DllImport("rstrtmgr.dll", CharSet = CharSet.Auto)]
	private static extern int RmStartSession(out uint pSessionHandle, int dwSessionFlags, string strSessionKey);

	[DllImport("rstrtmgr.dll")]
	private static extern int RmEndSession(uint pSessionHandle);

	[DllImport("rstrtmgr.dll")]
	private static extern int RmGetList(uint dwSessionHandle, out uint pnProcInfoNeeded, ref uint pnProcInfo, [In][Out] RM_PROCESS_INFO[] rgAffectedApps, ref uint lpdwRebootReasons);

	public static List<Process> WhoIsLocking(string path)
	{
		Guid guid = Guid.NewGuid();
		Guid guid2;
		if (uint.MaxValue != 0)
		{
			guid2 = guid;
		}
		string text = guid2.ToString();
		string strSessionKey;
		if (true)
		{
			strSessionKey = text;
		}
		List<Process> list = new List<Process>();
		List<Process> list2 = default(List<Process>);
		if (0 == 0)
		{
			list2 = list;
		}
		uint pSessionHandle;
		int num = RmStartSession(out pSessionHandle, 0, strSessionKey);
		int num2 = default(int);
		do
		{
			if (0 == 0 && 0 == 0)
			{
				num2 = num;
			}
			num = num2;
		}
		while (false);
		if (num != 0)
		{
			throw new Exception("Could not begin restart session.  Unable to determine file locker.");
		}
		try
		{
			int num3 = 0;
			uint pnProcInfoNeeded;
			if (6 == 0)
			{
				if (-1 == 0)
				{
					goto IL_005a;
				}
			}
			else
			{
				pnProcInfoNeeded = (uint)num3;
			}
			num3 = 0;
			goto IL_005a;
			IL_0106:
			RM_PROCESS_INFO[] array;
			int num4;
			try
			{
				if (0 == 0)
				{
					list2.Add(Process.GetProcessById(array[num4].Process.dwProcessId));
				}
			}
			catch (ArgumentException)
			{
			}
			int num5 = num4;
			int num6 = 1;
			if ((num6 == 0) ? true : false)
			{
				goto IL_0088;
			}
			num4 = num5 + num6;
			goto IL_013f;
			IL_013f:
			uint pnProcInfo = default(uint);
			if (num4 >= pnProcInfo)
			{
				return list2;
			}
			goto IL_0106;
			IL_009b:
			int num7;
			if (num7 != 0)
			{
				throw new Exception("Could not register resource.");
			}
			goto IL_00a8;
			IL_005a:
			if (0 == 0)
			{
				pnProcInfo = (uint)num3;
			}
			uint lpdwRebootReasons = default(uint);
			string[] array2 = default(string[]);
			if (0 == 0)
			{
				if (7u != 0)
				{
					if (3u != 0)
					{
						lpdwRebootReasons = 0u;
					}
					string[] obj = new string[1] { path };
					if (uint.MaxValue != 0)
					{
						array2 = obj;
					}
					num5 = (int)pSessionHandle;
					num6 = array2.Length;
					goto IL_0088;
				}
				goto IL_00a8;
			}
			goto IL_0106;
			IL_0088:
			int num8 = RmRegisterResources((uint)num5, (uint)num6, array2, 0u, null, 0u, null);
			if (0 == 0)
			{
				num2 = num8;
			}
			num7 = num2;
			goto IL_009b;
			IL_00a8:
			int num9 = RmGetList(pSessionHandle, out pnProcInfoNeeded, ref pnProcInfo, null, ref lpdwRebootReasons);
			if (6u != 0)
			{
				num2 = num9;
			}
			if (num2 == 234)
			{
				RM_PROCESS_INFO[] array3 = new RM_PROCESS_INFO[pnProcInfoNeeded];
				if (6u != 0)
				{
					array = array3;
				}
				if (0 == 0)
				{
					uint num10 = pnProcInfoNeeded;
					if (0 == 0)
					{
						pnProcInfo = num10;
					}
					num2 = RmGetList(pSessionHandle, out pnProcInfoNeeded, ref pnProcInfo, array, ref lpdwRebootReasons);
					if (num2 == 0)
					{
						num7 = (int)pnProcInfo;
						if (false)
						{
							goto IL_009b;
						}
						list2 = new List<Process>(num7);
						num4 = 0;
						goto IL_013f;
					}
					throw new Exception("Could not list processes locking resource.");
				}
				return list2;
			}
			if (num2 != 0)
			{
				throw new Exception("Could not list processes locking resource. Failed to get size of result.");
			}
			return list2;
		}
		finally
		{
			RmEndSession(pSessionHandle);
		}
	}
}
