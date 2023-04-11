using DTS_Tugas6.Data;
using DTS_Tugas6.Models;
using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Repositories.mssql;

public class UniversityRepository : EFCoreRepository<int, University, DatabaseContext>
{
    public UniversityRepository(DatabaseContext context) : base(context)
    {
    }
}