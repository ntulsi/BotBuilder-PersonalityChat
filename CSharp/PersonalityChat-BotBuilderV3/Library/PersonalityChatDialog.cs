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
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Connector;
    using Microsoft.Bot.Builder.Internals.Fibers;
    using System.Reflection;
    using System.Linq;
    using System.Web;
    using Microsoft.Bot.Builder.PersonalityChat.Core;

    [Serializable]
    public class PersonalityChatDialog<TResult> : IDialog<IMessageActivity>
    {
        private PersonalityChatDialogOptions personalityChatDialogOptions = new PersonalityChatDialogOptions();

        public PersonalityChatDialog()
        {
        }

        public void SetPersonalityChatDialogOptions(PersonalityChatDialogOptions personalityChatDialogOptions)
        {
            this.personalityChatDialogOptions = personalityChatDialogOptions;
        }

        async Task IDialog<IMessageActivity>.StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            var userQuery = message.Text;
            var personalityChatService = new PersonalityChatService(this.personalityChatDialogOptions);

            var personalityChatResults = await personalityChatService.QueryServiceAsync(userQuery);

            if (personalityChatDialogOptions.RespondOnlyIfChat && !personalityChatResults.IsChatQuery)
            {
                return;
            }
            
            string personalityChatResponse = this.GetResponse(personalityChatResults);

            await this.PostPersonalityChatResponseToUser(context, personalityChatResponse);
        }

        public virtual string GetResponse(PersonalityChatResults personalityChatResults)
        {
            var matchedScenarios = personalityChatResults?.ScenarioList;

            string response = string.Empty;

            if (matchedScenarios != null)
            {
                var topScenario = matchedScenarios.FirstOrDefault();

                if (topScenario?.Responses != null && topScenario.Score > this.personalityChatDialogOptions.ScenarioThresholdScore && topScenario.Responses.Count > 0)
                {
                    Random randomGenerator = new Random();
                    int randomIndex = randomGenerator.Next(topScenario.Responses.Count);

                    response = topScenario.Responses[randomIndex];
                }
            }

            return response;
        }

        public virtual async Task PostPersonalityChatResponseToUser(IDialogContext context, string personalityChatResponse)
        {
            if (!string.IsNullOrEmpty(personalityChatResponse))
            {
                await context.PostAsync(personalityChatResponse);
            }

            context.Done(true);
        }
    }
}