using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.Logica.Comandos;
using RapidNote.Presentacion.Contrato.Usuario;
using RapidNote.Clases.Fabrica;
using RapidNote.Logica.Fabrica;

namespace RapidNote.Presentacion.Presentador.Usuario
{
    public class PresentadorImportarConfiguracion
    {
        private IContratoImportarConfiguracion contrato;
        private Comando<Entidad> comando;

        public PresentadorImportarConfiguracion(IContratoImportarConfiguracion _contrato) 
        {
            contrato = _contrato;
        }

        public void Ejecutar() 
        {
            Entidad usuario = FabricaEntidad.CrearUsuario();
            usuario.Estado = contrato.nombreArchivo;

            comando = FabricaComando.CrearComandoSubirArchivo(contrato.fileUpload);
            comando.Ejecutar();

            comando = FabricaComando.CrearComandoImportarConfiguracion(usuario);
            usuario = comando.Ejecutar();
        }
    }
}