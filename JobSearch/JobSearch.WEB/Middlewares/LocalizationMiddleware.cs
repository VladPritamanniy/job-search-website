using System.Globalization;

namespace JobSearch.WEB.Middlewares
{
    public class LocalizationMiddleware
    {
        private readonly RequestDelegate _next;

        public LocalizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Session != null)
            {
                CultureInfo ci = new CultureInfo("uk");
                if (context.Session.GetString("Culture") == null)
                {
                    string langName = "uk";
                    ci = new CultureInfo(langName);
                    context.Session.Set("Culture", System.Text.Encoding.Default.GetBytes(ci.ToString()));
                }
                else
                {
                    ci = new CultureInfo(context.Session.GetString("Culture"));
                }

                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
            }

            await _next(context);
        }
    }
}
