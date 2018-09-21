using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using EntrebatorModelClass;

namespace EntrebatorDataAccesslayer
{
    public class AdminDetails : Entity
    {
        #region PrivateFields

        private ISQLHelper _helper;

        #endregion

        #region Constructors

        public AdminDetails(SqlTransaction Transaction)
        {
            base.Transaction = Transaction;
            _helper = new SQLHelper();
        }

        public AdminDetails(string strConnectionString)
        {
            base.ConnectionString = strConnectionString;
            _helper = new SQLHelper();
        }

        #endregion

        #region Public Methods



        //this method is used to load continent
        public List<AdminModel.GetContinent> LoadContinent()
        {
            return PrivateLoadContinent();
        }
        public List<QuickLinksModel.MemberFeeds> Sp_FetchWallFeedConversation(Guid guid)
        {
            return PrivateSp_FetchWallFeedConversation(guid);
        }

        public int DeleteFeedTop(Guid MemberID, byte memberStatus)
        {
            return PrivateDeleteFeedTop(MemberID, memberStatus);
        }
        public ReferralModel.NotificationList Sp_CheckAnyNotificationsCameOrNot(Guid guid)
        {
            return PrivateSp_CheckAnyNotificationsCameOrNot(guid);
        }


        #endregion

        #region private Methods

