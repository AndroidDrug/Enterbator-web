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
    public partial class DisplayInvoces : System.Web.UI.Page
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
        public static string EB_FetechAllInvoices()
        {
            Guid UserID = new Guid(HttpContext.Current.Session["UserID"].ToString());
            string strRet = "";
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<TransactionsModel.FetchInvoices> listData = TransactionsManager.EB_FetechAllInvoices(UserID);
            strRet = jss.Serialize(listData);
            return strRet;
        }
        [WebMethod]
        public static string EB_FetechpaidInvoices()
        {
            Guid UserID = new Guid(HttpContext.Current.Session["UserID"].ToString());
            string strRet = "";
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<TransactionsModel.FetchInvoices> listData = TransactionsManager.EB_FetechpaidInvoices(UserID);
            strRet = jss.Serialize(listData);
            return strRet;
        }
        [WebMethod]
        //To create the Invoice
        public static long UpdateInvoices(string obj)
        {
            long inv = 0;
            if (HttpContext.Current.Session["UserID"].ToString() == null)
            {
                HttpContext.Current.Response.Redirect(ConfigurationManager.AppSettings["SiteUrl"] + "/MemberLogin.aspx", false);
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            TransactionsModel.FetchInvoices ob = new TransactionsModel.FetchInvoices();
            ob = jss.Deserialize<TransactionsModel.FetchInvoices>(obj);
            inv = TransactionsManager.UpdateInvoices(ob);
            if(inv !=0)
            {
                //1 means performainvoice table values
                SendMail(inv, ob.InvoiceType);
            }
            return inv;
        }
        [WebMethod]
        public static long CashPayment(string Obj)
        {
            int ret = 0;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            TransactionsModel.UPDateReceiptTransaction objj = new TransactionsModel.UPDateReceiptTransaction();
            objj = jss.Deserialize<TransactionsModel.UPDateReceiptTransaction>(Obj);
            objj.Status = (byte)EntrebatorEnumandConstants.Enumbers.InvoiceStatus.Paid;
            objj.PaymentMode = (byte)EntrebatorEnumandConstants.Enumbers.PaymentMode.Cash;
            long r = TransactionsManager.UpdateReceiptTransations(objj);
            if(r!=0)
            {
                SendReceiptMail(r, 2);
            }
            return r;
        }
        [WebMethod]
        public static long ChequePayment(string Obj)
        {
            int ret = 0;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            TransactionsModel.UPDateReceiptTransaction objj = new TransactionsModel.UPDateReceiptTransaction();
            objj = jss.Deserialize<TransactionsModel.UPDateReceiptTransaction>(Obj);
            objj.Status = (byte)EntrebatorEnumandConstants.Enumbers.InvoiceStatus.Paid;
            objj.PaymentMode = (byte)EntrebatorEnumandConstants.Enumbers.PaymentMode.Cheque;
            long r = TransactionsManager.UpdateReceiptTransations(objj);
            if (r != 0)
            {
                SendReceiptMail(r, 2);
            }
            return r;
        }
        [WebMethod]
        public static long NeftPayment(string Obj)
        {
            int ret = 0;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            TransactionsModel.UPDateReceiptTransaction objj = new TransactionsModel.UPDateReceiptTransaction();
            objj = jss.Deserialize<TransactionsModel.UPDateReceiptTransaction>(Obj);
            objj.Status = (byte)EntrebatorEnumandConstants.Enumbers.InvoiceStatus.Paid;
            objj.PaymentMode = (byte)EntrebatorEnumandConstants.Enumbers.PaymentMode.Neft;
            long r = TransactionsManager.UpdateReceiptTransations(objj);
            if (r != 0)
            {
                SendReceiptMail(r, 2);
            }
            return r;
        }
        [WebMethod]
        public static long PaytmPayment(string Obj)
        {
            int ret = 0;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            TransactionsModel.UPDateReceiptTransaction objj = new TransactionsModel.UPDateReceiptTransaction();
            objj = jss.Deserialize<TransactionsModel.UPDateReceiptTransaction>(Obj);
            objj.Status = (byte)EntrebatorEnumandConstants.Enumbers.InvoiceStatus.Paid;
            objj.PaymentMode = (byte)EntrebatorEnumandConstants.Enumbers.PaymentMode.Paytm;
            long r = TransactionsManager.UpdateReceiptTransations(objj);
            if (r != 0)
            {
                SendReceiptMail(r, 2);
            }
            return r;
        }
        [WebMethod]
        public static long EzetapPayment(string Obj)
        {
            int ret = 0;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            TransactionsModel.UPDateReceiptTransaction objj = new TransactionsModel.UPDateReceiptTransaction();
            objj = jss.Deserialize<TransactionsModel.UPDateReceiptTransaction>(Obj);
            objj.Status = (byte)EntrebatorEnumandConstants.Enumbers.InvoiceStatus.Paid;
            objj.PaymentMode = (byte)EntrebatorEnumandConstants.Enumbers.PaymentMode.Ezetap;
            long r = TransactionsManager.UpdateReceiptTransations(objj);
            if (r != 0)
            {
                SendReceiptMail(r, 2);
            }
            return r;
        }
        //to delete invoice by invoiceid
        [WebMethod]
        public static int DeleteInvoiceByInvoiceID(long InvoiceId, byte InvoiceType)
        {
            byte Status = 0;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Status = (byte)EntrebatorEnumandConstants.Enumbers.InvoiceStatus.Canceled;
            int r = TransactionsManager.DeleteInvoiceByInvoiceID(InvoiceId, InvoiceType, Status);
            return r;
        }
        //to resend invoice
        [WebMethod]
        public static int ResendInvoice(long InvoiceId, byte InvoiceType)
        {
            byte ss =1 ;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            SendMail(InvoiceId, InvoiceType);
            return ss;
        }
        //to resend Receiptinvoice
        [WebMethod]
        public static int ResendReceiptInvoice(long InvoiceId, byte InvoiceType)
        {
            byte ss = 1;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            SendReceiptMail(InvoiceId, InvoiceType);
            return ss;
        }
        private static void SendMail(long InvoiceID, byte InvoiceType)
        {
            
            string strFromEmail = System.Configuration.ConfigurationManager.AppSettings["PaymentEmail"].ToString();
            TransactionsModel.GetInvoiceByInvoiceID obj = TransactionsManager.EB_FetechInvoiceByInvoiceID(InvoiceID, InvoiceType);
            string strToEmail = obj.Email;
            string Invoice = EntrebatorUtility.EncryptionAndDecryption.EncryptInvoice(InvoiceID.ToString());
            string strMessageBody;
           // DateTime Exposedate = obj.InvoiceDate.AddDays(3);
            string strMailSubject = "Proforma Invoice from ONE ON ONE LINKS PRIVATE LIMITED";
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
                //  EntrebatorUtility.EmailUtils.SendInvoiceEmail(strFromEmail, strToEmail, strMailSubject, strMessageBody);

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
    }
}