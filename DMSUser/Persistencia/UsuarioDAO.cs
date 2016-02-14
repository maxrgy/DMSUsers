using DMSUser.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DMSUser.Persistencia
{
    public class UsuarioDAO
    {
        public Usuario Crear(Usuario userACrear)
        {
            Usuario userCreado = null;
            string sql = "INSERT INTO T_usuario VALUES (@cod, @pas, @cor, @nom, @tip)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", userACrear.Codigo));
                    com.Parameters.Add(new SqlParameter("@pas", userACrear.Password));
                    com.Parameters.Add(new SqlParameter("@nom", userACrear.Nombre));
                    com.Parameters.Add(new SqlParameter("@cor", userACrear.Correo));
                    com.Parameters.Add(new SqlParameter("@tip", userACrear.Tipo));
                    com.ExecuteNonQuery();
                }
            }
            userCreado = Obtener(userACrear.Codigo);
            return userCreado;
        }
        public Usuario Obtener(string codigo)
        {
            Usuario userEncontrado = null;
            string sql = "SELECT * FROM T_usuario WHERE username=@cod";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", codigo));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            userEncontrado = new Usuario()
                            {
                                Codigo = (string)resultado["username"],
                                Password = (string)resultado["password"],
                                Nombre = (string)resultado["nombre"],
                                Correo = (string)resultado["correo"],
                                Tipo = (int)resultado["tipo"]
                            };
                        }
                    }
                }
            }
            return userEncontrado;
        }
        public Usuario Modificar(Usuario userAModificar)
        {
            Usuario userModificado = null;
            string sql = "UPDATE T_usuario SET nombre = @nom WHERE username=@cod";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", userAModificar.Codigo));
                    com.Parameters.Add(new SqlParameter("@nom", userAModificar.Nombre));
                    com.ExecuteNonQuery();
                }
            }
            userModificado = Obtener(userAModificar.Codigo);
            return userModificado;
        }


        public void Eliminar(string codigo)
        {
            string sql = "DELETE FROM T_usuario WHERE username=@cod";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", codigo));
                    com.ExecuteNonQuery();

                }
            }

        }

        public List<Usuario> ListarTodos()
        {
            List<Usuario> listaUsers = null;
            Usuario nuevo = null;
            string sql = "SELECT * FROM T_usuario";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            nuevo = new Usuario()
                            {
                                Codigo = (string)resultado["username"],
                                Nombre = (string)resultado["nombre"],
                                Correo = (string)resultado["correo"],
                                Password = (string)resultado["password"],
                                Tipo = (int)resultado["tipo"]
                            };
                            listaUsers.Add(nuevo);
                        }
                    }
                }
            }
            return listaUsers;
        }
    }
}