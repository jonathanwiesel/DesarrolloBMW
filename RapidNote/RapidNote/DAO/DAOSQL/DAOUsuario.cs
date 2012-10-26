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
    }
}