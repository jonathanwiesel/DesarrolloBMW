using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.IDAOS;
using RapidNote.DAO.DAOFactory;

namespace RapidNote.Logica.Comandos.Nota
{
    public class ComandoListarEtiquetasPorNota : Comando<List<Entidad>>
    {
        private Entidad nota;

        private List<Entidad> listaEtiquetas;

        public ComandoListarEtiquetasPorNota(Entidad _nota) 
        {
            nota = _nota;
        }


        public override List<Entidad> Ejecutar()
        {
            IDAONota accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAONota();

            listaEtiquetas = accion.ListarEtiquetas(nota);

            return listaEtiquetas;
        }
    }
}