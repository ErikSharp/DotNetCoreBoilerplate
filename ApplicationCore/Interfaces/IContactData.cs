using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IContactData
    {
        IEnumerable<Contact> GetContacts();
    }
}
