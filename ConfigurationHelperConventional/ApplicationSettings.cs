using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using ExceptionHandling;

namespace ConfigurationHelperConventional
{
	public class ApplicationSettings
	{

		public delegate void OnErrorSettingDelegate(ApplicationSettingError args);
		public delegate void OnErrorGetDelegate(string key, Exception ex);
		public delegate void OnSettingChangedDelegate(string key, string value);

		/// <summary>
		/// Provides access to when an exception is thrown when a value can not be set
		/// </summary>
		public static event OnErrorSettingDelegate OnSettingsErrorEvent;
		/// <summary>
		/// provides access when a key in the configuration file is not found in the configuration file
		/// </summary>
		public static event OnErrorGetDelegate OnGetKeyErrorEvent;
		/// <summary>
		/// Provides access to a setting changed
		/// </summary>
		public static event OnSettingChangedDelegate OnSettingChangedEvent;

		/// <summary>
		/// Get app setting as string from application file. If configKey is not located an exception is thrown without
		/// anything to indicate this but will throw a runtime exception from the calling method.
		/// </summary>
		/// <param name="configKey">Key in app.config</param>
		/// <returns>Key value or an empty string</returns>
		public static string GetSettingAsString(string configKey)
		{

			string value = null;

			try
			{

				value = ConfigurationManager.AppSettings[configKey];

				if (value == null)
				{
					throw new Exception($"Setting {configKey} not found");
				}

			}
			catch (Exception e)
			{
				if (OnGetKeyErrorEvent != null)
                {
                    OnGetKeyErrorEvent(configKey, e);
                }

                Exceptions.Write(e);
			}

			return value;

		}
		/// <summary>
		/// Get a key in the configuration file as a date
		/// </summary>
		/// <param name="configKey">Key to read</param>
		/// <returns></returns>
		public static DateTime GetSettingAsDateTime(string configKey)
		{

			string value = null;
			DateTime result = default;

			try
			{

				value = ConfigurationManager.AppSettings[configKey];

				if (value == null)
				{
					throw new Exception($"Setting {configKey} not found");
				}


				if (!DateTime.TryParse(value, out result))
				{
					throw new Exception($"Invalid value in app config for {configKey}");
				}
			}
			catch (Exception e)
			{
                OnGetKeyErrorEvent?.Invoke(configKey, e);

                Exceptions.Write(e);
			}

			return result;

		}
		/// <summary>
		/// Get a key in the configuration file as a date
		/// </summary>
		/// <param name="configKey">Key to read</param>
		/// <returns></returns>
		public static int GetSettingAsInteger(string configKey)
		{

			string value = null;
			int result = 0;

			try
			{

				value = ConfigurationManager.AppSettings[configKey];

				if (value == null)
				{
					throw new Exception($"Setting {configKey} not found");
				}


				if (!int.TryParse(value, out result))
				{
					throw new Exception($"Invalid value in app config for {configKey}");
				}
			}
			catch (Exception e)
			{

                OnGetKeyErrorEvent?.Invoke(configKey, e);

                Exceptions.Write(e);
			}

			return result;

		}
		/// <summary>
		/// Set a app setting key value
		/// </summary>
		/// <param name="key">Key in app setting</param>
		/// <param name="value">Value for key</param>
		public static bool SetValue(string key, string value)
		{

			bool success = true;

			try
			{
				var applicationDirectoryName = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
				var configFile = Path.Combine(applicationDirectoryName, $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.exe.config");
				var configFileMap = new ExeConfigurationFileMap { ExeConfigFilename = configFile };
				var config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

				if (config.AppSettings.Settings[key] == null)
				{
					throw new Exception($"Key {key} does not exist");
				}

				config.AppSettings.Settings[key].Value = value;

				config.Save();

				ConfigurationManager.RefreshSection("appSettings");
                OnSettingChangedEvent?.Invoke(key, value);
            }
			catch (Exception e)
			{
				if (OnSettingsErrorEvent != null)
					OnSettingsErrorEvent(new ApplicationSettingError()
					{
						Key = key,
						Value = value,
						Exception = e
					});
				Exceptions.Write(e);
				success = false;
			}

			return success;

		}
		/// <summary>
		/// Set last running of the app
		/// </summary>
		/// <returns></returns>
		public static bool SetLastRan()
		{
			return SetValue("LastRan", DateTime.Now.ToString());
		}
		/// <summary>
		/// Set Incoming folder
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool SetIncomingFolder(string value)
		{
			return SetValue("IncomingFolder", value);
		}
		/// <summary>
		/// Get incoming folder
		/// </summary>
		/// <returns></returns>
		public static string GetIncomingFolder()
		{
			return GetSettingAsString("IncomingFolder");
		}
		/// <summary>
		/// Get main window title
		/// </summary>
		/// <returns></returns>
		public static string MainWindowTitle()
		{
			return GetSettingAsString("MainWindowTitle");
		}
		/// <summary>
		/// Set main form/window title (Text property)
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool SetMainWindowTitle(string value)
		{
			return SetValue("MainWindowTitle", value);
		}
		/// <summary>
		/// Minutes to pause for various operations as milliseconds 
		/// </summary>
		/// <returns></returns>
		public static int ImportMinutesToPause()
		{
			return GetSettingAsInteger("importMinutesToPause") * 1000;
		}
		//LastCategoryIdentifier
		public static int LastCategoryIdentifier()
		{
			return GetSettingAsInteger("LastCategoryIdentifier");
		}
		public static int SetLastCategoryIdentifier(int value)
		{
			SetValue("LastCategoryIdentifier", value.ToString());
			return 0;
		}

		/// <summary>
		/// Get last run date as string
		/// </summary>
		/// <returns></returns>
		public static string LastRan() => LastRanAsDate().ToString(CultureInfo.InvariantCulture);

        public static DateTime LastRanAsDate() => GetSettingAsDateTime("LastRan");

        /// <summary>
		/// Determine if the application should be in test mode
		/// </summary>
		/// <returns></returns>
		public static bool IsTestMode() => bool.Parse(GetSettingAsString("TestMode"));

        public static void SetTestMode(bool value)
		{
			SetValue("TestMode", value.ToString());
		}
		/// <summary>
		/// SQL-Server database string
		/// </summary>
		/// <returns></returns>
		public static string DatabaseConnectionString()
		{
			return $"Data Source= {GetSettingAsString("DatabaseServer")};Initial Catalog={GetSettingAsString("Catalog")};Integrated Security=True";
		}
		/// <summary>
		/// Finish up
		/// </summary>
		/// <returns></returns>
		public static MyApplication Application()
		{

			return new()
			{
				IncomingFolder = GetIncomingFolder(),
				MainWindowTitle = MainWindowTitle(),
				DatabaseServer = GetSettingAsString("DatabaseServer"),
				Catalog = GetSettingAsString("Catalog"),
				LastRan = GetSettingAsDateTime("LastRan")
			};

		}
		/// <summary>
		/// Determine if a key exists
		/// </summary>
		public static void AllKeys()
		{
			var keys = ConfigurationManager.AppSettings.AllKeys.Select((item) => new
			{
				Name = item,
				Value = ConfigurationManager.AppSettings[item]
			});
		}

		/// <summary>
		/// Determine if a key exists
		/// </summary>
		public static bool KeyExists(string key)
		{
			var result = ConfigurationManager.AppSettings.AllKeys.FirstOrDefault((keyName) => keyName == key);
			return result != null;
		}
		/// <summary>
		/// Populate <see cref="MyApplication"/> instance dynamically
		/// </summary>
		/// <returns></returns>
		public static MyApplication CreateMyApplicationDynamically()
		{

			var propertyInfo = typeof(MyApplication).GetProperties().Where((p) => p.CanWrite).Select((p) => new
			{
				PropertyName = p.Name,
				Value = ConfigurationManager.AppSettings[p.Name]
			}).ToList();

			MyApplication myApplication = new();

			foreach (var anonymous in propertyInfo)
			{
				object propertyValue = anonymous.Value;
				myApplication.SetPropertyValue(anonymous.PropertyName, propertyValue);
			}


			return myApplication;

		}
    }
}
