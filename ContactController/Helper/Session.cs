using ContactController.Models;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using System.Globalization;

namespace ContactController.Helper
{
    public class Session : ISession
    {
        private readonly IHttpContextAccessor _httpContext;

        public Session(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor;
        }
        public void CreateUserSession(UserModel user)
        {
            string value = JsonConvert.SerializeObject(user);

            _httpContext.HttpContext.Session.SetString("SessionUserloggin", value);
        }

        public UserModel GetUserSession()
        {
            string sessionUser = _httpContext.HttpContext.Session.GetString("SessionUserloggin");

            if (string.IsNullOrEmpty(sessionUser)) return null;

            return JsonConvert.DeserializeObject<UserModel>(sessionUser);
        }

        public void RemoveUserSession()
        {
            _httpContext.HttpContext.Session.Remove("SessionUserloggin");
        }
    }
}
