﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
// ReSharper disable All

namespace Extend.Utilities
{
    public class Security
    {
        private static readonly RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

        //disable Security contructor
        private Security() { }

        public static string GetVerifyToken(ref string verifyToken)
        {
            string captcha = string.Empty;
            return GetVerifyToken(ref verifyToken, ref captcha, 6);
        }

        public static string GetVerifyToken(ref string verifyToken, int length)
        {
            string captcha = string.Empty;
            return GetVerifyToken(ref verifyToken, ref captcha, length);
        }

        public static string GetVerifyToken(ref string verifyToken, ref string captcha)
        {
            return GetVerifyToken(ref verifyToken, ref captcha, 6);
        }

        public static string GetVerifyToken(ref string verifyToken, ref string captcha, int length)
        {
            const string key = "123456789ABCDEFGHIJKLMNPQRSTUVXYZ";

            byte[] randomNumber = new byte[length];
            rngCsp.GetBytes(randomNumber);

            var keyLenght = key.Length;
            var s = "";
            for (var i = 0; i < length; i++)
            {
                s = s + key[(randomNumber[i] % keyLenght)];
            }

            var time = DateTime.Now.Ticks;
            captcha = s;
            verifyToken = string.Format("{0}-{1}", time, Security.MD5Encrypt(s + time.ToString()));

            return System.Web.HttpUtility.UrlEncode(Security.TripleDESEncrypt(Security.MD5Encrypt(Environment.MachineName), s.ToUpper()));
        }

        public static string GetTokenPlainText(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return string.Empty;
            }

            return Security.TripleDESDecrypt(Security.MD5Encrypt(Environment.MachineName), System.Web.HttpUtility.UrlDecode(token).Replace(" ", "+"));
        }

        public static DateTime GetTokenTime(string verify)
        {
            var timeOfCurrentToken = Convert.ToInt64(verify.Split('-')[0]);
            return new DateTime(timeOfCurrentToken);
        }

        public static string MD5Encrypt(string plainText)
        {
            UTF8Encoding encoding1 = new UTF8Encoding();
            MD5CryptoServiceProvider provider1 = new MD5CryptoServiceProvider();
            byte[] buffer1 = encoding1.GetBytes(plainText);
            byte[] buffer2 = provider1.ComputeHash(buffer1);
            return BitConverter.ToString(buffer2).Replace("-", "").ToLower();
        }

        public static string RandomPassword()
        {
            string text1 = string.Empty;
            Random random1 = new Random(DateTime.Now.Millisecond);
            for (int num1 = 1; num1 < 10; num1++)
            {
                text1 = string.Format("{0}{1}", text1, random1.Next(0, 9));
            }
            return text1;
        }

        public static string RandomString(int length)
        {
            string text1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int num1 = text1.Length;
            Random random1 = new Random();
            string text2 = string.Empty;
            for (int num2 = 0; num2 < length; num2++)
            {
                text2 = string.Format("{0}{1}", text2, text1[random1.Next(num1)]);
            }
            return text2;
        }

        public static string TripleDESEncrypt(string key, string data)
        {
            data = data.Trim();

            byte[] keydata = Encoding.ASCII.GetBytes(key);

            string md5String = BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(keydata)).Replace("-", "").ToLower();

            byte[] tripleDesKey = Encoding.ASCII.GetBytes(md5String.Substring(0, 24));

            TripleDES tripdes = TripleDESCryptoServiceProvider.Create();

            tripdes.Mode = CipherMode.ECB;

            tripdes.Key = tripleDesKey;

            tripdes.GenerateIV();

            MemoryStream ms = new MemoryStream();

            CryptoStream encStream = new CryptoStream(ms, tripdes.CreateEncryptor(),
                CryptoStreamMode.Write);

            encStream.Write(Encoding.ASCII.GetBytes(data), 0, Encoding.ASCII.GetByteCount(data));

            encStream.FlushFinalBlock();

            byte[] cryptoByte = ms.ToArray();

            ms.Close();

            encStream.Close();

