using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoomlaSite.Common_Action;

namespace JoomlaSite.Page_Objects
{
    class ArticleManagerPage:Common
    {
        #region Click
        public void ClickNewButton()
        {
            ClickWebElement("new_btn");
        }
        public void ClickEditButton()
        {
            ClickWebElement("edit_btn");
        }
        public void ClickPublishButton()
        {
            ClickWebElement("publich_btn");
        }
        public void ClickTrashButton()
        {
            ClickWebElement("trash_btn");
        }
        public void ClickEmptyTrashButton()
        {
            ClickWebElement("emptytrash)btn");
        }
        public void ClickCheckBoxCheckAll()
        {
            ClickWebElement("checkall_cbx");
        }
        public void ClickSearchButton()
        {
            ClickWebElement("search_btn");
        }
        public void OpenSearchToolsSection()
        {
            if (FindWebElement("searchstatus_btn").Displayed == false)
            {ClickWebElement("searchtools_btn");}
            else { }
        }
        public void CloseSearchToolsSection()
        {
            if(FindWebElement("searchstatus_btn").Displayed == true)
            { ClickWebElement("searchtools_btn");}
            else { }
        }
        public void ClickSearchStatusButton()
        {
            ClickWebElement("searchstatus_btn");
        }
        public void ClickSearchCategoryButton()
        {
            ClickWebElement("searchcategory_btn");
        }
        #endregion

        #region Enter Text
        public void EnterSearchText(string text)
        {
            TypeText("search_tbx", text);
        }
        #endregion

        #region Select search value
        public void SelectStatusSearchValue(string statusvalue)
        {
            SelectDropdownList("searchstatus_btn", "status", statusvalue);
        }
        public void SelectCategorySearchValue(string categoryvalue)
        {
            SelectDropdownList("searchcategory_btn", "category", categoryvalue);
        }
        #endregion
        #region Search
        public void SearchArticleTitle(string titletosearch)
        {
            EnterSearchText(titletosearch);
            ClickSearchButton();
        }
        public void SearchArticleStatus(string statusvalue)
        {
            OpenSearchToolsSection();
            SelectStatusSearchValue(statusvalue);
        }
        #endregion

        #region Main Method
        public void TrashArticle(string articletitle)
        {
            SearchArticleTitle(articletitle);
            ClickTrashButton();
        }
        public void DeleteArticle(string searchvalue)
        {
            TrashArticle(searchvalue);
            SearchArticleStatus("Trashed");
            SearchArticleTitle(searchvalue);
            ClickCheckBoxCheckAll();
            ClickEmptyTrashButton();
            AcceptAlertPopup();
        }
        #endregion
    }
}
