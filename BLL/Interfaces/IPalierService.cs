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

        bool CreatePalier(Paliers Paliers);
        bool UpdatePalier(int id);
        bool DeletePalier(int id);
    }
}
