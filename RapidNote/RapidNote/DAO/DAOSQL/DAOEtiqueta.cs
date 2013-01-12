using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using RapidNote.Clases;
using RapidNote.Clases.Fabrica;
using RapidNote.DAO.IDAOS;

namespace RapidNote.DAO.DAOSQL
{
    public class DAOEtiqueta : IDAOEtiqueta
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public List<Entidad> ListarEtiquetas(Entidad usuario)
        {
            List<Entidad> lista = new List<Entidad>();
            Entidad etiqueta = null;
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "AccesarEtiqueta";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroId = new SqlParameter("@ID", (usuario as Usuario).Id);
                sqlcmd.Parameters.Add(parametroId);
                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {
                    etiqueta = FabricaEntidad.CrearEtiqueta();
                    (etiqueta as Etiqueta).Idetiqueta = int.Parse(sqlrd["idEtiqueta"].ToString());
                    (etiqueta as Etiqueta).Nombre = sqlrd["nombre"].ToString();
                    lista.Add(etiqueta);
                    if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " etiqueta: " + (etiqueta as Clases.Etiqueta).ToString());
                }

                return lista;

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " mensaje: " + E.Message, E);
                return lista;

            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }





        public List<Etiqueta> ListarEtiquetasDeNota(Entidad nota)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            List<Etiqueta> listaEtiquetas = new List<Etiqueta>();
            Entidad etiqueta = null;

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "listarEtiquetasPorNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroCorreo = new SqlParameter("@tituloNota", (nota as Nota).Titulo);
                sqlcmd.Parameters.Add(parametroCorreo);
                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {
                    etiqueta = FabricaEntidad.CrearEtiqueta();
                    (etiqueta as Etiqueta).Nombre = sqlrd["nombre"].ToString();
                    listaEtiquetas.Add((etiqueta as Etiqueta));
                }
                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " nota: " + (nota as Clases.Nota).ToString());
                return listaEtiquetas;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " mensaje: " + E.Message, E);
                return listaEtiquetas;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }
    }
}