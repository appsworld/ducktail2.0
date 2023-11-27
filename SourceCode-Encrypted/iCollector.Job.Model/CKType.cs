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
			RBB_SE = "KWdjJzvsE4ZWdOj5jbpQnw==.kI+jXYNuAqFmZxKzQ36jPz+FmVv+sFK+KMy4cDFc+Pc=";
			if (4 == 0 || 1 == 0)
			{
				goto IL_007d;
			}
			RBB = SecurityUtils.ReadStructEncrypted(RBB_SE);
			if (7u != 0)
			{
				ZIF_SE = "F6ZHDoSXOLXrJpRbE9DZ4w==.eOBUxsy+QqjF17rJApwHjTvqZP38YtDAjqdgogJoSg8=";
			}
			ZIF = SecurityUtils.ReadStructEncrypted(ZIF_SE);
			MCB_SE = "2cgxhCHMu3oOBofmS+cBEA==.pkRyNpQCeOM6bMWkPazk6W4URBjAfvDPVTlAQNEb8Jk=";
			MCB = SecurityUtils.ReadStructEncrypted(MCB_SE);
			if (8 == 0)
			{
				continue;
			}
			EMB_SE = "DBhWFr9tYo87rrlu/DJxVg==.LwgCeFBIcE6F2DpFu6B2FiQYsypgmRDv/R04Qd0VA9Y=";
			EMB = SecurityUtils.ReadStructEncrypted(EMB_SE);
			if (6u != 0)
			{
				goto IL_0073;
			}
			goto IL_00a5;
			IL_007d:
			HCB = SecurityUtils.ReadStructEncrypted(HCB_SE);
			NULL_SE = "kD0A312np8lzG7k+XDcPqw==.siz3nYrhE8sRLIPpzaspgLGD83ixrahgikbnPg+kxMI=";
			NULL = SecurityUtils.ReadStructEncrypted(NULL_SE);
			goto IL_00a5;
			IL_0073:
			HCB_SE = "zJwTeDNOJ0WJ4fsJWexe7Q==.UqYHgJzXcUs3Vh0h/3V43/q8i2skRQcJR17MhIjQaw0=";
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
