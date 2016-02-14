using DMSUser.Dominio;
using DMSUser.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DMSUser
{
    public class Usuarios : IUsuarios
    {
        private UsuarioDAO dao = new UsuarioDAO();

        public Usuario CrearUser(Usuario userACrear)
        {
            return dao.Crear(userACrear);
        }

        public void EliminarUser(string codigo)
        {
            dao.Eliminar(codigo);
        }

        public List<Usuario> ListarUsers()
        {
            return dao.ListarTodos();
        }

        public Usuario ModificarUser(Usuario userAModificar)
        {
            return dao.Modificar(userAModificar);
        }

        public Usuario ObtenerUser(string codigo)
        {
            Usuario userObtenido = dao.Obtener(codigo);
            if (userObtenido == null)
            {
                throw new System.ServiceModel.Web.WebFaultException<string>(
                    "Usuario no existe en el sistema. Intente otra vez.", HttpStatusCode.InternalServerError);
            }
            return userObtenido;
        }
    }
}
