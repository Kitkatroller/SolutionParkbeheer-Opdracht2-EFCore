using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.IO;
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


            return new HuisEF(huisEntry.Straat, huisEntry.Nr, huisEntry.Actief, ParkMapper.MapToEfEntity(huisEntry.Park), huisEntry.Park.Id);
        }
    }
}
