using System;

namespace WpfEmployee.ViewModels
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }

        // Propriété calculée pour afficher le nom complet
        public string FullName => $"{FirstName} {LastName}";

        // Propriété calculée pour formater la date de naissance
        public string DisplayBirthDate => BirthDate?.ToString("d MMM yyyy") ?? "N/A";
    }
}
