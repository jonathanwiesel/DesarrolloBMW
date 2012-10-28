using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Presentacion.Contrato.Nota;
using RapidNote.Logica.Comandos;
using RapidNote.Clases;
using RapidNote.Logica.Fabrica;
using RapidNote.Clases.Fabrica;

namespace RapidNote.Presentacion.Presentador.Nota
{
    public class PresentadorMostrarNota
    {
        private IContratoMostrarNota contrato;

        private Comando<List<Entidad>> comando;

        private Comando<Entidad> comandoMuestra;

        public PresentadorMostrarNota(IContratoMostrarNota _contrato) 
        {
            contrato = _contrato;
        }

        public void IniciarVista() 
        {
            Entidad usuario = (contrato.Sesion["usuario"] as Usuario);
            comando = FabricaComando.CrearComandoListarTituloNotas(usuario);
            contrato.setListaNotas(comando.Ejecutar());
        }

        public void Ejecutar() 
        {
            Entidad nota = FabricaEntidad.CrearNota();
            (nota as Clases.Nota).Titulo = contrato.getTituloNota();
            comandoMuestra = FabricaComando.CrearComandoMostrarNota(nota);
            nota = comandoMuestra.Ejecutar();

            contrato.setContenido((nota as Clases.Nota).Contenido);
            contrato.setNombreLibreta((nota as Clases.Nota).Libreta.NombreLibreta);            
            contrato.setFechaCreacion((nota as Clases.Nota).Fechacreacion.ToString());
            if ((nota as Clases.Nota).Fechamodificacion.Year<2010)
            {
                contrato.setFechaModificacion("No ha sido modificado");
            }
            else 
            {
                contrato.setFechaModificacion((nota as Clases.Nota).Fechamodificacion.ToString());
            }

            comando = FabricaComando.CrearComandoListarAdjuntosPorNota(nota);
            contrato.setArchivoAdjunto(comando.Ejecutar());

            comando = FabricaComando.CrearComandoListarEtiquetasPorNota(nota);
            contrato.setListaEtiquetas(comando.Ejecutar());

        }
    }
}