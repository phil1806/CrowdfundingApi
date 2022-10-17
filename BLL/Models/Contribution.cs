using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Contribution
    {
        public int Id { get; set; }
        public decimal Montant { get; set; }
        public int userId { get; set; }

        public string projectId { get; set; }

    }
}
