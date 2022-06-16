//*****************************************************************************
// Page.cs - Base for all page objects
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
    public interface Page
    {
        /// <summary>
        /// Is the browser on the selected page?
        /// </summary>
        /// <param name="page">Page to look in</param>
        /// <param name="locator">Locator definition to look for in page</param>
        /// <returns>true - browser is on selected page. False - otherwise</returns>
        public Task<bool> IsOnPage(IPage page, string locator);
    }
}