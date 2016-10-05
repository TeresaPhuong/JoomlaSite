using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoomlaSite.Common_Action;

namespace JoomlaSite.Page_Objects
{
    class LoginPage:Common
    {
        public void EnterIntoUsername()
        {
            string username = GetData("username");
            TypeText("username_tbx", username);
        }

        public void EnterIntoPassword()
        {
            string password = GetData("password");
            TypeText("password_tbx", password);
        }

        public HomePage ClickLoginButton()
        {
            ClickWebElement("login_btn");
            return new HomePage();
        }

        public HomePage Login()
        {
            EnterIntoUsername();
            EnterIntoPassword();
            ClickLoginButton();
            return new HomePage();
        }
        public void LoginSuccess()
        {
            EnterIntoUsername();
            EnterIntoPassword();
            ClickLoginButton();
        }
    }
}
