using Microsoft.AspNetCore.Mvc;
using NLog;

namespace eshop_cartapi.API.Controllers
{
    public class BaseApiController : Controller
    {
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    }
}