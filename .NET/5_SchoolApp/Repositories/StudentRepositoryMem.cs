using _5_SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _5_SchoolApp.Repositories
{
    internal class StudentRepositoryMem : IRepository<Student>
    {
        private readonly List<Student> _students = new List<Student>();

        public StudentRepositoryMem()
        {

        }

        public void Delete(Student entity)
        {
            _students.Remove(entity);
        }

        public IList<Student> GetAll()
        {
            return _students;
        }

        public Student GetById(int id)
        {
            return _students.FirstOrDefault(s => s.StudentId == id);
        }

        public void Insert(Student entity)
        {
            _students.Add(entity);
        }

        public bool Save(Student entity, Expression<Func<Student, bool>> predicate)
        {
            var existingStudent = _students.AsQueryable().FirstOrDefault(predicate);
            if (existingStudent == null)
            {
                _students.Add(entity);
                return true;
            }
            return false;
        }

        public IList<Student> SearchFor(Expression<Func<Student, bool>> predicate)
        {
            return _students.AsQueryable().Where(predicate).ToList();
        }
    }
}
