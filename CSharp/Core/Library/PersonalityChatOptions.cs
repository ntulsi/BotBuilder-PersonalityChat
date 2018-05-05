// 
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.
// 
// Microsoft Bot Framework: http://botframework.com
// 
// Personality Chat based Dialogs for Bot Builder:
// https://github.com/Microsoft/BotBuilder-PersonalityChat
// 
// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// MIT License:
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

namespace Microsoft.Bot.Builder.PersonalityChat.Core
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The PersonalityChatApi information required to build the request. 
    /// </summary>
    [Serializable]
    public class PersonalityChatOptions
    {
        /// <summary>
        /// Constructs the PersonalityChatOptions using the options.
        /// </summary>
        public PersonalityChatOptions(string subscriptionKey = "", PersonalityChatPersona botPersona = PersonalityChatPersona.Friendly, Dictionary<string, List<string>> scenarioResponse = null)
        {
            this.SubscriptionKey = subscriptionKey;
            this.BotPersona = botPersona;
            this.scenarioResponse = scenarioResponse;
        }

        /// <summary>
        /// The Subscription Key to access PersonalityChatAPI
        /// </summary>
        public string SubscriptionKey { get; private set; }

        /// <summary>
        /// The required persona for Bot.
        /// </summary>
        public PersonalityChatPersona BotPersona { get; private set; }

        /// <summary>
        /// Customizable ScenarioResponse list.
        /// </summary>
        public Dictionary<string, List<string>> scenarioResponse { get; private set; }
    }
}