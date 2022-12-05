using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class Ventas__BLL:IDisposable
    {
        public void Dispose() { }
        public static List<Ventas__BE> GetDatosSP(Ventas__BE item)
        {
            List<Ventas__BE> data = null;
            using (var model = new Ventas__DAL())
            {
                data = model.GetDatosSP(item);
            }
            return data;
        }
    }
}
