using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
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
        private Comando<String> comando4;
        private Entidad usuario;
        private List<Entidad> lista = new List<Entidad>();
        private string clave;
        private String _mensajeErrorUsuario = "Ya existe un usuario en el sistema con este correo";
        private Vista.CrearLibreta crearLibreta;



        public PresentadorAgregarUsuario(IcontratoAgregarUsuario vista)
        {
            _vista = vista;

        }

        public PresentadorAgregarUsuario(Vista.CrearLibreta crearLibreta)
        {
            // TODO: Complete member initialization
            this.crearLibreta = crearLibreta;
        }
        public String Ejecutar()
        {
            usuario = FabricaEntidad.CrearUsuario();
            comando2 = FabricaComando.CrearComandoSha512(_vista.getclave());
            clave = comando2.Ejecutar();
            (usuario as Clases.Usuario).Nombre = _vista.getNombre();
            (usuario as Clases.Usuario).Apellido = _vista.getApellido();
            (usuario as Clases.Usuario).Correo = _vista.getCorreo();
            (usuario as Clases.Usuario).Clave = clave;
            comando3 = FabricaComando.CrearComandoListaUsuario(usuario);
            usuario = comando3.Ejecutar();
            if ((usuario as Clases.Usuario).Id == 0)
            {
                comando = FabricaComando.CrearComandoAgregarUsuario(usuario);
                comando.Ejecutar();
                _vista.Correo["Correo"] = _vista.getCorreo();
                comando4 = FabricaComando.CrearComandoAutentificacionDropbox(_vista.puerto);
                String ruta = comando4.Ejecutar();
                return ruta;
            }
            else
            {
                _vista.MensajeError.Text = _mensajeErrorUsuario;
                _vista.MensajeError.Visible = true;
                string valor = "Ya existe";
                return valor;
            }

        }



    }

}
