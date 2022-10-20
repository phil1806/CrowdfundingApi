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
        Paliers GetPalierById(int id);

        bool CreatePalier(Paliers Paliers);
        bool UpdatePalier(int id);
        bool DeletePalier(int id);
    }
}
