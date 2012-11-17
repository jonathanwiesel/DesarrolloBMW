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
    }
}