using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PalierService : IPalierService
    {
        //Prop's
        private readonly IPalierRepo _palierRepo;

        //Constructeur
        public PalierService(IPalierRepo palierRepo )
        {
            _palierRepo = palierRepo;
        }


        public int CreatePalier(Paliers Palier)
        {
            return _palierRepo.CreatePalier(Palier.toDalPallier());
        }

        public bool DeletePalier(int id)
        {
            return _palierRepo.DeletePalier(id);
        }

        public IEnumerable<Paliers> GetAllPaliers()
        {
            return _palierRepo.GetAllPaliers().Select(x =>x.toBllPallier()); 
        }

        public IEnumerable<Paliers> GetPalierByProjetId(int id)
        {
            return _palierRepo.GetPalierByProjetId(id).Select(p => p.toBllPallier());
        }

        public bool UpdatePalier(Paliers P)
        {
            return _palierRepo.UpdatePalier(P.toDalPallier());
        }
    }
}
