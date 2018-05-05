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

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Bot.Builder.Dialogs;
using Moq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Autofac;
using Microsoft.Bot.Builder.Dialogs.Internals;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Bot.Builder.PersonalityChat;

namespace Microsoft.Bot.Builder.PersonalityChat.Tests
{
    [TestClass]
    public sealed class PersonalityChatV3DialogTests : DialogTestBase
    {
        public sealed class PersonalityChatTestDialog : PersonalityChatDialog<object>
        {
            public PersonalityChatTestDialog() : base()
            { }
        }

        [TestMethod]
        public async Task ExecutePersonalityChatTests()
        {
            string userQuery = "test query aswedff";
            string expectedResponse = "test response";
            var personalityChatDialog = new PersonalityChatTestDialog();
            await this.TestPersonalityChatDialogResponse(personalityChatDialog, userQuery, expectedResponse);

            return;
        }

        private async Task TestPersonalityChatDialogResponse(IDialog<object> personalityChatDialog, string userQuery, string expectedResponse)
        {
            // arrange
            var toBot = DialogTestBase.MakeTestMessage();
            toBot.From.Id = Guid.NewGuid().ToString();
            toBot.Text = userQuery;

            Func<IDialog<object>> MakeRoot = () => personalityChatDialog;

            using (new FiberTestBase.ResolveMoqAssembly(personalityChatDialog))
            using (var container = Build(Options.MockConnectorFactory | Options.ScopedQueue, personalityChatDialog))
            {
                // act: sending the message
                IMessageActivity toUser = null;
                toUser = await GetResponse(container, MakeRoot, toBot);

                // assert: check if the dialog returned the right response
                Assert.AreEqual(toUser.Text, expectedResponse);
            }
        }

        private async Task<IMessageActivity> GetResponse(
            IContainer container,
            Func<IDialog<object>> makeRoot,
            IMessageActivity toBot)
        {
            using (var scope = DialogModule.BeginLifetimeScope(container, toBot))
            {
                DialogModule_MakeRoot.Register(scope, makeRoot);

                // act: sending the message
                var task = scope.Resolve<IPostToBot>();
                CancellationToken token = default(CancellationToken);
                await task.PostAsync(toBot, token);
                return scope.Resolve<Queue<IMessageActivity>>().Dequeue();
            }
        }
    }
}