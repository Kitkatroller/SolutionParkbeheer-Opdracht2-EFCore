using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public class ParkMapper
    {
        public static Park MapToBLModel(ParkEF efParkEntry)
        {
            if (efParkEntry == null) return null;

            return new Park(efParkEntry.Id, efParkEntry.Naam, efParkEntry.Locatie);
        }

        public static ParkEF MapToEfEntity(Park parkEntry)
        {
            if (parkEntry == null) return null;


            return new ParkEF
            {
                Id = parkEntry.Id,
                Naam = parkEntry.Naam,
                Locatie = parkEntry.Locatie
            };
        }
    }
}
