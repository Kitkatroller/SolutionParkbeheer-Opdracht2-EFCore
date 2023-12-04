using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public class HuurcontractMapper
    {
        public static Huurcontract MapToBLModel(HuurcontractEF huurcontractEF)
        {
            if (huurcontractEF == null) return null;

            Huis huis = HuisMapper.MapToBLModel(huurcontractEF.Huis);
            Huurder huurder = HuurderMapper.MapToBLModel(huurcontractEF.Huurder);
            Huurperiode huurperiode = HuurperiodeMapper.MapToBLModel(huurcontractEF.Huurperiode);
            return new Huurcontract(
                huurcontractEF.Id,
                huurperiode,
                huurder,
                huis
            );
        }

        public static HuurcontractEF MapToEfEntity(Huurcontract huurcontract)
        {
            if (huurcontract == null) return null;

            HuisEF huis = HuisMapper.MapToEfEntity(huurcontract.Huis);
            HuurderEF huurder = HuurderMapper.MapToEfEntity(huurcontract.Huurder);
            HuurperiodeEF huurperiode = HuurperiodeMapper.MapToEfEntity(huurcontract.Huurperiode);

            return new HuurcontractEF
            {
                Id = huurcontract.Id,
                Huurperiode = huurperiode,
                Huurder = huurder,
                Huis = huis
            };
        }
    }
}
