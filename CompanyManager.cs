using DataAccessLayer;
using EntrebatorModelClass;
using System;
using System.Collections.Generic;


namespace EntrebatorBusinesslayer
{
    public class CompanyManager
    {
        #region Public Methods

        // Method to update the company slogan
        public static int UpdateSloganByMemberID(CompanyModel.CompanySloganAbout ObjSlogan)
        {
            int intResult = 0;
            using (DALHelper dalHelper = new DALHelper())
            {
                try
                {
                    dalHelper.OpenConnectionWithTransaction();
                    intResult = dalHelper.GetDAL_CompanyDetails(true).UpdateSloganByMemberID(ObjSlogan);
                    dalHelper.EndConnectionAndCommitTransaction();
                }
                catch (Exception)
                {
                    dalHelper.EndConnectionAndRollBackTransaction();
                    throw;
                }
            }
            return intResult;
        }

        // Method to update the company about me
        public static int UpdateAboutMeByMemberID(CompanyModel.CompanySloganAbout ObjAbtMe)
        {
            int intResult = 0;
            using (DALHelper dalHelper = new DALHelper())
            {
                try
                {
                    dalHelper.OpenConnectionWithTransaction();
                    intResult = dalHelper.GetDAL_CompanyDetails(true).UpdateAboutMeByMemberID(ObjAbtMe);
                    dalHelper.EndConnectionAndCommitTransaction();
                }
                catch (Exception)
                {
                    dalHelper.EndConnectionAndRollBackTransaction();
                    throw;
                }
            }
            return intResult;
        }

        //this method for get about me
        public static CompanyModel.CompanySloganAbout LoadAboutMe(Guid UserID)
        {
            using (DALHelper dalHelper = new DALHelper())
            {
                return dalHelper.GetDAL_CompanyDetails(false).LoadAboutMe(UserID);
            }
        }

        // Method to update the company about me
        public static int UpdateAbtSerProByMemberID(CompanyModel.CompanySloganAbout ObjAbtSerPro)
        {
            int intResult = 0;
            using (DALHelper dalHelper = new DALHelper())
            {
                try
                {
                    dalHelper.OpenConnectionWithTransaction();
                    intResult = dalHelper.GetDAL_CompanyDetails(true).UpdateAbtSerProByMemberID(ObjAbtSerPro);
                    dalHelper.EndConnectionAndCommitTransaction();
                }
                catch (Exception)
                {
                    dalHelper.EndConnectionAndRollBackTransaction();
                    throw;
                }
            }
            return intResult;
        }

        // Method to update the company about team
        public static int UpdateAbtTeamByMemberID(CompanyModel.CompanySloganAbout ObjAbtTeam)
        {
            int intResult = 0;
            using (DALHelper dalHelper = new DALHelper())
            {
                try
                {
                    dalHelper.OpenConnectionWithTransaction();
                    intResult = dalHelper.GetDAL_CompanyDetails(true).UpdateAbtTeamByMemberID(ObjAbtTeam);
                    dalHelper.EndConnectionAndCommitTransaction();
                }
                catch (Exception)
                {
                    dalHelper.EndConnectionAndRollBackTransaction();
                    throw;
                }
            }
            return intResult;
        }

        // Method to update the company about jobs
        public static int UpdateAbtJobsByMemberID(CompanyModel.CompanySloganAbout ObjAbtJob)
        {
            int intResult = 0;
            using (DALHelper dalHelper = new DALHelper())
            {
                try
                {
                    dalHelper.OpenConnectionWithTransaction();
                    intResult = dalHelper.GetDAL_CompanyDetails(true).UpdateAbtJobsByMemberID(ObjAbtJob);
                    dalHelper.EndConnectionAndCommitTransaction();
                }
                catch (Exception)
                {
                    dalHelper.EndConnectionAndRollBackTransaction();
                    throw;
                }
            }
            return intResult;
        }

        // Method to update the company about clients
        public static int UpdateAbtClientsByMemberID(CompanyModel.CompanySloganAbout ObjAbtClient)
        {
            int intResult = 0;
            using (DALHelper dalHelper = new DALHelper())
            {
                try
                {
                    dalHelper.OpenConnectionWithTransaction();
                    intResult = dalHelper.GetDAL_CompanyDetails(true).UpdateAbtClientsByMemberID(ObjAbtClient);
                    dalHelper.EndConnectionAndCommitTransaction();
                }
                catch (Exception)
                {
                    dalHelper.EndConnectionAndRollBackTransaction();
                    throw;
                }
            }
            return intResult;
        }

        // Method to add the service/product
        public static int AddServiceAndProducts(CompanyModel.ServiceProduct objServiceProc)
        {
            int intResult = 0;
            using (DALHelper dalHelper = new DALHelper())
            {
                dalHelper.OpenConnectionWithTransaction();
                intResult = dalHelper.GetDAL_CompanyDetails(true).AddServiceAndProducts(objServiceProc);
                dalHelper.EndConnectionAndCommitTransaction();
            }
            return intResult;
        }

