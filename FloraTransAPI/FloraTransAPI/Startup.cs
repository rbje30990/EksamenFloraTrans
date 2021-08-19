using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FloraTransAPI.Data;

namespace FloraTransAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FloraTransAPI", Version = "v1" });
            });

            services.AddDbContext<FloraTransAPIContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("FloraTransAPIContext")));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FloraTransAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
/*
            modelBuilder.Entity<Kunder>().HasData(
                new Kunder
                {KID = 1, navn = "Mark", email = "MarkMail@hotmail.com", jobtitel = "Landmand", telefon = "45 63 27 18", CVRNR = 436734278, adresse = "Landmarksgade 43"},
                new Kunder
                {KID = 2, navn = "John", email = "JohnMail@hotmail.com", jobtitel = "Youtuber", telefon = "Ukendt", CVRNR = 736734278, adresse = "Pcvejle 42"},
                new Kunder
                {KID = 3, navn = "Julie", email = "JulieMail@hotmail.com", jobtitel = "Forfatter", telefon = "47 43 97 98", CVRNR = 436734278, adresse = "Landmarksgade 43"}
                );

            modelBuilder.Entity<Lager>().HasData(
                new Lager
                {CCTAG = 54324882, lejeDato = "16/08/2021", udløbsDato = "16/08/2022", brugsretten = 1500.49f, ledighed = true, bundramme = 1, antalhylder = 5, antalsøjlerør = 4},
                new Lager
                {CCTAG = 74836638, lejeDato = "15/03/2021", udløbsDato = "15/03/2022", brugsretten = 1500.49f, ledighed = false, bundramme = 1, antalhylder = 5, antalsøjlerør = 4},
                new Lager
                {CCTAG = 93638354, lejeDato = "03/01/2021", udløbsDato = "03/01/2022", brugsretten = 1500.49f, ledighed = false, bundramme = 1, antalhylder = 5, antalsøjlerør = 4},
                new Lager
                {CCTAG = 54352345, lejeDato = "01/01/2021", udløbsDato = "01/01/2022", brugsretten = 1500.49f, ledighed = false, bundramme = 1, antalhylder = 2, antalsøjlerør = 4},
                new Lager
                {CCTAG = 84352345, lejeDato = "01/01/2021", udløbsDato = "01/01/2022", brugsretten = 1500.49f, ledighed = false, bundramme = 0, antalhylder = 0, antalsøjlerør = 0}
                );

            modelBuilder.Entity<Bevægelser>().HasData(
                new Bevægelser
                {BID = 1, KundeID = 1, CCTAG = Lager.FirstOrDefault(x => x.CCTAG == 54324882), sendtBundramme = 1, sendtAntalHylder = 5, sendtAntalSøjlerør = 4, afleveretDato = "24/04/2021", tilbagemodtagetDato = "20/05/2021"},
                new Bevægelser
                {BID = 2, KID = Kunder.FirstOrDefault(x => x.KID == 1), CCTAG = Lager.FirstOrDefault(x => x.CCTAG == 74836638), sendtBundramme = 1, sendtAntalHylder = 5, sendtAntalSøjlerør = 4, afleveretDato = "05/06/2021", tilbagemodtagetDato = "05/07/2021"},
                new Bevægelser
                {BID = 3, KID = Kunder.FirstOrDefault(x => x.KID == 2), CCTAG = Lager.FirstOrDefault(x => x.CCTAG == 74836638), sendtBundramme = 1, sendtAntalHylder = 3, sendtAntalSøjlerør = 4, afleveretDato = "18/08/2021", tilbagemodtagetDato = "18/09/2021"},
                new Bevægelser
                {BID = 4, KID = Kunder.FirstOrDefault(x => x.KID == 2), CCTAG = Lager.FirstOrDefault(x => x.CCTAG == 84352345), sendtBundramme = 1, sendtAntalHylder = 5, sendtAntalSøjlerør = 4, afleveretDato = "18/04/2021", tilbagemodtagetDato = "18/05/2021"},
                new Bevægelser
                {BID = 5, KID = Kunder.FirstOrDefault(x => x.KID == 3), CCTAG = Lager.FirstOrDefault(x => x.CCTAG == 93638354), sendtBundramme = 1, sendtAntalHylder = 5, sendtAntalSøjlerør = 4, afleveretDato = "15/08/2021", tilbagemodtagetDato = "15/09/2021"}
                );

            modelBuilder.Entity<Fejlmeldinger>().HasData(
                new Fejlmeldinger
                {FID = 1, BID = Bevægelser.FirstOrDefault(x => x.BID == 1), HeltTabt = false, manglerBundramme = 0, manglerAntalHylder = 3, manglerAntalSøjlerør = 0},
                new Fejlmeldinger
                {FID = 2, BID = Bevægelser.FirstOrDefault(x => x.BID == 4), HeltTabt = true, manglerBundramme = 1, manglerAntalHylder = 5, manglerAntalSøjlerør = 4}
                );
 */
