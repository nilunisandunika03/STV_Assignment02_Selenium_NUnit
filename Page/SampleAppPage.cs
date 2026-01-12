using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSE2522_Assignment02.Page
{
    public class SampleAppPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public SampleAppPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private readonly By UserNameField = By.Id("username");
        private readonly By PasswordField = By.Id("password");
        private readonly By LoginButton = By.Id("login");
        private readonly By LoginStatus = By.Id("loginstatus");

        public void NavigateTo()
        {
            driver.Navigate().GoToUrl("https://uitestingplayground.com/sampleapp");
            wait.Until(d => d.Url.Contains("sampleapp"));
        }

        public bool AreElementsDisplayed()
        {
            try
            {
                return wait.Until(d => d.FindElement(UserNameField)).Displayed &&
                       wait.Until(d => d.FindElement(PasswordField)).Displayed &&
                       wait.Until(d => d.FindElement(LoginButton)).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public void Login(string user, string pass)
        {
            var username = wait.Until(d => d.FindElement(UserNameField));
            username.Clear();
            username.SendKeys(user);

            var password = wait.Until(d => d.FindElement(PasswordField));
            password.Clear();
            password.SendKeys(pass);

            wait.Until(d => d.FindElement(LoginButton)).Click();
        }

        public string GetStatusText()
        {
            return wait.Until(d => d.FindElement(LoginStatus)).Text.Trim();
        }
    }
}
