using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.Clases.Fabrica;
using RapidNote.DAO.IDAOS;
using RapidNote.DAO.DAOFactory;
using RapidNote.Logica.Fabrica;
using RapidNote.Logica.Comandos.Dropbox;


namespace RapidNote.Logica.Comandos.Adjunto
{
    public class ComandoVerificarAdjuntoEli: Comando<bool>
    {
        private List<Clases.Adjunto> lista;
        private Entidad usuario;
        private Comando<bool> comando;

        public ComandoVerificarAdjuntoEli(List<Clases.Adjunto> lista, Entidad usuario)
        {
            this.lista = lista;
            this.usuario = usuario;
        }

        public override bool Ejecutar()
        {
            bool resultado = false;
            foreach (Clases.Adjunto adjun in lista)
            {
                IDAOAdjunto accon3 = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAdjunto();
                accon3.EliminarAdjuntosHuerfanos(adjun.Titulo);

                IDAOAdjunto accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAdjunto();
                int result = accion.VerificarAdjuntoEliminar(usuario, adjun.Titulo);
                if (result == 0)
                {
                    comando = FabricaComando.CrearComandoEliminarAdjuntoDropbox(usuario, adjun.Titulo);
                    comando.Ejecutar();
                    resultado = true;
                }
            }

            return resultado;
        }
    }
}