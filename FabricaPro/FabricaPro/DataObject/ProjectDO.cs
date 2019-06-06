using FabricaPro.DataAccessObject;
using FabricaPro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FabricaPro.DataObject
{
    
    public class ProjectDO
    {
        public ProjectDAO _projectDAO = new ProjectDAO();

        public List<ProjectDTO> GetAll()
        {
            return _projectDAO.GetAll();
        }

        public List<ProjectDTO> Get(int currentPage, int sizeData)
        {
            return _projectDAO.GetProject(currentPage, sizeData);
        }

        public List<ProjectDTO> GetProjectByFilter(ProjectDTO filter)
        {
            List<ProjectDTO> data = _projectDAO.GetProjectByFilter(filter);
            return data;
        }

        public ProjectDTO GetByID(int id)
        {
            ProjectDTO project = _projectDAO.GetProjectByID(id);
            return project;
        }

            public int Post(ProjectDTO value)
        {
            int data = _projectDAO.PostProject(value);
            return data;
        }

        // Actualizar Proyecto
        public int Put(int Pro_id, ProjectDTO value)
        {
            int data = _projectDAO.PutProject(Pro_id, value);
            return data;
        }

        // Eliminar un Proyecto DELETE
        public int Delete(int Pro_ID)
        {
            int data = _projectDAO.DeleteProject(Pro_ID);
            return data;
        }

    }
}
