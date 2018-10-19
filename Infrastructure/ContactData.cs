using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    public class ContactData : IContactData
    {
        private readonly ContactContext _context;

        public ContactData(ContactContext context)
        {
            _context = context;

            if (!_context.Contacts.Any())
            {
                _context.Contacts.Add(
                    new Contact
                    {
                        Id = 1,
                        First = "Erik",
                        Last = "Sharp",
                        ImageUrl = "https://i.imgur.com/SxJrbWX.jpg",
                        Description = "Unemployed Software Engineer"
                    });

                _context.Contacts.Add(
                    new Contact
                    {
                        Id = 2,
                        First = "Lynsey",
                        Last = "Sharp",
                        ImageUrl = "https://i.imgur.com/9z0eOJv.jpg",
                        Description = "Software Test Analyst"
                    });

                _context.SaveChanges();
            }
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _context.Contacts;
        }
    }
}
