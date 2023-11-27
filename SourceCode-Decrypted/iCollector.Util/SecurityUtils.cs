using System;
using System.Text;
using Microsoft.CSharp.RuntimeBinder;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;

namespace iCollector.Util;

internal class SecurityUtils
{
	private static int PADDING_SIMPLE_KEY = 1;

	public static readonly string PUBLIC_RSA_KEY_SIMPLE_ENC = "CBRBEJxn1l7LG1GIFp0i8gkwL3b3zHtqOKwZW{ZkQDKUQK8gIwVKDfFV9eU8PnPsn{V7nx1tkXtMw1uVFt66Dr5qD33f36e4dIylmIy{DnJ2L58[qjfpYvNjtQj3TSzE:mfoIP1l1r9YbI8UMocQU:ChiBqpEsYwptk4n9t8[yLIoCHy9qIK{sVIRlfcrRI11fFgTFfNV4LMNTK3zObGCPNDgoHkKRWs8CYvpS,R7jLBH:mVTVZgmEk0xT[Hzk3QxZQW2ZUp{Tw5uLgEI{BtcPjLcdQ,w1sIogmGrNoHeuLgk2E7WYZbN,Z1i0j3377swGD67vGKiyrq2Vf08qWMlfwRwwekBFRBDLhDCJJNB9RBDPBBGFRBC1x:HjlirlhCOBkJCJJN";

	public static byte[] AES_KEY_BYTES;

	public static void Init()
	{
		int num = 16;
		if (num != 0 && num != 0)
		{
			AES_KEY_BYTES = new byte[num];
			SecureRandom secureRandom = new SecureRandom();
			byte[] aES_KEY_BYTES = AES_KEY_BYTES;
			if (0 == 0 && 0 == 0)
			{
				secureRandom.NextBytes(aES_KEY_BYTES);
			}
			num = 2;
		}
		if (num == 0)
		{
			return;
		}
		do
		{
			if (8u != 0)
			{
				InitProfileEncrypted();
			}
		}
		while (false);
	}

	public static void InitProfileEncrypted()
	{
	}

	public static string StructEncrypted(string text)
	{
		byte[] array2 = default(byte[]);
		string text3 = default(string);
		string text5 = default(string);
		while (true)
		{
			if (0 == 0)
			{
				if (4 == 0)
				{
					goto IL_0058;
				}
				byte[] array = new byte[16];
				if (6u != 0 && 0 == 0)
				{
					array2 = array;
				}
				SecureRandom secureRandom = new SecureRandom();
				byte[] buffer = array2;
				if (0 == 0 && 0 == 0)
				{
					secureRandom.NextBytes(buffer);
				}
				string text2 = AesUtils.Encrypt(text, array2);
				if (2u != 0 && 4u != 0)
				{
					text3 = text2;
				}
			}
			goto IL_0027;
			IL_0027:
			do
			{
				string text4 = Base64.ToBase64String(array2) + "." + text3;
				if (0 == 0 && 0 == 0)
				{
					text5 = text4;
				}
			}
			while (false);
			if (!text.Equals(ReadStructEncrypted(text5)))
			{
				throw new RuntimeBinderException("error");
			}
			goto IL_0058;
			IL_0058:
			if (2 == 0)
			{
				continue;
			}
			if (6u != 0)
			{
				break;
			}
			goto IL_0027;
		}
		return text5;
	}

	public static string ReadStructEncrypted(string text)
	{
		if (string.IsNullOrEmpty(text) || -1 == 0)
		{
			return text;
		}
		int num = default(int);
		if (0 == 0 && 6u != 0)
		{
			num = 0;
		}
		int num2 = default(int);
		if (0 == 0 && uint.MaxValue != 0)
		{
			num2 = 0;
		}
		char[] array2 = default(char[]);
		do
		{
			char[] array = text.ToCharArray();
			if (false)
			{
				break;
			}
			if (0 == 0)
			{
				array2 = array;
			}
		}
		while (false);
		int num3 = 0;
		if (num3 != 0)
		{
			goto IL_003c;
		}
		if (0 == 0)
		{
			if (false)
			{
				goto IL_0043;
			}
			if (2u != 0)
			{
				num = num3;
			}
		}
		goto IL_004d;
		IL_003c:
		int num4 = 0;
		nint num5 = num4;
		goto IL_003d;
		IL_003d:
		if (num4 == 0)
		{
			num2 = num3;
		}
		goto IL_0043;
		IL_004d:
		num3 = num;
		num5 = (nint)array2.LongLength;
		if (0 == 0)
		{
			if (num3 < (int)num5)
			{
				if (array2[num] == '.')
				{
					num3 = num;
					goto IL_003c;
				}
				goto IL_0043;
			}
			string text2 = text.Substring(0, num2);
			string s;
			if (6u != 0)
			{
				s = text2;
			}
			string input = text.Substring(num2 + 1);
			byte[] array3 = Convert.FromBase64String(s);
			byte[] keys;
			if (7u != 0)
			{
				keys = array3;
			}
			return AesUtils.Decrypt(input, keys);
		}
		goto IL_0045;
		IL_0045:
		if (3 == 0)
		{
			goto IL_003d;
		}
		int num6 = num3 + num4;
		if (3u != 0)
		{
			num = num6;
		}
		goto IL_004d;
		IL_0043:
		num3 = num;
		num4 = 1;
		num5 = num4;
		goto IL_0045;
	}

