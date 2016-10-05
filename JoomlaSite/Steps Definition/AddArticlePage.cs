using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoomlaSite.Page_Objects;
using TechTalk.SpecFlow;

namespace JoomlaSite.Steps_Definition
{
    [Binding]
    class AddArticlePage: Page_Objects.AddArticlePage
    {
        [When(@"I enter title into title text box")]
        public void IEnterTitle()
        {
            EnterArticleTitle();
        }
        [When(@"I enter content into content textbox")]
        public void IEnterContent()
        {
            EnterArticleContent();
        }
        [When(@"I select status value")]
        public void ISelectStatus()
        {
            SelectArticleStatus();
        }
        [When(@"I select category value")]
        public void ISelectCategory()
        {
            SelectArticleCategory();
        }
        [When(@"I click Save and Close button")]
        public void IClickSaveCloseButton()
        {
            ClickSaveCloseButton();
        }
    }
}
