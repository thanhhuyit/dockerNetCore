using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace AkApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferOrderController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<TransferOrderController> _logger;
        private readonly GkPosSettings _options;
        public TransferOrderController(IOptions<GkPosSettings> options, ILogger<TransferOrderController> logger)
        {
            _logger = logger;
            _options = options.Value;
        }

        [HttpGet(Name = "Transfer")]
        public async Task<IList<OrderViewModel>> Transfer()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync($"{_options.ShopApiUrl}?shopid={_options.ShopId}").Result;

            string responseBody = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<IList<OrderViewModel>>(responseBody);

            return data;
        }
    }
}