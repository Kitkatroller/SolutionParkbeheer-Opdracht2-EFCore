using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public class HuurderMapper
    {
        public static Huurder MapToBLModel(HuurderEF efHuurderEntry)
        {
            if (efHuurderEntry == null) return null;

            Contactgegevens contactgegevens = ContactgegevensMapper.MapToBLModel(efHuurderEntry.Contactgegevens);

            return new Huurder(efHuurderEntry.Id, efHuurderEntry.Naam, contactgegevens);
        }

        public static HuurderEF MapToEfEntity(Huurder huurderEntry)
        {
            if (huurderEntry == null) return null;


            return new HuurderEF
            {
                Id = huurderEntry.Id,
                Naam = huurderEntry.Naam,
                Contactgegevens = ContactgegevensMapper.MapToEfEntity(huurderEntry.Contactgegevens)
            };
        }
    }
}
