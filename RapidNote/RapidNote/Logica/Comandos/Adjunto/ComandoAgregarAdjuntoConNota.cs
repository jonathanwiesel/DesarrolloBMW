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
    public class ComandoAgregarAdjuntoConNota:Comando<bool>
    {
        private string[] archivo;
        private string[] nombre;
        private Entidad nota;
        private Entidad usuario;
        private Entidad adjunto;
        private bool resultado = false;

        public ComandoAgregarAdjuntoConNota(string[] archivo, string[] nombre, Entidad nota, Entidad usuario)
        {
            this.archivo = archivo;
            this.nombre = nombre;
            this.nota = nota;
            this.usuario = usuario;

        }

        public override bool Ejecutar()
        {
            try
            {
                IDAONota accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAONota();
                nota = accion.VerificarNota(nota, usuario);
                if ((nota as Clases.Nota).Idnota != 0)
                {
                    adjunto = FabricaEntidad.CrearAdjunto();
                    for (int i = 0; i < archivo.Count(); i++)
                    {
                        if (archivo[i] != "")
                        {
                            (adjunto as Clases.Adjunto).Urlarchivo = archivo[i];
                            (adjunto as Clases.Adjunto).Titulo = nombre[i];
                            IDAOAdjunto accion2 = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAdjunto();
                            adjunto = accion2.VerificarAdjunto(adjunto);

                            if ((adjunto as Clases.Adjunto).Idadjunto != 0)
                            {
                                IDAOAdjunto accion3 = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAdjunto();
                                resultado = accion3.AgregarAdjunto_Nota(nota, adjunto);
                            }
                            else
                            {
                                return resultado;
                            }
                        }
                    }
                    return resultado;
                }
                else
                {
                    return resultado;
                }
            }
            catch
            {
                return resultado;
            }
        }
    }
}