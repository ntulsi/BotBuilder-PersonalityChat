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
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder.PersonalityChat.Core;
    using Microsoft.Bot.Schema;

    public class PersonalityChatMiddleware : IMiddleware
    {
        private readonly PersonalityChatService personalityChatService;
        private readonly PersonalityChatMiddlewareOptions personalityChatMiddlewareOptions;

        public PersonalityChatMiddleware(PersonalityChatMiddlewareOptions personalityChatMiddlewareOptions)
        {
            this.personalityChatMiddlewareOptions = personalityChatMiddlewareOptions ?? throw new ArgumentNullException(nameof(personalityChatMiddlewareOptions));

            this.personalityChatService = new PersonalityChatService(personalityChatMiddlewareOptions);
        }

        public async Task OnTurn(ITurnContext context, MiddlewareSet.NextDelegate next)
        {
            if (context.Activity.Type == ActivityTypes.Message)
            {
                var messageActivity = context.Activity.AsMessageActivity();
                if (!string.IsNullOrEmpty(messageActivity.Text))
                {
                    var results = await this.personalityChatService.QueryServiceAsync(messageActivity.Text.Trim()).ConfigureAwait(false);

                    if (!this.personalityChatMiddlewareOptions.RespondOnlyIfChat || results.IsChatQuery)
                    {
                        string personalityChatResponse = this.GetResponse(results);
                        await this.PostPersonalityChatResponseToUser(context, next, personalityChatResponse);
                    }
                }
            }

            await next().ConfigureAwait(false);
        }

        public virtual string GetResponse(PersonalityChatResults personalityChatResults)
        {
            var matchedScenarios = personalityChatResults?.ScenarioList;

            string response = string.Empty;

            if (matchedScenarios != null)
            {
                var topScenario = matchedScenarios.FirstOrDefault();

                if (topScenario?.Responses != null && topScenario.Score > this.personalityChatMiddlewareOptions.ScoreThreshold && topScenario.Responses.Count > 0)
                {
                    Random randomGenerator = new Random();
                    int randomIndex = randomGenerator.Next(topScenario.Responses.Count);

                    response = topScenario.Responses[randomIndex];
                }
            }

            return response;
        }

        public virtual async Task PostPersonalityChatResponseToUser(ITurnContext context, MiddlewareSet.NextDelegate next, string personalityChatResponse)
        {
            if (!string.IsNullOrEmpty(personalityChatResponse))
            {
                await context.SendActivity(personalityChatResponse).ConfigureAwait(false);

                if (this.personalityChatMiddlewareOptions.EndActivityRoutingOnResponse)
                {
                    // Query is answered, don't keep routing
                    return;
                }
            }
        }
    }
}