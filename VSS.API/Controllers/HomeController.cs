using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VSS.API.Attributes;

namespace VSS.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            
            return View();
        }

        public ActionResult Test(string vin)
        {
            //https://carvx.jp/search/new?chassis_number=NKE165-7072856
            // https://www.carjam.co.nz/japan-history:car?chassis=

            string baseURL = "https://www.carjam.co.nz";
            string relativeURL = "/japan-history:car";
            string queryString = "?chassis=" + vin;
            string address = baseURL + relativeURL + queryString;
            string Url = address.ToLower();
            //List<UserInfo> listUserInfo = null; listUserInfo = new List<UserInfo>();
            string resultAsString = "";
            try 
            {
                using (WebClient client = new WebClient())
                {
                    //client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    //byte[] result = client.DownloadData(Url);
                    //resultAsString = System.Text.Encoding.UTF8.GetString(result);
                    //listUserInfo = JsonConvert.DeserializeObject<List<UserInfo>>(resultAsString);

                    //ServicePointManager.Expect100Continue = true;
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                    //       | SecurityProtocolType.Tls11
                    //       | SecurityProtocolType.Tls12
                    //       | SecurityProtocolType.Ssl3;
                    //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    new WebClient().DownloadData("https://ct.mob0.com/Styles/Fun.png");
                    byte[] result = client.DownloadData(Url);
                    resultAsString = System.Text.Encoding.UTF8.GetString(result);
                }
            }
            catch (Exception ex) 
            {

            }
            

            /*try
            {
                string address = "https://carvx.jp/search/new";
                string Url = address.ToLower();

                var obj = new { _csrf = "cEdxLTFqNlQAdjRUci1iZCZyPB9uBG4uPyo5FBxfeDIiMCR0ByRBEA==", chassis_number = "NKE165-7072856" };
                var jsonString = JsonConvert.SerializeObject(obj);

                NameValueCollection values = new NameValueCollection();
                values.Add("_csrf", "S3Z1VkZIV0E7RzAvBQ8DcR1DOGQZJg87BBs9b2t9GScZASAPcAYgBQ==");
                values.Add("chassis_number", "NKE165-7072856");
                //string Url = urlvalue.ToLower();

                string resultAsString = "";
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("Content-Type", "application/x-www-form-urlencoded"); // multipart/form-data
                    //byte[] result = client.UploadValues(Url, "POST", values);
                    //string ResultAuthTicket = System.Text.Encoding.UTF8.GetString(result);

                    resultAsString = client.UploadString(Url, "POST", jsonString);

                }
            }
            catch (Exception ex)
            {
            }*/
            return Content(resultAsString);
        }
    }
}
