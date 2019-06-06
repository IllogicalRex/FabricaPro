using FabricaPro.DataObject;
using FabricaPro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricaPro.Manager
{

    public class HResourcesMgr
    {
        public HResourcesDO _ResourcetDO = new HResourcesDO();

        // Metodo para Consultar GET
        public List<HResourcesDTO> GetHResourcesAll()
        {
            return _ResourcetDO.GetHResourcesAll();
        }

        public List<HResourcesDTO> GetHResources(int currentPage, int sizeData)
        {
            return _ResourcetDO.GetHResources(currentPage, sizeData);
        }

        public HResourcesDTO GetResourceByID(int id)
        {
            HResourcesDTO data = _ResourcetDO.GetResourceByID(id);
            return data;
        }

        public int Post(HResourcesDTO value)
        {
            int data = _ResourcetDO.Post(value);
            return data;
        }

        // Actualizar Proyecto
        public int Put(int Pro_id, HResourcesDTO value)
        {
            int data = _ResourcetDO.Put(Pro_id, value);
            return data;
        }

        // Eliminar un Proyecto DELETE
        public int Delete(int Pro_ID)
        {
            int data = _ResourcetDO.Delete(Pro_ID);
            return data;
        }
    }
}
