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
    }
}
