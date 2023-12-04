using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Mappers;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class HuurderRepositoryEF : IHuurderRepository
    {
        private readonly ParkbeheerContext _context;

        public HuurderRepositoryEF(string connectionString)
        {
            var options = new DbContextOptionsBuilder<ParkbeheerContext>()
                              .UseSqlServer(connectionString)
                              .Options;
            _context = new ParkbeheerContext(options);
        }

        public Huurder GeefHuurder(int id)
        {
            try
            {
                var huurderEF = _context.Huurders
                            .Include(h => h.Contactgegevens)
                            .FirstOrDefault(h => h.Id == id);
                return HuurderMapper.MapToBLModel(huurderEF);
            }
            catch
            {
                throw new RepositoryException("Geef huurder");
            }
            
        }

        public List<Huurder> GeefHuurders(string naam)
        {
            try
            {
                var huurdersEF = _context.Huurders
                            .Include(h => h.Contactgegevens)
                            .Where(h => h.Naam == naam);

                List<Huurder> huurders = new List<Huurder>();

                foreach (var huurder in huurdersEF)
                {
                    huurders.Add(HuurderMapper.MapToBLModel(huurder));
                }

                return huurders;
            }
            catch
            {
                throw new RepositoryException("Geef huurder");
            }
        }

        public bool HeeftHuurder(string naam, Contactgegevens contact)
        {
            try
            {
                return _context.Huurders.Any(h => h.Naam == naam 
                && h.Contactgegevens == ContactgegevensMapper.MapToEfEntity(contact));
            }
            catch
            {
                throw new RepositoryException("Heeft huurder");
            }
        }

        public bool HeeftHuurder(int id)
        {
            try
            {
                return _context.Huurders.Any(h => h.Id == id);
            }
            catch
            {
                throw new RepositoryException("Heeft huurder");
            }
        }

        public void UpdateHuurder(Huurder huurder)
        {
            try
            {
                var huurderEF = _context.Huurders.Find(huurder.Id);
                if (huurderEF != null)
                {
                    var mappedHuurderEF = HuurderMapper.MapToEfEntity(huurder);
                    mappedHuurderEF.Id = huurderEF.Id;

                    _context.Entry(huurderEF).CurrentValues.SetValues(mappedHuurderEF);

                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new RepositoryException("Update Huurder");
            }
        }

        public Huurder VoegHuurderToe(Huurder huurder)
        {
            try
            {
                var huurderEF = HuurderMapper.MapToEfEntity(huurder);

                //if (_context.Contactgegevens.Find(huurderEF.Contactgegevens) != null)//Im searching the same result twice, search once
                //{
                //    huurderEF.Contactgegevens = _context.Contactgegevens.Find(huurderEF.Contactgegevens);
                //}

                _context.Huurders.Add(huurderEF);
                _context.SaveChanges();
                return HuurderMapper.MapToBLModel(huurderEF);
            }
            catch
            {
                throw new RepositoryException("Voeg huurder toe");
            }
        }
    }
}
