using DTS_Tugas6.Models;
using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Repositories.mssql;

public class EmployeeRepository : EFCoreRepository<string, Employee>
{
    public EmployeeRepository(DbContext context) : base(context)
    {
    }
}