using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IContributionRepo
    {
        public Contribution Add(ContributionModelDAL contribution);
        public Contribution GetById(int id);
        public IEnumerable<Contribution> GetAll();

    }
}
