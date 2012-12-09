using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RapidNote.Clases;

namespace RapidNote.DAO.IDAOS
{
    public interface IDAONota : IDAO
    {
        /// <summary>
        /// Lista las notas de un usuario
        /// </summary>
        /// <param name="usuario">variable usuario</param>
        /// <returns>Devuelve una lista de notas</returns>
        List<Entidad> ListarNotas(Entidad usuario);

        /// <summary>
        /// Trae el contenido completo de una nota
        /// </summary>
        /// <param name="nota">variable nota</param>
        /// <returns>Trae todos los atributos de la nota</returns>
        Entidad MostrarNota(Entidad nota);

        /// <summary>
        /// Trae los adjuntos de una nota
        /// </summary>
        /// <param name="nota">variable nota</param>
        /// <param name="usuario">variable usuario</param>
        /// <returns>Trae todos los adjuntos de una nota de ese usuario</returns>
        List<Entidad> ListarAjuntos(Entidad nota, Entidad usuario);

        /// <summary>
        /// Trae las etiquetas de una nota
        /// </summary>
        /// <param name="nota">variable nota</param>
        /// <returns>Trae todos las etiquetas de una nota</returns>
        List<Entidad> ListarEtiquetas(Entidad nota);

        /// <summary>
        /// Crea una nota nueva
        /// </summary>
        /// <param name="nota">variable nota</param>
        /// <returns>Devuelve la misma variable</returns>
        Entidad NuevaNota(Entidad nota);

        /// <summary>
        /// Trae las libretas de un usuario
        /// </summary>
        /// <param name="nota">variable usuario</param>
        /// <returns>Devuelve una lista de libretas</returns>
        List<Entidad> ListarLibretas(Entidad usuario);

        /// <summary>
        /// Trae las notas buscando por el contenido de sus etiquetas
        /// </summary>
        /// <param name="usuario">variable usuario</param>
        /// <returns>Trae una lista de notas</returns>
        List<Entidad> BuscarNotasEtiqueta(Entidad usuario);

        /// <summary>
        /// Trae las notas buscando por el contenido de las mismas
        /// </summary>
        /// <param name="usuario">vaiable usuario</param>
        /// <returns>Trae una lista de notas</returns>
        List<Entidad> BuscarNotas(Entidad usuario);

        /// <summary>
        /// Edita una nota
        /// </summary>
        /// <param name="nota">variable nota</param>
        /// <returns>devuelve la nota editada</returns>
        Entidad EditarNota(Entidad nota);

        /// <summary>
        /// Borra una nota
        /// </summary>
        /// <param name="nota">variable nota</param>
        /// <returns>devuelve la nota borrada</returns>
        Entidad BorrarNota(Entidad nota);

        /// <summary>
        /// Busca el id de una nota por su contenido
        /// </summary>
        /// <param name="nota">variable</param>
        /// <returns>Devuelve un entero, el id de la nota</returns>
        int BuscarIdNota(Entidad nota);

        /// <summary>
        /// Busca una nota por su id
        /// </summary>
        /// <param name="nota">variable de tipo nota</param>
        /// <returns>devuelve la nota con todos los datos</returns>
        Entidad BuscarNota(Entidad nota);

        /// <summary>
        /// Trae las notas de una libreta
        /// </summary>
        /// <param name="libreta">variable libreta</param>
        /// <returns>Trae una liasta de notas</returns>
        List<Entidad> ListarNotasLibreta(Entidad libreta);

        /// <summary>
        /// Verifica si esa nota ya existe, se busca por titulo
        /// </summary>
        /// <param name="nota">variable nota</param>
        /// <param name="usuario">variable usuario</param>
        /// <returns>Devuelve la nota a verificar</returns>
        Entidad VerificarNota(Entidad nota, Entidad usuario);
    }
}