	public static string SimpleEncrypt(string value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2;
		if (6u != 0 && 3u != 0)
		{
			stringBuilder2 = stringBuilder;
		}
		char[] array = value.ToCharArray();
		char[] array2 = default(char[]);
		if (0 == 0)
		{
			if (7u != 0)
			{
				array2 = array;
			}
			if (3 == 0)
			{
				goto IL_004c;
			}
		}
		int num = 0;
		if (num != 0)
		{
			goto IL_003f;
		}
		int num2 = default(int);
		if (0 == 0 && 0 == 0)
		{
			num2 = num;
		}
		goto IL_0043;
		IL_0043:
		while (true)
		{
			IL_0043_2:
			num = num2;
			if (6 == 0)
			{
				break;
			}
			while (num < array2.Length)
			{
				if (7 == 0)
				{
					goto IL_0043_2;
				}
				num = array2[num2];
				char c;
				if (false)
				{
					if (false)
					{
						goto IL_0043_2;
					}
				}
				else if (true)
				{
					c = (char)num;
				}
				stringBuilder2.Append((char)(c + PADDING_SIMPLE_KEY));
				num = num2;
				if (8 == 0)
				{
					continue;
				}
				goto IL_003d;
			}
			goto IL_004c;
			IL_003d:
			num++;
			break;
		}
		goto IL_003f;
		IL_003f:
		if (0 == 0 && 0 == 0)
		{
			num2 = num;
		}
		goto IL_0043;
		IL_004c:
		if (0 == 0)
		{
			return stringBuilder2.ToString();
		}
		goto IL_0043;
	}

	public static string SimpleDecrypt(string value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2;
		if (6u != 0 && 3u != 0)
		{
			stringBuilder2 = stringBuilder;
		}
		char[] array = value.ToCharArray();
		char[] array2 = default(char[]);
		if (0 == 0)
		{
			if (7u != 0)
			{
				array2 = array;
			}
			if (3 == 0)
			{
				goto IL_004c;
			}
		}
		int num = 0;
		if (num != 0)
		{
			goto IL_003f;
		}
		int num2 = default(int);
		if (0 == 0 && 0 == 0)
		{
			num2 = num;
		}
		goto IL_0043;
		IL_0043:
		while (true)
		{
			IL_0043_2:
			num = num2;
			if (6 == 0)
			{
				break;
			}
			while (num < array2.Length)
			{
				if (7 == 0)
				{
					goto IL_0043_2;
				}
				num = array2[num2];
				char c;
				if (false)
				{
					if (false)
					{
						goto IL_0043_2;
					}
				}
				else if (true)
				{
					c = (char)num;
				}
				stringBuilder2.Append((char)(c - PADDING_SIMPLE_KEY));
				num = num2;
				if (8 == 0)
				{
					continue;
				}
				goto IL_003d;
			}
			goto IL_004c;
			IL_003d:
			num++;
			break;
		}
		goto IL_003f;
		IL_003f:
		if (0 == 0 && 0 == 0)
		{
			num2 = num;
		}
		goto IL_0043;
		IL_004c:
		if (0 == 0)
		{
			return stringBuilder2.ToString();
		}
		goto IL_0043;
	}

	public static string EncryptRSA(byte[] data)
	{
		string key = default(string);
		while (0 == 0)
		{
			string text = TextUtils.Reverse(SimpleDecrypt(PUBLIC_RSA_KEY_SIMPLE_ENC));
			if (false)
			{
				break;
			}
			if (0 == 0)
			{
				key = text;
			}
			if (0 == 0)
			{
				break;
			}
		}
		return RsaUtils.Encrypt(data, key);
	}

	public static string EncryptAES(string data)
	{
		return AesUtils.Encrypt(data, AES_KEY_BYTES);
	}
}
