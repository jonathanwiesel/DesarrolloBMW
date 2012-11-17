using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.IDAOS;
using RapidNote.DAO.DAOFactory;

namespace RapidNote.Logica.Comandos.Nota
{
    public class ComandoBuscarNotas : Comando<List<Entidad>>
    {
        private Entidad usuario;

        private List<Entidad> listaNotas;

        public ComandoBuscarNotas(Entidad _usuario) 
        {
            usuario = _usuario;
        }

        public override List<Entidad> Ejecutar()
        {
            IDAONota accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAONota();

            listaNotas = accion.BuscarNotas(usuario);            

            return listaNotas;
        }
    }
}