using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace DataDrivenTest.Pages
{
    public class HomePage
    {

        private IWebDriver driver;
   

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public String getTitle()
        {
            return driver.Title;
        }
    }
}
