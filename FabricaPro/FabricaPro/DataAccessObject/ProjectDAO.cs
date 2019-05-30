using FabricaPro.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FabricaPro.DataAccessObject
{
    public class ProjectDAO
    {

       
        SqlConnection connection = new SqlConnection("Server=E-JAVELAZQUEZ;Database=FabricaPro;Trusted_Connection=True;");
        SqlCommand command;
        public ProjectDAO() 
        {

        }

        public List<ProjectDTO> GetProject()
        {
            List<ProjectDTO> lista = new List<ProjectDTO>();
            SqlDataReader rdr = execProc("Project_R");
            ProjectDTO obj;
            while (rdr.Read())    // En caso de que exista varios valores de retorno sin usar DataTable
            {
                obj = new ProjectDTO();
                obj.Pro_ID = rdr.GetInt32(rdr.GetOrdinal("Pro_ID"));
                obj.Name = rdr.GetString(rdr.GetOrdinal("Name"));
                obj.StartDate = rdr.GetDateTime(rdr.GetOrdinal("StartDate"));
                obj.EndDate = rdr.GetDateTime(rdr.GetOrdinal("EndDate"));
                obj.ProyectLeader = rdr.GetString(rdr.GetOrdinal("ProyectLeader"));
                
                lista.Add(obj);
            }
            connection.Close();
            return lista;
        }

        public ProjectDTO GetProjectByID(int id)
        {
            ProjectDTO project = null;
            command = new SqlCommand("Project_R_ByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            command.Parameters.AddWithValue("@Pro_ID", id);
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())    // En caso de que exista varios valores de retorno sin usar DataTable
            {
                project = new ProjectDTO();
                project.Pro_ID = rdr.GetInt32(rdr.GetOrdinal("Pro_ID"));
                project.Name = rdr.GetString(rdr.GetOrdinal("Name"));
                project.StartDate = rdr.GetDateTime(rdr.GetOrdinal("StartDate"));
                project.EndDate = rdr.GetDateTime(rdr.GetOrdinal("EndDate"));
                project.ProyectLeader = rdr.GetString(rdr.GetOrdinal("ProyectLeader"));
            }
            connection.Close();
            return project;
        }


        public int PostProject(ProjectDTO value)
        {
            ProjectDTO data = new ProjectDTO();
            command = new SqlCommand("Project_C", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            command.Parameters.AddWithValue("@Name", value.Name);
            command.Parameters.AddWithValue("@StartDate", value.StartDate);
            command.Parameters.AddWithValue("@EndDate", value.EndDate);
            command.Parameters.AddWithValue("@ProyectLeader", value.ProyectLeader);
            // command.Parameters.Clear();
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
            int Pro_ID=0;
            while (rdr.Read())    // En caso de que exista varios valores de retorno sin usar DataTable
            {
                Pro_ID = rdr.GetInt32(rdr.GetOrdinal("Pro_ID"));
            }
            connection.Close();
            return Pro_ID;
        }

        public int PutProject(int Pro_id, ProjectDTO value)
        {
            command = new SqlCommand("Project_U", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            command.Parameters.AddWithValue("@Pro_ID", Pro_id);
            command.Parameters.AddWithValue("@Name", value.Name);
            command.Parameters.AddWithValue("@StartDate", value.StartDate);
            command.Parameters.AddWithValue("@EndDate", value.EndDate);
            command.Parameters.AddWithValue("@ProyectLeader", value.ProyectLeader);
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
            int Pro_ID = 0;
            while (rdr.Read())    // En caso de que exista varios valores de retorno sin usar DataTable
            {
                Pro_ID = rdr.GetInt32(rdr.GetOrdinal("Pro_ID"));
            }
            connection.Close();
            return Pro_ID;
        }

        public int DeleteProject(int ID)
        {
            command = new SqlCommand("Project_D", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            command.Parameters.AddWithValue("@Pro_ID", ID);
            // command.Parameters.Clear();
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
            int Pro_ID = 0;
            while (rdr.Read())    // En caso de que exista varios valores de retorno sin usar DataTable
            {
                Pro_ID = rdr.GetInt32(rdr.GetOrdinal("Pro_ID"));
            }
            connection.Close();
            return Pro_ID;
        }


        public SqlDataReader execProc(string Proc)
        {
            command = new SqlCommand(Proc, connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            // command.Parameters.Clear();
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);// obtener resultados, termina la conexion cuaundo termina el lector de datos
            return rdr;
        }

        
    }

    

}
