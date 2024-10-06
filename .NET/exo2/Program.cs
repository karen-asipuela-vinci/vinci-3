//2 préparation de l'exo
using LINQDataContext;
using Microsoft.VisualBasic.CompilerServices;

DataContext dc = new DataContext();

Student? jdepp = (from student in dc.Students
                  where student.Login == "jdepp"
                  select student).SingleOrDefault();

if (jdepp != null)
{
    Console.WriteLine(jdepp.Last_Name + jdepp.First_Name);
}

Console.WriteLine("----------------------- 2.1 --------------------------");

//2 exos 2

/* exo 2.1
 * Ecrire une requête pour présenter, pour chaque étudiant, 
 * le nom de l’étudiant, la date de naissance, le login et le résultat pour l’année de l’étudiant. */
var studentView = from Student s in dc.Students
                            select new
                            {
                                s.Last_Name,
                                s.BirthDate,
                                s.Login,
                                s.Year_Result
                            };

//autre version (appels méthodes) 2.1

studentView = dc.Students.Select(s => new
{
    s.Last_Name,
    s.BirthDate,
    s.Login,
    s.Year_Result
});

foreach (var student in studentView)
{
    Console.WriteLine("{0} est né le {1} et a obtenu {2}.", student.Last_Name, student.BirthDate, student.Year_Result);
}

Console.WriteLine("----------------------- 2.2 --------------------------");

// exo 2.2
// Ecrire une requête pour présenter, pour chaque étudiant,
// son nom complet (nom et prénom séparés par un espace),
// son id et sa date de naissance.
//  ’objectif pour cet exercice est de réaliser un maximum dans le query et non dans l’affichage.

var studentV = from Student student in dc.Students
                            select new
                            {
                                FullName = student.Last_Name + " " + student.First_Name,
                                student.Student_ID,
                                student.BirthDate
                            };

foreach (var stud in studentV)
{
    Console.WriteLine("{0} {1} {2}", stud.FullName, stud.Student_ID, stud.BirthDate);
}

Console.WriteLine("------------------------ 2.3 -------------------------");


// exo 2.3
/* Exercice 2.3 (SUPPLEMENTAIRE)
Ecrire une requête pour présenter, pour chaque étudiant, dans une seule colonne l’ensemble des données relatives séparées par un « | ».*/

// En-tête des colonnes
Console.WriteLine("{0,-15} {1,-10} {2,-15} {3,-15} {4,-5}", "Nom", "Prénom", "Date de Naissance", "Login", "Résultat");

// Requête LINQ
var studentData = from student in dc.Students
                  select new
                  {
                      student.Last_Name,
                      student.First_Name,
                      BirthDate = student.BirthDate.ToString("yyyy-MM-dd"),
                      student.Login,
                      YearResult = student.Year_Result
                  };

// Affichage des résultats
foreach (var student in studentData)
{
    // Affichage formaté avec colonnes
    Console.WriteLine("{0,-15}| {1,-10}| {2,-15}| {3,-15}| {4,-5}",
        student.Last_Name,
        student.First_Name,
        student.BirthDate,
        student.Login,
        student.YearResult);
}

Console.WriteLine("----------------------- 3.1 --------------------------");

//2 exos 3 : OPERATEURS WHERE, ORDER BY

// Exo 3.1
/*Pour chaque étudiant né avant 1955, donner le nom, le résultat annuel et le statut. 
 * Le statut prend la valeur « OK » si l’étudiant a obtenu au moins 12 comme résultat annuel et « KO » dans le cas contraire.*/

var studentWhere = from student in dc.Students
                   where student.BirthDate.Year < 1955
                   select new
                   {
                       student.Last_Name,
                       student.First_Name,
                       student.Year_Result,
                       Status = student.Year_Result >= 12 ? "OK" : "KO"
                   };


foreach (var s in studentWhere)
{
    Console.WriteLine("{0} {1} {2} {3}", s.Last_Name, s.First_Name, s.Year_Result, s.Status);
}

Console.WriteLine("------------------------- 3.2 ------------------------");

// exo 3.2
/*Donner pour chaque étudiant né entre 1955 et 1965 
 * le nom, le résultat annuel et la catégorie à laquelle il appartient. 
 * La catégorie est en fonction du résultat obtenu :	< 10 : inférieure ;  > 10 : supérieure ; = 10 : neutre .*/

