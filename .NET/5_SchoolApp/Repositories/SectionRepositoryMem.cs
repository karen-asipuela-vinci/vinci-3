using _5_SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_SchoolApp.Repositories
{
    internal class SectionRepositoryMem : IRepository<Section>
    {

        private readonly List<Section> _sections = new List<Section>();

        public SectionRepositoryMem() 
        {

        }

        public void Delete(Section entity)
        {
            throw new NotImplementedException();
        }

        public IList<Section> GetAll()
        {
            throw new NotImplementedException();
        }

        public Section GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Section entity)
        {
            throw new NotImplementedException();
        }

        public bool Save(Section entity, System.Linq.Expressions.Expression<Func<Section, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<Section> SearchFor(System.Linq.Expressions.Expression<Func<Section, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
