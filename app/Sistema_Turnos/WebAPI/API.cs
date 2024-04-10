using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Sistema_Turnos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Sistema_Turnos.WebAPI
{
    public class API
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContext;
        private readonly AppSettings _appSettings;
        public API(IHttpContextAccessor httpContext, IOptions<AppSettings> appSettings)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            _client = new HttpClient(httpClientHandler);
            _httpContext = httpContext;
            _appSettings = appSettings.Value;
            _client.BaseAddress = new Uri(_appSettings.BaseAddress);
            _client.Timeout = TimeSpan.FromSeconds(10);
        }

        public async Task<ApiResult<B>> Get<A, B>(Action<ApiCallConfiguration<A>> action, string token = null)
        {
            var config = new ApiCallConfiguration<A>();
            var result = new ApiResult<B>();
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                action(config);
                var response = await _client.GetAsync(config.PathWithQueryStrings);
                var content = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ApiResult<B>>(content);
                if (result != null)
                {
                    result.Path = config.Path;
                    result.StatusCode = response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;

                result.Message = Helpers.GetMessage(ex);
            }
            return result;
        }

        public async Task<ApiResult<List<B>>> Details<A, B>(Action<ApiCallConfiguration<A>> action, string token = null)
        {
            var config = new ApiCallConfiguration<A>();
            var result = new ApiResult<List<B>>();
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                action(config);
                var requestUrl = new Uri(_client.BaseAddress, config.PathWithQueryStrings);

                // Especificar el tipo de medio esperado
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _client.GetAsync(requestUrl);
                var content = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ApiResult<List<B>>>(content);
                if (result != null)
                {
                    result.Path = config.Path;
                    result.StatusCode = response.StatusCode;
                    result.Type = ApiResultType.Success;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = Helpers.GetMessage(ex);
            }
            return result;
        }

        public async Task<ApiResult<B>> Post<A, B>(Action<ApiCallConfiguration<A>> action, string token = null)
        {
            var config = new ApiCallConfiguration<A>();
            var result = new ApiResult<B>();
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                action(config);
                var requestUrl = new Uri(_client.BaseAddress, config.PathWithQueryStrings);
                var responseData = await _client.PostAsync(requestUrl, config.ContentJson);
                var content = await responseData.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ApiResult<B>>(content);
                result.Path = config.Path;
                //result.StatusCode = responseData.StatusCode;

                //if (responseData.StatusCode == HttpStatusCode.OK)
                //    result.Success = true;
                //else
                //    result.Success = false;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = Helpers.GetMessage(ex);
            }
            return result;
        }

        public async Task<ApiResult<B>> Delete<A, B>(Action<ApiCallConfiguration<A>> action, string token = null)
        {
            var config = new ApiCallConfiguration<A>();
            var result = new ApiResult<B>();
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                action(config);
                var requestUrl = new Uri(_client.BaseAddress, config.PathWithQueryStrings);

                var response = await _client.DeleteAsync(requestUrl);
                var content = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ApiResult<B>>(content);
                result.Path = config.Path;
                result.StatusCode = response.StatusCode;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = Helpers.GetMessage(ex);
            }

            return result;
        }

        public async Task<ApiResult<B>> Put<A, B>(Action<ApiCallConfiguration<A>> action, string token = null)
        {
            var config = new ApiCallConfiguration<A>();
            var result = new ApiResult<B>();
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                action(config);
                var requestUrl = new Uri(_client.BaseAddress, config.PathWithQueryStrings);
                var response = await _client.PutAsync(requestUrl, config.ContentJson);
                var content = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ApiResult<B>>(content);
                result.Path = config.Path;
                result.StatusCode = response.StatusCode;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = Helpers.GetMessage(ex);
            }

            return result;
        }
    }
}
