//*****************************************************************************
// BrowserHandler.cs - Singleton to manage the browser handling
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
// 01/07/2022 - Nir Gallenr
// Last update
//*****************************************************************************
using System.ComponentModel;
using Microsoft.Playwright;

namespace Verisoft.Core
{
    public class PlaywrightHandler
    {
        #region [ Members ]
        private Dictionary<int, IBrowser> m_browsers;
        private Dictionary<int, IPage> m_pages;
        private IPlaywright m_playwright;

        #endregion

        #region [ Constructors ]
        private PlaywrightHandler()
        {
            m_browsers = new Dictionary<int, IBrowser>();
            m_pages = new Dictionary<int, IPage>();

            IPlaywright playwright = Playwright.CreateAsync().Result;
            m_playwright = playwright;
        }

        #endregion

        #region [ Methods ]

        public IBrowser GetNewBrowser()
        {
            // Is there an existing browser?
            int threadId = Thread.CurrentThread.ManagedThreadId;


            //Browser
            IBrowser browser = m_playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions()
                {
                    Headless = false
                }
            ).Result;



            m_browsers.Add(threadId, browser);
            return browser;
        }

        public async Task<IPage> GetNewPage()
        {
            // Is there an existing browser?
            int threadId = Thread.CurrentThread.ManagedThreadId;


            //Browser
            IBrowser? browser;
            m_browsers.TryGetValue(threadId, out browser);
            if (browser == null)
            {
                GetNewBrowser();
                browser = m_browsers[threadId];
            }

            // Page
            
            IPage page = await browser.NewPageAsync(new BrowserNewPageOptions()
            {
            });
            page.SetDefaultTimeout(30000);
            m_pages.Add(browser.GetHashCode(), page);
            return page;
        }

        #endregion


        #region [ Static ]

        // Static Fields
        private static PlaywrightHandler? s_handler;

        // Static Constructor
        public static PlaywrightHandler Instance
        {
            get
            {
                if (s_handler == null)
                {
                    s_handler = new PlaywrightHandler();
                }

                return s_handler;
            }
        }
        #endregion
    }
}