var studentW = from students in dc.Students
               where students.BirthDate.Year >= 1955 && students.BirthDate.Year <= 1965
               select new
               {
                   students.Last_Name,
                   students.Year_Result,
                   Category = students.Year_Result < 10 ? "Inférieure" : students.Year_Result == 10 ? "Neutre" : "Supérieure"
               };

foreach (var s in studentW)
{
    Console.WriteLine(s);
}

Console.WriteLine("----------------------- 3.3 --------------------------");

// exo 3.3  ( SUPPLEMENTAIRE)
/*Ecrire une requête pour présenter le nom et l’id de section de tous les étudiants dont le nom de famille se termine par « r ».*/

var student33 = from students in dc.Students
                where students.Last_Name.EndsWith("r")
                select new
                       {
                           students.Last_Name,
                           students.Section_ID
                       };

foreach (var s in student33)
{
    Console.WriteLine(s);
}

Console.WriteLine("----------------------- 3.4 --------------------------");

// exo 3.4
/*Ecrire une requête pour présenter le nom et le résultat annuel classé par résultats annuels décroissants
 de tous les étudiants qui ont obtenu un résultat inférieur ou égal à 3.*/

var student34 = from students in dc.Students
                where students.Year_Result <= 3
                orderby students.Year_Result descending
                select new
                {
                    students.Last_Name,
                    students.Year_Result
                };

foreach (var s in student34)
{
    Console.WriteLine(s);
};

Console.WriteLine("----------------------- 3.5 ---------------------------");

// exo 3.5
/*Ecrire une requête pour présenter le nom complet (nom et prénom séparés par un espace) 
 * et le résultat annuel classé par ordre croissant sur le nom des étudiants appartenant à la section 1110.  */

var student35 = from students in dc.Students
                where students.Section_ID == 1110
                orderby students.Last_Name ascending
                select new
                {
                    Name = students.Last_Name + " " + students.First_Name,
                    students.Year_Result
                };

foreach(var s in student35)
{
    Console.WriteLine(s);
};

Console.WriteLine("----------------------- 3.6 ---------------------------");

// exo 3.6 (SUPPLEMENTAIRE)
/*Ecrire une requête pour présenter le nom, 
 * l’id de section
 * et le résultat annuel classé par ordre croissant sur la section de tous les étudiants 
 * appartenant aux sections 1010 et 1020 ayant un résultat annuel qui n’est pas compris entre 12 et 18.*/

var students36 = from students in dc.Students
                 where 
                    (students.Section_ID == 1010 || students.Section_ID == 1020)
                 && (students.Year_Result > 18 || students.Year_Result < 12)
                 orderby students.Section_ID ascending
                 select new
                 {
                     students.Last_Name,
                     students.Section_ID,
                     students.Year_Result
                 };

foreach (var s in students36)
{
    Console.WriteLine(s);
};

Console.WriteLine("----------------------- 3.7 ---------------------------");

// Exercice 3.7 ( SUPPLEMENTAIRE)
/* Ecrire une requête pour présenter le nom, l’id de section et le résultat annuel sur 100 ( nommer une colonne result_100)
 * classé par ordre décroissant du résultat de tous les étudiants appartenant aux sections commençant par 13 
 * et ayant un résultat annuel sur 100 inférieur ou égal à 60.*/

var students37 = from students in dc.Students
                 where students.Section_ID.ToString().StartsWith("13")
                 && students.Year_Result * 100 <= 60
                 orderby students.Year_Result descending
                 select new
                 {
                     students.Last_Name,
                     students.Section_ID,
                     result_100 = students.Year_Result * 100
                 };

foreach (var s in students37)
{
    Console.WriteLine(s);
};

//2 exos 4

Console.WriteLine("----------------------- Exos 4 ---------------------------");

/*Exercice 4.1
Donner le résultat annuel moyen pour l’ensemble des étudiants.
*/

double moyenne = dc.Students.Average(s => s.Year_Result);

Console.WriteLine("La moyenne est de {0}", moyenne);

/*Exercice 4.2 ( SUPPLEMENTAIRE)
Donner le plus haut résultat annuel obtenu par un étudiant.
*/

double bestResult = dc.Students.Max(s => s.Year_Result);

Console.WriteLine("Le résultat maximum est de {0}", bestResult);

/*Exercice 4.3 ( SUPPLEMENTAIRE)
Donner la somme des résultats annuels.
*/

double somme = dc.Students.Sum(s => s.Year_Result);

Console.WriteLine("La somme des résultats annuels est de {0}", somme);

/*Exercice 4.4 ( SUPPLEMENTAIRE)
Donner le résultat annuel le plus faible.
*/

