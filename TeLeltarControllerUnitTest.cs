using IT_Inventory_rest_api;
using IT_Inventory_rest_api.Controller;
using IT_Inventory_rest_api.Data;
using IT_Inventory_rest_api.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace IT_Invenroty_api_UnitTest
{
    public class TeLeltarControllerUnitTest
    {

        /// <summary>
        /// A dbContext változóba beletöltjük a dbcontext szerint az adatokat. A controller változóba példányosítom a TE_LeltarControllert.
        /// A response változóba meghívom a controllert, azon belül is a GetAll metódust. Az assert ellenõrzi hogy a response ne legyen null érték.
        /// Assert.Equal ellenõrzi hogy az itemek száma egynelõ e 2vel, ugyanis 2 az összes adatunk a mockolt adatbázisban.
        /// </summary>
        [Fact]
        public void TestGetTeLeltarAll()
        {
            // Arrange
            var dbContext = DbContextMocker.GetWideWorldImportersDbContext(nameof(TestGetTeLeltarAll));
            var controller = new TE_LeltarController(dbContext);

            // Act
            var response = controller.GetAll();

            // Assert
            Assert.NotNull(response);
            var items = Assert.IsAssignableFrom<IEnumerable<TeLeltar>>(response);
            Assert.Equal(2, items.Count());

        }

        /// <summary>
        /// Ez a teszt rész, teszteli a GetById kérést, aminek paraméterként átadom az id-t. Majd a válasz visszajön OkObjectResult-ként.
        /// Az assertben ellenõrzöm, hogy az okResult ne legyen null és hogy a visszakapott státusz kód megegyezzen 200-al.
        /// </summary>

        [Fact]
        public void TestGetTeLeltarById()
        {
            // Arrange
            var dbContext = DbContextMocker.GetWideWorldImportersDbContext(nameof(TestGetTeLeltarById));
            var controller = new TE_LeltarController(dbContext);
            var id = 1;

            // Act          
            var response = controller.GetById(id) as IActionResult;
            var okResult = response as OkObjectResult;
            dbContext.Dispose();

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        /// <summary>
        /// Itt a GetById kérést tesztelem hibára, vagyis hogy notfound jöjjön vissza válaszként. Ezért olyan id-t adok neki paraméterként ami nem létezik ebben a kontextusban.
        /// Így 404-es notfoundresult státuszkóddal tér vissza. Az assert-ben ellenõrzöm, hogy a NotFoundResult változó ne legyen null, és hogy a NotFoundResult változónak
        /// a státusz kódja 404 vagyis notfound legyen.
        /// </summary>

        [Fact]
        public void TestGetTeLeltarByIdNotFound()
        {
            // Arrange
            var dbContext = DbContextMocker.GetWideWorldImportersDbContext(nameof(TestGetTeLeltarByIdNotFound));
            var controller = new TE_LeltarController(dbContext);
            var id = 5;

            //Act
            var response = controller.GetById(id) as IActionResult;
            var NotfoundResult = response as NotFoundResult;

            dbContext.Dispose();

            // Assert
            Assert.NotNull(NotfoundResult);
            Assert.Equal(404, NotfoundResult.StatusCode);
        }

        /// <summary>
        /// TestGetTeLeltarByLeltariSzam metódusban tesztelem a leltári számra való lekérdezést. A leltariszam változóba megadom az egyik mockolt adatbázisban található item leltári számát.
        /// Meghívom a  TE_leltarController-en belül lévõ GetTeLeltarbyLeltariSzam metódust mint IActionResult.
        /// okResult változóban visszakapjuk a választ mint OkObjectResult. Az assert-ben ellenõrzöm hogy ne legyen null az okResult és a státusz kódja legyen egyenlõ 200-zal vagyik Ok-kal.
        /// </summary>

        [Fact]
        public void TestGetTeLeltarByLeltariSzam()
        {
            // Arrange
            var dbContext = DbContextMocker.GetWideWorldImportersDbContext(nameof(TestGetTeLeltarByLeltariSzam));
            var controller = new TE_LeltarController(dbContext);
            var leltariszam = "IT-000624";

            //Act
            var response = controller.GetTeLeltarbyLeltariSzam(leltariszam) as IActionResult;
            var okResult = response as OkObjectResult;

            dbContext.Dispose();

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        /// <summary>
        /// Itt a TestGetTeLeltarByLeltariSzamNotFound tesztben, meghívom a GetTeLeltarbyLeltariSzam metódust és átadok neki egy olyan leltári számot,
        /// ami nem létezik a mockolt adatbázisban. A NotfoundResult változóba belerakom a response értékét mint NotFoundResult.
        /// Az assert-ben ellenõrzöm, hogy a NotfoundResult értéke vagyis státusz kódja ne legyen null. Utána ellenõrzöm hogy a NotfoundResult státusz kódja egyenlõ e 404-gyel,
        /// vagyis a notfound html státsuz kódjával.
        /// </summary>

        [Fact]
        public void TestGetTeLeltarByLeltariSzamNotFound()
        {
            // Arrange
            var dbContext = DbContextMocker.GetWideWorldImportersDbContext(nameof(TestGetTeLeltarByLeltariSzamNotFound));
            var controller = new TE_LeltarController(dbContext);
            var leltariszam = "IT-00550624";

            //Act
            var response = controller.GetTeLeltarbyLeltariSzam(leltariszam) as IActionResult;
            var NotfoundResult = response as NotFoundResult;

            dbContext.Dispose();

            // Assert
            Assert.NotNull(NotfoundResult);
            Assert.Equal(404, NotfoundResult.StatusCode);
        }

        /// <summary>
        /// TestGetTeLeltarBySorozatSzam metódusban tesztelem a sorozat számra való lekérdezést. A sorozatszam változóba megadom az egyik mockolt adatbázisban található item sorozat számát.
        /// Meghívom a  TE_leltarController-en belül lévõ GetTeLeltarbySorozatSzam metódust mint IActionResult.
        /// okResult változóban visszakapjuk a választ mint OkObjectResult. Az assert-ben ellenõrzöm hogy ne legyen null az okResult és a státusz kódja legyen egyenlõ 200-zal vagyik Ok-kal.
        /// </summary>

        [Fact]
        public void TestGetTeLeltarBySorozatSzam()
        {
            // Arrange
            var dbContext = DbContextMocker.GetWideWorldImportersDbContext(nameof(TestGetTeLeltarBySorozatSzam));
            var controller = new TE_LeltarController(dbContext);
            var sorozatszam = "000455676";

            //Act
            var response = controller.GetTeLeltarbySorozatSzam(sorozatszam) as IActionResult;
            var okResult = response as OkObjectResult;

            dbContext.Dispose();

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        /// <summary>
        /// TestGetTeLeltarBySorozatSzamNotFound tesztben, meghívom a GetTeLeltarbySorozatSzam metódust és átadok neki egy olyan sorozat számot,
        /// ami nem létezik a mockolt adatbázisban. A NotfoundResult változóba belerakom a response értékét mint NotFoundResult.
        /// Az assert-ben ellenõrzöm, hogy a NotfoundResult értéke vagyis státusz kódja ne legyen null. Utána ellenõrzöm hogy a NotfoundResult státusz kódja egyenlõ e 404-gyel,
        /// vagyis a notfound html státsuz kódjával.
        /// </summary>

        [Fact]
        public void TestGetTeLeltarBySorozatSzamNotFound()
        {
            // Arrange
            var dbContext = DbContextMocker.GetWideWorldImportersDbContext(nameof(TestGetTeLeltarBySorozatSzamNotFound));
            var controller = new TE_LeltarController(dbContext);
            var sorozatszam = "0044455676";

            //Act
            var response = controller.GetTeLeltarbySorozatSzam(sorozatszam) as IActionResult;
            var NotfoundResult = response as NotFoundResult;

            dbContext.Dispose();

            // Assert
            Assert.NotNull(NotfoundResult);
            Assert.Equal(404, NotfoundResult.StatusCode);
        }

        /// <summary>
        /// TestPostTeLeltar metódusban tesztelem a Post metódust. A request változóba példányosítom a TeLeltarDto-t és létrehozok egy itemet.
        /// A response változóba postolom a request változó tartalmát. Az okResult változóba beletöltöm a response-t mint OkObjectResult.
        /// az assert-ben ellenõrzöm, hogy az okResult értéke ne legyen null és, hogy a státusz kódja legyen egyenlõ 200-zal vagyis Ok-kal.
        /// </summary>

        [Fact]
        public void TestPostTeLeltar()
        {
            // Arrange
            var dbContext = DbContextMocker.GetWideWorldImportersDbContext(nameof(TestPostTeLeltar));
            var controller = new TE_LeltarController(dbContext);
            var request = new TeLeltarDto
            {
                Nev = "Suf-host",
                Hely = "IT",
                Felhasznalo = "Kiss Józzsi",
                Csoport = "IT",
                Statusz = "Használva",
                Tipusok = "Surface 7",
                Gyarto = "Microsoft",
                Modell = "5",
                Sorozatszam = "000455676",
                LeltariSzam = "IT-000624"
            };

            // Act
            var response = controller.Post(request) as IActionResult;
            var okResult = response as OkObjectResult;

            dbContext.Dispose();

            // Assert

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        /// <summary>
        /// TestPostTeLeltarBadRequest metódusban tesztelem a Post metódust BadRequestre. 
        /// A request változóba példányosítom a TeLeltarDto-t és létrehozok egy itemet rossz kontextus szerint.
        /// A response változóba postolom a request változó tartalmát. A badRequestResult változóba beletöltöm a response-t mint BadRequestObjectResult.
        /// az assert-ben ellenõrzöm, hogy a badRequestResult értéke ne legyen null és, hogy a státusz kódja legyen egyenlõ 400-zal vagyis BadRequest-tel.
        /// </summary>

        [Fact]
        public void TestPostTeLeltarBadRequest()
        {
            // Arrange
            var dbContext = DbContextMocker.GetWideWorldImportersDbContext(nameof(TestPostTeLeltarBadRequest));
            var controller = new TE_LeltarController(dbContext);
            var request = new TeLeltarDto
            {
                //Nid = 401,
                Nev = null,
                Hely = "IT",
                Felhasznalo = "Kiss Józzsi",
                Csoport = "IT",
                Statusz = "Használva",
                Tipusok = "Surface 7",
                Gyarto = "",
                Modell = "5",
                Sorozatszam = "000455676",
                LeltariSzam = "IT-000624"
            };

            // Act
            controller.ModelState.AddModelError("Nev", "Required");
            var response = controller.Post(request) as IActionResult;
            var badRequestResult = response as BadRequestObjectResult;

            dbContext.Dispose();

            // Assert  
            Assert.NotNull(badRequestResult.StatusCode);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        /// <summary>
        /// TestPutTeLeltar metódusban tesztelem a Put kérést. Az id változóba megadom egy létezõ item id-ját. A requestben a módosítandó mezõket illetve értékeket adom meg.
        /// A response-ba meghívom a Put metódust és paraméterként átadom nkei az id-t és a request változókat.
        /// Az okResult változóba belerakom a response-t mint OkResult.
        /// Az assert-ben ellenõrzöm, hogy az okResult ne legyen null és a státusz kódja legyen egyenlõ 200-zal.
        /// </summary>

        [Fact]
        public void TestPutTeLeltar()
        {
            // Arrange
            var dbContext = DbContextMocker.GetWideWorldImportersDbContext(nameof(TestPutTeLeltar));
            var controller = new TE_LeltarController(dbContext);
            var id = 1;
            var request = new TeLeltarDto
            {
                Nev = "Suf-host",
                LeltariSzam = "IT-007624"

            };

            // Act
            var response = controller.Put(id, request) as IActionResult;
            var okResult = response as OkResult;

            dbContext.Dispose();

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        /// <summary>
        ///  TestDeleteTeLeltar metódusban tesztelem a Delete kérést. Az id változóba megadom egy létezõ item id-ját.
        /// A response-ba meghívom a Delete metódust és paraméterként átadom nkei az id-t.
        /// Az okResult változóba belerakom a response-t mint OkResult.
        /// Az assert-ben ellenõrzöm, hogy az okResult ne legyen null és a státusz kódja legyen egyenlõ 200-zal.
        /// </summary>

        [Fact]
        public void TestDeleteTeLeltar()
        {
            // Arrange
            var dbContext = DbContextMocker.GetWideWorldImportersDbContext(nameof(TestDeleteTeLeltar));
            var controller = new TE_LeltarController(dbContext);
            var id = 1;

            // Act
            var response = controller.Delete(id) as IActionResult;
            var okResult = response as OkResult;

            dbContext.Dispose();

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        /// <summary>
        /// TestDeleteTeLeltarNotFound metódusban tesztelem a Delete kérést NotFound-ra. Az id változóba megadom egy nem létezõ item id-ját.
        /// A response-ba meghívom a Delete metódust és paraméterként átadom nkei az id-t.
        /// A notFoundResult változóba belerakom a response-t mint NotFoundResult.
        /// Az assert-ben ellenõrzöm, hogy a notFoundResult ne legyen null és a státusz kódja legyen egyenlõ 404-gyel.
        /// </summary>

        [Fact]
        public void TestDeleteTeLeltarNotFound()
        {
            // Arrange
            var dbContext = DbContextMocker.GetWideWorldImportersDbContext(nameof(TestDeleteTeLeltarNotFound));
            var controller = new TE_LeltarController(dbContext);
            var id = 5;

            // Act
            var response = controller.Delete(id) as IActionResult;
            var notFoundResult = response as NotFoundResult;

            dbContext.Dispose();

            // Assert
            Assert.NotNull(notFoundResult);
            Assert.Equal(404, notFoundResult.StatusCode);
        }
    }
}
