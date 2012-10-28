using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Presentacion.Contrato.Login;
using RapidNote.Clases;
using RapidNote.Logica.Comandos;
using RapidNote.Logica.Fabrica;
using RapidNote.Clases.Fabrica;

namespace RapidNote.Presentacion.Presentador.Login
{
    public class PresentadorLogin
    {
        private IContratoLogin contrato;

        private Comando<Entidad> comando;

        private Comando<String> comando2;

        private Entidad usuario;

        public PresentadorLogin(IContratoLogin _contrato)
        {
            contrato = _contrato;
        }

        public int Ejecutar() 
        {
            usuario = FabricaEntidad.CrearUsuario();

            (usuario as Usuario).Correo = contrato.getCorreo();
            (usuario as Usuario).Clave = contrato.getClave();

            comando2 = FabricaComando.CrearComandoSha512(contrato.getClave());
            (usuario as Usuario).Clave = comando2.Ejecutar();

            comando = FabricaComando.CrearComandoLogin(usuario);
            usuario = comando.Ejecutar();
            if ((usuario as Usuario).Id > 0)
            {
                contrato.Sesion["usuario"] = usuario;
            }
            return (usuario as Usuario).Id;
        }

    }
}