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
    public class ComandoBorrarAdjunto : Comando<int>
    {
        private Entidad Idnota;
        private string nombre;
        private Entidad usuario;
        private int result;

        public ComandoBorrarAdjunto(Entidad Idnota, string nombre, Entidad usuario)
        {
            this.Idnota = Idnota;
            this.nombre = nombre;
            this.usuario = usuario;
        }

        public override int Ejecutar()
        {
            IDAOAdjunto accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAdjunto();
            Entidad resultado = accion.BorrarAdjunto(Idnota, nombre);
            if (resultado != null)
            {
                IDAOAdjunto accion2 = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAdjunto();
                result = accion2.VerificarAdjuntoEliminar(usuario, nombre);
            }
            return result;
        }
    }
}