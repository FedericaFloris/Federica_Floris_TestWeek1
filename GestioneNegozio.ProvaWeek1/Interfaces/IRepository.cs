using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneNegozio.ProvaWeek1.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();

        bool Aggiungi(T item);

        T GetByCodice(string codice);
    }
}
