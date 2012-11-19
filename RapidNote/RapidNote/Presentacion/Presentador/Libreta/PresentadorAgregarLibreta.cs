using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Presentacion.Contrato.Libreta;
using RapidNote.Clases;
using RapidNote.Logica.Comandos;
using RapidNote.Logica.Fabrica;
using RapidNote.Clases.Fabrica;

namespace RapidNote.Presentacion.Presentador.Libreta
{
    public class PresentadorAgregarLibreta
    {
        private IContratoAgregarLibreta _vista;
        private Comando<Boolean> comando;
        private Entidad libreta;
        private Boolean estado;

        public PresentadorAgregarLibreta(IContratoAgregarLibreta vista)
        {
            _vista = vista;
        }

        public Boolean Ejecutar()
        {
            Entidad usuario = (_vista.Sesion["usuario"] as Clases.Usuario);
            libreta = FabricaEntidad.CrearLibreta();
            (libreta as Clases.Libreta).NombreLibreta = _vista.getNombre();
            comando = FabricaComando.CrearComandoAgregarLibreta(libreta, usuario);
            estado = comando.Ejecutar();
            return estado;
        }
    }
}