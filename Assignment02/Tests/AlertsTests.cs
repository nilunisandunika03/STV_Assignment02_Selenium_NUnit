using NUnit.Framework;
using CSE2522_Automation.Pages;

namespace CSE2522_Automation.Tests
{
    public class AlertsTests : TestBase
    {
        [Test]
        public void TC004_Verify_Alert_Text()
        {
            var page = new AlertsPage(Driver);
            page.Open();

            string text = page.HandleAlert();
            Assert.That(text, Does.Contain("working day"));
        }

        [Test]
        public void TC004_Verify_Confirm_Accept()
        {
            var page = new AlertsPage(Driver);
            page.Open();

            string result = page.HandleConfirm(true);
            Assert.That(result, Does.Contain("Yes"));
        }

        [Test]
        public void TC004_Verify_Prompt()
        {
            var page = new AlertsPage(Driver);
            page.Open();

            string result = page.HandlePrompt("Hello", true);
            Assert.That(result, Does.Contain("Hello"));
        }
    }
}