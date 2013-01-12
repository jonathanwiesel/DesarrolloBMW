using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapidNote.DAO
{
    public class XmlFile
    {
        private static XmlFile xmlFile;

        private static string folderFileName;

        private XmlFile(string _folderFileName)
        {
            folderFileName = _folderFileName;
        }

        public static XmlFile getInstancia(string _folderFileName) 
        {
            if (xmlFile == null) 
            {
                xmlFile = new XmlFile(_folderFileName);
            }

            return xmlFile;
        }
        
        public String getXmlFolderPath()
        {
            //String xmlFolderPath = System.IO.Directory.GetCurrentDirectory();
            //String parentPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + xmlFolderPath.Replace('/', System.IO.Path.DirectorySeparatorChar);

            String xmlFolderPath = AppDomain.CurrentDomain.BaseDirectory ;

            for (int j = 0; j < 3; j++)
            {
                //parentPath = System.IO.Directory.GetParent(xmlFolderPath).ToString();
            }

            xmlFolderPath += "\\xml\\" + folderFileName;

            Console.WriteLine("xmlFolderPath: " + xmlFolderPath);

            return xmlFolderPath;
        }

    }
}