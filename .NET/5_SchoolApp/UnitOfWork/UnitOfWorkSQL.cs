using _5_SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_SchoolApp.Repositories
{
    internal class UnitOfWorkSQL : IUnitOfWork
    {
        private readonly SchoolContext _context;
        private BaseRepositorySQL<Student> _studentRepository;

        public UnitOfWorkSQL(SchoolContext context)
        {
            _context = context;
            _studentRepository = new BaseRepositorySQL<Student>(context);
        }

        public IRepository<Student> StudentRepository
        {
            get
            {
                return _studentRepository;
            }
        }

    }
}
