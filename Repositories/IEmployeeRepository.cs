using dotnet_101.DTOs;

namespace dotnet_101.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeDto>> ListManagerChain(int id);
    }
}