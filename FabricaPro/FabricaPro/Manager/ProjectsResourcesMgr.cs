using FabricaPro.DataObject;
using FabricaPro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricaPro.Manager
{
    
    public class ProjectsResourcesMgr
    {
        public ProjectsResourcesDO _projectResource = new ProjectsResourcesDO();


        public List<ProjectResourcesDTO> GetHProjectResources()
        {
            List<ProjectResourcesDTO> data = _projectResource.GetHProjectResources();
            return data;
        }

        public List<ProjectDTO> GetProjectWithoutResourcesAll()
        {
            List<ProjectDTO> data = _projectResource.GetProjectWithoutResourcesAll();
            return data;
        }

        public List<ProjectDTO> GetProjectWithoutResources(int currentPage, int sizeData)
        {
            List<ProjectDTO> data = _projectResource.GetProjectWithoutResources(currentPage, sizeData);
            return data;
        }

        public List<HResourcesDTO> GetResourcesWithoutProjectsAll()
        {
            List<HResourcesDTO> data = _projectResource.GetResourcesWithoutProjectsAll();
            return data;
        }

        public List<HResourcesDTO> GetResourcesWithoutProjects(int currentPage, int sizeData)
        {
            List<HResourcesDTO> data = _projectResource.GetResourcesWithoutProjects(currentPage, sizeData);
            return data;
        }

        public ProjectResourcesDTO PostAsignProRec(ProjectResourcesDTO value)
        {
            ProjectResourcesDTO data = _projectResource.PostAsignProRec(value);
            return data;
        }

        public ProjectResourcesDTO DeleteDesProRec(int pro_ID, int rec_ID)
        {
            ProjectResourcesDTO data = _projectResource.DeleteDesProRec(pro_ID, rec_ID);
            return data;
        }
    }
}
