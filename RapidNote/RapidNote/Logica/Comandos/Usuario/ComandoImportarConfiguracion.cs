using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.IDAOS;
using RapidNote.DAO.DAOFactory;
using RapidNote.Clases.Fabrica;

namespace RapidNote.Logica.Comandos.Usuario
{
    public class ComandoImportarConfiguracion : Comando<Entidad>
    {
        private Entidad usuario;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ComandoImportarConfiguracion(Entidad _usuario) 
        {
            usuario = _usuario;
        }

        public override Entidad Ejecutar()
        {
            IDAOUsuario accion = FabricaDAO.CrearFabricaDeDAO(2).CrearDAOUsuario();

            usuario = accion.ImportarConfiguracion(usuario);

            accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOUsuario();

            accion.ImportarConfiguracion(usuario);

            for (int i = 0; i < (usuario as Clases.Usuario).ListaLibretas.Count; i++) 
            {
                IDAOLibreta accionLibreta = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOLibreta();
                accionLibreta.AgregarLibreta((usuario as Clases.Usuario).ListaLibretas[i],usuario);

                for (int j = 0; j < (usuario as Clases.Usuario).ListaLibretas[i].ListaNota.Count; j++) 
                {
                    IDAONota accionNota = FabricaDAO.CrearFabricaDeDAO(1).CrearDAONota();
                    (usuario as Clases.Usuario).ListaLibretas[i].ListaNota[j].Libreta.NombreLibreta = (usuario as Clases.Usuario).ListaLibretas[i].NombreLibreta;
                    accionNota.ImportarNota((usuario as Clases.Usuario).ListaLibretas[i].ListaNota[j]);

                    for (int k = 0; k < (usuario as Clases.Usuario).ListaLibretas[i].ListaNota[j].ListaAdjunto.Count; k++) 
                    {
                        IDAOAdjunto accionVerificar = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAdjunto();
                        Entidad adjuntoExiste = FabricaEntidad.CrearAdjunto();
                        adjuntoExiste = accionVerificar.VerificarAdjunto((usuario as Clases.Usuario).ListaLibretas[i].ListaNota[j].ListaAdjunto[k]);

                        if ((adjuntoExiste as Clases.Adjunto).Idadjunto == 0)
                        {
                            IDAOAdjunto accionAdjunto = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAdjunto();
                            accionAdjunto.AdjuntarBD((usuario as Clases.Usuario).ListaLibretas[i].ListaNota[j].ListaAdjunto[k]);
                        }

                        accionNota = FabricaDAO.CrearFabricaDeDAO(1).CrearDAONota();
                        Entidad nota = accionNota.VerificarNota((usuario as Clases.Usuario).ListaLibretas[i].ListaNota[j], (usuario as Clases.Usuario));

                        IDAOAdjunto accion2 = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAdjunto();
                        adjuntoExiste = accion2.VerificarAdjunto((usuario as Clases.Usuario).ListaLibretas[i].ListaNota[j].ListaAdjunto[k]);

                        if ((adjuntoExiste as Clases.Adjunto).Idadjunto != 0)
                        {
                            IDAOAdjunto accion3 = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAdjunto();
                            accion3.AgregarAdjunto_Nota(nota, adjuntoExiste);
                        }
                    }
                    
                }
            }           

            return usuario;
        }
    }
}