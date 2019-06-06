using FabricaPro.DTO;
using FabricaPro.Manager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricaPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsResourcesController : ControllerBase
    {

        public ProjectsResourcesMgr _projectResource = new ProjectsResourcesMgr();

        [HttpGet]
        public List<ProjectResourcesDTO> GetHProjectResources()
        {
            List<ProjectResourcesDTO> data = _projectResource.GetHProjectResources();
            return data;
        }

        [Route("allwor")]
        [HttpGet]
        public List<ProjectDTO> GetProjectWithoutResourcesAll()
        {
            List<ProjectDTO> data = _projectResource.GetProjectWithoutResourcesAll();
            return data;
        }

        [Route("withoutrec")]
        [HttpGet]
        public List<ProjectDTO> GetProjectWithoutResources(int currentPage, int sizeData)
        {
            List<ProjectDTO> data = _projectResource.GetProjectWithoutResources(currentPage, sizeData);
            return data;
        }

        [Route("allwop")]
        [HttpGet]
        public List<HResourcesDTO> GetResourcesWithoutProjectsAll()
        {
            List<HResourcesDTO> data = _projectResource.GetResourcesWithoutProjectsAll();
            return data;
        }

        [Route("withoutpro")]
        [HttpGet]
        public List<HResourcesDTO> GetResourcesWithoutPro(int currentPage, int sizeData)
        {
            List<HResourcesDTO> data = _projectResource.GetResourcesWithoutProjects(currentPage, sizeData);
            return data;
        }

        [HttpPost]
        public ProjectResourcesDTO PostAsignProRec(ProjectResourcesDTO value)
        {
            ProjectResourcesDTO data = _projectResource.PostAsignProRec(value);
            return data;
        }

        [HttpDelete]
        public ProjectResourcesDTO DeleteDesProRec(int pro_ID, int rec_ID)
        {
            ProjectResourcesDTO data = _projectResource.DeleteDesProRec(pro_ID, rec_ID);
            return data;
        }
    }
}
