using DMSUser.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DMSUser
{
    [ServiceContract]
    public interface IUsuarios
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Usuarios", ResponseFormat = WebMessageFormat.Json)]
        Usuario CrearUser(Usuario alumnoACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Usuarios/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        Usuario ObtenerUser(string codigo);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Usuarios", ResponseFormat = WebMessageFormat.Json)]
        Usuario ModificarUser(Usuario userAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Usuarios/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarUser(string codigo);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Usuarios", ResponseFormat = WebMessageFormat.Json)]
        List<Usuario> ListarUsers();
    }
}
