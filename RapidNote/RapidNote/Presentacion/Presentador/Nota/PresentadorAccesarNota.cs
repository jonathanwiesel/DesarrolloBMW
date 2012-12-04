using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Presentacion.Contrato.Nota;
using RapidNote.Clases;
using RapidNote.Logica.Comandos;
using RapidNote.DAO.IDAOS;
using RapidNote.DAO.DAOFactory;
using RapidNote.Logica.Fabrica;

namespace RapidNote.Presentacion.Presentador.Nota
{
    public class PresentadorAccesarNota
    {
        private IContratoAccesarNota contrato;
        private string _mensajeError = "No posee notas";
        private Comando<List<Entidad>> comando;

        public PresentadorAccesarNota(IContratoAccesarNota _contrato)
        {
            contrato = _contrato;
        }

        public void IniciarVista()
        {
            Entidad usuario = (contrato.Sesion["usuario"] as Clases.Usuario);

            List<Entidad> listaNotas;

            comando = FabricaComando.CrearComandoListarNotas(usuario);

            listaNotas = comando.Ejecutar();

            if (listaNotas.Count() == 0)
            {
                contrato.MensajeError.Text = _mensajeError;
                contrato.MensajeError.Visible = true;
            }
            else
            {
                contrato.gridviewnota = listaNotas;
            }
        }
    }
}