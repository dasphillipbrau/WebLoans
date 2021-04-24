using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebLoans.app.Database
{
    public class DbConnection
    {
        public string ConnectionString { get; private set; }

        public SqlConnection Conn { get; private set; }

        public DbConnection()
        {
            GetConnection();
        }

        private string GetConnection()
        {
            return ConnectionString = ConfigurationManager.ConnectionStrings["LoansDB"].ConnectionString;
        }

        public void ExecuteNonQuery(SqlCommand pCommand)
        {
            try
            {
                using (Conn = new SqlConnection(ConnectionString))
                {
                    Conn.Open();
                    pCommand.Connection = Conn;
                    pCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    pCommand.ExecuteNonQuery();
                }
            } 
            catch(SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
                Console.WriteLine(sqlEx.Number);
                throw sqlEx;
            } 
            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }



    }
}