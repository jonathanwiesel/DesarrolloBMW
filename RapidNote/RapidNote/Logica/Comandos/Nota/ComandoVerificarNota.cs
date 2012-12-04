using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.IDAOS;
using RapidNote.DAO.DAOFactory;

namespace RapidNote.Logica.Comandos.Nota
{
    public class ComandoVerificarNota: Comando<Entidad>
    {
        private Entidad nota;
        private Entidad usuario;

        public ComandoVerificarNota(Entidad nota, Entidad usuario)
        {
            this.nota = nota;
            this.usuario = usuario;
        }

        public override Entidad Ejecutar()
        {
            IDAONota accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAONota();

            nota = accion.VerificarNota(nota, usuario);

            return nota;
        }
    }
}