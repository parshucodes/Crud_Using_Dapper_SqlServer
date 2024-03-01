using Dapper;
using DapperDBFirst.Models;
using DapperDBFirst.Models.Data;

namespace DapperDBFirst.Repos
{
    public class EmployeeRepo : IEmployeeRepo
    {
        //creat ctor and inject our database in it
        private readonly DapperDBContext context;
        public EmployeeRepo(DapperDBContext context)
        {
            this.context = context;
        }

        

        //before implementing this getall fn we need to register this repos and interface in our prog.cs
        public async Task<List<Employee>> GetAll()
        {
            string query = "select * From tab_Employee";
            using (var connection = this.context.CreateConnection())
            {
                var emplist = await connection.QueryAsync<Employee>(query);
                return emplist.ToList();
            }
        }

        public async Task<string> Create(Employee employee)
        {
            string response = string.Empty;
            string query = "insert into tab_Employee(name, email,phone, desig)values(@name,@email,@phone,@desig)";
            var parameters = new DynamicParameters();
            parameters.Add("name", employee.Name, System.Data.DbType.String);
            parameters.Add("email", employee.Email, System.Data.DbType.String);
            parameters.Add("phone", employee.Phone, System.Data.DbType.String);
            parameters.Add("desig", employee.Desig, System.Data.DbType.String);

            using (var connection = this.context.CreateConnection())
            {
                var emplist = await connection.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }

        public async Task<Employee> GetbyCode(int code)
        {
            string query = "select * From tab_Employee where code=@code";
            using (var connection = this.context.CreateConnection())
            {
                var emplist = await connection.QueryFirstOrDefaultAsync<Employee>(query, new {code});
                return emplist;
            }
        }

        public async Task<string> Remove(int code)
        {
            string response = string.Empty;
            string query = "Delete From tab_Employee where code=@code";
            using (var connection = this.context.CreateConnection())
            {
                var emplist = await connection.ExecuteAsync(query, new { code });
                response = "pass";
            }
            return response;
        }

        public async Task<string> Update(Employee employee, int code)
        {
            string response = string.Empty;
            string query = "update tab_employee set name=@name,email=@email,phone=@phone,desig=@desig where code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("code", employee.Code, System.Data.DbType.Int32);
            parameters.Add("name", employee.Name, System.Data.DbType.String);
            parameters.Add("email", employee.Email, System.Data.DbType.String);
            parameters.Add("phone", employee.Phone, System.Data.DbType.String);
            parameters.Add("desig", employee.Desig, System.Data.DbType.String);

            using (var connection = this.context.CreateConnection())
            {
                var emplist = await connection.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }
    }
}
