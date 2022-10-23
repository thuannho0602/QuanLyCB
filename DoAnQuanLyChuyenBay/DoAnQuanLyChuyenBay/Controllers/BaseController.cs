using DoAnCB.Lib;
using DoAnCB.Model;
using DoAnCB.Model.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCB.API.Controllers
{
    public class BaseController : Controller
    {
        //protected IScopedCache _scopedCache;

        protected IActionResult ThrowModelErrorsException()
        {
            throw new ErrorException(StatusCodes.Status400BadRequest, ModelState);
        }

        protected IActionResult GetResponse(int statusCode)
        {
            return _GetResponse(statusCode, null);
        }

        protected IActionResult GetResponse(IResponse res)
        {
            if (res == null)
            {
                return NotFound(GenericResponse.NotFound);
            }
            return _GetResponse(res.StatusCode, res);
        }

        protected IActionResult GetResponse(int code, object res)
        {
            return StatusCode(code, res);
        }

        private IActionResult _GetResponse(int statusCode, object res)
        {
            if (statusCode == StatusCodes.Status200OK)
            {
                return Ok(res);
            }
            else if (statusCode == StatusCodes.Status201Created)
            {
                return Created(string.Empty, res);
            }
            else if (statusCode == StatusCodes.Status204NoContent)
            {
                return NoContent();
            }
            else if (statusCode == StatusCodes.Status404NotFound)
            {
                return NotFound(res);
            }
            else if (statusCode == StatusCodes.Status400BadRequest)
            {
                return BadRequest(res);
            }
            else if (statusCode == StatusCodes.Status401Unauthorized)
            {
                return Unauthorized();
            }
            else if (statusCode == StatusCodes.Status409Conflict)
            {
                return Conflict(res);
            }

            return Forbid();
        }

        protected IActionResult GetResponse<T>(List<T> res) where T : IResponse
        {
            if (res == null)
            {
                return NotFound(GenericResponse.NotFound);
            }
            return Ok(res);
        }

        protected IActionResult GetResponse<T>(int code, List<T> res) where T : IResponse
        {
            return StatusCode(code, res);
        }

        /// <summary>
        /// Steven Check export order common
        /// </summary>
        /// <param name="context"></param>
        ///
        protected IActionResult GetResponseIfNull<T>(int code, List<T> res) where T : IResponse
        {
            if (res is null)
            {
                res = new List<T>();
            }
            return StatusCode(code, res);
        }

        /// <summary>
        /// Steven Check export order common
        /// </summary>
        /// <param name="context"></param>
        ///
        protected IActionResult GetResponseIfNull(int code, object res)
        {
            if (res is null)
            {
                res = new object();
            }
            return StatusCode(code, res);
        }

        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    base.OnActionExecuting(context);
        //    _scopedCache.ScopedContext = new ScopedContext();
        //    _scopedCache.ScopedContext.SetRequestContext(Request, Response);
        //    if (context.ActionArguments.ContainsKey("data"))
        //    {
        //        var model = context.ActionArguments["data"] as IRequest;
        //        if (model != null)
        //        {
        //            model.ScopedContext = _scopedCache.ScopedContext;
        //        }
        //    }
        //}

        protected string GetCurrentUserId()
        {
            if (User != null)
            {
                return User.FindFirst(JwtRegisteredClaimNames.NameId).Value;
            }

            return string.Empty;
        }
        protected IActionResult InvalidModel()
        {
            return base.Ok(new BaseResponseModel
            {
                Code = ErrorCodes.InvalidModel,
                Message = string.Join(", ", ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage)))
            });
        }
        protected IActionResult Failure(string message)
        {
            return Ok(new BaseResponseModel
            {
                Code = ErrorCodes.BadRequest,
                Message = message
            });
        }
        protected IActionResult Success<T>(T data) where T : class
        {
            return Ok(new BaseResponseModel<T>
            {
                Code = ErrorCodes.Success,
                Message = ErrorCodes.Success.ToDescription(),
                Data = data
            });
        }
    }
}
