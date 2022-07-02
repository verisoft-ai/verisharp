//*****************************************************************************
// SortAndFilterPage.cs - Representation of the generic sort and filter page
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
using log4net;
using System.Reflection;


namespace Verisoft.Pages
{
    /// <summary>
    /// An abstract representation of the sort and filter page. 
    /// All sort and filter pages derive from this class
    /// </summary>
    public class SortAndFilterPage : BasePage
    {
        #region [ Members ]

        // Fields
        private readonly ILocator m_apply;

        #endregion


        #region [ Constructors ]

        /// <summary>
        /// Default c-tor. Initializes all locators on page with the Ipage, and saves the page
        /// </summary>
        /// <param name="page">Playwright IPage object</param>
        public SortAndFilterPage(IPage page) : base(page)
        {
            m_apply = m_page.Locator("//*[@id='appView']//*[text()='Apply']");

        }

        #endregion


        #region [ Methods ]

        public override Task<bool> IsOnPage()
        {
            return base.IsOnPage(m_page, "//*[@id='appView']//*[text()='Apply']");
        }

        /// <summary>
        /// Clicks on the apply button
        /// </summary>
        /// <returns>void</returns>
        public async Task Apply()
        {
            await m_apply.ClickAsync();
        }

        #endregion


        #region [ Static ]
        
        // Static Fields
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        
        #endregion
    }
}
