using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;
using System.Text.RegularExpressions;


namespace PlaywrightTesting
{
    public class UITestingPlaygroundTests : PageTest
    {
        [Fact]
        public async Task TextInputPage()
        {

            await Page.GotoAsync("http://www.uitestingplayground.com/textinput");
            await Page.GetByPlaceholder("MyButton").ClickAsync();
            await Page.GetByPlaceholder("MyButton").FillAsync("SomeCustomText");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Button That Should Change it'" }).ClickAsync();

            await Expect(Page.Locator("#updatingButton")).ToContainTextAsync("SomeCustomText");
        }

        [Fact]
        public async Task TextInputPageExtension()
        {
            await Page.GotoAsync("http://www.uitestingplayground.com");            
            await Page.GetByRole(AriaRole.Link, new() { Name = "Dynamic ID" }).ClickAsync();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Button with Dynamic ID" }).ClickAsync();

            await Expect(Page.GetByRole(AriaRole.Button)).ToContainTextAsync("Button with Dynamic ID");           
        }
    }
}