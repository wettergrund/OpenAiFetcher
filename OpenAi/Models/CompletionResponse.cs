namespace OpenAi.Models
{
    /// <summary>
    /// Represents the response from OpenAI's API.
    /// </summary>
    public class GptResponse
    {
        /// <summary>
        /// Unique identifier for the response.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Type of the object in the response.
        /// </summary>
        public string Object { get; set; }

        /// <summary>
        /// Timestamp of when the response was created.
        /// </summary>
        public long Created { get; set; }

        /// <summary>
        /// The model that was used for generating the response.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// A list of choices returned by the OpenAI API.
        /// </summary>
        public List<Choice> Choices { get; set; }

        /// <summary>
        /// Information about the usage of tokens for the request.
        /// </summary>
        public Usage Usage { get; set; }
    }

    /// <summary>
    /// Represents a single choice in the list of possible completions.
    /// </summary>
    public class Choice
    {
        /// <summary>
        /// Index of the choice in the list.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// The message related to this choice.
        /// </summary>
        public Message Message { get; set; }

        /// <summary>
        /// The reason why the completion was finished.
        /// </summary>
        public string FinishReason { get; set; }
    }

    /// <summary>
    /// Contains the role and content of the message within a choice.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// The role associated with the message (e.g., 'user' or 'assistant').
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// The content of the message.
        /// </summary>
        public string Content { get; set; }
    }

    /// <summary>
    /// Details about the number of tokens used in the API request and response.
    /// </summary>
    public class Usage
    {
        /// <summary>
        /// Number of tokens used in the prompt.
        /// </summary>
        public int PromptTokens { get; set; }

        /// <summary>
        /// Number of tokens generated in the completion.
        /// </summary>
        public int CompletionTokens { get; set; }

        /// <summary>
        /// Total number of tokens used in the request.
        /// </summary>
        public int TotalTokens { get; set; }
    }
}
