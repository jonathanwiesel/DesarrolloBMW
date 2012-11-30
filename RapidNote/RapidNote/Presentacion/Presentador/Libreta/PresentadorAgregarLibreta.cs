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
        private Comando<Entidad> comando2;
        private string _mensajeErrorInsertar = "Error al insertar en base de datos";
        private string _mensajeErrorExiste = "Error, ya posee una libreta con ese nombre";
        private Entidad libreta;
        private Boolean estado;

        public PresentadorAgregarLibreta(IContratoAgregarLibreta vista)
        {
            _vista = vista;
        }

        public void Ejecutar()
        {
            Entidad usuario = (_vista.Sesion["usuario"] as Clases.Usuario);
            libreta = FabricaEntidad.CrearLibreta();
            (libreta as Clases.Libreta).NombreLibreta = _vista.getNombre();
            comando2 = FabricaComando.CrearComandoVerificarLibreta(libreta, usuario);
            libreta = comando2.Ejecutar();
            if ((libreta as Clases.Libreta).Idlibreta == 0)
            {
                comando = FabricaComando.CrearComandoAgregarLibreta(libreta, usuario);
                estado = comando.Ejecutar();
                if (estado == true)
                {
                    _vista.Redireccionar("../Vista/NuevaNota.aspx");
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
    }
}