using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models;
using DAL.Interfaces;

namespace BLL.Services {
    public class StatusProjetService : IStatusProjetService {

        private const int IdMinToChange = 5;//TODO put in appsetting ?
        private IStatusProjetRepo statuService;

        public StatusProjetService(IStatusProjetRepo _statuService) {
            statuService = _statuService;
        }

        public void Create(StatusBll s) {
            statuService.Create(s.ToDAL());
        }

        public void Delete(int id) {
            if(id <= IdMinToChange) throw new Exception("Statu ID can not be deleted");
            statuService.Delete(id);
        }

        public IEnumerable<StatusBll> GetAll() {
            return statuService.GetAll().Select(s => s.ToBll());
        }

        public void Update(StatusBll s) {
            if (s.Id <= IdMinToChange) throw new Exception("Statu ID can not be changed");
            statuService.Update(s.ToDAL());
        }
    }
}
