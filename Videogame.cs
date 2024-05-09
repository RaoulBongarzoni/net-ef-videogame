using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace net_ef_videogame
{
    [Table ("Videogame")]
    [Index(nameof(VideogameName), IsUnique = true)]
    public class Videogame
    {
        public int? VideogameId { get; set; }
        public string VideogameName { get; set; }
        public string? VideogameDescription { get; set; }
        public DateTime VideogameRelease { get; set; }

        public int SoftwareHouseId { get; set; }
        public SoftwareHouse SoftwareHouse { get; set; }


        public Videogame() { }

        public Videogame(int videogameId, string videogameName, string? videogameDescription, DateTime videogameRelease, int softwareHouseId, SoftwareHouse softwareHouse)
        {
            VideogameId = videogameId;
            VideogameName = videogameName;
            VideogameDescription = videogameDescription;
            VideogameRelease = DateTime.Now;
            SoftwareHouseId = softwareHouseId;
            SoftwareHouse = softwareHouse;
        }
    }


}