        //this method for get services and products
        public static List<CompanyModel.ServiceProduct> LoadSerPro(Guid UserID)
        {
            using (DALHelper dalHelper = new DALHelper())
            {
                return dalHelper.GetDAL_CompanyDetails(false).LoadSerPro(UserID);
            }
        }

        // Method to update the services and clients
        public static int UpdateSerProBySerProID(CompanyModel.ServiceProduct ObjUpSerPro)
        {
            int intResult = 0;
            using (DALHelper dalHelper = new DALHelper())
            {
                try
                {
                    dalHelper.OpenConnectionWithTransaction();
                    intResult = dalHelper.GetDAL_CompanyDetails(true).UpdateSerProBySerProID(ObjUpSerPro);
                    dalHelper.EndConnectionAndCommitTransaction();
                }
                catch (Exception)
                {
                    dalHelper.EndConnectionAndRollBackTransaction();
                    throw;
                }
            }
            return intResult;
        }

        // Method to add the team
        public static int AddTeam(CompanyModel.Team ObjTeam)
        {
            int intResult = 0;
            using (DALHelper dalHelper = new DALHelper())
            {
                dalHelper.OpenConnectionWithTransaction();
                intResult = dalHelper.GetDAL_CompanyDetails(true).AddTeam(ObjTeam);
                dalHelper.EndConnectionAndCommitTransaction();
            }
            return intResult;
        }

        //this method for get teams
        public static List<CompanyModel.Team> LoadTeam(Guid UserID)
        {
            using (DALHelper dalHelper = new DALHelper())
            {
                return dalHelper.GetDAL_CompanyDetails(false).LoadTeam(UserID);
            }
        }

        // Method to update the teams
        public static int UpdateTeambyTeamID(CompanyModel.Team ObjUpTeam)
        {
            int intResult = 0;
            using (DALHelper dalHelper = new DALHelper())
            {
                try
                {
                    dalHelper.OpenConnectionWithTransaction();
                    intResult = dalHelper.GetDAL_CompanyDetails(true).UpdateTeambyTeamID(ObjUpTeam);
                    dalHelper.EndConnectionAndCommitTransaction();
                }
                catch (Exception)
                {
                    dalHelper.EndConnectionAndRollBackTransaction();
                    throw;
                }
            }
            return intResult;
        }

        // Method to add the clients
        public static int AddClient(CompanyModel.Client ObjClient)
        {
            int intResult = 0;
            using (DALHelper dalHelper = new DALHelper())
            {
                dalHelper.OpenConnectionWithTransaction();
                intResult = dalHelper.GetDAL_CompanyDetails(true).AddClient(ObjClient);
                dalHelper.EndConnectionAndCommitTransaction();
            }
            return intResult;
        }

        //this method for get clients
        public static List<CompanyModel.Client> LoadClient(Guid UserID)
        {
            using (DALHelper dalHelper = new DALHelper())
            {
                return dalHelper.GetDAL_CompanyDetails(false).LoadClient(UserID);
            }
        }

        // Method to update the clienst
        public static int UpdateClientbyClientID(CompanyModel.Client ObjUpClient)
        {
            int intResult = 0;
            using (DALHelper dalHelper = new DALHelper())
            {
                try
                {
                    dalHelper.OpenConnectionWithTransaction();
                    intResult = dalHelper.GetDAL_CompanyDetails(true).UpdateClientbyClientID(ObjUpClient);
                    dalHelper.EndConnectionAndCommitTransaction();
                }
                catch (Exception)
                {
                    dalHelper.EndConnectionAndRollBackTransaction();
                    throw;
                }
            }
            return intResult;
        }

        // Method to update the Service Product
        public static int UpsertSerProBySerProID(CompanyModel.ServiceProductsUpdate ObjUpSerPro)
        {
            int intResult = 0;
            using (DALHelper dalHelper = new DALHelper())
            {
                try
                {
                    dalHelper.OpenConnectionWithTransaction();
                    intResult = dalHelper.GetDAL_CompanyDetails(true).UpsertSerProBySerProID(ObjUpSerPro);
                    dalHelper.EndConnectionAndCommitTransaction();
                }
                catch (Exception)
                {
                    dalHelper.EndConnectionAndRollBackTransaction();
                    throw;
                }
            }
            return intResult;
        }

        // Method to add jobs
        public static int AddJobs(CompanyModel.CompanyJobs ObjJobs)
        {
            int intResult = 0;
            using (DALHelper dalHelper = new DALHelper())
            {
                dalHelper.OpenConnectionWithTransaction();
                intResult = dalHelper.GetDAL_CompanyDetails(true).AddJobs(ObjJobs);
                dalHelper.EndConnectionAndCommitTransaction();
            }
            return intResult;
        }

