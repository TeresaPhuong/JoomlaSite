using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using JoomlaSite.Common_Action;

namespace JoomlaSite.Steps_Definition
{
    [Binding]
    class Configure: Common_Action.Configure
    {
        
        [Before]
        public void precondition()
        {
            StartBrowser();
        }

        [After]
        public void postcondition()
        {
            driver.Quit();
        }
    }
}
