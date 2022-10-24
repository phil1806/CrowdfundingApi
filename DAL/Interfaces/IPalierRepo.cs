using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPalierRepo
    {
        IEnumerable<Paliers> GetAllPaliers();
        IEnumerable<Paliers> GetPalierByProjetId(int id);

        int CreatePalier(Paliers Paliers);
        bool UpdatePalier(Paliers Paliers);
        bool DeletePalier(int id);
    }
}



