using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace iCollector.Util;

internal class TextUtils
{
	public static string Reverse(string text)
	{
		return string.Join("", text.Reverse());
	}

	public static string OnlyAlphaNumber(string src, int maxLength)
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = default(StringBuilder);
		if (8u != 0 && 0 == 0)
		{
			stringBuilder2 = stringBuilder;
		}
		int num3 = default(int);
		char c = default(char);
		while (true)
		{
			int num;
			if (true && uint.MaxValue != 0)
			{
				num = 0;
			}
			int num2 = 0;
			while (true)
			{
				if (0 == 0 && 0 == 0)
				{
					num3 = num2;
				}
				while (true)
				{
					int num4 = num3;
					int num5 = src.Length;
					if (-1 == 0)
					{
						goto IL_004e;
					}
					int num6;
					int num7;
					if (num4 < num5)
					{
						num2 = src[num3];
						if (6 == 0)
						{
							break;
						}
						if (3u != 0 && 0 == 0)
						{
							c = (char)num2;
						}
						if (c < 'a' || c > 'z')
						{
							if (c >= 'A')
							{
								num6 = c;
								num7 = 90;
								goto IL_0044;
							}
							goto IL_0046;
						}
						goto IL_0050;
					}
					goto IL_009b;
					IL_0046:
					if (c >= '0')
					{
						num4 = c;
						num5 = 57;
						goto IL_004e;
					}
					goto IL_0082;
					IL_009b:
					return stringBuilder2.ToString();
					IL_0044:
					if (num6 > num7)
					{
						goto IL_0046;
					}
					goto IL_0050;
					IL_0082:
					num6 = num3;
					num7 = 1;
					if (num7 != 0)
					{
						int num8 = num6 + num7;
						if (0 == 0 && 0 == 0)
						{
							num3 = num8;
						}
						continue;
					}
					goto IL_0044;
					IL_0050:
					stringBuilder2.Append(c);
					int num9 = num + 1;
					if ((4u != 0) ? true : false)
					{
						num = num9;
					}
					int num10 = num;
					if (5u != 0)
					{
						if (num10 != maxLength)
						{
							goto IL_0082;
						}
						if (false)
						{
							goto IL_009b;
						}
						num10 = 5;
					}
					if (num10 == 0)
					{
						goto end_IL_0015;
					}
					if (0 == 0)
					{
						if (8 == 0)
						{
							goto end_IL_0015;
						}
						return stringBuilder2.ToString();
					}
					goto IL_0046;
					IL_004e:
					if (num4 <= num5)
					{
						goto IL_0050;
					}
					goto IL_0082;
				}
				continue;
				end_IL_0015:
				break;
			}
		}
	}

	public static string CreateMD5(string input)
	{
		MD5 mD2 = default(MD5);
		byte[] buffer = default(byte[]);
		string result = default(string);
		while (true)
		{
			MD5 mD = MD5.Create();
			if (0 == 0 && 0 == 0)
			{
				mD2 = mD;
			}
			while (true)
			{
				try
				{
					do
					{
						byte[] bytes = Encoding.ASCII.GetBytes(input);
						if (8u != 0 && 0 == 0)
						{
							buffer = bytes;
						}
					}
					while (false);
					string text = Convert.ToBase64String(mD2.ComputeHash(buffer));
					if (0 == 0 && 0 == 0)
					{
						result = text;
					}
				}
				finally
				{
					while (true)
					{
						if (0 == 0)
						{
							if (0 == 0 && (false || mD2 == null))
							{
								break;
							}
							if (false)
							{
								continue;
							}
						}
						((IDisposable)mD2).Dispose();
						break;
					}
				}
				if (false)
				{
					break;
				}
				if (0 == 0)
				{
					return result;
				}
			}
		}
	}
}
