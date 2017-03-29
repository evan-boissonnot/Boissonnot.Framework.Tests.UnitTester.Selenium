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
    public class SetAction : BaseAction
    {
        #region Public methods
        public override void Execute(XElement element, Context context,
                                     Configuration.IConfiguration configuration, ISite site = null, ISiteOwner siteOwner = null)
        {
            foreach (var input in element.Elements("input"))
            {
                IWebElement webElement = context.Driver.FindElement(By.Id(input.Attribute("id").Value));
                webElement.SendKeys(input.Attribute("content").Value);
            }
        }
        #endregion
    }
}
