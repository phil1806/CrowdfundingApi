using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using BLL.Mappers;


namespace BLL.Services
{
    public class ContributionService : IContributionService
    {
        private readonly IContributionRepo _contributionService;

        public ContributionService(IContributionRepo contributionRepo)
        {
            _contributionService = contributionRepo;
        }

        public void Add(ContributionModelBLL contribution)
        {
            _contributionService.Add(contribution.ToDal());
        }

        public IEnumerable<ContributionModelBLL> GetAll()
        {
            return _contributionService.GetAll().Select(element => element.ToBll());
        }

        public ContributionModelBLL GetById(int id)
        {
            return _contributionService.GetById(id).ToBll();
        }
    }
}
