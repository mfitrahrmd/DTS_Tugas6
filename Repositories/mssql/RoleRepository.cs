using DTS_Tugas6.Data;
using DTS_Tugas6.Models;
using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Repositories.mssql;

public class RoleRepository : EFCoreRepository<int, Role, DatabaseContext>
{
    public RoleRepository(DatabaseContext context) : base(context)
    {
    }
}