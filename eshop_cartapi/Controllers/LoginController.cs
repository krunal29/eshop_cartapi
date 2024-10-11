using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using eshop_cartapi.Business.Helpers;
using eshop_cartapi.Business.ViewModels;
using eshop_cartapi.Domain.Models;
using eshop_cartapi.Helpers;
using System.Threading.Tasks;

namespace eshop_cartapi.Controllers
{
    public class LoginController : BaseController
    {
        private new readonly SignInManager<ApplicationUser> _signInManager;

        public LoginController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index(string redirectUrl = "")
        {
            ViewBag.redirectUrl = redirectUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(PersonModel personModel, string redirectUrl = null)
        {
            var result = await DoActionForPost<LoginResponseModel>(personModel, "Person/Login");
            if (!string.IsNullOrEmpty(result.Data.Token))
            {
                await _signInManager.SignInAsync(result.Data.ApplicationUser, isPersistent: true);
                MemoryCacheHelper.memoryCache.Set(Constant.Memory_UserRoles, result.Data.roleModuleModel);
                SessionHelper.Set(HttpContext, Constant.AppicationUserData, result.Data);
                if (Request.HttpContext.IsUserLogin())
                {
                    if (!string.IsNullOrEmpty(redirectUrl))
                    {
                        return PostCompleteRedirect(redirectUrl);
                    }
                }
                return PostCompleteRedirect(Url.Action("Index", "Person"));
            }
            return PostFailed();
        }

        [HttpPost]
        public async Task<PostJsonResult> Logout()
        {
            await _signInManager.SignOutAsync();
            var sessionClear = SessionHelper.Remove(HttpContext);
            if (!sessionClear)
            {
                return PostFailed();
            }
            return PostCompleteRedirect(Url.Action("Index", "Login"));
        }
    }
}