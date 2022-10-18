using BLLm = BLL.Models;
using DALm = DAL.Models;
namespace BLL.Mappers
{
    public static class ContributionMapper
    {
        public static BLLm.ContributionModelBLL ToBll(this DALm.ContributionModelDAL contribution)
        {
            return new BLLm.ContributionModelBLL()
            {
                Montant = contribution.Montant,
                UserId = contribution.UserId,
                ProjectId = contribution.ProjectId
            };
        }

        public static DALm.ContributionModelDAL ToDal(this BLLm.ContributionModelBLL contribution)
        {
            return new DALm.ContributionModelDAL()
            {
                Montant = contribution.Montant,
                UserId = contribution.UserId,
                ProjectId = contribution.ProjectId
            };        
        }

         /*TODOO
          * Connect Contribution to Project by is Id
          */
      /*  public static BLLm.ContributionModelBLL ToBll(this DALm.Project contribution)
        {
            return new BLLm.ContributionModelBLL()
            {
                Id = contribution.Id
            };
        }*/
    } 
}
