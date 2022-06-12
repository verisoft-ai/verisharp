//*****************************************************************************
// TestEvents.cs - Events Definition for Tests
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
namespace Verisoft.Core
{
    public class TestEvents : ITestEventsDefinition
    {
        #region [ Members ]

        // Events
        public event EventHandler<EventArgs>? PreSuiteInitEvent;
        public event EventHandler<EventArgs>? SuiteInitFailedEvent;
        public event EventHandler<EventArgs>? PostSuiteInitEvent;
        public event EventHandler<EventArgs>? PreTestClassInitEvent;
        public event EventHandler<EventArgs>? PostTestClassInitEvent;
        public event EventHandler<EventArgs>? TestClassInitFailedEvent;
        public event EventHandler<EventArgs>? PreTestInitEvent;
        public event EventHandler<EventArgs>? PostTestInitEvent;
        public event EventHandler<EventArgs>? TestInitFailedEvent;
        public event EventHandler<EventArgs>? PreTestTearEvent;
        public event EventHandler<EventArgs>? PostTestTearEvent;
        public event EventHandler<EventArgs>? TestTearFailedEvent;

        #endregion


        #region [ Methods ]
        public void PreSuiteInit(string msg)
        {
            EventArgs e = new TestEventArgs("PreSuiteInit: " + msg);
            PreSuiteInitEvent?.Invoke(this, e);

        }
        public void SuiteInitFailed(string msg)
        {
            EventArgs e = new TestEventArgs("SuiteInitFailed: " + msg);
            SuiteInitFailedEvent?.Invoke(this, e);

        }
        public void PostSuiteInit(string msg)
        {
            EventArgs e = new TestEventArgs("PostSuiteInit: " + msg);
            PostSuiteInitEvent?.Invoke(this, e);

        }
        public void PreTestClassInit(string msg)
        {
            EventArgs e = new TestEventArgs("PreTestClassInit: " + msg);
            PreTestClassInitEvent?.Invoke(this, e);

        }
        public void PostTestClassInit(string msg)
        {
            EventArgs e = new TestEventArgs("PostTestClassInit: " + msg);
            PostTestClassInitEvent?.Invoke(this, e);

        }
        public void TestClassInitFailed(string msg)
        {
            EventArgs e = new TestEventArgs("TestClassInitFailed: " + msg);
            TestClassInitFailedEvent?.Invoke(this, e);

        }
        public void PreTestInit(string msg)
        {
            EventArgs e = new TestEventArgs("PreTestInit: " + msg);
            PreTestInitEvent?.Invoke(this, e);

        }
        public void PostTestInit(string msg)
        {
            EventArgs e = new TestEventArgs("PostTestInit: " + msg);
            PostTestInitEvent?.Invoke(this, e);

        }
        public void TestInitFailed(string msg)
        {
            EventArgs e = new TestEventArgs("TestInitFailed: " + msg);
            TestInitFailedEvent?.Invoke(this, e);

        }
        public void PreTestTear(string msg)
        {
            EventArgs e = new TestEventArgs("PreTestTear: " + msg);
            PreTestTearEvent?.Invoke(this, e);

        }
        public void PostTestTear(string msg)
        {
            EventArgs e = new TestEventArgs("PostTestTear: " + msg);
            PostTestTearEvent?.Invoke(this, e);

        }

        public void TestTearFailed(string msg)
        {
            EventArgs e = new TestEventArgs("TestTearFailed: " + msg);
            TestTearFailedEvent?.Invoke(this, e);

        }

        #endregion
    }
}
