using DapperDBFirst.Models;

namespace DapperDBFirst.Repos
{
    public interface IEmployeeRepo
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetbyCode(int code);
        Task<string> Create(Employee employee);

        Task<string> Update(Employee employee, int code);
        Task<string> Remove(int code);
    }
}
