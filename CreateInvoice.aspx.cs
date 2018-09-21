using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Collections.Specialized;
using EntrebatorBusinesslayer;
using EntrebatorModelClass;
using EntrebatorEnumandConstants;
using EntrebatorErrorHandler;

namespace Entrebator.Associative
{
    public partial class CreateInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Guid UserID = new Guid(HttpContext.Current.Session["UserID"].ToString());
            }
            else
            {
                Response.Redirect(ConfigurationManager.AppSettings["SiteUrl"] + "/MemberLogin.aspx", false);
            }
        }
        [WebMethod]
        public static string EB_Fetch_ETRMemberShips()
        {
            Guid UserID = new Guid(HttpContext.Current.Session["UserID"].ToString());
            string strRet = "";
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<TransactionsModel.MemberShips> listData = TransactionsManager.EB_Fetch_ETRMemberShips();
            strRet = jss.Serialize(listData);
            return strRet;
        }
        [WebMethod]
        public static string EB_Fetch_ETRMemberShipsByMembershipID(Guid MembershipID)
        {
            Guid UserID = new Guid(HttpContext.Current.Session["UserID"].ToString());
            string strRet = "";
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<TransactionsModel.MemberShips> listData = TransactionsManager.EB_Fetch_ETRMemberShips();
            listData = listData.Where(param => param.MembershipID == MembershipID).ToList();
            strRet = jss.Serialize(listData);
            return strRet;
        }
        [WebMethod]
        public static string EB_Fetch_GetFutureEvents()
        {
            Guid UserID = new Guid(HttpContext.Current.Session["UserID"].ToString());
            string strRet = "";
            JavaScriptSerializer jss = new JavaScriptSerializer();
            DateTime date = DateTime.Now;
            List<TransactionsModel.GetFutureEvents> Listdata = TransactionsManager.EB_Fetch_GetFutureEvents(date);
            strRet = jss.Serialize(Listdata);
            return strRet;
        }
        [WebMethod]
        public static string EB_Fetch_GetFutureEventsByEventID(Guid EventID)
        {
            Guid UserID = new Guid(HttpContext.Current.Session["UserID"].ToString());
            string strRet = "";
            JavaScriptSerializer jss = new JavaScriptSerializer();
            DateTime date = DateTime.Now;
            List<TransactionsModel.GetFutureEvents> Listdata = TransactionsManager.EB_Fetch_GetFutureEvents(date);
            Listdata = Listdata.Where(param => param.EventID == EventID).ToList();
            strRet = jss.Serialize(Listdata);
            return strRet;
        }
        [WebMethod]
        //To create the Invoice
        public static long InsertProformaInvoices(string obj)
        {
            long inv = 0;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            TransactionsModel.CreateInvoice ob = new TransactionsModel.CreateInvoice();
            ob = jss.Deserialize<TransactionsModel.CreateInvoice>(obj);
            if (HttpContext.Current.Session["UserID"].ToString() == null)
            {
                HttpContext.Current.Response.Redirect(ConfigurationManager.AppSettings["SiteUrl"] + "/MemberLogin.aspx", false);
            }
            ob.CreatedBy = new Guid(HttpContext.Current.Session["UserId"].ToString());
            ob.Status = (byte)EntrebatorEnumandConstants.Enumbers.InvoiceStatus.Sent;
            // ob.CreatedOn = DateTime.Now;
            ob.ItemID = Guid.NewGuid();
            ob.Currency = "INR";
            ob.InvoiceType = 1;
            inv = TransactionsManager.InsertProformaInvoices(ob);
            if (inv != 0)
            {
                ob.InvoiceID = inv;
                int xx = TransactionsManager.InsertProformaInvoiceItems(ob);
                //1 means performainvoice table values
                SendMail(inv, 1);
            }
            return inv;
        }
        [WebMethod]
        //To create the Invoice
        public static long InsertReceiptInvoices(string obj)
        {
            long inv = 0;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            TransactionsModel.ReceiptInvoice ob = new TransactionsModel.ReceiptInvoice();
            ob = jss.Deserialize<TransactionsModel.ReceiptInvoice>(obj);
            if (HttpContext.Current.Session["UserID"].ToString() == null)
            {
                HttpContext.Current.Response.Redirect(ConfigurationManager.AppSettings["SiteUrl"] + "/MemberLogin.aspx", false);
            }
            ob.CreatedBy = new Guid(HttpContext.Current.Session["UserId"].ToString());
            ob.Status = (byte)EntrebatorEnumandConstants.Enumbers.InvoiceStatus.Paid;
            // ob.CreatedOn = DateTime.Now;
            ob.ItemID = Guid.NewGuid();
            ob.Currency = "INR";
            ob.InvoiceType = 2;
            inv = TransactionsManager.InsertReceiptInvoices(ob);
            if (inv != 0)
            {
                ob.InvoiceID = inv;
                int xx = TransactionsManager.InsertReceiptInvoiceItems(ob);
                //1 means performainvoice table values
                SendMailPayment(inv, 2);
                SendReceiptMail(inv, 2);
            }
            return inv;
        }
        //To Get All User Details 
        [WebMethod]
        public static AssociativeModel.GetUserData EB_GetUserDetails(Guid UserID)
        {
            return AssociativeManager.EB_GetUserDetails(UserID);
        }
        private static void SendMail(long InvoiceID, byte InvoiceType)
        {

            string strFromEmail = System.Configuration.ConfigurationManager.AppSettings["PaymentEmail"].ToString();
            TransactionsModel.GetInvoiceByInvoiceID obj = TransactionsManager.EB_FetechInvoiceByInvoiceID(InvoiceID, InvoiceType);
            string strToEmail = obj.Email;
            string Invoice = EntrebatorUtility.EncryptionAndDecryption.EncryptInvoice(InvoiceID.ToString());
            string strMessageBody;
            //  DateTime Exposedate = obj.InvoiceDate.AddDays(3);
            string strMailSubject = "Proforma Invoice from  ONE ON ONE LINKS PRIVATE LIMITED";
            string InvoiceURL = System.Configuration.ConfigurationManager.AppSettings["SiteUrl"] + "/PayInvoiceAmount.aspx?invid=" + Invoice;
            NameValueCollection mergeFields = new NameValueCollection();
            mergeFields.Add("**SiteURL**", ConfigurationManager.AppSettings["SiteUrl"].ToString());
            mergeFields.Add("**InvoiceID**", obj.InvoiceID.ToString());
            mergeFields.Add("**Name**", obj.Name);
            mergeFields.Add("**Email**", obj.Email);
            mergeFields.Add("**Mobile**", obj.Mobile);
            mergeFields.Add("**Address**", obj.Address);
            mergeFields.Add("**InvoiceDate**", obj.InvoiceDate.ToString("MM/dd/yyyy"));
            mergeFields.Add("**ActualAmount**", obj.ActualAmount.ToString());
            mergeFields.Add("**DiscAmount**", obj.DiscAmount.ToString());
            mergeFields.Add("**BeforeTaxAmount**", obj.BeforeTaxAmount.ToString());
            mergeFields.Add("**FinalAmount**", obj.FinalAmount.ToString());
            mergeFields.Add("**Terms**", obj.Terms);
            mergeFields.Add("**ClientGST**", obj.ClientGST);
            mergeFields.Add("**Description**", obj.Description);
            mergeFields.Add("**Quantity**", obj.Quantity.ToString());
            mergeFields.Add("**CGST**", obj.CGST.ToString());
            mergeFields.Add("**SGST**", obj.SGST.ToString());
            mergeFields.Add("**InvoiceURL**", InvoiceURL);
            // mergeFields.Add("**Exposedate**", Exposedate.ToString("MM/dd/yyyy"));
            strMessageBody = EntrebatorUtility.EmailUtils.GetMailBody("PInvoice.html", mergeFields);
            try
            {

                EntrebatorUtility.SendGrid.SendInvoiceEmail(strFromEmail, strToEmail, strMailSubject, strMessageBody);
                //EntrebatorUtility.EmailUtils.SendInvoiceEmail(strFromEmail, strToEmail, strMailSubject, strMessageBody);

            }
            catch (Exception ex)
            {
                ErrorLogHelper.LogException(ex, Log.LoggingSeverity.Error);

            }
        }
        private static void SendReceiptMail(long InvoiceID, byte InvoiceType)
        {
            string strFromEmail = System.Configuration.ConfigurationManager.AppSettings["PaymentEmail"].ToString();
            TransactionsModel.GetInvoiceByInvoiceID obj = TransactionsManager.EB_FetechInvoiceByInvoiceID(InvoiceID, InvoiceType);
            string strToEmail = obj.Email;
            string strMessageBody;
            string strMailSubject = "Receipt from ONE ON ONE LINKS PRIVATE LIMITED";
            NameValueCollection mergeFields = new NameValueCollection();
            mergeFields.Add("**InvoiceID**", obj.InvoiceID.ToString());
            mergeFields.Add("**Name**", obj.Name);
            mergeFields.Add("**Email**", obj.Email);
            mergeFields.Add("**Mobile**", obj.Mobile);
            mergeFields.Add("**Address**", obj.Address);
            mergeFields.Add("**InvoiceDate**", obj.InvoiceDate.ToString("MM/dd/yyyy"));
            mergeFields.Add("**ActualAmount**", obj.ActualAmount.ToString());
            mergeFields.Add("**DiscAmount**", obj.DiscAmount.ToString());
            mergeFields.Add("**BeforeTaxAmount**", obj.BeforeTaxAmount.ToString());
            mergeFields.Add("**FinalAmount**", obj.FinalAmount.ToString());
            mergeFields.Add("**Terms**", obj.Terms);
            mergeFields.Add("**ClientGST**", obj.ClientGST);
            mergeFields.Add("**Description**", obj.Description);
            mergeFields.Add("**Quantity**", obj.Quantity.ToString());
            mergeFields.Add("**CGST**", obj.CGST.ToString());
            mergeFields.Add("**SGST**", obj.SGST.ToString());
            mergeFields.Add("**ChequeDate**", obj.ChequeDate.ToString("MM/dd/yyyy"));
            mergeFields.Add("**StrPaymentMode**", obj.StrPaymentStatus);
            mergeFields.Add("**ChequeAmount**", obj.ChequeAmount.ToString());
            strMessageBody = EntrebatorUtility.EmailUtils.GetMailBody("InvReceipt.html", mergeFields);
            try
            {
                EntrebatorUtility.SendGrid.SendInvoiceEmail(strFromEmail, strToEmail, strMailSubject, strMessageBody);
                // EntrebatorUtility.EmailUtils.SendInvoiceEmail(strFromEmail, strToEmail, strMailSubject, strMessageBody);

            }
            catch (Exception ex)
            {
                ErrorLogHelper.LogException(ex, Log.LoggingSeverity.Error);

            }
        }
        private static void SendMailPayment(long InvoiceID, byte InvoiceType)
        {

            string strFromEmail = System.Configuration.ConfigurationManager.AppSettings["PaymentEmail"].ToString();
            TransactionsModel.GetInvoiceByInvoiceID obj = TransactionsManager.EB_FetechInvoiceByInvoiceID(InvoiceID, InvoiceType);
            string strToEmail = obj.Email;
            string Invoice = EntrebatorUtility.EncryptionAndDecryption.EncryptInvoice(InvoiceID.ToString());
            string strMessageBody;
            //  DateTime Exposedate = obj.InvoiceDate.AddDays(3);
            string strMailSubject = "Proforma Invoice from  ONE ON ONE LINKS PRIVATE LIMITED";
            string InvoiceURL = System.Configuration.ConfigurationManager.AppSettings["SiteUrl"] + "/PayInvoiceAmount.aspx?invid=" + Invoice;
            NameValueCollection mergeFields = new NameValueCollection();
            mergeFields.Add("**SiteURL**", ConfigurationManager.AppSettings["SiteUrl"].ToString());
            mergeFields.Add("**InvoiceID**", obj.InvoiceID.ToString());
            mergeFields.Add("**Name**", obj.Name);
            mergeFields.Add("**Email**", obj.Email);
            mergeFields.Add("**Mobile**", obj.Mobile);
            mergeFields.Add("**Address**", obj.Address);
            mergeFields.Add("**InvoiceDate**", obj.InvoiceDate.ToString("MM/dd/yyyy"));
            mergeFields.Add("**ActualAmount**", obj.ActualAmount.ToString());
            mergeFields.Add("**DiscAmount**", obj.DiscAmount.ToString());
            mergeFields.Add("**BeforeTaxAmount**", obj.BeforeTaxAmount.ToString());
            mergeFields.Add("**FinalAmount**", obj.FinalAmount.ToString());
            mergeFields.Add("**Terms**", obj.Terms);
            mergeFields.Add("**ClientGST**", obj.ClientGST);
            mergeFields.Add("**Description**", obj.Description);
            mergeFields.Add("**Quantity**", obj.Quantity.ToString());
            mergeFields.Add("**CGST**", obj.CGST.ToString());
            mergeFields.Add("**SGST**", obj.SGST.ToString());
            mergeFields.Add("**InvoiceURL**", InvoiceURL);
            // mergeFields.Add("**Exposedate**", Exposedate.ToString("MM/dd/yyyy"));
            strMessageBody = EntrebatorUtility.EmailUtils.GetMailBody("PaymntInvoice.html", mergeFields);
            try
            {

                EntrebatorUtility.SendGrid.SendInvoiceEmail(strFromEmail, strToEmail, strMailSubject, strMessageBody);
                //EntrebatorUtility.EmailUtils.SendInvoiceEmail(strFromEmail, strToEmail, strMailSubject, strMessageBody);

            }
            catch (Exception ex)
            {
                ErrorLogHelper.LogException(ex, Log.LoggingSeverity.Error);

            }
        }
    }
}