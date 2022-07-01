//*****************************************************************************
// TopMenu.cs - Representation of the top menu in the dashboard
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
    public class TopMenu : BasePage
    {
        #region [ Members ]

        private readonly ILocator m_companySelector;
        private readonly ILocator m_brandSelector;
        private readonly ILocator m_btnUserDetails;
        private readonly ILocator m_btnHelp;

        #endregion

        #region [ Constructor ]

        public TopMenu(IPage page) : base(page)
        {
            //*[@data-testid='dropMenu'] 
            m_companySelector = m_page.Locator("//*[@data-testid='dropMenu'] //*[text() ='Company:']/ancestor::div[@data-testid='dropMenu']//span[@class='MuiIconButton-label']/span[1]");
            m_brandSelector = m_page.Locator("//*[@data-testid='dropMenu'] //*[text() ='Brand:']/ancestor::div[@data-testid='dropMenu']//span[@class='MuiIconButton-label']/span[1]");
            m_btnUserDetails = m_page.Locator("div[data-testid='menuListDropDownSelector']");
            m_btnHelp = m_page.Locator("#simpoPlusBtn");

        }

        #endregion

        #region [ Methods ]
        public override Task<bool> IsOnPage()
        {
            return base.IsOnPage(m_page, "#simpoPlusBtn");
        }

        public async Task<TopMenu> withCompany(string company)
        {
            await m_companySelector.ClickAsync();
            await m_page.Locator("text=" + company).ClickAsync();
            await m_companySelector.WaitForAsync();
            return this;
        }

        public async Task<TopMenu> withBrand(string brand)
        {
            await m_brandSelector.ClickAsync();
            await m_page.Locator("text=" + brand).ClickAsync();
            await m_companySelector.WaitForAsync();
            return this;
        }

        public async Task<string> Company()
        {
            return await m_companySelector.InnerTextAsync();
        }

        public async Task<string> Brand()
        {
            return await m_brandSelector.InnerTextAsync();
        }
        #endregion
    }
}