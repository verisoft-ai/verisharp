//*****************************************************************************
// DataGenerator.cs - Data class for tests
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
namespace Verisoft
{
    /// <summary>
    /// Data class for tests. Holds the data generation mechanism to be used throughout the test cases.
    /// </summary>
    class DataGenerator
    {
        /// <summary>
        /// userFullName, username, password, company, brand
        /// </summary>
        public static object[] User =
        {
            new object[]
            {
                "Test Automation", "Test.Auto", "Nglr!2022", "TTI", "Ryobi"
            }
        };
    }
}