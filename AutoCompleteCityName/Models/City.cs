using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteCityName.Models
{
    public class City
    {
        public string description { get; set; }
        public string id { get; set; }
        public string place_id { get; set; }
        public string reference { get; set; }
        public IList<string> types { get; set; }   
    }
}