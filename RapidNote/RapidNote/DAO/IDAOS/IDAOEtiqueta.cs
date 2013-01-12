using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RapidNote.Clases;

namespace RapidNote.DAO.IDAOS
{
    public interface IDAOEtiqueta
    {
        /// <summary>
        /// Trae las etiquetas de un usuario
        /// </summary>
        /// <param name="usuario">variable usuario</param>
        /// <returns>Devuelde una lista de etiquetas</returns>
        List<Entidad> ListarEtiquetas(Entidad usuario);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nota"></param>
        /// <returns></returns>
        List<Etiqueta> ListarEtiquetasDeNota(Entidad nota);
        
    }
}
