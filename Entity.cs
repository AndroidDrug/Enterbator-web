using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// This class is the base class which will be inherited by all DataAccesslayer classes.
    /// </summary>
    public class Entity
    {
        #region Private Fields
        private SqlTransaction _transaction = null;
        private string _connectionString = null;
        #endregion

        #region Constructor
        public Entity()
        {
        }

        public Entity(SqlTransaction transaction)
        {
            _transaction = transaction;
        }
        #endregion

        #region Public Properties
        public SqlTransaction Transaction
        {
            get { return _transaction; }
            set { _transaction = value; }
        }
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }
        #endregion
    }
}
