using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.Clases.Fabrica;
using RapidNote.DAO.IDAOS;
using RapidNote.DAO.DAOFactory;

namespace RapidNote.Logica.Comandos.Adjunto
{
    public class ComandoAgregarAdjuntoBD: Comando<bool>
    {
        private string[] archivo;
        private string[] nombre;
        private Entidad adjunto;
        private Entidad adjuntoExiste;
        private bool estado = false;

        public ComandoAgregarAdjuntoBD(string[] archivo, string[] nombre)
        {
            this.archivo = archivo;
            this.nombre = nombre;
        }

        public override bool Ejecutar()
        {
            try
            {
                adjunto = FabricaEntidad.CrearAdjunto();
                for (int i = 0; i < archivo.Count(); i++)
                {
                    if (archivo[i] != "")
                    {
                        (adjunto as Clases.Adjunto).Urlarchivo = archivo[i];
                        (adjunto as Clases.Adjunto).Titulo = nombre[i];
                        IDAOAdjunto accionVerificar = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAdjunto();
                        adjuntoExiste = FabricaEntidad.CrearAdjunto();
                        adjuntoExiste = accionVerificar.VerificarAdjunto(adjunto);
                        if ((adjuntoExiste as Clases.Adjunto).Idadjunto == 0)
                        {
                            IDAOAdjunto accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAdjunto();
                            estado = accion.AdjuntarBD(adjunto);
                        }
                        else
                        {
                            estado = true;
                        }
                    }
                }
                return estado;
            }
            catch 
            {
                return estado;
            }
        }
    }
}