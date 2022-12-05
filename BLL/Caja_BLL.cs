using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class Caja_BLL : IDisposable
    {
        public void Dispose() { }
        public static List<Caja_BE> GetSPCaja(Caja_BE item)
        {
            List<Caja_BE> data = null;
            using (var model = new Caja_DAL())
            {
                data = model.GetSPCaja(item);
            }
            return data;
        }
    }
}
