using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace RRS_Pages
{
    public class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void login(string username, string password)
        {
            typeUsername(username);
            typePassword(password);
            clickLoginButton();
        }

        public void typeUsername(string username)
        {
            driver.FindElement(By.XPath("//*[@id='username']")).SendKeys(username);
        }

        public void typePassword(string password)
        {
            driver.FindElement(By.XPath("//*[@id='password']")).SendKeys(password);
        }

        public void clickLoginButton()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/form/div[2]/button")).Click();
        }
    }
}
