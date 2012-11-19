using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.DAO.IDAOS;
using System.Data.SqlClient;
using System.Data;
using RapidNote.Clases;

namespace RapidNote.DAO.DAOSQL
{
    public class DAOUsuario : IDAOUsuario
    {        
        public Entidad ConsultarLogin(Entidad usuario)
        {

            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "ConsultarLogin";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroCorreo = new SqlParameter("@correoUsuario", (usuario as Usuario).Correo);
                sqlcmd.Parameters.Add(parametroCorreo);
                SqlParameter parametroClave = new SqlParameter("@claveUsuario", (usuario as Usuario).Clave);
                sqlcmd.Parameters.Add(parametroClave);
                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {
                    (usuario as Usuario).Id = int.Parse(sqlrd["IDUSUARIO"].ToString());
                    (usuario as Usuario).AccesToken = sqlrd["acesstoken"].ToString();
                    (usuario as Usuario).AccesSecret = sqlrd["acesssecret"].ToString();
                }
                return usuario;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                return usuario;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }            
        }

        public void AgregarUsuario(Entidad usuario)
        {

            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "AgregarUsuario";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroCorreo = new SqlParameter("@CORREO", (usuario as Usuario).Correo);
                sqlcmd.Parameters.Add(parametroCorreo);
                SqlParameter parametroClave = new SqlParameter("@CLAVE", (usuario as Usuario).Clave);
                sqlcmd.Parameters.Add(parametroClave);
                SqlParameter parametroNombre = new SqlParameter("@NOMBRE", (usuario as Usuario).Nombre);
                sqlcmd.Parameters.Add(parametroNombre);
                SqlParameter parametroApellido = new SqlParameter("@APELLIDO", (usuario as Usuario).Apellido);
                sqlcmd.Parameters.Add(parametroApellido);
                sqlcmd.ExecuteNonQuery();



            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);

            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }

        public Entidad ListarUsuario(Entidad usuario)
        {

            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "ListarUsuario";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroCorreo = new SqlParameter("@CORREO", (usuario as Usuario).Correo);
                sqlcmd.Parameters.Add(parametroCorreo);
                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {
                    (usuario as Usuario).Id = int.Parse(sqlrd["IDUSUARIO"].ToString());
                }

                return usuario;

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                return usuario;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }

        }

        public Boolean InsertarToken(String correo, Entidad usuario)
        {
            Boolean estado = false;
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "InsertarToken";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroCorreo = new SqlParameter("@CORREO", correo);
                sqlcmd.Parameters.Add(parametroCorreo);
                SqlParameter parametroAcesstoken = new SqlParameter("@ACCESSTOKEN", (usuario as Usuario).AccesToken);
                sqlcmd.Parameters.Add(parametroAcesstoken);
                SqlParameter parametroAcesssecret = new SqlParameter("@ACCESSSECRET", (usuario as Usuario).AccesSecret);
                sqlcmd.Parameters.Add(parametroAcesssecret);
                sqlcmd.ExecuteNonQuery();
                estado = true;
                return estado;

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                return estado;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }

        }
    }
}