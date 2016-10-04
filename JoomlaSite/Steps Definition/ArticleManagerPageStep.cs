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
    class ArticleManagerPageStep:ArticleManagerPage
    {
        [When(@"I click New button")]
        public void ClickNew()
        {
            ClickNewButton();
        }
    }
}
