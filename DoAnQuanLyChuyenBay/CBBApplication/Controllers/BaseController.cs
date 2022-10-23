using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CBBApplication.Controllers
{
    public class BaseController:Controller
    {
        private readonly HttpClient client;
        private static string ApiUrl;
        public IConfiguration Configuration { get; }

        public BaseController()
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .AddEnvironmentVariables();

            Configuration = builder.Build();
            ApiUrl = Configuration["ApiUrl"];
            client = new HttpClient
            {
                BaseAddress = new Uri($"{ApiUrl}")
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<dynamic> GetRequest(string uri)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("UserToken"));
            var response = await client.GetAsync($"{uri}");
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                HttpContext.Session.Remove("UserToken");
                RedirectToAction("Login", "Account");
            }

            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<dynamic>(result);

            return data;
        }

        public async Task<dynamic> GetRequest(string uri, string jwt)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            var response = await client.GetAsync($"{uri}");
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                HttpContext.Session.Remove("UserToken");
                RedirectToAction("Login", "Account");
            }

            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<dynamic>(result);

            return data;
        }

        public async Task<dynamic> PostRequest(string uri, dynamic model)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("UserToken"));
            var json = JsonConvert.SerializeObject(model);
            var payload = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{uri}", payload);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                HttpContext.Session.Remove("UserToken");
                RedirectToAction("Login", "Account");
            }

            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<dynamic>(result);

            return data;
        }

        public async Task<dynamic> PutRequest(string uri, dynamic model)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("UserToken"));
            var json = JsonConvert.SerializeObject(model);
            var payload = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{uri}", payload);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                HttpContext.Session.Remove("UserToken");
                RedirectToAction("Login", "Account");
            }

            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<dynamic>(result);

            return data;
        }

        public async Task<dynamic> DeleteRequest(string uri)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("UserToken"));
            var response = await client.DeleteAsync($"{uri}");
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                HttpContext.Session.Remove("UserToken");
                RedirectToAction("Login", "Account");
            }

            var result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<dynamic>(result);

            return data;
        }
        public string FullName()
        {
            string token = HttpContext.Session.GetString("UserToken");
            if (!string.IsNullOrEmpty(token))
            {
                var jwttoken = new JwtSecurityTokenHandler().ReadJwtToken(token);

                var FirstName = jwttoken.Claims.First(claim => claim.Type == "given_name").Value;
                var LastName = jwttoken.Claims.First(claim => claim.Type == "family_name").Value;
                return FirstName + " " + LastName;
            }
            return "";
        }
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserToken")) && HttpContext.Request.Path != "/Account/Login")
        //    {
        //        filterContext.Result = RedirectToAction("Login", "Account");
        //    }
        //    else
        //    {
        //        InitData();
        //    }
        //}

        //public void InitData()
        //{
        //    try
        //    {
        //        //RedirectToAction("Login", "Account");
        //        ViewBag.Dashboards = GetRequest("Dashboard?includeShareable=true").Result;
        //    }
        //    catch (Exception)
        //    {
        //        RedirectToAction("Login", "Account");
        //    }

        //}
    }
}
