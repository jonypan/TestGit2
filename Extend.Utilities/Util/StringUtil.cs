using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Extend.Utilities
{
    public class StringUtil
    {
        public class Encryptor
        {
            public static string GetMD5(string str)
            {

                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

                byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

                StringBuilder sbHash = new StringBuilder();

                foreach (byte b in bHash)
                {

                    sbHash.Append(String.Format("{0:x2}", b));

                }

                return sbHash.ToString();

            }
        }
        public static string MaskUserName(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return "";
            }

            int length = username.Length;
            //neu dai it nhat 11 ky tu -> lay 8 ky tu dau và ***
            if (length > 10)
            {
                username = string.Format("{0}***", username.Substring(0, 8));
            }
            //neu dai it nhat 7 ky tu -> thi *** 3 ky tu cuoi
            else if (length > 6)
            {
                username = string.Format("{0}***", username.Substring(0, length - 3));
            }
            //neu dai it nhat 4 ky tu -> lay 3 ky tu dau va ***
            else if (length > 3)
            {
                username = string.Format("{0}***", username.Substring(0, 3));
            }
            else
            {
                username = string.Format("{0}***", username.Substring(0, 1));
            }

            return username;
        }
    }

    public static class StringExt
    {
        public static string Replace(this string s, string oldValue, string newValue, StringComparison comparisonType)
        {
            if (s == null)
                return null;

            if (String.IsNullOrEmpty(oldValue))
                return s;

            StringBuilder result = new StringBuilder(Math.Min(4096, s.Length));
            int pos = 0;

            while (true)
            {
                int i = s.IndexOf(oldValue, pos, comparisonType);
                if (i < 0)
                    break;

                result.Append(s, pos, i - pos);
                result.Append(newValue);

                pos = i + oldValue.Length;
            }
            result.Append(s, pos, s.Length - pos);

            return result.ToString();
        }
    }
}