using Microsoft.AspNetCore.Mvc;

namespace ChallengeApi.Controllers
{
    public class ChallengeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
