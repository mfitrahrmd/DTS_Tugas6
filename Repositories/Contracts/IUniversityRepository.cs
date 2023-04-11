using DTS_Tugas6.Models;

namespace DTS_Tugas6.Repositories;

public interface IUniversityRepository : IBaseRepository<int, University>
{
    IEnumerable<University> FindManyContainsName(string name);
}