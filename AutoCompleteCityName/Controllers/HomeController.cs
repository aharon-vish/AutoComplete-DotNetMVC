using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using AutoCompleteCityName.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AutoCompleteCityName.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult City(string id)
        {
            // we get in id a string that contains id with city name and between them we have delimiter '_'
            Char delimiter = '_';
            //split in 2 string
            String[] substrings = id.Split(delimiter);
            //array wit  2 string s
            return View(substrings);
        }
        public ActionResult SampleBook4()
        {
            return View();
        }
        //get a string from input and search from open api google map
        public JsonResult getCiteis(string startsWith)
        {         
            var url =string.Format("https://maps.googleapis.com/maps/api/place/autocomplete/json?input=+'"+startsWith+"'+&types=(cities)&components=country:il&language=en&key=AIzaSyCmGR0pWFGXLG2X4t72QYaMeOFMCjOCFKc");          
            var result = new JObject { };
            var resultList = new List<City>();
            using (var client = new WebClient())
            {
                var json = client.DownloadString(url);                                         
                 result = (JObject)JsonConvert.DeserializeObject(json);
                 if (result["status"].ToString() != "ZERO_RESULTS")
                 {               
                     foreach (var item in result)
                     {
                         try
                         {
                             // bug in api return to much duplicate element , we need jast the first one that why we break after the first 
                             resultList = item.Value.ToObject<List<City>>();
                             break;
                         }
                         catch (Exception)
                         {
                          
                         }

                     }
                 }               
            }
            //send list to dom as son 
            return Json(resultList, JsonRequestBehavior.AllowGet);
        } 
    }

}

