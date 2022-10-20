using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Paliers
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Montant { get; set; }
        public string Description { get; set; }
        public int IdProject { get; set; }
    }
}
