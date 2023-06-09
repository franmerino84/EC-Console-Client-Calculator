﻿using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Services.Resolvers.Journals.Dtos
{
    public class JournalQueryOperationDto
    {
        public JournalQueryOperationDto(string operation, string calculation, DateTime date)
        {
            Operation = operation;
            Calculation = calculation;
            Date = date;
        }

        [JsonPropertyName("operation")]
        public string Operation { get; }

        [JsonPropertyName("calculation")]
        public string Calculation { get; }

        [JsonPropertyName("date")]
        public DateTime Date { get; }
    }
}