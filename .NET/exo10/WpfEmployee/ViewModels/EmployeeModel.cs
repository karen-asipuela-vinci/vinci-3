using System;
using System.ComponentModel;

namespace WpfEmployee.Models
{
    public class EmployeeModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _titleOfCourtesy;
        private DateTime? _birthDate;
        private DateTime? _hireDate;
        private Employee eGlobal;

        public EmployeeModel(Employee eGlobal)
        {
            this.eGlobal = eGlobal;
        }

        public int EmployeeID { get; set; }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName)); // Met à jour FullName
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName)); // Met à jour FullName
            }
        }

        public string TitleOfCourtesy
        {
            get => _titleOfCourtesy;
            set
            {
                _titleOfCourtesy = value;
                OnPropertyChanged();
            }
        }

        public DateTime? BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }

        //display BitrhDate in the format "dd/MM/yyyy"
        public string DisplayBirthDate => BirthDate?.ToString("dd/MM/yyyy");

        public DateTime? HireDate
        {
            get => _hireDate;
            set
            {
                _hireDate = value;
                OnPropertyChanged();
            }
        }

        // Propriété calculée pour le nom complet
        public string FullName => $"{FirstName} {LastName}";

        // Implémentation de INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
