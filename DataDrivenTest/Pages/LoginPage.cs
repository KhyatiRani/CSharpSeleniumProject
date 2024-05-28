using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDrivenTest.Pages
{
    public  class LoginPage
    {

        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        By username = By.Id("user-name");
        By password = By.Id("password");
        By loginBtn = By.Id("login-button");


        public void EnterCredentials(String uname,String pwd)
        {
            driver.FindElement(username).SendKeys(uname);
            driver.FindElement(password).SendKeys(pwd);
        }

        public void ClickOnLoginBtn()
        {
            driver.FindElement(loginBtn).Click();
        }

    
    }
}
