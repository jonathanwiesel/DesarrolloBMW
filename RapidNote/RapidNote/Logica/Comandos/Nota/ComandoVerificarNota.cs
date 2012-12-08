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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ComandoVerificarNota(Entidad nota, Entidad usuario)
        {
            this.nota = nota;
            this.usuario = usuario;
        }
       
        public override Entidad Ejecutar()
        {
            IDAONota accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAONota();

            if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " usuario: " + (usuario as Clases.Usuario).ToString());
            if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " nota: " + (nota as Clases.Nota).ToString());

            nota = accion.VerificarNota(nota, usuario);

            return nota;
        }
    }
}