//*****************************************************************************
// ITestEventsDefinition.cs - Definition interface for events
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
    public interface ITestEventsDefinition
    {

        #region [ Members ]

        // Events
        event EventHandler<EventArgs> PreSuiteInitEvent;
        event EventHandler<EventArgs> SuiteInitFailedEvent;
        event EventHandler<EventArgs> PostSuiteInitEvent;
        event EventHandler<EventArgs> PreTestClassInitEvent;
        event EventHandler<EventArgs> PostTestClassInitEvent;
        event EventHandler<EventArgs> TestClassInitFailedEvent;
        event EventHandler<EventArgs> PreTestInitEvent;
        event EventHandler<EventArgs> PostTestInitEvent;
        event EventHandler<EventArgs> TestInitFailedEvent;
        event EventHandler<EventArgs> PreTestTearEvent;
        event EventHandler<EventArgs> PostTestTearEvent;
        event EventHandler<EventArgs> TestTearFailedEvent;

        #endregion
    }
}