using DTS_Tugas6.Data;
using DTS_Tugas6.Models;
using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Repositories.mssql;

public class EmployeeRepository : EFCoreRepository<string, Employee, DatabaseContext>
{
    public EmployeeRepository(DatabaseContext context) : base(context)
    {
    }
}