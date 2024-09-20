using MathNet.Numerics.LinearAlgebra.Solvers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace exo1
{

    internal class Actor:Person
    {

        private static readonly long SerialVersionUID = 1L;
        private readonly int SizeInCentimeter;
        private readonly IList<Movie> Movies = [];

        public int getSizeInCentimeter()
        {
            return SizeInCentimeter;
        }

        public Actor(string Name, string Firstname, DateTime BirthDate, int SizeInCentimeter)
            : base(Name, Firstname, BirthDate)
        {
            this.SizeInCentimeter = SizeInCentimeter;  
        }


      public string ToString()
        {
            return "Actor [name = " + GetName() + " firstname = " + GetFirstname() + " sizeInCentimeter = " + SizeInCentimeter + " birthdate = " + GetBirthDate() + "]";
        }

        /**
         * 
         * @return list of movies in which the actor has played
         */
        public IEnumerator<Movie> MoviesList()
        {
            return Movies.GetEnumerator();
        }

        /**
         * add movie to the list of movies in which the actor has played
         * @param movie
         * @return false if the movie is null or already present
         */
        public bool AddMovie(Movie Movie)
        {
            if ((Movie == null) || Movies.Contains(Movie))
                return false;

            if (!Movie.ContainsActor(this))
                Movie.AddActor(this);

            Movies.Add(Movie);

            return true;
        }

        public bool ContainsMovie(Movie Movie)
        {
            return Movies.Contains(Movie);
        }

        public string GetName()
        {
            return base.GetName().ToUpper();
        }
    }
}
