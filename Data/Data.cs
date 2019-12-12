using System;
using System.Data.SqlClient;

namespace ECommerce.Data
{
    public abstract class Data : IDisposable
    {
        protected SqlConnection connection;

        public Data()
        {
            string strConn = @"Data Source=localhost;
                                Initial Catalog=Ecommerce;
                                Integrated Security=true";
                                // User Id=sa; Password=dba;

            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}