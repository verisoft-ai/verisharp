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
using log4net;
using System.Reflection;
using Microsoft.Playwright;

namespace Verisoft.Pages
{
    /// <summary>
    /// Representation of the BrandShield dashboard page. Currently contains the top menu and the left menu.
    /// </summary>
    public class DashboardPage : BasePage
    {

        #region [ Members ]

        // Fields
        private readonly TopMenu m_topMenu;
        private readonly LeftSideMenu m_leftSideMenu;

        #endregion


        #region [ Constructors ]


        /// <summary>
        /// Default c-tor. Initializes the fields using page, and saves the page
        /// </summary>
        /// <param name="page">playwright IPage object</param>
        public DashboardPage(IPage page) : base(page)
        {
            m_topMenu = new TopMenu(m_page);
            m_leftSideMenu = new LeftSideMenu(m_page);
        }

        #endregion


        #region [ Properties ]
        /// <summary>
        /// Retrieves the TopMenu object
        /// </summary>
        public TopMenu TopMenu
        {
            get
            {
                return this.m_topMenu;
            }
        }

        /// <summary>
        /// Retrieves the LeftSideMenu object
        /// </summary>
        public LeftSideMenu LeftSideMenu
        {
            get
            {
                return this.m_leftSideMenu;
            }
        }

        #endregion


        #region [ Methods ]
        public override async Task<bool> IsOnPage()
        {
            return await base.IsOnPage(m_page, "//*[@data-testid='menuListDropDownSelector']");
        }

        #endregion


        #region [ Static ]
        
        // Static Fields
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        
        #endregion
    }
}
