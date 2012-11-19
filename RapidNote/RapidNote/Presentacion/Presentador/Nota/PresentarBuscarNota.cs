using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Presentacion.Contrato.Nota;
using RapidNote.Clases;
using RapidNote.Logica.Comandos;
using RapidNote.Clases.Fabrica;
using RapidNote.Logica.Fabrica;

namespace RapidNote.Presentacion.Presentador.Nota
{
    public class PresentarBuscarNota
    {
        private IContratoBuscarNota contrato;

        private Comando<List<Entidad>> comando;

        public PresentarBuscarNota(IContratoBuscarNota _contrato) 
        {
            contrato = _contrato;
        }

        public void IniciarVista() 
        {
            Entidad usuario = (contrato.Sesion["usuario"] as Clases.Usuario);
            usuario.Estado = contrato.contenidoBusqueda;
            List<Entidad> listaNotas;

            comando = FabricaComando.CrearComandoBuscarNotas(usuario);

            listaNotas = comando.Ejecutar();

            contrato.gridviewnota = listaNotas;
            
        }
    }
}