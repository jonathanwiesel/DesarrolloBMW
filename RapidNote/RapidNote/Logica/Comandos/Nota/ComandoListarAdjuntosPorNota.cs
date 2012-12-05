using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.DAOFactory;
using RapidNote.DAO.IDAOS;

namespace RapidNote.Logica.Comandos.Nota
{
    public class ComandoListarAdjuntosPorNota : Comando<List<Entidad>>
    {
        private Entidad nota;
        private Entidad usuario;
        
        private List<Entidad> listaAdjuntos;

        public ComandoListarAdjuntosPorNota(Entidad _nota, Entidad _usuario) 
        {
            nota = _nota;
            usuario = _usuario;
        }

        public override List<Entidad> Ejecutar()
        {
            IDAONota accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAONota();

            listaAdjuntos = accion.ListarAjuntos(nota,usuario);

            return listaAdjuntos;
        }
    }
}