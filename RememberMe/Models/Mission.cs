using RememberMe.Models._ModelDefs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RememberMe.Models
{
    public class Mission : DbObject
    {
        //Karakter ayarlamaları vs yapabilirdim de 20 dk gibi kısıtlı sürem var :-) üşendim
        public string Content { get; set; }
        public bool Status { get; set; }
        public DateTime MissionDate { get; set; }
    }
}
