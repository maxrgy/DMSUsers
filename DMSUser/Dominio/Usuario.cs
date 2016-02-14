using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DMSUser.Dominio
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Correo { get; set; }
        [DataMember]
        public int Tipo { get; set; }
    }
}