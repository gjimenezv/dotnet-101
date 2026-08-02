using dotnet_101.DTOs;
using dotnet_101.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_101.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DotnetDbContext _context;

        public EmployeeRepository(DotnetDbContext context) => _context = context;

        public Task<List<EmployeeDto>> ListManagerChain(int id)
        {
           
            return _context.Database.SqlQueryRaw<EmployeeDto>(
                @"WITH ManagerChain AS (
                    SELECT e.Id, e.Name, e.Title, e.ManagerId, 0 as Level
                    FROM Employees e
                    WHERE e.Id = {0}

                    UNION ALL

                    SELECT e.Id, e.Name, e.Title, e.ManagerId, mc.Level + 1
                    FROM Employees e
                    INNER JOIN ManagerChain mc ON e.id = mc.ManagerId
                )
                SELECT Id, Name, Title
                FROM ManagerChain
                WHERE Level > 0
                ORDER BY Level ASC;",
                id
            ).ToListAsync();
        }
    }
}