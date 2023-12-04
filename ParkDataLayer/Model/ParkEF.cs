using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class ParkEF
    {
        [Key]
        [MaxLength(20)]
        public string Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Naam { get; set; }

        [MaxLength(500)]
        public string Locatie { get; set; }

        public virtual ICollection<HuisEF> Huizen { get; set; }

        public ParkEF(string id, string naam, string locatie)
        {
            Id = id;
            Naam = naam;
            Locatie = locatie;
        }
    }
}
