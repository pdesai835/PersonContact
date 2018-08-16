using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ContactAPI.Models;
using ContactAPI.CustomFilters;

namespace ContactAPI.Controllers
{
    public class PersonContactsController : ApiController
    {
        private ContactAPIContext db = new ContactAPIContext();

        // GET: api/PersonContacts
        public IQueryable<PersonContact> GetPersonContacts()
        {
            return db.PersonContacts;
            
        }

        // GET: api/PersonContacts/5
        [ResponseType(typeof(PersonContact))]
        public HttpResponseMessage GetPersonContact(int id)
        {
            PersonContact personContact = db.PersonContacts.Find(id);
            if (personContact == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person with id: " + id + " Not Found");
            }

            return Request.CreateResponse<PersonContact>(HttpStatusCode.OK,personContact);
        }

        // PUT: api/PersonContacts/5
        [ResponseType(typeof(void))]
        [BasicAuthenticationFilter]
        public IHttpActionResult PutPersonContact(int id, PersonContact personContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personContact.Id)
            {
                return BadRequest();
            }

            db.Entry(personContact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PersonContacts
        [ResponseType(typeof(PersonContact))]
        [BasicAuthenticationFilter]
        public IHttpActionResult PostPersonContact(PersonContact personContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            db.PersonContacts.Add(personContact);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personContact.Id }, personContact);
        }

        // DELETE: api/PersonContacts/5
        [ResponseType(typeof(PersonContact))]
        [BasicAuthenticationFilter]
        public IHttpActionResult DeletePersonContact(int id)
        {
            PersonContact personContact = db.PersonContacts.Find(id);
            if (personContact == null)
            {
                return NotFound();
            }

            db.PersonContacts.Remove(personContact);
            db.SaveChanges();

            return Ok(personContact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonContactExists(int id)
        {
            return db.PersonContacts.Count(e => e.Id == id) > 0;
        }
    }
}