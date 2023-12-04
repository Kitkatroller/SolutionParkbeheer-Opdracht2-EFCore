using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public class HuurperiodeMapper
    {
        public static Huurperiode MapToBLModel(HuurperiodeEF efHuurperiodeEntry)
        {
            if (efHuurperiodeEntry == null) return null;

            return new Huurperiode(efHuurperiodeEntry.StartDatum, efHuurperiodeEntry.AantalDagen);
        }

        public static HuurperiodeEF MapToEfEntity(Huurperiode HuurperiodeEntry)
        {
            if (HuurperiodeEntry == null) return null;


            return new HuurperiodeEF
            {
                StartDatum = HuurperiodeEntry.StartDatum,
                AantalDagen = HuurperiodeEntry.Aantaldagen
            };
        }
    }
}
