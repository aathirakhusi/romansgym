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
using RomansGymManagement.Models;

namespace RomansGymManagement.Controllers
{
    public class RegistrationFeesController : ApiController
    {
        private romansgy_gymEntities db = new romansgy_gymEntities();

        // GET: api/RegistrationFees
        public IQueryable<RegistrationFee> GetRegistrationFees()
        {
            return db.RegistrationFees;
        }

       
        // POST: api/RegistrationFees
        [ResponseType(typeof(RegistrationFee))]
        public IHttpActionResult PostRegistrationFee(RegistrationFee registrationFee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RegistrationFees.Add(registrationFee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = registrationFee.ID }, registrationFee);
        }

        // DELETE: api/RegistrationFees/5
        [ResponseType(typeof(RegistrationFee))]
        public IHttpActionResult DeleteRegistrationFee(int id)
        {
            RegistrationFee registrationFee = db.RegistrationFees.Find(id);
            if (registrationFee == null)
            {
                return NotFound();
            }

            db.RegistrationFees.Remove(registrationFee);
            db.SaveChanges();

            return Ok(registrationFee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegistrationFeeExists(int id)
        {
            return db.RegistrationFees.Count(e => e.ID == id) > 0;
        }
    }
}