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
    public class PresentadorEditarNota
    {
        private IContratoEditarNota contrato;

        private Comando<Entidad> comando;

        private Comando<int> comando1;

        private Comando<List<Entidad>> comandoLista;

        private Entidad nota;

        //private int idNota;

        public PresentadorEditarNota(IContratoEditarNota _contrato) 
        {
            contrato = _contrato;
        }


        public void IniciarVista() 
        {
            Entidad usuario = (contrato.Sesion["usuario"] as Clases.Usuario);
            //comandoLista = FabricaComando.CrearComandoListarLibretas(usuario);
            //contrato.setListaLibretas(comandoLista.Ejecutar());

            //agarro el ID que viene de la pagina de seleccion
            //idNota = int.Parse(contrato.getIdNota());

            //busco la nota segun su ID
            nota = FabricaEntidad.CrearNota();
            (nota as Clases.Nota).Idnota = int.Parse(contrato.getIdNota());

            comando = FabricaComando.CrearComandoBuscarNota(nota);
            nota = comando.Ejecutar();
            
            //cargo la nota a la vista
            contrato.setTitulo((nota as Clases.Nota).Titulo);
            contrato.setContenido((nota as Clases.Nota).Contenido);
            contrato.setNombreLibreta((nota as Clases.Nota).Libreta.NombreLibreta);


            //busco el id de la nota
            //nota = FabricaEntidad.CrearNota();
            //(nota as Clases.Nota).Titulo = contrato.getTitulo();
            //(nota as Clases.Nota).Libreta.NombreLibreta = contrato.getNombreLibreta();

            //comando1 = FabricaComando.CrearComandoBuscarIdNota(nota);

            //idNota = comando1.Ejecutar();
            
        }

        //actualizar
        public void Ejecutar() 
        {
            nota = FabricaEntidad.CrearNota();
            (nota as Clases.Nota).Titulo = contrato.getTitulo();
            (nota as Clases.Nota).Contenido = contrato.getContenido();
            (nota as Clases.Nota).Idnota = int.Parse(contrato.getIdNota());
            (nota as Clases.Nota).Libreta.NombreLibreta = contrato.getNombreLibreta();

            comando = FabricaComando.CrearComandoEditarNota(nota);

            nota = comando.Ejecutar();
        }

        //eliminar
        public void EjecutarDel()
        {
            nota = FabricaEntidad.CrearNota();
            (nota as Clases.Nota).Idnota = int.Parse(contrato.getIdNota());

            comando = FabricaComando.CrearComandoBorrarNota(nota);

            nota = comando.Ejecutar();
        }
    }
}