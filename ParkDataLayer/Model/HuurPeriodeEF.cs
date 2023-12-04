using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class HuurperiodeEF
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AantalDagen { get; set; }

        [Required]
        public DateTime EindDatum { get; set; }

        [Required]
        public DateTime StartDatum { get; set; }

        [ForeignKey("Huurcontract")]
        public string Huurcontract_Id { get; set; }
        public virtual HuurcontractEF Huurcontract { get; set; }
    }
}
