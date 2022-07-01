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
    public class WebsitePage : BasePage
    {
        #region [ Members ]
        private readonly WebsitesSortAndFilter m_sortAndFilter;
        private readonly ILocator m_search;
        #endregion

        #region [ Constructors ]
        public WebsitePage(IPage page) : base(page)
        {
            m_sortAndFilter = new WebsitesSortAndFilter(m_page);
            m_search = m_page.Locator("//input[@placeholder='Search...']");

        }
        #endregion

        #region [ Properties ]
        public WebsitesSortAndFilter SortAndFilter
        {
            get
            {
                return gotoWebSitesSortAndFilter().Result;

            }
        }
        #endregion

        #region [ Methods ]
        public override Task<bool> IsOnPage()
        {
            return base.IsOnPage(m_page, "//div[text()='Websites']");
        }

        private async Task<WebsitesSortAndFilter> gotoWebSitesSortAndFilter()
        {

            Thread.Sleep(1000);
            IElementHandle? handle = m_page.QuerySelectorAsync("(//span[text()='Sort & Filter '])[2]").Result;
            Thread.Sleep(500);
            if (handle != null)
            {
                await m_page.Locator("(//span[text()='Sort & Filter '])[2]").ClickAsync();
            }

            return new WebsitesSortAndFilter(m_page);
        }

        public async Task<WebsitePage> Search(string term)
        {
            await m_search.FillAsync(term);
            await m_page.Keyboard.PressAsync("Enter");
            return this;
        }
        #endregion
    }
}
