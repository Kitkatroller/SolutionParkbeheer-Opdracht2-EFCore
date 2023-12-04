using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;

namespace ParkDataLayer.Repositories
{
    public class HuizenRepositoryEF : IHuizenRepository
    {
        private readonly ParkbeheerContext _context;

        public HuizenRepositoryEF(string connectionString)
        {
            var options = new DbContextOptionsBuilder<ParkbeheerContext>()
                              .UseSqlServer(connectionString)
                              .Options;
            _context = new ParkbeheerContext(options);
        }

        public Huis GeefHuis(int id)
        {
            HuisEF huisEF = _context.Huizen
                                .Include(u => u.Park)
                                .FirstOrDefaultAsync(u => u.Id == id);
            return HuisMapper.MapToBLModel(huisEF);

            //throw new NotImplementedException();
        }

        public bool HeeftHuis(string straat, int nummer, Park park)
        {
            throw new NotImplementedException();
        }

        public bool HeeftHuis(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateHuis(Huis huis)
        {
            throw new NotImplementedException();
        }

        public Huis VoegHuisToe(Huis h)
        {
            throw new NotImplementedException();
        }
    }
}
