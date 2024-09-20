using MathNet.Numerics.LinearAlgebra.Solvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo1
{
    internal class PersonList
    {
        private static PersonList? Instance; // ? nullable
        private readonly Dictionary<string, Person> PersonMap; // Map -> Dictionary

        private PersonList()
        {
            PersonMap = [];
        }

        public static PersonList GetInstance()
        {
            Instance = new PersonList();

            return Instance;
        }

        public void AddPerson(Person Person)
        {
            if (Person == null)
                throw new MathNet.Numerics.InvalidParameterException();
            PersonMap.Add(Person.GetName(), Person);
        }

        public IEnumerator<Person> PersonListIt()
        {
            return PersonMap.Values.GetEnumerator();
        }

    }
}
