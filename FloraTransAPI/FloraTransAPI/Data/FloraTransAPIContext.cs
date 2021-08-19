using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FloraTransAPI.Models;

namespace FloraTransAPI.Data
{
    public class FloraTransAPIContext : DbContext
    {
        public FloraTransAPIContext (DbContextOptions<FloraTransAPIContext> options)
            : base(options)
        {
        }

        public DbSet<FloraTransAPI.Models.Kunder> Kunder { get; set; }

        public DbSet<FloraTransAPI.Models.Lager> Lager { get; set; }

        public DbSet<FloraTransAPI.Models.Bevægelser> Bevægelser { get; set; }

        public DbSet<FloraTransAPI.Models.Fejlmeldinger> Fejlmeldinger { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kunder>().HasData(
                new Kunder
                { KID = 1, navn = "Mark", email = "MarkMail@hotmail.com", jobtitel = "Landmand", telefon = "45 63 27 18", CVRNR = 436734278, adresse = "Landmarksgade 43" },
                new Kunder
                { KID = 2, navn = "John", email = "JohnMail@hotmail.com", jobtitel = "Youtuber", telefon = "Ukendt", CVRNR = 736734278, adresse = "Pcvejle 42" },
                new Kunder
                { KID = 3, navn = "Julie", email = "JulieMail@hotmail.com", jobtitel = "Forfatter", telefon = "47 43 97 98", CVRNR = 436734278, adresse = "Landmarksgade 43" }
                );

            modelBuilder.Entity<Lager>().HasData(
                new Lager
                { LID = 1, lejeDato = "16/08/2021", udløbsDato = "16/08/2022", brugsretten = 1500.49f, ledighed = true, bundramme = 1, antalhylder = 5, antalsøjlerør = 4 },
                new Lager
                { LID = 2, lejeDato = "15/03/2021", udløbsDato = "15/03/2022", brugsretten = 1500.49f, ledighed = false, bundramme = 1, antalhylder = 5, antalsøjlerør = 4 },
                new Lager
                { LID = 3, lejeDato = "03/01/2021", udløbsDato = "03/01/2022", brugsretten = 1500.49f, ledighed = false, bundramme = 1, antalhylder = 5, antalsøjlerør = 4 },
                new Lager
                { LID = 4, lejeDato = "01/01/2021", udløbsDato = "01/01/2022", brugsretten = 1500.49f, ledighed = false, bundramme = 1, antalhylder = 2, antalsøjlerør = 4 },
                new Lager
                { LID = 5, lejeDato = "01/01/2021", udløbsDato = "01/01/2022", brugsretten = 1500.49f, ledighed = false, bundramme = 0, antalhylder = 0, antalsøjlerør = 0 }
                );

            modelBuilder.Entity<Bevægelser>().HasData(
                new Bevægelser
                { BID = 1, KundeID = 1, LagerID = 4, sendtBundramme = 1, sendtAntalHylder = 5, sendtAntalSøjlerør = 4, afleveretDato = "24/04/2021", tilbagemodtagetDato = "20/05/2021" },
                new Bevægelser
                { BID = 2, KundeID = 1, LagerID = 2, sendtBundramme = 1, sendtAntalHylder = 5, sendtAntalSøjlerør = 4, afleveretDato = "05/06/2021", tilbagemodtagetDato = "05/07/2021" },
                new Bevægelser
                { BID = 3, KundeID = 2, LagerID = 2, sendtBundramme = 1, sendtAntalHylder = 3, sendtAntalSøjlerør = 4, afleveretDato = "18/08/2021", tilbagemodtagetDato = "18/09/2021" },
                new Bevægelser
                { BID = 4, KundeID = 2, LagerID = 5, sendtBundramme = 1, sendtAntalHylder = 5, sendtAntalSøjlerør = 4, afleveretDato = "18/04/2021", tilbagemodtagetDato = "18/05/2021" },
                new Bevægelser
                { BID = 5, KundeID = 3, LagerID = 3, sendtBundramme = 1, sendtAntalHylder = 5, sendtAntalSøjlerør = 4, afleveretDato = "15/08/2021", tilbagemodtagetDato = "15/09/2021" }
                );

            modelBuilder.Entity<Fejlmeldinger>().HasData(
                new Fejlmeldinger
                { FID = 2, BevægelserID = 1, HeltTabt = false, manglerBundramme = 0, manglerAntalHylder = 3, manglerAntalSøjlerør = 0 },
                new Fejlmeldinger
                { FID = 3, BevægelserID = 4, HeltTabt = true, manglerBundramme = 1, manglerAntalHylder = 5, manglerAntalSøjlerør = 4 }
                );
        }
    }
}
