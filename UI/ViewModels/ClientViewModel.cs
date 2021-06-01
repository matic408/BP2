using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UI.Commands;

namespace UI.ViewModels
{
    public class ClientViewModel:ViewModelBase
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
        private ObservableCollection<Client> data;
        public ObservableCollection<Client> Data
        {
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged(nameof(Data));
            }
        }

        private Client selectedClient;
        public Client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                Visible = Visibility.Collapsed;
                Cleanup();
                IsSelected = true;
                OnPropertyChanged(nameof(SelectedClient));
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
            Data = new ObservableCollection<Client>(Service.Instance.GetClients());
        }

        public void Cleanup()
        {
            Name = "";
            IsSelected = false;
        }

        public ClientViewModel()
        {
            ShowAddCommand = new MyICommand(ShowAdd);
            ShowEditCommand = new MyICommand(ShowEdit);
            DeleteCommand = new MyICommand(Delete);
            AddCommand = new MyICommand(Add);
            EditCommand = new MyICommand(Edit); 
            Cleanup();
            Visible = Visibility.Collapsed;
            Refresh();
        }

        public void ShowAdd()
        {   
            if(Visible == Visibility.Collapsed)
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
                Name = SelectedClient.Name;
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
                Service.Instance.AddClient(new Client { Name = Name });
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
                Service.Instance.EditClient(SelectedClient.Id, new Client() { Id = SelectedClient.Id, Name = Name });
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
            if (MessageBox.Show("Are you sure?","Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                if(Service.Instance.DeleteClient(SelectedClient.Id))
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
            if (String.IsNullOrWhiteSpace(Name))
            {
                return false;
            }

            return true;
        }
    }
}
