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
    public class HuisEF
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Straat { get; set; }

        [Required]
        public int Nr { get; set; }

        [Required]
        public bool Actief { get; set; }

        public string ParkId { get; set; }

        public virtual ParkEF Park { get; set; }

        public virtual ICollection<HuurcontractEF> Huurcontracten { get; set; }

        public HuisEF(string straat, int nr, bool actief)
        {
            Straat = straat;
            Nr = nr;
            Actief = actief;
        }

        public HuisEF(string straat, int nr, ParkEF park)
        {
            Straat = straat;
            Nr = nr;
            Park = park;
            Actief = true;
        }

        public HuisEF(string straat, int nr, bool actief, ParkEF park) : this(straat, nr, actief)
        {
            Park = park;
        }
        public HuisEF(string straat, int nr, bool actief, ParkEF park, string parkId) : this(straat, nr, actief, park)
        {
            ParkId = parkId;
        }
    }
}
