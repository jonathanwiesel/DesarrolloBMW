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

        private Comando<Boolean> comando2;

        private Comando<Boolean> comando3;

        private Entidad nota;

        public PresentadorNuevaNota(IContratoNuevaNota _contrato) 
        {
            contrato = _contrato;
        }

        public void IniciarVista() 
        {
            Entidad usuario = (contrato.Sesion["usuario"] as Clases.Usuario);
            comandoLista = FabricaComando.CrearComandoListarLibretas(usuario);
            contrato.setListaLibretas(comandoLista.Ejecutar());
        }

        public void Ejecutar() 
        {
            
            nota = FabricaEntidad.CrearNota();
            (nota as Clases.Nota).Titulo = contrato.getTitulo();
            (nota as Clases.Nota).Contenido = contrato.getContenido();
            (nota as Clases.Nota).Libreta.NombreLibreta = contrato.getNombreLibreta();
            (nota as Clases.Nota).ListaEtiqueta = contrato.getEtiquetas().Cast<Etiqueta>().ToList();

            comando = FabricaComando.CrearComandoNuevaNota(nota);

            nota = comando.Ejecutar();
        }

        public void Adjuntar()
        {
            Entidad usuario = (contrato.Sesion["usuario"] as Clases.Usuario);
            comando2 = FabricaComando.CrearComandoSubirArchivoServidor(contrato.getHfc());
            bool estado = comando2.Ejecutar();
            if (estado == true)
            {
                comando3 = FabricaComando.CrearComandoAdjuntarDropbox(contrato.getRutas(), contrato.getNombrearchivo(), usuario);
                comando3.Ejecutar();
            }
        }
    }
}