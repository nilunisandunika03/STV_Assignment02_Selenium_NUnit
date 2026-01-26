using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace CSE2522_Automation.Pages
{
    public class AlertsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public AlertsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        private By link = By.LinkText("Alerts");
        private By alertBtn = By.Id("alertButton");
        private By confirmBtn = By.Id("confirmButton");
        private By promptBtn = By.Id("promptButton");

        public void Open()
        {
            driver.FindElement(link).Click();
        }

        public string HandleAlert()
        {
            driver.FindElement(alertBtn).Click();
            IAlert alert = driver.SwitchTo().Alert();
            string text = alert.Text;
            alert.Accept();
            return text;
        }

        public string HandleConfirm(bool accept)
        {
            driver.FindElement(confirmBtn).Click();
            // first alert (confirmation)
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            if (accept) alert.Accept();
            else alert.Dismiss();

            // after accepting/dismissing the confirm, the page shows a follow-up alert with the result text
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert resultAlert = driver.SwitchTo().Alert();
            string resultText = resultAlert.Text;
            // close the follow-up alert so the session is clean
            resultAlert.Accept();
            return resultText;
        }

        public string HandlePrompt(string value, bool accept)
        {
            driver.FindElement(promptBtn).Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            alert.SendKeys(value);

            if (accept) alert.Accept();
            else alert.Dismiss();

            // follow-up alert contains the entered text
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert resultAlert = driver.SwitchTo().Alert();
            string resultText = resultAlert.Text;
            resultAlert.Accept();
            return resultText;
        }
    }
}