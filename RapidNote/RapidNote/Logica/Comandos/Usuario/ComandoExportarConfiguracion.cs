using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.IDAOS;
using RapidNote.DAO.DAOFactory;

namespace RapidNote.Logica.Comandos.Usuario
{
    public class ComandoExportarConfiguracion : Comando<Entidad>
    {
        private Entidad usuario;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ComandoExportarConfiguracion(Entidad _usuario)
        {
            usuario = _usuario;
        }

        public override Entidad Ejecutar()
        {
            IDAOUsuario accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOUsuario();
            usuario = accion.ExportarConfiguracion(usuario);

            if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " usuario: " + (usuario as Clases.Usuario).ToString());

            IDAOLibreta accionLibreta = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOLibreta();
            (usuario as Clases.Usuario).ListaLibretas = accionLibreta.ListarLibretas(usuario);

            IDAONota accionNota = FabricaDAO.CrearFabricaDeDAO(1).CrearDAONota();

            for (int i = 0; i < (usuario as Clases.Usuario).ListaLibretas.Count; i++) 
            {                
                (usuario as Clases.Usuario).ListaLibretas[i].ListaNota = accionNota.ListarNotasLibretaTypeNota((usuario as Clases.Usuario).ListaLibretas[i]);

                if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " libreta: " + (usuario as Clases.Usuario).ListaLibretas[i].ToString());

                IDAOEtiqueta accionEtiqueta = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOEtiqueta();
                IDAOAdjunto accionAdjunto = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAdjunto();

                for (int j = 0; j < (usuario as Clases.Usuario).ListaLibretas[i].ListaNota.Count; j++) 
                {
                    (usuario as Clases.Usuario).ListaLibretas[i].ListaNota[j].ListaEtiqueta = accionEtiqueta.ListarEtiquetasDeNota((usuario as Clases.Usuario).ListaLibretas[i].ListaNota[j]);
                    (usuario as Clases.Usuario).ListaLibretas[i].ListaNota[j].ListaAdjunto = accionAdjunto.ListarAjuntos((usuario as Clases.Usuario).ListaLibretas[i].ListaNota[j], (usuario as Clases.Usuario));
                    if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " Nota: " + (usuario as Clases.Usuario).ListaLibretas[i].ListaNota[j].ToString());
                }
            }

            accion = FabricaDAO.CrearFabricaDeDAO(2).CrearDAOUsuario();
            accion.ExportarConfiguracion(usuario);

            return usuario;
        }
    }
}