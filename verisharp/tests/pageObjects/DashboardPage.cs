//*****************************************************************************
// DashboardPage.cs - Page Object for BS dashboard page
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
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Verisoft.Pages
{
    public class DashboardPage : BasePage
    {

        #region [ Members ]
        
        // Fields
        private readonly TopMenu topMenu;
        #endregion

        #region [ Constructors ]

        public DashboardPage(IPage page):base(page)
        {
            topMenu = new TopMenu(m_page);
        }

        #endregion

        #region [ Properties ]
        public TopMenu TopMenu
        {
            get
            {
                return this.topMenu;
            }
        }
        
        #endregion

        #region [ Methods ]
        public override async Task<bool> IsOnPage()
        {
            return await base.IsOnPage(m_page, "");
        }
        
        #endregion

    }
}