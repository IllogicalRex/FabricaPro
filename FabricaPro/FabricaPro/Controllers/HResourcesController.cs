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
    public class HResourcesController: ControllerBase
    {
        public HResourcesMgr _resourcetMgr = new HResourcesMgr();

        [Route("all")]
        [HttpGet]
        public List<HResourcesDTO> GetHResourcesAll()
        {
            List<HResourcesDTO> data = _resourcetMgr.GetHResourcesAll();
            return data;
        }

        [HttpGet]
        public List<HResourcesDTO> GetHResources(int currentPage, int sizeData)
        {
            List<HResourcesDTO> data = _resourcetMgr.GetHResources(currentPage, sizeData);
            return data;
        }

        [HttpGet("{id}")]
        public HResourcesDTO GetResourceByID(int id)
        {
            HResourcesDTO data = _resourcetMgr.GetResourceByID(id);
            return data;
        }

        [HttpPost]
        public int Post([FromBody] HResourcesDTO value)
        {
            int data = _resourcetMgr.Post(value);
            return data;
        }

        [HttpPut("{Pro_id}")]
        public int Put(int Pro_id, [FromBody]HResourcesDTO value)
        {
            int data = _resourcetMgr.Put(Pro_id, value);
            return data;
        }

        [HttpDelete("{Pro_ID}")]
        public int Delete(int Pro_ID)
        {
            int data = _resourcetMgr.Delete(Pro_ID);
            return data;
        }
    }
}
