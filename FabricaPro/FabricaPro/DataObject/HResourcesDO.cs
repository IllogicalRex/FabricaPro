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
        public HResourcesDAO _resourcetDAO = new HResourcesDAO();

        // Metodo para Consultar GET
        public List<HResourcesDTO> GetHResourcesAll()
        {
            return _resourcetDAO.GetHResourcesAll();
        }

        public List<HResourcesDTO> GetHResources(int currentPage, int sizeData)
        {
            return _resourcetDAO.GetHResources(currentPage, sizeData);
        }

        public HResourcesDTO GetResourceByID(int id)
        {
            HResourcesDTO data = _resourcetDAO.GetResourceByID(id);
            return data;
        }

            public int Post(HResourcesDTO value)
        {
            int data = _resourcetDAO.PostHResources(value);
            return data;
        }

        // Actualizar Proyecto
        public int Put(int Pro_id, HResourcesDTO value)
        {
            int data = _resourcetDAO.PutHResources(Pro_id, value);
            return data;
        }

        // Eliminar un Proyecto DELETE
        public int Delete(int Pro_ID)
        {
            int data = _resourcetDAO.DeleteResources(Pro_ID);
            return data;
        }
    }
}
