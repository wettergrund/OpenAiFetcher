﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAi.Models
{
    /// <summary>
    /// Select different GPT versions
    /// </summary>
    public static class GptModels
    {
        /// <summary>
        /// gpt-3.5-turbo
        /// </summary>
        public static string Gpt35T { get; } = "gpt-3.5-turbo-1106";
        /// <summary>
        /// gpt-4
        /// </summary>
        public static string Gpt4 { get; } = "gpt-4";
        /// <summary>
        /// gpt-4-1106-preview, support json mode
        /// </summary>
        public static string Gpt4T { get; } = "gpt-4-1106-preview";

        /// <summary>
        /// Set a cusytom gpt model 
        /// </summary>
        public static string Custom { get; set; }



    }
}
