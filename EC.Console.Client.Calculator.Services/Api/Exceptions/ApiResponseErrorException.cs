﻿using EC.Console.Client.Calculator.Services.Api;
using System.Runtime.Serialization;
using EC.Console.Client.Calculator.Services.Exceptions;
using EC.Console.Client.Calculator.Services.Api.Dtos;

namespace EC.Console.Client.Calculator.Services.Resolvers
{
    [Serializable]
    public class ApiResponseErrorException : ApplicationNumberedErrorException
    {
        private const int _errorNumber = 15;
        private static string DefaultErrorMessage(ApplicationErrorBodyDto applicationErrorBody) => $"ERROR CCC015: There were problems during the request to the api: " +
            $"({applicationErrorBody.HttpStatusCode}) ({applicationErrorBody.ErrorCode}) {applicationErrorBody.Message}";
        public ApplicationErrorBodyDto ApplicationErrorBody { get; set; }

        public ApiResponseErrorException(ApplicationErrorBodyDto applicationErrorBody) : base(_errorNumber, DefaultErrorMessage(applicationErrorBody))
        {
            ApplicationErrorBody = applicationErrorBody;
        }

        public ApiResponseErrorException(ApplicationErrorBodyDto applicationErrorBody, string? message) : base(_errorNumber, message)
        {
            ApplicationErrorBody = applicationErrorBody;
        }

        public ApiResponseErrorException(ApplicationErrorBodyDto applicationErrorBody, string? message, Exception? innerException) : base(_errorNumber, message, innerException)
        {
            ApplicationErrorBody = applicationErrorBody;
        }

        protected ApiResponseErrorException(ApplicationErrorBodyDto applicationErrorBody, SerializationInfo info, StreamingContext context) : base(_errorNumber, info, context)
        {
            ApplicationErrorBody = applicationErrorBody;
        }
    }
}