        //Method to load continent by id
        private List<AdminModel.GetContinent> PrivateLoadContinent()
        {
            List<AdminModel.GetContinent> ObjListContinent = new List<AdminModel.GetContinent>();
            IDataReader dr = null;
            try
            {
                if (base.Transaction != null)
                    dr = _helper.ExecuteReader(base.Transaction, "LKUContinent_GetAllContinent");
                else
                    dr = _helper.ExecuteReader(base.ConnectionString, "LKUContinent_GetAllContinent");
                while (dr.Read())
                {
                    AdminModel.GetContinent ObjContinent = new AdminModel.GetContinent();
                    if (dr["ContinentID"] != DBNull.Value)
                        ObjContinent.byteContinentID = dr.GetByte(dr.GetOrdinal("ContinentID"));
                    if (dr["ContinentName"] != DBNull.Value)
                        ObjContinent.strContinentName = dr.GetString(dr.GetOrdinal("ContinentName"));
                    ObjListContinent.Add(ObjContinent);
                }
            }
            finally
            {
                if (dr != null)
                    dr.Close();
            }
            return ObjListContinent;
        }
        private List<QuickLinksModel.MemberFeeds> PrivateSp_FetchWallFeedConversation(Guid guid)
        {
            List<QuickLinksModel.MemberFeeds> ObjListContinent = new List<QuickLinksModel.MemberFeeds>();
            IDataReader dataReader = null;
            try
            {
                if (base.Transaction != null)
                {
                    dataReader = _helper.ExecuteReader(base.Transaction, "Sp_FetchWallFeedConversation", guid);
                }
                else
                {
                    dataReader = _helper.ExecuteReader(base.ConnectionString, "Sp_FetchWallFeedConversation", guid);
                }

                while (dataReader.Read())
                {
                    QuickLinksModel.MemberFeeds objFriendsInfo = new QuickLinksModel.MemberFeeds();
                    if (dataReader["MemberID"] != DBNull.Value)
                        objFriendsInfo.MemberID = dataReader.GetGuid(dataReader.GetOrdinal("MemberID"));
                    if (dataReader["FeedID"] != DBNull.Value)
                        objFriendsInfo.FeedID = dataReader.GetGuid(dataReader.GetOrdinal("FeedID"));
                    if (dataReader["Name"] != DBNull.Value)
                        objFriendsInfo.strName = dataReader.GetString(dataReader.GetOrdinal("Name"));
                    if (dataReader["FeedPhoto"] != DBNull.Value)
                        objFriendsInfo.strFeedPhoto = dataReader.GetString(dataReader.GetOrdinal("FeedPhoto"));
                    if (dataReader["BlockedOn"] != DBNull.Value)
                        objFriendsInfo.BlockOn = dataReader.GetDateTime(dataReader.GetOrdinal("BlockedOn"));
                    if (dataReader["AboutFeed"] != DBNull.Value)
                        objFriendsInfo.strFeed = dataReader.GetString(dataReader.GetOrdinal("AboutFeed"));
                    ObjListContinent.Add(objFriendsInfo);
                }
            }
            finally
            {
                if (dataReader != null)
                    dataReader.Close();
            }
            return ObjListContinent;
        }
        private int PrivateDeleteFeedTop(Guid MemberID, byte memberStatus)
        {
            if (base.Transaction != null)
            {
                return _helper.ExecuteNonQuery(base.Transaction, "SP_DeleteAndBlockFeedTopPost", MemberID, memberStatus);
            }
            else
            {
                return _helper.ExecuteNonQuery(base.ConnectionString, "SP_DeleteAndBlockFeedTopPost", MemberID, memberStatus);
            }
        }
        private ReferralModel.NotificationList PrivateSp_CheckAnyNotificationsCameOrNot(Guid guid)
        {
            ReferralModel.NotificationList obj = new ReferralModel.NotificationList();
            IDataReader dataReader = null;
            try
            {
                if (base.Transaction != null)
                {
                    dataReader = _helper.ExecuteReader(base.Transaction, "Sp_CheckAnyNotificationsCameOrNot", guid);
                }
                else
                {
                    dataReader = _helper.ExecuteReader(base.ConnectionString, "Sp_CheckAnyNotificationsCameOrNot", guid);
                }

                while (dataReader.Read())
                {
                    if (dataReader["QntsCount"] != DBNull.Value)
                        obj.QntsCount = dataReader.GetInt32(dataReader.GetOrdinal("QntsCount"));
                    if (dataReader["QuizCount"] != DBNull.Value)
                        obj.QuizCount = dataReader.GetInt32(dataReader.GetOrdinal("QuizCount"));
                    if (dataReader["ReffCount"] != DBNull.Value)
                        obj.ReffCount = dataReader.GetInt32(dataReader.GetOrdinal("ReffCount"));
                    if (dataReader["WallCount"] != DBNull.Value)
                        obj.WallCount = dataReader.GetInt32(dataReader.GetOrdinal("WallCount"));
                    if (dataReader["InvtsCount"] != DBNull.Value)
                        obj.InvtsCount = dataReader.GetInt32(dataReader.GetOrdinal("InvtsCount"));
                    if (dataReader["OnGoQuizCount"] != DBNull.Value)
                        obj.OnGoQuizCount = dataReader.GetInt32(dataReader.GetOrdinal("OnGoQuizCount"));
                    if (dataReader["MGLatestRefferral"] != DBNull.Value)
                        obj.MGLatestRefferral = dataReader.GetInt32(dataReader.GetOrdinal("MGLatestRefferral"));
                    if (dataReader["EngagedTome"] != DBNull.Value)
                        obj.EngagedTome = dataReader.GetInt32(dataReader.GetOrdinal("EngagedTome"));
                    if (dataReader["MyRefferralAccepted"] != DBNull.Value)
                        obj.MyRefferralAccepted = dataReader.GetInt32(dataReader.GetOrdinal("MyRefferralAccepted"));
                    if (dataReader["UserNeed"] != DBNull.Value)
                        obj.UserNeed = dataReader.GetInt32(dataReader.GetOrdinal("UserNeed"));
                    if (dataReader["UserJob"] != DBNull.Value)
                        obj.UserJob = dataReader.GetInt32(dataReader.GetOrdinal("UserJob"));
                    if (dataReader["UserAgent"] != DBNull.Value)
                        obj.UserAgent = dataReader.GetInt32(dataReader.GetOrdinal("UserAgent"));
                    if (dataReader["MGNeed"] != DBNull.Value)
                        obj.MGNeed = dataReader.GetInt32(dataReader.GetOrdinal("MGNeed"));
                    if (dataReader["MGJob"] != DBNull.Value)
                        obj.MGJob = dataReader.GetInt32(dataReader.GetOrdinal("MGJob"));
                    if (dataReader["MGAgent"] != DBNull.Value)
                        obj.MGAgent = dataReader.GetInt32(dataReader.GetOrdinal("MGAgent"));
                    if (dataReader["UnReadNotificationCount"] != DBNull.Value)
                        obj.UnReadNotificationCount = dataReader.GetInt32(dataReader.GetOrdinal("UnReadNotificationCount"));
                    if (dataReader["VersionKey"] != DBNull.Value)
                        obj.VersionKey = dataReader.GetString(dataReader.GetOrdinal("VersionKey"));
                }
            }
            finally
            {
                if (dataReader != null)
                    dataReader.Close();
            }
            return obj;
        }

        #endregion

    }
}
