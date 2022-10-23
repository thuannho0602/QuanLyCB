using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnCB.Lib
{
    public class GenericResponse : IResponse
    {
        public static GenericResponse NoContent { get; } = new GenericResponse { StatusCode = StatusCodes.Status204NoContent };
        public static GenericResponse Created { get; } = new GenericResponse { StatusCode = StatusCodes.Status201Created };
        public static ErrorResponse NotFound { get; } = new ErrorResponse
        {
            StatusCode = StatusCodes.Status404NotFound,
            Details = new List<string>(new string[] { "notFound" })
        };

        public int StatusCode { get; set; }
    }
}
