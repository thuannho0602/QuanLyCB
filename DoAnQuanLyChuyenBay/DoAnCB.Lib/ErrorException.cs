using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnCB.Lib
{
    public class ErrorException : Exception
    {
        ErrorResponse _errorResponse;

        public ErrorResponse Response
        {
            get
            {
                return _errorResponse;
            }
        }

        public ErrorException(ErrorResponse errorResponse)
        {
            _errorResponse = errorResponse;
        }

        public ErrorException(int statusCode, String details)
        {
            _errorResponse = new ErrorResponse(statusCode, details);
        }

        public ErrorException(int statusCode, String message, List<String> details)
        {
            _errorResponse = new ErrorResponse(statusCode, message, details);
        }

        public ErrorException(int statusCode, string message, params string[] messageParams)
        {
            _errorResponse = new ErrorResponse(statusCode, message, messageParams);
        }

        public ErrorException(int statusCode, IEnumerable<IdentityError> details)
        {
            _errorResponse = new ErrorResponse(statusCode, details);
        }

        public ErrorException(int statusCode, ModelStateDictionary modelState)
        {
            _errorResponse = new ErrorResponse(statusCode, modelState);
        }
    }
}
