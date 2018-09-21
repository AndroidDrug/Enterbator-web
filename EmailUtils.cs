using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mail;
using System.Collections.Specialized;
using System.Data;
using System.Web;

namespace EntrebatorUtility
{
    public static class EmailUtils
    {
        public static int SendEmail(string strMailFrom, string strMailTo, string strSubject, string strBody)
        {
            try
            {
                //const string SERVER = "dedrelay.secureserver.net";
                //MailMessage oMail = new System.Web.Mail.MailMessage();
                //oMail.From = strMailFrom;
                //oMail.To = strMailTo;
                //oMail.Subject = strSubject;
                //oMail.BodyFormat = MailFormat.Html; // enumeration
                //oMail.Priority = MailPriority.High; // enumeration
                //oMail.Body = strBody;
                //SmtpMail.SmtpServer = SERVER;
                //SmtpMail.Send(oMail);
                //oMail = null; // free up resource
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }
        public static int SendInvoiceEmail(string strMailFrom, string strMailTo, string strSubject, string strBody)
        {
            try
            {
                const string SERVER = "dedrelay.secureserver.net";
                MailMessage oMail = new System.Web.Mail.MailMessage();
                oMail.From = strMailFrom;
                oMail.To = strMailTo;
                oMail.Subject = strSubject;
                oMail.BodyFormat = MailFormat.Html; // enumeration
                oMail.Priority = MailPriority.High; // enumeration
                oMail.Body = strBody;
                SmtpMail.SmtpServer = SERVER;
                SmtpMail.Send(oMail);
                oMail = null; // free up resource
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }
        public static int SendEmailWithCC(string strMailFrom, string strMailTo, string strCCMailTo, string strSubject, string strBody)
        {
            try
            {
                //const string SERVER = "dedrelay.secureserver.net";
                //MailMessage oMail = new System.Web.Mail.MailMessage();
                //oMail.From = strMailFrom;
                //oMail.Cc = "strCCMailTo";
                //oMail.To = strMailTo;
                //oMail.Subject = strSubject;
                //oMail.BodyFormat = MailFormat.Html; // enumeration
                //oMail.Priority = MailPriority.High; // enumeration
                //oMail.Body = strBody;
                //SmtpMail.SmtpServer = SERVER;
                //SmtpMail.Send(oMail);
                //oMail = null; // free up resource
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }
        public static int SendEmailWithAttachment(string strMailFrom, string strMailTo, string strSubject, string strBody, DataTable dtAttachment)
        {
            try
            {
                //const string SERVER = "dedrelay.secureserver.net";
                //MailMessage oMail = new System.Web.Mail.MailMessage();
                //oMail.From = strMailFrom;
                //oMail.To = strMailTo;
                //oMail.Subject = strSubject;
                //oMail.BodyFormat = MailFormat.Html; // enumeration
                //oMail.Priority = MailPriority.High; // enumeration
                //oMail.Body = strBody;
                //for (int temp = 0; temp < dtAttachment.Rows.Count; temp++)
                //{
                //    oMail.Attachments.Add(new MailAttachment(dtAttachment.Rows[temp]["url"].ToString()));
                //}
                //SmtpMail.SmtpServer = SERVER;
                //SmtpMail.Send(oMail);
                //oMail = null; // free up resource
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }
        public static string LoadTemplateFile(string fileName, NameValueCollection mergeFields)
        {
            StringBuilder result = new StringBuilder(System.IO.File.ReadAllText(fileName));

            if (mergeFields != null)
            {
                for (int index = 0; index < mergeFields.Count; index++)
                {
                    result = result.Replace(mergeFields.Keys[index], mergeFields[index]);
                }
            }
            return result.ToString();
        }
        public static string GetMailBody(string fileName, NameValueCollection mergeFields)
        {
        string strContentName = HttpContext.Current.Request.PhysicalApplicationPath + "EmailTemplete\\" + fileName;
            return LoadTemplateFile(strContentName, mergeFields);

        }
    }
}
