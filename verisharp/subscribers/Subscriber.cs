//*****************************************************************************
// Subscriber.cs - A General Purpose Subscriber
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
using Verisoft.Core;
namespace Verisoft.Subscribers
{

    #region [ Methods ]
    public class Subscriber : ISubscriber
    {
        public void PreSuiteInit(object source, EventArgs e)
        {
            Console.WriteLine("Subscriber: PreSuiteInit");

        }
        public void SuiteInitFailed(object source, EventArgs e)
        {
            Console.WriteLine("Subscriber: SuiteInitFailed");

        }
        public void PostSuiteInit(object source, EventArgs e)
        {
            Console.WriteLine("Subscriber: PostSuiteInit");

        }
        public void PreTestClassInit(object source, EventArgs e)
        {
            Console.WriteLine("Subscriber: PreTestClassInit");

        }
        public void PostTestClassInit(object source, EventArgs e)
        {
            Console.WriteLine("Subscriber: PostTestClassInit");

        }
        public void TestClassInitFailed(object source, EventArgs e)
        {
            Console.WriteLine("Subscriber: TestClassInitFailed");

        }
        public void PreTestInit(object source, EventArgs e)
        {
            Console.WriteLine("Subscriber: PreTestInit");

        }
        public void PostTestInit(object source, EventArgs e)
        {
            Console.WriteLine("Subscriber: PostTestInit");

        }
        public void TestInitFailed(object source, EventArgs e)
        {
            Console.WriteLine("Subscriber: TestInitFailed");

        }
        public void PreTestTear(object source, EventArgs e)
        {
            Console.WriteLine("Subscriber: PreTestTear");

        }
        public void PostTestTear(object source, EventArgs e)
        {
            Console.WriteLine("Subscriber: PostTestTear");

        }

        public void TestTearFailed(object source, EventArgs e)
        {
            Console.WriteLine("Subscriber: PreSuiteInit");

        }

        #endregion
    }
}