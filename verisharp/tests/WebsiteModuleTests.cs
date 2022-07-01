//*****************************************************************************
// WebsiteModuleTests.cs - Tests for the website module
//
// VeriSoft Inc., 2022
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// See the NOTICE file distributed with this work for additional
// information regarding copyright ownership.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
//
// Code Modification History:
// ----------------------------------------------------------------------------
// 06/16/2022 - Nir Gallner
// Original version of source code generated.
//
// 01/07/2022 - Nir Gallenr
// Last update
//*****************************************************************************
using NUnit.Framework;
using Microsoft.Playwright;
using Verisoft.Pages;
using Verisoft.Core;

namespace Verisoft.Tests
{
    

    [TestFixture]
    public class WebsiteModuleTests
    {

        [TestCaseSource(typeof(DataGenerator), nameof(DataGenerator.User))]
        public async Task FlagSanityTest(string userFullName, string username, string password, string company, string brand)
        {
            // TODO - put this somewhere else
            Environment.SetEnvironmentVariable("env.url", "https://testing.brandshield.com");

            // Get a new web page
            IPage page = await PlaywrightHandler.Instance.GetNewPage();


            // TODO: put this somewhere else
            string? url = Environment.GetEnvironmentVariable("env.url");
            if (url == null)
            {
                throw new Exception("url cannot be null");
            }

            // Login to brandshield
            await page.GotoAsync(url);
            LoginPage loginPage = new LoginPage(page);
            Assert.AreEqual(true, loginPage.IsOnPage().Result, "Should be on login page but currently at " + page.Url);

            DashboardPage dashboardPage = await loginPage.Login(username, password);
            Assert.IsTrue(dashboardPage.IsOnPage().Result, "Should be on dashboard page but currently at " + page.Url);

            // Select company and brand
            await dashboardPage.TopMenu.withCompany(company).Result.withBrand(brand);
            Thread.Sleep(1000);
            Assert.AreEqual(company, dashboardPage.TopMenu.Company().Result, "Company should be as expected after change");
            Assert.AreEqual(brand, dashboardPage.TopMenu.Brand().Result, "Brand should be as expected after change");

            // Goto unflagged website
            WebsitePage websitePage = dashboardPage.LeftSideMenu.WebsitePage;
            List<WebsiteRisksDataItem> risks = websitePage.SortAndFilter.GetRisks(false).Result;

            // Flag the first result
            WebsiteRisksDataItem item = risks[0];
            FlagGrouPopup flagGrouPopup = await item.Flag();

            string groupName = "test1";
            await flagGrouPopup.SetGroup(groupName);

            // Check if the item is flagged and toolTip is OK
            bool isFlagged = await item.IsFlagged();
            
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            bool correct = await item.CheckToolTip(groupName, userFullName, date);


            // Search the item in the flagged area, make sure it is there
            await websitePage.SortAndFilter.ClearFilters().GetRisks(true);
            await websitePage.Search(item.Name);
            List<WebsiteRisksDataItem> risks2 = websitePage.SortAndFilter.GetRisks();

            bool result = false;
            foreach (var record in risks2)
            {
                if (record.Name == item.Name)
                    result = true;
            }
            Assert.True(result, "Did not find the item");
        }
    }
}