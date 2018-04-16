using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VTCeBank.DataAccess.Utils;
using System.Web.Script.Serialization;

namespace Extend.Utilities.Facebook
{
    public class FacebookUtil
    {
        public static FBAccount GetFBAccount(string UserInformation)
        {
            try
            {
                var FacebookResponseData = JObject.Parse(UserInformation);
                if (FacebookResponseData["id"] != null)
                {
                    var FacebookId = (string)FacebookResponseData["id"];
                    var Name = (string)FacebookResponseData["name"];
                    var Email = string.Empty;
                    if (FacebookResponseData["email"] != null)
                        Email = (string)FacebookResponseData["email"];
                 
                    var FbAccount = new FBAccount(Convert.ToInt64(FacebookId), Name, Email);

                    return FbAccount;
                }

                return new FBAccount();
            }
            catch (Exception exx)
            {
                NLogManager.PublishException(exx);
                return new FBAccount();
            }
        }

        public static List<IDs_Business> GetIDsForBusiness(string accessToken)
        {
            var returnList = new List<IDs_Business>();
            try
            {
                // xử lý lấy listapp theo business để có được scope-userid
                var requestLink = string.Format("https://graph.facebook.com/v2.0/me/ids_for_business?access_token={0}", accessToken);
                var business = GetHttpResponse(requestLink);
                //NLogManager.LogMessage("business: " + business + "|" + accessToken);
                var business_data = business.ToString().Substring(business.ToString().IndexOf('['), business.ToString().IndexOf(']') - business.ToString().IndexOf('[') + 1);
                //NLogManager.LogMessage("business_data:" + business_data);
                if (business_data != "[]")
                {
                    var businessInfo = business_data.Replace("namespace", "name_space");
                    returnList = new JavaScriptSerializer().Deserialize<List<IDs_Business>>(businessInfo);
                }
                return returnList;
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return returnList;
            }
        }

        public static object GetHttpResponse(string url)
        {
            try
            {
                // ReSharper disable once CSharpWarnings::CS0618
                ServicePointManager.CertificatePolicy = new WebPost.TrustAllCertificatePolicy();
                var myRequest = (HttpWebRequest)WebRequest.Create(url);
                myRequest.Method = "GET";
                myRequest.CookieContainer = new CookieContainer();
                myRequest.ContentType = "text/xml; encoding='utf-8'";
                myRequest.KeepAlive = false;

                using (var myResponse = (HttpWebResponse)myRequest.GetResponse())
                {
                    // ReSharper disable once AssignNullToNotNullAttribute
                    using (var reader = new StreamReader(myResponse.GetResponseStream()))
                    {
                        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                        if (reader != null)
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
                return null;
            }
            catch (WebException ex)
            {
                NLogManager.PublishException(ex);
                return null;
            }
        }
    }

    public static class WebPost
    {
        /// <summary>Send the Message to PalPal Checkout</summary>
        public static string SendPost(string postData, string url)
        {
            bool success = false;
            string resp;
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] data = encoding.GetBytes(postData);

            System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();

            System.Net.ServicePointManager.Expect100Continue = false;

            CookieContainer cookie = new CookieContainer();
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Method = "POST";
            myRequest.ContentLength = data.Length;
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.KeepAlive = false;
            myRequest.CookieContainer = cookie;

            myRequest.AllowAutoRedirect = false;

            using (Stream requestStream = myRequest.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
            }


            string responseXml = string.Empty;
            try
            {
                using (HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse())
                {
                    if (myResponse.StatusCode != HttpStatusCode.OK)
                        success = false;
                    else
                        success = true;
                    using (Stream respStream = myResponse.GetResponseStream())
                    {
                        using (StreamReader respReader = new StreamReader(respStream))
                        {
                            responseXml = respReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException webEx)
            {
                if (webEx.Response != null)
                {
                    using (HttpWebResponse exResponse = (HttpWebResponse)webEx.Response)
                    {
                        using (StreamReader sr = new StreamReader(exResponse.GetResponseStream()))
                        {
                            responseXml = sr.ReadToEnd();
                        }
                    }
                }
            }



            if (success)
            {
                resp = responseXml;
            }
            else
            {
                resp = responseXml;

            }

            return resp;
        }

        /// <summary>
        ///    Classed used to bypass self-signed server certificate
        /// </summary>
        /// <remarks>
        ///     To be used in development only.
        /// </remarks>
        public class TrustAllCertificatePolicy : System.Net.ICertificatePolicy
        {
            public TrustAllCertificatePolicy()
            {
            }

            public bool CheckValidationResult(ServicePoint sp,
                X509Certificate cert, WebRequest req, int problem)
            {
                return true;
            }
        }
    }
}
