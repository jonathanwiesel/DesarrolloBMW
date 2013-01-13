using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Presentacion.Contrato.Libreta;
using RapidNote.Clases;
using RapidNote.Clases.Fabrica;
using RapidNote.Logica.Comandos;
using RapidNote.Logica.Comandos.Libreta;
using RapidNote.Logica.Fabrica;

namespace RapidNote.Presentacion.Presentador.Libreta
{
    public class PresentadorEditarLibreta
    {
        private IContratoEditarLibreta _vista;
        private Comando<Entidad> comando;
        private Comando<Entidad> comando2;
        private Comando<Boolean> comando3;
        private Comando<Boolean> comando4;
        private Comando<List<Adjunto>> comando5;
        private Comando<bool> comando6;
        
        private string _mensajeErrorInsertar = "Error al modificar en base de datos";
        private string _mensajeErrorEliminar = "Error al eliminar en base de datos";
        private string _mensajeErrorExiste = "Error, ya posee una libreta con ese nombre";
        private Entidad libreta;
        private Entidad libretaExiste;
        private Entidad usuario;
        private bool estado;

        public PresentadorEditarLibreta(IContratoEditarLibreta vista)
        {
            this._vista = vista;
        }

        public void IniciarVista()
        {
            libreta = FabricaEntidad.CrearLibreta();
            (libreta as Clases.Libreta).Idlibreta = int.Parse(_vista.getIdLibreta().ToString());

            comando = FabricaComando.CrearComandoTraerLibreta(libreta);
            libreta = comando.Ejecutar();
            _vista.setNombre((libreta as Clases.Libreta).NombreLibreta);

        }

        public void Ejecutar()
        {
            usuario = (_vista.Sesion["usuario"] as Clases.Usuario);
            libreta = FabricaEntidad.CrearLibreta();
            (libreta as Clases.Libreta).Idlibreta = int.Parse(_vista.getIdLibreta().ToString());
            (libreta as Clases.Libreta).NombreLibreta = _vista.getNombre();
            comando2 = FabricaComando.CrearComandoVerificarLibreta(libreta, usuario);
            libretaExiste = FabricaEntidad.CrearLibreta();
            libretaExiste = comando2.Ejecutar();
            if ((libretaExiste as Clases.Libreta).Idlibreta == 0)
            {
                comando3 = FabricaComando.CrearComandoEditarLibreta(libreta);
                estado = comando3.Ejecutar();
                if (estado == true)
                {
                    _vista.Redireccionar("../Vista/AccesarLibreta.aspx");
                }
                else
                {
                    _vista.MensajeError.Text = _mensajeErrorInsertar;
                    _vista.MensajeError.Visible = true;
                }
            }
            else
            {
                _vista.MensajeError.Text = _mensajeErrorExiste;
                _vista.MensajeError.Visible = true;
            }

        }

        public void Eliminar() {
            libreta = FabricaEntidad.CrearLibreta();
            (libreta as Clases.Libreta).Idlibreta = int.Parse(_vista.getIdLibreta().ToString());
            comando4 = FabricaComando.CrearComandoEliminarLibreta(libreta);
            estado = comando4.Ejecutar();
            if (estado == true)
            {
                _vista.Redireccionar("../Vista/AccesarLibreta.aspx");
            }
            else
            {
                _vista.MensajeError.Text = _mensajeErrorEliminar;
                _vista.MensajeError.Visible = true;
            }
        }

        public void EliminarTodosAdjuntos()
        {
            usuario = (_vista.Sesion["usuario"] as Clases.Usuario);
            libreta = FabricaEntidad.CrearLibreta();
            (libreta as Clases.Libreta).Idlibreta = int.Parse(_vista.getIdLibreta().ToString());
            comando5 = FabricaComando.CrearComandoBorrarAdjuntosTodos(libreta);
            List<Adjunto> lista = new List<Adjunto>();
            lista = comando5.Ejecutar();
            comando6 = FabricaComando.CrearComandoVerificarAdjuntoEli(lista, usuario);
            comando6.Ejecutar();
            
        }
    }
}