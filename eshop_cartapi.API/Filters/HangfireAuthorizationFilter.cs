using Hangfire.Dashboard;

namespace eshop_cartapi.API.Filters
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            return false;
        }
    }
}