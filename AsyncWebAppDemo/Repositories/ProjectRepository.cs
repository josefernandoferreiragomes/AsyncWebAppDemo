using AsyncWebAppDemo.Models;
using Microsoft.Extensions.Hosting.Internal;

namespace AsyncWebAppDemo.Repositories
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public string Email { get; set; }
    }
    public class ProjectRepository
    {
        public ProjectRepository()
        {

        }
   
        public List<Project> GetProjectList()
        {
            
            List<Project> tempList = new List<Project>();

            for(int  i = 0; i < 10000; i++)
            {
                tempList.Add(new Project()
                {
                    ID = i,
                    Name = $"name of Project {i}",
                    ManagerName = $"manager name of Project {i}",
                    Email = $"email of Manager {i}",
                });
            }

            return tempList;
        }
    }
}
