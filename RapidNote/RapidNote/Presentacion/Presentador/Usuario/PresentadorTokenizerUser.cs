using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Presentacion.Contrato.Usuario;
using RapidNote.Presentacion.Contrato;
using RapidNote.Clases;
using RapidNote.Logica.Comandos;
using RapidNote.Logica.Fabrica;
using RapidNote.Clases.Fabrica;

namespace RapidNote.Presentacion.Presentador.Usuario
{
    public class PresentadorTokenizerUser
    {
        private IcontratoTokenizeUser _vista;
        private Comando<Boolean> comando;
        private bool estado = false;
        public PresentadorTokenizerUser(IcontratoTokenizeUser vista)
        {
            _vista = vista;
        }

        public Boolean IniciarVista()
        {
            String correo = (_vista.Correo["correo"] as String);
            if (correo != null)
            {
                comando = FabricaComando.CrearComandoObetenerToken(correo);
                estado = comando.Ejecutar();
                return estado;
            }
            else
            {
                return estado;
            }
        }
    }

}