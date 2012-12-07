using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RapidNote.Clases;

namespace RapidNote.DAO.IDAOS
{
    public interface IDAOAdjunto
    {
        /// <summary>
        /// Funcion que guarda en base de datos la ruta y el nombre del adjunto.
        /// </summary>
        /// <param name="adjunto">Parametro de tipo entidad que contiene el url y el titulo del adjunto</param>
        /// <returns>Retorna true si se guardo correctamente o false si ocurrio algun error</returns>
        bool AdjuntarBD(Entidad adjunto);

        /// <summary>
        /// Funcion que hace una consulta a base de datos para saber si el adjunto ya existe.
        /// </summary>
        /// <param name="adjunto">Parametro de tipo entidad que contiene el url y el titulo del adjunto</param>
        /// <returns>Retorna una entidad de tipo adjunto que contiene el id del adjunto</returns>
        Entidad VerificarAdjunto(Entidad adjunto);

        /// <summary>
        /// Funcion que guarda den base de datos el id de la nota y el id del adjunto en la tabla q rompe de la relacion
        /// mucho a mucho entre nota y adjunto.
        /// </summary>
        /// <param name="nota">Parametro de tipo entidad que contiene el id de la nota en base de datos</param>
        /// <param name="adjunto">Parametro de tipo entidad que contiene el id del adjunto en base de datos</param>
        /// <returns>Retorna true si se guardo correctamente o false si ocurrio algun error</returns>
        bool AgregarAdjunto_Nota(Entidad nota, Entidad adjunto);

        /// <summary>
        /// Funcion que borra los adjuntos relacionados a la nota.
        /// </summary>
        /// <param name="nota">Parametro de tipo entidad que contiene el id de la nota en base de datos</param>
        /// <returns>Retorna una entidad</returns>
        Entidad BorrarAdjunto(Entidad nota);
    }
}
