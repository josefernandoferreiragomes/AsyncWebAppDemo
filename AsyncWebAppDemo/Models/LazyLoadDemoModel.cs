using AsyncWebAppDemo.Repositories;

namespace AsyncWebAppDemo.Models
{
    public class LazyLoadDemoModel
    {
        public int RecordsPerPage = 20;
        public int PageNum { get; set; }
        private List<Project> _projectList;

        public List<Project> ProjectList 
        {
            get
            {
                if (_projectList == null)
                {
                    var projectRep = new ProjectRepository();
                    var projectData = projectRep.GetProjectList();

                    int from = (PageNum * RecordsPerPage);

                    _projectList = (from rec in projectData
                                    select rec).Skip(from).Take(20).ToList<Project>();
                }
                return _projectList;
            }
        }
    }  

}