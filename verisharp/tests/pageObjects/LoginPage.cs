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

using System.Threading.Tasks;
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

        public LoginPage(IPage page): base(page)
        {
            // Assign identifiers
            m_txtUserName = m_page.Locator("input[name ='userName']");
            m_txtPassword = m_page.Locator("input[name ='password']");
            m_btnLogin = m_page.Locator("[data-testid ='logInButton']");
            m_lnkForgotPassword = m_page.Locator("a[data-testid ='forgotPasswordLink']");
        }

        #endregion

        #region [ Methods ]

        public async Task clickLogin()
        {
            await m_btnLogin.ClickAsync();
        }

        public async Task<DashboardPage> Login(string userName, string password)
        {
            await m_txtUserName.FillAsync(userName);
            await m_txtPassword.FillAsync(password);
            await m_btnLogin.ClickAsync();

            return new DashboardPage(m_page);
        }

        public override async Task<bool> IsOnPage()
        {
            return await base.IsOnPage(m_page, "[data-testid ='logInButton']");
        }
        
        #endregion


    }
}