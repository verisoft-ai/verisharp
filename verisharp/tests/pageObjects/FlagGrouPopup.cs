//*****************************************************************************
// FlagGrouPopup.cs - Representation of the flag group popup
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
    public class FlagGrouPopup : BasePage
    {
        #region [ Members ]
        private readonly ILocator m_groupNameText;
        private readonly ILocator m_addGroup;
        private readonly ILocator m_flag;

        #endregion

        #region [ Constructors ]
        public FlagGrouPopup(IPage page) : base(page)
        {
            m_groupNameText = m_page.Locator("//input[@placeholder='Search group name...']");
            m_addGroup = m_page.Locator("//div[@class='FlagGroups_square__NRdVW']");
            m_flag = m_page.Locator("//*[text()=' flag']");
        }

        #endregion

        #region [ Methods ]
        public override Task<bool> IsOnPage()
        {
            return base.IsOnPage(m_page, "//*[text()=' flag']");
        }

        public async Task<FlagGrouPopup> WithGroup(string group)
        {
            await m_groupNameText.FillAsync(group);
            return this;

        }

        public async Task SetGroup(string group)
        {
            await m_groupNameText.FillAsync(group);
            Thread.Sleep(1000);

            IReadOnlyCollection<IElementHandle> groups = m_page.QuerySelectorAllAsync("//ul[@class='MuiList-root FlagGroups_listStyle__P1lY1']/li").Result;
            foreach (var item in groups)
            {
                if (item.TextContentAsync().Result == group)
                {
                    await item.ClickAsync();
                    Thread.Sleep(1000);
                    await m_flag.ClickAsync();
                    return;
                }
            }

            // If we are here, we did not find an existing group that matches
            await m_addGroup.ClickAsync();
            await m_page.Locator("//input[@placeholder='Enter new group name']").FillAsync(group);
            await m_flag.ClickAsync();
        }

        #endregion
    }
}