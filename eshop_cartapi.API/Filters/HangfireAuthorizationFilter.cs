using Hangfire.Dashboard;
using eshop_cartapi.Business.Helpers;

namespace eshop_cartapi.API.Filters
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            return new AppSettings().EnableHangfire;
        }
    }
}