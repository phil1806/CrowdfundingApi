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
        void Add(ContributionModelDAL contribution);
        ContributionModelDAL GetById(int id);
        IEnumerable<ContributionModelDAL> GetAll();

    }
}
