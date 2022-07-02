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
using Microsoft.Playwright.NUnit;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;
using log4net;
using log4net.Config;
using System.Reflection;

namespace Verisoft.Tests
{

    [TestFixture]
    [AllureNUnit]
    [AllureParentSuite("Root Suite")]
    [AllureSubSuite("Example")]
    [AllureSeverity(Allure.Commons.SeverityLevel.critical)]
    public class WebsiteModuleTests : PageTest
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
            // Load configuration
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }


        [TestCaseSource(typeof(DataGenerator), nameof(DataGenerator.User))]
        [AllureTag("Nunit", "Debug")]
        [AllureFeature("Core")]
        [AllureName("Simple test with steps")]
        public async Task FlagSanityTest(string userFullName, string username, string password, string company, string brand, string groupName)
        {
            log.Info("Start");

            // TODO - put this somewhere else
            Environment.SetEnvironmentVariable("env.url", "https://testing.brandshield.com");

            // Get a new web page
            IPage page = await PlaywrightHandler.Instance.GetNewPage();


            // TODO: put this somewhere else
            string? url = Environment.GetEnvironmentVariable("env.url");
            if (url == null)
                throw new Exception("url cannot be null");



            // Login to brandshield
            await page.GotoAsync(url);
            LoginPage loginPage = new LoginPage(page);
            Assert.AreEqual(true, loginPage.IsOnPage().Result, "Should be on login page but currently at " + page.Url);


            DashboardPage dashboardPage = await loginPage.Login(username, password);
            Assert.IsTrue(dashboardPage.IsOnPage().Result, "Should be on dashboard page but currently at " + page.Url);


            // Select company and brand
            await dashboardPage.TopMenu.withCompany(company).Result.withBrand(brand);
            await Expect(dashboardPage.TopMenu.Company).ToHaveTextAsync(company);
            await Expect(dashboardPage.TopMenu.Brand).ToHaveTextAsync(brand);



            // Goto websites
            WebsitesRisksPage websitesRisksPage = dashboardPage.LeftSideMenu.WebsitePage;
            FlaggedRisksPage flaggedRisksPage = await websitesRisksPage.GotoFlaggedRisksPage();
            int numOfGroupRisks = flaggedRisksPage.GetSumOfGroupRisks(groupName);
            await websitesRisksPage.GotoAllRisksPage();

            List<WebsiteRisksDataItem> risks = websitesRisksPage.SortAndFilter.GetRisks(false).Result;


            // Flag the first result
            WebsiteRisksDataItem item = risks[0];
            FlagGroupPopup flagGrouPopup = await item.Flag();

            await flagGrouPopup.SetGroup(groupName);

            // Check if the item is flagged and toolTip is OK
            bool isFlagged = await item.IsFlagged();

            string date = DateTime.Now.ToString("dd/MM/yyyy");
            bool correct = await item.ValidateToolTipData(groupName, userFullName, date);


            // Search the item in the flagged area, make sure it is there
            await websitesRisksPage.SortAndFilter.ClearFilters().GetRisks(true);
            await websitesRisksPage.SearchGroup(item.Name);
            List<WebsiteRisksDataItem> risks2 = websitesRisksPage.SortAndFilter.GetRisks();

            bool result = false;
            foreach (var record in risks2)
            {
                if (record.Name == item.Name)
                    result = true;
            }

            Assert.True(result, "Did not find the item");



            // Clear filters and go back to flagged risks - make sure the risk is there
            await websitesRisksPage.SearchGroup("");
            websitesRisksPage.SortAndFilter.ClearFilters();
            flaggedRisksPage = await websitesRisksPage.GotoFlaggedRisksPage();
            int updateNumOfRisks = flaggedRisksPage.GetSumOfGroupRisks(groupName);

            Assert.AreEqual(numOfGroupRisks + 1, updateNumOfRisks, "Risk should increase by 1");
            log.Info(message: "End");

        }
    }
}
