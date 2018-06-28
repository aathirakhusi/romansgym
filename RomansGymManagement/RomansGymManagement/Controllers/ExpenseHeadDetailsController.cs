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
    [Route("api/Expense")]
    public class ExpenseHeadDetailsController : ApiController
    {
        private romansgy_gymEntities db = new romansgy_gymEntities();

        // GET: api/ExpenseHeadDetails
        public IQueryable<ExpenseHeadDetail> GetExpenseHeadDetails()
        {
            return db.ExpenseHeadDetails;
        }

        // GET: api/ExpenseHeadDetails/5
        [ResponseType(typeof(ExpenseHeadDetail))]
        public IHttpActionResult GetExpenseHeadDetail(int id)
        {
            ExpenseHeadDetail expenseHeadDetail = db.ExpenseHeadDetails.Find(id);
            if (expenseHeadDetail == null)
            {
                return NotFound();
            }

            return Ok(expenseHeadDetail);
        }

        // PUT: api/ExpenseHeadDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExpenseHeadDetail(int id, ExpenseHeadDetail expenseHeadDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expenseHeadDetail.ID)
            {
                return BadRequest();
            }

            db.Entry(expenseHeadDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseHeadDetailExists(id))
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

        // POST: api/ExpenseHeadDetails
        [ResponseType(typeof(ExpenseHeadDetail))]
        [Route("api/Expense", Name = "InsertExpenseDetails")]
        public IHttpActionResult PostExpenseHeadDetail(ExpenseHeadDetail expenseHeadDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExpenseHeadDetails.Add(expenseHeadDetail);
            db.SaveChanges();

            return CreatedAtRoute("InsertExpenseDetails", new { id = expenseHeadDetail.ID }, expenseHeadDetail);
        }
        [Route("api/Expense/getLiju")]
        [ResponseType(typeof(ExpenseHeadDetail))]
        public string GetExpenseHeadDetail()
        {
            string liju = "liju";
            return liju;
        }


        // DELETE: api/ExpenseHeadDetails/5
        [ResponseType(typeof(ExpenseHeadDetail))]
        [Route("api/Expense/{id:int}")]
        public IHttpActionResult DeleteExpenseHeadDetail(int id)
        {
            ExpenseHeadDetail expenseHeadDetail = db.ExpenseHeadDetails.Find(id);
            if (expenseHeadDetail == null)
            {
                return NotFound();
            }

            db.ExpenseHeadDetails.Remove(expenseHeadDetail);
            db.SaveChanges();

            return Ok(expenseHeadDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExpenseHeadDetailExists(int id)
        {
            return db.ExpenseHeadDetails.Count(e => e.ID == id) > 0;
        }
    }
}