/*
 * Model to register new User
 * 
 */ 

namespace BLL.Models {
    public class UserForm {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public DateTime BirtDay { get; set; }
        public int Role { get; set; }
    }
}
