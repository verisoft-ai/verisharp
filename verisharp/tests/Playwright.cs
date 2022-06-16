using NUnit.Framework;
using Microsoft.Playwright;

namespace Verisoft
{

    [TestFixture]
    public class Pwright
    {
        [Test]
        public async Task FirstTest()
        {
            //playwright
            using var playwright = await Playwright.CreateAsync();

            //Browser
            await using var browser = await playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions()
                {
                    Headless = false
        }
            );

            // Page
            var page = await browser.NewPageAsync();

        await page.GotoAsync("http://www.eaapp.somee.com");
         await page.ScreenshotAsync(new PageScreenshotOptions{
            Path="EAApp.jpg"
        });
        await page.ClickAsync("text=Login");
       
    }

}
}