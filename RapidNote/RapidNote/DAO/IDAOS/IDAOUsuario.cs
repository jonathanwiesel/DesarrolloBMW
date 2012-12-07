using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RapidNote.Clases;

namespace RapidNote.DAO.IDAOS
{
    public interface IDAOUsuario : IDAO
    {
        /// <summary>
        /// Funcion que hace una consulta a base de datos para verificar que ese usuario esta registrado en el sistema.
        /// </summary>
        /// <param name="usuario">entidad de tipo usuario que contiene el correo y la clave del usuario</param>
        /// <returns>Retorna una entidad de tipo usuario que contiene el id, el accesstoken y el accesssecret</returns>
        Entidad ConsultarLogin(Entidad usuario);

        /// <summary>
        /// Funcion que guarda en base de datos el usuario que se esta registrando.
        /// </summary>
        /// <param name="usuario">Entidad de tipo usuario que contiene nombre, apellido, correo y clave</param>
        void AgregarUsuario(Entidad usuario);

        /// <summary>
        /// Funcion que hace una consulta a base de datos para validar si el usuario ya esta registrado.
        /// </summary>
        /// <param name="usuario">Entidad de tipo usuario que contiene nombre, apellido, correo y clave</param>
        /// <returns>Retorna una entidad de tipo usuario con el id del usuario si este ya esta registrado o vacio sino</returns>
        Entidad ListarUsuario(Entidad usuario);

        /// <summary>
        /// Funcion que guarda en base de datos el accesstoken y el accesssecret del usuario.
        /// </summary>
        /// <param name="correo">Parametro que contiene el correo del usuario que esta logueado</param>
        /// <param name="usuario">Entidad de tipo usuario que contiene el accesstoken y el accesssecret</param>
        /// <returns>Restorna true si se guardo correctamente o false si ocurrio algun error</returns>
        Boolean InsertarToken(String correo, Entidad usuario);
    }
}
