using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public class ContactgegevensMapper
    {
        public static Contactgegevens MapToBLModel(ContactgegevensEF efContactgegevensEntry)
        {
            if (efContactgegevensEntry == null) return null;

            return new Contactgegevens(efContactgegevensEntry.Email, efContactgegevensEntry.Tel, efContactgegevensEntry.Adres);
        }

        public static ContactgegevensEF MapToEfEntity(Contactgegevens ContactgegevensEntry)
        {
            if (ContactgegevensEntry == null) return null;


            return new ContactgegevensEF
            {
                Email = ContactgegevensEntry.Email,
                Tel = ContactgegevensEntry.Tel,
                Adres = ContactgegevensEntry.Adres
            };
        }
    }
}
