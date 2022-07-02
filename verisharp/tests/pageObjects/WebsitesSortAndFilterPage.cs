//*****************************************************************************
// WebsitesSortAndFilter.cs - Representation of the Websites Sort And Filter side bar
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
//*****************************************************************************
using Microsoft.Playwright;

namespace Verisoft.Pages
{
    /// <summary>
    /// Representation of the sort and filter page, which is relevant for the websites page
    /// </summary>
    public class WebsitesSortAndFilterPage : SortAndFilterPage
    {

        #region [ Members ]

        // Fields
        private readonly ILocator m_flagged;
        private readonly ILocator m_notFlagged;

        #endregion


        #region [ Constructors ]

        /// <summary>
        /// Default c-tor. Initializes all locators on page with the Ipage, and saves the page
        /// </summary>
        /// <param name="page">Playwright IPage object</param>
        public WebsitesSortAndFilterPage(IPage page) : base(page)
        {
            m_flagged = m_page.Locator("//*[text()='Flagged']");
            m_notFlagged = m_page.Locator("//*[text()='Not flagged']");
        }

        #endregion 


        #region [ Methods ]

        public override Task<bool> IsOnPage()
        {
            return base.IsOnPage(m_page, "//*[text()='Flagged']");
        }


        /// <summary>
        /// Apply a filter for flagged items, creates a list of filtered items and put the results in the list.
        /// </summary>
        /// <param name="flagged">true - filter all flag items. Flase - filter all unflagged items</param>
        /// <returns>A list of the filtered items</returns>
        public async Task<List<WebsiteRisksDataItem>> GetRisks(bool flagged = false)
        {
            if (flagged == true)
                await m_flagged.ClickAsync();
            else
                await m_notFlagged.ClickAsync();

            await this.Apply();
            Thread.Sleep(3000);

            IReadOnlyCollection<IElementHandle> flaggedContent = m_page.QuerySelectorAllAsync("//*[@class='List_root__KZ4p']/li").Result;

            List<WebsiteRisksDataItem> websiteRisksDataItem = new List<WebsiteRisksDataItem>();
            foreach (IElementHandle item in flaggedContent)
            {
                websiteRisksDataItem.Add(new WebsiteRisksDataItem(m_page, item));
            }

            return websiteRisksDataItem;
        }


        /// <summary>
        /// Retrieves the current displayed risks
        /// </summary>
        /// <returns>A list of the current items</returns>
        public List<WebsiteRisksDataItem> GetRisks()
        {
            IReadOnlyCollection<IElementHandle> flaggedContent = m_page.QuerySelectorAllAsync("//*[@class='List_root__KZ4p']/li").Result;

            List<WebsiteRisksDataItem> websiteRisksDataItem = new List<WebsiteRisksDataItem>();
            foreach (IElementHandle item in flaggedContent)
            {
                websiteRisksDataItem.Add(new WebsiteRisksDataItem(m_page, item));
            }

            return websiteRisksDataItem;
        }


        /// <summary>
        /// Clearsd all the filter, if there are filters applied
        /// </summary>
        /// <returns>this object</returns>
        public WebsitesSortAndFilterPage ClearFilters()
        {
            Thread.Sleep(500);
            IElementHandle? handle = m_page.QuerySelectorAsync("//span[text()='Reset All']").Result;
            if (handle != null)
                handle.ClickAsync();

            return this;
        }
        
        #endregion
    }
}
