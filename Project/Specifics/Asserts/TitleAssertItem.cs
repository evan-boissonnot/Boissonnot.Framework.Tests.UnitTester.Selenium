using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FDC.Sites.Web.UnitTest.Selenium.Specifics.Asserts
{
    public class TitleAssertItem : AssertItem
    {
        #region Constructors
        public TitleAssertItem(XElement item, XElement page, ISiteOwner siteOwner, 
                               Configuration.IConfiguration defaultConfiguration) : base(item, page, siteOwner, defaultConfiguration)
        {}
        #endregion

        #region Internal methods
        protected override void DoValid(Context context)
        {
            string title = this.Item.Element("title").Value;

            Assert.IsTrue(context.Driver.Title == title, "La page " + this.Page.Attribute("url").Value + " doit avoir le titre " + title);
        }
        #endregion
    }
}
