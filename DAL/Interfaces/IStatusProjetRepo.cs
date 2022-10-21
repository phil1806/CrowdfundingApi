

using DAL.Models;

namespace DAL.Interfaces {


    public interface IStatusProjetRepo {

        public void Create(StatusDalModel s);
        public void Delete(int i);
        public void Update(StatusDalModel s);
        public IEnumerable<StatusDalModel> GetAll();

    }
    
}
