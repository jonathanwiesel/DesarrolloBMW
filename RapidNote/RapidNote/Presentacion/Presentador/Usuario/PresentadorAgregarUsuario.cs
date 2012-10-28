using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RapidNote.Presentacion.Contrato;
using RapidNote.Clases;
using RapidNote.Logica.Comandos;
using RapidNote.Logica.Fabrica;
using RapidNote.Clases.Fabrica;

namespace RapidNote.Presentacion.Presentador
{
    public class PresentadorAgregarUsuario
    {
        private IcontratoAgregarUsuario _vista;

        private Comando<Entidad> comando;
        private Comando<String> comando2;
        private Comando<Entidad> comando3;
        private Entidad usuario;
        private List<Entidad> lista = new List<Entidad>();
        private string clave;
        private String _mensajeErrorUsuario = "Ya existe un usuario en el sistema con este correo";

        

        public PresentadorAgregarUsuario(IcontratoAgregarUsuario vista)
        {
            _vista = vista;

        }
        public void Ejecutar()
        {
            comando2 = FabricaComando.CrearComandoSha512(_vista.getclave());
            clave = comando2.Ejecutar();
            usuario = FabricaEntidad.CrearUsuario();
            (usuario as Usuario).Nombre = _vista.getNombre();
            (usuario as Usuario).Apellido = _vista.getApellido();
            (usuario as Usuario).Correo = _vista.getCorreo();
            (usuario as Usuario).Clave = clave;
            comando3 = FabricaComando.CrearComandoListaUsuario(usuario);
            usuario = comando3.Ejecutar();
            if ((usuario as Usuario).Id == 0)
            {
                comando = FabricaComando.CrearComandoAgregarUsuario(usuario);
                comando.Ejecutar();
            }
            else
            {
                _vista.MensajeError.Text = _mensajeErrorUsuario;
                _vista.MensajeError.Visible = true;
            }
           
        }


       
    }

}
