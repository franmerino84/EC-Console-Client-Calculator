﻿namespace EC.Console.Client.Calculator.Presentation.Processors.Journals
{
    public class JournalRequestDto
    {
        public JournalRequestDto(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}