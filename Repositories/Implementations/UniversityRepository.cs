using DTS_Tugas6.Data;
using DTS_Tugas6.Models;
using DTS_Tugas6.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Repositories.mssql;

public class UniversityRepository : EFCoreRepository<int, University, DatabaseContext>, IUniversityRepository
{
    public UniversityRepository(DatabaseContext context) : base(context)
    {
    }

    public IEnumerable<University> FindManyContainsName(string name)
    {
        return from u in _context.Set<University>()
            where u.Name.Contains(name)
            select u;
    }
}