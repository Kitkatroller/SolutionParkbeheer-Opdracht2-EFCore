using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Linq;

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
            try
            {
                var huisEF = _context.Huizen
                                 .Include(h => h.Park)
                                 .FirstOrDefault(h => h.Id == id);
                return HuisMapper.MapToBLModel(huisEF);
            }
            catch
            {
                throw new RepositoryException("Geef huis");
            }
            
        }

        public bool HeeftHuis(string straat, int nummer, Park park)
        {
            try
            {
                return _context.Huizen.Any(h => h.Straat == straat && h.Nr == nummer && h.ParkId == park.Id);
            }
            catch
            {
                throw new RepositoryException("Heeft huis");
            }            
        }

        public bool HeeftHuis(int id)
        {
            try
            {
                return _context.Huizen.Any(h => h.Id == id);
            }
            catch
            {
                throw new RepositoryException("Heeft huis");
            }             
        }

        public void UpdateHuis(Huis huis)
        {
            try
            {
                var huisEF = _context.Huizen.Find(huis.Id);
                if (huisEF != null)
                {
                    var mappedHuisEF = HuisMapper.MapToEfEntity(huis);
                    mappedHuisEF.Id = huisEF.Id;

                    _context.Entry(huisEF).CurrentValues.SetValues(mappedHuisEF);

                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new RepositoryException("Update huis");
            }
            
        }

        public Huis VoegHuisToe(Huis huis)
        {
            try
            {
                var huisEF = HuisMapper.MapToEfEntity(huis);

                if (_context.Parks.Find(huisEF.Park.Id) != null)//Im searching the same result twice, search once
                {
                    huisEF.Park = _context.Parks.Find(huisEF.Park.Id);
                }

                _context.Huizen.Add(huisEF);
                _context.SaveChanges();
                return HuisMapper.MapToBLModel(huisEF);
            }
            catch
            {
                throw new RepositoryException("Update huis");
            }            
        }
    }
}
