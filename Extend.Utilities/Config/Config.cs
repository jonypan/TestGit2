using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web;

namespace Extend.Utilities
{
    //ac
    public sealed class Config
    {
        private static readonly Config instance = new Config();
        private readonly string _SQLConn;
        private readonly string _SQLConnCMS;
        private readonly string _CGDGConnectionString;
        private readonly string _AdminAccountIds;

        private readonly string _CardTelcoServiceUrl;

        private readonly string _SysPartnerKey;

        private readonly string _SQLConnectionString;

        private readonly string _useCoinServiceKey;
        private readonly string _useCoinServiceUrl;

        private readonly string _mobileSid = ConfigurationManager.AppSettings["MobileSid"] ?? "3";

        private readonly string _acbSid = ConfigurationManager.AppSettings["AcbSid"] ?? "1";
        private readonly string _vcbSid = ConfigurationManager.AppSettings["VcbSid"] ?? "2";
        private readonly string _cbnSid = ConfigurationManager.AppSettings["CbnSid"] ?? "6";
        private readonly string _ccbSid = ConfigurationManager.AppSettings["CcbSid"] ?? "11";
        private readonly string _wapSid = ConfigurationManager.AppSettings["WapSid"] ?? "5";
        private readonly string _gamebai777Sid = ConfigurationManager.AppSettings["gamebai777Sid"] ?? "15";
        
        Config()
        {
            bool encrypted = true;
            bool production = true;

            string encryptedStr = ConfigurationManager.AppSettings["encrypted"];
            if (encryptedStr != null && encryptedStr != string.Empty)
            {
                encrypted = Boolean.Parse(encryptedStr);
            }
            string productionStr = ConfigurationManager.AppSettings["production"];
            if (productionStr != null && productionStr != string.Empty)
            {
                production = Boolean.Parse(productionStr);
            }

            _AdminAccountIds = ConfigurationManager.AppSettings["AdminAccountIds"];

            _CardTelcoServiceUrl = ConfigurationManager.AppSettings["CARD_TELCO_SERVICE_URL"];
            _useCoinServiceKey = ConfigurationManager.AppSettings["UseCoin.ServiceID"];
            _useCoinServiceUrl = ConfigurationManager.AppSettings["USE_COIN_SERVICE_URL"];

            _SQLConnectionString = GetConnStr("SQLConnection", encrypted);
           
            if (!encrypted)
            {
                if (production)
                {
                    Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                    AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");
                    ConnectionStringsSection connectStrings = (ConnectionStringsSection)config.GetSection("connectionStrings");

                    UpdateAppSettings(appSettings, "encrypted", "true");

                    UpdateConnectionStrings(connectStrings, "SysPartnerKey", true);
                    UpdateConnectionStrings(connectStrings, "TokenConnectionString", true);

                    UpdateConnectionStrings(connectStrings, "AuthenDBConnectionString", true);
                    UpdateConnectionStrings(connectStrings, "PaymentDBConnectionString", true);
                    UpdateConnectionStrings(connectStrings, "ProfileDBConnectionString", true);

                    UpdateConnectionStrings(connectStrings, "SQLConnCMS", true);
                    UpdateConnectionStrings(connectStrings, "SQLConn", true);
                    UpdateConnectionStrings(connectStrings, "CGDGConnectionString", true);
                    UpdateConnectionStrings(connectStrings, "GameDBConnectionString", true);
                    UpdateConnectionStrings(connectStrings, "IntecomApiConnectionString", true);
                    UpdateConnectionStrings(connectStrings, "ReportConnectionString", true);
                    UpdateConnectionStrings(connectStrings, "EventConnectionString", true);
                    UpdateConnectionStrings(connectStrings, "LogConnectionString", true);
                    UpdateConnectionStrings(connectStrings, "BotConnectionString", true);
                    UpdateConnectionStrings(connectStrings, "SSOConnectionString", true);
                    UpdateConnectionStrings(connectStrings, "NotificationConnectionString", true);
                    UpdateConnectionStrings(connectStrings, "DynamicPasswordAPIConnectionString", true);
                    UpdateConnectionStrings(connectStrings, "DeviceFingerConnectionString", true);
                    UpdateConnectionStrings(connectStrings, "EbankConnectionString", true);
                    UpdateConnectionStrings(connectStrings, "SmsBankingConnectionString", true);
                    config.Save();
                    ConfigurationManager.RefreshSection("connectionStrings");
                }
            }
        }

        public static string SQLConnCMS
        {
            get { return instance._SQLConnCMS; }
        }
        public static string SQLConn
        {
            get { return instance._SQLConn; }
        }

        public static string CGDGConnectionString
        {
            get { return instance._CGDGConnectionString; }
        }

        public static string AdminAccountIds
        {
            get { return instance._AdminAccountIds; }
        }

        public static string CardTelcoServiceUrl
        {
            get { return instance._CardTelcoServiceUrl; }
        }

        public static string SysPartnerKey
        {
            get
            {
                return instance._SysPartnerKey;
            }
        }