double minResult = dc.Students.Min(s => s.Year_Result);

Console.WriteLine("Le résultat annuel mimum est {0}", minResult);

/*Exercice 4.5
Donner le nombre de lignes qui composent la « table » STUDENT.
*/

int nbLignes = dc.Students.Count();

Console.WriteLine("Le nombre de lignes composant la table Student est de {0}", nbLignes);

//2 exos 5

Console.WriteLine("----------------------- Exos 5 ---------------------------");

// groupement par section
var sectionsResult = from Student s in dc.Students
                     group s by s.Section_ID;

Console.WriteLine("----------------------- 5.1 ---------------------------");
/*Exercice 5.1
Donner pour chaque section, le résultat maximum (Max_Result) obtenu par les étudiants.
*/
//## utiliser grouping !!!

foreach (IGrouping<Int32, Student> section in sectionsResult)
{
    Console.WriteLine("Le max de la section {0} est {1}", section.Key, section.Max(s => s.Year_Result));

}

Console.WriteLine("----------------------- 5.2 ---------------------------");

/*Exercice 5.2 ( SUPPLEMENTAIRE)
Donner pour toutes les sections commençant par 10, le résultat annuel moyen (AVG_Result) obtenu par les étudiants.
*/

foreach (IGrouping<int, Student> section in sectionsResult)
{
    // Vérification si la section commence par "10"
    if (section.Key.ToString().StartsWith("10"))
    {
        // Calcul de la moyenne des résultats pour cette section
        double avg_Result = section.Average(s => s.Year_Result);
        Console.WriteLine("La section {0} a une moyenne de {1}", section.Key, avg_Result);
    }
}

Console.WriteLine("----------------------- 5.3 ---------------------------");

/*Exercice 5.3
Donner le résultat moyen (AVG_Result) et le mois en chiffre (BirtMonth) pour les étudiants né le même mois entre 1970 et 1985.
*/
//## besoin d'un nouveau avg car autre condition

var avg_condition = from students in dc.Students
                    where (students.BirthDate.Year >= 1970 && students.BirthDate.Year <= 1985)
                    group students by students.BirthDate.Month;

foreach (IGrouping<int, Student> section in avg_condition)
{
    Console.WriteLine("Moyenne : {0} du mois : {1}", section.Key, section.Average(s => s.Year_Result));
};

Console.WriteLine("----------------------- 5.4 ---------------------------");

/*Exercice 5.4 ( SUPPLEMENTAIRE)
Donner pour toutes les sections comptant plus de 3 étudiants, la moyenne des résultats annuels ( AVG_Results).
*/

var avg_3 = from section in sectionsResult
            where section.Count() > 3
            select new
            {
                section.Key,
                //## ne pas oublier de mettre un nom quand méthode/condition
                avg_Result = section.Average(s => s.Year_Result)
            };

foreach (var s in avg_3)
{
    Console.WriteLine("La section {0} a une moyenne de {1}", s.Key, s.avg_Result);
};

Console.WriteLine("----------------------- 5.5 ---------------------------");

/* Exercice 5.5 
Donner pour chaque cours le nom du professeur responsable ainsi que la section dont il fait partie.
*/

var query = from Cours in dc.Courses
            join prof in dc.Professors on Cours.Professor_ID equals prof.Professor_ID
            join sect in dc.Sections on prof.Section_ID equals sect.Section_ID
            select new { Cours.Course_Name, prof.Professor_Name, sect.Section_Name };

foreach (var res in query)
{
    Console.WriteLine(res.Course_Name + " " + res.Section_Name + " " + res.Professor_Name);
}

Console.WriteLine("----------------------- 5.6 ---------------------------");

/*Exercice 5.6 ( SUPPLEMENTAIRE)
Donner pour chaque section, l’id, le nom et le nom de son délégué. Classer les sections dans l’ordre inverse des ids de section.
*/

// Assuming that each section has a delegate (student representative)
var query5_6 = from s in dc.Sections
               join d in dc.Students on s.Delegate_ID equals d.Student_ID
               orderby s.Section_ID descending
               select new
               {
                   SectionID = s.Section_ID,
                   SectionName = s.Section_Name,
                   DelegateName = d.Last_Name
               };

foreach (var section in query5_6)
{
    Console.WriteLine("Section ID: {0}, Nom: {1}, Délégué: {2}", section.SectionID, section.SectionName, section.DelegateName);
}

Console.WriteLine("----------------------- 5.7 ---------------------------");

