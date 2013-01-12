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

        private Comando<bool> comando2;

        private Comando<bool> comando3;

        private Comando<bool> comando4;

        private Comando<bool> comando5;

        //private Comando<int> comando1;

        private Comando<List<Entidad>> comandoLista;

        private Comando<List<Entidad>> comandolistaadjunto;

        private Comando<Entidad> comandoverificar;
        private Comando<bool> comandodescargar;

        private Comando<bool> comandoeliminardropbox;

        private Comando<bool> comandovisualizar;

        private Comando<int> comandoverificareliminar;

        private Entidad nota;

        private Entidad notaExiste;

        private string _mensajeErrorInsertar = "Error, ya posee una nota igual en esta libreta";

        private string _mensajeErrorServidor = "Error, No se pudo subir los archivos al servidor";

        private string _mensajeErrorDropbox = "Error, No se pudo subir los archivos al Dropbox";

        private string _mensajeErrorDescarga = "Debe seleccionar uno de los archivos de la lista para poder descargarlo";

        private string _mensajeErrorDropEliminar = "Dese seleccionar uno de los archivos de la lista para poder eliminarlo";

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

            //busco las etiquetas de la nota
            comandoLista = FabricaComando.CrearComandoListarEtiquetasPorNota(nota);
            contrato.setListaEtiquetas(comandoLista.Ejecutar());

            comandolistaadjunto = FabricaComando.CrearComandoListarAdjuntosPorNota(nota,usuario);
            contrato.setArchivoAdjunto(comandolistaadjunto.Ejecutar());
        }

        //actualizar
        public void Ejecutar() 
        {
            
            nota = FabricaEntidad.CrearNota();
            (nota as Clases.Nota).Titulo = contrato.getTitulo();
            (nota as Clases.Nota).Contenido = contrato.getContenido();
            (nota as Clases.Nota).Idnota = int.Parse(contrato.getIdNota());
            (nota as Clases.Nota).Libreta.NombreLibreta = contrato.getNombreLibreta();
            (nota as Clases.Nota).ListaEtiqueta = contrato.getEtiquetas().Cast<Clases.Etiqueta>().ToList();
            comando = FabricaComando.CrearComandoEditarNota(nota);
            nota = comando.Ejecutar();
            contrato.Redireccionar("../Vista/Index.aspx");
            
        }

        public bool VerificarNota()
        {
            Entidad usuario = (contrato.Sesion["usuario"] as Clases.Usuario);
            bool estado = false;
            nota = FabricaEntidad.CrearNota();
            (nota as Clases.Nota).Titulo = contrato.getTitulo();
            (nota as Clases.Nota).Idnota = int.Parse(contrato.getIdNota());
            (nota as Clases.Nota).Libreta.NombreLibreta = contrato.getNombreLibreta();
            notaExiste = FabricaEntidad.CrearNota();
            comandoverificar = FabricaComando.CrearComandoVerificarNota(nota, usuario);
            notaExiste = comandoverificar.Ejecutar();
            if ((notaExiste as Clases.Nota).Idnota == 0 || (notaExiste as Clases.Nota).Idnota == (nota as Clases.Nota).Idnota)
            {
                estado = true;
                return estado;
            }
            else
            {
                contrato.MensajeError.Text = _mensajeErrorInsertar;
                contrato.MensajeError.Visible = true;
                return estado;
            }
        }

        //eliminar
        public void EjecutarDel()
        {
            nota = FabricaEntidad.CrearNota();
            (nota as Clases.Nota).Idnota = int.Parse(contrato.getIdNota());

            comando = FabricaComando.CrearComandoBorrarNota(nota);

            nota = comando.Ejecutar();
            contrato.Redireccionar("../Vista/Index.aspx");
        }

        public bool Adjuntar()
        {
            bool resultado = false;
            Entidad usuario = (contrato.Sesion["usuario"] as Clases.Usuario);
            comando2 = FabricaComando.CrearComandoSubirArchivoServidor(contrato.getHfc());
            bool estado = comando2.Ejecutar();
            if (estado == true)
            {
                comando3 = FabricaComando.CrearComandoAdjuntarDropbox(contrato.getRutas(), contrato.getNombrearchivo(), usuario);
                estado = comando3.Ejecutar();
                if (estado == true)
                {
                    comando4 = FabricaComando.CrearComandoAgregarAdjuntoBD(contrato.getRutas(), contrato.getNombrearchivo());
                    comando4.Ejecutar();
                    nota = FabricaEntidad.CrearNota();
                    (nota as Clases.Nota).Idnota = int.Parse(contrato.getIdNota());
                    comando = FabricaComando.CrearComandoBuscarNota(nota);
                    nota = comando.Ejecutar();
                    comando5 = FabricaComando.CrearComandoAgregarAdjuntoConNota(contrato.getRutas(), contrato.getNombrearchivo(), nota, usuario);
                    resultado = comando5.Ejecutar();
                    return resultado;
                }
                else
                {

                    contrato.MensajeError.Text = _mensajeErrorDropbox;
                    contrato.MensajeError.Visible = true;
                    return resultado;
                }
            }
            else
            {

                contrato.MensajeError.Text = _mensajeErrorServidor;
                contrato.MensajeError.Visible = true;
                return resultado;
            }
        }

        public bool DescargarAdjunto()
        {
            bool resultado = false;
            Entidad usuario = (contrato.Sesion["usuario"] as Clases.Usuario);
            if (contrato.archivo() != null)
            {
                comandodescargar = FabricaComando.CrearComandoDescargarDropbox(usuario, contrato.archivo());
                resultado = comandodescargar.Ejecutar();
                return resultado;
            }
            else
            {
                contrato.MensajeError.Text = _mensajeErrorDescarga;
                contrato.MensajeError.Visible = true;
                return resultado;
            }


        }

        public bool EliminarAdjunto()
        {
            bool resultado = false;
            nota = FabricaEntidad.CrearNota();
            (nota as Clases.Nota).Titulo = contrato.getTitulo();
            (nota as Clases.Nota).Idnota = int.Parse(contrato.getIdNota());
            Entidad usuario = (contrato.Sesion["usuario"] as Clases.Usuario);
            if (contrato.archivo() != null)
            {
                comandoverificareliminar = FabricaComando.CrearComandoBorrarAdjunto(nota, contrato.archivo(), usuario);
                int result = comandoverificareliminar.Ejecutar();
                if (result == 0)
                {
                    comandoeliminardropbox = FabricaComando.CrearComandoEliminarAdjuntoDropbox(usuario, contrato.archivo());
                    resultado = comandoeliminardropbox.Ejecutar();
                    contrato.Redireccionar2("../Vista/EditarNota.aspx?id=" + contrato.getIdNota());
                    return resultado;
                }
                else
                {
                    contrato.Redireccionar2("../Vista/EditarNota.aspx?id=" + contrato.getIdNota());
                    resultado = true;
                    return resultado;
                }
            }
            else
            {
                contrato.MensajeError.Text = _mensajeErrorDropEliminar;
                contrato.MensajeError.Visible = true;
                return resultado;
            }
        }

        public bool visualizarAdjunto()
        {
            bool resultado = false;
            Entidad usuario = (contrato.Sesion["usuario"] as Clases.Usuario);
            if (contrato.archivo() != null)
            {
                comandovisualizar = FabricaComando.CrearComandoVisualizarAdjunto(usuario, contrato.archivo());
                resultado = comandovisualizar.Ejecutar();
                return resultado;
            }
            else
            {
                contrato.MensajeError.Text = _mensajeErrorDropEliminar;
                contrato.MensajeError.Visible = true;
                return resultado;
            }
        }
    }
}