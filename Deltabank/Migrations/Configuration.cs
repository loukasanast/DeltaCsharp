namespace Deltabank.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using System.Security.Cryptography;
    using System.Text;
    internal sealed class Configuration : DbMigrationsConfiguration<Deltabank.Models.DeltaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Deltabank.Models.DeltaContext context)
        {
            /*string passwort = "passwort";
            string pin = "00000";

            using(SHA384 sha = SHA384.Create())
            {
                passwort = sha.ComputeHash(Encoding)
            }*/

            Kunde kunde = new Kunde()
            {
                KontoId = 1,
                Adresse = "Bauerstr 34, 90777 Berlin",
                Vorname = "Max",
                Nachname = "Mustermann",
                Passwort = "3932d5083b8904cc0ac3eb40d6196eef0556e86d9b6d1763c4cbe3aee1b50324595dc91b5cfecab5d729cde1893df768",
                PIN = "cec49d77c0fe599adfe783c4ac944709054ff46a84e250c84e240c37f779199d0414ed06fa5a7786be37fa426325c139",
                Geburtsdatum = new DateTime(1980, 11, 24)
            };

            Konto konto = new Konto()
            {
                Kunde = kunde,
                Kontonummer = 550776952,
                BLZ = 760200300,
                IBAN = "DE36760200840960955678",
                BIC = "PBNKDEFF",
                Saldo = 5155.05
            };

            Umsatz u1 = new Umsatz()
            {
                Kunde = kunde,
                Konto = konto,
                Betrag = 5436.0,
                Buchungsdetails = "Gehalt durch Arbeitgeber",
                Buchungstag = new DateTime(2016, 9, 1),
                Saldo = 5436.0,
                Umsatzart = Umsatzart.Gehalt,
                Wertstellung = new DateTime(2016, 9, 4),
            };

            Umsatz u2 = new Umsatz()
            {
                Kunde = kunde,
                Konto = konto,
                Betrag = -100.0,
                Buchungsdetails = "Geldabhebung am Geldautomat - Marienplatz, München",
                Buchungstag = new DateTime(2016, 9, 6),
                Saldo = 5336.0,
                Umsatzart = Umsatzart.Geldautomat,
                Wertstellung = new DateTime(2016, 9, 6),
            };

            Umsatz u3 = new Umsatz()
            {
                Kunde = kunde,
                Konto = konto,
                Betrag = -180.95,
                Buchungsdetails = "Lastschrift Abbuchung durch Deutche Telekom AG",
                Buchungstag = new DateTime(2016, 9, 12),
                Saldo = 5155.05,
                Umsatzart = Umsatzart.Lastschrift,
                Wertstellung = new DateTime(2016, 9, 12),
            };

            kunde.Konto = konto;

            context.Kunden.AddOrUpdate<Kunde>(
                    kunde
                );
            context.Konten.AddOrUpdate<Konto>(
                    konto
                );
            context.Umsaetze.AddOrUpdate<Umsatz>(
                    u1, u2, u3
                );
        }
    }
}
