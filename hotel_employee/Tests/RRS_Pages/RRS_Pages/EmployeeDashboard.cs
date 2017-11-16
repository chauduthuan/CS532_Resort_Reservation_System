using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI; // for dropdown menus

namespace RRS_Pages
{
    public class EmployeeDashboard
    {
        IWebDriver driver;
        public EmployeeDashboard(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void clickNoThanksButtonForTour()
        {
            driver.FindElement(By.XPath("//*[@id='guide-welcome']/div/div[2]/button[2]")).Click();
            System.Threading.Thread.Sleep(1000);
        }

        public void clickReservationTab()
        {
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[3]/a")).Click();
        }
    }
}