            return Convert.ToBase64String(cryptoByte, 0, cryptoByte.GetLength(0)).Trim();
        }

        public static string TripleDESDecrypt(string key, string data)
        {
            try
            {
                byte[] keydata = Encoding.ASCII.GetBytes(key);

                string md5String = BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(keydata)).Replace("-", "").ToLower();

                byte[] tripleDesKey = Encoding.ASCII.GetBytes(md5String.Substring(0, 24));

                TripleDES tripdes = TripleDESCryptoServiceProvider.Create();

                tripdes.Mode = CipherMode.ECB;

                tripdes.Key = tripleDesKey;

                byte[] cryptByte = Convert.FromBase64String(data);

                MemoryStream ms = new MemoryStream(cryptByte, 0, cryptByte.Length);

                ICryptoTransform cryptoTransform = tripdes.CreateDecryptor();

                CryptoStream decStream = new CryptoStream(ms, cryptoTransform,
                    CryptoStreamMode.Read);

                StreamReader read = new StreamReader(decStream);

                return (read.ReadToEnd());
            }
            catch
            {
                // Wrong key
                // throw new Exception("Sai key mã hóa\t key: " + key + "\t Data: " + data);
                return string.Empty;
            }
        }

        public static string Encrypt(string key, string data)
        {
            data = data.Trim();

            if (string.IsNullOrEmpty(data))
                return "Input string is empty!";

            var keydata = Encoding.ASCII.GetBytes(key);

            var md5String = BitConverter.ToString(new

            MD5CryptoServiceProvider().ComputeHash(keydata)).Replace("-", "").ToLower();

            var tripleDesKey = Encoding.ASCII.GetBytes(md5String.Substring(0, 24));

            var tripdes = TripleDES.Create();

            tripdes.Mode = CipherMode.ECB;

            tripdes.Key = tripleDesKey;

            tripdes.GenerateIV();

            var ms = new MemoryStream();

            var encStream = new CryptoStream(ms, tripdes.CreateEncryptor(),

                    CryptoStreamMode.Write);

            encStream.Write(Encoding.ASCII.GetBytes(data), 0, Encoding.ASCII.GetByteCount(data));

            encStream.FlushFinalBlock();

            var cryptoByte = ms.ToArray();

            ms.Close();

            encStream.Close();

            return Convert.ToBase64String(cryptoByte, 0, cryptoByte.GetLength(0)).Trim();
        }

        public static string Decrypt(string key, string data)
        {
            var keydata = Encoding.ASCII.GetBytes(key);

            var md5String = BitConverter.ToString(new

              MD5CryptoServiceProvider().ComputeHash(keydata)).Replace("-", "").Replace(" ", "+").ToLower();

            var tripleDesKey = Encoding.ASCII.GetBytes(md5String.Substring(0, 24));

            var tripdes = TripleDES.Create();

            tripdes.Mode = CipherMode.ECB;

            tripdes.Key = tripleDesKey;

            var cryptByte = Convert.FromBase64String(data);

            var ms = new MemoryStream(cryptByte, 0, cryptByte.Length);

            var cryptoTransform = tripdes.CreateDecryptor();

            var decStream = new CryptoStream(ms, cryptoTransform,

                    CryptoStreamMode.Read);

            var read = new StreamReader(decStream);

            return (read.ReadToEnd());
        }

        public static string EncryptSha256(string data)
        {
            SHA256 sha256 = SHA256Managed.Create(); //utf8 here as well
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));
            string result = Convert.ToBase64String(bytes);
            return result;
        }

        public static string EncriptSHA256(string inputvalue)
        {
            HashAlgorithm hasher = null;
            try
            {
                hasher = new SHA256CryptoServiceProvider();
            }
            catch
            {

                hasher = new SHA256Managed();
            }
            byte[] textWithSaltBytes = Encoding.UTF8.GetBytes(string.Concat(inputvalue));
            byte[] hashedBytes = hasher.ComputeHash(textWithSaltBytes);
            hasher.Clear();
            return Convert.ToBase64String(hashedBytes);
        }
    }
}