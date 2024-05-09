using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("SoftwareHouse")]
    [Index(nameof(SoftwareHouseId), IsUnique = true)]
    public class SoftwareHouse
    {
        public int SoftwareHouseId { get; internal set; }
        public string SoftwareHouseName { get; set; }
        public string? SoftwareHouseDescription { get; set; }

        public List<Videogame>? Videogames { get; set; }

        public SoftwareHouse(string name)
        {
            this.SoftwareHouseName = name;
        }

        public SoftwareHouse() { }
    }
}
