using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.Presentacion.Contrato.Etiqueta;
using RapidNote.Logica.Fabrica;
using RapidNote.Logica.Comandos;
using RapidNote.Logica.Comandos.Etiqueta;

namespace RapidNote.Presentacion.Presentador.Etiqueta
{
    public class PresentadorAccesarEtiqueta
    {
        private IContratoAccesarEtiqueta _vista;
        private Comando<List<Entidad>> comando;
        private List<Entidad> lista;
        private string _mensajeError = "No posee etiquetas registradas";

        public PresentadorAccesarEtiqueta(IContratoAccesarEtiqueta vista)
        {
            _vista = vista;
        }

        public void IniciarVista()
        {
            Entidad usuario = _vista.Sesion["usuario"] as Clases.Usuario;
            comando = FabricaComando.CrearComandoListarEtiquetas(usuario);
            lista = comando.Ejecutar();
            if (lista.Count() == 0)
            {
                _vista.MensajeError.Text = _mensajeError;
                _vista.MensajeError.Visible = true;
            }
            else
            {
                _vista.gridviewlibreta = lista;
            }
        }
    }
}