using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FloraTransAPI.Models
{
    public class Fejlmeldinger
    {
        [Key]
        public int FID { get; set; }   
        public bool HeltTabt { get; set; }
        public int manglerBundramme { get; set; }
        public int manglerAntalHylder { get; set; }
        public int manglerAntalSøjlerør { get; set; }

        [ForeignKey("BevægelserID")]
        public int BevægelserID { get; set; }
        public Bevægelser Bevægelser { get; set; } // foreign key

    }
}
