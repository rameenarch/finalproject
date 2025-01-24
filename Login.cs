using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;
using System.Text.RegularExpressions;


namespace PlaywrightTesting
{
    public class Login : PageTest
    {
        [Fact]
        public async Task Test1()
        {
            await Page.GotoAsync("https://the-internet.herokuapp.com/login");

            await Page.FillAsync("input#username", "tomsmith");
            await Page.FillAsync("input#password", "SuperSecretPassword!");

            await Page.ClickAsync("button[type='submit']");

            var flashMessage = Page.Locator("#flash");


            await Expect(Page).ToHaveURLAsync("https://the-internet.herokuapp.com/secure");
        }

    }
}