using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CSE2522_Automation
{
    public class TestBase
    {
        protected IWebDriver Driver;
        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--remote-allow-origins=*");      // already needed for Chrome144+
            options.AddArgument("--ignore-certificate-errors");  // ALLOWS unsafe HTTPS
            options.AddArgument("--allow-insecure-localhost");   // optional if localhost

            Driver = new ChromeDriver(options);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://uitestingplayground.com/");
        }
        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}