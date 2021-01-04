using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deltabank.Models
{
    [Table("tblKonto")]
    public class Konto
    {
        [Column("Id")]
        [Key, ForeignKey("Kunde")]
        public int KontoId { get; set; }
        public Kunde Kunde { get; set; }
        public List<Umsatz> Umsaetze { get; set; }
        public long Kontonummer { get; set; }
        public long BLZ { get; set; }
        public string IBAN { get; set; }
        public string BIC { get; set; }
        public double Saldo { get; set; }
    }
}
