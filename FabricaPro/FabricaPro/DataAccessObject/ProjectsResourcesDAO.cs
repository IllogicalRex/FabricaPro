using FabricaPro.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FabricaPro.DataAccessObject
{
    public class ProjectsResourcesDAO
    {
        SqlConnection connection = new SqlConnection("Server=E-JAVELAZQUEZ;Database=FabricaPro;Trusted_Connection=True;");
        SqlCommand command;

        public ProjectsResourcesDAO()
        {

        }

        public List<ProjectResourcesDTO> GetHProjectResources()
        {
            List<ProjectResourcesDTO> lista = new List<ProjectResourcesDTO>();
            command = new SqlCommand("Projects_Resources_R", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
            ProjectResourcesDTO obj;
            while (rdr.Read())    // En caso de que exista varios valores de retorno sin usar DataTable
            {
                obj = new ProjectResourcesDTO();
                obj.Pro_ID = rdr.GetInt32(rdr.GetOrdinal("Pro_ID"));
                obj.NameProject = rdr.GetString(rdr.GetOrdinal("NameProject"));
                obj.Rec_ID = rdr.GetInt32(rdr.GetOrdinal("Rec_ID"));
                obj.NameResource = rdr.GetString(rdr.GetOrdinal("NameResource"));

                lista.Add(obj);
            }
            connection.Close();
            return lista;
        }

        public List<ProjectDTO> GetProjectWithoutResourcesAll()
        {
            List<ProjectDTO> lista = new List<ProjectDTO>();
            command = new SqlCommand("Projects_Resources_RPAll", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
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

        public List<ProjectDTO> GetProjectWithoutResources(int currentPage, int sizeData)
        {
            List<ProjectDTO> lista = new List<ProjectDTO>();
            command = new SqlCommand("Projects_Resources_RP", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            command.Parameters.AddWithValue("@currentPage", currentPage);
            command.Parameters.AddWithValue("@sizeData", sizeData);
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
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

        public List<HResourcesDTO> GetResourcesWithoutProjectsAll()
        {
            List<HResourcesDTO> lista = new List<HResourcesDTO>();
            command = new SqlCommand("Projects_Resources_RRAll", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
            HResourcesDTO obj;
            while (rdr.Read())    // En caso de que exista varios valores de retorno sin usar DataTable
            {
                obj = new HResourcesDTO();
                obj.Rec_ID = rdr.GetInt32(rdr.GetOrdinal("Rec_ID"));
                obj.Name = rdr.GetString(rdr.GetOrdinal("Name"));
                obj.LastName = rdr.GetString(rdr.GetOrdinal("LastName"));
                obj.Position = rdr.GetString(rdr.GetOrdinal("Position"));
                obj.Email = rdr.GetString(rdr.GetOrdinal("Email"));

                lista.Add(obj);
            }
            connection.Close();
            return lista;
        }

        public List<HResourcesDTO> GetResourcesWithoutProjects(int currentPage, int sizeData)
        {
            List<HResourcesDTO> lista = new List<HResourcesDTO>();
            command = new SqlCommand("Projects_Resources_RR", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            command.Parameters.AddWithValue("@currentPage", currentPage);
            command.Parameters.AddWithValue("@sizeData", sizeData);
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
            HResourcesDTO obj;
            while (rdr.Read())    // En caso de que exista varios valores de retorno sin usar DataTable
            {
                obj = new HResourcesDTO();
                obj.Rec_ID = rdr.GetInt32(rdr.GetOrdinal("Rec_ID"));
                obj.Name = rdr.GetString(rdr.GetOrdinal("Name"));
                obj.LastName = rdr.GetString(rdr.GetOrdinal("LastName"));
                obj.Position = rdr.GetString(rdr.GetOrdinal("Position"));
                obj.Email = rdr.GetString(rdr.GetOrdinal("Email"));

                lista.Add(obj);
            }
            connection.Close();
            return lista;
        }

        public ProjectResourcesDTO PostAsignProRec(ProjectResourcesDTO value)
        {
            List<ProjectResourcesDTO> lista = new List<ProjectResourcesDTO>();
            command = new SqlCommand("Projects_Resources_C", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            command.Parameters.AddWithValue("@Pro_ID", value.Pro_ID);
            command.Parameters.AddWithValue("@Rec_ID", value.Rec_ID);
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
            ProjectResourcesDTO obj = null;
            while (rdr.Read())    // En caso de que exista varios valores de retorno sin usar DataTable
            {
                obj = new ProjectResourcesDTO();
                obj.Pro_ID = rdr.GetInt32(rdr.GetOrdinal("Pro_ID"));
                obj.Rec_ID = rdr.GetInt32(rdr.GetOrdinal("Rec_ID"));

                
            }
            connection.Close();
            return obj;
        }

        public ProjectResourcesDTO DeleteDesProRec(int Pro_ID, int Rec_ID)
        {
            List<ProjectResourcesDTO> lista = new List<ProjectResourcesDTO>();
            command = new SqlCommand("Projects_Resources_D", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            command.Parameters.AddWithValue("@Pro_ID", Pro_ID);
            command.Parameters.AddWithValue("@Rec_ID", Rec_ID);
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
            ProjectResourcesDTO obj = null;
            while (rdr.Read())    // En caso de que exista varios valores de retorno sin usar DataTable
            {
                obj = new ProjectResourcesDTO();
                obj.Pro_ID = rdr.GetInt32(rdr.GetOrdinal("Pro_ID"));
                obj.Rec_ID = rdr.GetInt32(rdr.GetOrdinal("Rec_ID"));


            }
            connection.Close();
            return obj;
        }
    }
}
