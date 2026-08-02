using dotnet_101.DTOs;
using dotnet_101.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_101.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]

    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository) => _employeeRepository = employeeRepository;

        [HttpGet("{id}/manager-chain")]
        public async Task<List<EmployeeDto>> ListManagerChain(int id)
        {
            return await _employeeRepository.ListManagerChain(id);
        }
    }
}