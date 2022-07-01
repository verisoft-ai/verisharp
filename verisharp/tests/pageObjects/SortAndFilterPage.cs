//*****************************************************************************
// MainDataArea.cs - Representation of the main data area in the sytem
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
    public class SortAndFilterPage : BasePage
    {
        #region [ Members ]
        private readonly ILocator m_apply;
        

        #endregion

        #region [ Constructors ]
        
        public SortAndFilterPage(IPage page):base(page)
        {
            m_apply = m_page.Locator("//*[@id='appView']//*[text()='Apply']");

        }
        #endregion

        #region [ Methods ]
        public override Task<bool> IsOnPage()
        {
            return base.IsOnPage(m_page, "//*[@id='appView']//*[text()='Apply']");
        }
        
        public async Task Apply()
        {
            await m_apply.ClickAsync();
        }
        #endregion
    }
}

