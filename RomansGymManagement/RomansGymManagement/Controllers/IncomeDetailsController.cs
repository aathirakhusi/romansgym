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
 [Route("api/Income")]
    public class IncomeDetailsController : ApiController
    {
        private romansgy_gymEntities db = new romansgy_gymEntities();

        // GET: api/IncomeDetails
        public IQueryable<IncomeDetail> GetIncomeDetails()
        {
            return db.IncomeDetails;
        }

        // GET: api/IncomeDetails/5
        [ResponseType(typeof(IncomeDetail))]
        public IHttpActionResult GetIncomeDetail(int id)
        {
            IncomeDetail incomeDetail = db.IncomeDetails.Find(id);
            if (incomeDetail == null)
            {
                return NotFound();
            }

            return Ok(incomeDetail);
        }

        // PUT: api/IncomeDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIncomeDetail(int id, IncomeDetail incomeDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != incomeDetail.ID)
            {
                return BadRequest();
            }

            db.Entry(incomeDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomeDetailExists(id))
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

        // POST: api/IncomeDetails
        [ResponseType(typeof(IncomeDetail))]
        [Route("api/Income", Name = "InsertIncomeDetails")]
        public IHttpActionResult PostIncomeDetail(IncomeDetail incomeDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IncomeDetails.Add(incomeDetail);
            db.SaveChanges();

            return CreatedAtRoute("InsertExpenseDetails", new { id = incomeDetail.ID }, incomeDetail);
        }

        // DELETE: api/IncomeDetails/5
        [ResponseType(typeof(IncomeDetail))]
        public IHttpActionResult DeleteIncomeDetail(int id)
        {
            IncomeDetail incomeDetail = db.IncomeDetails.Find(id);
            if (incomeDetail == null)
            {
                return NotFound();
            }

            db.IncomeDetails.Remove(incomeDetail);
            db.SaveChanges();

            return Ok(incomeDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IncomeDetailExists(int id)
        {
            return db.IncomeDetails.Count(e => e.ID == id) > 0;
        }
    }
}