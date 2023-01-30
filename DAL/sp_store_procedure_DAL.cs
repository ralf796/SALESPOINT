using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class sp_store_procedure_DAL : IDisposable
    {
        public void Dispose() { }

        public List<Usuarios_BE> DAL_sp_usuarios(Usuarios_BE item)
        {
            List<Usuarios_BE> result = new List<Usuarios_BE>();
            using (var model = new Base_SQL("sp_usuario"))
            {
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                model.Command.Parameters.AddWithValue("@PRIMER_NOMBRE", item.PRIMER_NOMBRE);
                model.Command.Parameters.AddWithValue("@SEGUNDO_NOMBRE", item.SEGUNDO_NOMBRE);
                model.Command.Parameters.AddWithValue("@PRIMER_APELLIDO", item.PRIMER_APELLIDO);
                model.Command.Parameters.AddWithValue("@SEGUNDO_APELLIDO", item.SEGUNDO_APELLIDO);
                model.Command.Parameters.AddWithValue("@DIRECCION", item.DIRECCION);
                model.Command.Parameters.AddWithValue("@ID_TIPO_EMPLEADO", item.ID_TIPO_EMPLEADO);
                model.Command.Parameters.AddWithValue("@TELEFONO", item.TELEFONO);
                model.Command.Parameters.AddWithValue("@EMAIL", item.EMAIL);
                model.Command.Parameters.AddWithValue("@URL_FOTO", item.PATH);
                model.Command.Parameters.AddWithValue("@USUARIO", item.USUARIO);
                model.Command.Parameters.AddWithValue("@PASSWORD", item.PASSWORD);
                model.Command.Parameters.AddWithValue("@CREADO_POR", item.CREADO_POR);
                model.Command.Parameters.AddWithValue("@ID_EMPLEADO", item.ID_EMPLEADO);
                model.Command.Parameters.AddWithValue("@ID_ROL", item.ID_ROL);
                model.Command.Parameters.AddWithValue("@LINK_DEFAULT", item.URL_PANTALLA);
                result = model.GetData<Usuarios_BE>();
            }
            return result;
        }

        public List<Usuarios_BE> GetSPLogin(Usuarios_BE item)
        {
            List<Usuarios_BE> result = new List<Usuarios_BE>();
            using (var model = new Base_SQL("sp_login"))
            {
                model.Command.Parameters.AddWithValue("@USUARIO", item.USUARIO);
                model.Command.Parameters.AddWithValue("@PASSWORD", item.PASSWORD);
                model.Command.Parameters.AddWithValue("@CORREO", item.EMAIL);
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                result = model.GetData<Usuarios_BE>();
            }
            return result;
        }
        public List<Accesos_BE> GetAccesos(Accesos_BE item)
        {
            List<Accesos_BE> result = new List<Accesos_BE>();
            using (var model = new Base_SQL("sp_login"))
            {
                model.Command.Parameters.AddWithValue("@USUARIO", item.USUARIO);
                model.Command.Parameters.AddWithValue("@PASSWORD", item.PASSWORD);
                model.Command.Parameters.AddWithValue("@CORREO", item.EMAIL);
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                result = model.GetData<Accesos_BE>();
            }
            return result;
        }
    }
}
