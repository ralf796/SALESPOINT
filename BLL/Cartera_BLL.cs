using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class Cartera_BLL:IDisposable
    {
        public void Dispose() { }
        public static List<Cartera_BE> GetDatosSP(Cartera_BE item)
        {
            List<Cartera_BE> data = null;
            using (var model = new Cartera_DAL())
            {
                data = model.GetDatosSP(item);
            }
            return data;
        }
    }
}
