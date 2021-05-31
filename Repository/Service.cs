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

        public void DeleteClient(int id)
        {
            db.Clients.Remove(db.Clients.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
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

        public void DeleteCompany(int id)
        {
            db.Companies.Remove(db.Companies.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
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

        public void DeleteProject(int id)
        {
            db.Projects.Remove(db.Projects.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
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
            db.Tasks.FirstOrDefault(x => x.Id == id).Project = temp.Project;
            db.Tasks.FirstOrDefault(x => x.Id == id).SuperTask = temp.SuperTask;
            db.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            db.Tasks.Remove(db.Tasks.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
        }

        public void AddAssignment(Assignment x)
        {
            db.Assignments.Add(x);
            db.SaveChanges();
        }

        public List<Assignment> GetAssignments()
        {
            return db.Assignments.ToList();
        }

        public Assignment GetAssignment(int id)
        {
            return db.Assignments.FirstOrDefault(x => x.Id == id);
        }

        public void EditAssignment(int id, Assignment temp)
        {
            db.Assignments.FirstOrDefault(x => x.Id == id).Task = temp.Task;
            db.Assignments.FirstOrDefault(x => x.Id == id).Team = temp.Team;
            db.SaveChanges();
        }

        public void DeleteAssignment(int id)
        {
            db.Assignments.Remove(db.Assignments.FirstOrDefault(x => x.Id == id));
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

        public void DeleteTeam(int id)
        {
            db.Teams.Remove(db.Teams.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
        }

        public void AddTeamProficiency(TeamProficiency x)
        {
            db.TeamProficiencies.Add(x);
            db.SaveChanges();
        }

        public List<TeamProficiency> GetTeamProficiencies()
        {
            return db.TeamProficiencies.ToList();
        }

        public TeamProficiency GetTeamProficiency(int id)
        {
            return db.TeamProficiencies.FirstOrDefault(x => x.Id == id);
        }

        public void EditTeamProficiency(int id, TeamProficiency temp)
        {
            db.TeamProficiencies.FirstOrDefault(x => x.Id == id).Team = temp.Team;
            db.TeamProficiencies.FirstOrDefault(x => x.Id == id).Proficiency = temp.Proficiency;
            db.SaveChanges();
        }

        public void DeleteTeamProficiency(int id)
        {
            db.TeamProficiencies.Remove(db.TeamProficiencies.FirstOrDefault(x => x.Id == id));
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

        public void DeleteProficiency(int id)
        {
            db.Proficiencies.Remove(db.Proficiencies.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
        }

        //public void AddDeveloper(Developer x)
        //{
        //    db.Employees.Add(x);
        //    db.SaveChanges();
        //}

        //public List<Team> GetTeams()
        //{
        //    return db.Teams.ToList();
        //}

        //public Team GetTeam(int id)
        //{
        //    return db.Teams.FirstOrDefault(x => x.Id == id);
        //}

        //public void EditTeam(int id, Team temp)
        //{
        //    db.Teams.FirstOrDefault(x => x.Id == id).Name = temp.Name;
        //    db.SaveChanges();
        //}

        //public void DeleteTeam(int id)
        //{
        //    db.Teams.Remove(db.Teams.FirstOrDefault(x => x.Id == id));
        //    db.SaveChanges();
        //}
    }
}
