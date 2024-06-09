using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json.Nodes;

namespace PEPRN231_SU24TrialTest_StudentCode_FE.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string MessageError { get; set; }
        [BindProperty]
        public string UserEmail { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var response = await Common.SendRequestWithBody(
                new
                {
                    UserEmail = UserEmail,
                    Password = Password
                }, "Account/Login");

            if (response.IsSuccessStatusCode)
            {
                var accessToken = JsonNode.Parse(await response.Content.ReadAsStringAsync());
                HttpContext.Session.SetString("accessToken", accessToken.ToString());

                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(accessToken.ToString());
                var tokenS = jsonToken as JwtSecurityToken;
                var role = tokenS.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
                if (role != null)
                {
                    HttpContext.Session.SetString("Role", role);
                    return RedirectToPage("/WaterPainting/Index");
                }
            }

            this.MessageError = "User email or password not correct";
            return Page();
        }
    }
}
