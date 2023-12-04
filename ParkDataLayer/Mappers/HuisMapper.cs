using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public class HuisMapper
    {
        public static Huis MapToBLModel(HuisEF efHuisEntry)
        {
            if (efHuisEntry == null) return null;

            Park park = ParkMapper.MapToBLModel(efHuisEntry.Park);

            Huis huis = new(efHuisEntry.Id, efHuisEntry.Straat, efHuisEntry.Nr, efHuisEntry.Actief, park);

            return huis;
        }

        public static HuisEF MapToEfEntity(Huis huisEntry)
        {
            if (huisEntry == null) return null;


            return new HuisEF
            {
                Straat = huisEntry.Straat,
                Nr = huisEntry.Nr,
                Actief = huisEntry.Actief,
                ParkId = huisEntry.Park.Id,
                Park = ParkMapper.MapToEfEntity(huisEntry.Park)
            };
        }
    }
}
