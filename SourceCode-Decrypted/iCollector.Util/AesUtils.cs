using System;
using System.Linq;
using System.Text;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace iCollector.Util;

internal class AesUtils
{
	public static string Encrypt(string input, byte[] key)
	{
		byte[] array = default(byte[]);
		CbcBlockCipher cbcBlockCipher2 = default(CbcBlockCipher);
		byte[] array3 = default(byte[]);
		byte[] array4;
		int outOff = default(int);
		do
		{
			if (3u != 0)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(input);
				if (0 == 0 && 0 == 0)
				{
					array = bytes;
				}
			}
			CbcBlockCipher cbcBlockCipher = new CbcBlockCipher(new AesEngine());
			if (0 == 0 && uint.MaxValue != 0)
			{
				cbcBlockCipher2 = cbcBlockCipher;
			}
			PaddedBufferedBlockCipher paddedBufferedBlockCipher = new PaddedBufferedBlockCipher(cbcBlockCipher2, new Pkcs7Padding());
			byte[] array2 = new byte[cbcBlockCipher2.GetBlockSize()];
			if (uint.MaxValue != 0 && 0 == 0)
			{
				array3 = array2;
			}
			SecureRandom secureRandom = new SecureRandom();
			byte[] buffer = array3;
			if (6u != 0 && 5u != 0)
			{
				secureRandom.NextBytes(buffer);
			}
			ParametersWithIV parameters = new ParametersWithIV(new KeyParameter(key), array3, 0, cbcBlockCipher2.GetBlockSize());
			paddedBufferedBlockCipher.Init(forEncryption: true, parameters);
			array4 = new byte[paddedBufferedBlockCipher.GetOutputSize(array.Length)];
			int num = paddedBufferedBlockCipher.ProcessBytes(array, array4, 0);
			if (0 == 0 && 0 == 0)
			{
				outOff = num;
			}
			paddedBufferedBlockCipher.DoFinal(array4, outOff);
		}
		while (false);
		return Convert.ToBase64String(array3.Concat(array4).ToArray());
	}

	public static string Decrypt(string input, byte[] keys)
	{
		byte[] source = Convert.FromBase64String(input);
		CbcBlockCipher cbcBlockCipher = new CbcBlockCipher(new AesEngine());
		CbcBlockCipher cbcBlockCipher2;
		if (2u != 0 && 2u != 0)
		{
			cbcBlockCipher2 = cbcBlockCipher;
		}
		PaddedBufferedBlockCipher paddedBufferedBlockCipher = new PaddedBufferedBlockCipher(cbcBlockCipher2, new Pkcs7Padding());
		byte[] array = source.Take(cbcBlockCipher2.GetBlockSize()).ToArray();
		byte[] iv = default(byte[]);
		if (0 == 0 && uint.MaxValue != 0)
		{
			iv = array;
		}
		byte[] array2 = source.Skip(cbcBlockCipher2.GetBlockSize()).ToArray();
		byte[] array3;
		if ((5u != 0) ? true : false)
		{
			array3 = array2;
		}
		ParametersWithIV parametersWithIV = new ParametersWithIV(new KeyParameter(keys), iv, 0, cbcBlockCipher2.GetBlockSize());
		ParametersWithIV parametersWithIV2 = default(ParametersWithIV);
		if (6u != 0 && 0 == 0)
		{
			parametersWithIV2 = parametersWithIV;
		}
		ParametersWithIV parameters = parametersWithIV2;
		if (0 == 0)
		{
			paddedBufferedBlockCipher.Init(forEncryption: false, parameters);
		}
		byte[] array4 = new byte[paddedBufferedBlockCipher.GetOutputSize(array3.Length)];
		byte[] array5 = default(byte[]);
		if (0 == 0)
		{
			array5 = array4;
		}
		int num = paddedBufferedBlockCipher.ProcessBytes(array3, array5, 0);
		int num2;
		if (8u != 0)
		{
			num2 = num;
		}
		int num3 = num2 + paddedBufferedBlockCipher.DoFinal(array5, num2);
		if (0 == 0)
		{
			num2 = num3;
		}
		return Encoding.UTF8.GetString(array5, 0, num2);
	}
}
