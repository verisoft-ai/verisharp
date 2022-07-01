//*****************************************************************************
// WebsiteRisksDataItem.cs - Representation of a risk data item in the website risks 
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
using System.Reflection.Metadata;
using System.Xml;
using Microsoft.Playwright;
namespace Verisoft.Pages
{
    public class WebsiteRisksDataItem
    {
        #region [ Members ]
        private IElementHandle m_item;
        private IPage m_page;
        #endregion

        #region [ Constructors ]
        public WebsiteRisksDataItem(IPage page, IElementHandle handle)
        {
            m_page = page;
            m_item = handle;
        }
        #endregion

        #region [ Properties ]
        #endregion

        #region [ Methods ]
        public async Task<FlagGrouPopup> Flag()
        {

            await GetFlag().Result.ClickAsync();
            return new FlagGrouPopup(m_page);

        }

        public async Task<bool> IsFlagged()
        {
            IElementHandle handle = await GetFlag();
            IReadOnlyCollection<IElementHandle> flaggedContent = handle.QuerySelectorAllAsync("//*[name()='svg']/*[name()='path']").Result;
            return flaggedContent.Count < 2 ? false : true;

        }

        public async Task<bool> CheckToolTip(string group, string user, string date)
        {
            IElementHandle handle = await GetFlag();
            await handle.HoverAsync();
            Thread.Sleep(1000);
            IReadOnlyCollection<IElementHandle> toolTipData = m_page.QuerySelectorAllAsync("//ul[@class='FlagDropdownOverlay_list__wuE9Z']/li").Result;
            if (toolTipData.Count < 2)
            {
                throw new Exception("Could not locate the tooltip");
            }

            string toolTipGroup = toolTipData.ElementAt(0).QuerySelectorAsync("//*[@class='FlagDropdownOverlay_groupName__KGGhw']").Result.TextContentAsync().Result;
            string toolTipUser = toolTipData.ElementAt(1).TextContentAsync().Result;
            string toolTipDate = toolTipData.ElementAt(2).TextContentAsync().Result;

            return (toolTipGroup == group) && (toolTipUser.Substring(6).Trim() == user) && (toolTipDate.Substring(6).Trim() == date);







        }
        private async Task<IElementHandle> GetFlag()
        {
            string locator = "//button[@class='MuiButtonBase-root MuiIconButton-root FlagElement_root__zW5AB']";
            IElementHandle? handle = await m_item.QuerySelectorAsync(locator);
            if (handle != null)
            {
                return handle;
            }
            else
            {
                throw new ArgumentException("Could not click on the flag. Locator " + locator + "search returnen null");
            }
        }
        #endregion
    }
}

// this.m_name = m_page.Locator(".LinkWithTrack_clickableItem__X8IOt");
// this.m_flagged = m_page.Locator("//*[@class='PreventPropagationWrapper_root__E9eu FlagElement_flagElementContainer__OIxkL']");