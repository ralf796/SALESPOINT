using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class Inventario_BLL:IDisposable
    {
        public void Dispose() { }
        public static List<Inventario_BE> GetSPInventario(Inventario_BE item)
        {
            List<Inventario_BE> data = null;
            using (var model = new Inventario_DAL())
            {
                data = model.GetSPInventario(item);
            }
            return data;
        }
        public static List<Inventario_BE> GetInventario_select(Inventario_BE item)
        {
            List<Inventario_BE> data = null;
            using (var model = new Inventario_DAL())
            {
                data = model.GetInventario_select(item);
            }
            return data;
        }
        public static List<Inventario_BE> GetInventario_delete(Inventario_BE item)
        {
            List<Inventario_BE> data = null;
            using (var model = new Inventario_DAL())
            {
                data = model.GetInventario_delete(item);
            }
            return data;
        }
    }
}
