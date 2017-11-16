using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI; // for dropdown menus
using RRS_Pages;

namespace RRS_Tests
{
    [TestClass]
    public class RRS_Reservations_Tests
    {
        static IWebDriver driver;
        LoginPage loginPage;
        EmployeeDashboard employeeDashboard;
        ReservationPage reservationPage;
        PHPMyAdminPage phpPage;

        [TestCleanup]
        public void CleanUp()
        {
            driver.Close();
        }

        [TestInitialize]
        public void Initialize()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            employeeDashboard = new EmployeeDashboard(driver);
            reservationPage = new ReservationPage(driver);
            phpPage = new PHPMyAdminPage(driver);
        }

        [TestMethod]
        public void Make_Reservation_Test()
        {
            // Wait 10 seconds for element to load/appear before failing test.
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //driver.Url = "https://google.com";
            //driver.Navigate();
            //driver.Navigate().GoToUrl("https://google.com");
            
            //System.Threading.Thread.Sleep(1000);

            driver.Navigate().GoToUrl("https://localhost/hotel"); // MUST INCLUDE "https://"

            loginPage.login("channaveer", "channaveer");
            //driver.FindElement(By.XPath("//*[@id='username']")).SendKeys("channaveer");
            //driver.FindElement(By.XPath("//*[@id='password']")).SendKeys("channaveer");
            //driver.FindElement(By.XPath("/html/body/div[2]/div/form/div[2]/button")).Click();

            employeeDashboard.clickNoThanksButtonForTour();
            //driver.FindElement(By.XPath("//*[@id='guide-welcome']/div/div[2]/button[2]")).Click();

            employeeDashboard.clickReservationTab();
            //driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[3]/a")).Click();

            reservationPage.fillOutSearchForRooms("1", "Double Bed", "11222017", "11232017");
            //driver.FindElement(By.XPath("//*[@id='customer_TCno']")).SendKeys("1");
            //SelectElement selectElement = new SelectElement(driver.FindElement(By.XPath("//*[@id='room_type']")));
            //selectElement.SelectByText("Double Bed");
            //driver.FindElement(By.XPath("//*[@id='checkin_date']")).SendKeys("11222017");
            //driver.FindElement(By.XPath("//*[@id='checkout_date']")).SendKeys("11232017");

            // Click List Available button
            reservationPage.clickListAvailableButton();
            //driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div/div/form/div[2]/button")).Click();

            reservationPage.verifyReservationInfo("1", "Double Bed", "2017-11-22", "2017-11-23");
            /*
            Assert.AreEqual("1", driver.FindElement(By.XPath("//*[@id='customer_TCno']")).GetAttribute("value"));
            Assert.AreEqual("Double Bed", driver.FindElement(By.XPath("//*[@id='room_type']")).GetAttribute("value"));
            Assert.AreEqual("2017-11-22", driver.FindElement(By.XPath("//*[@id='checkin_date']")).GetAttribute("value"));
            Assert.AreEqual("2017-11-23", driver.FindElement(By.XPath("//*[@id='checkout_date']")).GetAttribute("value"));
            */

            // Click first button to reserve room
            reservationPage.clickAvailableRoom("2");
            //driver.FindElement(By.XPath("/html/body/div[3]/div/div/form/div[2]/div/table/tbody/tr/td[1]/button")).Click();

            reservationPage.clickOkOnAlert();
            //driver.SwitchTo().Alert().Accept(); // "Yes"

            phpPage.gotoDashboard();
            //driver.Navigate().GoToUrl("http://localhost/phpmyadmin/");
            //System.Threading.Thread.Sleep(1000);

            phpPage.clickHotelDatabase();
            //driver.FindElement(By.XPath("//*[@id='pma_navigation_tree_content']/ul/li[2]/a")).Click();
            //System.Threading.Thread.Sleep(1000);

            phpPage.clickReservationTable();
            //driver.FindElement(By.XPath("//*[@id='row_tbl_12']/th/a")).Click();
            //System.Threading.Thread.Sleep(1000);

            phpPage.verifyReservationEntryInReservationTable();
            /*
            IWebElement table = driver.FindElement(By.XPath("//*[@id='page_content']/div[2]/form[2]/div[1]/table[2]/tbody"));

            Assert.AreEqual("1", table.FindElement(By.XPath(".//td[5]")).Text); // customer_id
            Assert.AreEqual("2017-11-22", table.FindElement(By.XPath(".//td[7]")).Text); // checkin_date
            Assert.AreEqual("2017-11-23", table.FindElement(By.XPath(".//td[8]")).Text); // checkout_date
            */

            phpPage.deleteAllEntriesInReservationTable();

            phpPage.clickRoomSalesTable();
            phpPage.deleteAllEntriesInRoomSalesTable();
        }
    }
}
