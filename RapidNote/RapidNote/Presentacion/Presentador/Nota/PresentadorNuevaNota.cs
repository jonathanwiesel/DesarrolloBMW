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
    public class PresentadorNuevaNota
    {
        private IContratoNuevaNota contrato;

        private Comando<Entidad> comando;

        private Comando<List<Entidad>> comandoLista;

        private Entidad nota;

        public PresentadorNuevaNota(IContratoNuevaNota _contrato) 
        {
            contrato = _contrato;
        }

        public void IniciarVista() 
        {
            Entidad usuario = (contrato.Sesion["usuario"] as Usuario);
            comandoLista = FabricaComando.CrearComandoListarLibretas(usuario);
            contrato.setListaLibretas(comandoLista.Ejecutar());
        }

        public void Ejecutar() 
        {
            nota = FabricaEntidad.CrearNota();
            (nota as Clases.Nota).Titulo = contrato.getTitulo();
            (nota as Clases.Nota).Contenido = contrato.getContenido();
            (nota as Clases.Nota).Libreta.NombreLibreta = contrato.getNombreLibreta();

            comando = FabricaComando.CrearComandoNuevaNota(nota);

            nota = comando.Ejecutar();
        }
    }
}