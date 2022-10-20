using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{

    public class PalierProject
    {
        public int Id { get; set; }
        public decimal Montant { get; set; }


    }
    public class CreateProjectModel
    {
        public int Id { get; set; }
        public string Titre { get; set; }

        public IEnumerable<PalierProject> Paliers { get; set; }    
    }
}
