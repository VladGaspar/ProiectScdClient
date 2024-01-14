using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRDesktopApp
{
    internal class LoginDto
    {
        public string username { get; set; }
        public string password { get; set; }
        public LoginDto() { }
        public LoginDto(string username, string password) {
            this.username = username;
            this.password = password;
        }
       
    }
}
