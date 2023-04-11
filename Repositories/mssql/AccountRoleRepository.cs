using DTS_Tugas6.Models;
using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Repositories.mssql;

public class AccountRoleRepository : EFCoreRepository<int, AccountRole>
{
    public AccountRoleRepository(DbContext context) : base(context)
    {
    }
}