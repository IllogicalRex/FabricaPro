using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FabricaPro.DTO
{
    
    public class ProjectDTO
    {
      //  [IgnoreDataMember]

        public int Pro_ID { get; set; }

        //[ScaffoldColumn(false)]
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

    public class ProjectResourcesDTO
    {
        public int Pro_ID { get; set; }

        public string NameProject { get; set; }

        public int Rec_ID { get; set; }

        public string NameResource { get; set; }

    }

    public class filterPaginationDTO
    {
        public int currentPage { get; set; }

        public int sizeData { get; set; }

    }
}
