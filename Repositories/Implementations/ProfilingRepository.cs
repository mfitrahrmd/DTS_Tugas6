using DTS_Tugas6.Data;
using DTS_Tugas6.Models;
using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Repositories.mssql;

public class ProfilingRepository : EFCoreRepository<string, Profiling, DatabaseContext>, IProfilingRepository
{
    public ProfilingRepository(DatabaseContext context) : base(context)
    {
    }
}