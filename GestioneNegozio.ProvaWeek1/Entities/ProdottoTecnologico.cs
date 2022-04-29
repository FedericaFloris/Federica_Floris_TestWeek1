using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneNegozio.ProvaWeek1.Entities
{
    public class ProdottoTecnologico : Prodotto
    {
        public string Marca { get; set; }
        public bool IsNuovo { get; set; }

        public ProdottoTecnologico()
        {

        }

        public ProdottoTecnologico(string codice, string descrizione,double prezzo, string marca, bool isNuovo)
            :base(codice, descrizione, prezzo)
        {
            Marca = marca;
            IsNuovo = isNuovo;
        }

        public override string ToString()
        {
            return base.ToString() + $" Marca: {Marca} - E' nuovo: {IsNuovo}";
        }
    }
}
