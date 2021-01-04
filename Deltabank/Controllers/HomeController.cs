using Deltabank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Deltabank.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Uebersicht(long kontonummer, string passwort)
        {
            Kunde kunde;
            List<Umsatz> umsaetze = new List<Umsatz>();
            Dictionary<Kunde, List<Umsatz>> data = new Dictionary<Kunde, List<Umsatz>>();

            using(SHA384 sha = SHA384Managed.Create())
            using(DeltaContext db = new DeltaContext())
            {
                byte[] b = sha.ComputeHash(Encoding.UTF8.GetBytes(passwort));
                string p = BitConverter.ToString(b).Replace("-", string.Empty).ToLower();

                kunde = db.Kunden.FirstOrDefault<Kunde>(k => k.Konto.Kontonummer == kontonummer && (k.PIN == p || k.Passwort == p)) ?? new Kunde();
                kunde.Konto = db.Konten.FirstOrDefault<Konto>(k => k.Kontonummer == kontonummer && k.Kunde.KundeId == kunde.KundeId);

                umsaetze.AddRange((from u in db.Umsaetze
                                    where u.Kunde.KundeId == kunde.KundeId
                                    orderby u.Wertstellung descending
                                    select u) ?? new List<Umsatz>().AsQueryable<Umsatz>());

                data.Add(kunde, umsaetze);
            }

            return View(data);
        }
    }
}