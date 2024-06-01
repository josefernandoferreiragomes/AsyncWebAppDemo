using AsyncWebAppDemo.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AsyncWebAppDemo.Models
{
    public class LazyLoadComboDemoModel
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

        public int ProjectID { get; set; }
        private List<SelectListItem> _projectSelectList;
        public List<SelectListItem> ProjectSelectList 
        { 
            get
            {
                if(_projectSelectList == null)
                {
                    _projectSelectList = new List<SelectListItem>();
                    foreach ( var item in this.ProjectList)
                    {
                        
                        _projectSelectList.Add(new SelectListItem()
                        {
                            Value = item.ID.ToString(),
                            Text = item.Name,
                        });
                    }
                }
                return _projectSelectList;
            }
        }
    }  

}