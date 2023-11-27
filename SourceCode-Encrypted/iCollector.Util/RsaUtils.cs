using System;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace iCollector.Util;

internal class RsaUtils
{
	public static string Encrypt(byte[] data, string key)
	{
		RsaKeyParameters rsaKeyParameters = default(RsaKeyParameters);
		do
		{
			RsaKeyParameters obj = (RsaKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(key));
			if (4u != 0 && 0 == 0)
			{
				rsaKeyParameters = obj;
			}
		}
		while (false);
		OaepEncoding oaepEncoding = new OaepEncoding(new RsaEngine(), new Sha256Digest(), new byte[0]);
		RsaKeyParameters param = rsaKeyParameters;
		if (0 == 0 && 4u != 0)
		{
			oaepEncoding.Init(forEncryption: true, param);
		}
		return Convert.ToBase64String(oaepEncoding.ProcessBlock(data, 0, data.Length));
	}
}
