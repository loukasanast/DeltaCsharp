using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deltabank.Models
{
    [Table("tblKunde")]
    public class Kunde
    {
        [Column("Id")]
        public int KundeId { get; set; }
        public int KontoId { get; set; }
        public Konto Konto { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Adresse { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public string PIN { get; set; }
        public string Passwort { get; set; }
    }
}
