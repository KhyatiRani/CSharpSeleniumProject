using DataDrivenTest.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;

namespace DataDrivenTest
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        LoginPage loginPage;
        HomePage homePage;

        [TestInitialize]
        public void Setup() {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void Test()
        { 
            XElement xDocument = XElement.Load("C:\\Users\\khyati.rani\\source\\repos\\DataDrivenTest\\DataDrivenTest\\data.xml");
            IEnumerable<XElement> xElements = xDocument.Elements();
            foreach (var  Ent in xElements)
            {
                var loginPage = new LoginPage(driver);
                loginPage.EnterCredentials(Ent.Element("username").Value, Ent.Element("password").Value);
                Thread.Sleep(3000);
                loginPage.ClickOnLoginBtn();
                var homePage = new HomePage(driver);
                Assert.AreEqual("Swag Labs", homePage.getTitle());
                Thread.Sleep(3000);
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }


        
    }
}
