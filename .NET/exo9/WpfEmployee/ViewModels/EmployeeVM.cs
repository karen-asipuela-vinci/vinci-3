using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    public class EmployeeVM
    {
        public ObservableCollection<EmployeeModel> EmployeesList { get; set; } = new ObservableCollection<EmployeeModel>();

        // employé sélectionné
        private EmployeeModel _selectedEmployee;
        public EmployeeModel SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                // Mettre à jour la propriété
            }
        }

        // Liste des titres de courtoisie
        public ObservableCollection<string> ListTitle { get; set; } = new ObservableCollection<string>
    {
        "Mr.",
        "Mrs.",
        "Dr.",
        "Ms."
    };

        public void LoadEmployees()
        {
            using (var context = new NorthwindContext())
            {
                var employees = context.Employees.ToList();

                // Convertir chaque Employee en EmployeeModel
                foreach (var employee in employees)
                {
                    EmployeesList.Add(new EmployeeModel
                    {
                        EmployeeID = employee.EmployeeId,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        BirthDate = employee.BirthDate,
                        TitleOfCourtesy = employee.TitleOfCourtesy
                    });
                }
            }
        }

        // Implémentation de INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
