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
    class LoginPage: Page_Objects.LoginPage
    {
        [Given(@"I navigate to Joomlasite")]
        public void NavigateTo()
        {
            string url = GetData("url");
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
        }
        [Given(@"I login with valid username and password")]
        public void ILoginSuccess()
        {
            LoginSuccess();
        }
    }

}
