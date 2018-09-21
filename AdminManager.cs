using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntrebatorModelClass;
using EntrebatorEnumandConstants;

namespace EntrebatorBusinesslayer
{
    public class AdminManager
    {
        #region Public Methods

        public static int Invitaionsend(ContactsModel.Invitation objInvite)
        {
            int intRetunValue = 0;
            using (DALHelper dalHelper = new DALHelper())
            {
                try
                {
                    dalHelper.OpenConnectionWithTransaction();
                    intRetunValue = dalHelper.GetDal_ContactDetails(true).Invitaionsend(objInvite);
                    dalHelper.EndConnectionAndCommitTransaction();
                }
                catch (Exception)
                {
                    dalHelper.EndConnectionAndRollBackTransaction();
                    throw;
                }
            }
            return intRetunValue;
        }

        //this method is used to get continent 
        public static List<AdminModel.GetContinent> LoadContinent()
        {
            using (DALHelper dalHelper = new DALHelper())
            {
                return dalHelper.GetDAL_AdminDetails(false).LoadContinent();
            }
        }
        public static List<QuickLinksModel.MemberFeeds> Sp_FetchWallFeedConversation(Guid guid)
        {
            using (DALHelper dalHelper = new DALHelper())
            {
                return dalHelper.GetDAL_AdminDetails(false).Sp_FetchWallFeedConversation(guid);
            }
        }

        public static int DeleteFeedTop(Guid MemberID, byte memberStatus)
        {
            int intRetunValue = 0;
            using (DALHelper dal = new DALHelper())
            {
                try
                {
                    dal.OpenConnectionWithTransaction();
                    intRetunValue = dal.GetDAL_AdminDetails(true).DeleteFeedTop(MemberID, memberStatus);
                    dal.EndConnectionAndCommitTransaction();
                }
                catch (Exception)
                {
                    dal.EndConnectionAndRollBackTransaction();
                    throw;
                }
            }
            return intRetunValue;
        }
        public static ReferralModel.NotificationList Sp_CheckAnyNotificationsCameOrNot(Guid guid)
        {
            using (DALHelper dalHelper = new DALHelper())
            {
                return dalHelper.GetDAL_AdminDetails(false).Sp_CheckAnyNotificationsCameOrNot(guid);
            }
        }
        //Method For update the notification update status
        public static int EB_MC_UpdateNotificationCameAfterSeenByType(Guid MemberID, byte Type)
        {
            int intRetunValue = 0;
            using (DALHelper dal = new DALHelper())
            {
                try
                {
                    dal.OpenConnectionWithTransaction();
                    intRetunValue = dal.GetDAL_MemberMGDetails(true).EB_MC_UpdateNotificationCameAfterSeenByType(MemberID, Type);
                    dal.EndConnectionAndCommitTransaction();
                }
                catch (Exception)
                {
                    dal.EndConnectionAndRollBackTransaction();
                    throw;
                }
            }
            return intRetunValue;
        }
        #endregion




    }
}
