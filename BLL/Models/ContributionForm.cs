using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    internal class ContributionForm
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }

        private string CompteBc { get; set; }
        private DateTime DateDeDebut { get; set; }
        private DateTime DateDeFin { get; set; }
    }
}
