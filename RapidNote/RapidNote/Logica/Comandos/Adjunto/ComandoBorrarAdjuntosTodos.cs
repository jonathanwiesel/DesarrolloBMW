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
    public class ComandoBorrarAdjuntosTodos:Comando<List<Clases.Adjunto>>
    {
        private Entidad libreta;
        private List<Clases.Adjunto> lista;

        public ComandoBorrarAdjuntosTodos(Entidad libreta)
        {
            this.libreta = libreta;
        }

        public override List<Clases.Adjunto> Ejecutar()
        {
            IDAOAdjunto accion2 = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAdjunto();
            lista = accion2.AdjuntosHuerfanos(libreta);
            if (lista.Count !=0)
            {
            IDAOAdjunto accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAdjunto();
            bool resultado = accion.EliminarAdjuntosTodos(libreta);
     
            
                
            }
            return lista;
        }
    }
}