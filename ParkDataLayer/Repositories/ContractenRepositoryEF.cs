using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class ContractenRepositoryEF : IContractenRepository
    {
        private readonly ParkbeheerContext _context;

        public ContractenRepositoryEF(string connectionString)
        {
            var options = new DbContextOptionsBuilder<ParkbeheerContext>()
                              .UseSqlServer(connectionString)
                              .Options;
            _context = new ParkbeheerContext(options);
        }

        public void AnnuleerContract(Huurcontract contract)
        {
            throw new NotImplementedException();
        }

        public Huurcontract GeefContract(string id)
        {
            throw new NotImplementedException();
        }

        public List<Huurcontract> GeefContracten(DateTime dtBegin, DateTime? dtEinde)
        {
            throw new NotImplementedException();
        }

        public bool HeeftContract(DateTime startDatum, int huurderid, int huisid)
        {
            try
            {
                return _context.Huurcontracten.Any(h => h.StartDatum == startDatum 
                && h.Huurder_Id == huurderid
                && h.Huis_Id == huisid);
            }
            catch
            {
                throw new RepositoryException("Heeft contract");
            }
        }

        public bool HeeftContract(string id)
        {
            try
            {
                return _context.Huurcontracten.Any(h => h.Id == id);
            }
            catch
            {
                throw new RepositoryException("Heeft huis");
            }
        }

        public void UpdateContract(Huurcontract contract)
        {
            throw new NotImplementedException();
        }

        public void VoegContractToe(Huurcontract contract)
        {
            try
            {
                var huurcontractEF = HuurcontractMapper.MapToEfEntity(contract);

                //if (_context.Parks.Find(huisEF.Park.Id) != null)//Im searching the same result twice, search once
                //{
                //    huisEF.Park = _context.Parks.Find(huisEF.Park.Id);
                //}

                _context.Huurcontracten.Add(huurcontractEF);
                _context.SaveChanges();
                //return HuurcontractMapper.MapToBLModel(huurcontractEF);
            }
            catch
            {
                throw new RepositoryException("Voeg Contract toe");
            }
        }
    }
}
