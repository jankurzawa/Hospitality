namespace Hospitality.Web.Controllers
{
    public class SignOutController : Controller
    {
        [HttpGet]
        public IActionResult SignOut()
        {
            HttpContext.Session.Remove("token");
            return RedirectToAction("SignIn", "SignIn", null);
        }
    }
}
