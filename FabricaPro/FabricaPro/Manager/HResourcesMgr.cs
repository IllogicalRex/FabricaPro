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
        public HResourcesDO _projectDO = new HResourcesDO();

        // Metodo para Consultar GET
        public List<HResourcesDTO> Get()
        {
            return _projectDO.Get();
        }

        public int Post(HResourcesDTO value)
        {
            int data = _projectDO.Post(value);
            return data;
        }

        // Actualizar Proyecto
        public int Put(int Pro_id, HResourcesDTO value)
        {
            int data = _projectDO.Put(Pro_id, value);
            return data;
        }

        // Eliminar un Proyecto DELETE
        public int Delete(int Pro_ID)
        {
            int data = _projectDO.Delete(Pro_ID);
            return data;
        }
    }
}
