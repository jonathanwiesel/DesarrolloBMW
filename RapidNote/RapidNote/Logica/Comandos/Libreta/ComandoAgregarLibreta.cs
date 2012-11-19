using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.DAOFactory;
using RapidNote.DAO.IDAOS;

namespace RapidNote.Logica.Comandos.Libreta
{
    public class ComandoAgregarLibreta : Comando<Boolean>
    {
        private Entidad libreta;
        private Entidad usuario;
        private Boolean estado;

        public ComandoAgregarLibreta(Entidad libreta, Entidad usuario)
        {
            this.libreta = libreta;
            this.usuario = usuario;
        }

        public override bool Ejecutar()
        {
            IDAOLibreta accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOLibreta();
            estado = accion.AgregarLibreta(libreta, usuario);
            return estado;
        }
    }
}