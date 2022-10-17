/*
 * Model to register new User
 * 
 */


namespace DAL.Models {
    public class UserRegister {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public DateTime BirtDay { get; set; }
        public int Role { get; set; }
    }
}
