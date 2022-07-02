//*****************************************************************************
// TopMenu.cs - Representation of the top menu in the dashboard
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
    /// Web part which represents the dashboard top menu (with logo, company and brand, user details etc.)
    /// </summary>
    public class TopMenu : BasePage
    {
        #region [ Members ]

        // Fields
        private readonly ILocator m_companySelector;
        private readonly ILocator m_brandSelector;
        private readonly ILocator m_btnUserDetails;
        private readonly ILocator m_btnHelp;

        #endregion


        #region [ Constructor ]

        /// <summary>
        /// Default c-tor. Initializes all locators on page with the Ipage, and saves the page
        /// </summary>
        /// <param name="page">Playwright IPage object</param>u
        public TopMenu(IPage page) : base(page)
        {
            //*[@data-testid='dropMenu'] 
            m_companySelector = m_page.Locator("//*[@data-testid='dropMenu'] //*[text() ='Company:']/ancestor::div[@data-testid='dropMenu']//span[@class='MuiIconButton-label']/span[1]");
            m_brandSelector = m_page.Locator("//*[@data-testid='dropMenu'] //*[text() ='Brand:']/ancestor::div[@data-testid='dropMenu']//span[@class='MuiIconButton-label']/span[1]");
            m_btnUserDetails = m_page.Locator("div[data-testid='menuListDropDownSelector']");
            m_btnHelp = m_page.Locator("#simpoPlusBtn");
        }

        #endregion


        #region [ Properties ]

        /// <summary>
        /// Returns the current company
        /// </summary>
        public string CompanyName
        {
            get
            {
                return m_companySelector.InnerTextAsync().Result;
            }
        }


        /// <summary>
        /// Returns the current brand
        /// </summary>
        public string BrandName
        {
            get
            {
                return m_brandSelector.InnerTextAsync().Result;
            }
        }

        /// <summary>
        /// Returns the ILocator for company
        /// </summary>
        public ILocator Company
        {
            get
            {
                return m_companySelector;
            }
        }

        /// <summary>
        /// Returns the ILocator for brand
        /// </summary>
        public ILocator Brand
        {
            get
            {
                return m_brandSelector;
            }
        }

        #endregion


        #region [ Methods ]
        public override Task<bool> IsOnPage()
        {
            return base.IsOnPage(m_page, "#simpoPlusBtn");
        }


        /// <summary>
        /// Selects a company from the drop down list
        /// </summary>
        /// <param name="company">Company name to switch to</param>
        /// <returns>this object. Useful for page flow during the test</returns>
        public async Task<TopMenu> withCompany(string company)
        {
            await m_companySelector.ClickAsync();

            try
            {
                ILocator locator = m_page.Locator("text=" + company);
                await locator.ClickAsync();

            }
            catch (Exception e)
            {
                throw new Exception("Error selecting company. Could not locate the company name requested - " + company, e);
            }

            await m_companySelector.WaitForAsync();
            return this;
        }


        /// <summary>
        /// Selects a brand from the drop down list
        /// </summary>
        /// <param name="brand">Brand name to switch to</param>
        /// <returns>this object. Useful for page flow during the test</returns>
        public async Task<TopMenu> withBrand(string brand)
        {
            await m_brandSelector.ClickAsync();
            try
            {
                await m_page.Locator("text=" + brand).ClickAsync();
                await m_page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            }
            catch (Exception e)
            {
                throw new Exception("Error selecting brand. Could not locate the brand name requested - " + brand, e);
            }

            await m_companySelector.WaitForAsync();
            return this;
        }

        #endregion


        #region [ Static ]
        
        // Static Fields
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        #endregion
    }
}
