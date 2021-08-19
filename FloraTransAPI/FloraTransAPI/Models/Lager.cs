using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FloraTransAPI.Models
{
    public class Lager
    {
        [Key]
        public int LID { get; set; }
        public string lejeDato { get; set; }
        public string udløbsDato { get; set; }
        public float brugsretten { get; set; }
        public bool ledighed { get; set; }
        public int bundramme { get; set; }
        public int antalhylder { get; set; }
        public int antalsøjlerør { get; set; }



    }
}
