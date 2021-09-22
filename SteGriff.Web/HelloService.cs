using System.Globalization;

namespace SteGriff.Web
{
    public class HelloService : IHelloService
    {
        private Dictionary<string, string> _resources = new Dictionary<string, string>()
        {
            { "en", "hello" },
            { "fr", "bonjour" },
            { "de", "hallo" },
            { "es", "buen dia" }
        };

        public string GetHello(HttpContext context)
        {
            string locale = context.Request.Query["lang"].ToString();
            if (string.IsNullOrEmpty(locale)) locale = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            return _resources[locale];
        }
    }
}
