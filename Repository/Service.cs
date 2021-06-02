using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Service
    {
        private static Service instance = null;
        public ModelContainer db;

        private Service()
        {
            db = new ModelContainer();
        }

        public static Service Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Service();
                }
                return instance;
            }
        }

        public void AddClient(Client x)
        {
            db.Clients.Add(x);
            db.SaveChanges();
        }

        public List<Client> GetClients()
        {
            return db.Clients.ToList();
        }

        public Client GetClient(int id)
        {
            return db.Clients.FirstOrDefault(x => x.Id == id);
        }

        public void EditClient(int id, Client temp)
        {
            db.Clients.FirstOrDefault(x => x.Id == id).Name = temp.Name;
            db.SaveChanges();
        }

        public bool DeleteClient(int id)
        {
            if (db.DealsWiths.FirstOrDefault(x => x.Client.Id == id) == null)
            {
                db.Clients.Remove(db.Clients.FirstOrDefault(x => x.Id == id));
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddCompany(Company x)
        {
            db.Companies.Add(x);
            db.SaveChanges();
        }

        public List<Company> GetCompanies()
        {
            return db.Companies.ToList();
        }

        public Company GetCompany(int id)
        {
            return db.Companies.FirstOrDefault(x => x.Id == id);
        }
        
        public void EditCompany(int id, Company temp)
        {
            db.Companies.FirstOrDefault(x => x.Id == id).Name = temp.Name;
            db.SaveChanges();
        }

        public bool DeleteCompany(int id)
        {
            if(db.DealsWiths.FirstOrDefault(x=>x.Company.Id == id) == null && db.Employees.FirstOrDefault(x=>x.Company.Id == id) == null && db.Assets.FirstOrDefault(x=>x.Company.Id == id) == null)
            {
                db.Companies.Remove(db.Companies.FirstOrDefault(x => x.Id == id));
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }           
        }

        public void AddDeal(DealsWith x)
        {
            db.DealsWiths.Add(x);
            db.SaveChanges();
        }

        public List<DealsWith> GetDeals()
        {
            return db.DealsWiths.ToList();
        }

        public DealsWith GetDeal(int id)
        {
            return db.DealsWiths.FirstOrDefault(x => x.Id == id);
        }

        public void EditDeal(int id, DealsWith temp)
        {
            db.DealsWiths.FirstOrDefault(x => x.Id == id).Date = temp.Date;
            db.DealsWiths.FirstOrDefault(x => x.Id == id).Client = temp.Client;
            db.DealsWiths.FirstOrDefault(x => x.Id == id).Company = temp.Company;
            db.SaveChanges();
        }

        public void DeleteDeal(int id)
        {
            db.DealsWiths.Remove(db.DealsWiths.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
        }

        public void AddContract(Contract x)
        {
            db.Contracts.Add(x);
            db.SaveChanges();
        }

        public List<Contract> GetContracts()
        {
            return db.Contracts.ToList();
        }

        public Contract GetContract(int id)
        {
            return db.Contracts.FirstOrDefault(x => x.Id == id);
        }

        public void EditContract(int id, Contract temp)
        {
            db.Contracts.FirstOrDefault(x => x.Id == id).DealsWith = temp.DealsWith;
            db.Contracts.FirstOrDefault(x => x.Id == id).DateSigned = temp.DateSigned;
            db.Contracts.FirstOrDefault(x => x.Id == id).Content = temp.Content;
            db.SaveChanges();
        }

        public void DeleteContract(int id)
        {
            db.Contracts.Remove(db.Contracts.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
        }

        public void AddProject(Project x)
        {
            db.Projects.Add(x);
            db.SaveChanges();
        }

        public List<Project> GetProjects()
        {
            return db.Projects.ToList();
        }

        public Project GetProject(int id)
        {
            return db.Projects.FirstOrDefault(x => x.Id == id);
        }

        public void EditProject(int id, Project temp)
        {
            db.Projects.FirstOrDefault(x => x.Id == id).Contract = temp.Contract;
            db.Projects.FirstOrDefault(x => x.Id == id).Description = temp.Description;
            db.Projects.FirstOrDefault(x => x.Id == id).Manager = temp.Manager;
            db.Projects.FirstOrDefault(x => x.Id == id).Name = temp.Name;
            db.SaveChanges();
        }

        public bool DeleteProject(int id)
        {
            if (db.Tasks.FirstOrDefault(x => x.Project.Id == id) == null)
            {
                db.Projects.Remove(db.Projects.FirstOrDefault(x => x.Id == id));
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddTask(Task x)
        {
            db.Tasks.Add(x);
            db.SaveChanges();
        }

        public List<Task> GetTasks()
        {
            return db.Tasks.ToList();
        }

        public Task GetTask(int id)
        {
            return db.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public void EditTask(int id, Task temp)
        {
            db.Tasks.FirstOrDefault(x => x.Id == id).Description = temp.Description;
            db.Tasks.FirstOrDefault(x => x.Id == id).SuperTask = temp.SuperTask;
            db.SaveChanges();
        }

        public bool DeleteTask(int id)
        {
            //if(db.Assignments.FirstOrDefault(x=>x.Task.Id == id) == null)
            //{
            //    db.Tasks.Remove(db.Tasks.FirstOrDefault(x => x.Id == id));
            //    db.SaveChanges();
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            db.Tasks.Remove(db.Tasks.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
            return true;
        }

        public bool AddAssignment(Assignment x)
        {
            foreach(Assignment y in db.Assignments)
            {
                if(y.Team.Id == x.Team.Id && y.Task.Id == x.Task.Id)
                {
                    return false;
                }
            }
            db.Assignments.Add(x);
            db.SaveChanges();
            return true;
        }

        public List<Assignment> GetAssignments()
        {
            return db.Assignments.ToList();
        }

        public void DeleteAssignment(Team team, Task task)
        {
            db.Assignments.Remove(db.Assignments.FirstOrDefault(x => x.Team.Id == team.Id && x.Task.Id == task.Id));
            db.SaveChanges();
        }

        public void AddTeam(Team x)
        {
            db.Teams.Add(x);
            db.SaveChanges();
        }

        public List<Team> GetTeams()
        {
            return db.Teams.ToList();
        }

        public Team GetTeam(int id)
        {
            return db.Teams.FirstOrDefault(x => x.Id == id);
        }

        public void EditTeam(int id, Team temp)
        {
            db.Teams.FirstOrDefault(x => x.Id == id).Name = temp.Name;
            db.SaveChanges();
        }

        public bool DeleteTeam(int id)
        {
            if(db.Assignments.FirstOrDefault(x=>x.Team.Id == id) == null && db.TeamProficiencies.FirstOrDefault(x =>x.Team.Id == id) == null)
            {
                db.Teams.Remove(db.Teams.FirstOrDefault(x => x.Id == id));
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddTeamProficiency(TeamProficiency x)
        {
            if(db.TeamProficiencies.FirstOrDefault(y=>y.Proficiency.Id == x.Proficiency.Id && y.Team.Id == x.Team.Id) == null)
            {
                db.TeamProficiencies.Add(x);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<TeamProficiency> GetTeamProficiencies()
        {
            return db.TeamProficiencies.ToList();
        }

        public void DeleteTeamProficiency(Team team, Proficiency proficiency)
        {
            db.TeamProficiencies.Remove(db.TeamProficiencies.FirstOrDefault(x => x.Team.Id == team.Id && x.Proficiency.Id == proficiency.Id));
            db.SaveChanges();
        }

        public void AddProficiency(Proficiency x)
        {
            db.Proficiencies.Add(x);
            db.SaveChanges();
        }

        public List<Proficiency> GetProficiencies()
        {
            return db.Proficiencies.ToList();
        }

        public Proficiency GetProficiency(int id)
        {
            return db.Proficiencies.FirstOrDefault(x => x.Id == id);
        }

        public void EditProficiency(int id, Proficiency temp)
        {
            db.Proficiencies.FirstOrDefault(x => x.Id == id).Name = temp.Name;
            db.SaveChanges();
        }

        public bool DeleteProficiency(int id)
        {
            if(db.TeamProficiencies.FirstOrDefault(x=>x.Proficiency.Id == id) == null)
            {
                db.Proficiencies.Remove(db.Proficiencies.FirstOrDefault(x => x.Id == id));
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddManager(Manager x)
        {
            db.Employees.Add(x);
            db.SaveChanges();
        }

        public void AddDeveloper(Developer x)
        {
            db.Employees.Add(x);
            db.SaveChanges();
        }

        public void AddSupplier(Supplier x)
        {
            db.Employees.Add(x);
            db.SaveChanges();
        }

        public List<Manager> GetManagers()
        {
            List<Manager> temp = new List<Manager>();
            foreach(Employee e in db.Employees)
            {
                if(e is Manager)
                {
                    temp.Add(e as Manager);
                }
            }
            return temp;
        }

        public List<Developer> GetDevelopers()
        {
            List<Developer> temp = new List<Developer>();
            foreach (Employee e in db.Employees)
            {
                if (e is Developer)
                {
                    temp.Add(e as Developer);
                }
            }
            return temp;
        }

        public List<Supplier> GetSuppliers()
        {
            List<Supplier> temp = new List<Supplier>();
            foreach (Employee e in db.Employees)
            {
                if (e is Supplier)
                {
                    temp.Add(e as Supplier);
                }
            }
            return temp;
        }

        public List<Employee> GetEmployees()
        {
            return db.Employees.ToList();
        }

        public Employee GetEmployee(int id)
        {
            return db.Employees.FirstOrDefault(x => x.Id == id);
        }

        public void EditManager(int id, Manager temp)
        {
            //db.Employees.FirstOrDefault(x => x.Id == id).Company = temp.Company;
            db.Employees.FirstOrDefault(x => x.Id == id).DOB = temp.DOB;
            db.Employees.FirstOrDefault(x => x.Id == id).Gender = temp.Gender;
            db.Employees.FirstOrDefault(x => x.Id == id).Name = temp.Name;
            db.SaveChanges();
        }

        public void EditSupplier(int id, Supplier temp)
        {
            //db.Employees.FirstOrDefault(x => x.Id == id).Company = temp.Company;
            db.Employees.FirstOrDefault(x => x.Id == id).DOB = temp.DOB;
            db.Employees.FirstOrDefault(x => x.Id == id).Gender = temp.Gender;
            db.Employees.FirstOrDefault(x => x.Id == id).Name = temp.Name;
            db.SaveChanges();
        }

        public void EditDeveloper(int id, Developer temp)
        {
            //db.Employees.FirstOrDefault(x => x.Id == id).Company = temp.Company;
            db.Employees.FirstOrDefault(x => x.Id == id).DOB = temp.DOB;
            db.Employees.FirstOrDefault(x => x.Id == id).Gender = temp.Gender;
            db.Employees.FirstOrDefault(x => x.Id == id).Name = temp.Name;
            (db.Employees.FirstOrDefault(x => x.Id == id)as Developer).Team = temp.Team;
            db.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            db.Employees.Remove(db.Employees.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
        }

        public void AddAsset(Asset x)
        {
            db.Assets.Add(x);
            db.SaveChanges();
        }
        public List<Asset> GetAssets()
        {
            return db.Assets.ToList();
        }
        public Asset GetAsset(int id)
        {
            return db.Assets.FirstOrDefault(x => x.Id == id);
        }
        public void EditAsset(int id, Asset temp)
        {
            db.Assets.FirstOrDefault(x => x.Id == id).Name = temp.Name;
            db.Assets.FirstOrDefault(x => x.Id == id).Supplier = temp.Supplier;
            db.SaveChanges();
        }
        public void DeleteAsset(int id)
        {
            db.Assets.Remove(db.Assets.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
        }
    }
}
