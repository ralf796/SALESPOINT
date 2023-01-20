using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class Usuarios_BLL:IDisposable
    {
        public void Dispose() { }
        public static List<Usuarios_BE> GetSPUsuario(Usuarios_BE item)
        {
            List<Usuarios_BE> data = null;
            using (var model = new Usuarios_DAL())
            {
                data = model.GetSPUsuario(item);
            }
            return data;
        }
        public static List<Usuarios_BE> GetSPLogin(Usuarios_BE item)
        {
            List<Usuarios_BE> data = null;
            using (var model = new Usuarios_DAL())
            {
                data = model.GetSPLogin(item);
            }
            return data;
        }
        public static List<Accesos_BE> GetAccesos(Accesos_BE item)
        {
            List<Accesos_BE> data = null;
            using (var model = new Usuarios_DAL())
            {
                data = model.GetAccesos(item);
            }
            return data;
        }
    }
}
