#region Using Statement

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using EntrebatorDataAccesslayer;
using EntrebatorModelClass;

#endregion Using Statement

namespace DataAccessLayer
{
    public class DALHelper : IDisposable
    {
        #region basics

        private readonly string _connectionString;
        private SqlTransaction _transaction;
        private SqlConnection _connection;

        public DALHelper()
        {
            _connectionString = (ConfigurationManager.ConnectionStrings["sqlConnectionString"]).ToString();
        }

        public DALHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void OpenConnectionWithTransaction()
        {
            try
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
                _transaction = _connection.BeginTransaction();
            }
            catch (Exception ex)
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                }
                throw ex;
            }
        }

        public void EndConnectionAndCommitTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
                _transaction.Dispose();
            }
            if (_connection != null)
            {
                _connection.Dispose();
            }
        }

        public void EndConnectionAndRollBackTransaction()
        {
            if (_transaction != null)
            {
                try
                {
                    _transaction.Rollback();
                    _transaction.Dispose();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (_connection != null)
            {
                _connection.Dispose();
            }
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
            if (_connection != null)
            {
                _connection.Dispose();
            }
        }

        #endregion basics

        public UserDetails GetDAL_UserDetails(bool withTransaction)
        {
            UserDetails objRegistrationDetails = null;
            if (!withTransaction)
            {
                objRegistrationDetails = new UserDetails(_connectionString);
            }
            else
            {
                objRegistrationDetails = new UserDetails(_transaction);
            }
            return objRegistrationDetails;
        }

        public RegisterDetails GetDal_RegisterDetails(bool withTransaction)
        {
            RegisterDetails objRegisterDetails = null;
            if (withTransaction)
                objRegisterDetails = new RegisterDetails(_transaction);
            else
                objRegisterDetails = new RegisterDetails(_connectionString);
            return objRegisterDetails;
        }

        public ContactDetails GetDal_ContactDetails(bool withTransaction)
        {
            ContactDetails objRegisterDetails = null;
            if (withTransaction)
                objRegisterDetails = new ContactDetails(_transaction);
            else
                objRegisterDetails = new ContactDetails(_connectionString);
            return objRegisterDetails;
        }

        public MemberVerifyDetails GetDAL_MemberVerifyDetails(bool withTransaction)
        {
            MemberVerifyDetails objRegisterDetails = null;
            if (withTransaction)
                objRegisterDetails = new MemberVerifyDetails(_transaction);
            else
                objRegisterDetails = new MemberVerifyDetails(_connectionString);
            return objRegisterDetails;
        }

        public AdminDetails GetDAL_AdminDetails(bool withTransaction)
        {
            AdminDetails objRegisterDetails = null;
            if (withTransaction)
                objRegisterDetails = new AdminDetails(_transaction);
            else
                objRegisterDetails = new AdminDetails(_connectionString);
            return objRegisterDetails;
        }

        public ReportedDetails GetDAL_ReportedDetails(bool withTransaction)
        {
            ReportedDetails ObjReportedDetails = null;
            if (withTransaction)
                ObjReportedDetails = new ReportedDetails(_transaction);
            else
                ObjReportedDetails = new ReportedDetails(_connectionString);
            return ObjReportedDetails;
        }

        public CompanyDetails GetDAL_CompanyDetails(bool withTransaction)
        {
            CompanyDetails ObjCompanyDetails = null;
            if (withTransaction)
                ObjCompanyDetails = new CompanyDetails(_transaction);
            else
                ObjCompanyDetails = new CompanyDetails(_connectionString);
            return ObjCompanyDetails;
        }

        public PointsDetails GetDAL_PointsDetails(bool withTransaction)
        {
            PointsDetails ObjPointsDetails = null;
            if (withTransaction)
                ObjPointsDetails = new PointsDetails(_transaction);
            else
                ObjPointsDetails = new PointsDetails(_connectionString);
            return ObjPointsDetails;
        }

        public ReferralDetails GetDAL_ReferralDetails(bool withTransaction)
        {
            ReferralDetails ObjreferralDetails = null;
            if (withTransaction)
                ObjreferralDetails = new ReferralDetails(_transaction);
            else
                ObjreferralDetails = new ReferralDetails(_connectionString);
            return ObjreferralDetails;
        }

        public RatingsDetails GetDAL_RatingsDetails(bool withTransaction)
        {
            RatingsDetails ObjRatingDetails = null;
            if (withTransaction)
                ObjRatingDetails = new RatingsDetails(_transaction);
            else
                ObjRatingDetails = new RatingsDetails(_connectionString);
            return ObjRatingDetails;
        }

        public HistoryDetails GetDAL_HistoryDetails(bool withTransaction)
        {
            HistoryDetails ObjHistoryDetails = null;
            if (withTransaction)
                ObjHistoryDetails = new HistoryDetails(_transaction);
            else
                ObjHistoryDetails = new HistoryDetails(_connectionString);
            return ObjHistoryDetails;
        }

        public OrganizerDetails GetDAL_OrganizerDetails(bool withTransaction)
        {
            OrganizerDetails ObjOrganizerDetails = null;
            if (withTransaction)
                ObjOrganizerDetails = new OrganizerDetails(_transaction);
            else
                ObjOrganizerDetails = new OrganizerDetails(_connectionString);
            return ObjOrganizerDetails;
        }

        public MentorDetails GetDAL_MentorDetails(bool withTransaction)
        {
            MentorDetails ObjMentorDetails = null;
            if (withTransaction)
                ObjMentorDetails = new MentorDetails(_transaction);
            else
                ObjMentorDetails = new MentorDetails(_connectionString);
            return ObjMentorDetails;
        }

        public GroupLeaderDetails GetDAL_GroupLeaderDetails(bool withTransaction)
        {
            GroupLeaderDetails ObjGroupLeaderDetails = null;
            if (withTransaction)
                ObjGroupLeaderDetails = new GroupLeaderDetails(_transaction);
            else
                ObjGroupLeaderDetails = new GroupLeaderDetails(_connectionString);
            return ObjGroupLeaderDetails;
        }

        public AssociativeDetails GetDAL_AssociativeDetails(bool withTransaction)
        {
            AssociativeDetails ObjAssociativeDetails = null;
            if (withTransaction)
                ObjAssociativeDetails = new AssociativeDetails(_transaction);
            else
                ObjAssociativeDetails = new AssociativeDetails(_connectionString);
            return ObjAssociativeDetails;
        }

        public MemberMGDetails GetDAL_MemberMGDetails(bool withTransaction)
        {
            MemberMGDetails ObjMemberMGDetails = null;
            if (withTransaction)
                ObjMemberMGDetails = new MemberMGDetails(_transaction);
            else
                ObjMemberMGDetails = new MemberMGDetails(_connectionString);
            return ObjMemberMGDetails;
        }

        public MemberShipDetails GetMemberShipDetails(bool withTransaction)
        {
            MemberShipDetails objMemberShipDetails = null;
            if (withTransaction)
                objMemberShipDetails = new MemberShipDetails(_transaction);
            else
                objMemberShipDetails = new MemberShipDetails(_connectionString);

            return objMemberShipDetails;
        }
        public MarketingExecutiveDetails GetMarketingExecutiveDetails(bool withTransaction)
        {
            MarketingExecutiveDetails objMemberShipDetails = null;
            if (withTransaction)
                objMemberShipDetails = new MarketingExecutiveDetails(_transaction);
            else
                objMemberShipDetails = new MarketingExecutiveDetails(_connectionString);

            return objMemberShipDetails;
        }
        public TransactionsDetails GetTransactionsDetails(bool withTransaction)
        {
            TransactionsDetails objTransactionsDetails = null;
            if (withTransaction)
                objTransactionsDetails = new TransactionsDetails(_transaction);
            else
                objTransactionsDetails = new TransactionsDetails(_connectionString);

            return objTransactionsDetails;
        }
        public InstantQuizDetails GetInstantQuizDetails(bool withTransaction)
        {
            InstantQuizDetails objInstantQuizDetails = null;
            if (withTransaction)
                objInstantQuizDetails = new InstantQuizDetails(_transaction);
            else
                objInstantQuizDetails = new InstantQuizDetails(_connectionString);

            return objInstantQuizDetails;
        }
    }
}