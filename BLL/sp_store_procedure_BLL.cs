using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class sp_store_procedure_BLL : IDisposable
    {
        public void Dispose() { }

        #region PROCESO ACCESOS
        public static List<Usuarios_BE> BLL_sp_usuarios(Usuarios_BE item)
        {
            List<Usuarios_BE> data = null;
            using (var model = new sp_store_procedure_DAL())
            {
                data = model.DAL_sp_usuarios(item);
            }
            return data;
        }
        public static List<Usuarios_BE> GetSPLogin(Usuarios_BE item)
        {
            List<Usuarios_BE> data = null;
            using (var model = new sp_store_procedure_DAL())
            {
                data = model.GetSPLogin(item);
            }
            return data;
        }
        public static List<Accesos_BE> GetAccesos(Accesos_BE item)
        {
            List<Accesos_BE> data = null;
            using (var model = new sp_store_procedure_DAL())
            {
                data = model.GetAccesos(item);
            }
            return data;
        }

        #endregion
    }
}
