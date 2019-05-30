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
    public class HResourcesController
    {
        public HResourcesMgr _projectMgr = new HResourcesMgr();

        [HttpGet]
        public List<HResourcesDTO> Get()
        {
            List<HResourcesDTO> data = _projectMgr.Get();
            return data;
        }

        [HttpPost]
        public int Post([FromBody] HResourcesDTO value)
        {
            int data = _projectMgr.Post(value);
            return data;
        }

        [HttpPut("{Pro_id}")]
        public int Put(int Pro_id, [FromBody]HResourcesDTO value)
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
