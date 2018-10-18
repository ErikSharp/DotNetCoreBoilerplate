using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
