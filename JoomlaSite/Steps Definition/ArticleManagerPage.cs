using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;
using JoomlaSite.Page_Objects;

namespace JoomlaSite.Steps_Definition
{
    [Binding]
    class ArticleManagerPage: Page_Objects.ArticleManagerPage
    {
        [BeforeStep("ClickNew")]
        public void DeleteArticleBeforeAdd()
        {
            string title = GetData("articletitle");
            DeleteArticle(title);
        }
        [When(@"I click New button")]
        public void ClickNew()
        {
            ClickNewButton();
        }
        [Then(@"Added Article Success Message display.")]
        public void IsArticleAddedSuccessMessageDisplay()
        {
            Assert.IsTrue(IsArticleAddedMessageDisplay());
        }
        [Then(@"New Article is displayed in Articles Manager table")]
        public void IsNewArticleDisplay()
        {
            Assert.IsTrue(IsArticleAddedSuccess());
        }
    }
}
