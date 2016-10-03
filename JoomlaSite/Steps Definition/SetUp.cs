using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using JoomlaSite.Common_Action;

namespace JoomlaSite.Steps_Definition
{
    class SetUp:Configure
    {
        [Given(@"I navigate to (.*)")]
        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
        }
        [BeforeFeature]
        public void precondition()
        {
            StartBrowser();
        }

        [AfterFeature]
        public void postcondition()
        {
            driver.Quit();
        }
    }
}
