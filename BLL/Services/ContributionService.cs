using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class ContributionService : IContributionService
    {
        private readonly IContributionRepo _contributionService;

        public ContributionService(IContributionRepo contributionRepo)
        {
            _contributionService = contributionRepo;
        }

        public Contribution Add(ContributionForm contribution)
        {
            return _contributionService.Add(contribution.ToDal());
        }

        public IEnumerable<Contribution> GetAll()
        {
            return _contributionService.GetAll().Select(element => element.ToBll());
        }

        public Contribution GetById(int id)
        {
            return _contributionService.GetById(id).ToBll();
        }
    }
}
