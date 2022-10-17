

using BLL.Models;

namespace BLL.Interfaces {
    public interface IUserService {
        public User Create(UserForm user);
        public User Login(UserLogin user);
        public User Update(User user);
        public void Delete(int id);
        public User GetUserById(int id);
        public IEnumerable<User> GetAllUsers();
    }
}
