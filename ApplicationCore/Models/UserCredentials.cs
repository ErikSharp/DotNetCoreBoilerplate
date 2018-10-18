using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class UserCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"UserName: {this.Username}, Password: {this.Password}";
        }
    }
}
