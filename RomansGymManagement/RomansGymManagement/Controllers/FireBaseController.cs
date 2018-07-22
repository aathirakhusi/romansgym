using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Script.Serialization;
using RomansGymManagement.Models;
using System.Runtime.Serialization.Json;

namespace RomansGymManagement.Controllers
{
    [Route("api/Notification")]
    public class FireBaseController : ApiController
    {
        private romansgy_gymEntities db = new romansgy_gymEntities();
       [Route("api/Notification/{bodyText}/{titleText}")]
       [HttpGet]
       public void Notification(string bodyText, string titleText)     
        {
            var fcmIds = db.GetFCMIds().ToList();
            foreach (var fcmId in fcmIds)
            {
                string webAddr = "https://fcm.googleapis.com/fcm/send";
                string toKey = fcmId;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "key=AIzaSyCr5KFHclGsD4nskD3tezljqEzCZDtV_kQ");
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string jsonTemp = "{ \"to\" : \"ph0\",\"data\" : {\"body\" : \"ph1\",\"title\": \"ph2\"}}";
                    string jsonTemp1 = jsonTemp.Replace("ph1", bodyText);
                    string jsonTemp2 = jsonTemp1.Replace("ph2", titleText);
                    string json = jsonTemp2.Replace("ph0", toKey);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string str = httpResponse.StatusDescription;

            }            
        }

       // POST: api/Notification
        [ResponseType(typeof(DeviceNotification))]
        [Route("api/Notification", Name = "UpsertDeviceNotification")]
        [HttpPost]
       public IHttpActionResult PostDeviceNotification(DeviceNotification deviceNotificationModel)
       {
           var result = db.UpsertDeviceNotification(deviceNotificationModel.DeviceId, deviceNotificationModel.FCMRegistrationID);
           return CreatedAtRoute("UpsertDeviceNotification", new { id = deviceNotificationModel.DeviceId }, deviceNotificationModel);
       }

        // DELETE: api/Notification
        [ResponseType(typeof(DeviceNotification))]
        [Route("api/Notification/{deviceId}")]
        [HttpDelete]
        public HttpResponseMessage DeleteExpenseHeadDetail(string deviceId)
        {
            var result = db.DeleteDeviceNotification(deviceId);
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }
    }
}
