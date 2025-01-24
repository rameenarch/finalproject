using Microsoft.Playwright.Xunit;

namespace PlaywrightTesting
{
    public class FileDownload : PageTest
    {
        [Fact]
        public async Task FileDownloadWorksCorrectly()
        {
            // Navigate to the file download page
            await Page.GotoAsync("https://the-internet.herokuapp.com/download");

            // Start waiting for the download
            var download = await Page.RunAndWaitForDownloadAsync(async () =>
            {
                await Page.ClickAsync("a[href='download/some-file.txt']"); // Adjust the selector as needed
            });

            // Save the downloaded file (absolute path)
            var downloadPath = Path.GetFullPath("downloads/some-file.txt");
            await download.SaveAsAsync(downloadPath);

            // Verify that the file exists
            Assert.True(File.Exists(downloadPath), $"Downloaded file not found at: {downloadPath}");
        }



    }
}
