using DTS_Tugas6.Models;
using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Repositories.mssql;

public class ProfilingRepository : EFCoreRepository<string, Profiling>
{
    public ProfilingRepository(DbContext context) : base(context)
    {
    }
}