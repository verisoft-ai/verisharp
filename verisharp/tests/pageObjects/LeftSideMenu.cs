//*****************************************************************************
// LeftSideMenu.cs - Representation of the left side menu in the dashboard
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
using log4net;
using System.Reflection;

namespace Verisoft.Pages
{
    /// <summary>
    /// Representation of the BrandShield left side menu, currently in an opened position
    /// </summary>
    public class LeftSideMenu : BasePage
    {
        #region [ Members ]

        // Fields
        private readonly ILocator m_dashboardSelector;
        private readonly ILocator m_websitesSelector;
        private readonly ILocator m_risksSelector;      // Websites sub menu selector

        #endregion


        #region [ Constructor ]

        /// <summary>
        /// Default c-tor. Initializes all locators on page with the Ipage, and saves the page
        /// </summary>
        /// <param name="page">Playwright IPage object</param>
        public LeftSideMenu(IPage page) : base(page)
        {
            m_dashboardSelector = m_page.Locator("//*[@data-testid='listItemText']/span[text()='Dashboard']");
            m_websitesSelector = m_page.Locator("//*[@data-testid='listItemText']/span[text()='Websites']");
            m_risksSelector = m_page.Locator("//*[@data-testid='listItemText']/span[text()='Risks']");
        }

        #endregion


        #region [ Properties ]

        public WebsitesRisksPage WebsitePage
        {
            get
            {
                return GotoWebSites().Result;
            }
        }

        #endregion


        #region [ Methods ]

        public override Task<bool> IsOnPage()
        {
            return base.IsOnPage(m_page, "//*[@data-testid='listItemText']/span[text()='Dashboard']");
        }

        /// <summary>
        /// Clicks on the websites page. Currently only supports visible sidebar
        /// </summary>
        /// <returns>A new WebsitePage object</returns>
        private async Task<WebsitesRisksPage> GotoWebSites()
        {
            await m_websitesSelector.ClickAsync();
            return new WebsitesRisksPage(m_page);
        }

        #endregion


        #region [ Static ]
        
        // Static Fields
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        #endregion
    }
}
