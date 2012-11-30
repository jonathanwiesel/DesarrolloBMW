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
    public class DAOLibreta : IDAOLibreta
    {
        public Boolean AgregarLibreta(Entidad libreta, Entidad usuario)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            Boolean estado = false;
            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "AgregarLibreta";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroCorreo = new SqlParameter("@CORREO", (usuario as Usuario).Correo);
                sqlcmd.Parameters.Add(parametroCorreo);
                SqlParameter parametroNombre = new SqlParameter("@NOMBRE", (libreta as Libreta).NombreLibreta);
                sqlcmd.Parameters.Add(parametroNombre);
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

        public Entidad VerificarLibreta(Entidad libreta, Entidad usuario)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "VerificarLibreta";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroNombre = new SqlParameter("@NOMBRE", (libreta as Libreta).NombreLibreta);
                sqlcmd.Parameters.Add(parametroNombre);
                SqlParameter parametroId = new SqlParameter("@ID", (usuario as Usuario).Id);
                sqlcmd.Parameters.Add(parametroId);
                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {
                    (libreta as Libreta).Idlibreta = int.Parse(sqlrd["idLibreta"].ToString());
                }
                return libreta;

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                return libreta;

            }

            finally
            {
                connexion.CerrarConexionBd();
            }

        }
    }
}