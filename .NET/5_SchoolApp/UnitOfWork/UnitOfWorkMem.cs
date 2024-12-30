using _5_SchoolApp.Models;
using _5_SchoolApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_SchoolApp.UnitOfWork
{
    class UnitOfWorkMem : IUnitOfWork
    {
        private IRepository<Student> _studentRepository;

        public UnitOfWorkMem()
        {
            this._studentRepository = new StudentRepositoryMem();
        }

        public IRepository<Student> StudentRepository
        {
            get
            {
                return this._studentRepository;
            }
        }
    }
}
