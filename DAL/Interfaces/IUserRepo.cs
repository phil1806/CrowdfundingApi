using DAL.Models;


namespace DAL.Interfaces {
    public interface IUserRepo {
        public User Register(UserRegister user);
        public User Login(UserLogin user);
        public User Update(User user);
        public void Delete(int id);
        public User GetUserById(int id);
        public IEnumerable<User> GetAllUsers();
    }
}
