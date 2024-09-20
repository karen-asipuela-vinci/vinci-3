using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace exo1
{
    internal class Movie
    {

        private string title;
        private int releaseYear;
        private List<Actor> actors = new();
        private Director director;

        public Movie(string title, int releaseYear)
        {
            this.title = title;
            this.releaseYear = releaseYear;
        }

        public Director GetDirector()
        {
            return director;
        }
        public void SetDirector(Director director)
        {
            if (director == null)
                return;
            this.director = director;
            director.AddMovie(this);
        }

        public string GetTitle()
        {
            return title;
        }
        public void SetTitle(string title)
        {
            this.title = title;
        }
        public int GetReleaseYear()
        {
            return releaseYear;
        }
        public void SetReleaseYear(int releaseYear)
        {
            this.releaseYear = releaseYear;
        }

        public bool AddActor(Actor actor)
        {
            if (actors.Contains(actor))
                return false;

            actors.Add(actor);
            if (!actor.ContainsMovie(this))
                actor.AddMovie(this);

            return true;
        }

        public bool ContainsActor(Actor actor)
        {
            return actors.Contains(actor);
        }

        public string ToString()
        {
            return "Movie [title=" + title + ", releaseYear=" + releaseYear + "]";
        }


    }
}
