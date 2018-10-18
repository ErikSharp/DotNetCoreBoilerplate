using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Services
{
    public class ContactsService : IContactsService
    {
        //private readonly IContactData contactData;

        //public ContactsService(IContactData contactData)
        //{
        //    this.contactData = contactData;
        //}
        public ContactsService()
        {

        }

        public IEnumerable<Contact> GetContacts()
        {
            return new[]
            {
                new Contact
                {
                  Id = 1,
                  First = "Erik",
                  Last = "Sharp",
                  ImageUrl = "https://i.imgur.com/SxJrbWX.jpg",
                  Description = "Unemployed Software Engineer"
                },
                new Contact
                {
                  Id = 2,
                  First = "Lynsey",
                  Last = "Sharp",
                  ImageUrl = "https://i.imgur.com/9z0eOJv.jpg",
                  Description = "Software Test Analyst"
                }
            };
        }
    }
}
