using System.Data;
using BLLm = BLL.Models;
using DALm = DAL.Models;


namespace BLL.Mappers {
    public static class UserMapper {

        public static BLLm.UserForm ToBll(this DALm.UserRegister user) {
            return new BLLm.UserForm() {
                Email = user.Email,
                Role = user.Role,
                BirtDay = user.BirtDay,
                Nickname = user.Nickname,
                Password = user.Password
            };
        }

        public static DALm.UserRegister ToDAL(this BLLm.UserForm user) {
            return new DALm.UserRegister() {
                Email = user.Email,
                Role = user.Role,
                BirtDay = user.BirtDay,
                Nickname = user.Nickname,
                Password = user.Password
            };
        }

        public static BLLm.User ToBll(this DALm.User user) {
            return new BLLm.User() {
                Nickname = user.Nickname,
                Id = user.Id
            };
        }

    }
}
