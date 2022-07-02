//*****************************************************************************
// BasePage.cs - Base for all BS page objects
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
    /// This page is the base of all pages. It keeps the page as a protected varialble to be accessed to all children,
    /// and provides an interface to IsOnPage(), to be implemented in the children classes.
    /// </summary>
    public abstract class BasePage : WebPage
    {
        #region [ Members ]

        // Fields
        protected IPage m_page;

        #endregion


        #region [ Constructors ]

        /// <summary>
        /// C-tor, just keeps the given page
        /// </summary>
        /// <param name="page">playwright given page</param>
        public BasePage(IPage page)
        {
            m_page = page;
        }

        #endregion


        #region [ Methods ]

        /// <summary>
        /// Is playwright page on the right page? Use selector to find out 
        /// </summary>
        /// <param name="page">Page to look in</param>
        /// <param name="locator">Locator to find within the page</param>
        /// <returns>true - on page, false - not on page</returns>
        public async Task<bool> IsOnPage(IPage page, string locator)
        {
            ILocator element = page.Locator(locator);
            await element.WaitForAsync();
            return await element.IsVisibleAsync();
        }

        /// <summary>
        /// Is playwright page on the right page? Use selector to find out 
        /// </summary>
        /// <returns>true - on page, false - not on page</returns>
        public abstract Task<bool> IsOnPage();

        #endregion
    }
}
