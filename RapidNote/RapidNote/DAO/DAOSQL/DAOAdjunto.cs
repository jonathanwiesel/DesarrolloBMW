using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.DAO.IDAOS;
using System.Data.SqlClient;
using System.Data;
using RapidNote.Clases;
using RapidNote.Clases.Fabrica;

namespace RapidNote.DAO.DAOSQL
{
    public class DAOAdjunto:IDAOAdjunto
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool AdjuntarBD(Entidad adjunto)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            bool estado = false;
            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "AgregarAdjunto";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroUrl = new SqlParameter("@URL", (adjunto as Adjunto).Urlarchivo);
                sqlcmd.Parameters.Add(parametroUrl);
                SqlParameter parametroTitulo = new SqlParameter("@TITULO", (adjunto as Adjunto).Titulo);
                sqlcmd.Parameters.Add(parametroTitulo);
                sqlcmd.ExecuteNonQuery();
                if (log.IsInfoEnabled) log.Info((adjunto as Clases.Adjunto).ToString());
                estado = true;
                return estado;


            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error(E.Message, E);
                return estado;

            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }


        public Entidad VerificarAdjunto(Entidad adjunto)
        {
            Entidad adjuntoExiste;
            adjuntoExiste = FabricaEntidad.CrearAdjunto();
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "VerificarAdjunto";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroUrl = new SqlParameter("@URL", (adjunto as Adjunto).Urlarchivo);
                sqlcmd.Parameters.Add(parametroUrl);
                SqlParameter parametroTitulo = new SqlParameter("@NOMBRE", (adjunto as Adjunto).Titulo);
                sqlcmd.Parameters.Add(parametroTitulo);
                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {
                    (adjuntoExiste as Adjunto).Idadjunto = int.Parse(sqlrd["idAdjunto"].ToString());
                }
                if (log.IsInfoEnabled) log.Info((adjunto as Clases.Adjunto).ToString());
                return adjuntoExiste;

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error(E.Message, E);
                return adjuntoExiste;

            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }

        public bool AgregarAdjunto_Nota(Entidad nota, Entidad adjunto)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            bool estado = false;
            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "AgregarAdjuntoNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroIdAdjunto = new SqlParameter("@IDADJUNTO", (adjunto as Adjunto).Idadjunto);
                sqlcmd.Parameters.Add(parametroIdAdjunto);
                SqlParameter parametroIdNota = new SqlParameter("@IDNOTA", (nota as Nota).Idnota);
                sqlcmd.Parameters.Add(parametroIdNota);
                sqlcmd.ExecuteNonQuery();
                if (log.IsInfoEnabled) log.Info((adjunto as Clases.Adjunto).ToString());
                if (log.IsInfoEnabled) log.Info((nota as Nota).ToString());
                estado = true;
                return estado;


            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error(E.Message, E);
                return estado;

            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }

        public Entidad BorrarAdjunto(Entidad nota)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            
            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "BorrarAdjunto";
                sqlcmd.CommandTimeout = 2;
                SqlParameter parametroIdNota = new SqlParameter("@IDNOTA", (nota as Nota).Idnota);
                sqlcmd.Parameters.Add(parametroIdNota);
                sqlcmd.ExecuteNonQuery();
                if (log.IsInfoEnabled) log.Info((nota as Nota).ToString());
                return nota;


            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error(E.Message, E);
                return nota;

            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }


        public List<Adjunto> ListarAjuntos(Entidad nota, Entidad usuario)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            List<Adjunto> listaAdjuntos = new List<Adjunto>();
            Entidad adjunto = null;

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "listarAdjuntosPorNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroCorreo = new SqlParameter("@tituloNota", (nota as Nota).Titulo);
                sqlcmd.Parameters.Add(parametroCorreo);
                SqlParameter parametroLibreta = new SqlParameter("@libreta", (nota as Nota).Libreta.NombreLibreta);
                sqlcmd.Parameters.Add(parametroLibreta);
                SqlParameter parametroId = new SqlParameter("@id", (usuario as Usuario).Id);
                sqlcmd.Parameters.Add(parametroId);
                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {
                    adjunto = FabricaEntidad.CrearAdjunto();
                    (adjunto as Adjunto).Titulo = sqlrd["TITULO"].ToString();
                    listaAdjuntos.Add((adjunto as Adjunto));
                }
                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " nota: " + (nota as Clases.Nota).ToString());
                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " usuario: " + (usuario as Clases.Usuario).ToString());
                return listaAdjuntos;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " mensaje: " + E.Message, E);
                return listaAdjuntos;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }
    }
}