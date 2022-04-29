using GestioneNegozio.ProvaWeek1.Entities;
using GestioneNegozio.ProvaWeek1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneNegozio.ProvaWeek1.Repositories
{
    public class RepositoryProdottoAlimentareMock : IRepositoryProdottoAlimentare
    {
        private List<ProdottoAlimentare> prodottiAlimentari = new List<ProdottoAlimentare>()
        {
            new ProdottoAlimentare() { Codice = "AO1", Descrizione = "Pesca", Prezzo= 1.20, QuantitaMagazzino=100, DataScadenza= new DateTime(2022,06,29) },
            new ProdottoAlimentare() { Codice = "AO2", Descrizione = "Carota", Prezzo= 0.80, QuantitaMagazzino=500, DataScadenza= new DateTime(2022,05,5) },
            new ProdottoAlimentare() { Codice = "AO3", Descrizione = "Broccolo", Prezzo= 0.30, QuantitaMagazzino=50, DataScadenza= new DateTime(2022,04,30) },
        };
        public bool Aggiungi(ProdottoAlimentare item)
        {
            if (item == null)
            {
                return false;
            }
            prodottiAlimentari.Add(item);
            return true;
        }

        public List<ProdottoAlimentare> GetAll()
        {
            return prodottiAlimentari;
        }

        public ProdottoAlimentare GetByCodice(string codice)
        {
            foreach(var item in prodottiAlimentari)
            {
                if(item.Codice == codice)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
