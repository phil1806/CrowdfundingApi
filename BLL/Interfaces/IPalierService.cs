using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPalierService
    {
        IEnumerable<Paliers> GetAllPaliers();
        Paliers GetPalierById(int id);

        int CreatePalier(Paliers Palier);
        bool UpdatePalier(int id, Paliers Palier);
        bool DeletePalier(int id);
    }
}
