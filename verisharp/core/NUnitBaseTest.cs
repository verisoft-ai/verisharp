//*****************************************************************************
// NUnitBaseTest.cs - Base Test Class For All Tests
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
// 06/07/2022 - Nir Gallner
// Original version of source code generated.
//
//*****************************************************************************
using NUnit.Framework;
using Verisoft.Subscribers;

namespace Verisoft.Core
{

    [SetUpFixture]
    public class FixtureSetup
    {

        #region [ Methods ]

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            TestContext.Progress.WriteLine("FixtureSetup:OneTimeSetUp:Before");
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            TestContext.Progress.WriteLine("FixtureSetup:OneTimeTearDown");
        }

        #endregion
    }



    [TestFixture]
    public class NUnitBaseTest
    {


        #region [ Constructors ]
        public NUnitBaseTest()
        {

            TestOrchastrator.Instance.Register(new Subscriber());
        }

        #endregion


        #region [ Methods ]

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            TestContext.Progress.WriteLine("NUnitBaseTest:OneTimeSetUp:Before");
        }


        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("NUnitBaseTest:SetUp:Before");

            try
            {
                TestOrchastrator.Instance.PreTestInit("NUnitBaseTest:SetUp:Before");
                TestContext.Progress.WriteLine("NUnitBaseTest:SetUp:After");
                TestOrchastrator.Instance.PostTestInit("NUnitBaseTest:SetUp:After");
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine("NUnitBaseTest:SetUp:Failed " + e.GetType());
                TestOrchastrator.Instance.SuiteInitFailed("NUnitBaseTest:SetUp:Failed");
            }
        }


        [TearDown]
        public void TearDown()
        {
            TestContext.Progress.WriteLine("NUnitBaseTest:TearDown:Before");

            try
            {
                TestOrchastrator.Instance.PreTestTear("NUnitBaseTest:TearDown:Before");
                TestContext.Progress.WriteLine("NUnitBaseTest:TearDown:After");
                TestOrchastrator.Instance.PostTestTear("NUnitBaseTest:TearDown:After");
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine("NUnitBaseTest:TearDown:Failed " + e.GetType());
                TestOrchastrator.Instance.SuiteInitFailed("NUnitBaseTest:TearDown:Failed");
            }
        }


        [OneTimeTearDown]
        public void OneTimeTearDown() => TestContext.Progress.WriteLine("NUnitBaseTest:OneTimeTearDown");

        #endregion
    }
}
