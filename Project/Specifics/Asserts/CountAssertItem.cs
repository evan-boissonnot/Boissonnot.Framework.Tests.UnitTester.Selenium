using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FDC.Sites.Web.UnitTest.Selenium.Specifics.Asserts
{
    public class CountAssertItem : AssertItem
    {
        #region Constructors
        public CountAssertItem(XElement item, XElement page, ISiteOwner siteOwner, Configuration.IConfiguration defaultConfiguration) :
                              base(item, page, siteOwner, defaultConfiguration)
        {}
        #endregion

        #region Internal methods
        protected override void DoValid(Context context)
        {
            const string FINDBY = "findby-";
            XElement countElement = this.Item.Element("count");
            int expected = int.Parse(countElement.Attribute("expected").Value);
            int nbItems = 0;      

            XAttribute attribute = countElement.Element("control").Attribute(FINDBY + "xpath");
            IReadOnlyCollection<IWebElement> webElementList = null;

            if (attribute != null)
            {
                try
                {
                    webElementList = context.Driver.FindElements(By.XPath(attribute.Value));
                    nbItems = webElementList.Count;
                }
                catch(Exception ex)
                {
                    nbItems = 0;
                }

                Assert.IsTrue(expected == nbItems, "Le nombre d'éléments attendu est de : " + expected + ", nous en avons : " + nbItems);
            }
        }
        #endregion
    }
}
