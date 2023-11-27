using iCollector.Util;

namespace iCollector.Job.Model;

internal class CKType
{
	public static readonly string RBB_SE;

	public static readonly string RBB;

	public static readonly string ZIF_SE;

	public static readonly string ZIF;

	public static readonly string MCB_SE;

	public static readonly string MCB;

	public static readonly string EMB_SE;

	public static readonly string EMB;

	public static readonly string HCB_SE;

	public static readonly string HCB;

	public static readonly string NULL_SE;

	public static readonly string NULL;

	static CKType()
	{
		while (true)
		{
			RBB_SE = "RBB";
			if (4 == 0 || 1 == 0)
			{
				goto IL_007d;
			}
			RBB = SecurityUtils.ReadStructEncrypted(RBB_SE);
			if (7u != 0)
			{
				ZIF_SE = "ZIF";
			}
			ZIF = SecurityUtils.ReadStructEncrypted(ZIF_SE);
			MCB_SE = "MCB";
			MCB = SecurityUtils.ReadStructEncrypted(MCB_SE);
			if (8 == 0)
			{
				continue;
			}
			EMB_SE = "EMB";
			EMB = SecurityUtils.ReadStructEncrypted(EMB_SE);
			if (6u != 0)
			{
				goto IL_0073;
			}
			goto IL_00a5;
			IL_007d:
			HCB = SecurityUtils.ReadStructEncrypted(HCB_SE);
			NULL_SE = "NULL";
			NULL = SecurityUtils.ReadStructEncrypted(NULL_SE);
			goto IL_00a5;
			IL_0073:
			HCB_SE = "HCB";
			goto IL_007d;
			IL_00a5:
			if (6 == 0)
			{
				goto IL_0073;
			}
			if (true)
			{
				break;
			}
			goto IL_007d;
		}
	}
}
