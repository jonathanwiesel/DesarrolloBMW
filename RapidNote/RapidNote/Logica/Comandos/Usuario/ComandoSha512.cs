using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using RapidNote.Clases;
using RapidNote.DAO.DAOFactory;
using RapidNote.DAO.IDAOS;

namespace RapidNote.Logica.Comandos.Usuario
{
    public class ComandoSha512 : Comando<String>
    {
        private String clave;
        public String text;

        public ComandoSha512(string _clave)
        {
            clave = _clave;
        }

        public override string Ejecutar()
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;

            byte[] message = UE.GetBytes(clave);

            SHA512Managed hashString = new SHA512Managed();

            text = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
            text += String.Format("{0:x2}", x);
            }
            return text;
        }

        
    }
}