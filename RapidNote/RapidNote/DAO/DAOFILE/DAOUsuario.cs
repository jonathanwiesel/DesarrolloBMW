using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.DAO.IDAOS;
using System.Xml;
using RapidNote.Clases;
using RapidNote.Clases.Fabrica;

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

            usuario.Estado = "Configuracion" + (usuario as Usuario).Correo + ".xml";

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
            XmlFile xmlFile = XmlFile.getInstancia(usuario.Estado);
            // Create an isntance of XmlTextReader and call Read method to read the file
            XmlTextReader textReader = new XmlTextReader(xmlFile.getXmlFolderPath());
            textReader.Read();
            // If the node has value

            textReader.WhitespaceHandling = WhitespaceHandling.None;

            Boolean seccionLibretas = false;

            int i = -1; int j = -1; int k = -1;

            while (textReader.Read())
            {

                if (seccionLibretas == false)
                {
                    if (textReader.Name.Equals("Correo"))
                    {                        
                        textReader.Read();
                        (usuario as Usuario).Correo = textReader.Value;
                        textReader.Read();
                    }

                    if (textReader.Name.Equals("Clave"))
                    {                        
                        textReader.Read();
                        (usuario as Usuario).Clave = textReader.Value;
                        textReader.Read();
                    }

                    if (textReader.Name.Equals("Nombre"))
                    {
                        Console.WriteLine("Name:" + textReader.Name);
                        textReader.Read();
                        Console.WriteLine("Value:" + textReader.Value);
                        (usuario as Usuario).Nombre = textReader.Value;
                        textReader.Read();
                    }

                    if (textReader.Name.Equals("Apellido"))
                    {
                        Console.WriteLine("Name:" + textReader.Name);
                        textReader.Read();
                        Console.WriteLine("Value:" + textReader.Value);
                        (usuario as Usuario).Apellido = textReader.Value;
                        textReader.Read();
                    }

                    if (textReader.Name.Equals("AccesSecret"))
                    {                        
                        textReader.Read();
                        (usuario as Usuario).AccesSecret = textReader.Value;
                        textReader.Read();
                    }

                    if (textReader.Name.Equals("AccesToken"))
                    {
                        //Console.WriteLine("Name:" + textReader.Name);
                        textReader.Read();
                        //Console.WriteLine("Value:" + textReader.Value);
                        (usuario as Usuario).AccesToken = textReader.Value;
                        textReader.Read();
                    }
                }
                else
                {
                    if (textReader.Name.Equals("NombreLibreta"))
                    {
                        i++; j = -1;
                        textReader.Read();
                        Entidad libreta = FabricaEntidad.CrearLibreta();
                        (libreta as Libreta).NombreLibreta = textReader.Value;
                        (usuario as Usuario).ListaLibretas.Add((libreta as Libreta));
                        textReader.Read();
                        seccionLibretas = true;
                    }

                    if (textReader.Name.Equals("Titulo"))
                    {
                        j++;
                        textReader.Read();
                        Entidad nota = FabricaEntidad.CrearNota();
                        (nota as Nota).Titulo = textReader.Value;
                        (usuario as Usuario).ListaLibretas[i].ListaNota.Add((nota as Nota));
                        textReader.Read();
                    }

                    if (textReader.Name.Equals("Contenido"))
                    {                        
                        textReader.Read();
                        (usuario as Usuario).ListaLibretas[i].ListaNota[j].Contenido = textReader.Value;
                        textReader.Read();
                    }

                    if (textReader.Name.Equals("Fechacreacion"))
                    {
                        textReader.Read();
                        (usuario as Usuario).ListaLibretas[i].ListaNota[j].Fechacreacion = Convert.ToDateTime(textReader.Value);
                        textReader.Read();
                    }

                    if (textReader.Name.Equals("Fechamodificacion"))
                    {
                        textReader.Read();
                        if (textReader.Value.Contains("/"))
                        {
                            (usuario as Usuario).ListaLibretas[i].ListaNota[j].Fechacreacion = Convert.ToDateTime(textReader.Value);
                        }
                        textReader.Read();
                    }

                    if (textReader.Name.Equals("Etiquetas"))
                    {                        
                        textReader.Read();
                    }

                    if (textReader.Name.Equals("NombreEtiqueta"))
                    {
                        Console.WriteLine("Name:" + textReader.Name);
                        textReader.Read();
                        Console.WriteLine("Value:" + textReader.Value);
                        Entidad etiqueta = FabricaEntidad.CrearEtiqueta();
                        (etiqueta as Etiqueta).Nombre = textReader.Value;
                        (usuario as Usuario).ListaLibretas[i].ListaNota[j].ListaEtiqueta.Add((etiqueta as Etiqueta));
                        textReader.Read();
                    }

                    if (textReader.Name.Equals("Adjuntos"))
                    {
                        textReader.Read();
                        k = -1;
                    }

                    if (textReader.Name.Equals("NombreArchivo"))
                    {
                        k++;
                        textReader.Read();
                        Entidad adjunto = FabricaEntidad.CrearAdjunto();
                        (adjunto as Adjunto).Titulo = textReader.Value;
                        (usuario as Usuario).ListaLibretas[i].ListaNota[j].ListaAdjunto.Add((adjunto as Adjunto));
                        textReader.Read();
                    }

                    if (textReader.Name.Equals("Urlarchivo"))                    
                    {
                        
                        textReader.Read();
                        if (textReader.Value != "")
                        {
                            (usuario as Usuario).ListaLibretas[i].ListaNota[j].ListaAdjunto[k].Urlarchivo = textReader.Value;
                        }
                        textReader.Read();
                    }

                }

                if (textReader.Name.Equals("Libretas"))
                {                    
                    textReader.Read();
                    seccionLibretas = true;
                }

            }

            return usuario;
        }
    }
}