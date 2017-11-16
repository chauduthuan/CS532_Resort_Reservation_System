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
    public class PHPMyAdminPage
    {
        IWebDriver driver;

        public PHPMyAdminPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void gotoDashboard()
        {
            driver.Navigate().GoToUrl("http://localhost/phpmyadmin/");
            System.Threading.Thread.Sleep(2000);
        }

        public void clickHotelDatabase()
        {
            driver.FindElement(By.XPath("//*[@id='pma_navigation_tree_content']/ul/li[2]/a")).Click();
            System.Threading.Thread.Sleep(2000);
        }

        public void clickReservationTable()
        {
            driver.FindElement(By.XPath("//*[@id='row_tbl_12']/th/a")).Click();
            System.Threading.Thread.Sleep(2000);
        }

        public void clickRoomSalesTable()
        {
            driver.FindElement(By.XPath("//*[@id='pma_navigation_tree_content']/ul/li[2]/div[4]/ul/li[2]/div[3]/ul/li[17]/a")).Click();
            System.Threading.Thread.Sleep(2000);
        }

        public void verifyReservationEntryInReservationTable()
        {
            IWebElement table = driver.FindElement(By.XPath("//*[@id='page_content']/div[2]/form[2]/div[1]/table[2]/tbody"));

            Assert.AreEqual("1", table.FindElement(By.XPath(".//td[5]")).Text); // customer_id
            Assert.AreEqual("2017-11-22", table.FindElement(By.XPath(".//td[7]")).Text); // checkin_date
            Assert.AreEqual("2017-11-23", table.FindElement(By.XPath(".//td[8]")).Text); // checkout_date
        }
        public void verifyReservationEntryInRoomSalesTable()
        {
            IWebElement table = driver.FindElement(By.XPath("//*[@id='page_content']/div[2]/form[2]/div[1]/table[2]/tbody"));

            Assert.AreEqual("1", table.FindElement(By.XPath(".//td[5]")).Text); // customer_id
            Assert.AreEqual("2017-11-22", table.FindElement(By.XPath(".//td[7]")).Text); // checkin_date
            Assert.AreEqual("2017-11-23", table.FindElement(By.XPath(".//td[8]")).Text); // checkout_date
        }

        public void deleteAllEntriesInReservationTable()
        {
            IWebElement table = driver.FindElement(By.XPath("//*[@id='page_content']/div[2]/form[2]/div[2]"));

            table.FindElement(By.XPath(".//input[1]")).Click();
            table.FindElement(By.XPath(".//button[3]")).Click();

            driver.FindElement(By.XPath("//*[@id='page_content']/form/fieldset[1]/legend/input[1]")).Click(); // Click "Yes"
            System.Threading.Thread.Sleep(2000);
        }

        public void deleteAllEntriesInRoomSalesTable()
        {
            IWebElement table = driver.FindElement(By.XPath("//*[@id='page_content']/div[2]/form[2]/div[2]"));

            table.FindElement(By.XPath(".//input[1]")).Click();
            table.FindElement(By.XPath(".//button[3]")).Click();

            driver.FindElement(By.XPath("//*[@id='page_content']/form/fieldset[1]/legend/input[1]")).Click(); // Click "Yes"
            System.Threading.Thread.Sleep(2000);
        }
    }
}
