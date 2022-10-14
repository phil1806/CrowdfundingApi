using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models {
    public class UserForm {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public DateTime BirtDay { get; set; }
        public int Role { get; set; }
    }
}
