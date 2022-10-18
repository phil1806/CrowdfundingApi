using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models;
using DAL.Interfaces;

namespace BLL.Services {
    public class UserService : IUserService {

        private readonly IUserRepo _UserRepo;

        public UserService(IUserRepo userRepo) {
            _UserRepo = userRepo;
        }
        public User Create(UserForm user) {
            //TODO check > 18 ans
            return _UserRepo.Register(user.ToDAL()).ToBll();
        }

        public void Delete(int id) {
            _UserRepo.Delete(id);
        }

        public IEnumerable<User> GetAllUsers() {
            return _UserRepo.GetAllUsers().ToBll();
        }

        public User GetUserById(int id) {
            return _UserRepo.GetUserById(id).ToBll();
        }

        public User Login(UserLogin user) {
            return _UserRepo.Login(user.ToDal()).ToBll();
        }

        public void Update(User user) {
            _UserRepo.Update(user.ToBll());
        }
    }
}
