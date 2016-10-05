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
    class HomePage: Page_Objects.HomePage
    {
        [When(@"I click New Article button")]
        public void IClickNewArticleButton()
        {
            ClickNewArticleButton();
        }
        [When(@"I click Articles button")]
        public void IClickArticlesButton()
        {
            ClickArticlesButton();
        }
    }
}