        //this method for load all jobs
        public static List<CompanyModel.CompanyJobs> LoadJobs(Guid UserID)
        {
            using (DALHelper dalHelper = new DALHelper())
            {
                return dalHelper.GetDAL_CompanyDetails(false).LoadJobs(UserID);
            }
        }

        // delete jobs
        public static int DeleteJob(Guid JobID)
        {
            int intResult = 0;
            using (DALHelper dalHelper = new DALHelper())
            {
                try
                {
                    dalHelper.OpenConnectionWithTransaction();
                    intResult = dalHelper.GetDAL_CompanyDetails(true).DeleteJob(JobID);
                    dalHelper.EndConnectionAndCommitTransaction();
                }
                catch (Exception ex)
                {
                    dalHelper.EndConnectionAndRollBackTransaction();
                    throw;
                }
            }
            return intResult;
        }

        // Method to add the service/product
        public static int AddServiceProduct(CompanyModel.ServiceProductNew objServiceProc)
        {
            int intResult = 0;
            using (DALHelper dalHelper = new DALHelper())
            {
                dalHelper.OpenConnectionWithTransaction();
                intResult = dalHelper.GetDAL_CompanyDetails(true).AddServiceProduct(objServiceProc);
                dalHelper.EndConnectionAndCommitTransaction();
            }
            return intResult;
        }

        public static List<CompanyModel.ServiceProductNew> GetAllServiceProducts()
        {
            using (DALHelper dalHelper = new DALHelper())
            {
                return dalHelper.GetDAL_CompanyDetails(false).GetAllServiceProducts();
            }
        }
        //to get the product and services
        public static List<CompanyModel.ServiceProductNew> SP_FetchServiceProductsByIndustryIDAndMemberID(Guid MemberID, Int16 IndustryID, int PageCount)
        {
            using (DALHelper dalHelper = new DALHelper())
            {
                return dalHelper.GetDAL_CompanyDetails(false).SP_FetchServiceProductsByIndustryIDAndMemberID(MemberID, IndustryID, PageCount);
            }
        }
        public static List<CompanyModel.ServiceProductNew> GetAllSerPro(Guid UserID)
        {
            using (DALHelper dalHelper = new DALHelper())
            {
                return dalHelper.GetDAL_CompanyDetails(false).GetAllSerPro(UserID);
            }
        }

        public static CompanyModel.ServiceProductsUpdate GetPostedSerPro(Guid SerProID)
        {
            using (DALHelper dalHelper = new DALHelper())
            {
                return dalHelper.GetDAL_CompanyDetails(false).GetPostedSerPro(SerProID);
            }
        }
        public static List<CompanyModel.ServiceProductNew> Sp_SearchServicesAndPro()
        {
            using (DALHelper dalHelper = new DALHelper())
            {
                return dalHelper.GetDAL_CompanyDetails(false).Sp_SearchServicesAndPro();
            }
        }
        #endregion Public Methods

        public static int UpsertSerProBySerProIDForApp(CompanyModel.ServiceProductsUpdate ObjUpSerPro)
        {
            int intResult = 0;
            using (DALHelper dalHelper = new DALHelper())
            {
                try
                {
                    dalHelper.OpenConnectionWithTransaction();
                    intResult = dalHelper.GetDAL_CompanyDetails(true).UpsertSerProBySerProIDForApp(ObjUpSerPro);
                    dalHelper.EndConnectionAndCommitTransaction();
                }
                catch (Exception)
                {
                    dalHelper.EndConnectionAndRollBackTransaction();
                    throw;
                }
            }
            return intResult;
        }
        public static List<CompanyModel.ServiceProductNew> SP_ServiceProducts_GetBySearch(string Searchvalue)
        {
            using (DALHelper dalHelper = new DALHelper())
            {
                return dalHelper.GetDAL_CompanyDetails(false).SP_ServiceProducts_GetBySearch(Searchvalue);
            }
        }

        public static int AddServiceProductMadan(CompanyModel.ServiceProductNewMadan objServ)
        {
            int intResult = 0;
            using (DALHelper dalHelper = new DALHelper())
            {
                dalHelper.OpenConnectionWithTransaction();
                intResult = dalHelper.GetDAL_CompanyDetails(true).AddServiceProductMadan(objServ);
                dalHelper.EndConnectionAndCommitTransaction();
            }
            return intResult;
        }
        public static CompanyModel.ServiceProductNew SP_FetchServiceProductsByServiceProductID(Guid ServiceProductID)
        {
            using (DALHelper dalHelper = new DALHelper())
            {
                return dalHelper.GetDAL_CompanyDetails(false).SP_FetchServiceProductsByServiceProductID(ServiceProductID);
            }

        }
        //to get the product and services
        public static List<CompanyModel.ServiceProductNewsForHome> SP_FetchServiceProductsForHome()
        {
            using (DALHelper dalHelper = new DALHelper())
            {
                return dalHelper.GetDAL_CompanyDetails(false).SP_FetchServiceProductsForHome();
            }
        }
    }
}