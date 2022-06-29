using IT_Inventory_rest_api.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IT_Invenroty_api_UnitTest
{
    public static class DbContextMocker
    {

        /// <summary>
        /// Ez a metódus létrehozza a beállításokat a DbContext-hez, létrehozzuk a DbContext példányt, hozzáadjuk az entitásokat a memoriához.
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public static Selfdev_reportingContext GetWideWorldImportersDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<Selfdev_reportingContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            var dbContext = new Selfdev_reportingContext(options);

            dbContext.Seed();

            return dbContext;
        }
    }
}
