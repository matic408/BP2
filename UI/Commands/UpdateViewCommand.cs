using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ViewModels;

namespace UI.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Home")
            {
                viewModel.CurrentViewModel = new HomeViewModel();
            }
            else if (parameter.ToString() == "Client")
            {
                viewModel.CurrentViewModel = new ClientViewModel();
            }
            else if (parameter.ToString() == "Company")
            {
                viewModel.CurrentViewModel = new CompanyViewModel();
            }
            else if (parameter.ToString() == "Deal")
            {
                viewModel.CurrentViewModel = new DealViewModel();
            }
            else if(parameter.ToString() == "Contract")
            {
                viewModel.CurrentViewModel = new ContractViewModel();
            }
            else if(parameter.ToString() == "Project")
            {
                viewModel.CurrentViewModel = new ProjectViewModel();
            }
            else if(parameter.ToString() == "Employee")
            {
                viewModel.CurrentViewModel = new EmployeeViewModel();
            }
            else if(parameter.ToString() == "Team")
            {
                viewModel.CurrentViewModel = new TeamViewModel();
            }
            else if(parameter.ToString() == "Task")
            {
                viewModel.CurrentViewModel = new TaskViewModel();
            }
            else if(parameter.ToString() == "Assignment")
            {
                viewModel.CurrentViewModel = new AssignmentViewModel();
            }
            else if(parameter.ToString() == "Proficiency")
            {
                viewModel.CurrentViewModel = new ProficiencyViewModel();
            }
            else if(parameter.ToString() == "TeamProficiency")
            {
                viewModel.CurrentViewModel = new TeamProficiencyViewModel();
            }
            else if(parameter.ToString() == "Asset")
            {
                viewModel.CurrentViewModel = new AssetViewModel();
            }
        }
    }
}
