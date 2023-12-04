using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class ContactgegevensEF
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Adres { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Tel { get; set; }

        [ForeignKey("Huurder")]
        public int Huurder_Id { get; set; }
        public virtual HuurderEF Huurder { get; set; }
    }
}
