﻿using System.Data;
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
                Password = user.Password,
                
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

        public static DALm.UserLogin ToDal(this BLLm.UserLogin user) {
            return new DALm.UserLogin() {
                Email = user.Email,
                Password = user.Password
            };
        }

        public static BLLm.User ToBll(this DALm.User user) {
            return new BLLm.User() {
                Nickname = user.Nickname,
                Id = user.Id,
                Email = user.Email,
                BirtDay= user.BirtDay,
                Role = user.Role
        };
        }

        public static DALm.User ToBll(this BLLm.User user) {
            return new DALm.User() {
                Nickname = user.Nickname,
                Id = user.Id,
                Email = user.Email,
                BirtDay = user.BirtDay,
                Role = user.Role
            };
        }


        //TODO useless fct
        public static IEnumerable<BLLm.User> ToBll(this IEnumerable<DALm.User> users) {
            foreach(DALm.User u in users) {
                yield return u.ToBll();
            }
        }

    }
}
