using Boissonnot.Framework.Tests.UnitTester.Selenium.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Boissonnot.Framework.Tests.UnitTester.Selenium.Specifics.Actions
{
    public class ClickAction : BaseAction
    {
        #region Public methods
        public override void Execute(XElement element, Context context,
                                     Configuration.IConfiguration configuration, ISite site = null, ISiteOwner siteOwner = null)
        {
            const string FINDBY = "findby-";
            XAttribute attribute = element.Element("input").Attribute(FINDBY + "xpath");
            IWebElement webElement = null;

            if (attribute != null)
                webElement = context.Driver.FindElement(By.XPath(attribute.Value));

            System.Threading.Thread.Sleep(100);

            if (webElement != null)
                webElement.Click();
        }
        #endregion
    }
}
