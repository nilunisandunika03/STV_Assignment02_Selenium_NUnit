using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace CSE2522_Automation.Pages
{
    public class ClientSideDelayPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public ClientSideDelayPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        private By link = By.LinkText("Client Side Delay");
        private By triggerButton = By.Id("ajaxButton");
        private By resultLabel = By.CssSelector(".bg-success");

        public void Open()
        {
            driver.FindElement(link).Click();
        }

        public void ClickAndWaitForResult()
        {
            driver.FindElement(triggerButton).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(resultLabel));
        }

        public bool IsResultDisplayed()
        {
            try
            {
                return driver.FindElement(resultLabel).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}