using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace UI.ViewModels
{
    public class TaskViewModel:ViewModelBase
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

        private ObservableCollection<Project> projects;
        public ObservableCollection<Project> Projects
        {
            get { return projects; }
            set
            {
                projects = value;
                OnPropertyChanged(nameof(Projects));
            }
        }

        private Project selectedProject;

        public Project SelectedProject
        {
            get { return selectedProject; }
            set
            {
                selectedProject = value;
                OnPropertyChanged(nameof(SelectedProject));
            }
        }

        private ObservableCollection<Task> data;
        public ObservableCollection<Task> Data
        {
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged(nameof(Data));
            }
        }

        private ObservableCollection<Task> superTasks;

        public ObservableCollection<Task> SuperTasks
        {
            get { return superTasks; }
            set
            {
                superTasks = value;
                OnPropertyChanged(nameof(SuperTasks));
            }
        }

        private Task selectedSuperTask;
        public Task SelectedSuperTask
        {
            get { return selectedSuperTask; }
            set
            {
                selectedSuperTask = value;
                OnPropertyChanged(nameof(SelectedSuperTask));
            }
        }

        private Task selectedTask;

        public Task SelectedTask
        {
            get { return selectedTask; }
            set
            {
                selectedTask = value;
                Visible = Visibility.Collapsed;
                Cleanup();
                SuperTasks.Remove(SuperTasks.FirstOrDefault(x => x.Id == value.Id));
                IsSelected = true;
                OnPropertyChanged(nameof(SelectedTask));
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
            Data = new ObservableCollection<Task>(Service.Instance.GetTasks());
        }

        public void Cleanup()
        {
            Desc = "";
            SelectedSuperTask = null;
            SelectedProject = null;
            IsSelected = false;
            SuperTasks = new ObservableCollection<Task>(Service.Instance.GetTasks());
        }

        public TaskViewModel()
        {
            ShowAddCommand = new MyICommand(ShowAdd);
            ShowEditCommand = new MyICommand(ShowEdit);
            DeleteCommand = new MyICommand(Delete);
            AddCommand = new MyICommand(Add);
            EditCommand = new MyICommand(Edit);
            SuperTasks = new ObservableCollection<Task>(Service.Instance.GetTasks());
            Projects = new ObservableCollection<Project>(Service.Instance.GetProjects());
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
                Desc = SelectedTask.Description;
                SelectedSuperTask = SelectedTask.SuperTask;
                SelectedProject = SelectedTask.Project;
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
                Service.Instance.AddTask(new Task { Description = Desc, SuperTask = SelectedSuperTask, Project = SelectedProject });
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
                Service.Instance.EditTask(SelectedTask.Id, new Task() { Id = SelectedTask.Id, SuperTask = SelectedSuperTask, Description = Desc });
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
                if (Service.Instance.DeleteTask(SelectedTask.Id))
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
            if (SelectedProject == null && ShowEditButton == Visibility.Collapsed)
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
