using FabricaPro.DataAccessObject;
using FabricaPro.DTO;
using FabricaPro.Manager;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricaPro.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController: ControllerBase
    {
        public ProjectMgr _projectMgr = new ProjectMgr();

        //[EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<ProjectDTO> Get()
        {
            List<ProjectDTO> data = _projectMgr.Get();
            return data;
        }

        [HttpGet("{id}")]
        public ProjectDTO GetByID(int id)
        {
            ProjectDTO data = _projectMgr.GetByID(id);
            return data;
        }

        [HttpPost]
        public int Post([FromBody] ProjectDTO value)
        {
            int data = _projectMgr.Post(value);
            return data;
        }

        [HttpPut("{Pro_id}")]
        public int Put(int Pro_id, [FromBody]ProjectDTO value)
        {
            int data = _projectMgr.Put(Pro_id, value);
            return data;
        }

        [HttpDelete("{Pro_ID}")]
        public int Delete(int Pro_ID)
        {
            int data = _projectMgr.Delete(Pro_ID);
            return data;
        }

    }
}
