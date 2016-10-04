using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoomlaSite.Common_Action;

namespace JoomlaSite.Page_Objects
{
    class HomePage:Common
    {
        #region Click
        public ArticleManagerPage ClickArticlesButton()
        {
            ClickWebElement("Articles_btn");
            return new ArticleManagerPage();
        }
        #endregion
    }
}
