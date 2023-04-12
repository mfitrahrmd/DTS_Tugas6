using DTS_Tugas6.Models;
using DTS_Tugas6.ViewModels;

namespace DTS_Tugas6.Repositories;

public interface IAccountRepository : IBaseRepository<string, Account>
{
    RegisterVM? Register(RegisterVM registerVm);
    bool Login(LoginVM loginVm);
    
}