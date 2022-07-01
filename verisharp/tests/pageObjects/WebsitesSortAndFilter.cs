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
using System.Runtime.CompilerServices;
using Microsoft.Playwright;
using NUnit.Framework.Constraints;

namespace Verisoft.Pages
{
    public class WebsitesSortAndFilter : SortAndFilterPage
    {

        #region [ Members ]
        private readonly ILocator m_flagged;
        private readonly ILocator m_notFlagged;


        #endregion

        #region [ Constructors ]
        public WebsitesSortAndFilter(IPage page) : base(page)
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

        public async Task<List<WebsiteRisksDataItem>> GetRisks(bool flagged = false)
        {
            if (flagged == true)
            {
                await m_flagged.ClickAsync();
            }
            else
            {
                await m_notFlagged.ClickAsync();
            }

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

        #endregion
    }
}