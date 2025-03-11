using Microsoft.AspNetCore.Mvc;
using WalkSafe.Core.Entities.RouteAggregate;

namespace WalkSafeApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouteController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public RouteController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpPost("generate")]
        public async Task<IActionResult> GenerateRoute([FromBody] RouteRequest request)
        {
            // Call the Python API
            var pythonApiUrl = "http://127.0.0.1:8000/route";

            try
            {
                var response = await _httpClient.PostAsJsonAsync(pythonApiUrl, request);

                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
                }

                var route = await response.Content.ReadFromJsonAsync<RouteResponse>();
                return Ok(route);
            }
            catch (HttpRequestException e)
            {
                return StatusCode(500, $"Error communicating with Python service: {e.Message}");
            }
        }
    }
}
