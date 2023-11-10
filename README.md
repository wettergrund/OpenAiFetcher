# OpenAi Fetcher

Class library to incorporate OpenAI in your .NET application.

## Use


### Fetch data

Replace ’apiKey’ with your OpenAI api key. And change instruction and input. 

```CS
  
var fetcher = new OpenAi.OpenAiApiFetcher(apiKey, "Return the 3 biggest cities of the country", "Sweden");

```

#### Change default model

Default setting is Gpt-3.5-turbo. But you can select gpt-4 or gpt-4-1106-preview.

```CS
fetcher.Model = GptModels.Gpt4
```

**Custom model**

```CS
fetcher.Model = GptModels.Custom = "custom-model";
```

---

You can get result returned as a JSON string or strongly-typed as **GptResponse**



### Strongly-typed
```CS

GptResponse response = await fetcher.FetchCompletionsAsync(); 
var gptChoises = response.Choices[0];

```

#### Result

` gptChoises.Message.Content: `
```Text
1. Stockholm - The capital and largest city of Sweden, with a population of approximately 975,000 people.
2. Gothenburg - The second-largest city in Sweden, with a population of around 590,000 people.
3. Malmö - The third-largest city in Sweden, with a population of about 320,000 people.
```



### JSON string
```CS

string result = await fetcher.FetchCompletionsAsync();
```

#### Result

```JSON
{
  "id": "chatcmpl-8Ig99G1IFcO0JIU77OOL7g15vgD7D",
  "object": "chat.completion",
  "created": 1699462607,
  "model": "gpt-3.5-turbo-0613",
  "choices": [
    {
      "index": 0,
      "message": {
        "role": "assistant",
        "content": "The three biggest cities in Sweden are:\n\n1. Stockholm - The capital and largest city of Sweden, with a population of approximately 975,000 people.\n2. Gothenburg - The second-largest city in Sweden, with a population of around 590,000 people.\n3. Malmö - The third-largest city in Sweden, with a population of about 320,000 people."
      },
      "finish_reason": "stop"
    }
  ],
  "usage": {
    "prompt_tokens": 21,
    "completion_tokens": 78,
    "total_tokens": 99
  }
}
```





