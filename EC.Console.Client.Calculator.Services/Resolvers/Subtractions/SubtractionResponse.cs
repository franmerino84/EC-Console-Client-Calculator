﻿using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Services.Resolvers.Subtractions
{
    public class SubtractionResponse
    {
        public SubtractionResponse(int difference)
        {
            Difference = difference;
        }

        public int Difference { get; }
    }
}
