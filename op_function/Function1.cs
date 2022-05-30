using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace op_function
{
    public class Function1
    {
        private readonly ILogger _logger;
        op_function.Models.Options.AppSettings _options; 

        public Function1(ILoggerFactory loggerFactory, IOptions<op_function.Models.Options.AppSettings> options)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
            _options = options?.Value == null ? throw new Exception("configuration missing") : options.Value;
        }

        [Function("Function1")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Azure out-of-process function, DI + options pattern");

            _logger?.LogInformation("Azure out-of-process function");
            _logger?.LogInformation("DI + options pattern:");
            _logger?.LogInformation($"Setting1: {_options.Setting1}");
            _logger?.LogInformation($"Setting2: {_options.Setting2}");
            _logger?.LogInformation($"Setting3: {_options.Setting3}");
            _logger?.LogInformation($"Setting4: {_options.ArraySettings[0]?.Setting4}");
            _logger?.LogInformation($"Setting5: {_options.ArraySettings[1]?.Setting5}");

            return response;
        }
    }
}
