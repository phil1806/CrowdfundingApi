﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ContributionModelDAL
    {
        public int Id { get; set; }
        public decimal Montant { get; set; }
        public int IdUser { get; set; }

        public int IdProject { get; set; }
    }
}
