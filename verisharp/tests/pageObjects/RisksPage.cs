//*****************************************************************************
// RisksPage.cs - Representation of the risks page, part of the websites page
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
    public class RisksPage : WebsitePage
    {
        #region [ Members ]
        private readonly ILocator m_title;
        private readonly ILocator m_sumOfAllRisks;
        private readonly ILocator m_sumOfFlaggedRisks;
        private readonly ILocator m_sumOfNewRisks;
        #endregion

        #region [ Constructors ]
        public RisksPage(IPage page): base(page)
        {
            m_title = m_page.Locator("//div[text()='Risks']");
            m_sumOfAllRisks = m_page.Locator("(//*[@data-testid='filtersGroup']//div[@class='CategoryCountersFilters_count__mLiq6'])[1]");
            m_sumOfFlaggedRisks = m_page.Locator("(//*[@data-testid='filtersGroup']//div[@class='CategoryCountersFilters_count__mLiq6'])[3]");
            m_sumOfNewRisks = m_page.Locator("(//*[@data-testid='filtersGroup']//div[@class='CategoryCountersFilters_count__mLiq6'])[2]");
        }
        #endregion

        #region [ Methods ]
        public override Task<bool> IsOnPage()
        {
            return base.IsOnPage(m_page, "//div[text()='Risks']");
        }
        #endregion
    }
}