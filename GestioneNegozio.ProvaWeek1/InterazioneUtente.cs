using GestioneNegozio.ProvaWeek1.Entities;
using GestioneNegozio.ProvaWeek1.Interfaces;
using GestioneNegozio.ProvaWeek1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneNegozio.ProvaWeek1
{
    public static class InterazioneUtente
    {
        static IRepositoryProdottoAlimentare repoAlimenti = new RepositoryProdottoAlimentareMock();
        static IRepositoryProdottoTecnologico repoTecnologico = new RepositoryProdottoTecnologicoMock();
        internal static void Start()
        {
            bool continua = true;
            while (continua)
            {
                int scelta = Menu();
                switch (scelta)
                {
                    case 1:
                        VisualizzaTuttiProdotti();
                        break;
                    case 2:
                        VisualizzaProdottiAlimentari();
                        break;
                    case 3:
                        VisualizzaProdottiTecnologici();
                        break;
                    case 4:
                        AggiungiProdottoT(); //aggiungere prodotto tecnologico Attenzione al codice
                        break;
                    case 5:
                        AggiungiProdottoA(); // aggiungi proddoto alimentare attenzione no codice uguale no data scadenza passata
                        break;
                    case 6:
                        CercaProdottoA(); //cerca prodotto alimentare per codice
                        break;
                    case 7:
                        CercaProdottoT(); //cerca prodotto tecnologico per marca
                        break;
                    case 8:
                        VisualizzaProdottiTNuovi();
                        break;
                    case 9:
                        VisualizzaProdottiScadenzaOggi();
                        break;
                    case 10:
                        VisualizzaProdottiAScaduti3Gg();
                        break;
                    case 0:
                        Console.WriteLine("Arrivederci");
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta errata"); 
                        break;

                }
                
            }
        }

        private static void VisualizzaProdottiAScaduti3Gg()
        {
            //uso un bool semplicemente per riportarmi al caso non ci fossero prodotti in scadenza tra 3 gg
            bool esito = false;
            var mieiProdottiA = repoAlimenti.GetAll();
            foreach (var item in mieiProdottiA)
            {
                if (item.GiorniScadenza <= 3)
                {
                    Console.WriteLine(item);
                    esito = true;
                }
            }
            if (esito == false)
            {
                Console.WriteLine("Al momento non sono prodotti in scadenza tra 3 giorni");
            }
        }

        private static void VisualizzaProdottiScadenzaOggi()
        {
            //uso un bool semplicemente per riportarmi al caso non ci fossero prodotti in scadenza oggi
            bool esito = false;
            var mieiProdottiA = repoAlimenti.GetAll();
            foreach (var item in mieiProdottiA)
            {
                if(item.GiorniScadenza == 0)
                {
                    Console.WriteLine(item);
                    esito = true;
                }
            }
            if (esito == false)
            {
                Console.WriteLine("Al momento non sono prodotti in scadenza oggi");
            }
        }

        private static void VisualizzaProdottiTNuovi()
        {
            var mieiProdottiT = repoTecnologico.GetAll();
            //uso un bool semplicemente per riportarmi al caso non ci fossero prodotti nuovi
            bool esito = false;
            foreach(var item in mieiProdottiT)
            {
                if(item.IsNuovo == true)
                {
                    Console.WriteLine(item);
                    esito = true;
                }
                
            }
            if(esito == false)
            {
                Console.WriteLine("Al momento non sono disponibili nuovi prodotti");
            }
        }

        private static void CercaProdottoT()
        {
            Console.WriteLine("Quale prodotto tecnologico vuoi vedere?Inserire marca:");
            string marca = Console.ReadLine();
            var prodottoCercato = repoTecnologico.GetByMarca(marca);
            if (prodottoCercato == null)
            {
                Console.WriteLine("Non esiste nessun prodotto con quel codice");
            }
            else
            {
                Console.WriteLine(prodottoCercato);
            }
        }

        private static void CercaProdottoA()
        {
            Console.WriteLine("Quale prodotto alimentare vuoi vedere?Inserire codice:");
            string codice= Console.ReadLine();
            var prodottoCercato = repoAlimenti.GetByCodice(codice);
            if (prodottoCercato == null)
            {
                Console.WriteLine("Non esiste nessun prodotto con quel codice");
            }
            else
            {
                Console.WriteLine(prodottoCercato);
            }
        }

        private static void AggiungiProdottoA()
        {
            //li faccio visualizzare tutti i prodotti alimentari per vedere i codici già esistenti
            VisualizzaProdottiAlimentari();
            string codice;
            do
            {
                Console.WriteLine("Inserisci un codice prodotto che non esiste già:");
                codice = Console.ReadLine();

            } while (!(repoAlimenti.GetByCodice(codice) == null));
            Console.WriteLine("Inserisci descrizione prodotto:");
            string descrizione = Console.ReadLine();
            double prezzo;
            do
            {
                Console.WriteLine("Inserisci il prezzo del codice");

            } while (!double.TryParse(Console.ReadLine(), out prezzo));
            int quantità;
            do
            {
                Console.WriteLine("Inserisci quantità del prodotto disponibile in magazzino");
            } while (!int.TryParse(Console.ReadLine(), out quantità));
            DateTime dataScadenza;
            do
            {
                Console.WriteLine("Inserisci la data di un prodotto non ancora scaduto");
            }while (!(DateTime.TryParse(Console.ReadLine(), out dataScadenza) && dataScadenza > DateTime.Now));
            ProdottoAlimentare nuovoProdottoA = new ProdottoAlimentare(codice,descrizione,prezzo,quantità,dataScadenza);

            bool esito = repoAlimenti.Aggiungi(nuovoProdottoA);
            if (esito)
            {
                Console.WriteLine("Prodotto aggiunto con successo");
            }
            else
            {
                Console.WriteLine("Mi dispiace il prodotto non è aggiunto");
            }

        }

        private static void AggiungiProdottoT()
        {
            //li faccio visualizzare tutti i prodotti tecnologici per vedere i codici già esistenti
            VisualizzaProdottiTecnologici();
            string codice;
            do
            {
                Console.WriteLine("Inserisci un codice prodotto che non esiste già:");
                codice = Console.ReadLine();

            } while (!(repoTecnologico.GetByCodice(codice) == null));
            
           
            Console.WriteLine("Inserisci descrizione prodotto:");
            string descrizione = Console.ReadLine();
            double prezzo;
            do
            {
                Console.WriteLine("Inserisci il prezzo del codice");

            } while (!double.TryParse(Console.ReadLine(), out prezzo));
            Console.WriteLine("Inserisci marca prodotto");
            string prodotto = Console.ReadLine();
            bool isUsato;
            do
            {
                Console.WriteLine("Inserisci se un prodotto è usato o meno(si:true-no:false)");
            } while (!bool.TryParse(Console.ReadLine(), out isUsato));
            ProdottoTecnologico nuovoProdottoT = new ProdottoTecnologico(codice, descrizione, prezzo, prodotto, isUsato);
            
            
            
                bool esito = repoTecnologico.Aggiungi(nuovoProdottoT);
                if (esito)
                {
                    Console.WriteLine("Prodotto aggiunto con successo");
                }
                else
                {
                    Console.WriteLine("Mi dispiace il prodotto non è aggiunto");
                }
            
            


            
        }

        private static void VisualizzaProdottiTecnologici()
        {
            var mieiProdottiT = repoTecnologico.GetAll();
            if (mieiProdottiT.Count == 0)
            {
                Console.WriteLine("Non ci sono prodotti tecnologici");
            }
            else
            {
                Console.WriteLine("Prodotti Tecnologici");
                foreach (var item in mieiProdottiT)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void VisualizzaProdottiAlimentari()
        {
            var mieiProdottiA = repoAlimenti.GetAll();
            if (mieiProdottiA.Count == 0)
            {
                Console.WriteLine("Non ci sono prodotti alimentari");
            }
            else
            {
                Console.WriteLine("Prodotti Alimentari:");
                foreach (var item in mieiProdottiA)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void VisualizzaTuttiProdotti()
        {
            var mieiProdottiA = repoAlimenti.GetAll();
            var mieiProdottiT = repoTecnologico.GetAll();
            if(mieiProdottiA.Count == 0)
            {
                Console.WriteLine("Non ci sono prodotti alimentari");
            }
            else
            {
                Console.WriteLine("Prodotti Alimentari:");
                foreach(var item in mieiProdottiA)
                {
                    Console.WriteLine(item);
                }
            }
            if(mieiProdottiT.Count == 0)
            {
                Console.WriteLine("Non ci sono prodotti tecnologici");
            }
            else
            {
                Console.WriteLine("Prodotti Tecnologici");
                foreach(var item in mieiProdottiT)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static int Menu()
        {
            Console.WriteLine("--------Menu--------");
            Console.WriteLine("1.Visualizza tutti i Prodotti");
            Console.WriteLine("2.Visualizza i prodotti alimentari");
            Console.WriteLine("3.Visualizza i prodotti tecnologici");
            Console.WriteLine("4.Aggiungere un nuovo prodotto tecnologico");
            Console.WriteLine("5.Aggiungere un nuovo prodotto alimentare");
            Console.WriteLine("6.Cerca un prodotto alimentare per codice");
            Console.WriteLine("7.Cerca un prodotto tecnologico per marca");
            Console.WriteLine("8. Visualizzare i prodotti tecnologici nuovi");
            Console.WriteLine("9. Visualizzare i prodotti alimentari in scadenza oggi");
            Console.WriteLine("10. Visualizzare i prodotti alimentari che scadono tra meno di 3 giorni");
            Console.WriteLine("\n0.Exit");

            Console.WriteLine("\n Inserisci la tua scelta:");


            int sceltaUtente;
            while (!int.TryParse(Console.ReadLine(), out sceltaUtente))
            {
                Console.WriteLine("Riprova. Devi inserire un numero");

            }
            return sceltaUtente;

        }

    }
}
