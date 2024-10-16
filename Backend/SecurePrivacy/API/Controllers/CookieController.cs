using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/cookie")]
    public class CookieController : ControllerBase
    {
        [HttpPost("set-consent")]
        public IActionResult SetCookieConsent([FromBody] bool consent)
        {
            if (consent)
            {
                Response.Cookies.Append("CookieConsent", "true", new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1),
                    IsEssential = true
                });

                return Ok("Cookie consent granted.");
            }
            else
            {
                return BadRequest("Cookie consent not provided.");
            }
        }

        [HttpGet("check-consent")]
        public IActionResult CheckConsent()
        {
            var consent = Request.Cookies["CookieConsent"];
            if (consent == "true")
            {
                return Ok("Cookie consent has already been given.");
            }

            return Ok("Cookie consent not provided.");
        }

        [HttpPost("set-preference")]
        public IActionResult SetUserPreference(string preference)
        {
            var consent = Request.Cookies["CookieConsent"];
            if (consent == "true")
            {
                Response.Cookies.Append("UserPreference", preference, new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddMonths(1)
                });
                return Ok("User preference saved.");
            }

            return BadRequest("Cookie consent not provided.");
        }

        [HttpPost("revoke-consent")]
        public IActionResult RevokeCookieConsent()
        {
            Response.Cookies.Delete("CookieConsent");

            Response.Cookies.Delete("UserPreference");

            return Ok("Cookie consent revoked and cookies removed.");
        }
    }
}
