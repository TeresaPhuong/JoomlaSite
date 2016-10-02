using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoomlaSite.Common;

namespace JoomlaSite.Page_Objects
{
    class LoginPage:CommonAC
    {
        public void EnterIntoUsername(string username)
        {
            TypeText("username_tbx", username);
        }

        public void EnterIntoPassword(string password)
        {
            TypeText("password_tbx", password);
        }

        public HomePage ClickLoginButton()
        {
            ClickWebElement("login_btn");
            return new HomePage();
        }

        public HomePage Login(string username, string password)
        {
            EnterIntoUsername(username);
            EnterIntoPassword(password);
            ClickLoginButton();
            return new HomePage();
        }
    }
}
