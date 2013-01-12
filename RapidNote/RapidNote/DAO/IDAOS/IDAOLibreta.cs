using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RapidNote.Clases;

namespace RapidNote.DAO.IDAOS
{
    public interface IDAOLibreta
    {
        /// <summary>
        /// Funcion que guarda en base de datos la libreta que se esta creando.
        /// </summary>
        /// <param name="libreta">Entidad de tipo libreta que contiene el nombre de la libreta</param>
        /// <param name="usuario">Entidad de tipo usuario que contiene el id y el correo del usuario que esta creando la libreta</param>
        /// <returns>Retorna true si se guardo correctamente o false si ocurrio algun error</returns>
        Boolean AgregarLibreta(Entidad libreta, Entidad usuario);

        /// <summary>
        /// Funcion que hace una consulta a base de datos para saber si la libreta ya existe registrado a ese usuario.
        /// </summary>
        /// <param name="libreta">Entidad de tipo libreta que contiene el nombre de la libreta</param>
        /// <param name="usuario">Entidad de tipo usuario que contiene el id y el correo del usuario que esta creando la libreta</param>
        /// <returns>Retorna una entidad de tipo libreta que contiene el id seteado con el id en base de datos o el id vacion si no existe</returns>
        Entidad VerificarLibreta(Entidad libreta, Entidad usuario);

        /// <summary>
        /// Funcion que hace una consulta en base para traer el nombre de la libreta para setear el campo nombre de la pagina editar libreta
        /// </summary>
        /// <param name="libreta">Entidad de tipo libreta que contiene el id de la libreta</param>
        /// <returns>Retorna una entidad de tipo libreta que contiene el nombre de la libreta para setear el campo nombre de la pantalla editar libreta </returns>
        Entidad TraerLibreta(Entidad libreta);

        /// <summary>
        /// Funcion que hace un update en la base de datos en la libreta
        /// </summary>
        /// <param name="libreta">Entidad de tipo libreta que contiene el nombre de la libreta y el id de la libreta de la libreta</param>
        /// <returns>Retorna true si se realizo el update correctamente o false si ocurrio algun error</returns>
        Boolean EditarLibreta(Entidad libreta);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        List<Libreta> ListarLibretas(Entidad usuario);
    }
}
