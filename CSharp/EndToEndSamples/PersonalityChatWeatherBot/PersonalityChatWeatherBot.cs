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

namespace Microsoft.Bot.Builder.PersonalityChat.Sample.WeatherBot
{
    using System.Threading.Tasks;
    using Microsoft.Bot;
    using Microsoft.Bot.Builder;
    using Microsoft.Bot.Schema;

    public class PersonalityChatWeatherBot : IBot
    {
        public async Task OnTurn(ITurnContext context)
        {
            // At this point, the PersonalityChat Middleware has already been run. If the incoming
            // Activity was a message, the Middleware called out to PersonalityChat looking for 
            // a response. If a response was found, the Responded flag on the context will be set 
            // and we can do nothing here. If the Middlware did NOT find a match, then it's 
            // up to the Bot to send something to the user, in this case the "No Match" message. 
            switch (context.Activity.Type)
            {
                case ActivityTypes.Message:
                    if (context.Activity.Type == ActivityTypes.Message && context.Responded == false)
                    {
                        // Call the weather API. For now a default response:-

                        if (context.Activity.AsMessageActivity().Text.ToLower().Contains("weather"))
                        {
                            await context.SendActivity("Overcast skies, and temps dropping to 8°C tonight.Stay warm and dry, or don’t… up to you really");
                        }
                        else
                        {
                            await context.SendActivity("Sorry, I do not understand.");
                        }
                    }

                    break;
                case ActivityTypes.ConversationUpdate:
                    foreach (var newMember in context.Activity.MembersAdded)
                    {
                        if (newMember.Id != context.Activity.Recipient.Id)
                        {
                            await context.SendActivity("Hiya! I’ll be your weatherman.");
                        }
                    }

                    break;
            }
        }
    }
}
