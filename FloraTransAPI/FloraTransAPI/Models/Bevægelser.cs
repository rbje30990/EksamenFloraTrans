using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FloraTransAPI.Models
{
    public class Bevægelser
    {
        [Key]
        public int BID { get; set; }
        public int sendtBundramme { get; set; }
        public int sendtAntalHylder { get; set; }
        public int sendtAntalSøjlerør { get; set; }
        public string afleveretDato { get; set; }
        public string tilbagemodtagetDato { get; set; }
        
        [ForeignKey("KundeID")]
        public int KundeID { get; set; }
        public Kunder Kunde { get; set; } // foreign key

        [ForeignKey("LagerID")]
        public int LagerID { get; set; }
        public Lager Lager { get; set; } // foreign key
    }
}
