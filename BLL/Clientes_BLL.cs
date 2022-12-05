using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
    public class Clientes_BLL : IDisposable
    {
        public void Dispose() { }
        public static List<Clientes_BE> GetSPCliente(Clientes_BE item)
        {
            List<Clientes_BE> data = null;
            using (var model = new Clientes_DAL())
            {
                data = model.GetSPCliente(item);
            }
            return data;
        }
    }
}