/*Exercice 5.7 
Donner pour toutes les sections les professeurs qui en sont membres.
*/

// groupjoin
var query5_7 = from s in dc.Sections
               join p in dc.Professors on s.Section_ID equals p.Section_ID into sectProfs
               select new { 
                   nomsection = s.Section_Name,
                   nomsprofs = sectProfs 
               };

foreach (var jointure in query5_7)
{
    Console.WriteLine("Section : " + jointure.nomsection);
    foreach (Professor prof in jointure.nomsprofs)
    {
        Console.WriteLine("Prof : " + prof.Professor_Name);
    }
}

Console.WriteLine("----------------------- 5.8 ---------------------------");

/*Exercice 5.8 ( COMPLEXE)
Même objectif que le 5.7 mais seules les sections comportant au moins 1 professeur doivent être prises en compte.
*/
// groupjoin + test count
var query5_8 = from s in dc.Sections
               join p in dc.Professors on s.Section_ID equals p.Section_ID into sectProfs
               where sectProfs.Count() > 0
               select new { nomsection = s.Section_Name, nomsprofs = sectProfs };

foreach (var jointure in query5_8)
{
    if (jointure.nomsprofs.Count() > 0)
    {
        Console.WriteLine("Section : " + jointure.nomsection);

        foreach (Professor prof in jointure.nomsprofs)
        {
            Console.WriteLine("Prof : " + prof.Professor_Name);
        }
    }
}

Console.WriteLine("----------------------- 5.9 ---------------------------");

/*Exercice 5.9 ( COMPLEXE)
Donner à chaque étudiant ayant obtenu un résultat annuel supérieur ou égal à 12 son grade en fonction de son résultat annuel et sur base de la table grade. 
La liste doit être classée dans l’ordre alphabétique des grades attribués.
*/

var studentsGrades = from s in dc.Students
                     from g in dc.Grades
                     where s.Year_Result >= g.Lower_Bound && s.Year_Result <= g.Upper_Bound
                     select new
                     {
                         StudentName = s.Last_Name,
                         StudentResult = s.Year_Result,
                         Grade = g.GradeName
                     };


var listStudents = from ls in studentsGrades
                   where ls.StudentResult >= 12
                   orderby ls.Grade ascending
                   select ls;

// Afficher les résultats
foreach (var student in listStudents)
{
    Console.WriteLine("Nom: {0}, Résultat: {1}, Grade: {2}", student.StudentName, student.StudentResult, student.Grade);
}


Console.WriteLine("----------------------- 5.10 ---------------------------");

/*Exercice 5.10 ( COMPLEXE)
Donner la liste des professeurs et la section à laquelle ils se rapportent ainsi que le(s) cours ( nom du cours et crédits) dont le professeur est responsable. 
La liste est triée par ordre décroissant de crédits attribués à un cours.
*/

var query5_10 = from p in dc.Professors
                join s in dc.Sections on p.Section_ID equals s.Section_ID
                join c in dc.Courses on p.Professor_ID equals c.Professor_ID
                orderby c.Course_Ects descending
                select new
                {
                    ProfessorName = p.Professor_Name,
                    SectionName = s.Section_Name,
                    CourseName = c.Course_Name,
                    Credits = c.Course_Ects
                };

foreach (var entry in query5_10)
{
    Console.WriteLine("Professeur: {0}, Section: {1}, Cours: {2}, Crédits: {3}",
                      entry.ProfessorName, entry.SectionName, entry.CourseName, entry.Credits);
}

Console.WriteLine("----------------------- 5.11 ---------------------------");

/* Exercice 5.11 (SUPPLEMENTAIRE)
Donner pour chaque professeur son id et le total des crédits ECTS (ECTSTOT) qui lui sont attribués. 
La liste est triée par ordre décroissant de la somme des crédits alloués.
*/

var query5_11 = from p in dc.Professors
                join c in dc.Courses on p.Professor_ID equals c.Professor_ID
                group c by new { p.Professor_ID, p.Professor_Name } into profGroup // Inclure le nom si nécessaire
                select new
                {
                    ProfessorID = profGroup.Key.Professor_ID,
                    TotalCredits = profGroup.Sum(c => c.Course_Ects)
                };

// Appliquer l'ordre décroissant après la sélection
var orderedProfessors = query5_11.OrderByDescending(p => p.TotalCredits);

foreach (var professor in orderedProfessors)
{
    Console.WriteLine("Professeur ID: {0}, Total Crédits ECTS: {1}", professor.ProfessorID, professor.TotalCredits);
}
