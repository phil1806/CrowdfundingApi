using BLLm = BLL.Models;
using DALm = DAL.Models;

namespace BLL.Mappers {
    public static class StatuProjetMapper {

        public static BLLm.StatusBll ToBll(this DALm.StatusDalModel statu) {
            return new BLLm.StatusBll() {
                Id = statu.Id,
                TypeStatus = statu.TypeStatus
            };
        }

        public static DALm.StatusDalModel ToDAL(this BLLm.StatusBll statu) {
            return new DALm.StatusDalModel() {
                Id = statu.Id,
                TypeStatus = statu.TypeStatus
            };
        }

    }
}
