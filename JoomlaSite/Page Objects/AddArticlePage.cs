using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoomlaSite.Common_Action;

namespace JoomlaSite.Page_Objects
{
    class AddArticlePage:Common
    {
        #region Click
        public void ClickSaveButton()
        {
            ClickWebElement("save_btn");
        }
        public void ClickSaveCloseButton()
        {
            ClickWebElement("saveclose_btn");
        }
        #endregion
        #region Title+Alias
        public void EnterArticleTitle()
        {
            string title = GetData("articletitle");
            TypeText("title_tbx", title);
        }
        public void EnterAlias()
        {
            string alias = GetData("articlealias");
            TypeText("alias_tbx", alias);
        }
        #endregion
        #region Content tab
        public void EnterArticleContent()
        {
            string content = GetData("articlecontent");
            driver.SwitchTo().Frame(FindWebElement("content_frame"));
            TypeText("content_tbx", content);
            driver.SwitchTo().DefaultContent();
        }
        public void SelectArticleStatus()
        {
            string status = GetData("statusvalue");
            SelectDropdownList("status_btn", "status", status);
        }
        public void SelectArticleCategory()
        {
            string category = GetData("categoryvalue");
            SelectDropdownList("category_btn", "category", category);
        }
        #endregion
    }
}
