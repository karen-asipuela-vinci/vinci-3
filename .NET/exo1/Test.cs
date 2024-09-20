using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace exo1
{
    internal class Test
    {
        public static void Main()
        {

            Actor[] MyActors =  {
                new( "Assange", "Julian", new DateTime(1961, 6, 3), 187),
                new( "Paul", "Newmann", new DateTime(1925, 1, 26), 187),
                new( "Becker", "Norma Jean", new DateTime(1926, 5, 1), 187)
        };

            Director[] MyDirectors = {
                // month start 0
                new("Spielberg", "Steven", new DateTime(1946, 11, 18)),
                new("Coen", "Ettan", new DateTime(1957, 8, 21)),
                new("Coppolla", "Francis Ford", new DateTime(1939, 3, 7))
        };


            Movie bigLebow = new("The Big Lebowski", 1996);
            Movie eT = new("E.T.", 1982);

            eT.AddActor(MyActors[0]);
            eT.AddActor(MyActors[2]);
            eT.SetDirector(MyDirectors[0]);

            bigLebow.AddActor(MyActors[1]);
            bigLebow.AddActor(MyActors[2]);
            bigLebow.SetDirector(MyDirectors[1]);

            PersonList myPersons = PersonList.GetInstance();

            foreach (Actor Act in MyActors)
            {
                myPersons.AddPerson(Act);
            }

            foreach (Director Director in MyDirectors)
            {
                myPersons.AddPerson(Director);
            }

            IEnumerator<Person> ActorIt = myPersons.PersonListIt();
            while (ActorIt.MoveNext())
            {
                Person Person = ActorIt.Current;
                Console.WriteLine(Person);

                IEnumerator<Movie> MoviesIt;
                if (Person is Actor)
                {
                    Console.WriteLine("a joué dans les films suivants ");
                    MoviesIt = ((Actor)Person).MoviesList();
                }
                else
                {
                    if (Person is Director)
                    {
                        Console.WriteLine("a dirigé les films suivants :");
                        MoviesIt = ((Director)Person).MoviesList();
                    }
                    else
                    {
                        Console.WriteLine("est inconnu et n'a rien à faire ici !!! ");
                        continue;
                    }
                }
                while (MoviesIt.MoveNext())
                {
                    Movie Movie = MoviesIt.Current;
                    Console.WriteLine(Movie);
                }

            }
        }
    }
}
