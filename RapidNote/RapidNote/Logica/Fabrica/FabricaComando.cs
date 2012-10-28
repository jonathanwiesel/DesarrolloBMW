using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.Logica.Comandos.Login;
using RapidNote.Logica.Comandos;
using RapidNote.Logica.Comandos.Nota;

namespace RapidNote.Logica.Fabrica
{
    public class FabricaComando
    {
        public static Comando<Entidad> CrearComandoLogin(Entidad entidad) 
        {
            return new ComandoLogin(entidad);
        }

        public static Comando<List<Entidad>> CrearComandoListarTituloNotas(Entidad entidad) 
        {
            return new ComandoListarTituloNotas(entidad);
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
    }
}