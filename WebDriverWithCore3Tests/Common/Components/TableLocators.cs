using System.Collections.Generic;
using WebDriverWithCore3Tests.Common.WebElements;

namespace WebDriverWithCore3Tests.Common.Components
{
    public class TableLocators
    {
        #region Table header

        public virtual WebElement Table => new WebElement { XPath = "//table[@class='table']" };

        public virtual WebElement TableToolbar => Table
            .FindChildElement<WebElement>(new WebElement { XPath = "//tr[@_ngcontent-c6]" });

        public virtual IList<TableHeaderElement> TableHeaders
            => TableToolbar.FindChildElements<TableHeaderElement>
            (new WebElement { XPath = "th[@_ngcontent-c6]" });

        //Header elements //thead[@_ngcontent-c6]//tr[@_ngcontent-c6]//th[@_ngcontent-c6]

        #endregion

        #region Body Content

        public virtual WebElement BodyContent => new WebElement { XPath = "//tbody[@_ngcontent-c6]" };

        public virtual IList<WebElement> BodyRows => BodyContent
            .FindChildElements<WebElement>(new WebElement { XPath = "//tbody[@_ngcontent-c6]//tr[@_ngcontent-c6]" }); //

        public virtual IList<WebElement> Cells => Table.FindChildElements<WebElement>(new WebElement { XPath = "//td[@_ngcontent-c6]" });

        public virtual IList<WebElement> RowCells(WebElement row) 
            => row.FindChildElements<WebElement>(new WebElement { XPath = "//td[@_ngcontent-c6]" });

        #endregion
    }
}
