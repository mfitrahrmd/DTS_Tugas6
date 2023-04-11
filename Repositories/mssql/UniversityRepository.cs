using DTS_Tugas6.Models;
using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Repositories.mssql;

public class UniversityRepository : EFCoreRepository<int, University>
{
    public UniversityRepository(DbContext context) : base(context)
    {
    }
}