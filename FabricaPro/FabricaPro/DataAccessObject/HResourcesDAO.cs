using FabricaPro.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FabricaPro.DataAccessObject
{
    public class HResourcesDAO
    {
        SqlConnection connection = new SqlConnection("Server=E-JAVELAZQUEZ;Database=FabricaPro;Trusted_Connection=True;");
        SqlCommand command;

        public HResourcesDAO()
        {

        }
        public List<HResourcesDTO> GetHResourcesAll()
        {
            List<HResourcesDTO> lista = new List<HResourcesDTO>();
            command = new SqlCommand("Human_Resources_RAll", connection);
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

        public List<HResourcesDTO> GetHResources(int currentPage, int sizeData)
        {
            List<HResourcesDTO> lista = new List<HResourcesDTO>();
            command = new SqlCommand("Human_Resources_R", connection);
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


        public HResourcesDTO GetResourceByID(int id)
        {
            HResourcesDTO resource = null;
            command = new SqlCommand("Resource_R_ByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            command.Parameters.AddWithValue("@Rec_ID", id);
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())    // En caso de que exista varios valores de retorno sin usar DataTable
            {
                resource = new HResourcesDTO();
                resource.Rec_ID = rdr.GetInt32(rdr.GetOrdinal("Rec_ID"));
                resource.Name = rdr.GetString(rdr.GetOrdinal("Name"));
                resource.LastName = rdr.GetString(rdr.GetOrdinal("LastName"));
                resource.Position = rdr.GetString(rdr.GetOrdinal("Position"));
                resource.Email = rdr.GetString(rdr.GetOrdinal("Email"));
            }
            connection.Close();
            return resource;
        }

        public int PostHResources(HResourcesDTO value)
        {
            HResourcesDTO data = new HResourcesDTO();
            command = new SqlCommand("Human_Resources_C", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            command.Parameters.AddWithValue("@Name", value.Name);
            command.Parameters.AddWithValue("@LastName", value.LastName);
            command.Parameters.AddWithValue("@Position", value.Position);
            command.Parameters.AddWithValue("@Email", value.Email);
            // command.Parameters.Clear();
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
            int Pro_ID = 0;
            while (rdr.Read())    // En caso de que exista varios valores de retorno sin usar DataTable
            {
                Pro_ID = rdr.GetInt32(rdr.GetOrdinal("Rec_ID"));
            }
            connection.Close();
            return Pro_ID;
        }
        public int PutHResources(int Pro_id, HResourcesDTO value)
        {
            command = new SqlCommand("Human_Resources_U", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            command.Parameters.AddWithValue("@Rec_ID", Pro_id);
            command.Parameters.AddWithValue("@Name", value.Name);
            command.Parameters.AddWithValue("@LastName", value.LastName);
            command.Parameters.AddWithValue("@Position", value.Position);
            command.Parameters.AddWithValue("@Email", value.Email);
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
            int Rec_ID = 0;
            while (rdr.Read())    // En caso de que exista varios valores de retorno sin usar DataTable
            {
                Rec_ID = rdr.GetInt32(rdr.GetOrdinal("Rec_ID"));
            }
            connection.Close();
            return Rec_ID;
        }

        public int DeleteResources(int ID)
        {
            command = new SqlCommand("Human_Resources_D", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            command.Parameters.AddWithValue("@Rec_ID", ID);
            // command.Parameters.Clear();
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
            int Pro_ID = 0;
            while (rdr.Read())    // En caso de que exista varios valores de retorno sin usar DataTable
            {
                Pro_ID = rdr.GetInt32(rdr.GetOrdinal("Rec_ID"));
            }
            connection.Close();
            return Pro_ID;
        }


    }
}
