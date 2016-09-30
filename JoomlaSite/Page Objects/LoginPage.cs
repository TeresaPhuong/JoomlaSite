using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoomlaSite.Page_Objects
{
    class LoginPage
    {
        public void EnterIntoUsername(string username)
        {
            WaitToPageLoad(Username_TBX);
            EnterText(Username_TBX, username);
        }

        public void EnterIntoPassword(string password)
        {
            EnterText(Password_TBX, password);
        }

        public HomePageAC ClickLoginBTN()
        {
            ClickElement(Login_BTN);
            return new HomePageAC();
        }

        public HomePageAC Login(string username, string password)
        {
            EnterIntoUsername(username);
            EnterIntoPassword(password);
            ClickLoginBTN();
            return new HomePageAC();
        }
    }
}
