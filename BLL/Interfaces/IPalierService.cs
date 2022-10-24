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
        IEnumerable<Paliers> GetPalierByProjetId(int id);

        int CreatePalier(Paliers Palier);
        bool UpdatePalier( Paliers Palier);
        bool DeletePalier(int id);
    }
}
