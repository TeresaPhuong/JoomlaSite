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
        [Given(@"I navigate to Joomlasite")]
        public void NavigateTo()
        {
            string url = GetData("url");
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
        }
        [When(@"I enter username")]
        public void EnterUsername()
        {
            EnterIntoUsername();
        }
        [When(@"I enter password")]
        public void EnterPassword()
        {
            EnterIntoPassword();
        }
        [When(@"I click Login button")]
        public void ClickLogin()
        {
            ClickLoginButton();
        }
    }

}
