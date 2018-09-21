using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using System.Net;
using System.IO;
using EntrebatorModelClass;
using EntrebatorBusinesslayer;
using System.Collections.Specialized;

namespace EntrebatorUtility
{
    public static class SMSManager
    {
        public static string SendSMS(string Number, string Message)
        {
            string sURL = "http://alerts.variforrmsolution.com/api/v3/index.php?method=sms&api_key=A860740c26bc8e71ba23ae761616fb276&to=" + Number + "&sender=EBATOR&message=" + Message;

            string sResponse = GetResponse(sURL);
            return sResponse;
        }
        public static string SendSMSForRegistration(string Number, string Message)
        {
            // String message = HttpUtility.UrlEncode("This is your message");
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , "cff735680249c42e9d0f298af19f628e0cb5128172aa5b21fd04745a3dfb4967"},
                {"username","subhash@rsosbiz.com" },
                {"password","22SMSsms@@" },
                {"numbers" , Number},
                {"message" , Message},
                {"sender" , "EBATOR"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                return result;
            }
        }
        public static string GetResponse(string sURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return sResponse;
            }
            catch
            {
                return "failed";
            }
        }
        public static int EB_ToInsertNotifications(Guid NotificationFrom_ID, Guid NotificationTo_ID, string Notification_Desc, Guid Notificationkey_ID, string NotificationKey, byte Notification_Type, string IndustryID)
        {

            int i = 0;
            TransactionsModel.Notifications_ToCreate obj = new TransactionsModel.Notifications_ToCreate();
            obj.Notification_ID = Guid.NewGuid();
            obj.NotificationFrom_ID = NotificationFrom_ID;
            obj.NotificationTo_ID = NotificationTo_ID;
            obj.Notification_Desc = Notification_Desc;
            obj.Created_ON = DateTime.UtcNow.AddMinutes(-90);
            obj.Read_Status = false;
            obj.Notificationkey_ID = Notificationkey_ID;
            obj.Notification_Type = Notification_Type;
            obj.IndustryID = Convert.ToInt16(IndustryID);
            obj.NotificationKey = NotificationKey;
            i = TransactionsManager.EB_SP_Notifications_ToInsert(obj);
            return i;

        }
    }
}
