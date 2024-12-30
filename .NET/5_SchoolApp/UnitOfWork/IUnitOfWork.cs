using _5_SchoolApp.Models;

namespace _5_SchoolApp.Repositories
{
    internal interface IUnitOfWork
    {
        IRepository<Student> StudentRepository { get; }
    }
}
