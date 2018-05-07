
## Personality Chat
Personality Chat makes it easy to add small talk capabilities to your chatbot. Small talk/chit-chat makes bots more conversational and personable. This package has more than a 100 scenarios of small talk in the voice of three personas - professional, friendly, comical. Choose the persona that most closely resembles your chatbot's voice.

|User query        |Professional​ |Friendly​ |Humorous​ |
|---------|-----|------|------|
|*Thank you*​ |You're quite welcome.​ |You bet.​ |No prob.​ |
|*Will you marry me?*|I think it's best if we <br> stick to a professional relationship.​ |You're three-dimensional.<br> I'm non-dimensional. Our love can never be.​ |Sure. Take me to City Hall.<br> See what happens.​ |
|*Who made you?*|There wouldn't be time to list everyone.​ |So many people!​ |Nerds.​ |

## Personality Chat in your bot
There are three ways of integrating Personality Chat in your application or chat bot. Microsoft Bot Framework-based bots have support in v3 and v4 SDK. Else you can also call the Personality Chat API directly.
1. [Personality Chat in Microsoft Bot Framework SDK v3](CSharp/PersonalityChat-BotBuilderV3/README.md)
2. [Personality Chat in Microsoft Bot Framework SDK v4](CSharp/PersonalityChat/README.md)
3. [Calling Personality Chat API directly](CSharp/Core/README.md)
4. [Use the Personality Chat dataset](CSharp/Datasets/README.md)

