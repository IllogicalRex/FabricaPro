using FabricaPro.DataAccessObject;
using FabricaPro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricaPro.DataObject
{
    public class HResourcesDO
    {
        public HResourcesDAO _projectDAO = new HResourcesDAO();

        // Metodo para Consultar GET
        public List<HResourcesDTO> Get()
        {
            return _projectDAO.GetHResources();
        }

        public int Post(HResourcesDTO value)
        {
            int data = _projectDAO.PostHResources(value);
            return data;
        }

        // Actualizar Proyecto
        public int Put(int Pro_id, HResourcesDTO value)
        {
            int data = _projectDAO.PutHResources(Pro_id, value);
            return data;
        }

        // Eliminar un Proyecto DELETE
        public int Delete(int Pro_ID)
        {
            int data = _projectDAO.DeleteResources(Pro_ID);
            return data;
        }
    }
}
