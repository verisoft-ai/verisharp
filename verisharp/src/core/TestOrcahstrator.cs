//*****************************************************************************
// TestOrchastrator.cs - Orchastrator for all tests
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
    public class TestOrchastrator
    {
        #region [ Members ]

        // Fields
        //private readonly ILogger<TestOrchastrator> m_logger;
        public TestEvents testEvents;
        private List<ISubscriber> subscribers;

        #endregion

        #region [ Constructors ]

        private TestOrchastrator()
        {
            subscribers = new List<ISubscriber>();
            testEvents = new TestEvents();

        }

        #endregion

        #region [ Methods ]

        public void Register(ISubscriber subscriber)
        {
            if( subscriber == null)
            {
                return;
            }

            subscribers.Add(subscriber);

            testEvents.PostSuiteInitEvent += subscriber.PostSuiteInit;
            testEvents.PostTestClassInitEvent += subscriber.PostTestClassInit;
            testEvents.PostTestInitEvent += subscriber.PostTestInit;
            testEvents.PostTestTearEvent += subscriber.PostTestTear;
            testEvents.PreSuiteInitEvent += subscriber.PreSuiteInit;
            testEvents.PreTestClassInitEvent += subscriber.PreTestClassInit;
            testEvents.PreTestInitEvent += subscriber.PreTestInit;
            testEvents.PreTestTearEvent += subscriber.PreTestTear;
            testEvents.SuiteInitFailedEvent += subscriber.SuiteInitFailed;
            testEvents.TestTearFailedEvent += subscriber.TestTearFailed;

        }

        public void PreSuiteInit(string msg)
        {
            testEvents.PreSuiteInit(msg);

        }
        public void SuiteInitFailed(string msg)
        {
            testEvents.SuiteInitFailed(msg);

        }
        public void PostSuiteInit(string msg)
        {
            testEvents.PostSuiteInit(msg);

        }
        public void PreTestClassInit(string msg)
        {
            testEvents.PreTestClassInit(msg);

        }
        public void PostTestClassInit(string msg)
        {
            testEvents.PostTestClassInit(msg);

        }
        public void TestClassInitFailed(string msg)
        {
            testEvents.TestClassInitFailed(msg);

        }
        public void PreTestInit(string msg)
        {
            testEvents.PreTestInit(msg);

        }
        public void PostTestInit(string msg)
        {
            testEvents.PostTestInit(msg);

        }
        public void TestInitFailed(string msg)
        {
            testEvents.TestInitFailed(msg);

        }
        public void PreTestTear(string msg)
        {
            testEvents.PreTestTear(msg);

        }
        public void PostTestTear(string msg)
        {
            testEvents.PostTestTear(msg);

        }

        public void TestTearFailed(string msg)
        {
            testEvents.TestTearFailed(msg);

        }

        #endregion
       
        #region [ Static ]

        // Static Fields
        private static TestOrchastrator s_orchastrator;


        // Static Constructor
        public static TestOrchastrator Instance
        {
            get
            {
                if (s_orchastrator == null)
                    s_orchastrator = new TestOrchastrator();

                return s_orchastrator;

            }
        }

        #endregion

    }
}