        public static string SQLConnectionString
        {
            get
            {
                return instance._SQLConnectionString;
            }
        }

        public static int UseCoinServiceKey
        {
            get
            {
                int value;
                return Int32.TryParse(instance._useCoinServiceKey, out value) ? value : 0;
            }
        }

        public static string UseCoinServiceUrl
        {
            get
            {
                return instance._useCoinServiceUrl;
            }
        }

        public static int MobileSid
        {
            get
            {
                int value;
                return Int32.TryParse(instance._mobileSid, out value) ? value : 0;
            }
        }

        public static int AcbSid
        {
            get
            {
                int value;
                return Int32.TryParse(instance._acbSid, out value) ? value : 0;
            }
        }

        public static int VcbSid
        {
            get
            {
                int value;
                return Int32.TryParse(instance._vcbSid, out value) ? value : 0;
            }
        }

        public static int CcbSid
        {
            get
            {
                int value;
                return Int32.TryParse(instance._ccbSid, out value) ? value : 0;
            }
        }

        public static int CbnSid
        {
            get
            {
                int value;
                return Int32.TryParse(instance._cbnSid, out value) ? value : 0;
            }
        }

        public static int WapSid
        {
            get
            {
                int value;
                return Int32.TryParse(instance._wapSid, out value) ? value : 0;
            }
        }

        public static int Gamebai777Sid
        {
            get
            {
                int value;
                return Int32.TryParse(instance._gamebai777Sid, out value) ? value : 0;
            }
        }
        
        public static Config Instance
        {
            get
            {
                return instance;
            }
        }

        public static string GetConnStr(string name)
        {
            return GetConnStr(name, true);
        }

        public static string GetConnStr(string name, bool encrypted)
        {
            string connStr = ConfigurationManager.ConnectionStrings[name] == null ? "" : ConfigurationManager.ConnectionStrings[name].ConnectionString;

            if (!encrypted)
            {
                return connStr;
            }

            try
            {
                return connStr == "" ? "" : connStr;// new RijndaelEnhanced(GetAppSettings("SiteName"), "@1B2c3D4e5F6g7H8").Decrypt(connStr);
            }
            catch
            {
                return connStr;
            }
        }

        public static void UpdateAppSettings(AppSettingsSection appSettings, string key, string value)
        {
            if (appSettings.Settings[key] == null)
            {
                return;
            }

            appSettings.Settings[key].Value = value;
        }

        public static void UpdateConnectionStrings(ConnectionStringsSection connectStrings, string name, bool encrypt)
        {
            if (connectStrings.ConnectionStrings[name] == null)
            {
                return;
            }

            string connectionString = connectStrings.ConnectionStrings[name].ConnectionString;
            if (encrypt)
            {
                connectionString = new RijndaelEnhanced(GetAppSettings("SiteName"), "@1B2c3D4e5F6g7H8").Encrypt(connectionString);
            }

            connectStrings.ConnectionStrings[name].ConnectionString = connectionString;
        }

        public static string GetAppSettings(string key, string defaultValue = "")
        {
            string value = defaultValue;

            if (string.IsNullOrEmpty(key))
                return value;

            try
            {
                value = ConfigurationManager.AppSettings[key];
            }
            catch { }

            return value;
        }

        public static int GetIntegerAppSettings(string key, int defaultValue = 0)
        {
            int value = defaultValue;

            if (string.IsNullOrEmpty(key))
                return value;

            try
            {
                value = Int32.Parse(ConfigurationManager.AppSettings[key]);
            }
            catch { }

            return value;
        }

        public static bool CheckEmail(string email)
        {
            //Kiểm tra định dạng email
            return Regex.IsMatch(email, @"^([0-9a-z]+[-._+&])*[0-9a-z]+@([-0-9a-z]+[.])+[a-z]{2,6}$", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Get ra kiểu email (yahoo, gmail, msn) từ địa chỉ email
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns>
        /// 0: Loại khác
        /// 1: Yahoo
        /// 2: gmail
        /// 3: msn
        /// </returns>
        public static int GetEmailType(string emailAddress)
        {
            var listyahoo = new List<string> { "yahoo", "ymail.com", "rocketmail.com" };
            var listgmail = new List<string> { "gmail.com", "googlemail.com" };
            var listmsn = new List<string> { "hotmail.com", "msn.com", "live.com" };
            var domain = emailAddress.Substring(emailAddress.IndexOf('@') + 1);
            if (listyahoo.Exists(e => domain.ToLower().StartsWith(e)))
                return 1;
            if (listgmail.Exists(e => domain.ToLower().StartsWith(e)))
                return 2;
            return listmsn.Exists(e => domain.ToLower().StartsWith(e)) ? 3 : 0;
        }

        /// <summary>
        /// Kiểm tra độ mạnh của password
        /// pass phải từ 6-16 ký tự, bao gồm cả chữ cái và chữ số
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsPasswordStrong(string password)
        {
            return Regex.IsMatch(password, @"^(?=.{6,16})(?=.*\d)(?=.*[a-zA-Z]).*$");
        }
    }
}