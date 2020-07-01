using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RememberMe.Models.ViewModel
{
    public class MissionsViewModel
    {
        public int id { get; set; }
        public string name{ get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string starttime { get; set; }
        public string endtime { get; set; }
        public string color { get; set; }
        public string url { get; set; }

    }
}
