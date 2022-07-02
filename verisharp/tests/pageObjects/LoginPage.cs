//*****************************************************************************
// LoginPage.cs - Page object for Login page
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
    public class LoginPage : BasePage
    {

        #region [ Members ]

        // Fields
        private readonly ILocator m_txtUserName;
        private readonly ILocator m_txtPassword;
        private readonly ILocator m_btnLogin;
        private readonly ILocator m_lnkForgotPassword;

        #endregion


        #region [ Constructors ]

        /// <summary>
        /// Default c-tor. Initializes all locators on page with the Ipage, and saves the page
        /// </summary>
        /// <param name="page">Playwright IPage object</param>
        public LoginPage(IPage page) : base(page)
        {
            // Assign identifiers
            m_txtUserName = m_page.Locator("//input[@name='userName']");
            m_txtPassword = m_page.Locator("//input[@name ='password']");
            m_btnLogin = m_page.Locator("//form/div[2]/button/span[1]");
            m_lnkForgotPassword = m_page.Locator("a[data-testid ='forgotPasswordLink']");
        }

        #endregion


        #region [ Methods ]

        /// <summary>
        /// Just click on the login button
        /// </summary>
        /// <returns>A new DashboardPage object to ease the test flow</returns>
        public async Task<DashboardPage> clickLogin()
        {
            await m_btnLogin.ClickAsync();
            log.Debug("Clicked on Login button");
            return new DashboardPage(m_page);
        }


        /// <summary>
        /// Performs login process - Inserts username, inserts password, and clicks on the login button
        /// </summary>
        /// <param name="userName">username</param>
        /// <param name="password">password</param>
        /// <returns>A new DashboardPage object to ease the test flow</returns>
        public async Task<DashboardPage> Login(string userName, string password)
        {
            await m_txtUserName.FillAsync(userName);
            await m_txtPassword.FillAsync(password);
            await m_btnLogin.ClickAsync();
            log.Debug("Clicked on Login button");

            return new DashboardPage(m_page);
        }

        public override async Task<bool> IsOnPage()
        {
            return await base.IsOnPage(m_page, "[data-testid ='logInButton']");
        }

        #endregion


        #region [ Static ]
        
        // Static Fields
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        #endregion
    }
}
