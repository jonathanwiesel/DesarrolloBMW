using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.Logica.Comandos.Login;
using RapidNote.Logica.Comandos;
using RapidNote.Logica.Comandos.Nota;
using RapidNote.Logica.Comandos.usuario;
using RapidNote.Logica.Comandos.Usuario;
using RapidNote.Logica.Comandos.Dropbox;
using RapidNote.Logica.Comandos.Libreta;
using RapidNote.Logica.Comandos.Adjunto;

namespace RapidNote.Logica.Fabrica
{
    public class FabricaComando
    {
        public static Comando<Entidad> CrearComandoLogin(Entidad entidad) 
        {
            return new ComandoLogin(entidad);
        }

        public static Comando<List<Entidad>> CrearComandoListarNotas(Entidad entidad) 
        {
            return new ComandoListarNotas(entidad);
        }

        public static Comando<Entidad> CrearComandoMostrarNota(Entidad entidad) 
        {
            return new ComandoMostrarNota(entidad);
        }

        public static Comando<List<Entidad>> CrearComandoListarAdjuntosPorNota(Entidad entidad) 
        {
            return new ComandoListarAdjuntosPorNota(entidad);
        }

        public static Comando<List<Entidad>> CrearComandoListarEtiquetasPorNota(Entidad nota)
        {
            return new ComandoListarEtiquetasPorNota(nota);
        }

        public static Comando<Entidad> CrearComandoNuevaNota(Entidad nota) 
        {
            return new ComandoNuevaNota(nota);
        }

        public static Comando<List<Entidad>> CrearComandoListarLibretas(Entidad entidad) 
        {
            return new ComandoListarLibretas(entidad);
        }

        public static Comando<Entidad> CrearComandoAgregarUsuario(Entidad entidad)
        {
            return new ComandoAgregarUsuario(entidad);
        }

        public static Comando<String> CrearComandoSha512(String clave)
        {
            return new ComandoSha512(clave);
        }

        public static Comando<Entidad> CrearComandoListaUsuario(Entidad entidad)
        {
            return new ComandoListaUsuario(entidad);
        }

        public static Comando<List<Entidad>> CrearComandoBuscarNotas(Entidad usuario) 
        {
            return new ComandoBuscarNotas(usuario);
        }

        public static Comando<Entidad> CrearComandoEditarNota(Entidad nota)
        {
            return new ComandoEditarNota(nota);
        }

        public static Comando<Entidad> CrearComandoBorrarNota(Entidad nota)
        {
            return new ComandoBorrarNota(nota);
        }

        public static Comando<int> CrearComandoBuscarIdNota(Entidad nota)
        {
            return new ComandoBuscarIdNota(nota);
        }

        public static Comando<Entidad> CrearComandoBuscarNota(Entidad nota)
        {
            return new ComandoBuscarNota(nota);
        }

        public static Comando<String> CrearComandoAutentificacionDropbox(String puerto)
        {
            return new ComandoAutentificarDropbox(puerto);
        }

        public static Comando<Boolean> CrearComandoObetenerToken(String correo)
        {
            return new ComandoObtenerToken(correo);
        }

        public static Comando<Boolean> CrearComandoAgregarLibreta(Entidad libreta, Entidad usuario)
        {
            return new ComandoAgregarLibreta(libreta, usuario);
        }

        public static Comando<Boolean> CrearComandoAdjuntarDropbox(string[] archivo, string[] nombre, Entidad usuario)
        {
            return new ComandoAdjuntarDropbox(archivo, nombre, usuario);
        }


        public static Comando<Boolean> CrearComandoSubirArchivoServidor(HttpFileCollection hfc)
        {
            return new ComandoSubirArchivoServidor(hfc);
        }

        public static Comando<Entidad> CrearComandoVerificarLibreta(Entidad libreta, Entidad usuario)
        {
            return new ComandoVerificarLibreta(libreta, usuario);
        }

        public static Comando<Entidad> CrearComandoTraerLibreta(Entidad libreta)
        {
            return new ComandoTraerLibreta(libreta);
        }

        public static Comando<Boolean> CrearComandoEditarLibreta(Entidad libreta)
        {
            return new ComandoEditarLibreta(libreta);
        }

        public static Comando<List<Entidad>> CrearComandoListarNotasLibreta(Entidad libreta)
        {
            return new ComandoListarNotasLibreta(libreta);
        }

        public static Comando<Entidad> CrearComandoVerificarNota(Entidad nota, Entidad usuario)
        {
            return new ComandoVerificarNota(nota, usuario);
        }

        public static Comando<bool> CrearComandoAgregarAdjuntoBD(string[] archivo, string[] nombre)
        {
            return new ComandoAgregarAdjuntoBD(archivo, nombre);
        }

        public static Comando<bool> CrearComandoAgregarAdjuntoConNota(string[] archivo, string[] nombre, Entidad nota, Entidad usuario)
        {
            return new ComandoAgregarAdjuntoConNota(archivo, nombre, nota, usuario);
        }

    }
}