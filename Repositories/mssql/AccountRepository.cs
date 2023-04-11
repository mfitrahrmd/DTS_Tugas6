using DTS_Tugas6.Models;
using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Repositories.mssql;

public class AccountRepository : EFCoreRepository<string, Account>
{
    public AccountRepository(DbContext context) : base(context)
    {
    }
}