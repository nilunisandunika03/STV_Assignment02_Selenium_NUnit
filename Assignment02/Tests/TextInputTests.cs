using NUnit.Framework;
using CSE2522_Automation;
using CSE2522_Automation.Pages;

namespace CSE2522_Automation.Tests
{
    [TestFixture]
    public class TextInputTests : TestBase
    {
        [Test(Description = "TC001_1_Text_Input_Verification")]
        public void VerifyTextInputFunctionality()
        {
            var textInputPage = new TextInputPage(Driver);

            textInputPage.OpenTextInputPage();

            Assert.That(textInputPage.IsTextBoxDisplayed(),
                "Text box is not displayed");

            Assert.That(textInputPage.IsButtonDisplayed(),
                "Button is not displayed");

            string testText = "HelloTest";
            textInputPage.EnterText(testText);
            textInputPage.ClickButton();

            Assert.That(textInputPage.GetButtonText(), Is.EqualTo(testText),
                "Button text did not update correctly");
        }
    }
}