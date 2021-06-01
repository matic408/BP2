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
    public class AssetViewModel:ViewModelBase
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

        private ObservableCollection<Asset> data;
        public ObservableCollection<Asset> Data
        {
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged(nameof(Data));
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

        private Supplier selectedSupplier;
        public Supplier SelectedSupplier
        {
            get { return selectedSupplier; }
            set { selectedSupplier = value; OnPropertyChanged(nameof(SelectedSupplier)); }
        }

        private ObservableCollection<Supplier> suppliers;
        public ObservableCollection<Supplier> Suppliers
        {
            get { return suppliers; }
            set { suppliers = value; OnPropertyChanged(nameof(Suppliers)); }
        }

        private Asset selectedAsset;

        public Asset SelectedAsset
        {
            get { return selectedAsset; }
            set
            {
                selectedAsset = value;
                Visible = Visibility.Collapsed;
                Cleanup();
                IsSelected = true;
                OnPropertyChanged(nameof(SelectedAsset));
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
            Data = new ObservableCollection<Asset>(Service.Instance.GetAssets());
        }

        public void Cleanup()
        {
            Name = "";
            SelectedCompany = null;
            IsSelected = false;
        }

        public AssetViewModel()
        {
            ShowAddCommand = new MyICommand(ShowAdd);
            ShowEditCommand = new MyICommand(ShowEdit);
            DeleteCommand = new MyICommand(Delete);
            AddCommand = new MyICommand(Add);
            EditCommand = new MyICommand(Edit);
            Companies = new ObservableCollection<Company>(Service.Instance.GetCompanies());
            Suppliers = new ObservableCollection<Supplier>(Service.Instance.GetSuppliers());
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
                Name = SelectedAsset.Name;
                SelectedCompany = SelectedAsset.Company;
                SelectedSupplier = SelectedAsset.Supplier;
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
                Service.Instance.AddAsset(new Asset { Name = Name, Company = SelectedCompany, Supplier = SelectedSupplier });
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
                Service.Instance.EditAsset(SelectedAsset.Id, new Asset() { Id = SelectedAsset.Id, Name = Name, Supplier = SelectedSupplier });
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
                Service.Instance.DeleteAsset(SelectedAsset.Id);
                Refresh();
                Cleanup();
                Visible = Visibility.Collapsed;
            }
        }

        public bool Validate()
        {
            if (SelectedSupplier == null)
            {
                return false;
            }
            if(SelectedCompany == null && ShowEditButton == Visibility.Collapsed)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(Name))
            {
                return false;
            }
            return true;
        }
    }
}
