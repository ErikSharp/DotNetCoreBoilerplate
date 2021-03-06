﻿using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IContactData contactData;

        public ContactsService(IContactData contactData)
        {
            this.contactData = contactData;
        }

        public IEnumerable<Contact> GetContacts()
        {
            return contactData.GetContacts();
        }
    }
}
