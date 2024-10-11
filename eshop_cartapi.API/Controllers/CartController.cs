using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eshop_cartapi.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class CartController : BaseApiController
    {
        private readonly IHtmlLocalizer<CartController> _localizer;
        public CartController(IHtmlLocalizer<CartController> localizer)
        {
            _localizer = localizer;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<object> GetAll()
        {
            int a = 1;
            return "";
        }

        [HttpGet]
        public async Task<object> Get(int id)
        {
            return "";
        }

        public void getData()
        { 

        }
    }
}