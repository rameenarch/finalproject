using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;
using System.Text.RegularExpressions;


namespace PlaywrightTesting
{
    public class DynamicContentLoadsCorrectly : PageTest
    {
        [Fact]
        public async Task DynamicContentLoadsCorrectlys()
        {
            // Navigate to the dynamic content page with changing images
            await Page.GotoAsync("https://the-internet.herokuapp.com/dynamic_content");

            // Locate the images
            var images = Page.Locator(".large-2 img");

            // Verify that three images are loaded
            await Expect(images).ToHaveCountAsync(3);

            // Capture the sources of the images, replacing null with an empty string in JavaScript
            var imageSources = await images.EvaluateAllAsync<string[]>("imgs => imgs.map(img => img.getAttribute('src') || '')");

            // Reload the page and verify that images have changed
            await Page.ReloadAsync();

            // Re-locate the images after reload
            images = Page.Locator(".large-2 img");

            // Capture the new sources of the images
            var newImageSources = await images.EvaluateAllAsync<string[]>("imgs => imgs.map(img => img.getAttribute('src') || '')");

            // Assert that the new image sources are not the same as the original ones
            Assert.False(imageSources.SequenceEqual(newImageSources), "Image sources should change after reload.");
        }
    }
}