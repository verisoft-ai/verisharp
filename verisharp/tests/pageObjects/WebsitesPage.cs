//*****************************************************************************
// WebsitePage.cs - Representation of the data when choosing Websites from the side bar
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
// 07/01/2022 - Nir Gallner
// Original version of source code generated.
//
//*****************************************************************************
using Microsoft.Playwright;

namespace Verisoft.Pages
{

    /// <summary>
    /// A representation of the BrandShield websites page
    /// </summary>
    public class WebsitesPage : BasePage
    {
        #region [ Members ]

        // Fields
        private readonly WebsitesSortAndFilterPage m_sortAndFilter;
        private readonly ILocator m_search;

        #endregion


        #region [ Constructors ]

        /// <summary>
        /// Default c-tor. Initializes all locators on page with the Ipage, and saves the page
        /// </summary>
        /// <param name="page">Playwright IPage object</param>
        public WebsitesPage(IPage page) : base(page)
        {
            m_sortAndFilter = new WebsitesSortAndFilterPage(m_page);
            m_search = m_page.Locator("//input[@placeholder='Search...']");
        }

        #endregion


        #region [ Properties ]

        /// <summary>
        /// Retrieves the WebsitesSortAndFilter object, which is a part of the Websites page
        /// </summary>
        public WebsitesSortAndFilterPage SortAndFilter
        {
            get
            {
                return GotoWebSitesSortAndFilter().Result;
            }
        }

        #endregion


        #region [ Methods ]

        public override Task<bool> IsOnPage()
        {
            return base.IsOnPage(m_page, "//div[text()='Websites']");
        }


        /// <summary>
        /// Opens up the websites sort and filter menu, if it is not already opened
        /// </summary>
        /// <returns>WebsitesSortAndFilter object</returns>
        private async Task<WebsitesSortAndFilterPage> GotoWebSitesSortAndFilter()
        {
            string selector = "(//span[text()='Sort & Filter '])[2]";

            
            // Wait for the search and filter. If not found, exception will be thrown
            try
            {
                ILocator locator = m_page.Locator(selector);
                await locator.ClickAsync(new LocatorClickOptions() { Timeout = 3000 });
            }
            catch (Exception e)
            {
                // No-Op
                // TODO: add log entry here
            }

            return new WebsitesSortAndFilterPage(m_page);
        }


        /// <summary>
        /// Search for a given term within the websites page
        /// </summary>
        /// <param name="term">Term to search</param>
        /// <returns>this object. Useful for page flow process during the test</returns>
        public async Task<WebsitesPage> Search(string term)
        {
            await m_search.FillAsync(term);
            await m_page.Keyboard.PressAsync("Enter");
            return this;
        }

        #endregion
    }
}
