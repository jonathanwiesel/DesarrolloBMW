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

        private Comando<Entidad> comando4;

        private Comando<bool> comando5;

        private Comando<bool> comando6;

        private Entidad nota;

        private Entidad notaExiste;

        private string _mensajeErrorInsertar = "Error, ya posee una nota igual en esta libreta";

        private string _mensajeErrorServidor = "Error, No se pudo subir los archivos al servidor";

        private string _mensajeErrorDropbox = "Error, No se pudo subir los archivos al Dropbox";
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
            Entidad usuario = (contrato.Sesion["usuario"] as Clases.Usuario);
            nota = FabricaEntidad.CrearNota();
            (nota as Clases.Nota).Titulo = contrato.getTitulo();
            (nota as Clases.Nota).Contenido = contrato.getContenido();
            (nota as Clases.Nota).Libreta.NombreLibreta = contrato.getNombreLibreta();
            (nota as Clases.Nota).ListaEtiqueta = contrato.getEtiquetas().Cast<Etiqueta>().ToList();
            notaExiste = FabricaEntidad.CrearNota();
            comando4 = FabricaComando.CrearComandoVerificarNota(nota, usuario);
            notaExiste = comando4.Ejecutar();
            if ((notaExiste as Clases.Nota).Idnota == 0)
            {
                comando = FabricaComando.CrearComandoNuevaNota(nota);
                nota = comando.Ejecutar();
                comando6 = FabricaComando.CrearComandoAgregarAdjuntoConNota(contrato.getRutas(), contrato.getNombrearchivo(), nota, usuario);
                comando6.Ejecutar();
            }
            else 
            {
                contrato.MensajeError.Text = _mensajeErrorInsertar;
                contrato.MensajeError.Visible = true;
            }
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
                    comando5 = FabricaComando.CrearComandoAgregarAdjuntoBD(contrato.getRutas(), contrato.getNombrearchivo());
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
    }
}