using System;
using System.Collections.Generic;

namespace exo1
{
    [Serializable]
    internal class Director : Person
    {
        private static readonly long SerialVersionUID = 5952964360274024205L;
        private readonly IList<Movie> DirectedMovies;

        // Constructeur
        public Director(string name, string firstname, DateTime birthDate)
            : base(name, firstname, birthDate) // Appel du constructeur de la classe parente
        {
            DirectedMovies = []; // Initialisation de la liste
        }

        // Méthode pour ajouter un film
        public bool AddMovie(Movie movie)
        {
            if (DirectedMovies.Contains(movie))
                return false;

            if (movie.GetDirector() == null)
                movie.SetDirector(this);

            DirectedMovies.Add(movie);

            return true;
        }

        // Méthode pour obtenir l'énumérateur des films
        public IEnumerator<Movie> MoviesList()
        {
            return DirectedMovies.GetEnumerator();
        }
    }
}
