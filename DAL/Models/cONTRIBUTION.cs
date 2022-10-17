using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Contribution
    {
        public int Id { get; set; }
        public decimal Montant { get; set; }
        public int UserId { get; set; }

        public string ProjectId { get; set; }

    }
}
