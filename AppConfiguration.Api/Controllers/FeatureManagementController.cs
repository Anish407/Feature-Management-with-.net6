using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using System.Text.Json.Serialization;

namespace AppConfiguration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureManagementController : ControllerBase
    {
        private readonly IFeatureManager featureManager;

        public FeatureManagementController(IFeatureManager featureManager)
        {
            this.featureManager = featureManager;
        }

        [HttpGet]
        public async Task<WeatherForecast> Get()
        {
            var isRainFeatureEnabled = await featureManager.IsEnabledAsync("RainEnabled");


            return new WeatherForecast
            {
                Date= DateTime.UtcNow.Date,
                Summary="Todays weather",
                TemperatureC= 10,
                // check program.cs, we remove this property from the response if the 
                // value is null (op.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;)
                Rain = isRainFeatureEnabled ? "10 degree": null
            };
        }

        [HttpGet("FeatureGateEnabled")]
        [FeatureGate("FeatureGateEnabled")]
        public async Task<WeatherForecast> FeatureGateEnabled()
        {
            var isRainFeatureEnabled = await featureManager.IsEnabledAsync("RainEnabled");


            return new WeatherForecast
            {
                Date = DateTime.UtcNow.Date,
                Summary = "Todays weather",
                TemperatureC = 10,
                // check program.cs, we remove this property from the response if the 
                // value is null (op.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;)
                Rain = isRainFeatureEnabled ? "10 degree" : null
            };
        }

        [HttpGet("CustomFilters")]
        [FeatureGate("FeatureGateEnabled")]
        public async Task<string> CustomFilters()
        {
            var isRainFeatureEnabled = await featureManager.IsEnabledAsync("CustomFilters");

            return isRainFeatureEnabled ? "new" : "old";
        }
    }
}
