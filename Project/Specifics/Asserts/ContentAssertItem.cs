using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Boissonnot.Framework.Tests.UnitTester.Selenium.Specifics.Asserts
{
    public class ContentAssertItem : AssertItem
    {
        #region Constructors
        public ContentAssertItem(XElement item, XElement page, ISiteOwner siteOwner,
                                 Configuration.IConfiguration defaultConfiguration) : base(item, page, siteOwner, defaultConfiguration)
        { }
        #endregion

        #region Internal methods
        protected override void DoValid(Context context)
        {
            foreach (var item in this.Item.Descendants("control"))
            {
                IWebElement webElement = null;

                try
                {
                    webElement = context.Driver.FindElement(By.TagName(item.Attribute("type").Value));
                }
                catch (Exception ex) { }

                Assert.IsNotNull(webElement);
                Assert.IsTrue(webElement.Text == item.Value);
            }
        }
        #endregion
    }
}
