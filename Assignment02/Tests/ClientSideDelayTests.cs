using NUnit.Framework;
using CSE2522_Automation.Pages;

namespace CSE2522_Automation.Tests
{
    public class ClientSideDelayTests : TestBase
    {
        [Test]
        public void TC003_Verify_Client_Side_Delay()
        {
            var page = new ClientSideDelayPage(Driver);

            page.Open();
            page.ClickAndWaitForResult();

            Assert.That(page.IsResultDisplayed(), Is.True);
        }
    }
}