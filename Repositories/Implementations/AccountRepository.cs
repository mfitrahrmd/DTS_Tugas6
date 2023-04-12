using DTS_Tugas6.Data;
using DTS_Tugas6.Models;
using DTS_Tugas6.Repositories.Contracts;
using DTS_Tugas6.ViewModels;

namespace DTS_Tugas6.Repositories.Implementations;

public class AccountRepository : EFCoreRepository<string, Account, DatabaseContext>, IAccountRepository
{
    public AccountRepository(DatabaseContext context) : base(context)
    {
    }

    public RegisterVM? Register(RegisterVM registerVm)
    {
        var tx = _context.Database.BeginTransaction();

        try
        {
            var university = _context.Set<University>().FirstOrDefault(u => u.Name.Equals(registerVm.UniversityName));

            if (university is null)
            {
                university = new University
                {
                    Name = registerVm.UniversityName
                };
            
                _context.Set<University>().Add(university);
                _context.SaveChanges();
            }

            var education = new Education
            {
                Major = registerVm.Major,
                Degree = registerVm.Degree,
                GPA = registerVm.GPA,
                UniversityId = university.Id
            };

            _context.Set<Education>().Add(education);
            _context.SaveChanges();

            var employee = new Employee
            {
                Nik = registerVm.Nik,
                FirstName = registerVm.FirstName,
                LastName = registerVm.LastName,
                Birthdate = registerVm.Birthdate,
                Gender = registerVm.Gender,
                PhoneNumber = registerVm.PhoneNumber,
                Email = registerVm.Email,
                HiringDate = DateTime.Now
            };

            _context.Set<Employee>().Add(employee);
            _context.SaveChanges();

            var account = new Account
            {
                EmployeeNik = registerVm.Nik,
                Password = registerVm.Password
            };

            _context.Set<Account>().Add(account);
            _context.SaveChanges();
        
            var roleUser = _context.Set<Role>().FirstOrDefault(r => r.Name.Equals("User"));

            if (roleUser is null)
            {
                roleUser = new Role
                {
                    Name = "User"
                };
            
                _context.Set<Role>().Add(roleUser);
                _context.SaveChanges();
            }

            var accountRole = new AccountRole
            {
                AccountNik = account.EmployeeNik,
                RoleId = roleUser.Id
            };

            _context.Set<AccountRole>().Add(accountRole);
            _context.SaveChanges();

            var profiling = new Profiling
            {
                EmployeeNik = registerVm.Nik,
                EducationId = education.Id
            };

            _context.Set<Profiling>().Add(profiling);
            _context.SaveChanges();
        
            tx.Commit();
        }
        catch (Exception)
        {
            tx.Rollback();
            throw;
        }

        return registerVm;
    }

    public bool Login(LoginVM loginVm)
    {
        var employee = _context.Set<Employee>().FirstOrDefault(e => e.Email.Equals(loginVm.Email));

        if (employee is null)
            throw new RepositoryException("Account was not found with given email", nameof(loginVm.Email));

        if (employee.Account is null)
            throw new NullReferenceException("Employee account is null");

        if (!employee.Account.Password.Equals(loginVm.Password))
            throw new RepositoryException("Invalid password", nameof(loginVm.Password));

        return true;
    }
}