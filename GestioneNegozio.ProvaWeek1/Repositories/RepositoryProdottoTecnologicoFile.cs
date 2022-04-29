using GestioneNegozio.ProvaWeek1.Entities;
using GestioneNegozio.ProvaWeek1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneNegozio.ProvaWeek1.Repositories
{
    public class RepositoryProdottoTecnologicoFile : IRepositoryProdottoTecnologico
    {
        //Path --> percorso del mio file
        string path = @"C:\Users\federica.floris\Desktop\GestioneNegozio\GestioneNegozio.ProvaWeek1\Repositories\Tecnologico.txt";

        public bool Aggiungi(ProdottoTecnologico item)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{item.Codice}-{item.Descrizione}-{item.Prezzo}-{item.Marca}-{item.IsNuovo}");
            }
            return true;
        }

        public List<ProdottoTecnologico> GetAll()
        {
            List<ProdottoTecnologico> prodotti = new List<ProdottoTecnologico>();
            using (StreamReader sr = new StreamReader(path))
            {
                string contenutoFile = sr.ReadToEnd();
                if (string.IsNullOrEmpty(contenutoFile))
                {
                    return new List<ProdottoTecnologico>();
                }
                else
                {
                    var righeDelFile = contenutoFile.Split("\r\n");
                    for (int i = 0; i < righeDelFile.Length - 1; i++)
                    {
                        var campiDellaRiga = righeDelFile[i].Split("-");
                        ProdottoTecnologico p = new ProdottoTecnologico();
                        p.Codice = campiDellaRiga[0];
                        p.Descrizione = campiDellaRiga[1];
                        p.Prezzo = double.Parse(campiDellaRiga[2]);
                        p.Marca = campiDellaRiga[3];
                        p.IsNuovo = bool.Parse(campiDellaRiga[4]);
                        prodotti.Add(p);
                    }
                }
                return prodotti;
            }
        }

        public ProdottoTecnologico GetByCodice(string codice)
        {

            using (StreamReader sr = new StreamReader(path))
            {
                string contenutoFile = sr.ReadToEnd();



                
                    var righeDelFile = contenutoFile.Split("\r\n");
                    for (int i = 0; i < righeDelFile.Length; i++)
                    {
                        var campiDellaRiga = righeDelFile[i].Split("-");
                        ProdottoTecnologico p = new ProdottoTecnologico();
                        p.Codice = campiDellaRiga[0];
                        p.Descrizione = campiDellaRiga[1];
                        p.Prezzo = double.Parse(campiDellaRiga[2]);
                        p.Marca = campiDellaRiga[3];
                        p.IsNuovo = bool.Parse(campiDellaRiga[4]);
                         if (campiDellaRiga[0] == codice)
                         {
                             return p;
                         }
                    }
                    
                
                return null;
            }

        }

        public ProdottoTecnologico GetByMarca(string marca)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string contenutoFile = sr.ReadToEnd();



                var righeDelFile = contenutoFile.Split("\r\n");
                for (int i = 0; i < righeDelFile.Length; i++)
                {
                    var campiDellaRiga = righeDelFile[i].Split("-");
                    ProdottoTecnologico p = new ProdottoTecnologico();
                    p.Codice = campiDellaRiga[0];
                    p.Descrizione = campiDellaRiga[1];
                    p.Prezzo = double.Parse(campiDellaRiga[2]);
                    p.Marca = campiDellaRiga[3];
                    p.IsNuovo = bool.Parse(campiDellaRiga[4]);
                    if (campiDellaRiga[3] == marca)
                    {
                        return p;
                    }
                }
                return null;
            }
        }
    }
}
