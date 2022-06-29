using IT_Inventory_rest_api.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace IT_Invenroty_api_UnitTest
{
    public static class DbContextExtension
    {
        /// <summary>
        /// A mockolt adatbázist a Seed tölti fel adatokkal.
        /// </summary>
        /// <param name="dbContext"></param>
        public static void Seed(this Selfdev_reportingContext dbContext)
        {
            dbContext.TeLeltars.Add(new TeLeltar
            {
                Nev = "Suf-host",
                Hely = "IT",
                Felhasznalo = "Kiss Pista",
                Csoport = "IT",
                Statusz = "Használva",
                Tipusok = "Surface 7",
                Gyarto = "Microsoft",
                Modell = "5",
                Sorozatszam = "000455676",
                LeltariSzam = "IT-000624"
            });
            dbContext.TeLeltars.Add(new TeLeltar
            {
                Nev = "Suf-host2",
                Hely = "IT2",
                Felhasznalo = "Kiss Pist2a",
                Csoport = "IT",
                Statusz = "Használva2",
                Tipusok = "Surface 5",
                Gyarto = "Microsoft",
                Modell = "4",
                Sorozatszam = "000455676",
                LeltariSzam = "IT-000624"
            });
            dbContext.SaveChanges();
        }
    }
}
