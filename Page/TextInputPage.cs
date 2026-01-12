using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSE2522_Assignment02.Page
{
    public class TextInputPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        private readonly By NewButtonNameInput = By.Id("newButtonName");
        private readonly By UpdatingButton = By.Id("updatingButton");

        public TextInputPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void NavigateTo()
        {
            driver.Navigate().GoToUrl("https://uitestingplayground.com/textinput");
            wait.Until(d => d.Url.Contains("textinput"));
        }

        public void EnterButtonText(string text)
        {
            var input = wait.Until(d => d.FindElement(NewButtonNameInput));
            input.Clear();
            input.SendKeys(text);
        }

        public void ClickButton()
        {
            wait.Until(d => d.FindElement(UpdatingButton)).Click();
        }

        public string GetButtonText()
        {
            return wait.Until(d => d.FindElement(UpdatingButton)).Text;
        }

        public bool IsPageDisplayed()
        {
            try
            {
                return wait.Until(d => d.FindElement(NewButtonNameInput)).Displayed &&
                       wait.Until(d => d.FindElement(UpdatingButton)).Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}
