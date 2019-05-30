using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricaPro.DTO
{
    [BsonIgnoreExtraElements]
    public class ProjectDTO
    {
        public int Pro_ID { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ProyectLeader { get; set; }
        
    }

    public class HResourcesDTO
    {
        public int Rec_ID { get; set; }
	    
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public string Email { get; set; }

    }
}
