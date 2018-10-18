using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsService contactsService;

        public ContactsController(ContactsService contactsService)
        {
            this.contactsService = contactsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> Get()
        {
            return contactsService.GetContacts().ToList();
        }
    }
}