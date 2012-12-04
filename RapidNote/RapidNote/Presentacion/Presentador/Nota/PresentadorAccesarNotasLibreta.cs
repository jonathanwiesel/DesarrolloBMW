using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.Clases.Fabrica;
using RapidNote.Presentacion.Contrato.Nota;
using RapidNote.Logica.Fabrica;
using RapidNote.Logica.Comandos;

namespace RapidNote.Presentacion.Presentador.Nota
{
    public class PresentadorAccesarNotasLibreta
    {
        private IContratoAccesarNotaLibreta _vista;
        private Entidad libreta;
        private Comando<List<Entidad>> comando;
        private string _mensajeError = "No posee notas en esta libreta";

        public PresentadorAccesarNotasLibreta(IContratoAccesarNotaLibreta vista)
        {
            this._vista = vista;
        }

        public void IniciarVista()
        {
            libreta = FabricaEntidad.CrearLibreta();
            (libreta as Clases.Libreta).Idlibreta = int.Parse(_vista.getIdLibreta().ToString());

            List<Entidad> listaNotas;

            comando = FabricaComando.CrearComandoListarNotasLibreta(libreta);

            listaNotas = comando.Ejecutar();

            if (listaNotas.Count() == 0)
            {
                _vista.MensajeError.Text = _mensajeError;
                _vista.MensajeError.Visible = true;
            }
            else
            {
                _vista.gridviewnota = listaNotas;
            }
        }
    }
}