﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Logica.Comandos;
using RapidNote.Clases;
using RapidNote.Logica.Fabrica;
using RapidNote.Presentacion.Contrato.Usuario;

namespace RapidNote.Presentacion.Presentador.Usuario
{
    public class PresentadorExportarConfiguracion
    {
        private IContratoExportarConfiguracion contrato;
        private Comando<Entidad> comando;

        public PresentadorExportarConfiguracion(IContratoExportarConfiguracion _contrato) 
        {
            contrato = _contrato;
        }

        public Entidad Ejecutar() 
        {
            Entidad usuario = (contrato.Sesion["usuario"] as Clases.Usuario);

            comando = FabricaComando.CrearComandoExportarConfiguracion(usuario);
            usuario = comando.Ejecutar();

            return usuario;
        }
    }
}