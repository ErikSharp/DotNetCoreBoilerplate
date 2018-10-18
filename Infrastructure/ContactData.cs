using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class ContactData : IContactData
    {
        public IEnumerable<Contact> Contacts => throw new NotImplementedException();
    }
}
