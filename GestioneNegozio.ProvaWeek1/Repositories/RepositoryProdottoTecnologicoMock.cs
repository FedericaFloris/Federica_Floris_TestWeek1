using GestioneNegozio.ProvaWeek1.Entities;
using GestioneNegozio.ProvaWeek1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneNegozio.ProvaWeek1.Repositories
{
    public class RepositoryProdottoTecnologicoMock : IRepositoryProdottoTecnologico
    {
        private List<ProdottoTecnologico> prodottiTecnologici = new List<ProdottoTecnologico>()
        {
            new ProdottoTecnologico() { Codice = "T01", Descrizione ="Cellulare", Prezzo = 1250, Marca = "Iphone", IsNuovo= true},
            new ProdottoTecnologico() { Codice = "T02", Descrizione ="Cuffie", Prezzo = 30, Marca = "Samsung", IsNuovo= false},
            new ProdottoTecnologico() { Codice = "T03", Descrizione ="Tablet", Prezzo = 600, Marca = "Dell", IsNuovo= true}
        };

        public bool Aggiungi(ProdottoTecnologico item)
        {
            if(item == null)
            {
                return false;
            }
            prodottiTecnologici.Add(item);
            return true;
        }

        public List<ProdottoTecnologico> GetAll()
        {
            return prodottiTecnologici;
        }

        public ProdottoTecnologico GetByCodice(string codice)
        {
            foreach(var item in prodottiTecnologici)
            {
                if(item.Codice == codice)
                {
                    return item;
                }
            }
            return null;
        }

        public ProdottoTecnologico GetByMarca(string marca)
        {
            foreach (var item in prodottiTecnologici)
            {
                if (item.Marca == marca)
                {
                    return item;
                }
            }
            return null;
        }
    }  
}
