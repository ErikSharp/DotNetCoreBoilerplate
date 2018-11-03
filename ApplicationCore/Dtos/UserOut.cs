using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dtos
{
    public class UserOut
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
