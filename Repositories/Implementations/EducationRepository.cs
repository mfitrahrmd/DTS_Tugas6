using DTS_Tugas6.Data;
using DTS_Tugas6.Models;
using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Repositories.mssql;

public class EducationRepository : EFCoreRepository<int, Education, DatabaseContext>, IEducationRepository
{
    public EducationRepository(DatabaseContext context) : base(context)
    {
    }
}