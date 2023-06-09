using DTS_Tugas6.Data;
using DTS_Tugas6.Models;
using DTS_Tugas6.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Repositories.mssql;

public class RoleRepository : EFCoreRepository<int, Role, DatabaseContext>, IRoleRepository
{
    public RoleRepository(DatabaseContext context) : base(context)
    {
    }
}