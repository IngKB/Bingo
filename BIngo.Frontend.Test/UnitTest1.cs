using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BIngo.Frontend.Test
{
    public class Tests
    {
        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:4200/home");
    }

        [Test]
        public void loguearExitoso()
        {
            IWebElement login = driver.FindElement(By.Id("btnLogin"));
            login.Click();
            IWebElement txtUser = driver.FindElement(By.Id("inpUsernameLogin"));
            txtUser.SendKeys("dar@gmail.com");
            IWebElement txtPassword = driver.FindElement(By.Id("inpPasswdLogin"));
            txtPassword.SendKeys("123456");
            IWebElement entrar = driver.FindElement(By.Id("btnLoginConf"));
            entrar.Click();
            //driver.Close();
            //driver.Quit();
        }
        [Test]
        public void loguearFallido()
        {
            IWebElement login = driver.FindElement(By.Id("btnLogin"));
            login.Click();
            IWebElement txtUser = driver.FindElement(By.Id("inpUsernameLogin"));
            txtUser.SendKeys("dr@gmail.com");
            IWebElement txtPassword = driver.FindElement(By.Id("inpPasswdLogin"));
            txtPassword.SendKeys("12346");
            IWebElement entrar = driver.FindElement(By.Id("btnLoginConf"));
            entrar.Click();
            //driver.Close();
            //driver.Quit();
        }

        [Test]
        public void RegistrarUsuario()
        {
            // pruebas 
            IWebElement login = driver.FindElement(By.Id("btnRegistrarse"));
            login.Click();
            IWebElement txtIdentificacion = driver.FindElement(By.Id("iptIdentificacion"));
            txtIdentificacion.SendKeys("10225444");
            IWebElement txtFirsname = driver.FindElement(By.Id("iptPrimerNombre"));
            txtFirsname.SendKeys("dario");
            IWebElement txtsecondName = driver.FindElement(By.Id("iptSegundoNombre"));
            txtsecondName.SendKeys("andres");
            IWebElement txtTelefono = driver.FindElement(By.Id("iptTelefono"));
            txtTelefono.SendKeys("5805470");
            IWebElement txtFirstLastName = driver.FindElement(By.Id("iptPrimerApellido"));
            txtFirstLastName.SendKeys("ramos");
            IWebElement txtSecondLastName = driver.FindElement(By.Id("iptSegundoApellido"));
            txtSecondLastName.SendKeys("cañas");
            IWebElement txtCity = driver.FindElement(By.Id("iptCiudad"));
            txtCity.SendKeys("valledupar");
            IWebElement txtGenero = driver.FindElement(By.Id("iptGenero"));
            txtGenero.SendKeys("masculino");
            IWebElement txtMail = driver.FindElement(By.Id("iptCorreo"));
            txtMail.SendKeys("dandre@hotmail.com");
            IWebElement txtPass = driver.FindElement(By.Id("iptContraseña"));
            txtPass.SendKeys("1234658");

            IWebElement registrarse = driver.FindElement(By.Id("btnRegistrarseConf"));
            registrarse.Click();
            //driver.Close();
            //driver.Quit();
        }
    }
}