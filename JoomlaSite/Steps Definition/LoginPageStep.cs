using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using JoomlaSite.Page_Objects;

namespace JoomlaSite.Steps_Definition
{
    [Binding]
    class LoginPageStep:LoginPage
    {
        [When(@"I enter username (.*)")]
        public void EnterUsername(string username)
        {
            EnterIntoUsername(username);
        }
        [When(@"I enter password (.*)")]
        public void EnterPassword(string password)
        {
            EnterIntoPassword(password);
        }
        [When(@"I click Login button")]
        public void ClickLogin()
        {
            ClickLoginButton();
        }
    }
}
