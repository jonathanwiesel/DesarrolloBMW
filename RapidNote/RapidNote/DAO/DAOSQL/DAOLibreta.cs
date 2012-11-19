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
    }
}