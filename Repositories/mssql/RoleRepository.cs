using DTS_Tugas6.Models;
using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Repositories.mssql;

public class RoleRepository : EFCoreRepository<int, Role>
{
    public RoleRepository(DbContext context) : base(context)
    {
    }
}