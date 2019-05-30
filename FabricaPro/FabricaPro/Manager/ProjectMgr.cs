﻿using FabricaPro.DataObject;
using FabricaPro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricaPro.Manager
{
    public class ProjectMgr
    {
        public ProjectDO _projectDO = new ProjectDO();

        // Metodo para Consultar GET
        public List<ProjectDTO> Get()
        {
            return _projectDO.Get();
        }

        public ProjectDTO GetByID(int id)
        {
            ProjectDTO project = _projectDO.GetByID(id);
            return project;
        }

        public int Post(ProjectDTO value)
        {
            int data = _projectDO.Post(value);
            return data;
        }
        
        // Actualizar Proyecto
        public int Put(int Pro_id, ProjectDTO value)
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
