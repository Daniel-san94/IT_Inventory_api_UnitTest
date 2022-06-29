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
        /// A dbContext v�ltoz�ba belet�ltj�k a dbcontext szerint az adatokat. A controller v�ltoz�ba p�ld�nyos�tom a TE_LeltarControllert.
        /// A response v�ltoz�ba megh�vom a controllert, azon bel�l is a GetAll met�dust. Az assert ellen�rzi hogy a response ne legyen null �rt�k.
        /// Assert.Equal ellen�rzi hogy az itemek sz�ma egynel� e 2vel, ugyanis 2 az �sszes adatunk a mockolt adatb�zisban.
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
        /// Ez a teszt r�sz, teszteli a GetById k�r�st, aminek param�terk�nt �tadom az id-t. Majd a v�lasz visszaj�n OkObjectResult-k�nt.
        /// Az assertben ellen�rz�m, hogy az okResult ne legyen null �s hogy a visszakapott st�tusz k�d megegyezzen 200-al.
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
        /// Itt a GetById k�r�st tesztelem hib�ra, vagyis hogy notfound j�jj�n vissza v�laszk�nt. Ez�rt olyan id-t adok neki param�terk�nt ami nem l�tezik ebben a kontextusban.
        /// �gy 404-es notfoundresult st�tuszk�ddal t�r vissza. Az assert-ben ellen�rz�m, hogy a NotFoundResult v�ltoz� ne legyen null, �s hogy a NotFoundResult v�ltoz�nak
        /// a st�tusz k�dja 404 vagyis notfound legyen.
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
        /// TestGetTeLeltarByLeltariSzam met�dusban tesztelem a lelt�ri sz�mra val� lek�rdez�st. A leltariszam v�ltoz�ba megadom az egyik mockolt adatb�zisban tal�lhat� item lelt�ri sz�m�t.
        /// Megh�vom a  TE_leltarController-en bel�l l�v� GetTeLeltarbyLeltariSzam met�dust mint IActionResult.
        /// okResult v�ltoz�ban visszakapjuk a v�laszt mint OkObjectResult. Az assert-ben ellen�rz�m hogy ne legyen null az okResult �s a st�tusz k�dja legyen egyenl� 200-zal vagyik Ok-kal.
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
        /// Itt a TestGetTeLeltarByLeltariSzamNotFound tesztben, megh�vom a GetTeLeltarbyLeltariSzam met�dust �s �tadok neki egy olyan lelt�ri sz�mot,
        /// ami nem l�tezik a mockolt adatb�zisban. A NotfoundResult v�ltoz�ba belerakom a response �rt�k�t mint NotFoundResult.
        /// Az assert-ben ellen�rz�m, hogy a NotfoundResult �rt�ke vagyis st�tusz k�dja ne legyen null. Ut�na ellen�rz�m hogy a NotfoundResult st�tusz k�dja egyenl� e 404-gyel,
        /// vagyis a notfound html st�tsuz k�dj�val.
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
        /// TestGetTeLeltarBySorozatSzam met�dusban tesztelem a sorozat sz�mra val� lek�rdez�st. A sorozatszam v�ltoz�ba megadom az egyik mockolt adatb�zisban tal�lhat� item sorozat sz�m�t.
        /// Megh�vom a  TE_leltarController-en bel�l l�v� GetTeLeltarbySorozatSzam met�dust mint IActionResult.
        /// okResult v�ltoz�ban visszakapjuk a v�laszt mint OkObjectResult. Az assert-ben ellen�rz�m hogy ne legyen null az okResult �s a st�tusz k�dja legyen egyenl� 200-zal vagyik Ok-kal.
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
        /// TestGetTeLeltarBySorozatSzamNotFound tesztben, megh�vom a GetTeLeltarbySorozatSzam met�dust �s �tadok neki egy olyan sorozat sz�mot,
        /// ami nem l�tezik a mockolt adatb�zisban. A NotfoundResult v�ltoz�ba belerakom a response �rt�k�t mint NotFoundResult.
        /// Az assert-ben ellen�rz�m, hogy a NotfoundResult �rt�ke vagyis st�tusz k�dja ne legyen null. Ut�na ellen�rz�m hogy a NotfoundResult st�tusz k�dja egyenl� e 404-gyel,
        /// vagyis a notfound html st�tsuz k�dj�val.
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
        /// TestPostTeLeltar met�dusban tesztelem a Post met�dust. A request v�ltoz�ba p�ld�nyos�tom a TeLeltarDto-t �s l�trehozok egy itemet.
        /// A response v�ltoz�ba postolom a request v�ltoz� tartalm�t. Az okResult v�ltoz�ba belet�lt�m a response-t mint OkObjectResult.
        /// az assert-ben ellen�rz�m, hogy az okResult �rt�ke ne legyen null �s, hogy a st�tusz k�dja legyen egyenl� 200-zal vagyis Ok-kal.
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
                Felhasznalo = "Kiss J�zzsi",
                Csoport = "IT",
                Statusz = "Haszn�lva",
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
        /// TestPostTeLeltarBadRequest met�dusban tesztelem a Post met�dust BadRequestre. 
        /// A request v�ltoz�ba p�ld�nyos�tom a TeLeltarDto-t �s l�trehozok egy itemet rossz kontextus szerint.
        /// A response v�ltoz�ba postolom a request v�ltoz� tartalm�t. A badRequestResult v�ltoz�ba belet�lt�m a response-t mint BadRequestObjectResult.
        /// az assert-ben ellen�rz�m, hogy a badRequestResult �rt�ke ne legyen null �s, hogy a st�tusz k�dja legyen egyenl� 400-zal vagyis BadRequest-tel.
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
                Felhasznalo = "Kiss J�zzsi",
                Csoport = "IT",
                Statusz = "Haszn�lva",
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
        /// TestPutTeLeltar met�dusban tesztelem a Put k�r�st. Az id v�ltoz�ba megadom egy l�tez� item id-j�t. A requestben a m�dos�tand� mez�ket illetve �rt�keket adom meg.
        /// A response-ba megh�vom a Put met�dust �s param�terk�nt �tadom nkei az id-t �s a request v�ltoz�kat.
        /// Az okResult v�ltoz�ba belerakom a response-t mint OkResult.
        /// Az assert-ben ellen�rz�m, hogy az okResult ne legyen null �s a st�tusz k�dja legyen egyenl� 200-zal.
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
        ///  TestDeleteTeLeltar met�dusban tesztelem a Delete k�r�st. Az id v�ltoz�ba megadom egy l�tez� item id-j�t.
        /// A response-ba megh�vom a Delete met�dust �s param�terk�nt �tadom nkei az id-t.
        /// Az okResult v�ltoz�ba belerakom a response-t mint OkResult.
        /// Az assert-ben ellen�rz�m, hogy az okResult ne legyen null �s a st�tusz k�dja legyen egyenl� 200-zal.
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
        /// TestDeleteTeLeltarNotFound met�dusban tesztelem a Delete k�r�st NotFound-ra. Az id v�ltoz�ba megadom egy nem l�tez� item id-j�t.
        /// A response-ba megh�vom a Delete met�dust �s param�terk�nt �tadom nkei az id-t.
        /// A notFoundResult v�ltoz�ba belerakom a response-t mint NotFoundResult.
        /// Az assert-ben ellen�rz�m, hogy a notFoundResult ne legyen null �s a st�tusz k�dja legyen egyenl� 404-gyel.
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
