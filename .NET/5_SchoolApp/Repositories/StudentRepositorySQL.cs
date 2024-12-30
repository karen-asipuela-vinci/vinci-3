using _5_SchoolApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_SchoolApp.Repositories
{
    internal class StudentRepositorySQL : BaseRepositorySQL<Student>
    {

        private readonly SchoolContext _context;

        public StudentRepositorySQL(SchoolContext context) : base(context)
        {
            _context = context;
        }

        // afficher étudiants par section en fonction de leur résultat : les têtes d'abord
        public IList<IGrouping<Section, Student>> GetStudentsGroupedBySectionOrderedByResult()
        {
            return _context.Set<Student>()
                .Include(s => s.Section) // Inclure les informations de la section pour chaque étudiant
                .OrderByDescending(s => s.YearResult) // Trier les étudiants par leur résultat annuel, de la meilleure note à la pire
                .GroupBy(s => s.Section!) // Grouper les étudiants par section
                .ToList(); // Convertir le résultat en liste
        }
    }
}
