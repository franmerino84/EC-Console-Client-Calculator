﻿using EC.Console.Client.Calculator.Services.Processors.Divisions.Dtos;
using EC.Console.Client.Calculator.Services.Processors.Divisions.Exceptions;

namespace EC.Console.Client.Calculator.Services.Processors.Divisions
{
    public class DivisionProcessor : IOperationProcessor
    {
        private readonly ICalculatorApiManager _calculatorApiManager;

        public DivisionProcessor(ICalculatorApiManager calculatorApiManager)
        {
            _calculatorApiManager = calculatorApiManager;
        }
        public async Task Process(IEnumerable<string> arguments, string? trackingId)
        {
            var requestDto = GetDivisionRequestDto(arguments.ToArray());

            var responseDto = await _calculatorApiManager.PostAsync<DivisionRequestDto, DivisionResponseDto>("calculator/div", requestDto, trackingId);

            System.Console.WriteLine($"Quotient: {responseDto.Quotient}. Remainder: {responseDto.Remainder}");
        }

        private static DivisionRequestDto GetDivisionRequestDto(IList<string> arguments)
        {
            if (arguments.Count != 2)
                throw new DivisionRequiresTwoArgumentsException();

            try
            {
                return new DivisionRequestDto(int.Parse(arguments[0]), int.Parse(arguments[1]));
            }
            catch (Exception ex) 
            {
                throw new DivisionRequiresIntegerArgumentsException(ex);
            }
        }
    }
}