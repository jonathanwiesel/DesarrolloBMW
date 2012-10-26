using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace RapidNote.DAO
{
    public class Conexion
    {
        private static string servidor = "localhost";
        private static string nombrebd = "rapidNote";
        private static string CadenaConexion = "Data Source=" + servidor + ";Initial Catalog=" + nombrebd + ";Integrated Security=True";
        private static SqlConnection conexion = new SqlConnection(CadenaConexion);

        public Conexion()
        { }

        public string GetCadenaConexion()
        {
            return CadenaConexion;
        }

        public void AbrirConexionBd()
        {
            try
            {
                String estadoConexion = null;
                estadoConexion = conexion.State.ToString();

                if (estadoConexion.Equals("Open"))
                    conexion.Close();

                conexion.ConnectionString = GetCadenaConexion();
                conexion.Open();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CerrarConexionBd()
        {
            String estadoConexion = null;
            estadoConexion = conexion.State.ToString();

            if (estadoConexion.Equals("Open"))

                conexion.Close();
        }

        public SqlConnection ObjetoConexion()
        {
            return (conexion);
        }
    }
}