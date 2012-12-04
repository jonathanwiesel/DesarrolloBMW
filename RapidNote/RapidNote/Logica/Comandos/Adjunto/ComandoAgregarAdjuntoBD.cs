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
                        IDAOAdjunto accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAdjunto();
                        estado = accion.AdjuntarBD(adjunto);
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