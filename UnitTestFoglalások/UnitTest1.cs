using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using System.Configuration;
using MongoDB.Abstracts;
using Aloe.Foglalások.Models;
using Aloe.Foglalások.Models.Repository;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace UnitTestFoglalások
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Setup()
        {
            this.DropDB();
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.DropDB();
        }

        private void DropDB()
        {
            var url = new MongoUrl(ConfigurationManager.ConnectionStrings["MongoServerSettings"].ConnectionString);
            var client = new MongoClient(url);
            client.DropDatabase(url.DatabaseName);
        }

        [TestMethod]
        public void DolgozóAddAndUpdateTest()
        {
            var url = new MongoUrl(ConfigurationManager.ConnectionStrings["MongoServerSettings"].ConnectionString);
            DolgozoRepository  dolgozoRepo = new DolgozoRepository(url);

            Assert.IsNotNull(dolgozoRepo);

            var dolgozo = new Dolgozo();
            dolgozo.Név = "Janza Kata";
            dolgozo.Jelszó = "Janza Kata";
            dolgozo.Engedélyek = new List<Engedély>()
            {
                new Engedély()
                {
                    Ablak = "Belépés",
                    Olvas = true,
                    Írja = false
                },
                new Engedély()
                {
                    Ablak = "DoldozóLista",
                    Olvas = true,
                    Írja = false
                }

            };

            dolgozoRepo.Insert(dolgozo);

            Assert.IsNotNull(dolgozo);

            Assert.IsNotNull(dolgozo.Id);

            // fetch it back 
            var alreadyAddeddolgozo = dolgozoRepo.FindOne(c => c.Név == dolgozo.Név);

            Assert.IsNotNull(alreadyAddeddolgozo);
            Assert.AreEqual(dolgozo.Név, alreadyAddeddolgozo.Név);
            Assert.AreEqual(dolgozo.Engedélyek.Count, alreadyAddeddolgozo.Engedélyek.Count);

            alreadyAddeddolgozo.Név = "Megan Ray";

            dolgozoRepo.Update(alreadyAddeddolgozo);

            // fetch by id now 
            Expression<Func<Dolgozo, bool>> filter = x => x.Id == dolgozo.Id;
            var updateddolgozo = dolgozoRepo.FindOne(filter);

            Assert.IsNotNull(updateddolgozo);
            Assert.AreEqual(alreadyAddeddolgozo.Név, updateddolgozo.Név);
            
        }

        [TestMethod]
        public void MasszorAddAndUpdateTest()
        {
            var url = new MongoUrl(ConfigurationManager.ConnectionStrings["MongoServerSettings"].ConnectionString);
            MasszőrRepository masszőrRepo = new MasszőrRepository(url);

            Assert.IsNotNull(masszőrRepo);

            var masszor = new Masszor();
            masszor.Név = "Bob";

            masszőrRepo.Insert(masszor);

            // fetch it back 
            var alreadyAddedmasszor = masszőrRepo.FindOne(c => c.Név == masszor.Név);

            Assert.IsNotNull(alreadyAddedmasszor);
            Assert.AreEqual(masszor.Név, alreadyAddedmasszor.Név);
            Assert.AreEqual(masszor.Id, alreadyAddedmasszor.Id, string.Format("Kapott id:{0}", alreadyAddedmasszor.Id));

            alreadyAddedmasszor.Név = "Liu";

            masszőrRepo.Update(alreadyAddedmasszor);

            // fetch by id now http://stackoverflow.com/questions/8264935/how-to-build-an-expressionfunct-bool-from-another-expression-expressionfun
            Expression<Func<Masszor, bool>> filter = x => x.Id == alreadyAddedmasszor.Id;
            var updatedmasszor = masszőrRepo.FindOne(filter);

            Assert.IsNotNull(updatedmasszor);
            Assert.AreEqual(updatedmasszor.Név, updatedmasszor.Név);

        }

        [TestMethod]
        public void BerletTipusAddAndUpdateTest()
        {
            var url = new MongoUrl(ConfigurationManager.ConnectionStrings["MongoServerSettings"].ConnectionString);
            BerletTipusRepository repo = new BerletTipusRepository(url);

            Assert.IsNotNull(repo);

            var berletTipus = new BerletTipus();
            berletTipus.BérletNév = "Alkalmi";
            berletTipus.BérletTipus = "AKb";

            repo.Insert(berletTipus);

            // fetch it back 
            var alreadyAddedberletTipus = repo.FindOne(c => c.BérletNév == berletTipus.BérletNév);

            Assert.IsNotNull(alreadyAddedberletTipus);
            Assert.AreEqual(berletTipus.BérletNév, alreadyAddedberletTipus.BérletNév);
            Assert.AreEqual(berletTipus.Id, alreadyAddedberletTipus.Id, string.Format("Kapott id:{0}", alreadyAddedberletTipus.Id));

            alreadyAddedberletTipus.BérletTipus = "AK";

            repo.Update(alreadyAddedberletTipus);

            // fetch by id now http://stackoverflow.com/questions/8264935/how-to-build-an-expressionfunct-bool-from-another-expression-expressionfun
            Expression<Func<BerletTipus, bool>> filter = x => x.Id == alreadyAddedberletTipus.Id;
            var updatedberletTipus = repo.FindOne(filter);

            Assert.IsNotNull(updatedberletTipus);
            Assert.AreEqual(updatedberletTipus.BérletNév, updatedberletTipus.BérletNév);

        }

        [TestMethod]
        public void IdopontAddAndUpdateTest()
        {
            var url = new MongoUrl(ConfigurationManager.ConnectionStrings["MongoServerSettings"].ConnectionString);
            IdopontRepository repo = new IdopontRepository(url);

            Assert.IsNotNull(repo);

            var idopontok = new List<Idopont>
            {
                new Idopont { Idő = TimeSpan.Parse("10:00") },
                new Idopont { Idő = TimeSpan.Parse("10:15") },
                new Idopont { Idő = TimeSpan.Parse("10:30") },
                new Idopont { Idő = TimeSpan.Parse("10:45") },
                new Idopont { Idő = TimeSpan.Parse("11:00") },
                new Idopont { Idő = TimeSpan.Parse("11:15") },
                new Idopont { Idő = TimeSpan.Parse("11:30") },
                new Idopont { Idő = TimeSpan.Parse("11:45") },
                new Idopont { Idő = TimeSpan.Parse("12:00") },
                new Idopont { Idő = TimeSpan.Parse("12:15") },
                new Idopont { Idő = TimeSpan.Parse("12:30") },
                new Idopont { Idő = TimeSpan.Parse("12:45") },
                new Idopont { Idő = TimeSpan.Parse("13:00") },
                new Idopont { Idő = TimeSpan.Parse("13:15") },
                new Idopont { Idő = TimeSpan.Parse("13:30") },
                new Idopont { Idő = TimeSpan.Parse("13:45") },
                new Idopont { Idő = TimeSpan.Parse("14:00") },
                new Idopont { Idő = TimeSpan.Parse("14:15") },
                new Idopont { Idő = TimeSpan.Parse("14:30") },
                new Idopont { Idő = TimeSpan.Parse("14:45") },
                new Idopont { Idő = TimeSpan.Parse("15:00") },
                new Idopont { Idő = TimeSpan.Parse("15:15") },
                new Idopont { Idő = TimeSpan.Parse("15:30") },
                new Idopont { Idő = TimeSpan.Parse("15:45") },
                new Idopont { Idő = TimeSpan.Parse("16:00") },
                new Idopont { Idő = TimeSpan.Parse("16:15") },
                new Idopont { Idő = TimeSpan.Parse("16:30") },
                new Idopont { Idő = TimeSpan.Parse("16:45") },
                new Idopont { Idő = TimeSpan.Parse("17:00") },
                new Idopont { Idő = TimeSpan.Parse("17:15") },
                new Idopont { Idő = TimeSpan.Parse("17:30") },
                new Idopont { Idő = TimeSpan.Parse("17:45") },
                new Idopont { Idő = TimeSpan.Parse("18:00") },
                new Idopont { Idő = TimeSpan.Parse("18:15") },
                new Idopont { Idő = TimeSpan.Parse("18:30") },
                new Idopont { Idő = TimeSpan.Parse("18:45") },
                new Idopont { Idő = TimeSpan.Parse("19:00") },
                new Idopont { Idő = TimeSpan.Parse("19:15") },
                new Idopont { Idő = TimeSpan.Parse("19:30") },
                new Idopont { Idő = TimeSpan.Parse("19:45") },
                new Idopont { Idő = TimeSpan.Parse("20:00") },
                new Idopont { Idő = TimeSpan.Parse("20:15") },
                new Idopont { Idő = TimeSpan.Parse("20:30") },
                new Idopont { Idő = TimeSpan.Parse("20:45") },
                new Idopont { Idő = TimeSpan.Parse("21:00") },
                new Idopont { Idő = TimeSpan.Parse("21:15") },
                new Idopont { Idő = TimeSpan.Parse("21:30") },
                new Idopont { Idő = TimeSpan.Parse("21:45") },
                new Idopont { Idő = TimeSpan.Parse("22:00") },
                new Idopont { Idő = TimeSpan.Parse("22:15") },
                new Idopont { Idő = TimeSpan.Parse("22:30") },
                new Idopont { Idő = TimeSpan.Parse("22:45") },
                new Idopont { Idő = TimeSpan.Parse("23:00") },
            };

            repo.InsertBatch(idopontok);

            // fetch it back 
            var lista = repo.All();
            var alreadyAddedidopontok = lista.ToList();

            Assert.IsNotNull(alreadyAddedidopontok);
            Assert.AreEqual(idopontok.Count, alreadyAddedidopontok.Count);

        }
        
        [TestMethod]
        public void SzolgaltatasTipusAddAndUpdateTest()
        {
            var url = new MongoUrl(ConfigurationManager.ConnectionStrings["MongoServerSettings"].ConnectionString);
            SzolgaltatasTipusRepository repo = new SzolgaltatasTipusRepository(url);

            Assert.IsNotNull(repo);

            var szolgaltatasTipus = new List<SzolgaltatasTipus>
            {
                new SzolgaltatasTipus { TipusNév = "Talpmasszázs", RövidTipusNév = "TM" },
                new SzolgaltatasTipus { TipusNév = "Hátmasszázs", RövidTipusNév = "HM" },
                new SzolgaltatasTipus { TipusNév = "Hátmasszázs olajos", RövidTipusNév = "HMO" },
                new SzolgaltatasTipus { TipusNév = "Tradicionális Thai Masszázs", RövidTipusNév = "TTM" },
                new SzolgaltatasTipus { TipusNév = "Aromaolajos Thai Masszázs", RövidTipusNév = "ATM" },
                new SzolgaltatasTipus { TipusNév = "Svéd masszázs", RövidTipusNév = "SM" },
                new SzolgaltatasTipus { TipusNév = "Herbál Thai Masszázs", RövidTipusNév = "HTM" },
                new SzolgaltatasTipus { TipusNév = "Kombinált Talp és Tradicionális Testmasszázs", RövidTipusNév = "KTTT" },
                new SzolgaltatasTipus { TipusNév = "Kombinált Talp és Aromaolajos Testmasszázs", RövidTipusNév = "KTAT" },
                new SzolgaltatasTipus { TipusNév = "Hullámok Ölelése Szépítőfürdő", RövidTipusNév = "HÖSZ" },
                new SzolgaltatasTipus { TipusNév = "Természet Ölén Testradír", RövidTipusNév = "TÖT" },
                new SzolgaltatasTipus { TipusNév = "Infraszauna", RövidTipusNév = "ISZ" },
                new SzolgaltatasTipus { TipusNév = "Finn szauna ", RövidTipusNév = "FSZ" },
                new SzolgaltatasTipus { TipusNév = "Shiatsu masszázs", RövidTipusNév = "SM" },
                new SzolgaltatasTipus { TipusNév = "Nyirokmasszázs", RövidTipusNév = "NyM" },
                new SzolgaltatasTipus { TipusNév = "Talpreflexológia", RövidTipusNév = "TRF" },
            };

            repo.InsertBatch(szolgaltatasTipus);

            // fetch it back 
            var lista = repo.All();
            var alreadyAddedszolgaltatasTipus = lista.ToList();

            Assert.IsNotNull(alreadyAddedszolgaltatasTipus);
            Assert.AreEqual(szolgaltatasTipus.Count, alreadyAddedszolgaltatasTipus.Count);

        }
        [TestMethod]
        public void KezelésAddAndUpdateTest()
        {
            var url = new MongoUrl(ConfigurationManager.ConnectionStrings["MongoServerSettings"].ConnectionString);
            KezelesRepository repo = new KezelesRepository(url);

            Assert.IsNotNull(repo);

            var kezeles = new Kezeles();
            kezeles.Név = "Talpmasszázs";
            kezeles.RövidNév = "Tm";
            kezeles.KezelésÁrak = new List<KezelésÁr>
                {
                    new KezelésÁr
                    {
                        Tartama = "1 óra",
                        TartamaPerc = 60,
                        Ártipusa = "Teljes",
                        ÉrvényesIg = DateTime.Parse("2016.01.01"),
                        Érvényestől = DateTime.Parse("2016.12.31"),
                        Összeg = 5000
                    },
                    new KezelésÁr
                    {
                        Tartama = "1 óra",
                        TartamaPerc = 60,
                        Ártipusa = "Bérlet 5 alkal. (-10%)",
                        ÉrvényesIg = DateTime.Parse("2016.01.01"),
                        Érvényestől = DateTime.Parse("2016.12.31"),
                        Összeg = 4500,
                        BérletÖsszeg = 22500,
                        AlkalmakSzáma = 5
                    },
                    new KezelésÁr
                    {
                        Tartama = "1 óra",
                        TartamaPerc = 60,
                        Ártipusa = "Bérlet 10 alkal. (-15%)",
                        ÉrvényesIg = DateTime.Parse("2016.01.01"),
                        Érvényestől = DateTime.Parse("2016.12.31"),
                        Összeg = 4250,
                        BérletÖsszeg = 42500,
                        AlkalmakSzáma = 10
                    },
                    new KezelésÁr
                    {
                        Tartama = "1,5 óra",
                        TartamaPerc = 90,
                        Ártipusa = "Teljes",
                        ÉrvényesIg = DateTime.Parse("2016.01.01"),
                        Érvényestől = DateTime.Parse("2016.12.31"),
                        Összeg = 6500
                    },
                    new KezelésÁr
                    {
                        Tartama = "1,5 óra",
                        TartamaPerc = 90,
                        Ártipusa = "Bérlet 5 alkal. (-10%)",
                        ÉrvényesIg = DateTime.Parse("2016.01.01"),
                        Érvényestől = DateTime.Parse("2016.12.31"),
                        Összeg = 5850,
                        BérletÖsszeg = 29250,
                        AlkalmakSzáma = 5
                    },
                    new KezelésÁr
                    {
                        Tartama = "1,5 óra",
                        TartamaPerc = 90,
                        Ártipusa = "Bérlet 10 alkal. (-15%)",
                        ÉrvényesIg = DateTime.Parse("2016.01.01"),
                        Érvényestől = DateTime.Parse("2016.12.31"),
                        Összeg = 4250,
                        BérletÖsszeg = 42500,
                        AlkalmakSzáma = 10
                    }
                };

            repo.Insert(kezeles);

            // fetch it back 
            var alreadyAddedkezeles = repo.FindOne(c => c.Id == kezeles.Id);

            Assert.IsNotNull(alreadyAddedkezeles);
            Assert.AreEqual(kezeles.Név, alreadyAddedkezeles.Név);
            Assert.AreEqual(kezeles.Id, alreadyAddedkezeles.Id, string.Format("Kapott id:{0}", alreadyAddedkezeles.Id));

           /* alreadyAddedkezeles.KezelésÁrak. = "AK";

            repo.Update(alreadyAddedberletTipus);

            // fetch by id now http://stackoverflow.com/questions/8264935/how-to-build-an-expressionfunct-bool-from-another-expression-expressionfun
            Expression<Func<BerletTipus, bool>> filter = x => x.Id == alreadyAddedberletTipus.Id;
            var updatedberletTipus = repo.FindOne(filter);

            Assert.IsNotNull(updatedberletTipus);
            Assert.AreEqual(updatedberletTipus.BérletNév, updatedberletTipus.BérletNév);*/

        }
    }

}
