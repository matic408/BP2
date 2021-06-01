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
    public class ProjectViewModel:ViewModelBase
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

        private string desc;
        public string Desc
        {
            get { return desc; }
            set
            {
                desc = value;
                OnPropertyChanged(nameof(Desc));
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


        private ObservableCollection<Contract> contracts;
        public ObservableCollection<Contract> Contracts
        {
            get { return contracts; }
            set
            {
                contracts = value;
                OnPropertyChanged(nameof(Contracts));
            }
        }

        private Contract selectedContract;

        public Contract SelectedContract
        {
            get { return selectedContract; }
            set
            {
                selectedContract = value;
                OnPropertyChanged(nameof(SelectedContract));
            }
        }

        private ObservableCollection<Project> data;
        public ObservableCollection<Project> Data
        {
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged(nameof(Data));
            }
        }

        private ObservableCollection<Manager> managers;

        public ObservableCollection<Manager> Managers
        {
            get { return managers; }
            set
            {
                managers = value;
                OnPropertyChanged(nameof(Managers));
            }
        }


        private Manager selectedManager;
        public Manager SelectedManager
        {
            get { return selectedManager; }
            set
            {
                selectedManager = value;
                OnPropertyChanged(nameof(SelectedManager));
            }
        }

        private Project selectedProject;

        public Project SelectedProject
        {
            get { return selectedProject; }
            set
            {
                selectedProject = value;
                Visible = Visibility.Collapsed;
                Cleanup();
                IsSelected = true;
                OnPropertyChanged(nameof(SelectedProject));
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

        public void Refresh()
        {
            Data = new ObservableCollection<Project>(Service.Instance.GetProjects());
        }

        public void Cleanup()
        {
            Name = "";
            Desc = "";
            SelectedManager = null;
            SelectedContract = null;
            IsSelected = false;
        }

        public ProjectViewModel()
        {
            ShowAddCommand = new MyICommand(ShowAdd);
            ShowEditCommand = new MyICommand(ShowEdit);
            DeleteCommand = new MyICommand(Delete);
            AddCommand = new MyICommand(Add);
            EditCommand = new MyICommand(Edit);
            Managers = new ObservableCollection<Manager>(Service.Instance.GetManagers());
            Contracts = new ObservableCollection<Contract>(Service.Instance.GetContracts());
            Cleanup();
            Visible = Visibility.Collapsed;
            Refresh();
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
                Name = SelectedProject.Name;
                Desc = SelectedProject.Description;
                SelectedManager = SelectedProject.Manager;
                SelectedContract = selectedProject.Contract;
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
                Service.Instance.AddProject(new Project { Name=Name, Description = Desc, Manager = SelectedManager, Contract = SelectedContract });
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
                Service.Instance.EditProject(SelectedProject.Id, new Project() { Id = SelectedProject.Id, Name = Name, Manager=SelectedManager, Contract= SelectedContract, Description = Desc });
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
                if (Service.Instance.DeleteProject(SelectedProject.Id))
                {
                    Refresh();
                    Cleanup();
                    Visible = Visibility.Collapsed;
                }
                else
                {
                    MessageBox.Show("Failed to Delete, selected entity is in use as a non nullable foreign key.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(Desc))
            {
                return false;
            }
            return true;
        }
    }
}
