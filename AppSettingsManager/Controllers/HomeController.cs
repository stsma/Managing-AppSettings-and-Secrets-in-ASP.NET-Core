using System.Diagnostics;
using AppSettingsManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppSettingsManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly TwilioSetting _twilioSetting;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _twilioSetting = new TwilioSetting();
            _configuration.Bind("Twilio", _twilioSetting);
        }

        public IActionResult Index()
        {
            ViewBag.SendGridKey = _configuration.GetValue<string>("SendGridKey");
            ViewBag.TwilioAccountSID = _twilioSetting.AccountSID; // _configuration.GetValue<string>("Twilio:AccountSID");
            ViewBag.TwilioAuthToken = _configuration.GetValue<string>("Twilio:AuthToken");
            ViewBag.TwilioAccountUsername = _configuration.GetValue<string>("Twilio:Account:Username");
            ViewBag.TwilioAccountPassword = _configuration.GetValue<string>("Twilio:Account:Password");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
