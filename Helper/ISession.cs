using CheckBox.Web.Models;

namespace CheckBox.Web.Helper
{
    public interface ISession
    {
        void MakeSession(UserViewModel user);
        void RemoveSession();
        UserViewModel FindUserSession();
    }
}