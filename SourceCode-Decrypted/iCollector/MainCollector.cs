using System;
using System.Collections.Generic;
using System.Threading;
using iCollector.Job.Handler;
using iCollector.Job.Model;
using iCollector.Job.SocialJob;
using iCollector.Model;
using iCollector.RestClient;
using iCollector.RestClient.Model;
using iCollector.Util;

namespace iCollector;

internal class MainCollector
{
	private static string CLAZZ_NAME_SE = "MainCollector";

	private static string CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);

	private Logger log = Logger.Instance();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	public void Collect(CKProfile ckProfile)
	{
		SocialProfile socialProfile2 = default(SocialProfile);
		do
		{
			SocialProfile socialProfile = ckProfile.SocialProfile;
			if (false)
			{
				break;
			}
			if (0 == 0)
			{
				socialProfile2 = socialProfile;
			}
		}
		while (6 == 0);
		LogContext logContext = ctx;
		if (3u != 0 && 3u != 0)
		{
			logContext.MethodName = "Collect";
		}
		string profile = socialProfile2.profileId + "." + socialProfile2.UserId;
		if (0 == 0 && 0 == 0)
		{
			LogContext.Profile = profile;
		}
		try
		{
			SocialProfile profile2 = socialProfile2;
			if (6u != 0 && 0 == 0)
			{
				StartCollect(ckProfile, profile2);
			}
		}
		catch (Exception ex)
		{
			do
			{
				log.Error(ctx, ex.ToString());
			}
			while (3 == 0);
		}
		finally
		{
			while (true)
			{
				if (3u != 0)
				{
					IRestClient restClient = socialProfile2.RestClient;
					socialProfile2.RestClient = null;
					CacheRepository.Save(CacheRepository.KEY_PERFIX_SOCIAL_PROFILE + socialProfile2.profileId, socialProfile2);
					socialProfile2.RestClient = restClient;
				}
				if (8u != 0)
				{
					LogContext.Profile = "";
					if (5u != 0)
					{
						break;
					}
				}
			}
		}
	}

	private void StartCollect(CKProfile ckProfile, SocialProfile profile)
	{
		LogContext logContext = ctx;
		if (4u != 0)
		{
			logContext.MethodName = "StartCollect";
		}
		if (6u != 0)
		{
			RestOptions obj = new RestOptions
			{
				UA = profile.UA
			};
			string identityHeader = profile.IdentityHeader;
			if (0 == 0)
			{
				obj.IdentityHeader = identityHeader;
			}
			DefaultRestClient restClient = new DefaultRestClient(obj);
			if (uint.MaxValue != 0)
			{
				profile.RestClient = restClient;
			}
			Logger logger = log;
			LogContext logContext2 = ctx;
			string message = "Start collect with IdentityHeader: " + profile.IdentityHeader;
			if (0 == 0)
			{
				logger.Info(logContext2, message);
			}
			int num = (CheckLive(profile) ? 1 : 0);
			while (true)
			{
				if (num == 0)
				{
					Logger logger2 = log;
					LogContext logContext3 = ctx;
					if (0 == 0)
					{
						logger2.Info(logContext3, "Not live. Stop process");
					}
					return;
				}
				if (0 == 0)
				{
					if (profile.PersonalInfo == null || profile.PersonalInfo.PersonalInfo == null)
					{
						num = 3000;
						if (num == 0)
						{
							continue;
						}
						if (0 == 0)
						{
							Thread.Sleep(num);
						}
						PersonalInfoResult personalInfoResult = new GetPersonalInfoJob().Execute(profile);
						PersonalInfoResult personalInfoResult2;
						if (2u != 0)
						{
							personalInfoResult2 = personalInfoResult;
						}
						if (personalInfoResult2 != null && personalInfoResult2.PersonalInfo != null)
						{
							if (2u != 0)
							{
								profile.PersonalInfo = personalInfoResult2;
							}
						}
						else
						{
							Logger logger3 = log;
							LogContext logContext4 = ctx;
							if (5u != 0)
							{
								logger3.Info(logContext4, "Get personal info failed");
							}
						}
					}
					if (!profile.Live)
					{
						return;
					}
					if (profile.Tokens != null)
					{
						break;
					}
				}
				List<string> tokens = new List<string>();
				if (4u != 0)
				{
					profile.Tokens = tokens;
				}
				break;
			}
			if (profile.Tokens.Count == 0)
			{
				if (-1 == 0)
				{
					goto IL_01cd;
				}
				GetTokenResult getTokenResult = new GetTokenJob().Execute(profile);
				GetTokenResult getTokenResult2;
				if (2u != 0)
				{
					getTokenResult2 = getTokenResult;
				}
				List<string> tokens2 = getTokenResult2.Tokens;
				if (0 == 0)
				{
					profile.Tokens = tokens2;
				}
			}
			if (profile.Tokens.Count == 0)
			{
				log.Info(ctx, "Get tokens failed. Stop process");
				return;
			}
			goto IL_0171;
		}
		goto IL_0206;
		IL_0171:
		Thread.Sleep(30000);
		if (profile.SocialResourceResult != null && profile.SocialResourceResult.Accounts != null && profile.SocialResourceResult.Accounts.Count != 0 && !profile.SocialResourceResult.needFetchAgain)
		{
			goto IL_0206;
		}
		SocialResourceResult socialResourceResult = new GetSocialResourceJob().Execute(ckProfile, profile);
		if (socialResourceResult != null)
		{
			if (socialResourceResult.Accounts.Count > 0)
			{
				goto IL_01cd;
			}
			log.Info(ctx, "Get social resources accounts empty");
		}
		else
		{
			log.Info(ctx, "Get social resources accounts failed");
		}
		goto IL_021c;
		IL_01cd:
		profile.SocialResourceResult = socialResourceResult;
		goto IL_021c;
		IL_021c:
		if (!profile.Live)
		{
			return;
		}
		if (profile.SocialBusinesssResourceResult == null || profile.SocialBusinesssResourceResult.BusinessAccounts == null || profile.SocialBusinesssResourceResult.BusinessAccounts.Count == 0 || profile.SocialBusinesssResourceResult.needFetchAgain)
		{
			Thread.Sleep(3000);
			SocialBusinessResourceResult socialBusinessResourceResult = new GetSocialBusinessResourceJobV3().Execute(ckProfile, profile);
			if (socialBusinessResourceResult != null)
			{
				if (socialBusinessResourceResult.BusinessAccounts.Count > 0)
				{
					profile.SocialBusinesssResourceResult = socialBusinessResourceResult;
				}
				else
				{
					log.Info(ctx, "Get business social resources accounts empty");
				}
			}
			else
			{
				log.Info(ctx, "Get business social resources accounts failed");
				if (false)
				{
					goto IL_0171;
				}
				if (!CheckLive(profile))
				{
					log.Info(ctx, "Not live. Stop process");
					return;
				}
			}
		}
		else
		{
			log.Info(ctx, "skip check business accounts");
		}
		Thread.Sleep(3000);
		log.Info(ctx, "Finish collected profile: " + LogContext.Profile);
		return;
		IL_0206:
		log.Info(ctx, "skip check accounts");
		goto IL_021c;
	}

	private bool CheckLive(SocialProfile profile)
	{
		CheckLiveJobResult checkLiveJobResult2 = default(CheckLiveJobResult);
		while (true)
		{
			CheckLiveJobResult checkLiveJobResult = new CheckLiveExecutor().Execute(profile);
			if (0 == 0 && 0 == 0)
			{
				checkLiveJobResult2 = checkLiveJobResult;
			}
			while (8 == 0)
			{
			}
			string dtsg = checkLiveJobResult2.Dtsg;
			if (true)
			{
				if (0 == 0)
				{
					profile.Dtsg = dtsg;
				}
				if (false)
				{
					break;
				}
			}
			if (0 == 0)
			{
				bool live = checkLiveJobResult2.Live;
				if (0 == 0 && 0 == 0)
				{
					profile.Live = live;
				}
				break;
			}
		}
		return profile.Live;
	}
}
