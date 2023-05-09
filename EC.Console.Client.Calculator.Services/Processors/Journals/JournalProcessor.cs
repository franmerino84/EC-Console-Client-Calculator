﻿using EC.Console.Client.Calculator.Services.Processors.Journals.Dtos;
using EC.Console.Client.Calculator.Services.Processors.Journals.Exceptions;

namespace EC.Console.Client.Calculator.Services.Processors.Journals
{
    public class JournalProcessor : IOperationProcessor
    {
        private readonly ICalculatorApiManager _calculatorApiManager;

        public JournalProcessor(ICalculatorApiManager calculatorApiManager)
        {
            _calculatorApiManager = calculatorApiManager;
        }
        public async Task Process(IEnumerable<string> arguments, string? trackingId)
        {
            var requestDto = GetJournalRequestDto(arguments);

            var responseDto = await _calculatorApiManager.PostAsync<JournalRequestDto, JournalResponseDto>("journal/query", requestDto);

            foreach(var operation in responseDto.Operations)
            {
                System.Console.WriteLine($"{operation.Date} ({operation.Operation}): {operation.Calculation}");
            }
            
        }

        private static JournalRequestDto GetJournalRequestDto(IEnumerable<string> arguments)
        {
            if (arguments.Count() != 1)
                throw new JournalRequiresOneArgumentException();

            return new JournalRequestDto(arguments.First());
        }
    }
}