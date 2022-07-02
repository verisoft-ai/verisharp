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
using log4net;
using System.Reflection;

namespace Verisoft.Pages
{
    /// <summary>
    /// Representation of the flag add to group popup.
    /// </summary>
    public class FlagGroupPopup : BasePage
    {

        #region [ Members ]

        // Fields
        private readonly ILocator m_groupNameText;  // Search group name text box
        private readonly ILocator m_addGroup;       // Add new group + button
        private readonly ILocator m_flag;           // Flag button

        #endregion


        #region [ Constructors ]

        /// <summary>
        /// Default c-tor. Initializes all locators on page with the Ipage, and saves the page
        /// </summary>
        /// <param name="page">Playwright IPage object</param>
        public FlagGroupPopup(IPage page) : base(page)
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


        /// <summary>
        /// Inserts group name into the textbox to search the group. 
        /// </summary>
        /// <param name="group">Group name to search</param>
        /// <returns>this object, useful for chained methods</returns>
        public async Task<FlagGroupPopup> WithGroup(string group)
        {
            await m_groupNameText.FillAsync(group);
            return this;
        }

        /// <summary>
        /// Entire process of adding a group to the flag. It does the following:
        /// 1. Insert the group into the text box
        /// 2. If the group is found according to the group received, select it and click on the flag button
        /// 3. If the group is not found, click on the add group icon and add a new group
        /// </summary>
        /// <param name="group">Name of the group to add</param>
        /// <returns>void, basically</returns>
        public async Task SetGroup(string group)
        {
            await m_groupNameText.FillAsync(group);

            // Wait for the page to display the groups
            string selector = "//ul[@class='MuiList-root FlagGroups_listStyle__P1lY1']/li";
            await m_page.WaitForSelectorAsync(selector);
            
            // Get all pre-saved groups
            IReadOnlyCollection<IElementHandle> groups = m_page.QuerySelectorAllAsync(selector).Result;
            foreach (var item in groups)
            {
                if (item.TextContentAsync().Result == group)
                {
                    await item.ClickAsync();
                    await m_flag.ClickAsync();
                    return;
                }
            }

            // If we are here, we did not find an existing group that matches
            await m_addGroup.ClickAsync();
            await m_page.Locator("//input[@placeholder='Enter new group name']").FillAsync(group);
            await m_flag.ClickAsync();
            return;
        }

        #endregion


        #region [ Static ]
        
        // Static Fields
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        #endregion
    }
}
