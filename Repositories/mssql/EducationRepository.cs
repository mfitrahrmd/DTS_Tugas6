using DTS_Tugas6.Models;
using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Repositories.mssql;

public class EducationRepository : EFCoreRepository<int, Education>
{
    public EducationRepository(DbContext context) : base(context)
    {
    }
}