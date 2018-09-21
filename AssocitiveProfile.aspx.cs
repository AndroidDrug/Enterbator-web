using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using EntrebatorBusinesslayer;
using EntrebatorModelClass;
using EntrebatorEnumandConstants;
using EntrebatorUtility;
using EntrebatorErrorHandler;
using System.Configuration;
namespace Entrebator.Associative
{
    public partial class AssocitiveProfile : System.Web.UI.Page
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
        //------------------------------------------------
        //Method for load the profile details
        //----------------------------------------------
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string loadProfileDetails()
        {
            string data = "";
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Guid UserID = new Guid(HttpContext.Current.Session["UserID"].ToString());
            RegistrationModel.GetRegisterDetails objRegisterModel = RegisterManager.GetProfileDetailsByUserID(UserID);
            data = jss.Serialize(objRegisterModel);
            return data;
        }
    }
}