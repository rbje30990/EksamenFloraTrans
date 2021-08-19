using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FloraTransAPI.Models
{
    public class Kunder
    {
        [Key]
        public int KID { get; set; }
        public string navn { get; set; }
        public string email { get; set; }
        public string jobtitel { get; set; }
        public string telefon { get; set; }
        public int CVRNR { get; set; }
        public string adresse { get; set; }

    }
}
