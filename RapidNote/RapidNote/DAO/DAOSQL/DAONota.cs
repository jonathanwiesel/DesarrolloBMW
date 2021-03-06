﻿using System;
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
    public class DAONota : IDAONota
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public List<Entidad> ListarNotas(Entidad usuario)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            List<Entidad> listaNotas = new List<Entidad>();
            Entidad nota = null;

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "ListarNotas";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroCorreo = new SqlParameter("@correoUsuario", (usuario as Usuario).Correo);
                sqlcmd.Parameters.Add(parametroCorreo);
                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {
                    nota = FabricaEntidad.CrearNota();
                    (nota as Nota).Idnota = int.Parse(sqlrd["idNota"].ToString());
                    (nota as Nota).Titulo = sqlrd["TITULO"].ToString();
                    (nota as Nota).Fechacreacion = DateTime.Parse(sqlrd["fechaCreacion"].ToString());
                    listaNotas.Add(nota);
                }
                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " usuario: " + (usuario as Clases.Usuario).ToString());
                return listaNotas;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " mensaje: " + E.Message, E);
                return listaNotas;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }


        public Entidad MostrarNota(Entidad nota)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "MostrarNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroCorreo = new SqlParameter("@tituloNota", (nota as Nota).Titulo);
                sqlcmd.Parameters.Add(parametroCorreo);
                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {
                    (nota as Nota).Contenido = sqlrd["CONTENIDO"].ToString();
                    (nota as Nota).Fechacreacion = DateTime.Parse(sqlrd["fechaCreacion"].ToString());
                    (nota as Nota).Libreta.NombreLibreta = sqlrd["nombreLibreta"].ToString();
                    if (sqlrd["fechaModificacion"].ToString() != null)
                    {
                        (nota as Nota).Fechamodificacion = DateTime.Parse(sqlrd["fechaModificacion"].ToString());
                    }
                    //(nota as Nota).Libreta.NombreLibreta = sqlrd["nombreLibreta"].ToString();                    
                }
                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " nota: " + (nota as Clases.Nota).ToString());
                return nota;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " mensaje: " + E.Message, E);
                return nota;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }


        public List<Entidad> ListarAjuntos(Entidad nota, Entidad usuario)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            List<Entidad> listaAdjuntos = new List<Entidad>();
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
                    listaAdjuntos.Add(adjunto);
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


        public List<Entidad> ListarEtiquetas(Entidad nota)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            List<Entidad> listaEtiquetas = new List<Entidad>();
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
                    listaEtiquetas.Add(etiqueta);
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


        public Entidad NuevaNota(Entidad nota)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "CrearNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroTitulo = new SqlParameter("@tituloNota", (nota as Nota).Titulo);
                sqlcmd.Parameters.Add(parametroTitulo);
                SqlParameter parametroContenido = new SqlParameter("@contenidoNota", (nota as Nota).Contenido);
                sqlcmd.Parameters.Add(parametroContenido);
                SqlParameter parametroNombreL = new SqlParameter("@nombreLibreta", (nota as Nota).Libreta.NombreLibreta);
                sqlcmd.Parameters.Add(parametroNombreL);

                sqlcmd.ExecuteNonQuery();

                //meto en base de datos las etiquetas que no existen y obtengo los 
                //ids de todas las etiquetas de la nota a editar
                List<int> idEtiquetas = new List<int>();
                foreach (Etiqueta etiqueta in (nota as Clases.Nota).ListaEtiqueta)
                {
                    int id = Agregar_Consultar_Etiqueta(etiqueta.Nombre);
                    idEtiquetas.Add(id);
                }


                //le asigno las etiquetas
                foreach (int idEti in idEtiquetas)
                {
                    int id = BuscarIdNota(nota);
                    AsignarEtiquetasNota(id, idEti);
                }
                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " nota: " + (nota as Clases.Nota).ToString());
                return nota;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " mensaje: " + E.Message, E);
                return nota;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }


        public List<Entidad> ListarLibretas(Entidad usuario)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            List<Entidad> listaLibretas = new List<Entidad>();
            Entidad libreta = null;

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "ConsultarLibretas";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroCorreo = new SqlParameter("@correoUsuario", (usuario as Usuario).Correo);
                sqlcmd.Parameters.Add(parametroCorreo);
                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {
                    libreta = FabricaEntidad.CrearLibreta();
                    (libreta as Libreta).Idlibreta = int.Parse(sqlrd["idLibreta"].ToString());
                    (libreta as Libreta).NombreLibreta = sqlrd["nombreLibreta"].ToString();
                    listaLibretas.Add(libreta);
                }
                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " nota: " + (usuario as Clases.Usuario).ToString());
                return listaLibretas;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " mensaje: " + E.Message, E);
                return listaLibretas;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }


        public List<Entidad> BuscarNotasEtiqueta(Entidad usuario)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            List<Entidad> listaNotas = new List<Entidad>();
            Entidad nota = null;

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "BuscarNotaEtiqueta";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroFraseBusqueda = new SqlParameter("@contenidoBusqueda", usuario.Estado);
                sqlcmd.Parameters.Add(parametroFraseBusqueda);
                SqlParameter parametroCorreo = new SqlParameter("@correoUsuario", (usuario as Usuario).Correo);
                sqlcmd.Parameters.Add(parametroCorreo);
                
                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {
                    nota = FabricaEntidad.CrearNota();
                    (nota as Nota).Idnota = Convert.ToInt32(sqlrd["idNota"]);
                    (nota as Nota).Titulo = sqlrd["titulo"].ToString();
                    (nota as Nota).Fechacreacion = DateTime.Parse(sqlrd["fechaCreacion"].ToString());
                    listaNotas.Add(nota);
                }
                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " usuario: " + (usuario as Clases.Usuario).ToString());
                return listaNotas;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " mensaje: " + E.Message, E);
                return listaNotas;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }


        public List<Entidad> BuscarNotas(Entidad usuario)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            List<Entidad> listaNotas = new List<Entidad>();
            Entidad nota = null;

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "BuscarNotaContenido";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroFraseBusqueda = new SqlParameter("@contenidoBusqueda", usuario.Estado);
                sqlcmd.Parameters.Add(parametroFraseBusqueda);
                SqlParameter parametroCorreo = new SqlParameter("@correoUsuario", (usuario as Usuario).Correo);
                sqlcmd.Parameters.Add(parametroCorreo);

                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {
                    nota = FabricaEntidad.CrearNota();
                    (nota as Nota).Idnota = Convert.ToInt32(sqlrd["idNota"]);
                    (nota as Nota).Titulo = sqlrd["titulo"].ToString();
                    (nota as Nota).Fechacreacion = DateTime.Parse(sqlrd["fechaCreacion"].ToString());
                    listaNotas.Add(nota);
                }
                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " usuario: " + (usuario as Clases.Usuario).ToString());
                return listaNotas;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " mensaje: " + E.Message, E);
                return listaNotas;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }

        public int BuscarIdNota(Entidad nota)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            int aux = 0;

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "BuscarIdNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroTitulo = new SqlParameter("@tituloNota", (nota as Nota).Titulo);
                sqlcmd.Parameters.Add(parametroTitulo);

                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {

                    aux = int.Parse(sqlrd["IDNOTA"].ToString());

                }
                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " nota: " + (nota as Clases.Nota).ToString());
                return aux;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " mensaje: " + E.Message, E);
                return aux;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }

        public Entidad BuscarNota(Entidad nota)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            //int aux = 0;

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "BuscarNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroTitulo = new SqlParameter("@idNota", (nota as Nota).Idnota);
                sqlcmd.Parameters.Add(parametroTitulo);

                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {

                    (nota as Nota).Contenido = sqlrd["CONTENIDO"].ToString();
                    (nota as Nota).Fechacreacion = DateTime.Parse(sqlrd["fechaCreacion"].ToString());
                    (nota as Nota).Libreta.NombreLibreta = sqlrd["nombreLibreta"].ToString();
                    (nota as Nota).Titulo = sqlrd["titulo"].ToString();
                    if (sqlrd["fechaModificacion"].ToString() != null)
                    {
                        (nota as Nota).Fechamodificacion = DateTime.Parse(sqlrd["fechaModificacion"].ToString());
                    }

                }
                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " nota: " + (nota as Clases.Nota).ToString());
                return nota;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " mensaje: " + E.Message, E);
                return nota;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }


        public Entidad EditarNota(Entidad nota)
        {
            //primero borro todas las etiquetas de la nota
            BorrarEtiquetasDeNota((nota as Clases.Nota));
            List<int> idEtiquetas = new List<int>();

            //meto en base de datos las etiquetas que no existen y obtengo los 
            //ids de todas las etiquetas de la nota a editar
            foreach (Etiqueta etiqueta in (nota as Clases.Nota).ListaEtiqueta)
            {
                int id = Agregar_Consultar_Etiqueta(etiqueta.Nombre);
                idEtiquetas.Add(id);
            }

            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();

            //actualizo la nota
            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "EditarNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroTitulo = new SqlParameter("@tituloNota", (nota as Nota).Titulo);
                sqlcmd.Parameters.Add(parametroTitulo);
                SqlParameter parametroContenido = new SqlParameter("@contenidoNota", (nota as Nota).Contenido);
                sqlcmd.Parameters.Add(parametroContenido);
                SqlParameter parametroIdNota = new SqlParameter("@idNota", (nota as Nota).Idnota);
                sqlcmd.Parameters.Add(parametroIdNota);

                sqlcmd.ExecuteNonQuery();

                //le asigno las etiquetas
                foreach (int idEti in idEtiquetas)
                {
                    AsignarEtiquetasNota((nota as Nota).Idnota, idEti);
                }
                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " nota: " + (nota as Clases.Nota).ToString());
                return nota;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " mensaje: " + E.Message, E);
                return nota;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }

        public int Agregar_Consultar_Etiqueta(string nombreEtiqueta)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            int idEtiqueta = 0;
            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "Agregar_Consultar_Etiqueta";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroNombre = new SqlParameter("@nombre", nombreEtiqueta);
                sqlcmd.Parameters.Add(parametroNombre);

                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();

                while (sqlrd.Read())
                {
                    idEtiqueta = Convert.ToInt32(sqlrd["idEtiqueta"]);
                }
                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " nombreEtiqueta: " + nombreEtiqueta.ToString());
                return idEtiqueta;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " mensaje: " + E.Message, E);
                return idEtiqueta;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }

        public void BorrarEtiquetasDeNota(Entidad nota)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "BorrarEtiquetasDeNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroIdNota = new SqlParameter("@idNota", (nota as Nota).Idnota);
                sqlcmd.Parameters.Add(parametroIdNota);

                sqlcmd.ExecuteNonQuery();
                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " nota: " + (nota as Clases.Nota).ToString());

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " mensaje: " + E.Message, E);
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }

        public void AsignarEtiquetasNota(int idNota, int idEtiqueta)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "AsignarEtiquetasNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroIdNota = new SqlParameter("@idNota", idNota);
                sqlcmd.Parameters.Add(parametroIdNota);
                SqlParameter parametroIdEtiqueta = new SqlParameter("@idEtiqueta", idEtiqueta);
                sqlcmd.Parameters.Add(parametroIdEtiqueta);

                sqlcmd.ExecuteNonQuery();
                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " idnota: " + idNota);
                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " idEtiqueta: " + idEtiqueta);

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " mensaje: " + E.Message, E);
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }


        public Entidad BorrarNota(Entidad nota)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "BorrarNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroIdNota = new SqlParameter("@idNota", (nota as Nota).Idnota);
                sqlcmd.Parameters.Add(parametroIdNota);

                sqlcmd.ExecuteNonQuery();
                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " nota: " + (nota as Clases.Nota).ToString());
                return nota;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " mensaje: " + E.Message, E);
                return nota;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }

        public List<Entidad> ListarNotasLibreta(Entidad libreta)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            List<Entidad> listaNotas = new List<Entidad>();
            Entidad nota = null;

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "ListarNotasLibreta";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroId = new SqlParameter("@ID", (libreta as Libreta).Idlibreta);
                sqlcmd.Parameters.Add(parametroId);
                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();

                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " libreta: " + (libreta as Clases.Libreta).ToString());

                while (sqlrd.Read())
                {
                    nota = FabricaEntidad.CrearNota();
                    (nota as Nota).Idnota = int.Parse(sqlrd["idNota"].ToString());
                    (nota as Nota).Titulo = sqlrd["titulo"].ToString();
                    (nota as Nota).Fechacreacion = DateTime.Parse(sqlrd["fechaCreacion"].ToString());
                    listaNotas.Add(nota);
                    if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " nota: " + (nota as Clases.Nota).ToString());
                }
                
                return listaNotas;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " mensaje: " + E.Message, E);
                return listaNotas;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }

        }

        public Entidad VerificarNota(Entidad nota, Entidad usuario)
        {
            Entidad notaExiste;
            notaExiste = FabricaEntidad.CrearNota();
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "VerificarNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroTitulo = new SqlParameter("@TITULO", (nota as Clases.Nota).Titulo);
                sqlcmd.Parameters.Add(parametroTitulo);
                SqlParameter parametroNombre = new SqlParameter("@NOMBRE", (nota as Clases.Nota).Libreta.NombreLibreta);
                sqlcmd.Parameters.Add(parametroNombre);
                SqlParameter parametroId = new SqlParameter("@CORREO", (usuario as Usuario).Correo);
                sqlcmd.Parameters.Add(parametroId);
                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();

                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " nota: " + (nota as Clases.Nota).ToString());
                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " usuario: " + (usuario as Clases.Usuario).ToString());

                while (sqlrd.Read())
                {
                    (notaExiste as Clases.Nota).Idnota = int.Parse(sqlrd["idNota"].ToString());
                    if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " nota: " + (nota as Clases.Nota).ToString());
                }
                
                return notaExiste;

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " mensaje: " + E.Message, E);
                return notaExiste;

            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }



        public List<Nota> ListarNotasLibretaTypeNota(Entidad libreta)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            List<Nota> listaNotas = new List<Nota>();
            Entidad nota = null;

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "ListarNotasLibretaExport";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroId = new SqlParameter("@ID", (libreta as Libreta).Idlibreta);
                sqlcmd.Parameters.Add(parametroId);
                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();

                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " libreta: " + (libreta as Clases.Libreta).ToString());

                while (sqlrd.Read())
                {
                    nota = FabricaEntidad.CrearNota();
                    (nota as Nota).Idnota = int.Parse(sqlrd["idNota"].ToString());
                    (nota as Nota).Titulo = sqlrd["titulo"].ToString();
                    (nota as Nota).Contenido = sqlrd["contenido"].ToString();
                    (nota as Nota).Fechacreacion = DateTime.Parse(sqlrd["fechaCreacion"].ToString());
                    if (!DBNull.Value.Equals(sqlrd["fechaModificacion"]))
                    {
                        (nota as Nota).Fechamodificacion = DateTime.Parse(sqlrd["fechaModificacion"].ToString());
                    }
                    (nota as Nota).Libreta.NombreLibreta = (libreta as Libreta).NombreLibreta;
                    listaNotas.Add((nota as Nota));
                    if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " nota: " + (nota as Clases.Nota).ToString());
                }

                return listaNotas;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " mensaje: " + E.Message, E);
                return listaNotas;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }
		
		public Entidad ImportarNota(Entidad nota)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "ImportarNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroTitulo = new SqlParameter("@tituloNota", (nota as Nota).Titulo);
                sqlcmd.Parameters.Add(parametroTitulo);
                SqlParameter parametroContenido = new SqlParameter("@contenidoNota", (nota as Nota).Contenido);
                sqlcmd.Parameters.Add(parametroContenido);                
                SqlParameter parametroFechaC = new SqlParameter("@FechaC", (nota as Nota).Fechacreacion);
                sqlcmd.Parameters.Add(parametroFechaC);
                SqlParameter parametroFechaM = new SqlParameter("@FechaM", (nota as Nota).Fechacreacion);
                sqlcmd.Parameters.Add(parametroFechaM);
                SqlParameter parametroNombreL = new SqlParameter("@nombreLibreta", (nota as Nota).Libreta.NombreLibreta);
                sqlcmd.Parameters.Add(parametroNombreL);

                sqlcmd.ExecuteNonQuery();

                //meto en base de datos las etiquetas que no existen y obtengo los 
                //ids de todas las etiquetas de la nota a editar
                List<int> idEtiquetas = new List<int>();
                foreach (Etiqueta etiqueta in (nota as Clases.Nota).ListaEtiqueta)
                {
                    int id = Agregar_Consultar_Etiqueta(etiqueta.Nombre);
                    idEtiquetas.Add(id);
                }


                //le asigno las etiquetas
                foreach (int idEti in idEtiquetas)
                {
                    int id = BuscarIdNota(nota);
                    AsignarEtiquetasNota(id, idEti);
                }
                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " nota: " + (nota as Clases.Nota).ToString());
                return nota;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                if (log.IsErrorEnabled) log.Error("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " mensaje: " + E.Message, E);
                return nota;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }
    }
}