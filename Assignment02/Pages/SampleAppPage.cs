using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace CSE2522_Automation.Pages
{
    public class SampleAppPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public SampleAppPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        private By sampleAppLink = By.LinkText("Sample App");
        private By username = By.Name("UserName");
        private By password = By.Name("Password");
        private By loginBtn = By.Id("login");
        private By message = By.Id("loginstatus");

        public void Open()
        {
            var link = wait.Until(ExpectedConditions.ElementToBeClickable(sampleAppLink));
            link.Click();
        }

        public void Login(string user, string pass)
        {
            var userElem = wait.Until(ExpectedConditions.ElementIsVisible(username));
            userElem.Clear();
            userElem.SendKeys(user);

            var passElem = wait.Until(ExpectedConditions.ElementIsVisible(password));
            passElem.Clear();
            passElem.SendKeys(pass);

            var btn = wait.Until(ExpectedConditions.ElementToBeClickable(loginBtn));
            btn.Click();
        }

        public string GetMessage()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(message)).Text;
        }
    }
}