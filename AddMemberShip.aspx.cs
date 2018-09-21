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

namespace Entrebator.Associative
{
    public partial class AddMemberShip : System.Web.UI.Page
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
        public static List<AssociativeModel.GetAllVerifiedUsersForMembership> EB_Fetchallverifiedmembersformembership(Guid UserID)
        {
            List<AssociativeModel.GetAllVerifiedUsersForMembership> obj = new List<AssociativeModel.GetAllVerifiedUsersForMembership>();
            obj = AssociativeManager.EB_Fetchallverifiedmembersformembership(UserID);
            return obj;
        }
    }
}