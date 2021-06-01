using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UI.ViewModels
{
    public class EmployeeViewModel:ViewModelBase
    {
        private Visibility visible;
        public Visibility Visible
        {
            get { return visible; }
            set
            {
                visible = value;
                OnPropertyChanged(nameof(Visible));
            }
        }

        private DateTime dOB;
        public DateTime DOB
        {
            get { return dOB; }
            set
            {
                dOB = value;
                OnPropertyChanged(nameof(DOB));
            }
        }

        private string gender;
        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }


        private ObservableCollection<Company> companies;
        public ObservableCollection<Company> Companies
        {
            get { return companies; }
            set
            {
                companies = value;
                OnPropertyChanged(nameof(Companies));
            }
        }

        private Company selectedCompany;

        public Company SelectedCompany
        {
            get { return selectedCompany; }
            set
            {
                selectedCompany = value;
                OnPropertyChanged(nameof(SelectedCompany));
            }
        }

        private ObservableCollection<Employee> data;
        public ObservableCollection<Employee> Data
        {
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged(nameof(Data));
            }
        }

        private ObservableCollection<Developer> dataDeveloper;
        public ObservableCollection<Developer> DataDeveloper
        {
            get { return dataDeveloper; }
            set
            {
                dataDeveloper = value;
                OnPropertyChanged(nameof(DataDeveloper));
            }
        }

        private Visibility showTeams;
        public Visibility ShowTeams
        {
            get { return showTeams; }
            set
            {
                showTeams = value;
                OnPropertyChanged(nameof(ShowTeams));
            }
        }

        private ObservableCollection<Team> teams;

        public ObservableCollection<Team> Teams
        {
            get { return teams; }
            set
            {
                teams = value;
                OnPropertyChanged(nameof(Teams));
            }
        }


        private Team selectedTeam;
        public Team SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                selectedTeam = value;
                OnPropertyChanged(nameof(SelectedTeam));
            }
        }

        private Employee selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                Visible = Visibility.Collapsed;
                Cleanup();
                IsSelected = true;
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }

        private string selectedOption;

        public string SelectedOption
        {
            get { return selectedOption; }
            set
            {
                selectedOption = value;
                OnPropertyChanged(nameof(SelectedOption));
            }
        }

        private Visibility showAddButton;
        public Visibility ShowAddButton
        {
            get { return showAddButton; }
            set
            {
                showAddButton = value;
                OnPropertyChanged(nameof(ShowAddButton));
            }
        }

        private Visibility showEditButton;

        public Visibility ShowEditButton
        {
            get { return showEditButton; }
            set
            {
                showEditButton = value;
                OnPropertyChanged(nameof(ShowEditButton));
            }
        }

        private Visibility showDeveloper;

        public Visibility ShowDeveloper
        {
            get { return showDeveloper; }
            set
            {
                showDeveloper = value;
                OnPropertyChanged(nameof(ShowDeveloper));
            }
        }

        private Visibility showDefault;

        public Visibility ShowDefault
        {
            get { return showDefault; }
            set
            {
                showDefault = value;
                OnPropertyChanged(nameof(ShowDefault));
            }
        }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }


        public MyICommand AddCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand ShowAddCommand { get; set; }
        public MyICommand ShowEditCommand { get; set; }
        public MyICommand DevelopersCommand { get; set; }
        public MyICommand ManagersCommand { get; set; }
        public MyICommand SuppliersCommand { get; set; }

        public void Refresh()
        {
            Data = new ObservableCollection<Employee>(Service.Instance.GetEmployees());
            ShowDefault = Visibility.Visible;
            ShowDeveloper = Visibility.Collapsed;
        }

        public void Cleanup()
        {
            Name = "";
            Gender = null;
            DOB = DateTime.Now;
            SelectedCompany = null;
            SelectedTeam = null;
            IsSelected = false;
        }

        private string role;

        public string Role
        {
            get { return role; }
            set
            {
                role = value;
                if (value == "Developer")
                {
                    ShowTeams = Visibility.Visible;
                }
                else
                {
                    ShowTeams = Visibility.Collapsed;
                }
                OnPropertyChanged(nameof(Role));
            }
        }

        public List<string> Roles { get; set; } = new List<string>() { "Developer", "Manager", "Supplier" };
        public List<string> Genders { get; set; } = new List<string>() { "Male", "Female" };

        public EmployeeViewModel()
        {
            ShowAddCommand = new MyICommand(ShowAdd);
            ShowEditCommand = new MyICommand(ShowEdit);
            DeleteCommand = new MyICommand(Delete);
            AddCommand = new MyICommand(Add);
            EditCommand = new MyICommand(Edit);
            DevelopersCommand = new MyICommand(Developers);
            SuppliersCommand = new MyICommand(Suppliers);
            ManagersCommand = new MyICommand(Managers);
            Teams = new ObservableCollection<Team>(Service.Instance.GetTeams());
            Companies = new ObservableCollection<Company>(Service.Instance.GetCompanies());
            Cleanup();
            Visible = Visibility.Collapsed;
            Refresh();
        }

        public void Developers()
        {
            ShowDeveloper = Visibility.Visible;
            ShowDefault = Visibility.Collapsed;
            DataDeveloper = new ObservableCollection<Developer>(Service.Instance.GetDevelopers());
        }

        public void Managers()
        {
            ShowDefault = Visibility.Visible;
            ShowDeveloper = Visibility.Collapsed;
            Data = new ObservableCollection<Employee>(Service.Instance.GetManagers());
        }

        public void Suppliers()
        {
            ShowDefault = Visibility.Visible;
            ShowDeveloper = Visibility.Collapsed;
            Data = new ObservableCollection<Employee>(Service.Instance.GetSuppliers());
        }

        public void ShowAdd()
        {
            if (Visible == Visibility.Collapsed)
            {
                Visible = Visibility.Visible;
                ShowAddButton = Visibility.Visible;
                ShowEditButton = Visibility.Collapsed;
                Cleanup();
            }
            else if (ShowEditButton == Visibility.Visible)
            {
                ShowEditButton = Visibility.Collapsed;
                ShowAddButton = Visibility.Visible;
                Cleanup();
            }
            else
            {
                Visible = Visibility.Collapsed;
            }
        }

        public void ShowEdit()
        {
            if (Visible == Visibility.Collapsed)
            {
                Visible = Visibility.Visible;
                ShowAddButton = Visibility.Collapsed;
                ShowEditButton = Visibility.Visible;
                DOB = SelectedEmployee.DOB;
                Name = SelectedEmployee.Name;
                Gender = SelectedEmployee.Gender;
                if (SelectedEmployee is Developer)
                {
                    ShowTeams = Visibility.Visible;
                    SelectedTeam = (SelectedEmployee as Developer).Team;
                }
                else if (SelectedEmployee is Supplier)
                {
                    ShowTeams = Visibility.Collapsed;
                }
                else if (SelectedEmployee is Manager)
                {
                    ShowTeams = Visibility.Collapsed;
                }
                //SelectedCompany = SelectedEmployee.Company;
                //if(SelectedEmployee.GetType() == typeof(Developer))
                //{
                //    SelectedTeam = (SelectedEmployee as Developer).Team;
                //    Role = "Developer";
                //}
                //else if(SelectedEmployee.GetType() == typeof(Manager))
                //{
                //    Role = "Manager";
                //}
                //else if (SelectedEmployee.GetType() == typeof(Supplier))
                //{
                //    Role = "Supplier";
                //}
            }
            else if (ShowAddButton == Visibility.Visible)
            {
                ShowAddButton = Visibility.Collapsed;
                ShowEditButton = Visibility.Visible;
                Cleanup();
            }
            else
            {
                Visible = Visibility.Collapsed;
            }
        }

        public void Add()
        {
            if (Validate())
            {
                if (Role == "Developer")
                {
                    Service.Instance.AddDeveloper(new Developer() { Name = Name, DOB = DOB, Company = SelectedCompany, Gender = Gender, Team = SelectedTeam });
                }
                else if (Role == "Supplier")
                {
                    Service.Instance.AddSupplier(new Supplier() { Name = Name, DOB = DOB, Company = SelectedCompany, Gender = Gender });
                }
                else if(Role == "Manager")
                {
                    Service.Instance.AddManager(new Manager() { Name = Name, DOB = DOB, Company = SelectedCompany, Gender = Gender });
                }
                Refresh();
                Cleanup();
                Visible = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Please input correct values.", "Validation", MessageBoxButton.OK);
            }
        }

        public void Edit()
        {
            if (Validate())
            {
                if (SelectedEmployee is Developer)
                {
                    Service.Instance.EditDeveloper(SelectedEmployee.Id, new Developer() { Id = SelectedEmployee.Id, Company = SelectedCompany, DOB= DOB, Gender = Gender, Name = Name, Team = SelectedTeam});
                }
                else if (SelectedEmployee is Supplier)
                {
                    Service.Instance.EditSupplier(SelectedEmployee.Id, new Supplier() { Id = SelectedEmployee.Id, Company = SelectedCompany, DOB = DOB, Gender = Gender, Name = Name });
                }
                else if (SelectedEmployee is Manager)
                {
                    Service.Instance.EditManager(SelectedEmployee.Id, new Manager() { Id = SelectedEmployee.Id, Company = SelectedCompany, DOB = DOB, Gender = Gender, Name = Name });
                }
                Refresh();
                Cleanup();
                Visible = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Please input correct values.", "Validation", MessageBoxButton.OK);
            }
        }

        public void Delete()
        {
            if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Service.Instance.DeleteEmployee(SelectedEmployee.Id);
                Refresh();
                Cleanup();
                Visible = Visibility.Collapsed;
            }
        }

        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Role) && ShowEditButton == Visibility.Collapsed)
            {
                return false;
            }
            if (SelectedTeam == null && (Role=="Developer" || SelectedEmployee is Developer))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(Gender))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(Name))
            {
                return false;
            }
            if(SelectedCompany == null && ShowEditButton == Visibility.Collapsed)
            {
                return false;
            }
            return true;
        }
    }
}
