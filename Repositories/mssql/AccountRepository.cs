using DTS_Tugas6.Data;
using DTS_Tugas6.Models;
using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Repositories.mssql;

public class AccountRepository : EFCoreRepository<string, Account, DatabaseContext>
{
    public AccountRepository(DatabaseContext context) : base(context)
    {
    }
}