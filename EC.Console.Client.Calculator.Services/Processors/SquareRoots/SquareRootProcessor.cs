﻿using EC.Console.Client.Calculator.Services.Processors.SquareRoots.Dtos;
using EC.Console.Client.Calculator.Services.Processors.SquareRoots.Exceptions;

namespace EC.Console.Client.Calculator.Services.Processors.SquareRoots
{
    public class SquareRootProcessor : IOperationProcessor
    {
        private readonly ICalculatorApiManager _calculatorApiManager;

        public SquareRootProcessor(ICalculatorApiManager calculatorApiManager)
        {
            _calculatorApiManager = calculatorApiManager;
        }
        public async Task Process(IEnumerable<string> arguments, string? trackingId)
        {
            var requestDto = GetSquareRootRequestDto(arguments);

            var responseDto = await _calculatorApiManager.PostAsync<SquareRootRequestDto, SquareRootResponseDto>("calculator/sqrt", requestDto, trackingId);

            System.Console.WriteLine(responseDto.Square);
        }

        private static SquareRootRequestDto GetSquareRootRequestDto(IEnumerable<string> arguments)
        {
            if (arguments.Count() != 1)
                throw new SquareRootRequiresOneArgumentException();
            try
            {
                return new SquareRootRequestDto(int.Parse(arguments.First()));
            }
            catch (Exception ex)
            {
                throw new SquareRootRequiresIntegerArgumentsException(ex);
            }
        }
    }
}