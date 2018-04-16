using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using Extend.Utilities.IpAddress;

namespace Extend.Utilities
{
    public class AccountSession
    {
        public static long GetAccountID(dynamic context)
        {
            int userId = 0;
            if (context.Request.User != null && context.Request.User.Identity.IsAuthenticated)
            {
                var s = context.Request.User.Identity.Name.Split('|');

                if (s != null && s.Length > 0)
                    userId = Convert.ToInt32(s[0]);
            }

            return userId;
        }

        public static long AccountID
        {
            get
            {
                int userId = 0;
                if (HttpContext.Current != null && HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    var s = HttpContext.Current.User.Identity.Name.Split('|');
                    if (s != null && s.Length > 0)
                        userId = Convert.ToInt32(s[0]);
                }
                return userId;
            }
        }

        public static string AccountName
        {
            get
            {
                string userName = string.Empty;

                if (HttpContext.Current != null && HttpContext.Current.User.Identity.IsAuthenticated && !string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
                {
                    var s = HttpContext.Current.User.Identity.Name.Split('|');
                    if (s != null && s.Length > 1)
                        userName = s[1];
                }

                return userName;
            }
        }

        public static int MerchantID
        {
            get
            {
                int merchantId = 0;

                if (HttpContext.Current != null && HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    var s = HttpContext.Current.User.Identity.Name.Split('|');
                    if (s.Length > 4)
                        merchantId = Convert.ToInt32(s[4]);
                }

                return merchantId;
            }
        }

        public static int SourceID
        {
            get
            {
                int sourceId = 0;

                if (HttpContext.Current != null && HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    var s = HttpContext.Current.User.Identity.Name.Split('|');
                    if (s.Length > 5)
                        sourceId = Convert.ToInt32(s[5]);
                }

                return sourceId;
            }
        }

        //public static string SessionName(long accountId, string username)
        //{
        //    string ipAddress = HttpContext.Current.Request.UserHostAddress;
        //    string userAgent = HttpContext.Current.Request.UserAgent;
        //    //accountId | username | ip | userAgent
        //    return string.Format("{0}|{1}|{2}|{3}", accountId, username, ipAddress, userAgent);
        //}

        public static string AccountFullName
        {
            get
            {
                string userFullName = string.Empty;

                if (HttpContext.Current != null && HttpContext.Current.User.Identity.IsAuthenticated && !string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
                {
                    var s = HttpContext.Current.User.Identity.Name.Split('|');
                    if (s != null && s.Length > 1)
                        userFullName = s[6];
                }
                return userFullName;
            }
        }

        public static bool isFacebook
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.User.Identity.IsAuthenticated && !string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
                {
                    var s = HttpContext.Current.User.Identity.Name.Split('|');
                    if (s != null && s.Length > 7)
                        return Convert.ToBoolean(s[7]);
                }
                return false;
            }
        }

        public static long Bon
        {
            get
            {
                long Bon = 0;
                if (HttpContext.Current != null && HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    var s = HttpContext.Current.User.Identity.Name.Split('|');
                    if (s != null && s.Length > 0)
                        Bon = Convert.ToInt64(s[7]);
                }
                return Bon;
            }
        }

        public static long Bac
        {
            get
            {
                long Bac = 0;
                if (HttpContext.Current != null && HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    var s = HttpContext.Current.User.Identity.Name.Split('|');
                    if (s != null && s.Length > 0)
                        Bac = Convert.ToInt64(s[8]);
                }
                return Bac;
            }
        }

        //public static string SessionName(long accountId, string username, int merchantId, int sourceId, string fullName)
        //{
        //    string ipAddress = HttpContext.Current.Request.UserHostAddress;
        //    string userAgent = HttpContext.Current.Request.UserAgent;
        //    return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", accountId, username, ipAddress, userAgent, merchantId, sourceId, fullName);
        //}

        public static string SessionNameCreate(long accountId, string username, int merchantId, int sourceId, string fullName, long Bon, long Bac)
        {
            string ipAddress = HttpContext.Current.Request.UserHostAddress;
            string userAgent = HttpContext.Current.Request.UserAgent;
            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}", accountId, username, ipAddress, userAgent, merchantId, sourceId, fullName, Bon, Bac);
        }

    }
}