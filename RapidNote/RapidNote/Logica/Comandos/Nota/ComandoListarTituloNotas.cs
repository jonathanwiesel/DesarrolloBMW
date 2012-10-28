using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.DAOFactory;
using RapidNote.DAO.IDAOS;

namespace RapidNote.Logica.Comandos.Nota
{
    public class ComandoListarTituloNotas : Comando<List<Entidad>>
    {
        private Entidad usuario;
        
        private List<Entidad> listaNotas;

        public ComandoListarTituloNotas(Entidad _usuario) 
        {
            usuario = _usuario;
        }

        public override List<Entidad> Ejecutar()
        {
            IDAONota accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAONota();

            listaNotas = accion.ListarNotas(usuario);

            return listaNotas;
        }
    }
}