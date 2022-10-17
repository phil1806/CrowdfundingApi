using DAL.Models;


namespace DAL.Interfaces {
    public interface IUserRepo {
        public User Register(UserRegister user);
    }
}
