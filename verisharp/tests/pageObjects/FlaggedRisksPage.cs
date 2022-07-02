//*****************************************************************************
// FlaggedRisksPage.cs - Representation of the flagged risks view in the websites -> risks page
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
// 07/02/2022 - Nir Gallner
// Original version of source code generated.
//
//*****************************************************************************

using log4net;
using System.Reflection;
using Microsoft.Playwright;

namespace Verisoft.Pages
{
    /// <summary>
    /// Representation of the flagged risks, part of the websites->risks page
    /// </summary>
    public class FlaggedRisksPage : WebsitesPage
    {

        #region [ Members ]

        private readonly string m_risksLocator = ".FlaggedRiskListGroup_listContainer__zAQba";

        #endregion


        #region [ Constructors ]

        public FlaggedRisksPage(IPage page) : base(page)
        {
        }

        #endregion


        #region [ Methods ]

        public override Task<bool> IsOnPage()
        {
            return base.IsOnPage(m_page, m_risksLocator);
        }


        /// <summary>
        /// Retrieves a list of strings with the group names
        /// </summary>
        /// <returns>a list of string with the groups names</returns>
        public async Task<List<string>> GetGroupNames()
        {
            string selector = "//*[@class='FlaggedRiskListGroup_listContainer__zAQba']//*[@class='Accordion_summaryText__Zwpw']/span";

            // Wait for page to fully load
            await m_page.WaitForSelectorAsync(selector);

            // Find the list of items and convert them to string
            IReadOnlyList<IElementHandle> handles = m_page.QuerySelectorAllAsync(selector).Result;
            List<string> groupNames = new List<string>();
            foreach (IElementHandle handle in handles)
            {
                groupNames.Add(handle.InnerTextAsync().Result);
            }

            return groupNames;
        }


        /// <summary>
        /// Retrieves the number of risks per given group
        /// </summary>
        /// <param name="groupName">Name of the group</param>
        /// <returns>number of risks per given group</returns>
        /// <exception cref="Exception">If for some reason the number could not be retrieved</exception>
        public int GetSumOfGroupRisks(string groupName)
        {
            List<string> groupNames = GetGroupNames().Result;
            int index = groupNames.FindIndex(str => str.Contains(groupName));
            if (index >= 0)
            {
                string result = groupNames[index];
                int sum;
                if (int.TryParse(result.Split('(', ')')[1], out sum) == true)
                    return sum;
                else
                    throw new Exception("Group name " + result + "could not be parsed");

            }

            // If we are here, it means there is no group so sum is 0
            return 0;

        }

        #endregion


        #region [ Static ]
        
        // Static Fields
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        #endregion
    }
}
