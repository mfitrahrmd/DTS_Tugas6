using DTS_Tugas6.Data;
using DTS_Tugas6.Models;
using DTS_Tugas6.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Repositories.mssql;

public class EmployeeRepository : EFCoreRepository<string, Employee, DatabaseContext>, IEmployeeRepository
{
    public EmployeeRepository(DatabaseContext context) : base(context)
    {
    }

    public Employee? FindOneByEmail(string email)
    {
        var employee = _context.Set<Employee>().FirstOrDefault(e => e.Email.Equals(email));

        return employee;
    }
}