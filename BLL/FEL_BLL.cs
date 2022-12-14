using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class FEL_BLL : IDisposable
    {
        public void Dispose() { }
        public static List<FEL_BE> GetDatosSP(FEL_BE item)
        {
            List<FEL_BE> data = null;
            using (var model = new FEL_DAL())
            {
                data = model.GetDatosSP(item);
            }
            return data;
        }
    }
}
