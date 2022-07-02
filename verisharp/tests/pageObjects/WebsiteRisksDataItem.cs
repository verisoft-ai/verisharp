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
using Microsoft.Playwright;

namespace Verisoft.Pages
{
    public class WebsiteRisksDataItem
    {
        #region [ Members ]

        // Fields
        private IElementHandle m_item;          // Representation of a single line in the risks list
        private IPage m_page;
        private string m_itemName;              // Name of the item, which holds the link to the website

        #endregion


        #region [ Constructors ]

        /// <summary>
        /// Default c-tor., stores the parametes and saves the item's name
        /// </summary>
        /// <param name="page">Playwright IPage object</param>
        /// <param name="handle">The specifig DOM object which represents the current record. It holds inside all the 
        /// other objects (e.g enforce, select, flag etc.)
        /// </param>
        public WebsiteRisksDataItem(IPage page, IElementHandle handle)
        {
            m_page = page;
            m_item = handle;
            m_itemName = handle.QuerySelectorAsync(".LinkWithTrack_clickableItem__X8IOt").Result.InnerTextAsync().Result;
        }
        #endregion


        #region [ Properties ]

        /// <summary>
        /// Retrieves the name of the item (link to the website)
        /// </summary>
        public string Name
        {
            get
            {
                return m_itemName;
            }
        }

        #endregion


        #region [ Methods ]

        /// <summary>
        /// clicks on the flag icon
        /// </summary>
        /// <returns>Flag pop up object</returns>
        public async Task<FlagGroupPopup> Flag()
        {
            await GetFlag().Result.ClickAsync();

            // TODO: change this. what if it was already flagged?
            return new FlagGroupPopup(m_page);
        }


        /// <summary>
        /// Checks whether the record is flagged already.
        /// </summary>
        /// <returns>true if it is flaggd, flase - otherwise</returns>
        public async Task<bool> IsFlagged()
        {
            IElementHandle handle = await GetFlag();
            IReadOnlyCollection<IElementHandle> flaggedContent = handle.QuerySelectorAllAsync("//*[name()='svg']/*[name()='path']").Result;
            return flaggedContent.Count < 2 ? false : true;
        }


        /// <summary>
        /// Compares the tooltip information with the given parameters
        /// </summary>
        /// <param name="group">Group name to validate</param>
        /// <param name="user">User full name to validate</param>
        /// <param name="date">Date to validate</param>
        /// <returns>true - if the data matches the system, false - otherwise</returns>
        /// <exception cref="Exception">If playwright was not able to open the tooltip</exception>
        public async Task<bool> ValidateToolTipData(string group, string user, string date)
        {
            IElementHandle handle = await GetFlag();
            Thread.Sleep(1000);
            await handle.HoverAsync();
            Thread.Sleep(1000);

            // A flagged object holds a list of the tooltip info - group, user and date
            IReadOnlyCollection<IElementHandle> toolTipData = m_page.QuerySelectorAllAsync("//ul[@class='FlagDropdownOverlay_list__wuE9Z']/li").Result;
            if (toolTipData.Count < 2)
                throw new Exception("Could not locate the tooltip");

            // Get the info
            string? toolTipGroup = toolTipData.ElementAt(0).QuerySelectorAsync("//*[@class='FlagDropdownOverlay_groupName__KGGhw']").Result.TextContentAsync().Result;
            string? toolTipUser = toolTipData.ElementAt(1).TextContentAsync().Result;
            string? toolTipDate = toolTipData.ElementAt(2).TextContentAsync().Result;

            // Validateion
            if (toolTipGroup == null || toolTipUser == null || toolTipDate == null)
                return false;

            // Compare the values
            return (toolTipGroup == group) && (toolTipUser.Substring(6).Trim() == user) && (toolTipDate.Substring(6).Trim() == date);
        }


        /// <summary>
        /// Retrieves a fresh DOM object of the flag object.
        /// </summary>
        /// <returns>IElementHandle representation of the flag</returns>
        /// <exception cref="ArgumentException">If the flag object was not found</exception>
        private async Task<IElementHandle> GetFlag()
        {
            string locator = "//button[@class='MuiButtonBase-root MuiIconButton-root FlagElement_root__zW5AB']";
            IElementHandle? handle = await m_item.QuerySelectorAsync(locator);

            if (handle != null)
                return handle;
            else
                throw new ArgumentException("Could not find the flag object. Locator " + locator);
        }

        #endregion
    }
}
