
## Personality Chat
Personality Chat makes it easy to add small talk capabilities to your chatbot. Small talk/chit-chat makes bots more conversational and personable. This package has about a 100 scenarios of small talk in the voice of three personas - professional, friendly, comical. Choose the persona that most closely resembles your chatbot's voice.

|Scenario​        |Professional​ |Friendly​ |Humorous​ |
|---------|-----|------|------|
|*Thank you*​ |You're quite welcome.​ |You bet.​ |No prob.​ |
|*Will you marry me?*|I think it's best if we stick to a professional relationship.​ |You're three-dimensional. I'm non-dimensional. Our love can never be.​ |Sure. Take me to City Hall. See what happens.​ |
|*Who made you?*|There wouldn't be time to list everyone.​ |So many people!​ |Nerds.​ |


## Personality Chat in your bot
There are three ways of integrating Personality Chat in your application or chat bot. Microsoft Bot Framework-based bots have support in v3 and v4 SDK. Else you can also call the Personality Chat API directly.
1. [Personality Chat in Microsoft Bot Framework SDK v3](CSharp/PersonalityChat-BotBuilderV3/README.md)
2. [Personality Chat in Microsoft Bot Framework SDK v4](CSharp/PersonalityChat/README.md)
3. [Calling Personality Chat API directly](CSharp/PersonalityChat/Core/README.md)
4. [Use the Personality Chat dataset](Datasets/README.md)

## How Personality Chat works
    `TODO:  Add some simple architecture diagram of dialog/middleware calling the API
    Also reference throttling limits.`

Throttling limits: 

## Personality Chat scenario list
Scenarios supported cover the most commonly asked small talk questions to a bot. 

|No|Scenario Name|Sample queries|
|---|-----|----|
|1|Bot_Ability|Can you fly?|
|2|Bot_Age|How old are you?|
|3|Bot_BodyFunctions|Do you feel things?|
|4|Bot_Boring|You are boring|
|5|Bot_Boss|Who is your boss?|
|6|Bot_Busy|Are you busy?|
|7|Bot_Creator|Who made you?|
|8|Bot_DidDo|What did you do {past time}?|
|9|Bot_Doing|What are you doing?|
|10|Bot_DoingLater|What are you doing {future time}?|
|11|Bot_Family|Who is your mother?|
|12|Bot_Favorites|Whats your favorite color?|
|13|Bot_Gender|Are you male or female?|
|14|Bot_Happy|Are you happy?|
|15|Bot_Hungry|Are you hungry?|
|16|Bot_KnowOtherBot|Do you know {other AI}?|
|17|Bot_Opinion_Generic|What do you think about people?|
|18|Bot_Opinion_Love||
|19|Bot_Opinion_MeaningOfLife|What is the meaning of life?|
|20|Bot_Opinion_PrettierThanMe|Are you prettier than me?|
|21|Bot_Opinion_SmarterThanMe|Are you smarter than me?|
|22|Bot_Opinion_TechCo|What do you think about {tech world}?|
|23|Bot_Opinion_UserLooks|How do I look?|
|24|Bot_Opinion_WhatToDo|What should I do?|
|25|Bot_OtherBots|Do you like Siri?|
|26|Bot_Real|Are you real?|
|27|Bot_RuleWorld|Do you want to rule the world?|
|28|Bot_SexualIdentity|Are you {sexual orientation}?|
|29|Bot_Smart|Are you smart?|
|30|Bot_Spy|Do you work for the CIA?|
|31|Bot_There|Are you there?|
|32|Bot_WhatAreYou|What are you?|
|33|Bot_WhereAreYou|Where are you?|
|34|Bot_WhoAreYou|Who are you?|
|35|Command_AskMeAnything|Ask me anything|
|36|Command_Chat|Talk to me?|
|37|Command_Fired|You are fired|
|38|Command_FlipCoin|Flip a coin|
|39|Command_Joke|Tell me a joke|
|40|Command_JokeOther|Tell me a silly joke|
|41|Command_SaySomethingFunny|Say something funny|
|42|Command_ShutUp|Shut up|
|43|Command_Sing|Sing a song|
|44|Command_SurpriseMe|Surprise me|
|45|Compliment_Bot|You are awesome!|
|46|Compliment_Humor|You are funny :) |
|47|Compliment_Looks|You are beautiful|
|48|Compliment_Response|That was smart|
|49|Criticism_Abusive|You s***|
|50|Criticism_Bot|You are so annoying!|
|51|Criticism_Humor|That was a sad joke|
|52|Criticism_Looks|You are ugly|
|53|Criticism_Response||
|54|Dialog_Affirmation|cool!|
|55|Dialog_Laugh|Ha ha|
|56|Dialog_Polite|Sounds good|
|57|Dialog_Questions|Why?|
|58|Dialog_Right|You are right|
|59|Dialog_Sorry|I am sorry|
|60|Dialog_ThankYou|Thank you|
|61|Dialog_WhatDoYouMean|What do you mean by that?|
|62|Dialog_YouAreWelcome|You are welcome|
|63|Greetings_Bye|Bye|
|64|Greetings_Generic|Hi there!|
|65|Greetings_GoodEvening|Good evening|
|66|Greetings_GoodMorning|Good morning|
|67|Greetings_GoodNight|Good night|
|68|Greetings_Hello|Hello|
|69|Greetings_HowAreYou|How are you?|
|70|Greetings_HowWasYourDay|How was your day?|
|71|Greetings_NiceToMeetYou|Nice to meet you|
|72|Greetings_OtherBot|Hello {other AI}|
|73|Greetings_Special|Happy Halloween!|
|74|Greetings_WhatsUp|What is up?|
|75|Relationship_Flirting||
|76|Relationship_Friendship|Are you my friend?|
|77|Relationship_Generic||
|78|Relationship_HateMe|Do you hate me?|
|79|Relationship_HateYou|I hate you|
|80|Relationship_Hug|Give me a hug|
|81|Relationship_Kiss|Give me a kiss|
|82|Relationship_KnowMe|Do you know me?|
|83|Relationship_LikeMe|Do you like me?|
|84|Relationship_LikeYou|I like you|
|85|Relationship_LoveMe|Do you love me?|
|86|Relationship_LoveYou|I love you|
|87|Relationship_Marriage|Will you marry me?|
|88|Relationship_MissYou|I miss you|
|89|Relationship_ThinkAboutMe|What do you think about me?|
|90|Relationship_TrustYou|Can I trust you?|
|91|User_Angry|I am angry|
|92|User_BeBack|I will be back|
|93|User_Bored|I am bored|
|94|User_Happy|I am happy|
|95|User_Here|I am here|
|96|User_Hungry|I am hungry|
|97|User_IdentityOrState||
|98|User_Kidding|Just kidding|
|99|User_Lonely|I am lonely|
|100|User_Loves||
|101|User_Sad|I am sad|
|102|User_Statement||
|103|User_Testing|Testing|
|104|User_Tired|I am tired|



## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
