using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CSE2522_Automation.Pages;

namespace CSE2522_Automation.Tests
{
    public class SampleAppTests : TestBase
    {
        SampleAppPage sampleApp;

        [SetUp]
        public void Setup()
        {
            // Use the Driver created in TestBase so the ChromeOptions (ignore cert errors) are applied
            sampleApp = new SampleAppPage(Driver);
        }

        [Test]
        public void TC002_Verify_Sample_App_Login()
        {
            sampleApp.Open();
            sampleApp.Login("admin", "pwd");
            Assert.That(sampleApp.GetMessage(), Does.Contain("Welcome"));
        }

        // TearDown is handled by TestBase
    }
}