using System.Collections.Generic;
using System.Linq;
using iCollector.Job.Model;
using iCollector.RestClient;
using iCollector.Util;

namespace iCollector.Model;

internal class SocialProfile
{
	public string profileId { get; set; }

	public string UserId { get; set; }

	public string Username { get; set; }

	public string IdentityHeader { get; set; }

	public string UA { get; set; }

	public bool Live { get; set; }

	public string Dtsg { get; set; }

	public IRestClient RestClient { get; set; }

	public List<string> Tokens { get; set; }

	public List<string> MbIds { get; set; }

	public List<DynamicObject> MbTempList { get; set; }

	public string AdAccountId { get; set; }

	public PersonalInfoResult PersonalInfo { get; set; }

	public SocialResourceResult SocialResourceResult { get; set; }

	public SocialBusinessResourceResult SocialBusinesssResourceResult { get; set; }

	public string GetTokenForGotResources()
	{
		if (8u != 0 && 5u != 0)
		{
			if (true)
			{
				goto IL_0009;
			}
			goto IL_0016;
		}
		goto IL_001b;
		IL_001b:
		return Tokens[0];
		IL_0009:
		if (ListUtils.IsEmpty(Tokens))
		{
			goto IL_0016;
		}
		goto IL_001b;
		IL_0016:
		if (2u != 0)
		{
			return null;
		}
		goto IL_0009;
	}

	public string GetToken(string prefix)
	{
		_003C_003Ec__DisplayClass61_0 _003C_003Ec__DisplayClass61_2 = default(_003C_003Ec__DisplayClass61_0);
		string text2 = default(string);
		while (true)
		{
			_003C_003Ec__DisplayClass61_0 _003C_003Ec__DisplayClass61_ = new _003C_003Ec__DisplayClass61_0();
			if (0 == 0 && 7u != 0)
			{
				_003C_003Ec__DisplayClass61_2 = _003C_003Ec__DisplayClass61_;
			}
			while (true)
			{
				_003C_003Ec__DisplayClass61_2.prefix = prefix;
				if (false)
				{
					break;
				}
				if (ListUtils.IsEmpty(Tokens))
				{
					if (2 == 0)
					{
						break;
					}
					return null;
				}
				string? text = Tokens.AsEnumerable().FirstOrDefault(_003C_003Ec__DisplayClass61_2._003CGetToken_003Eb__0);
				if (5u != 0 && 0 == 0)
				{
					text2 = text;
				}
				if (string.IsNullOrEmpty(text2))
				{
					string text3 = Tokens[0];
					if (0 == 0 && 0 == 0)
					{
						text2 = text3;
					}
				}
				if (true)
				{
					return text2;
				}
			}
		}
	}

	public string GetTokenForGotBusinessResources()
	{
		int num = 0;
		if (num == 0)
		{
			if (num != 0)
			{
				goto IL_0051;
			}
			if (num != 0)
			{
				goto IL_0018;
			}
			num = (ListUtils.IsEmpty(Tokens) ? 1 : 0);
		}
		goto IL_0014;
		IL_0018:
		string? text = Tokens.AsEnumerable().FirstOrDefault((string token) => token.StartsWith("EAAG"));
		string text2 = default(string);
		if (0 == 0 && 5u != 0)
		{
			text2 = text;
		}
		num = (string.IsNullOrEmpty(text2) ? 1 : 0);
		goto IL_0051;
		IL_0016:
		return null;
		IL_0051:
		if (num != 0)
		{
			string? text3 = Tokens.AsEnumerable().FirstOrDefault((string token) => token.StartsWith("EAAI"));
			if (0 == 0 && 2u != 0)
			{
				text2 = text3;
			}
		}
		num = (string.IsNullOrEmpty(text2) ? 1 : 0);
		if (false || ((5 == 0) ? true : false))
		{
			goto IL_0014;
		}
		if (num != 0)
		{
			string tokenForGotResources = GetTokenForGotResources();
			if (0 == 0 && 4u != 0)
			{
				text2 = tokenForGotResources;
			}
		}
		if (0 == 0)
		{
			return text2;
		}
		goto IL_0016;
		IL_0014:
		if (num != 0)
		{
			goto IL_0016;
		}
		goto IL_0018;
	}
}
