using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace DoAnCB.Lib
{
    public class ErrorResponse : ObjectResponse
    {
        [BindNever]
        [JsonIgnore]
        public Dictionary<string, string[]> MessageParams { get; set; } = new Dictionary<string, string[]>();

        public ErrorResponse()
        {

        }

        public ErrorResponse(int statusCode, IEnumerable<IdentityError> identityErrors)
        {
            this.StatusCode = statusCode;
            Message = string.Empty;
            Fields = new List<ModelError>();
            foreach (IdentityError identityError in identityErrors)
            {
                string name = identityError.Code;
                if (name.Contains("UserName"))
                {
                    name = "UserName";
                }
                else if (name.Contains("Email"))
                {
                    name = "Email";
                }
                if (string.IsNullOrEmpty(Message))
                {
                    Message = identityError.Code;
                }
                Details.Add(identityError.Code);
                if (name != null)
                {
                    var field = Fields.Find(p => p.Name == name);
                    string message = identityError.Code;
                    if (field == null)
                    {
                        field = new ModelError(name);
                        Fields.Add(field);
                    }
                    field.Details.Add(message);
                    AddMessageParams(message, field.Name);
                }
                else
                {
                    var field = Fields.Find(p => p.Name == identityError.Code);
                    if (field == null)
                    {
                        field = new ModelError(identityError.Code);
                        Fields.Add(field);
                    }
                    field.Details.Add(identityError.Description);
                }
            }
        }

        public ErrorResponse(int statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            //Details.Add(message);
        }

        public ErrorResponse(int statusCode, string message, params string[] messageParams)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            AddMessageParams(null, message, messageParams);
        }

        public ErrorResponse(int statusCode, List<string> messages)
        {
            this.StatusCode = statusCode;
            Message = "There are errors, see details for more info.";
            Details = messages;
        }

        public ErrorResponse(int statusCode, string message, List<string> messages)
        {
            this.StatusCode = statusCode;
            Message = message;
            Details = messages;
        }

        public ErrorResponse(int statusCode, ModelStateDictionary modelState)
        {
            this.StatusCode = statusCode;
            Message = "Invalid data.";

            var errors = modelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
            Details.AddRange(errors);

            Fields = new List<ErrorResponse.ModelError>();
            var erroneousFields = modelState.Where(ms => ms.Value.Errors.Any())
                                            .Select(x => new { x.Key, x.Value.Errors });

            foreach (var erroneousField in erroneousFields)
            {
                var fieldKey = erroneousField.Key;
                var fieldErrors = erroneousField.Errors
                    .Select(error => _CreateModelError(fieldKey, error.ErrorMessage));
                Fields.AddRange(fieldErrors);
            }
        }

        public ErrorResponse AddDetails(params string[] details)
        {
            this.Details = details.ToList();
            return this;
        }

        public ErrorResponse AddMessageParams(string fieldName, string message, params string[] messageParams)
        {
            string pkey = fieldName == null ? message : fieldName + "_" + message;
            if (!MessageParams.ContainsKey(pkey))
            {
                MessageParams.Add(pkey, messageParams);
            }
            else
            {
                var oldparams = MessageParams[pkey];
                MessageParams[pkey] = oldparams.Concat(messageParams).ToArray();
            }

            return this;
        }

        private ErrorResponse.ModelError _CreateModelError(string field, string message)
        {
            var part = field.Split('.');
            AddMessageParams(field, message, part[part.Length - 1]);
            return new ErrorResponse.ModelError(field, message);
        }

        public ErrorResponse AddModelError(string field, string message)
        {
            if (Fields == null)
            {
                Fields = new List<ErrorResponse.ModelError>();
            }
            AddMessageParams(field, message, field);
            Fields.Add(new ErrorResponse.ModelError(field, message));
            return this;
        }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("details")]
        public List<string> Details { get; set; } = new List<string>();

        [JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore)]
        public List<ModelError> Fields { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public class ModelError
        {
            public string Name { get; set; }
            public List<string> Details { get; set; }

            public ModelError()
            {

            }

            public ModelError(string name)
            {
                Name = name;
                Details = new List<string>();
            }

            public ModelError(string name, string message)
            {
                Name = name;
                Details = new List<string>();
                Details.Add(message);
            }
        }
    }
}
