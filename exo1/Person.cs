using System;
using System.Globalization;

namespace exo1
{
    [Serializable] // annotations entre []
    internal class Person
    {
        // private static readonly long SerialVersionUID = 1L; // pas utilisé (?) - effacé
        private readonly string Name; // utilisation de alias string au lieu de la Class
        private readonly string Firstname;
        private readonly DateTime BirthDate;  // Utilisation de DateTime au lieu de Calendar

        public string GetName()
        {
            return Name;
        }

        public string GetFirstname()
        {
            return Firstname;
        }

        public string GetBirthDate()
        {
            return BirthDate.ToString("dd-MM-yyyy");
        }

        public Person(string Name, string Firstname, DateTime BirthDate)
        {
            this.Name = Name;
            this.Firstname = Firstname;
            this.BirthDate = BirthDate;
        }

        public override string ToString()
        {
            return $"Personne [name = {Name}, firstname = {Firstname}, birthDate = {GetBirthDate()}]";
        }
    }
}
