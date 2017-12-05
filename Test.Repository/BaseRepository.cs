using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Test.Repository
{
    public class BaseRepository
    {
        protected IDbConnection con;
        public BaseRepository()
        {
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;            
            con = new SqlConnection(settings["Northwind"].ConnectionString);
        }
        public void Dispose()
        {
            //throw new NotImplementedException();  
        }
    }
}
