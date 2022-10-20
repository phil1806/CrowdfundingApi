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


        public bool CreatePalier(Paliers Paliers)
        {
            throw new NotImplementedException();
        }

        public bool DeletePalier(int id)
        {
            return _palierRepo.DeletePalier(id);
        }

        public IEnumerable<Paliers> GetAllPaliers()
        {
            return _palierRepo.GetAllPaliers().Select(x =>x.toBllPallier()); 
        }

        public Paliers GetPalierById(int id)
        {
            return _palierRepo.GetPalierById(id).toBllPallier();
        }

        public bool UpdatePalier(int id)
        {
            throw new NotImplementedException();
        }
    }
}
