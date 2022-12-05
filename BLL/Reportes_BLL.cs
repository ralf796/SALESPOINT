using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class Reportes_BLL : IDisposable
    {
        public void Dispose() { }
        public static List<Reportes_BE> GetSPReportes(Reportes_BE item)
        {
            List<Reportes_BE> data = null;
            using (var model = new Reportes_DAL())
            {
                data = model.GetSPReportes(item);
            }
            return data;
        }
    }
}
