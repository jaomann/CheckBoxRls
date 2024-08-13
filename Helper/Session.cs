using CheckBox.Core.Contracts.entities;
using CheckBox.Web.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CheckBox.Web.Helper
{
    public class Session : ISession
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public Session(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public UserViewModel FindUserSession()
        {
            string sessionUser = _contextAccessor.HttpContext.Session.GetString("SessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessionUser))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<UserViewModel>(sessionUser);
        }

        public void MakeSession(UserViewModel user)
        {
            string valor = JsonConvert.SerializeObject(user);
            _contextAccessor.HttpContext.Session.SetString("SessaoUsuarioLogado", valor);
        }

        public void RemoveSession()
        {
            _contextAccessor.HttpContext.Session.Remove("SessaoUsuarioLogado");
        }
    }
}
