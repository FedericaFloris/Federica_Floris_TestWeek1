using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneNegozio.ProvaWeek1.Entities
{
    public class ProdottoAlimentare : Prodotto
    {
        public int QuantitaMagazzino { get; set; }
        public DateTime DataScadenza { get; set; }
        public int GiorniScadenza { get { return CalcoloScadenza(); } }

        public ProdottoAlimentare()
        {

        }

        public ProdottoAlimentare(string codice, string descrizione, double prezzo, int quantitaMagazzino,DateTime dataScadenza)
            :base(codice,descrizione,prezzo)
        {
            QuantitaMagazzino = quantitaMagazzino;
            DataScadenza = dataScadenza;
        }

        private int CalcoloScadenza()
        {
            return (DataScadenza - DateTime.Today).Days; //mi restituisce i giorni mancanti
        }

        public override string ToString()
        {
            return base.ToString() + $" Quantità: {QuantitaMagazzino} - Data scadenza: {DataScadenza.ToShortDateString().ToString()} - Giorni alla Scadenza: {GiorniScadenza}";
        }
    }
}
