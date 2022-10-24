using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public decimal Objectif { get; set; }
        public string CompteBQ { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string TypeStatus { get; set; } 
        public decimal ContributionTotal { get; set; } 
        public IEnumerable<Paliers> Paliers { get; set;}
    }


    
    
}
