using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperDBFirst.Models.Data
{
    public class DapperDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionstring;
        //Constructor : there we can inject our _configuration in or to access our connectionstring
        public DapperDBContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            this.connectionstring = this._configuration.GetConnectionString("conn");
        }
        //next in our dapper basically it is to extend the idb connection interface
        public IDbConnection CreateConnection() => new SqlConnection(connectionstring);
        //now we have to register this databse context in our program.cs
    }
}
