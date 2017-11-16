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
    public class ReservationPage
    {
        IWebDriver driver;
        public ReservationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void fillOutSearchForRooms(string tcNumber, string roomType, string checkinDate, string checkoutDate)
        {
            typeCustomerTCNo(tcNumber);
            selectRoomType(roomType);
            typeCheckinDate(checkinDate);
            typeCheckoutDate(checkoutDate);
        }

        private void typeCustomerTCNo(string tcNumber)
        {
            driver.FindElement(By.XPath("//*[@id='customer_TCno']")).SendKeys(tcNumber);
        }

        private void selectRoomType(string roomType)
        {
            var selectElement = new SelectElement(driver.FindElement(By.XPath("//*[@id='room_type']")));
            selectElement.SelectByText(roomType);
        }

        private void typeCheckinDate(string checkinDate)
        {
            driver.FindElement(By.XPath("//*[@id='checkin_date']")).SendKeys(checkinDate);
        }

        private void typeCheckoutDate(string checkoutDate)
        {
            driver.FindElement(By.XPath("//*[@id='checkout_date']")).SendKeys(checkoutDate);
        }

        public void clickListAvailableButton()
        {
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div/div/form/div[2]/button")).Click();
        }

        public void verifyReservationInfo(string tcNumber, string roomType, string checkinDate, string checkoutDate)
        {
            Assert.AreEqual(tcNumber, driver.FindElement(By.XPath("//*[@id='customer_TCno']")).GetAttribute("value"));
            Assert.AreEqual(roomType, driver.FindElement(By.XPath("//*[@id='room_type']")).GetAttribute("value"));
            Assert.AreEqual(checkinDate, driver.FindElement(By.XPath("//*[@id='checkin_date']")).GetAttribute("value"));
            Assert.AreEqual(checkoutDate, driver.FindElement(By.XPath("//*[@id='checkout_date']")).GetAttribute("value"));
        }

        public void clickAvailableRoom(string roomID)
        {
            int i = 1;
            while (!driver.FindElement(By.XPath("/html/body/div[3]/div/div/form/div[2]/div/table/tbody/tr/td[" + i + "]/button")).
                GetAttribute("value").Equals(roomID))
            {
                i++;
            }

            driver.FindElement(By.XPath("/html/body/div[3]/div/div/form/div[2]/div/table/tbody/tr/td[" + i + "]/button")).Click();
        }

        public void clickOkOnAlert()
        {
            driver.SwitchTo().Alert().Accept(); // "Yes"
        }
    }
}
