using GestioneNegozio.ProvaWeek1.Entities;
using GestioneNegozio.ProvaWeek1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneNegozio.ProvaWeek1.Repositories
{
    internal class RepositoryProdottoAlimentareFile : IRepositoryProdottoAlimentare
    {
        string path = @"C:\Users\federica.floris\Desktop\GestioneNegozio\GestioneNegozio.ProvaWeek1\Repositories\Alimenti.txt";
        public bool Aggiungi(ProdottoAlimentare item)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{item.Codice}-{item.Descrizione}-{item.Prezzo}-{item.QuantitaMagazzino}-{item.DataScadenza}-{item.GiorniScadenza}");
            }
            return true;
        }

        public List<ProdottoAlimentare> GetAll()
        {
            List<ProdottoAlimentare> prodotti = new List<ProdottoAlimentare>();
            using (StreamReader sr = new StreamReader(path))
            {
                string contenutoFile = sr.ReadToEnd();
                if (string.IsNullOrEmpty(contenutoFile))
                {
                    return new List<ProdottoAlimentare>();
                }
                else
                {
                    var righeDelFile = contenutoFile.Split("\r\n");
                    for (int i = 0; i < righeDelFile.Length - 1; i++)
                    {
                        var campiDellaRiga = righeDelFile[i].Split("-");
                        ProdottoAlimentare p = new ProdottoAlimentare();
                        p.Codice = campiDellaRiga[0];
                        p.Descrizione = campiDellaRiga[1];
                        p.Prezzo = double.Parse(campiDellaRiga[2]);
                        p.QuantitaMagazzino = int.Parse(campiDellaRiga[3]);
                        p.DataScadenza = DateTime.Parse(campiDellaRiga[4]);
                        prodotti.Add(p);
                    }
                }
                return prodotti;
            }
        }

        public ProdottoAlimentare GetByCodice(string codice)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string contenutoFile = sr.ReadToEnd();



                var righeDelFile = contenutoFile.Split("\r\n");
                for (int i = 0; i < righeDelFile.Length; i++)
                {
                    var campiDellaRiga = righeDelFile[i].Split("-");
                    ProdottoAlimentare p = new ProdottoAlimentare();
                    p.Codice = campiDellaRiga[0];
                    p.Descrizione = campiDellaRiga[1];
                    p.Prezzo = double.Parse(campiDellaRiga[2]);
                    p.QuantitaMagazzino = int.Parse(campiDellaRiga[3]);
                    p.DataScadenza = DateTime.Parse(campiDellaRiga[4]);
                    if (campiDellaRiga[0] == codice)
                    {
                        return p;
                    }
                }
                return null;
            }
        }
    }
}
