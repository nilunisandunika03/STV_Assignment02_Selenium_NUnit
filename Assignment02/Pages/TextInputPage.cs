using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace CSE2522_Automation.Pages
{
    public class TextInputPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public TextInputPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        private By TextInputLink = By.LinkText("Text Input");

        // Locators for elements on Text Input page
        private By TextBoxLocator = By.Id("newButtonName");
        private By ButtonLocator = By.Id("updatingButton");

        // Navigate to Text Input page
        public void OpenTextInputPage()
        {
            IWebElement link = wait.Until(ExpectedConditions.ElementToBeClickable(TextInputLink));
            link.Click();
        }

        // Check if text box is displayed
        public bool IsTextBoxDisplayed()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(TextBoxLocator)).Displayed;
        }

        // Check if button is displayed
        public bool IsButtonDisplayed()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(ButtonLocator)).Displayed;
        }

        // Enter text in the text box
        public void EnterText(string text)
        {
            IWebElement textBox = wait.Until(ExpectedConditions.ElementIsVisible(TextBoxLocator));
            textBox.Clear();
            textBox.SendKeys(text);
        }

        // Click the button
        public void ClickButton()
        {
            IWebElement button = wait.Until(ExpectedConditions.ElementToBeClickable(ButtonLocator));
            button.Click();
        }

        // Get the button text
        public string GetButtonText()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(ButtonLocator)).Text;
        }
    }
}