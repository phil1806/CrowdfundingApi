using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
  
    public class CreateProjectModel
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public decimal Objectif { get; set; }
        public string CompteBQ { get; set; }

        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int IdUserOwner { get; set; }

        public int IdStatus { get; set; }

        public IEnumerable<Paliers> Paliers { get; set; }
    }
}
