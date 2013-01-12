using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.DAO.IDAOS;
using System.Xml;
using RapidNote.Clases;

namespace RapidNote.DAO.DAOFILE
{
    public class DAOUsuario : IDAOUsuario
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public Clases.Entidad ConsultarLogin(Clases.Entidad usuario)
        {
            throw new NotImplementedException();
        }

        public void AgregarUsuario(Clases.Entidad usuario)
        {
            throw new NotImplementedException();
        }

        public Clases.Entidad ListarUsuario(Clases.Entidad usuario)
        {
            throw new NotImplementedException();
        }

        public bool InsertarToken(string correo, Clases.Entidad usuario)
        {
            throw new NotImplementedException();
        }


        public Entidad ExportarConfiguracion(Clases.Entidad usuario)
        {
            XmlFile xmlFile = XmlFile.getInstancia("Configuracion"+(usuario as Usuario).Correo+".xml");

            XmlTextWriter textWriter = new XmlTextWriter(xmlFile.getXmlFolderPath(), null);
            //identar
            textWriter.Formatting = Formatting.Indented;
            textWriter.Indentation = 4;
            // Opens the document
            textWriter.WriteStartDocument();
            // Write comments
            textWriter.WriteComment("Configuracion de usuario");

            textWriter.WriteStartElement("Usuario");

            textWriter.WriteStartElement("Correo", "");
            textWriter.WriteString((usuario as Usuario).Correo);
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("Clave", "");
            textWriter.WriteString((usuario as Usuario).Clave);
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("Nombre", "");
            textWriter.WriteString((usuario as Usuario).Nombre);
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("Apellido", "");
            textWriter.WriteString((usuario as Usuario).Apellido);
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("AccesSecret", "");
            textWriter.WriteString((usuario as Usuario).AccesSecret);
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("AccesToken", "");
            textWriter.WriteString((usuario as Usuario).AccesToken);
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("Libretas");

            for (int i = 0; i < (usuario as Usuario).ListaLibretas.Count; i++) 
            {
                textWriter.WriteStartElement("NombreLibreta", "");
                textWriter.WriteString((usuario as Usuario).ListaLibretas[i].NombreLibreta);
                textWriter.WriteEndElement();
                //textWriter.WriteString((usuario as Usuario).ListaLibretas[i].NombreLibreta);

                for (int j = 0; j < (usuario as Usuario).ListaLibretas[i].ListaNota.Count; j++) 
                {
                    textWriter.WriteStartElement("Nota");
                    
                    textWriter.WriteStartElement("Titulo", "");
                    textWriter.WriteString((usuario as Usuario).ListaLibretas[i].ListaNota[j].Titulo);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("Contenido", "");
                    textWriter.WriteString((usuario as Usuario).ListaLibretas[i].ListaNota[j].Contenido);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("Fechacreacion", "");
                    textWriter.WriteString((usuario as Usuario).ListaLibretas[i].ListaNota[j].Fechacreacion.ToString());
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("Fechamodificacion", "");
                    if ((usuario as Usuario).ListaLibretas[i].ListaNota[j].Fechamodificacion.Year == 1)
                    {
                        textWriter.WriteString("No ha sido modificada");                        
                    }
                    else 
                    {
                        textWriter.WriteString((usuario as Usuario).ListaLibretas[i].ListaNota[j].Fechamodificacion.ToString());
                    }
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("Etiquetas", "");

                    for (int k = 0; k < (usuario as Usuario).ListaLibretas[i].ListaNota[j].ListaEtiqueta.Count; k++) 
                    {
                        textWriter.WriteStartElement("NombreEtiqueta", "");
                        textWriter.WriteString((usuario as Usuario).ListaLibretas[i].ListaNota[j].ListaEtiqueta[k].Nombre);
                        textWriter.WriteEndElement();
                    }

                    textWriter.WriteEndElement();
                    textWriter.WriteStartElement("Adjuntos", "");

                    for (int l = 0; l < (usuario as Usuario).ListaLibretas[i].ListaNota[j].ListaAdjunto.Count; l++)
                    {
                        textWriter.WriteStartElement("NombreArchivo", "");
                        textWriter.WriteString((usuario as Usuario).ListaLibretas[i].ListaNota[j].ListaAdjunto[l].Titulo);
                        textWriter.WriteEndElement();

                        textWriter.WriteStartElement("Urlarchivo", "");
                        textWriter.WriteString((usuario as Usuario).ListaLibretas[i].ListaNota[j].ListaAdjunto[l].Urlarchivo);
                        textWriter.WriteEndElement();
                    }
                    textWriter.WriteEndElement();
                    textWriter.WriteEndElement();                   
                    
                }             

                
            }

            //textWriter.WriteEndElement();

            // Ends the document.
            textWriter.WriteEndDocument();
            // close writer
            textWriter.Close();

            return usuario;
        }


        public Entidad ImportarConfiguracion(Entidad usuario)
        {
            throw new NotImplementedException();
        }
    }
}