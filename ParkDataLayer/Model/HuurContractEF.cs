using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class HuurcontractEF
    {
        [Key]
        [MaxLength(25)]
        public string Id { get; set; }

        [Required]
        public DateTime StartDatum { get; set; }

        [Required]
        public DateTime EindDatum { get; set; }

        [Required]
        public int AantalDagen { get; set; }

        [ForeignKey("Huis")]
        public int Huis_Id { get; set; }
        public virtual HuisEF Huis { get; set; }

        [ForeignKey("Huurder")]
        public int Huurder_Id { get; set; }
        public virtual HuurderEF Huurder { get; set; }

        public virtual HuurperiodeEF Huurperiode { get; set; }
    }
}
