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
namespace Verisoft.Pages
{
    public class LeftSideMenu : BasePage
    {
        #region [ Members ]
        private readonly ILocator m_dashboardSelector;
        private readonly ILocator m_websitesSelector;
        private readonly ILocator m_risksSelector;
        
        #endregion

        #region [ Constructor ]
        public LeftSideMenu(IPage page):base(page)
        {
            m_dashboardSelector = m_page.Locator("//*[@data-testid='listItemText']/span[text()='Dashboard']");
            m_websitesSelector = m_page.Locator("//*[@data-testid='listItemText']/span[text()='Websites']");
            m_risksSelector = m_page.Locator("//*[@data-testid='listItemText']/span[text()='Risks']");
        }
        #endregion

        #region [ Properties ]
        public WebsitePage WebsitePage
        {
            get
            {
                 return gotoWebSites().Result;
                
            }
        }
        #endregion

        #region [ Methods ]
        public override Task<bool> IsOnPage()
        {
            return base.IsOnPage(m_page, "//*[@data-testid='listItemText']/span[text()='Dashboard']");
        }
        
        private async Task<WebsitePage> gotoWebSites()
        {
            await m_websitesSelector.ClickAsync();
            return new WebsitePage(m_page);
        }
        #endregion
    }
}