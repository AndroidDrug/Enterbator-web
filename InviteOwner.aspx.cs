using EntrebatorBusinesslayer;
using EntrebatorEnumandConstants;
using EntrebatorModelClass;
using EntrebatorUtility;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Entrebator.CountryAdmin
{
    public partial class InviteOwner : System.Web.UI.Page
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

        //-------------------------------------------------------------------------
        // check email already register or not for inviting
        //-------------------------------------------------------------------------
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string CheckEmail(string emlVal)
        {
            string data = "0";
            JavaScriptSerializer jss = new JavaScriptSerializer();
            int count = ContactManager.CheckEmail(emlVal);
            if (count > 0)
                data = jss.Serialize(count);
            return data;
        }

        //-------------------------------------------------------------------------
        // check mobile register or not for inviting
        //-------------------------------------------------------------------------
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string CheckMobile(string mobile)
        {
            string data = "0";
            JavaScriptSerializer jss = new JavaScriptSerializer();
            int count = ContactManager.CheckMobile(mobile);
            if (count > 0)
                data = jss.Serialize(count);
            return data;
        }

        //-------------------------------------
        //Method for invite business owners
        //-------------------------------------
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string InviteBOwner(string obj)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            InvitationType it = new InvitationType();
            it = jss.Deserialize<InvitationType>(obj);
            Guid UserID = new Guid(HttpContext.Current.Session["UserID"].ToString());
            int rValue = 0;
            RegistrationModel.GetRegisterDetails ObjUserInfo = RegisterManager.GetProfileDetailsByUserID(UserID);
            string strFullName = ObjUserInfo.strFirstName + " " + ObjUserInfo.strLastName;
            string strEmailID = it.strEmail;
            string strMailSubject = "Be part of business contacts and grow your business!";
            Guid OwnerInvitationID = Guid.NewGuid();
            string RegistrationLink = System.Configuration.ConfigurationManager.AppSettings["SiteURL"] + "/LaunchPage.aspx?InviID=" + OwnerInvitationID + "&&mid=" + UserID;
            NameValueCollection mergeFields = new NameValueCollection();
            mergeFields.Add("**REGISTRATIONURL**", RegistrationLink);
            mergeFields.Add("**ToName**", it.strName);
            mergeFields.Add("**FromName**", strFullName);
            mergeFields.Add("**FromEmail**", ObjUserInfo.strEmail);
            mergeFields.Add("**FromMobile**", ObjUserInfo.strMobile);
            ContactsModel.InviteOwner ObjOwnr = jss.Deserialize<ContactsModel.InviteOwner>(obj);
            string strMessageBody = EmailUtils.GetMailBody("InviteByHelpdesk.html", mergeFields);
            Guid InvitedToID = new Guid();
            EmailUtils.SendEmail(ObjUserInfo.strEmail, strEmailID, strMailSubject, strMessageBody);
            //insert query
            ObjOwnr.guidOwnerInvitationID = OwnerInvitationID;
            ObjOwnr.guidInvitedByID = UserID;
            ObjOwnr.guidInvitedToID = InvitedToID;
            ObjOwnr.byteMInvitationStatus = Convert.ToByte(UIEnums.MInvitationStatus.Sent);
            ObjOwnr.strEmail = it.strEmail;
            ObjOwnr.strName = it.strName;
            ObjOwnr.strMobile = it.strMobile;
            rValue = ContactManager.InviteOwner(ObjOwnr);
            return rValue.ToString();
        }
        public class InvitationType
        {
            public Guid guidOwnerInvitationID { get; set; }
            public Guid guidInvitedByID { get; set; }
            public Guid guidInvitedToID { get; set; }
            public DateTime dateInvitationDate { get; set; }
            public string strEmail { get; set; }
            public string strName { get; set; }
            public string strInvitationMessage { get; set; }
            public string strMobile { get; set; }
        }
    }
}