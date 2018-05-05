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

namespace Microsoft.Bot.Builder.PersonalityChat
{
    using System.Collections.Generic;
    using Microsoft.Bot.Builder.PersonalityChat.Core;

    /// <summary>
    /// Options to alter the default behaviour of the PersonalityChat Middleware
    /// </summary>
    public class PersonalityChatMiddlewareOptions : PersonalityChatOptions
    {
        public PersonalityChatMiddlewareOptions(string subscriptionKey = "", PersonalityChatPersona botPersona = PersonalityChatPersona.Friendly, bool respondOnlyIfChat = false, float scoreThreshold = 0.3F, bool endActivityRoutingOnResponse = false, Dictionary<string, List<string>> scenarioResponsesMapping = null) : base(subscriptionKey, botPersona, scenarioResponsesMapping)
        {
            this.RespondOnlyIfChat = respondOnlyIfChat;
            this.ScoreThreshold = scoreThreshold;
            this.EndActivityRoutingOnResponse = endActivityRoutingOnResponse;
        }

        /// <summary>
        /// If true, personality talk middleware will only respond 
        /// when query is classified as a chat query.
        /// </summary>
        public bool RespondOnlyIfChat { get; private set; }

        /// <summary>
        /// Score threshold of scenario/intents matching to query. Range [0,1]
        /// </summary>
        public float ScoreThreshold { get; private set; }

        /// <summary>
        /// If true then routing of the activity will be stopped when an response is 
        /// successfully returned by the PersonalityChat Middleware
        /// </summary>
        public bool EndActivityRoutingOnResponse { get; private set; }
    }
}