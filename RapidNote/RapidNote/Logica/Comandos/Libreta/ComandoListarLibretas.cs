using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.IDAOS;
using RapidNote.DAO.DAOFactory;

namespace RapidNote.Logica.Comandos.Nota
{
    public class ComandoListarLibretas : Comando<List<Entidad>>
    {
        private Entidad usuario;

        private List<Entidad> listaLibretas;

        public ComandoListarLibretas(Entidad _usuario) 
        {
            usuario = _usuario;
        }
        
        public override List<Entidad> Ejecutar()
        {
            IDAONota accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAONota();

            listaLibretas = accion.ListarLibretas(usuario);

            return listaLibretas;
        }
    }
}