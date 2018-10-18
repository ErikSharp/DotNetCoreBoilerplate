using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IContactsService
    {
        IEnumerable<Contact> GetContacts();
    }
}
