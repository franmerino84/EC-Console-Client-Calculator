﻿using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Presentation.Processors.Journals
{
    public class JournalResponseDto
    {
        public JournalResponseDto(IEnumerable<JournalQueryOperation> operations)
        {
            Operations = operations;
        }

        [JsonPropertyName("operations")]
        public IEnumerable<JournalQueryOperation> Operations { get; }
    }
}
