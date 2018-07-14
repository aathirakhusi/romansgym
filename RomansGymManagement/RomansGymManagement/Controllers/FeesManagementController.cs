using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RomansGymManagement.Models;

namespace RomansGymManagement.Controllers
{
    [Route("api/Fees")]
    public class FeesManagementController : ApiController
    {
        private romansgy_gymEntities db = new romansgy_gymEntities();
        // GET: api/Fees
        [ResponseType(typeof(FeesDuesModel))]
        [Route("api/Fees", Name = "GetFeesDues")]
        [HttpGet]
        public HttpResponseMessage GetFeesDues()
        {
            var feesDuesList = db.GetFeesDues().ToList();
            List<FeesDuesModel> studentsFeesDuesList = new List<FeesDuesModel>();
            foreach (var feesDues in feesDuesList)
            {
                FeesDuesModel fdm = new FeesDuesModel();
                fdm.Addres = feesDues.Addres;
                fdm.Age = feesDues.Age;
                fdm.CreatedDate = feesDues.CreatedDate;
                fdm.DeletedDate = feesDues.DeletedDate;
                fdm.FeesLastPaidDate = feesDues.FeesLastPaidDate;
                fdm.MobileNumber = feesDues.MobileNumber;
                fdm.Name = feesDues.Name;
                fdm.ParentName = feesDues.ParentName;
                fdm.Sex = feesDues.Sex;
                fdm.StudentId = feesDues.StudentId;
                fdm.TuitionFees = feesDues.TuitionFees;
                
                    var today = DateTime.Today; //
                    var lastPaidDate = DateTime.Parse(feesDues.FeesLastPaidDate != null ? feesDues.FeesLastPaidDate.ToString() : feesDues.CreatedDate.ToString());
                    var nextMonth = lastPaidDate.AddMonths(1);
                    var caldate = ((today.Year - lastPaidDate.Year) * 12) + today.Month - lastPaidDate.Month;
                    var months = MonthsBetween(nextMonth, today);
                    var items = months.Select(i => i.Item1).ToList();
                    if (caldate > 0)
                    {
                        fdm.PendingMonths = items;
                    }
                studentsFeesDuesList.Add(fdm);
            }
            studentsFeesDuesList.RemoveAll(t => t.PendingMonths == null);
            /*var itemToRemove = studentsFeesDuesList.SingleOrDefault(r => r.PendingMonths == null);
            if (itemToRemove != null)
            {
                studentsFeesDuesList.Remove(itemToRemove);
            }*/
           studentsFeesDuesList = studentsFeesDuesList.OrderByDescending(x => x.PendingMonths.Count).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, studentsFeesDuesList);
        }
        private static IEnumerable<Tuple<string, int>> MonthsBetween( DateTime startDate,  DateTime endDate)
        {
            DateTime iterator;
            DateTime limit;

            if (endDate > startDate)
            {
                iterator = new DateTime(startDate.Year, startDate.Month, 1);
                limit = endDate;
            }
            else
            {
                iterator = new DateTime(endDate.Year, endDate.Month, 1);
                limit = startDate;
            }

            var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            while (iterator <= limit)
            {
                yield return Tuple.Create(
                    dateTimeFormat.GetMonthName(iterator.Month),
                    iterator.Year);
                iterator = iterator.AddMonths(1);
            }
        }

    }
            
}