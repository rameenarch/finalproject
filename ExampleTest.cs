using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;
using System.Text.RegularExpressions;


namespace PlaywrightTesting
{
    public class ExampleTest : PageTest
    {
        [Fact]
        public async Task Test1()
        {
            await Page.GotoAsync("https://playwright.dev");

            await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
        }

        [Fact]
        public async Task GetStartedLink()
        {
            await Page.GotoAsync("https://playwright.dev");

            await Page.GetByRole(AriaRole.Link, new() {  Name = "Get Started"}).ClickAsync();

            await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
        }
    }
}