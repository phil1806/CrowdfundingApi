using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IContributionService
    {
        public Contribution Add(ContributionForm contribution);
        public Contribution GetById(int id);
        public IEnumerable<Contribution> GetAll();
    }
}
