# OpenAi Fetcher

Class library to make incorporate OpenAI in your .NET application.

## Use

```CS

  var newFetcher = new OpenAi.OpenAiApiFetcher(apiKey, "Return the capital city of the country", "Australia");
  
  string result = await newFetcher.FetchCompletionsAsync();

```

## Result
```JSON
{
  "id": "chatcmpl-8HzhFnTTKKfSf3RmSeiUGPFISK3c6",
  "object": "chat.completion",
  "created": 1699299429,
  "model": "gpt-3.5-turbo-0613",
  "choices": [
    {
      "index": 0,
      "message": {
        "role": "assistant",
        "content": "Canberra"
      },
      "finish_reason": "stop"
    }
  ],
  "usage": {
    "prompt_tokens": 19,
    "completion_tokens": 2,
    "total_tokens": 21
  }
}
  
```
