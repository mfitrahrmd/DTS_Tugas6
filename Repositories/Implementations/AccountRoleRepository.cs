using DTS_Tugas6.Data;
using DTS_Tugas6.Models;
using DTS_Tugas6.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Repositories.mssql;

public class AccountRoleRepository : EFCoreRepository<int, AccountRole, DatabaseContext>, IAccountRoleRepository
{
    public AccountRoleRepository(DatabaseContext context) : base(context)
    {
    }
}