## Personality Chat in Bot Framework SDK v4
Personality Chat is available as middleware in Bot Framework SDK v4. The middleware calls the Personality Chat API to match a user query with a small talk scenario. For matched user queries, a response is returned

Example:

	If personality is set to "Professional" 
	User input query to the bot: "so bored!!"
	Matched scenario: "I am bored"
	Response: "Well, let me know if there’s anything I can do for you."
	

#### Simple Personality Chat bot
[SimplePersonalityChatBot](SimplePersonalityChatBot) demonstrates a basic bot with chitchat capabilities that calls the PersonalityChat middleware. The middleware either returns a response if query is matched to a scenario or returns empty. 

```csharp
public void ConfigureServices(IServiceCollection services)
{
	services.AddBot<BasicPersonalityChatBot>(options =>
	{
		options.CredentialProvider = new ConfigurationCredentialProvider(Configuration);

		var middleware = options.Middleware;

		var PersonalityChatOptions = new PersonalityChatMiddlewareOptions();

		middleware.Add(new PersonalityChatMiddleware(PersonalityChatOptions));
	});
}
````

PersonalityChatOptions has defaults which can be overridden.
* `botPersona`: Set the personality of response. Choose between  *PersonalityChat.Professional*, *PersonalityChat.Friendly* and *PersonalityChat.Comical*
* `respondOnlyIfChat`: Specify whether the in-built chat classifier should be used. Chat classifier adds a layer of filtering on input user queries to prevent responding to those that are not chitchat-related. For example, "*Is it cold tonight*"? is a fact-finding query that should not be treated as chitchat.
* `scenarioThresholdScore`: Scenarios that matched the user query with a confidence score below this threshold will not be returned in the response body.
* `EndActivityRoutingOnResponse`: Specifies whether to continue processing or not.

Default settings for PersonalityChatDialogOptions()

```csharp
public PersonalityChatMiddlewareOptions(string subscriptionKey = "", PersonalityChat botPersona = PersonalityChat.Friendly, bool respondOnlyIfChat = false, float scoreThreshold = 0.3F, bool endActivityRoutingOnResponse = false) : base(subscriptionKey, botPersona)
        {
            this.RespondOnlyIfChat = respondOnlyIfChat;
            this.ScoreThreshold = scoreThreshold;
            this.EndActivityRoutingOnResponse = endActivityRoutingOnResponse;
        }
````

#### Customizing editorial response strings
You will very likely want to override the response for questions around bot identity (such as *"Who are you?"*, *"Who made you?"*) to make them specific to your chatbot.

The complete dataset mapping between small talk scenarios and responses is available at [Datasets](CSharp/Datasets/scenarioResponseMapping.txt). To edit any responses or remove existing ones, edit the file and pass it in as parameters to `PersonalityChatDialogOptions().`
The customizations in this file are not additive so do not delete other default responses.

```csharp
var scenarioResponses = File.ReadAllLines(@"Resources\CustomResponses.txt");
var scenarioResponsesMapping = new Dictionary<string, List<string>>();

foreach (var scenarioResponse in scenarioResponses)
{
    string scenario = scenarioResponse.Split('\t')[0];
    string response = scenarioResponse.Split('\t')[1];

    if (!scenarioResponsesMapping.ContainsKey(scenario))
    {
        scenarioResponsesMapping[scenario] = new List<string>();
    }

    scenarioResponsesMapping[scenario].Add(response);
}

var personalityChatOptions = new PersonalityChatMiddlewareOptions(scenarioResponsesMapping: scenarioResponsesMapping);

````

#### Personality Chat bot with overrides for customizing responses
Override the `GetResponse` method to intercept and manipulate the response being returned from the Personality Chat API

```csharp
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

````
