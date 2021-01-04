using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deltabank.Models
{
    [Table("tblUmsatz")]
    public class Umsatz
    {
        [Key]
        public int Id { get; set; }
        [Column("KontoId")]
        public Konto Konto { get; set; }
        [Column("KundeId")]
        public Kunde Kunde { get; set; }
        public Umsatzart Umsatzart { get; set; }
        public DateTime Buchungstag { get; set; }
        public DateTime Wertstellung { get; set; }
        public string Buchungsdetails { get; set; }
        public double Betrag { get; set; }
        public double Saldo { get; set; }
    }

    public enum Umsatzart : byte
    {
        Gehalt = 0,
        Geldautomat = 1,
        Gutschrift = 2,
        Lastschrift = 3,
        Entgelt = 4,
        Überweisung = 5
    }
}
