using NUnit.Framework;
using Microsoft.Playwright;
using Verisoft.Pages;

namespace Verisoft
{

    [TestFixture]
    public class Pwright
    {
        //[Test]
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
            await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "EAApp.jpg"
            });
            await page.ClickAsync("text=Login");
        }


        [Test]
        public async Task LoginTest()
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
            IPage page = await browser.NewPageAsync();

            await page.GotoAsync("https://testing.brandshield.com");
            LoginPage loginPage = new LoginPage(page);
            var dashboardPage = loginPage.Login("Test.Auto", "Nglr!2022").Result;
            Thread.Sleep(5000);
            await dashboardPage.TopMenu.withCompany("TTI").Result.withBrand("Ryobi");
            WebsitePage websitePage = dashboardPage.LeftSideMenu.WebsitePage;
            List<WebsiteRisksDataItem> risks = websitePage.SortAndFilter.GetRisks(false).Result;
            WebsiteRisksDataItem item = risks[0];
            FlagGrouPopup flagGrouPopup = await item.Flag(); 
            await flagGrouPopup.SetGroup("test1");
            Thread.Sleep(5000);
            bool isFlagged = await item.IsFlagged();
            bool correct = item.CheckToolTip("test1", "Test Automation", "01/07/2022").Result;
            List<WebsiteRisksDataItem> risks2 = websitePage.SortAndFilter.GetRisks(true).Result;
            // ??






            Thread.Sleep(5000);

        }
    }
}