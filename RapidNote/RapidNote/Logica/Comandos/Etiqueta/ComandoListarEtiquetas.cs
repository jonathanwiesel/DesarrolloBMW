using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.DAOFactory;
using RapidNote.DAO.IDAOS;

namespace RapidNote.Logica.Comandos.Etiqueta
{
    public class ComandoListarEtiquetas : Comando<List<Entidad>>
    {
        private Entidad usuario;
        private List<Entidad> lista;

        public ComandoListarEtiquetas(Entidad usuario)
        {
            this.usuario = usuario;
        }

        public override List<Entidad> Ejecutar()
        {
            IDAOEtiqueta accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOEtiqueta();
            lista = accion.ListarEtiquetas(usuario);
            return lista;
        }
    }
}