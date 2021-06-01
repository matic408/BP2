using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace UI.ViewModels
{
    public class AssignmentViewModel:ViewModelBase
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

        private ObservableCollection<Task> tasks;
        public ObservableCollection<Task> Tasks
        {
            get { return tasks; }
            set
            {
                tasks = value;
                OnPropertyChanged(nameof(Tasks));
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

        private Task selectedTask;
        public Task SelectedTask
        {
            get { return selectedTask; }
            set
            {
                selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
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


        private ObservableCollection<Assignment> data;
        public ObservableCollection<Assignment> Data
        {
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged(nameof(Data));
            }
        }

        private Assignment selectedAssignment;
        public Assignment SelectedAssignment
        {
            get { return selectedAssignment; }
            set
            {
                selectedAssignment = value;
                Visible = Visibility.Collapsed;
                Cleanup();
                IsSelected = true;
                OnPropertyChanged(nameof(SelectedAssignment));
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
            Data = new ObservableCollection<Assignment>(Service.Instance.GetAssignments());

        }

        public void Cleanup()
        {
            SelectedTeam = null;
            SelectedTask = null;
            IsSelected = false;
        }

        public AssignmentViewModel()
        {
            ShowAddCommand = new MyICommand(ShowAdd);
            ShowEditCommand = new MyICommand(ShowEdit);
            DeleteCommand = new MyICommand(Delete);
            AddCommand = new MyICommand(Add);
            EditCommand = new MyICommand(Edit);
            Tasks = new ObservableCollection<Task>(Service.Instance.GetTasks());
            Teams = new ObservableCollection<Team>(Service.Instance.GetTeams());
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
                SelectedTeam = SelectedAssignment.Team;
                SelectedTask = SelectedAssignment.Task;
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
                Service.Instance.AddAssignment(new Assignment { Task = SelectedTask, Team = SelectedTeam });
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
                Service.Instance.EditAssignment(SelectedAssignment.Id, new Assignment() { Id = SelectedAssignment.Id, Task = SelectedTask, Team = SelectedTeam });
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
                Service.Instance.DeleteAssignment(SelectedAssignment.Id);
                Refresh();
                Cleanup();
                Visible = Visibility.Collapsed;
            }
        }

        public bool Validate()
        {
            if (SelectedTask == null)
            {
                return false;
            }
            if (SelectedTeam == null)
            {
                return false;
            }
            return true;
        }
    }
}
