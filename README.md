# OpenAi Fetcher

Class library to incorporate OpenAI in your .NET application.

## Use


### Fetch data
```CS
  
var fetcher = new OpenAi.OpenAiApiFetcher(apiKey, "Return the 3 biggest cities of the country", "Sweden");

```


---

You can get reuslt returned as a JSON string or strongly-typed as **GptResponse**



### Strongly-typed
```CS

var fetcher = new OpenAi.OpenAiApiFetcher(apiKey, "Return the capital city of the country", "Australia");

string result = await Fetcher.FetchCompletionsAsync();

```

#### Result

```JSON
1. Stockholm - The capital and largest city of Sweden, with a population of approximately 975,000 people.
2. Gothenburg - The second-largest city in Sweden, with a population of around 590,000 people.
3. Malmö - The third-largest city in Sweden, with a population of about 320,000 people.
```



### JSON string
```CS

string result = await Fetcher.FetchCompletionsAsync();
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





