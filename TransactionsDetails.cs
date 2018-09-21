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
    public class TransactionsDetails : Entity
    {
        #region PrivateFields

        private ISQLHelper _helper;

        #endregion PrivateFields

        #region Constructors
        public TransactionsDetails(SqlTransaction Transaction)
        {
            base.Transaction = Transaction;
            _helper = new SQLHelper();
        }
        public TransactionsDetails(string strConnectionString)
        {
            base.ConnectionString = strConnectionString;
            _helper = new SQLHelper();
        }
        #endregion Constructors
        #region PublicMethods
        public Int64 InsertEBSTransactions(TransactionsModel.Transactions obj)
        {
            return PrivateInsertEBSTransactions(obj);
        }
        //get the All points history
        public List<TransactionsModel.FetchMemberPointsHistory> EB_FetchMemberPointsHistory(Guid UserID, int PageCount, byte Type)
        {
            return PrivateEB_FetchMemberPointsHistory(UserID, PageCount, Type);
        }
        //to get memberships for create invoice
        public List<TransactionsModel.MemberShips> EB_Fetch_ETRMemberShips()
        {
            return PrivateEB_Fetch_ETRMemberShips();
        }
        //to get Future Events For Create Invoice
        public List<TransactionsModel.GetFutureEvents> EB_Fetch_GetFutureEvents(DateTime Date)
        {
            return PrivateEB_Fetch_GetFutureEvents(Date);
        }
        //to create perfoma invoice wrote by eswar 2/6/2018
        public long InsertProformaInvoices(TransactionsModel.CreateInvoice objCampaign)
        {
            return privateInsertProformaInvoices(objCampaign);
        }
        //to inser the perpofa invoice terms wrote by eswar
        public int InsertProformaInvoiceItems(TransactionsModel.CreateInvoice objCampaign)
        {
            return privateInsertProformaInvoiceItems(objCampaign);
        }
        //to get Latest top 100 invoices from invoice and bith tables
        public List<TransactionsModel.FetchInvoices> EB_FetechAllInvoices(Guid MemberID)
        {
            return PrivateEB_FetechAllInvoices(MemberID);
        }
        //to update invoices wrote by eswar 2/6/2018
        public long UpdateInvoices(TransactionsModel.FetchInvoices objCampaign)
        {
            return privateUpdateInvoices(objCampaign);
        }
        //to get  invoice details by invoiceid
        public TransactionsModel.GetInvoiceByInvoiceID EB_FetechInvoiceByInvoiceID(long InvoiceID, byte InvoiceType)
        {
            return PrivateEB_FetechInvoiceByInvoiceID(InvoiceID, InvoiceType);
        }
        //Update EBS Transaction
        public int EB_UpdateEBSTransactions(TransactionsModel.Transactions objPaymentDetails)
        {
            return PrivateEB_UpdateEBSTransactions(objPaymentDetails);
        }
        //For Get EBS Transaction Details By OrderID
        public TransactionsModel.Transactions EB_GetEBSTransactionDetailsByOrderID(long OrderID)
        {
            return PrivateEB_GetEBSTransactionDetailsByOrderID(OrderID);
        }
        //to update the Online Transactions details
        public long UpdateTransations(TransactionsModel.UPDateTransaction objCampaign)
        {
            return privateUpdateTransations(objCampaign);
        }
        //to update  the recipt statuses
        public long UpdateReceiptTransations(TransactionsModel.UPDateReceiptTransaction objCampaign)
        {
            return privateUpdateReceiptTransations(objCampaign);
        }
        //to delete invoice by invoiceid
        public int DeleteInvoiceByInvoiceID(long InvoiceId, byte InvoiceType, byte Status)
        {
            return privateDeleteInvoiceByInvoiceID(InvoiceId, InvoiceType, Status);
        }
        //For Get EBS Transaction Details By OrderID
        public TransactionsModel.EbsTransactionForMemberdetails EB_FetchMemberDetailsForEbsTransaction(Guid MemberID)
        {
            return PrivateEB_FetchMemberDetailsForEbsTransaction(MemberID);
        }
        public int EB_SP_Notifications_ToInsert(TransactionsModel.Notifications_ToCreate obj)
        {
            return privateEB_SP_Notifications_ToInsert(obj);
        }
        //For Get  Notification details
        public List<TransactionsModel.Notifications_ToGet> EB_FetchNotificationDetails(Guid MemberID, int PageCount)
        {
            return PrivateEB_FetchNotificationsDetails(MemberID, PageCount);
        }
        //to  update Read Status
        public int EB_SP_Notifications_ToUpdateRead(TransactionsModel.Notifications_ToCreate obj)
        {
            return privateEB_SP_Notifications_ToUpdateRead(obj);
        }
        public int Sp_InfluencerInsertOrUpdate(TransactionsModel.Influencer obj)
        {
            return PrivateSp_InfluencerInsertOrUpdate(obj);
        }
        public List<TransactionsModel.Influencer> Sp_GetInfluencer(Guid UserID)
        {
            return PrivateSp_GetInfluencer(UserID);
        }

        public byte Sp_DeleteInfluencer(Guid InfluencerID)
        {
            return PriavateSp_DeleteInfluencer(InfluencerID);
        }
        public byte Sp_ChangeInfluencerType(Guid InfluencerID, byte Type)
        {
            return PriavateSp_ChangeInfluencerType(InfluencerID, Type);
        }
        public int UpdateTransationsDetails(Guid PaymentID, long InvoiceID)
        {
            return privateUpdateTransationsDetails(PaymentID, InvoiceID);
        }
        //to get paid invoices
        public List<TransactionsModel.FetchInvoices> EB_FetechpaidInvoices(Guid MemberID)
        {
            return PrivateEB_FetechpaidInvoices(MemberID);
        }

        //to create  invoice wrote by eswar 7/9/2018
        public long InsertReceiptInvoices(TransactionsModel.ReceiptInvoice objCampaign)
        {
            return privateInsertReceiptInvoices(objCampaign);
        }
       
        //to inser the receipt invoice terms wrote by eswar
        public int InsertReceiptInvoiceItems(TransactionsModel.ReceiptInvoice objCampaign)
        {
            return privateInsertReceiptInvoiceItems(objCampaign);
        }
            #endregion PublicMethods
            #region PrivateMethods
            //Insert EBS Transaction
            private Int64 PrivateInsertEBSTransactions(TransactionsModel.Transactions obj)
        {

            SqlParameter[] objSqlParameter = new SqlParameter[11];
            objSqlParameter[0] = new SqlParameter("@PaymentID", SqlDbType.UniqueIdentifier);
            objSqlParameter[0].Value = obj.PaymentID;
            objSqlParameter[1] = new SqlParameter("@Amount", SqlDbType.Decimal);
            objSqlParameter[1].Value = obj.Amount;
            objSqlParameter[2] = new SqlParameter("@EBSTransactionID", SqlDbType.NVarChar);
            objSqlParameter[2].Value = obj.EBSTransactionID;
            objSqlParameter[3] = new SqlParameter("@EBSPaymentID", SqlDbType.NVarChar);
            objSqlParameter[3].Value = obj.EBSPaymentID;
            objSqlParameter[4] = new SqlParameter("@PaidFor", SqlDbType.TinyInt);
            objSqlParameter[4].Value = obj.PaidFor;
            objSqlParameter[5] = new SqlParameter("@PaidBy", SqlDbType.UniqueIdentifier);
            objSqlParameter[5].Value = obj.PaidBy;
            objSqlParameter[6] = new SqlParameter("@PaidOn", SqlDbType.DateTime);
            objSqlParameter[6].Value = obj.PaidOn;
            objSqlParameter[7] = new SqlParameter("@PaymentType", SqlDbType.TinyInt);
            objSqlParameter[7].Value = obj.PaymentType;
            objSqlParameter[8] = new SqlParameter("@PaymentDescription", SqlDbType.NVarChar);
            objSqlParameter[8].Value = obj.PaymentDescription;
            objSqlParameter[9] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            objSqlParameter[9].Value = obj.InvoiceID;
            objSqlParameter[10] = new SqlParameter("@OrderID", SqlDbType.BigInt);
            objSqlParameter[10].Direction = ParameterDirection.Output;
            if (base.Transaction != null)
            {
                _helper.ExecuteNonQuery(base.Transaction,
                CommandType.StoredProcedure,
               "EB_InsertEBSTransactions",
               objSqlParameter);
            }
            else
            {
                _helper.ExecuteNonQuery(base.ConnectionString,
                 CommandType.StoredProcedure,
               "EB_InsertEBSTransactions",
               objSqlParameter);
            }
            return Convert.ToInt64(objSqlParameter[10].Value.ToString());
        }
        //get the All pints history
        private List<TransactionsModel.FetchMemberPointsHistory> PrivateEB_FetchMemberPointsHistory(Guid UserID, int PageCount, byte Type)
        {
            List<TransactionsModel.FetchMemberPointsHistory> objlist = new List<TransactionsModel.FetchMemberPointsHistory>();
            IDataReader datareader = null;
            SqlParameter[] objSqlparameter = new SqlParameter[3];
            objSqlparameter[0] = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
            objSqlparameter[0].Value = UserID;
            objSqlparameter[1] = new SqlParameter("@PageCount", SqlDbType.Int);
            objSqlparameter[1].Value = PageCount;
            objSqlparameter[2] = new SqlParameter("@Type", SqlDbType.TinyInt);
            objSqlparameter[2].Value = Type;
            try
            {
                if (base.Transaction != null)
                {
                    datareader = _helper.ExecuteReader(base.Transaction, "EB_FetchMemberPointHistory", objSqlparameter);
                }
                else
                {
                    datareader = _helper.ExecuteReader(base.ConnectionString, "EB_FetchMemberPointHistory", objSqlparameter);
                }
                while (datareader.Read())
                {
                    TransactionsModel.FetchMemberPointsHistory ob = new TransactionsModel.FetchMemberPointsHistory();
                    if (datareader["MemberID"] != DBNull.Value)
                        ob.MemberID = datareader.GetGuid(datareader.GetOrdinal("MemberID"));
                    if (datareader["TotalPoints"] != DBNull.Value)
                        ob.TotalPoints = datareader.GetDecimal(datareader.GetOrdinal("TotalPoints"));
                    if (datareader["NegativePoints"] != DBNull.Value)
                        ob.NegativePoints = datareader.GetDecimal(datareader.GetOrdinal("NegativePoints"));
                    if (datareader["Date"] != DBNull.Value)
                        ob.Date = datareader.GetDateTime(datareader.GetOrdinal("Date"));
                    if (datareader["Type"] != DBNull.Value)
                        ob.Type = datareader.GetByte(datareader.GetOrdinal("Type"));
                    if (datareader["Description"] != DBNull.Value)
                        ob.Description = datareader.GetString(datareader.GetOrdinal("Description"));
                    if (datareader["Points"] != DBNull.Value)
                        ob.Points = datareader.GetDecimal(datareader.GetOrdinal("Points"));
                    if (datareader["UID"] != DBNull.Value)
                        ob.UID = datareader.GetGuid(datareader.GetOrdinal("UID"));
                    if (datareader["BounusPoints"] != DBNull.Value)
                        ob.BounusPoints = datareader.GetDecimal(datareader.GetOrdinal("BounusPoints"));
                    objlist.Add(ob);
                }
            }
            finally
            {
                if (datareader != null)
                    datareader.Close();
            }
            return objlist;
        }
        //to get memberships for create invoice
        private List<TransactionsModel.MemberShips> PrivateEB_Fetch_ETRMemberShips()
        {
            List<TransactionsModel.MemberShips> objListmobile = new List<TransactionsModel.MemberShips>();
            IDataReader dr = null;
            try
            {
                if (base.Transaction != null)
                    dr = _helper.ExecuteReader(base.Transaction, "EB_Fetch_ETRMemberShips");
                else
                    dr = _helper.ExecuteReader(base.ConnectionString, "EB_Fetch_ETRMemberShips");
                while (dr.Read())
                {

                    TransactionsModel.MemberShips objgetchatmsg = new TransactionsModel.MemberShips();

                    if (dr["MembershipID"] != DBNull.Value)
                        objgetchatmsg.MembershipID = dr.GetGuid(dr.GetOrdinal("MembershipID"));
                    if (dr["MembershipName"] != DBNull.Value)
                        objgetchatmsg.MembershipName = dr.GetString(dr.GetOrdinal("MembershipName"));
                    if (dr["Amount"] != DBNull.Value)
                        objgetchatmsg.Amount = dr.GetDecimal(dr.GetOrdinal("Amount"));

                    objListmobile.Add(objgetchatmsg);
                }
            }
            finally
            {
                if (dr != null)
                    dr.Close();
            }
            return objListmobile;
        }
        //to get Future Events For Create Invoice
        private List<TransactionsModel.GetFutureEvents> PrivateEB_Fetch_GetFutureEvents(DateTime Date)
        {
            List<TransactionsModel.GetFutureEvents> objListmobile = new List<TransactionsModel.GetFutureEvents>();
            IDataReader dr = null;
            try
            {
                if (base.Transaction != null)
                    dr = _helper.ExecuteReader(base.Transaction, "EB_Fetch_GetFutureEventsByDate", Date);
                else
                    dr = _helper.ExecuteReader(base.ConnectionString, "EB_Fetch_GetFutureEventsByDate", Date);
                while (dr.Read())
                {

                    TransactionsModel.GetFutureEvents obj = new TransactionsModel.GetFutureEvents();
                    if (dr["EventID"] != DBNull.Value)
                        obj.EventID = dr.GetGuid(dr.GetOrdinal("EventID"));
                    if (dr["EventName"] != DBNull.Value)
                        obj.EventName = dr.GetString(dr.GetOrdinal("EventName"));
                    if (dr["Amount"] != DBNull.Value)
                        obj.Amount = dr.GetDecimal(dr.GetOrdinal("Amount"));

                    objListmobile.Add(obj);
                }
            }
            finally
            {
                if (dr != null)
                    dr.Close();
            }
            return objListmobile;
        }
        //to create perfoma invoice wrote by eswar 2/6/2018
        private long privateInsertProformaInvoices(TransactionsModel.CreateInvoice objCampaign)
        {
            SqlParameter[] objSqlParameter = new SqlParameter[21];
            objSqlParameter[0] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            objSqlParameter[0].Direction = ParameterDirection.Output;
            objSqlParameter[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            objSqlParameter[1].Value = objCampaign.Name;
            objSqlParameter[2] = new SqlParameter("@Email", SqlDbType.NVarChar);
            objSqlParameter[2].Value = objCampaign.Email;
            objSqlParameter[3] = new SqlParameter("@Mobile", SqlDbType.NVarChar);
            objSqlParameter[3].Value = objCampaign.Mobile;
            objSqlParameter[4] = new SqlParameter("@Address", SqlDbType.NVarChar);
            objSqlParameter[4].Value = objCampaign.Address;
            objSqlParameter[5] = new SqlParameter("@InvoiceDate", SqlDbType.DateTime);
            objSqlParameter[5].Value = objCampaign.InvoiceDate;
            objSqlParameter[6] = new SqlParameter("@ActualPrice", SqlDbType.Decimal);
            objSqlParameter[6].Value = objCampaign.ActualPrice;
            objSqlParameter[7] = new SqlParameter("@Discount", SqlDbType.Decimal);
            objSqlParameter[7].Value = objCampaign.Discount;
            objSqlParameter[8] = new SqlParameter("@DiscAmount", SqlDbType.Decimal);
            objSqlParameter[8].Value = objCampaign.DiscAmount;
            objSqlParameter[9] = new SqlParameter("@BeforeTaxAmount", SqlDbType.Decimal);
            objSqlParameter[9].Value = objCampaign.BeforeTaxAmount;
            objSqlParameter[10] = new SqlParameter("@TaxAmount", SqlDbType.Decimal);
            objSqlParameter[10].Value = objCampaign.TaxAmount;
            objSqlParameter[11] = new SqlParameter("@FinalAmount", SqlDbType.Decimal);
            objSqlParameter[11].Value = objCampaign.FinalAmount;
            objSqlParameter[12] = new SqlParameter("@Currency", SqlDbType.NVarChar);
            objSqlParameter[12].Value = objCampaign.Currency;
            objSqlParameter[13] = new SqlParameter("@Terms", SqlDbType.NVarChar);
            objSqlParameter[13].Value = objCampaign.Terms;
            objSqlParameter[14] = new SqlParameter("@Status", SqlDbType.TinyInt);
            objSqlParameter[14].Value = objCampaign.Status;
            objSqlParameter[15] = new SqlParameter("@CreatedBy", SqlDbType.UniqueIdentifier);
            objSqlParameter[15].Value = objCampaign.CreatedBy;
            objSqlParameter[16] = new SqlParameter("@MemberID", SqlDbType.UniqueIdentifier);
            objSqlParameter[16].Value = objCampaign.MemberID;
            objSqlParameter[17] = new SqlParameter("@InvoiceType", SqlDbType.TinyInt);
            objSqlParameter[17].Value = objCampaign.InvoiceType;
            objSqlParameter[18] = new SqlParameter("@ClientGST", SqlDbType.NVarChar);
            objSqlParameter[18].Value = objCampaign.ClientGST;
            objSqlParameter[19] = new SqlParameter("@InvoiceFor", SqlDbType.TinyInt);
            objSqlParameter[19].Value = objCampaign.InvoiceFor;
            objSqlParameter[20] = new SqlParameter("@UIDFor", SqlDbType.UniqueIdentifier);
            objSqlParameter[20].Value = objCampaign.UIDFor;
            if (base.Transaction != null)
            {
                _helper.ExecuteNonQuery(base.Transaction, CommandType.StoredProcedure, "EB_InsertProformaInvoices", objSqlParameter);
            }
            else
            {
                _helper.ExecuteNonQuery(base.ConnectionString, CommandType.StoredProcedure, "EBv_InsertProformaInvoices", objSqlParameter);
            }
            return Convert.ToInt64(objSqlParameter[0].Value);
        }
        //to create receipt invoice wrote by eswar 7/9/2018
        private long privateInsertReceiptInvoices(TransactionsModel.ReceiptInvoice objCampaign)
        {
            SqlParameter[] objSqlParameter = new SqlParameter[27];
            objSqlParameter[0] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            objSqlParameter[0].Direction = ParameterDirection.Output;
            objSqlParameter[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            objSqlParameter[1].Value = objCampaign.Name;
            objSqlParameter[2] = new SqlParameter("@Email", SqlDbType.NVarChar);
            objSqlParameter[2].Value = objCampaign.Email;
            objSqlParameter[3] = new SqlParameter("@Mobile", SqlDbType.NVarChar);
            objSqlParameter[3].Value = objCampaign.Mobile;
            objSqlParameter[4] = new SqlParameter("@Address", SqlDbType.NVarChar);
            objSqlParameter[4].Value = objCampaign.Address;
            objSqlParameter[5] = new SqlParameter("@InvoiceDate", SqlDbType.DateTime);
            objSqlParameter[5].Value = objCampaign.InvoiceDate;
            objSqlParameter[6] = new SqlParameter("@ActualPrice", SqlDbType.Decimal);
            objSqlParameter[6].Value = objCampaign.ActualPrice;
            objSqlParameter[7] = new SqlParameter("@Discount", SqlDbType.Decimal);
            objSqlParameter[7].Value = objCampaign.Discount;
            objSqlParameter[8] = new SqlParameter("@DiscAmount", SqlDbType.Decimal);
            objSqlParameter[8].Value = objCampaign.DiscAmount;
            objSqlParameter[9] = new SqlParameter("@BeforeTaxAmount", SqlDbType.Decimal);
            objSqlParameter[9].Value = objCampaign.BeforeTaxAmount;
            objSqlParameter[10] = new SqlParameter("@TaxAmount", SqlDbType.Decimal);
            objSqlParameter[10].Value = objCampaign.TaxAmount;
            objSqlParameter[11] = new SqlParameter("@FinalAmount", SqlDbType.Decimal);
            objSqlParameter[11].Value = objCampaign.FinalAmount;
            objSqlParameter[12] = new SqlParameter("@Currency", SqlDbType.NVarChar);
            objSqlParameter[12].Value = objCampaign.Currency;
            objSqlParameter[13] = new SqlParameter("@Terms", SqlDbType.NVarChar);
            objSqlParameter[13].Value = objCampaign.Terms;
            objSqlParameter[14] = new SqlParameter("@Status", SqlDbType.TinyInt);
            objSqlParameter[14].Value = objCampaign.Status;
            objSqlParameter[15] = new SqlParameter("@CreatedBy", SqlDbType.UniqueIdentifier);
            objSqlParameter[15].Value = objCampaign.CreatedBy;
            objSqlParameter[16] = new SqlParameter("@MemberID", SqlDbType.UniqueIdentifier);
            objSqlParameter[16].Value = objCampaign.MemberID;
            objSqlParameter[17] = new SqlParameter("@InvoiceType", SqlDbType.TinyInt);
            objSqlParameter[17].Value = objCampaign.InvoiceType;
            objSqlParameter[18] = new SqlParameter("@ClientGST", SqlDbType.NVarChar);
            objSqlParameter[18].Value = objCampaign.ClientGST;
            objSqlParameter[19] = new SqlParameter("@InvoiceFor", SqlDbType.TinyInt);
            objSqlParameter[19].Value = objCampaign.InvoiceFor;
            objSqlParameter[20] = new SqlParameter("@UIDFor", SqlDbType.UniqueIdentifier);
            objSqlParameter[20].Value = objCampaign.UIDFor;
            objSqlParameter[21] = new SqlParameter("@ChequeNo", SqlDbType.NVarChar);
            objSqlParameter[21].Value = objCampaign.ChequeNo;
            objSqlParameter[22] = new SqlParameter("@ChequeAmount", SqlDbType.NVarChar);
            objSqlParameter[22].Value = objCampaign.ChequeAmount;
            objSqlParameter[23] = new SqlParameter("@ChequeDate", SqlDbType.DateTime);
            objSqlParameter[23].Value = objCampaign.ChequeDate;
            objSqlParameter[24] = new SqlParameter("@BankDetails", SqlDbType.NVarChar);
            objSqlParameter[24].Value = objCampaign.BankDetails;
            objSqlParameter[25] = new SqlParameter("@CollectedBy", SqlDbType.NVarChar);
            objSqlParameter[25].Value = objCampaign.CollectedBy;
            objSqlParameter[26] = new SqlParameter("@PaymentMode", SqlDbType.TinyInt);
            objSqlParameter[26].Value = objCampaign.PaymentMode;
            if (base.Transaction != null)
            {
                _helper.ExecuteNonQuery(base.Transaction, CommandType.StoredProcedure, "EB_InsertReceiptInvoice", objSqlParameter);
            }
            else
            {
                _helper.ExecuteNonQuery(base.ConnectionString, CommandType.StoredProcedure, "EB_InsertReceiptInvoice", objSqlParameter);
            }
            return Convert.ToInt64(objSqlParameter[0].Value);
        }
        //to inser the perpofa invoice terms wrote by eswar
        private int privateInsertProformaInvoiceItems(TransactionsModel.CreateInvoice objCampaign)
        {
            SqlParameter[] objSqlParameter = new SqlParameter[11];
            objSqlParameter[0] = new SqlParameter("@ItemID", SqlDbType.UniqueIdentifier);
            objSqlParameter[0].Value = objCampaign.ItemID;
            objSqlParameter[1] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            objSqlParameter[1].Value = objCampaign.InvoiceID;
            objSqlParameter[2] = new SqlParameter("@Invoice", SqlDbType.NVarChar);
            objSqlParameter[2].Value = objCampaign.Invoice;
            objSqlParameter[3] = new SqlParameter("@Description", SqlDbType.NVarChar);
            objSqlParameter[3].Value = objCampaign.Description;
            objSqlParameter[4] = new SqlParameter("@ActualPrice", SqlDbType.Decimal);
            objSqlParameter[4].Value = objCampaign.ActualPrice;
            objSqlParameter[5] = new SqlParameter("@Quantity", SqlDbType.TinyInt);
            objSqlParameter[5].Value = objCampaign.Quantity;
            objSqlParameter[6] = new SqlParameter("@TotalPrice", SqlDbType.Decimal);
            objSqlParameter[6].Value = objCampaign.FinalAmount;
            objSqlParameter[7] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
            objSqlParameter[7].Value = objCampaign.CreatedOn;
            objSqlParameter[8] = new SqlParameter("@CGST", SqlDbType.Decimal);
            objSqlParameter[8].Value = objCampaign.CGST;
            objSqlParameter[9] = new SqlParameter("@SGST", SqlDbType.Decimal);
            objSqlParameter[9].Value = objCampaign.SGST;
            objSqlParameter[10] = new SqlParameter("@IGST", SqlDbType.Decimal);
            objSqlParameter[10].Value = objCampaign.IGST;
            if (base.Transaction != null)
            {
                return _helper.ExecuteNonQuery(base.Transaction, CommandType.StoredProcedure, "EB_InsertProformaInvoiceItems", objSqlParameter);
            }
            else
            {
                return _helper.ExecuteNonQuery(base.ConnectionString, CommandType.StoredProcedure, "EB_InsertProformaInvoiceItems", objSqlParameter);
            }
        }
        //to inser the receipt invoice terms wrote by eswar
        private int privateInsertReceiptInvoiceItems(TransactionsModel.ReceiptInvoice objCampaign)
        {
            SqlParameter[] objSqlParameter = new SqlParameter[11];
            objSqlParameter[0] = new SqlParameter("@ItemID", SqlDbType.UniqueIdentifier);
            objSqlParameter[0].Value = objCampaign.ItemID;
            objSqlParameter[1] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            objSqlParameter[1].Value = objCampaign.InvoiceID;
            objSqlParameter[2] = new SqlParameter("@Invoice", SqlDbType.NVarChar);
            objSqlParameter[2].Value = objCampaign.Invoice;
            objSqlParameter[3] = new SqlParameter("@Description", SqlDbType.NVarChar);
            objSqlParameter[3].Value = objCampaign.Description;
            objSqlParameter[4] = new SqlParameter("@ActualPrice", SqlDbType.Decimal);
            objSqlParameter[4].Value = objCampaign.ActualPrice;
            objSqlParameter[5] = new SqlParameter("@Quantity", SqlDbType.TinyInt);
            objSqlParameter[5].Value = objCampaign.Quantity;
            objSqlParameter[6] = new SqlParameter("@TotalPrice", SqlDbType.Decimal);
            objSqlParameter[6].Value = objCampaign.FinalAmount;
            objSqlParameter[7] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
            objSqlParameter[7].Value = objCampaign.CreatedOn;
            objSqlParameter[8] = new SqlParameter("@CGST", SqlDbType.Decimal);
            objSqlParameter[8].Value = objCampaign.CGST;
            objSqlParameter[9] = new SqlParameter("@SGST", SqlDbType.Decimal);
            objSqlParameter[9].Value = objCampaign.SGST;
            objSqlParameter[10] = new SqlParameter("@IGST", SqlDbType.Decimal);
            objSqlParameter[10].Value = objCampaign.IGST;
            if (base.Transaction != null)
            {
                return _helper.ExecuteNonQuery(base.Transaction, CommandType.StoredProcedure, "EB_InsertReceiptInvoiceItems", objSqlParameter);
            }
            else
            {
                return _helper.ExecuteNonQuery(base.ConnectionString, CommandType.StoredProcedure, "EB_InsertReceiptInvoiceItems", objSqlParameter);
            }
        }
        //to get Latest top 100 invoices from invoice and bith tables
        private List<TransactionsModel.FetchInvoices> PrivateEB_FetechAllInvoices(Guid MemberID)
        {
            IDataReader dataReader = null;
            List<TransactionsModel.FetchInvoices> objListCampaign = new List<TransactionsModel.FetchInvoices>();
            try
            {
                if (base.Transaction != null)
                {
                    dataReader = _helper.ExecuteReader(base.Transaction,
                        "EB_FetechAllInvoices", MemberID);
                }
                else
                {

                    dataReader = _helper.ExecuteReader(base.ConnectionString,
                        "EB_FetechAllInvoices", MemberID);
                }

                while (dataReader.Read())
                {
                    TransactionsModel.FetchInvoices objCampaign = new TransactionsModel.FetchInvoices();
                    if (dataReader["InvoiceID"] != DBNull.Value)
                        objCampaign.InvoiceID = dataReader.GetInt64(dataReader.GetOrdinal("InvoiceID"));
                    if (dataReader["Name"] != DBNull.Value)
                        objCampaign.Name = dataReader.GetString(dataReader.GetOrdinal("Name"));
                    if (dataReader["Mobile"] != DBNull.Value)
                        objCampaign.Mobile = dataReader.GetString(dataReader.GetOrdinal("Mobile"));
                    if (dataReader["Email"] != DBNull.Value)
                        objCampaign.Email = dataReader.GetString(dataReader.GetOrdinal("Email"));
                    if (dataReader["Address"] != DBNull.Value)
                        objCampaign.Address = dataReader.GetString(dataReader.GetOrdinal("Address"));
                    if (dataReader["InvoiceDate"] != DBNull.Value)
                        objCampaign.InvoiceDate = dataReader.GetDateTime(dataReader.GetOrdinal("InvoiceDate"));
                    if (dataReader["ActualAmount"] != DBNull.Value)
                        objCampaign.ActualAmount = dataReader.GetDecimal(dataReader.GetOrdinal("ActualAmount"));
                    if (dataReader["Discount"] != DBNull.Value)
                        objCampaign.Discount = dataReader.GetDecimal(dataReader.GetOrdinal("Discount"));
                    if (dataReader["DiscAmount"] != DBNull.Value)
                        objCampaign.DiscAmount = dataReader.GetDecimal(dataReader.GetOrdinal("DiscAmount"));
                    if (dataReader["BeforeTaxAmount"] != DBNull.Value)
                        objCampaign.BeforeTaxAmount = dataReader.GetDecimal(dataReader.GetOrdinal("BeforeTaxAmount"));
                    if (dataReader["TaxAmount"] != DBNull.Value)
                        objCampaign.TaxAmount = dataReader.GetDecimal(dataReader.GetOrdinal("TaxAmount"));
                    if (dataReader["FinalAmount"] != DBNull.Value)
                        objCampaign.FinalAmount = dataReader.GetDecimal(dataReader.GetOrdinal("FinalAmount"));
                    if (dataReader["Currency"] != DBNull.Value)
                        objCampaign.Currency = dataReader.GetString(dataReader.GetOrdinal("Currency"));
                    if (dataReader["Terms"] != DBNull.Value)
                        objCampaign.Terms = dataReader.GetString(dataReader.GetOrdinal("Terms"));
                    if (dataReader["Status"] != DBNull.Value)
                        objCampaign.Status = dataReader.GetByte(dataReader.GetOrdinal("Status"));
                    if (dataReader["CreatedBy"] != DBNull.Value)
                        objCampaign.CreatedBy = dataReader.GetGuid(dataReader.GetOrdinal("CreatedBy"));
                    if (dataReader["PaymentType"] != DBNull.Value)
                        objCampaign.PaymentType = dataReader.GetByte(dataReader.GetOrdinal("PaymentType"));
                    if (dataReader["PaymentMode"] != DBNull.Value)
                        objCampaign.PaymentMode = dataReader.GetByte(dataReader.GetOrdinal("PaymentMode"));
                    if (dataReader["ClientGST"] != DBNull.Value)
                        objCampaign.ClientGST = dataReader.GetString(dataReader.GetOrdinal("ClientGST"));
                    if (dataReader["InvoiceType"] != DBNull.Value)
                        objCampaign.InvoiceType = dataReader.GetByte(dataReader.GetOrdinal("InvoiceType"));
                    if (dataReader["Description"] != DBNull.Value)
                        objCampaign.Description = dataReader.GetString(dataReader.GetOrdinal("Description"));
                    if (dataReader["CGST"] != DBNull.Value)
                        objCampaign.CGST = dataReader.GetDecimal(dataReader.GetOrdinal("CGST"));
                    if (dataReader["SGST"] != DBNull.Value)
                        objCampaign.SGST = dataReader.GetDecimal(dataReader.GetOrdinal("SGST"));
                    if (dataReader["Quantity"] != DBNull.Value)
                        objCampaign.Quantity = dataReader.GetByte(dataReader.GetOrdinal("Quantity"));
                    if (dataReader["InvoiceFor"] != DBNull.Value)
                        objCampaign.InvoiceFor = dataReader.GetByte(dataReader.GetOrdinal("InvoiceFor"));
                    objListCampaign.Add(objCampaign);
                }
            }
            finally
            {
                if (dataReader != null)
                    dataReader.Close();
            }
            return objListCampaign;
        }
        //to get Latest top 100 invoices from invoice and bith tables
        private List<TransactionsModel.FetchInvoices> PrivateEB_FetechpaidInvoices(Guid MemberID)
        {
            IDataReader dataReader = null;
            List<TransactionsModel.FetchInvoices> objListCampaign = new List<TransactionsModel.FetchInvoices>();
            try
            {
                if (base.Transaction != null)
                {
                    dataReader = _helper.ExecuteReader(base.Transaction,
                        "EB_FetechpaidInvoices", MemberID);
                }
                else
                {

                    dataReader = _helper.ExecuteReader(base.ConnectionString,
                        "EB_FetechpaidInvoices", MemberID);
                }

                while (dataReader.Read())
                {
                    TransactionsModel.FetchInvoices objCampaign = new TransactionsModel.FetchInvoices();
                    if (dataReader["InvoiceID"] != DBNull.Value)
                        objCampaign.InvoiceID = dataReader.GetInt64(dataReader.GetOrdinal("InvoiceID"));
                    if (dataReader["Name"] != DBNull.Value)
                        objCampaign.Name = dataReader.GetString(dataReader.GetOrdinal("Name"));
                    if (dataReader["Mobile"] != DBNull.Value)
                        objCampaign.Mobile = dataReader.GetString(dataReader.GetOrdinal("Mobile"));
                    if (dataReader["Email"] != DBNull.Value)
                        objCampaign.Email = dataReader.GetString(dataReader.GetOrdinal("Email"));
                    if (dataReader["Address"] != DBNull.Value)
                        objCampaign.Address = dataReader.GetString(dataReader.GetOrdinal("Address"));
                    if (dataReader["InvoiceDate"] != DBNull.Value)
                        objCampaign.InvoiceDate = dataReader.GetDateTime(dataReader.GetOrdinal("InvoiceDate"));
                    if (dataReader["ActualAmount"] != DBNull.Value)
                        objCampaign.ActualAmount = dataReader.GetDecimal(dataReader.GetOrdinal("ActualAmount"));
                    if (dataReader["Discount"] != DBNull.Value)
                        objCampaign.Discount = dataReader.GetDecimal(dataReader.GetOrdinal("Discount"));
                    if (dataReader["DiscAmount"] != DBNull.Value)
                        objCampaign.DiscAmount = dataReader.GetDecimal(dataReader.GetOrdinal("DiscAmount"));
                    if (dataReader["BeforeTaxAmount"] != DBNull.Value)
                        objCampaign.BeforeTaxAmount = dataReader.GetDecimal(dataReader.GetOrdinal("BeforeTaxAmount"));
                    if (dataReader["TaxAmount"] != DBNull.Value)
                        objCampaign.TaxAmount = dataReader.GetDecimal(dataReader.GetOrdinal("TaxAmount"));
                    if (dataReader["FinalAmount"] != DBNull.Value)
                        objCampaign.FinalAmount = dataReader.GetDecimal(dataReader.GetOrdinal("FinalAmount"));
                    if (dataReader["Currency"] != DBNull.Value)
                        objCampaign.Currency = dataReader.GetString(dataReader.GetOrdinal("Currency"));
                    if (dataReader["Terms"] != DBNull.Value)
                        objCampaign.Terms = dataReader.GetString(dataReader.GetOrdinal("Terms"));
                    if (dataReader["Status"] != DBNull.Value)
                        objCampaign.Status = dataReader.GetByte(dataReader.GetOrdinal("Status"));
                    if (dataReader["CreatedBy"] != DBNull.Value)
                        objCampaign.CreatedBy = dataReader.GetGuid(dataReader.GetOrdinal("CreatedBy"));
                    if (dataReader["PaymentType"] != DBNull.Value)
                        objCampaign.PaymentType = dataReader.GetByte(dataReader.GetOrdinal("PaymentType"));
                    if (dataReader["PaymentMode"] != DBNull.Value)
                        objCampaign.PaymentMode = dataReader.GetByte(dataReader.GetOrdinal("PaymentMode"));
                    if (dataReader["ClientGST"] != DBNull.Value)
                        objCampaign.ClientGST = dataReader.GetString(dataReader.GetOrdinal("ClientGST"));
                    if (dataReader["InvoiceType"] != DBNull.Value)
                        objCampaign.InvoiceType = dataReader.GetByte(dataReader.GetOrdinal("InvoiceType"));
                    if (dataReader["Description"] != DBNull.Value)
                        objCampaign.Description = dataReader.GetString(dataReader.GetOrdinal("Description"));
                    if (dataReader["CGST"] != DBNull.Value)
                        objCampaign.CGST = dataReader.GetDecimal(dataReader.GetOrdinal("CGST"));
                    if (dataReader["SGST"] != DBNull.Value)
                        objCampaign.SGST = dataReader.GetDecimal(dataReader.GetOrdinal("SGST"));
                    if (dataReader["Quantity"] != DBNull.Value)
                        objCampaign.Quantity = dataReader.GetByte(dataReader.GetOrdinal("Quantity"));
                    if (dataReader["InvoiceFor"] != DBNull.Value)
                        objCampaign.InvoiceFor = dataReader.GetByte(dataReader.GetOrdinal("InvoiceFor"));
                    objListCampaign.Add(objCampaign);
                }
            }
            finally
            {
                if (dataReader != null)
                    dataReader.Close();
            }
            return objListCampaign;
        }
        //to update invoices wrote by eswar 2/6/2018
        private long privateUpdateInvoices(TransactionsModel.FetchInvoices objCampaign)
        {
            SqlParameter[] objSqlParameter = new SqlParameter[20];
            objSqlParameter[0] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            objSqlParameter[0].Value = objCampaign.InvoiceID;
            objSqlParameter[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            objSqlParameter[1].Value = objCampaign.Name;
            objSqlParameter[2] = new SqlParameter("@Email", SqlDbType.NVarChar);
            objSqlParameter[2].Value = objCampaign.Email;
            objSqlParameter[3] = new SqlParameter("@Mobile", SqlDbType.NVarChar);
            objSqlParameter[3].Value = objCampaign.Mobile;
            objSqlParameter[4] = new SqlParameter("@Address", SqlDbType.NVarChar);
            objSqlParameter[4].Value = objCampaign.Address;
            objSqlParameter[5] = new SqlParameter("@InvoiceDate", SqlDbType.DateTime);
            objSqlParameter[5].Value = objCampaign.InvoiceDate;
            objSqlParameter[6] = new SqlParameter("@ActualAmount", SqlDbType.Decimal);
            objSqlParameter[6].Value = objCampaign.ActualAmount;
            objSqlParameter[7] = new SqlParameter("@Discount", SqlDbType.Decimal);
            objSqlParameter[7].Value = objCampaign.Discount;
            objSqlParameter[8] = new SqlParameter("@DiscAmount", SqlDbType.Decimal);
            objSqlParameter[8].Value = objCampaign.DiscAmount;
            objSqlParameter[9] = new SqlParameter("@BeforeTaxAmount", SqlDbType.Decimal);
            objSqlParameter[9].Value = objCampaign.BeforeTaxAmount;
            objSqlParameter[10] = new SqlParameter("@TaxAmount", SqlDbType.Decimal);
            objSqlParameter[10].Value = objCampaign.TaxAmount;
            objSqlParameter[11] = new SqlParameter("@FinalAmount", SqlDbType.Decimal);
            objSqlParameter[11].Value = objCampaign.FinalAmount;
            objSqlParameter[12] = new SqlParameter("@Terms", SqlDbType.NVarChar);
            objSqlParameter[12].Value = objCampaign.Terms;
            objSqlParameter[13] = new SqlParameter("@Status", SqlDbType.TinyInt);
            objSqlParameter[13].Value = objCampaign.Status;
            objSqlParameter[14] = new SqlParameter("@InvoiceType", SqlDbType.TinyInt);
            objSqlParameter[14].Value = objCampaign.InvoiceType;
            objSqlParameter[15] = new SqlParameter("@ClientGST", SqlDbType.NVarChar);
            objSqlParameter[15].Value = objCampaign.ClientGST;
            objSqlParameter[16] = new SqlParameter("@Description", SqlDbType.NVarChar);
            objSqlParameter[16].Value = objCampaign.Description;
            objSqlParameter[17] = new SqlParameter("@CGST", SqlDbType.Decimal);
            objSqlParameter[17].Value = objCampaign.CGST;
            objSqlParameter[18] = new SqlParameter("@SGST", SqlDbType.Decimal);
            objSqlParameter[18].Value = objCampaign.SGST;
            objSqlParameter[19] = new SqlParameter("@Quantity", SqlDbType.TinyInt);
            objSqlParameter[19].Value = objCampaign.Quantity;
            if (base.Transaction != null)
            {
                _helper.ExecuteNonQuery(base.Transaction, CommandType.StoredProcedure, "EB_UpdateInvoice", objSqlParameter);
            }
            else
            {
                _helper.ExecuteNonQuery(base.ConnectionString, CommandType.StoredProcedure, "EB_UpdateInvoice", objSqlParameter);
            }
            return Convert.ToInt64(objSqlParameter[0].Value);
        }
        //to get  invoice details by invoiceid
        private TransactionsModel.GetInvoiceByInvoiceID PrivateEB_FetechInvoiceByInvoiceID(long InvoiceID, byte InvoiceType)
        {
            IDataReader dataReader = null;
            TransactionsModel.GetInvoiceByInvoiceID objCampaign = new TransactionsModel.GetInvoiceByInvoiceID();
            try
            {
                if (base.Transaction != null)
                {
                    dataReader = _helper.ExecuteReader(base.Transaction,
                        "EB_FetechInvoiceByInvoiceID", InvoiceID, InvoiceType);
                }
                else
                {

                    dataReader = _helper.ExecuteReader(base.ConnectionString,
                        "EB_FetechInvoiceByInvoiceID", InvoiceID, InvoiceType);
                }

                while (dataReader.Read())
                {
                    if (dataReader["MemberID"] != DBNull.Value)
                        objCampaign.MemberID = dataReader.GetGuid(dataReader.GetOrdinal("MemberID"));
                    if (dataReader["InvoiceID"] != DBNull.Value)
                        objCampaign.InvoiceID = dataReader.GetInt64(dataReader.GetOrdinal("InvoiceID"));
                    if (dataReader["Name"] != DBNull.Value)
                        objCampaign.Name = dataReader.GetString(dataReader.GetOrdinal("Name"));
                    if (dataReader["Mobile"] != DBNull.Value)
                        objCampaign.Mobile = dataReader.GetString(dataReader.GetOrdinal("Mobile"));
                    if (dataReader["Email"] != DBNull.Value)
                        objCampaign.Email = dataReader.GetString(dataReader.GetOrdinal("Email"));
                    if (dataReader["Address"] != DBNull.Value)
                        objCampaign.Address = dataReader.GetString(dataReader.GetOrdinal("Address"));
                    if (dataReader["InvoiceDate"] != DBNull.Value)
                        objCampaign.InvoiceDate = dataReader.GetDateTime(dataReader.GetOrdinal("InvoiceDate"));
                    if (dataReader["ActualAmount"] != DBNull.Value)
                        objCampaign.ActualAmount = dataReader.GetDecimal(dataReader.GetOrdinal("ActualAmount"));
                    if (dataReader["Discount"] != DBNull.Value)
                        objCampaign.Discount = dataReader.GetDecimal(dataReader.GetOrdinal("Discount"));
                    if (dataReader["DiscAmount"] != DBNull.Value)
                        objCampaign.DiscAmount = dataReader.GetDecimal(dataReader.GetOrdinal("DiscAmount"));
                    if (dataReader["BeforeTaxAmount"] != DBNull.Value)
                        objCampaign.BeforeTaxAmount = dataReader.GetDecimal(dataReader.GetOrdinal("BeforeTaxAmount"));
                    if (dataReader["TaxAmount"] != DBNull.Value)
                        objCampaign.TaxAmount = dataReader.GetDecimal(dataReader.GetOrdinal("TaxAmount"));
                    if (dataReader["FinalAmount"] != DBNull.Value)
                        objCampaign.FinalAmount = dataReader.GetDecimal(dataReader.GetOrdinal("FinalAmount"));
                    if (dataReader["Currency"] != DBNull.Value)
                        objCampaign.Currency = dataReader.GetString(dataReader.GetOrdinal("Currency"));
                    if (dataReader["Terms"] != DBNull.Value)
                        objCampaign.Terms = dataReader.GetString(dataReader.GetOrdinal("Terms"));
                    if (dataReader["Status"] != DBNull.Value)
                        objCampaign.Status = dataReader.GetByte(dataReader.GetOrdinal("Status"));
                    if (dataReader["CreatedBy"] != DBNull.Value)
                        objCampaign.CreatedBy = dataReader.GetGuid(dataReader.GetOrdinal("CreatedBy"));
                    if (dataReader["PaymentType"] != DBNull.Value)
                        objCampaign.PaymentType = dataReader.GetByte(dataReader.GetOrdinal("PaymentType"));
                    if (dataReader["PaymentMode"] != DBNull.Value)
                        objCampaign.PaymentMode = dataReader.GetByte(dataReader.GetOrdinal("PaymentMode"));
                    if (dataReader["ClientGST"] != DBNull.Value)
                        objCampaign.ClientGST = dataReader.GetString(dataReader.GetOrdinal("ClientGST"));
                    if (dataReader["InvoiceType"] != DBNull.Value)
                        objCampaign.InvoiceType = dataReader.GetByte(dataReader.GetOrdinal("InvoiceType"));
                    if (dataReader["Description"] != DBNull.Value)
                        objCampaign.Description = dataReader.GetString(dataReader.GetOrdinal("Description"));
                    if (dataReader["CGST"] != DBNull.Value)
                        objCampaign.CGST = dataReader.GetDecimal(dataReader.GetOrdinal("CGST"));
                    if (dataReader["SGST"] != DBNull.Value)
                        objCampaign.SGST = dataReader.GetDecimal(dataReader.GetOrdinal("SGST"));
                    if (dataReader["Quantity"] != DBNull.Value)
                        objCampaign.Quantity = dataReader.GetByte(dataReader.GetOrdinal("Quantity"));
                    if (dataReader["ChequeNo"] != DBNull.Value)
                        objCampaign.ChequeNo = dataReader.GetString(dataReader.GetOrdinal("ChequeNo"));
                    if (dataReader["ChequeAmount"] != DBNull.Value)
                        objCampaign.ChequeAmount = dataReader.GetString(dataReader.GetOrdinal("ChequeAmount"));
                    if (dataReader["BankDetails"] != DBNull.Value)
                        objCampaign.BankDetails = dataReader.GetString(dataReader.GetOrdinal("BankDetails"));
                    if (dataReader["CollectedBy"] != DBNull.Value)
                        objCampaign.CollectedBy = dataReader.GetString(dataReader.GetOrdinal("CollectedBy"));
                    if (dataReader["ChequeDate"] != DBNull.Value)
                        objCampaign.ChequeDate = dataReader.GetDateTime(dataReader.GetOrdinal("ChequeDate"));
                    if (dataReader["InvoiceFor"] != DBNull.Value)
                        objCampaign.InvoiceFor = dataReader.GetByte(dataReader.GetOrdinal("InvoiceFor"));
                }
            }
            finally
            {
                if (dataReader != null)
                    dataReader.Close();
            }
            return objCampaign;
        }
        //Update EBS Transaction
        private int PrivateEB_UpdateEBSTransactions(TransactionsModel.Transactions objPaymentDetails)
        {

            SqlParameter[] objSqlParameter = new SqlParameter[11];
            objSqlParameter[0] = new SqlParameter("@EBSPaymentID", SqlDbType.VarChar);
            objSqlParameter[0].Value = objPaymentDetails.EBSPaymentID;
            objSqlParameter[1] = new SqlParameter("@EBSTransactionID", SqlDbType.VarChar);
            objSqlParameter[1].Value = objPaymentDetails.EBSTransactionID;
            objSqlParameter[2] = new SqlParameter("@EBSPaymentMethod", SqlDbType.VarChar);
            objSqlParameter[2].Value = objPaymentDetails.EBSPaymentMethod;
            objSqlParameter[3] = new SqlParameter("@EBSPaymentStatus", SqlDbType.Bit);
            objSqlParameter[3].Value = objPaymentDetails.EBSPaymentStatus;
            objSqlParameter[4] = new SqlParameter("@EBSPaymentMessage", SqlDbType.VarChar);
            objSqlParameter[4].Value = objPaymentDetails.EBSPaymentMessage;
            objSqlParameter[5] = new SqlParameter("@PaymentDescription", SqlDbType.VarChar);
            objSqlParameter[5].Value = objPaymentDetails.PaymentDescription;
            objSqlParameter[6] = new SqlParameter("@IsFlagged", SqlDbType.Bit);
            objSqlParameter[6].Value = objPaymentDetails.IsFlagged;
            objSqlParameter[7] = new SqlParameter("@PaidOn", SqlDbType.DateTime);
            objSqlParameter[7].Value = objPaymentDetails.PaidOn;
            objSqlParameter[8] = new SqlParameter("@PaymentID", SqlDbType.UniqueIdentifier);
            objSqlParameter[8].Value = objPaymentDetails.PaymentID;
            objSqlParameter[9] = new SqlParameter("@OrderID", SqlDbType.BigInt);
            objSqlParameter[9].Value = objPaymentDetails.OrderID;
            objSqlParameter[10] = new SqlParameter("@Amount", SqlDbType.Decimal);
            objSqlParameter[10].Value = objPaymentDetails.Amount;
            if (base.Transaction != null)
            {
                return _helper.ExecuteNonQuery(base.Transaction,
                 CommandType.StoredProcedure,
                "EB_UpdateEBSTransaction",
                objSqlParameter);
            }
            else
            {
                return _helper.ExecuteNonQuery(base.ConnectionString,
                  CommandType.StoredProcedure,
                "EB_UpdateEBSTransaction",
                objSqlParameter);
            }
        }
        //For Get EBS Transaction Details By OrderID
        private TransactionsModel.Transactions PrivateEB_GetEBSTransactionDetailsByOrderID(long OrderID)
        {
            IDataReader dataReader = null;
            TransactionsModel.Transactions objEBSTransaction = new TransactionsModel.Transactions();
            try
            {
                if (base.Transaction != null)
                {
                    dataReader = _helper.ExecuteReader(base.Transaction,
                        "EB_GetEBSTransactionDetailsByOrderID",
                        OrderID);
                }
                else
                {

                    dataReader = _helper.ExecuteReader(base.ConnectionString,
                        "EB_GetEBSTransactionDetailsByOrderID",
                        OrderID);
                }

                while (dataReader.Read())
                {
                    if (dataReader["PaymentID"] != DBNull.Value)
                        objEBSTransaction.PaymentID = dataReader.GetGuid(dataReader.GetOrdinal("PaymentID"));
                    if (dataReader["Amount"] != DBNull.Value)
                        objEBSTransaction.Amount = dataReader.GetDecimal(dataReader.GetOrdinal("Amount"));
                    if (dataReader["PaidFor"] != DBNull.Value)
                        objEBSTransaction.PaidFor = dataReader.GetByte(dataReader.GetOrdinal("PaidFor"));
                    if (dataReader["InvoiceID"] != DBNull.Value)
                        objEBSTransaction.InvoiceID = dataReader.GetInt64(dataReader.GetOrdinal("InvoiceID"));

                }
            }
            finally
            {
                if (dataReader != null)
                    dataReader.Close();
            }
            return objEBSTransaction;
        }
        private long privateUpdateTransations(TransactionsModel.UPDateTransaction objCampaign)
        {
            SqlParameter[] objSqlParameter = new SqlParameter[11];
            objSqlParameter[0] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            objSqlParameter[0].Value = objCampaign.InvoiceID;
            objSqlParameter[1] = new SqlParameter("@PaymentID", SqlDbType.UniqueIdentifier);
            objSqlParameter[1].Value = objCampaign.PaymentID;
            objSqlParameter[2] = new SqlParameter("@Status", SqlDbType.TinyInt);
            objSqlParameter[2].Value = objCampaign.Status;
            objSqlParameter[3] = new SqlParameter("@ChequeNo", SqlDbType.NVarChar);
            objSqlParameter[3].Value = objCampaign.ChequeNo;
            objSqlParameter[4] = new SqlParameter("@ChequeAmount", SqlDbType.Decimal);
            objSqlParameter[4].Value = objCampaign.ChequeAmount;
            objSqlParameter[5] = new SqlParameter("@Paymentmode", SqlDbType.TinyInt);
            objSqlParameter[5].Value = objCampaign.PaymentMode;
            objSqlParameter[6] = new SqlParameter("@PaymentType", SqlDbType.TinyInt);
            objSqlParameter[6].Value = objCampaign.PaymentType;
            objSqlParameter[7] = new SqlParameter("@BankDetails", SqlDbType.NVarChar);
            objSqlParameter[7].Value = objCampaign.BankDetails;
            objSqlParameter[8] = new SqlParameter("@CollectedBy", SqlDbType.NVarChar);
            objSqlParameter[8].Value = objCampaign.CollectedBy;
            objSqlParameter[9] = new SqlParameter("@ChequeDate", SqlDbType.DateTime);
            objSqlParameter[9].Value = objCampaign.ChequeDate;
            objSqlParameter[10] = new SqlParameter("@ReturnInvoiceID", SqlDbType.BigInt);
            objSqlParameter[10].Direction = ParameterDirection.Output;

            if (base.Transaction != null)
            {
                _helper.ExecuteNonQuery(base.Transaction, CommandType.StoredProcedure, "EB_UpdateTransactionsInvoice", objSqlParameter);
            }
            else
            {
                _helper.ExecuteNonQuery(base.ConnectionString, CommandType.StoredProcedure, "EB_UpdateTransactionsInvoice", objSqlParameter);
            }
            return Convert.ToInt32(objSqlParameter[10].Value.ToString());
        }
        //to update  the recipt statuses
        private long privateUpdateReceiptTransations(TransactionsModel.UPDateReceiptTransaction objCampaign)
        {
            SqlParameter[] objSqlParameter = new SqlParameter[11];
            objSqlParameter[0] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            objSqlParameter[0].Value = objCampaign.InvoiceID;
            objSqlParameter[1] = new SqlParameter("@InvoiceType", SqlDbType.TinyInt);
            objSqlParameter[1].Value = objCampaign.InvoiceType;
            objSqlParameter[2] = new SqlParameter("@Status", SqlDbType.TinyInt);
            objSqlParameter[2].Value = objCampaign.Status;
            objSqlParameter[3] = new SqlParameter("@ChequeNo", SqlDbType.NVarChar);
            objSqlParameter[3].Value = objCampaign.ChequeNo;
            objSqlParameter[4] = new SqlParameter("@ChequeAmount", SqlDbType.Decimal);
            objSqlParameter[4].Value = objCampaign.ChequeAmount;
            objSqlParameter[5] = new SqlParameter("@Paymentmode", SqlDbType.TinyInt);
            objSqlParameter[5].Value = objCampaign.PaymentMode;
            objSqlParameter[6] = new SqlParameter("@PaymentType", SqlDbType.TinyInt);
            objSqlParameter[6].Value = objCampaign.PaymentType;
            objSqlParameter[7] = new SqlParameter("@BankDetails", SqlDbType.NVarChar);
            objSqlParameter[7].Value = objCampaign.BankDetails;
            objSqlParameter[8] = new SqlParameter("@CollectedBy", SqlDbType.NVarChar);
            objSqlParameter[8].Value = objCampaign.CollectedBy;
            objSqlParameter[9] = new SqlParameter("@ChequeDate", SqlDbType.DateTime);
            objSqlParameter[9].Value = objCampaign.ChequeDate;
            objSqlParameter[10] = new SqlParameter("@ReturnInvoiceID", SqlDbType.BigInt);
            objSqlParameter[10].Direction = ParameterDirection.Output;

            if (base.Transaction != null)
            {
                _helper.ExecuteNonQuery(base.Transaction, CommandType.StoredProcedure, "EB_UpdateReceiptTransactionsInvoice", objSqlParameter);
            }
            else
            {
                _helper.ExecuteNonQuery(base.ConnectionString, CommandType.StoredProcedure, "EB_UpdateReceiptTransactionsInvoice", objSqlParameter);
            }
            return Convert.ToInt32(objSqlParameter[10].Value.ToString());
        }
        //to delete invoice by invoiceid
        private int privateDeleteInvoiceByInvoiceID(long InvoiceId, byte InvoiceType, byte Status)
        {
            SqlParameter[] objSqlParameter = new SqlParameter[3];
            objSqlParameter[0] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            objSqlParameter[0].Value = InvoiceId;
            objSqlParameter[1] = new SqlParameter("@InvoiceType", SqlDbType.TinyInt);
            objSqlParameter[1].Value = InvoiceType;
            objSqlParameter[2] = new SqlParameter("@Status", SqlDbType.TinyInt);
            objSqlParameter[2].Value = Status;

            if (base.Transaction != null)
                return _helper.ExecuteNonQuery(base.Transaction, CommandType.StoredProcedure, "EB_DeleteInvoiceByInvoiceID", objSqlParameter);
            else
                return _helper.ExecuteNonQuery(base.ConnectionString, CommandType.StoredProcedure, "EB_DeleteInvoiceByInvoiceID", objSqlParameter);
        }
        //For Get EBS Transaction Details By OrderID
        private TransactionsModel.EbsTransactionForMemberdetails PrivateEB_FetchMemberDetailsForEbsTransaction(Guid MemberID)
        {
            IDataReader dataReader = null;
            TransactionsModel.EbsTransactionForMemberdetails objEBSTransaction = new TransactionsModel.EbsTransactionForMemberdetails();
            try
            {
                if (base.Transaction != null)
                {
                    dataReader = _helper.ExecuteReader(base.Transaction,
                        "EB_FetchMemberDetailsForEbsTransaction",
                        MemberID);
                }
                else
                {

                    dataReader = _helper.ExecuteReader(base.ConnectionString,
                        "EB_FetchMemberDetailsForEbsTransaction",
                        MemberID);
                }

                while (dataReader.Read())
                {
                    if (dataReader["MemberID"] != DBNull.Value)
                        objEBSTransaction.MemberID = dataReader.GetGuid(dataReader.GetOrdinal("MemberID"));
                    if (dataReader["Name"] != DBNull.Value)
                        objEBSTransaction.Name = dataReader.GetString(dataReader.GetOrdinal("Name"));
                    if (dataReader["Email"] != DBNull.Value)
                        objEBSTransaction.Email = dataReader.GetString(dataReader.GetOrdinal("Email"));
                    if (dataReader["Mobile"] != DBNull.Value)
                        objEBSTransaction.Mobile = dataReader.GetString(dataReader.GetOrdinal("Mobile"));
                    if (dataReader["Address"] != DBNull.Value)
                        objEBSTransaction.Address = dataReader.GetString(dataReader.GetOrdinal("Address"));
                    if (dataReader["CityName"] != DBNull.Value)
                        objEBSTransaction.CityName = dataReader.GetString(dataReader.GetOrdinal("CityName"));
                    if (dataReader["StateName"] != DBNull.Value)
                        objEBSTransaction.StateName = dataReader.GetString(dataReader.GetOrdinal("StateName"));
                    if (dataReader["CountryName"] != DBNull.Value)
                        objEBSTransaction.CountryName = dataReader.GetString(dataReader.GetOrdinal("CountryName"));
                    if (dataReader["ZipCode"] != DBNull.Value)
                        objEBSTransaction.ZipCode = dataReader.GetString(dataReader.GetOrdinal("ZipCode"));
                }
            }
            finally
            {
                if (dataReader != null)
                    dataReader.Close();
            }
            return objEBSTransaction;
        }
        //to create the Notifications
        private int privateEB_SP_Notifications_ToInsert(TransactionsModel.Notifications_ToCreate obj)
        {
            SqlParameter[] objSqlParameter = new SqlParameter[10];
            objSqlParameter[0] = new SqlParameter("@Notification_ID", SqlDbType.UniqueIdentifier);
            objSqlParameter[0].Value = obj.Notification_ID;
            objSqlParameter[1] = new SqlParameter("@NotificationFrom_ID", SqlDbType.UniqueIdentifier);
            objSqlParameter[1].Value = obj.NotificationFrom_ID;
            objSqlParameter[2] = new SqlParameter("@NotificationTo_ID", SqlDbType.UniqueIdentifier);
            objSqlParameter[2].Value = obj.NotificationTo_ID;
            objSqlParameter[3] = new SqlParameter("@Notification_Desc", SqlDbType.NVarChar);
            objSqlParameter[3].Value = obj.Notification_Desc;
            objSqlParameter[4] = new SqlParameter("@Notificationkey_ID", SqlDbType.UniqueIdentifier);
            objSqlParameter[4].Value = obj.Notificationkey_ID;
            objSqlParameter[5] = new SqlParameter("@NotificationKey", SqlDbType.NVarChar);
            objSqlParameter[5].Value = obj.NotificationKey;
            objSqlParameter[6] = new SqlParameter("@Created_ON", SqlDbType.DateTime2);
            objSqlParameter[6].Value = obj.Created_ON;
            objSqlParameter[7] = new SqlParameter("@Read_Status", SqlDbType.Bit);
            objSqlParameter[7].Value = obj.Read_Status;
            objSqlParameter[8] = new SqlParameter("@Notification_Type", SqlDbType.TinyInt);
            objSqlParameter[8].Value = obj.Notification_Type;
            objSqlParameter[9] = new SqlParameter("@IndustryID", SqlDbType.SmallInt);
            objSqlParameter[9].Value = obj.IndustryID;

            if (base.Transaction != null)
            {
                return _helper.ExecuteNonQuery(base.Transaction, CommandType.StoredProcedure, "EB_SP_Notifications_ToInsert", objSqlParameter);
            }
            else
            {
                return _helper.ExecuteNonQuery(base.ConnectionString, CommandType.StoredProcedure, "EB_SP_Notifications_ToInsert", objSqlParameter);
            }
        }
        //For Get  Notification details
        private List<TransactionsModel.Notifications_ToGet> PrivateEB_FetchNotificationsDetails(Guid MemberID, int PageCount)
        {
            IDataReader dataReader = null;
            List<TransactionsModel.Notifications_ToGet> ObjList = new List<TransactionsModel.Notifications_ToGet>();
            try
            {
                if (base.Transaction != null)
                {
                    dataReader = _helper.ExecuteReader(base.Transaction,
                        "EB_EB_FetchNotificationDetails",
                        MemberID, PageCount);
                }
                else
                {

                    dataReader = _helper.ExecuteReader(base.ConnectionString,
                        "EB_EB_FetchNotificationDetails",
                        MemberID, PageCount);
                }

                while (dataReader.Read())
                {
                    TransactionsModel.Notifications_ToGet obj = new TransactionsModel.Notifications_ToGet();
                    if (dataReader["Photo"] != DBNull.Value)
                        obj.Photo = dataReader.GetString(dataReader.GetOrdinal("Photo"));
                    if (dataReader["Name"] != DBNull.Value)
                        obj.Name = dataReader.GetString(dataReader.GetOrdinal("Name"));
                    if (dataReader["Notification_ID"] != DBNull.Value)
                        obj.Notification_ID = dataReader.GetGuid(dataReader.GetOrdinal("Notification_ID"));
                    if (dataReader["NotificationFrom_ID"] != DBNull.Value)
                        obj.NotificationFrom_ID = dataReader.GetGuid(dataReader.GetOrdinal("NotificationFrom_ID"));
                    if (dataReader["NotificationTo_ID"] != DBNull.Value)
                        obj.NotificationTo_ID = dataReader.GetGuid(dataReader.GetOrdinal("NotificationTo_ID"));
                    if (dataReader["Notificationkey_ID"] != DBNull.Value)
                        obj.Notificationkey_ID = dataReader.GetGuid(dataReader.GetOrdinal("Notificationkey_ID"));
                    if (dataReader["NotificationKey"] != DBNull.Value)
                        obj.NotificationKey = dataReader.GetString(dataReader.GetOrdinal("NotificationKey"));
                    if (dataReader["Created_ON"] != DBNull.Value)
                        obj.Created_ON = dataReader.GetDateTime(dataReader.GetOrdinal("Created_ON"));
                    if (dataReader["Lasttime_Read"] != DBNull.Value)
                        obj.Lasttime_Read = dataReader.GetDateTime(dataReader.GetOrdinal("Lasttime_Read"));
                    if (dataReader["Read_Status"] != DBNull.Value)
                        obj.Read_Status = dataReader.GetBoolean(dataReader.GetOrdinal("Read_Status"));
                    if (dataReader["IndustryID"] != DBNull.Value)
                        obj.IndustryID = dataReader.GetInt16(dataReader.GetOrdinal("IndustryID"));
                    if (dataReader["Notification_Type"] != DBNull.Value)
                        obj.Notification_Type = dataReader.GetByte(dataReader.GetOrdinal("Notification_Type"));
                    if (dataReader["Notification_Desc"] != DBNull.Value)
                        obj.Notification_Desc = dataReader.GetString(dataReader.GetOrdinal("Notification_Desc"));
                    ObjList.Add(obj);
                }
            }
            finally
            {
                if (dataReader != null)
                    dataReader.Close();
            }
            return ObjList;
        }  //to  update Read Status
        private int privateEB_SP_Notifications_ToUpdateRead(TransactionsModel.Notifications_ToCreate obj)
        {
            SqlParameter[] objSqlParameter = new SqlParameter[3];
            objSqlParameter[0] = new SqlParameter("@Notification_ID", SqlDbType.UniqueIdentifier);
            objSqlParameter[0].Value = obj.Notification_ID;
            objSqlParameter[1] = new SqlParameter("@Read_Status", SqlDbType.Bit);
            objSqlParameter[1].Value = obj.Read_Status;
            objSqlParameter[2] = new SqlParameter("@Lasttime_Read", SqlDbType.DateTime2);
            objSqlParameter[2].Value = obj.Lasttime_Read;


            if (base.Transaction != null)
            {
                return _helper.ExecuteNonQuery(base.Transaction, CommandType.StoredProcedure, "EB_SP_Notifications_ToUpdateRead", objSqlParameter);
            }
            else
            {
                return _helper.ExecuteNonQuery(base.ConnectionString, CommandType.StoredProcedure, "EB_SP_Notifications_ToUpdateRead", objSqlParameter);
            }
        }


        private int PrivateSp_InfluencerInsertOrUpdate(TransactionsModel.Influencer obj)
        {

            SqlParameter[] objSqlParameter = new SqlParameter[10];
            objSqlParameter[0] = new SqlParameter("@InfluencerID", SqlDbType.UniqueIdentifier);
            objSqlParameter[0].Value = obj.InfluencerID;
            objSqlParameter[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            objSqlParameter[1].Value = obj.Name;
            objSqlParameter[2] = new SqlParameter("@CompanyName", SqlDbType.NVarChar);
            objSqlParameter[2].Value = obj.CompanyName;
            objSqlParameter[3] = new SqlParameter("@Mobile", SqlDbType.NVarChar);
            objSqlParameter[3].Value = obj.Mobile;
            objSqlParameter[4] = new SqlParameter("@Type", SqlDbType.TinyInt);
            objSqlParameter[4].Value = obj.Type;
            objSqlParameter[5] = new SqlParameter("@EMail", SqlDbType.NVarChar);
            objSqlParameter[5].Value = obj.EMail;
            objSqlParameter[6] = new SqlParameter("@DateofBirth", SqlDbType.DateTime2);
            objSqlParameter[6].Value = obj.DateofBirth;
            objSqlParameter[7] = new SqlParameter("@Zipcode", SqlDbType.NVarChar);
            objSqlParameter[7].Value = obj.Zipcode;
            objSqlParameter[8] = new SqlParameter("@Photo", SqlDbType.NVarChar);
            objSqlParameter[8].Value = obj.Photo;
            objSqlParameter[9] = new SqlParameter("@CreatedBy", SqlDbType.UniqueIdentifier);
            objSqlParameter[9].Value = obj.CreatedBy;


            if (base.Transaction != null)
            {
                return _helper.ExecuteNonQuery(base.Transaction, CommandType.StoredProcedure, "Sp_InfluencerInsertOrUpdate", objSqlParameter);
            }
            else
            {
                return _helper.ExecuteNonQuery(base.ConnectionString, CommandType.StoredProcedure, "Sp_InfluencerInsertOrUpdate", objSqlParameter);
            }
        }


        private List<TransactionsModel.Influencer> PrivateSp_GetInfluencer(Guid UserID)
        {
            IDataReader dataReader = null;
            List<TransactionsModel.Influencer> objlist = new List<TransactionsModel.Influencer>();
            try
            {
                if (base.Transaction != null)
                {
                    dataReader = _helper.ExecuteReader(base.Transaction, "Sp_GetInfluencer", UserID);
                }
                else
                {

                    dataReader = _helper.ExecuteReader(base.ConnectionString, "Sp_GetInfluencer", UserID);
                }

                while (dataReader.Read())
                {
                    TransactionsModel.Influencer obj = new TransactionsModel.Influencer();
                    if (dataReader["InfluencerID"] != DBNull.Value)
                        obj.InfluencerID = dataReader.GetGuid(dataReader.GetOrdinal("InfluencerID"));
                    if (dataReader["Name"] != DBNull.Value)
                        obj.Name = dataReader.GetString(dataReader.GetOrdinal("Name"));
                    if (dataReader["CompanyName"] != DBNull.Value)
                        obj.CompanyName = dataReader.GetString(dataReader.GetOrdinal("CompanyName"));
                    if (dataReader["Mobile"] != DBNull.Value)
                        obj.Mobile = dataReader.GetString(dataReader.GetOrdinal("Mobile"));
                    if (dataReader["Type"] != DBNull.Value)
                        obj.Type = dataReader.GetByte(dataReader.GetOrdinal("Type"));
                    if (dataReader["EMail"] != DBNull.Value)
                        obj.EMail = dataReader.GetString(dataReader.GetOrdinal("EMail"));
                    if (dataReader["DateofBirth"] != DBNull.Value)
                        obj.DateofBirth = dataReader.GetDateTime(dataReader.GetOrdinal("DateofBirth"));
                    if (dataReader["Zipcode"] != DBNull.Value)
                        obj.Zipcode = dataReader.GetString(dataReader.GetOrdinal("Zipcode"));
                    if (dataReader["Photo"] != DBNull.Value)
                        obj.Photo = dataReader.GetString(dataReader.GetOrdinal("Photo"));

                    objlist.Add(obj);
                }
            }
            finally
            {
                if (dataReader != null)
                    dataReader.Close();
            }
            return objlist;
        }

        private byte PriavateSp_DeleteInfluencer(Guid InfluencerID)
        {
            byte retVal = 0;
            if (base.Transaction != null)
            {
                retVal = (byte)_helper.ExecuteNonQuery(base.Transaction, "Sp_DeleteInfluencer", InfluencerID);
            }
            else
            {
                retVal = (byte)_helper.ExecuteNonQuery(base.ConnectionString, "Sp_DeleteInfluencer", InfluencerID);
            }
            return retVal;
        }
        private byte PriavateSp_ChangeInfluencerType(Guid InfluencerID,byte Type)
        {
            byte retVal = 0;
            if (base.Transaction != null)
            {
                retVal = (byte)_helper.ExecuteNonQuery(base.Transaction, "Sp_ChangeInfluencerType", InfluencerID, Type);
            }
            else
            {
                retVal = (byte)_helper.ExecuteNonQuery(base.ConnectionString, "Sp_ChangeInfluencerType", InfluencerID, Type);
            }
            return retVal;
        }
        private int privateUpdateTransationsDetails(Guid PaymentID,long InvoiceID)
        {
            SqlParameter[] objSqlParameter = new SqlParameter[2];
            objSqlParameter[0] = new SqlParameter("@PaymentID", SqlDbType.UniqueIdentifier);
            objSqlParameter[0].Value = PaymentID;
            objSqlParameter[1] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            objSqlParameter[1].Value = InvoiceID;
            

            if (base.Transaction != null)
            {
                return _helper.ExecuteNonQuery(base.Transaction, CommandType.StoredProcedure, "eb_SP_UpdateTransactionInvoice", objSqlParameter);
            }
            else
            {
                return _helper.ExecuteNonQuery(base.ConnectionString, CommandType.StoredProcedure, "eb_SP_UpdateTransactionInvoice", objSqlParameter);
            }
        }
        #endregion PrivateMethods
    }
}
