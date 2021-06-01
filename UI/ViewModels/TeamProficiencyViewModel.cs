using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace UI.ViewModels
{
    public class TeamProficiencyViewModel:ViewModelBase
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

        private ObservableCollection<Proficiency> proficiencies;
        public ObservableCollection<Proficiency> Proficiencies
        {
            get { return proficiencies; }
            set
            {
                proficiencies = value;
                OnPropertyChanged(nameof(Proficiencies));
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

        private Proficiency selectedProficiency;
        public Proficiency SelectedProficiency
        {
            get { return selectedProficiency; }
            set
            {
                selectedProficiency = value;
                OnPropertyChanged(nameof(SelectedProficiency));
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


        private ObservableCollection<TeamProficiency> data;
        public ObservableCollection<TeamProficiency> Data
        {
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged(nameof(Data));
            }
        }

        private TeamProficiency selectedTeamProficiency;
        public TeamProficiency SelectedTeamProficiency
        {
            get { return selectedTeamProficiency; }
            set
            {
                selectedTeamProficiency = value;
                Visible = Visibility.Collapsed;
                Cleanup();
                IsSelected = true;
                OnPropertyChanged(nameof(SelectedTeamProficiency));
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
        public MyICommand DeleteCommand { get; set; }
        public MyICommand ShowAddCommand { get; set; }
        public MyICommand ShowEditCommand { get; set; }

        public void Refresh()
        {
            Data = new ObservableCollection<TeamProficiency>(Service.Instance.GetTeamProficiencies());

        }

        public void Cleanup()
        {
            SelectedTeam = null;
            SelectedProficiency = null;
            IsSelected = false;
        }

        public TeamProficiencyViewModel()
        {
            ShowAddCommand = new MyICommand(ShowAdd);
            DeleteCommand = new MyICommand(Delete);
            AddCommand = new MyICommand(Add);
            Proficiencies = new ObservableCollection<Proficiency>(Service.Instance.GetProficiencies());
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
                SelectedTeam = SelectedTeamProficiency.Team;
                SelectedProficiency = SelectedTeamProficiency.Proficiency;
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
                if(Service.Instance.AddTeamProficiency(new TeamProficiency { Proficiency = SelectedProficiency, Team = SelectedTeam }))
                {
                    Refresh();
                    Cleanup();
                    Visible = Visibility.Collapsed;
                }
                else
                {
                    MessageBox.Show("Key must be Unique.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
                Service.Instance.DeleteTeamProficiency(SelectedTeamProficiency.Team, SelectedTeamProficiency.Proficiency);
                Refresh();
                Cleanup();
                Visible = Visibility.Collapsed;
            }
        }

        public bool Validate()
        {
            if (SelectedProficiency == null)
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
