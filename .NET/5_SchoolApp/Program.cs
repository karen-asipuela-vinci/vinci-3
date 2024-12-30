// 1. création de la bd depuis fichier sur moodle
//! aux extensions : outils -> gestionnaire de package nuget -> ...

/////////////////////////////////////////////////
// PATTERN REPOSITORY

// 1. Implementer le pattern repository 
//TODO : ajouter interface IRepository<T>

// 2. Implementer le pattern repository
// - BaseRepositorySQL 
// - Un repository pour chaque entité

// 2. utilisaion de la classe Repository<T>
//! uniquement avec pattern repository

using System;
using System.Linq;
using _5_SchoolApp.Repositories;
using _5_SchoolApp.Models;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new SchoolContext()) // SchoolContext généré par scaffolding
        {
            // Initialisation des repositories
            var sectionRepository = new BaseRepositorySQL<Section>(context);
            var studentRepository = new BaseRepositorySQL<Student>(context);

            // a. Ajouter deux sections
            Console.WriteLine("Ajout des sections...");
            var sectInfo = new Section { Name = "Informatique" };
            var sectDiet = new Section { Name = "Diététique" };

            // Ajout conditionnel des sections
            sectionRepository.Save(sectInfo, s => s.Name == sectInfo.Name);
            sectionRepository.Save(sectDiet, s => s.Name == sectDiet.Name);
            context.SaveChanges();

            // b. Vérification des sections via LINQ
            Console.WriteLine("Vérification des sections en base de données...");
            var sectionsInDb = sectionRepository.GetAll();
            foreach (var section in sectionsInDb)
            {
                Console.WriteLine($"Section trouvée : {section.Name}");
            }

            // c. Ajouter 3 étudiants
            Console.WriteLine("Ajout des étudiants...");
            var studInfo1 = new Student
            {
                Name = "Dupont",
                Firstname = "Jean",
                YearResult = 100,
                SectionId = sectInfo.SectionId
            };

            var studDiet = new Student
            {
                Name = "Martin",
                Firstname = "Sophie",
                YearResult = 120,
                SectionId = sectDiet.SectionId
            };

            var studInfo2 = new Student
            {
                Name = "Dupont",
                Firstname = "Marie",
                YearResult = 110,
                SectionId = sectInfo.SectionId
            };

            // Ajout conditionnel des étudiants
            studentRepository.Save(studInfo1, s => s.Name == studInfo1.Name && s.Firstname == studInfo1.Firstname);
            studentRepository.Save(studDiet, s => s.Name == studDiet.Name && s.Firstname == studDiet.Firstname);
            studentRepository.Save(studInfo2, s => s.Name == studInfo2.Name && s.Firstname == studInfo2.Firstname);
            context.SaveChanges();

            // d. Vérifiez le résultat en base de données
            Console.WriteLine("Vérification des étudiants en DB...");
            var studentsInDb = studentRepository.GetAll();
            foreach (var student in studentsInDb)
            {
                Console.WriteLine($"Étudiant : {student.Name} {student.Firstname}, Year Result : {student.YearResult}, Section ID : {student.SectionId}");
            }
        }

        ///////////////////////////////////////////////////////////////
        /// query LINQ pour afficher les étudiants par section triée par ordre de résultat 
        /// 

        using (var context = new SchoolContext())
        {
            // initialisation du repository 
            var studentRepository = new StudentRepositorySQL(context);

            // appeller la méthode
            var studentsGroupedBySection = studentRepository.GetStudentsGroupedBySectionOrderedByResult();

            // affichage des résultats
            foreach (var group in studentsGroupedBySection)
            {
                Console.WriteLine($"Section : {group.Key.Name}");
                foreach (var student in group)
                {
                    Console.WriteLine($"\tÉtudiant : {student.Name} {student.Firstname}, Year Result : {student.YearResult}");
                }
            }
        }

        // pour vérifier les données dans la bd : directement dans le serveur sql
        /*
         * SELECT * FROM Sections;
            SELECT * FROM Students;
           */
    }
}


