namespace Hospitality.Web.Controllers
{
    public class SignInController : Controller
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public SignInController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }
        private async Task<IActionResult> GetContentAsync(object newCheckup, string url)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var response = await _httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newCheckup), Encoding.UTF8, "application/json"));
            if (!response.IsSuccessStatusCode || response is null) return StatusCode(404);
            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult SignIn(bool? result)
        {
            if (result == false)
                ViewBag.Show = "show";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(Credentials credentials)
        {
            ViewBag.Show = "show";

            var response = await _httpClient.PostAsync(_configuration["Paths:SignIn"], new StringContent(
                JsonConvert.SerializeObject(credentials), Encoding.UTF8, "application/json"));
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return RedirectToAction("SignIn", "SignIn", new { result = false });
            if (response.IsSuccessStatusCode && response.Content is not null)
            {
                HttpContext.Session.Clear();
                HttpContext.Session.SetString("token", await response.Content.ReadAsStringAsync());
                return RedirectToAction("Index", "Home", null);
            } 
            else
                return RedirectToAction("Index", "Home", null);
        }
    }
}