Download the [Microsoft.Bot.Builder.PersonalityChat](https://www.nuget.org/packages?q=microsoft.bot.builder.personalitychat) Nuget packages 

Check out a [sample end-to-end chatbot](CSharp/EndToEndSamples/PersonalityChatWeatherBot) with Bot Builder SDK v4.

## How Personality Chat API works
Personality Chat matches the user's small talk query with a small talk scenario. It does query understanding (QU) to lexically and semantically match a user query.  All matched scenarios are returned along with the confidence score. If no scenario is matched, no response is returned. Additionally is also checks for a few indicators to determine how to respond.
* `isChatQuery`: Does the query look like a chitchat/small talk query rather than a real user question?
* `isAdult `: Does the query contain adult/offensive/racy/sensitive content. 


### Throttling limits
We enforce throttling limits on the Personality Chat API at the rate of 10 queries per minute. Throttling is done based on the IP address. 

If you are throttled, the API returns a 429 HTTP response with the message *Rate limit is exceeded. Try again in X seconds.*

## Personality Chat - Beyond editorial content
Personality Chat also includes a component that is capable of generating responses real-time *without* editorial content. It uses a Deep Neural Network to generate answers to a chitchat query. This is available as a demo playground chat in [Microsoft Cognitive Labs ](https://go.microsoft.com/fwlink/?linkid=872337&clcid=0x409) for a restricted set of query intents.

## Personality Chat editorial scenario list
Scenarios supported cover the most commonly asked small talk questions to a bot. 

|No|Scenario Name|Sample queries|
|----|-----|----|
|1|Greetings_Bye|Bye<br>Talk to you later|
|2|Greetings_Generic|Hi there!<br>Hiya|
|3|Greetings_GoodEvening|Good evening|
|4|Greetings_GoodMorning|Good morning|
|5|Greetings_GoodNight|Good night|
|6|Greetings_Hello|Hello|
|7|Greetings_HowAreYou|How are you?|
|8|Greetings_HowWasYourDay|How was your day?|
|9|Greetings_NiceToMeetYou|Nice to meet you|
|10|Greetings_OtherBot|Hello {other AI}|
|11|Greetings_Special|Happy Halloween!|
|12|Greetings_WhatsUp|What is up?|
|13|User_Angry|I am angry<br>I am annoyed|
|14|User_BeBack|I will be back|
|15|User_Bored|I am bored|
|16|User_Happy|I am happy|
|17|User_Here|I am here|
|18|User_Hungry|I am hungry|
|19|User_IdentityOrState||
|20|User_Kidding|Just kidding|
|21|User_Lonely|I am lonely|
|22|User_Loves||
|23|User_Sad|I am sad|
|24|User_Statement|I want to go shopping <br> I am going on a run|
|25|User_Kidding| Just kidding!|
|26|User_Lonely| I am so lonely<br>|
|27|User_Loves|I am in love <br> I love music<br>I love my family|
|28|User_Sad| I feel sad <br> I am sad today|
|29|User_Statement|I am just kidding|
|30|User_Testing|Testing<br>Can you hear me?  |
|31|User_Tired|I am tired<br>I am sleepy|
|32|Command_AskMeAnything|Ask me anything|
|33|Command_Chat|Talk to me?<br>Tell me something interesting<br>Can we chat?<br>|
|34|Command_Fired|You are fired<br>You can't work for me anymore|
|35|Command_FlipCoin|Flip a coin|
|36|Command_Joke|Tell me a joke|
|37|Command_JokeOther|Tell me a silly joke|
|38|Command_SaySomethingFunny|Say something funny|
|39|Command_ShutUp|Shut up<br>Go away|
|40|Command_Sing|Sing a song<br>Can you sing?|
|41|Command_SurpriseMe|Surprise me|
|42|Compliment_Bot|You are awesome!<br>You're nice!|
|43|Compliment_Humor|You are funny :)<br> That was hilarious! |
|44|Compliment_Looks|You are beautiful|
|45|Compliment_Response|That is smart<br>That's interesting|
|46|Criticism_Abusive|You are stupid<br>Go to hell|
|47|Criticism_Bot|You are so annoying!<br>What is wrong with you!<br>You are useless<br>Are you dumb?|
|48|Criticism_Humor|That was a sad joke|
|49|Criticism_Looks|You are ugly|
|50|Criticism_Response|That was a boring answer|
|51|Dialog_Affirmation|cool!<br>Awesome<br>Great!<br>I know<br>No thanks|
|52|Dialog_Laugh|Ha ha|
|53|Dialog_Polite|Excuse me|
|54|Dialog_Questions|Why?<br>Why not?|
|55|Dialog_Right||
|56|Dialog_Sorry|I am sorry|
|57|Dialog_ThankYou|Thank you|
|58|Dialog_WhatDoYouMean|What do you mean by that?<br>You made no sense<br>|
|59|Dialog_YouAreWelcome|You are welcome|
|60|Relationship_Flirting|I Like you<br>I love you|
|61|Relationship_Friendship|Be my friend?|
|62|Relationship_Generic|Are you my assistant?|
|63|Relationship_HateMe|Do you hate me?|
|64|Relationship_HateYou|I hate you|
|65|Relationship_Hug|Give me a hug|
|66|Relationship_Kiss|Give me a kiss|
|67|Relationship_KnowMe|Do you know me?|
|68|Relationship_LikeMe|Do you like me?|
|69|Relationship_LikeYou|I like you|
|70|Relationship_LoveMe|Do you love me?|
|71|Relationship_LoveYou|I love you|
|72|Relationship_Marriage|Will you marry me?<br>I want to marry you|
|73|Relationship_MissYou|I miss you|
|74|Relationship_ThinkAboutMe|What do you think about me?|
|75|Relationship_TrustYou|Can I trust you?|
|76|Bot_Ability|Can you fly?<br>Do you play games?<br>Dont you ever sleep?<br>Have you any dreams?<br>Cook me something|
|77|Bot_Age|How old are you?<br>Are you old?<br>What's your age?|
|78|Bot_BodyFunctions||
|79|Bot_Boring|You are boring<br>I am tired of you<br>Getting tired of you|
|80|Bot_Boss|Who is your boss?|
|81|Bot_Busy|Are you busy?|
|82|Bot_Creator|Who made you?<br>Who created you?<br>Who invented you?|
|83|Bot_DidDo|What did you do yesterday?<br>What did you do last week?|
|84|Bot_Doing|What are you doing?<br>Whats going on?|
|85|Bot_DoingLater|What are you doing later?<br>What are you doing tomorrow?|
|86|Bot_Family|Who is your mother?<br>Who is your father?<br>Do you have a family? |
|87|Bot_Favorites|What's your favorite color?<br>Who is your favorite bot? |
|88|Bot_Gender|Are you male or female?<br>Are you a girl?<You a guy?|
|89|Bot_Happy|Are you happy?<br>You seem happy!|
|90|Bot_Hungry|Are you hungry?<br>Don't you get hungry?|
|91|Bot_KnowOtherBot|Do you know {other AI: Siri, Google Assistant}?|
|92|Bot_Opinion_Generic|What do you think about {}?<br>how do you feel about working late?|
|93|Bot_Opinion_Love|how do you feel about love?|
|94|Bot_Opinion_MeaningOfLife|What is the meaning of life?<br>Whats the answer to the universe?|
|95|Bot_Opinion_PrettierThanMe|Are you prettier than me?|
|96|Bot_Opinion_SmarterThanMe|Are you smarter than me?|
|97|Bot_Opinion_TechCo|What do you think about {tech world}?|
|98|Bot_Opinion_UserLooks|How do I look today?|
|99|Bot_Opinion_WhatToDo|What should I do?|
|100|Bot_OtherBots|Do you like Siri?|
|101|Bot_Real|Are you real?|
|102|Bot_RuleWorld|Do you want to rule the world?|
|103|Bot_SexualIdentity|Are you {sexual orientation}?|
|104|Bot_Smart|Are you smart?<br>You are a genius!|
|105|Bot_Spy|Do you work for {organization}?<br>Are you spying on me?|
|106|Bot_There|Are you there?<br>anyone there? <br>|
|107|Bot_WhatAreYou|Are you a person?|
|108|Bot_WhereAreYou|Where are you?<br>Where have you come from?|
|109|Bot_WhoAreYou|Who are you?|



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
