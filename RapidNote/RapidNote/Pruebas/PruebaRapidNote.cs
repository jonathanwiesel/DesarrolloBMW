using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using RapidNote.Clases;
using RapidNote.Clases.Fabrica;
using RapidNote.Logica.Comandos;
using RapidNote.Logica.Fabrica;
using NUnit.Framework;
using Spring.Social.OAuth1;
using Spring.Social.Dropbox.Api;
using Spring.Social.Dropbox.Connect;
using RapidNote.DAO.IDAOS;
using RapidNote.DAO.DAOFactory;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace RapidNote.Pruebas
{
    [TestFixture]
    public class PruebaRapidNote
    {
        Entidad usuario;
        Entidad nota;
        Entidad libreta;
        Entidad adjunto;
        string DropboxAppKey;
        string DropboxAppSecret;
        IWebDriver selenium;

        [SetUp]
        public void Before()
        {
            DropboxAppKey = "dbhvzaf6ugr4k6q";
            DropboxAppSecret = "q35bdvwgrut9bq4";
            usuario = FabricaEntidad.CrearUsuario();
            nota = FabricaEntidad.CrearNota();
            libreta = FabricaEntidad.CrearLibreta();
            adjunto = FabricaEntidad.CrearAdjunto();

            FirefoxProfile firefoxProf = new FirefoxProfile();

            selenium = new FirefoxDriver();
            selenium.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));

        }

        [TearDown]
        public void After()
        {
            usuario = null;
            nota = null;
            libreta = null;
            DropboxAppKey = null;
            DropboxAppSecret = null;
            adjunto = null;

            if (selenium != null) {
                selenium.Close();
            }
        }

        [Test]
        public void BuscarCadena()
        {

            string cadenaBuscar = "NotaPrueba";

            //creo un usuario
            (usuario as Clases.Usuario).Nombre = "NombrePrueba";
            (usuario as Clases.Usuario).Apellido = "ApellidoPrueba";
            (usuario as Clases.Usuario).Correo = "correoPrueba@prueba.com";
            (usuario as Clases.Usuario).Clave = "12345";

            Comando<Entidad> comandoVerificarExistenciaUsuario = FabricaComando.CrearComandoListaUsuario(usuario);
            usuario = comandoVerificarExistenciaUsuario.Ejecutar();
            if ((usuario as Clases.Usuario).Id == 0)
            {
                //si no entra es que la prueba ya se hizo una vez y el usuario ya esta insertado
                Comando<Entidad> comandoInsertarUsuario = FabricaComando.CrearComandoAgregarUsuario(usuario);
                comandoInsertarUsuario.Ejecutar();
            }


            //segun storedProcedure sabemos que se tiene la siguiete libreta por defecto al crear usuario
            (libreta as Clases.Libreta).NombreLibreta = "Libreta por defecto de NombrePrueba ApellidoPrueba";

            //creo una nota
            (nota as Clases.Nota).Titulo = cadenaBuscar;
            (nota as Clases.Nota).Contenido = "Nota de prueba para pruebas unitarias";
            (nota as Clases.Nota).Libreta.NombreLibreta = (libreta as Clases.Libreta).NombreLibreta;

            Entidad notaExiste = FabricaEntidad.CrearNota();
            Comando<Entidad> comandoVerificarExistenciaNota = FabricaComando.CrearComandoVerificarNota(nota, usuario);
            notaExiste = comandoVerificarExistenciaNota.Ejecutar();

            if ((notaExiste as Clases.Nota).Idnota == 0)
            {
                //si no entra es que la prueba ya se hizo una vez y la nota ya esta insertada
                Comando<Entidad> comandoCrearNota = FabricaComando.CrearComandoNuevaNota(nota);
                nota = comandoCrearNota.Ejecutar();
            }

            //busco la nota por su nombre
            usuario.Estado = cadenaBuscar;
            List<Entidad> listaNotas;
            Comando<List<Entidad>> comandoBuscar = FabricaComando.CrearComandoBuscarNotas(usuario);
            listaNotas = comandoBuscar.Ejecutar();

            //hago las asericiones
            Assert.IsNotNull(listaNotas);
            Assert.IsTrue(listaNotas.Count > 0);
            Assert.AreEqual((listaNotas[0] as Clases.Nota).Titulo, cadenaBuscar);
        }

        [Test]
        public void NotaConTresAdjuntos()
        {

            //setteo el usuario
            (usuario as Clases.Usuario).Nombre = "elbano";
            (usuario as Clases.Usuario).Apellido = "marquez";
            (usuario as Clases.Usuario).Correo = "elbano28@gmail.com";
            (usuario as Clases.Usuario).Clave = "e1223d9bbcd82236f9f09ae1f5578e3cbbd4e8f48954cead3003be60ac85629726dc04b1f875353459f97ba4a4283a1a6adb89d3524bb4816c7125964097106c";
            (usuario as Clases.Usuario).AccesSecret = "meteinmqlaznshx";
            (usuario as Clases.Usuario).AccesToken = "v8t8xvv80h9dzqs";

            //creo una nota
            (nota as Clases.Nota).Titulo = "NotaPruebaTresAdjuntos";
            (nota as Clases.Nota).Contenido = "Nota de prueba para pruebas unitarias con tres adjuntos";

            (nota as Clases.Nota).Libreta.NombreLibreta = "Libreta de elbano";

            Entidad notaExiste = FabricaEntidad.CrearNota();
            Comando<Entidad> comandoVerificarExistenciaNota = FabricaComando.CrearComandoVerificarNota(nota, usuario);
            notaExiste = comandoVerificarExistenciaNota.Ejecutar();

            string curretDirectory = @"C:\Users\elbano\Documents\GitHub\DesarrolloBMW\RapidNote\RapidNote\Archivo\";
            string[] rutas = { curretDirectory + "Koala.jpg", curretDirectory + "Tulips.jpg", curretDirectory + "Penguins.jpg" };
            string[] nombres = { "Koala.jpg", "Tulips.jpg", "Penguins.jpg" };

            if ((notaExiste as Clases.Nota).Idnota == 0)
            {
                bool resultado = false;


                Comando<Boolean> comando3 = FabricaComando.CrearComandoAdjuntarDropbox(rutas, nombres, usuario);
                bool estado = comando3.Ejecutar();
                if (estado == true)
                {
                    Comando<bool> comando5 = FabricaComando.CrearComandoAgregarAdjuntoBD(rutas, nombres);
                    resultado = comando5.Ejecutar();

                    if (resultado == true)
                    {

                        Comando<Entidad> comando = FabricaComando.CrearComandoNuevaNota(nota);
                        nota = comando.Ejecutar();
                        Comando<bool> comando6 = FabricaComando.CrearComandoAgregarAdjuntoConNota(rutas, nombres, nota, usuario);
                        comando6.Ejecutar();
                    }
                }
            }

            //busco la nota para hacer las aserciones

            usuario.Estado = "NotaPruebaTresAdjuntos";
            List<Entidad> listaNotas;
            Comando<List<Entidad>> comandoBuscar = FabricaComando.CrearComandoBuscarNotas(usuario);
            listaNotas = comandoBuscar.Ejecutar();

            Assert.IsNotNull(listaNotas);
            Assert.IsTrue(listaNotas.Count > 0);
            Assert.AreEqual((listaNotas[0] as Clases.Nota).Titulo, "NotaPruebaTresAdjuntos");
            int j = 0;
            for (int i = 0; i < nombres.Count(); i++)
            {
                (adjunto as Clases.Adjunto).Urlarchivo = rutas[i];
                (adjunto as Clases.Adjunto).Titulo = nombres[i];
                IDAOAdjunto accionVerificar = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOAdjunto();
                Entidad adjuntoExiste = accionVerificar.VerificarAdjunto(adjunto);
                if ((adjuntoExiste as Clases.Adjunto).Idadjunto != 0)
                {
                    j++;
                }

            }

            Assert.AreEqual(j, 3);


        }

        [Test]
        public void CreacionDirectorioDropbox()
        {
            //creo un usuario
            (usuario as Clases.Usuario).Nombre = "NombrePrueba";
            (usuario as Clases.Usuario).Apellido = "ApellidoPrueba";
            (usuario as Clases.Usuario).Correo = "correoPrueba@prueba.com";
            (usuario as Clases.Usuario).Clave = "12345";

            Comando<Entidad> comandoVerificarExistenciaUsuario = FabricaComando.CrearComandoListaUsuario(usuario);
            usuario = comandoVerificarExistenciaUsuario.Ejecutar();
            if ((usuario as Clases.Usuario).Id == 0)
            {
                //si no entra es que la prueba ya se hizo una vez y el usuario ya esta insertado
                Comando<Entidad> comandoInsertarUsuario = FabricaComando.CrearComandoAgregarUsuario(usuario);
                comandoInsertarUsuario.Ejecutar();
            }


            Comando<String> comando4 = FabricaComando.CrearComandoAutentificacionDropbox("http://localhost:1622");
            String ruta = comando4.Ejecutar();
            Assert.IsNotNull(ruta);

        }

        [Test]
        public void PruebaExportarXML() {

            //setteo el usuario
            (usuario as Clases.Usuario).Nombre = "elbano";
            (usuario as Clases.Usuario).Apellido = "marquez";
            (usuario as Clases.Usuario).Correo = "elbano28@gmail.com";
            (usuario as Clases.Usuario).Clave = "e1223d9bbcd82236f9f09ae1f5578e3cbbd4e8f48954cead3003be60ac85629726dc04b1f875353459f97ba4a4283a1a6adb89d3524bb4816c7125964097106c";
            (usuario as Clases.Usuario).AccesSecret = "meteinmqlaznshx";
            (usuario as Clases.Usuario).AccesToken = "v8t8xvv80h9dzqs";

            Comando<Entidad> comando = FabricaComando.CrearComandoExportarConfiguracion(usuario);
            usuario = comando.Ejecutar();

            Assert.IsNotNull(usuario);
            String ruta = AppDomain.CurrentDomain.BaseDirectory;

            ruta = ruta + "xml\\"; 
            string configuracionPrefix = "Configuracion";
            string archivo = ruta + configuracionPrefix + (usuario as Clases.Usuario).Correo + ".xml";

            Assert.IsTrue(System.IO.File.Exists(archivo));
            
            FileInfo file = new FileInfo(archivo);
            long fileSize = file.Length;
            
            Assert.IsTrue(fileSize > 0);
        }

        [Test]
        public void PruebaSeleniumNuevaNota() {

            string email = "elbano28@gmail.com";
            string clave = "1234";

            string login = "http://localhost:1622/Presentacion/Vista/Login.aspx";
            string nota = "http://localhost:1622/Presentacion/Vista/NuevaNota.aspx";

            selenium.Navigate().GoToUrl(login);
            selenium.FindElement(By.CssSelector("[id$='correo']")).SendKeys(email);
            selenium.FindElement(By.CssSelector("[id$='clave']")).SendKeys(clave);
            selenium.FindElement(By.CssSelector("[id$='clave']")).SendKeys(Keys.Enter);

            Assert.AreEqual("Home Page", selenium.Title);

            selenium.Navigate().GoToUrl(nota);

            Assert.AreEqual("Nota", selenium.Title);

            string nombreNota = "PruebaConSelenium";
            string contenidoNota = "Estamos probando selenium y esta saliendo bien";
            string etiqueta = "selenium";

            selenium.FindElement(By.CssSelector("[id$='TextBoxTitulo']")).SendKeys(nombreNota);
            selenium.FindElement(By.CssSelector("[id$='TextBoxContenido']")).SendKeys(contenidoNota);
            selenium.FindElement(By.CssSelector("[id$='TextBoxEtiqueta']")).SendKeys(etiqueta);

            selenium.FindElement(By.CssSelector("[id$='Button4']")).Click(); //boton agregar etiqueta

            Thread.Sleep(2000);

            selenium.FindElement(By.CssSelector("[id$='Button1']")).Click(); //boton guardar

            Assert.AreEqual("Home Page", selenium.Title);

            selenium.FindElement(By.CssSelector("[id$='BuscadorMain_TextBoxBuscadorSiteM']")).SendKeys(etiqueta);
            selenium.FindElement(By.CssSelector("[id$='BuscadorMain_TextBoxBuscadorSiteM']")).SendKeys(Keys.Enter);
            
            Thread.Sleep(2000);

            selenium.FindElement(By.XPath("//table[contains(@id,'MainContent_GridViewNotas')]//tbody/tr/td[1]")).Click();

            Thread.Sleep(1000);

            string urlNotaSelenium = selenium.Url;

            Assert.IsTrue(urlNotaSelenium.Contains("/EditarNota.aspx?id="));

            string nombreNotaSelenium = selenium.FindElement(By.CssSelector("[id$='TextBoxTitulo']")).GetAttribute("value");

            Assert.AreEqual(nombreNotaSelenium, nombreNota);



        }
    }
}