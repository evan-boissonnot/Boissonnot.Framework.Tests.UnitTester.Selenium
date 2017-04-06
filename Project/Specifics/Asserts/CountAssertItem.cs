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
            XAttribute expectedAttribute = countElement.Attribute("expected");
            XAttribute moreThanAttribute = countElement.Attribute("more-than");
            XAttribute findbyAttribute = countElement.Element("control").Attribute(FINDBY + "xpath");

            if (findbyAttribute != null)
            {
                int nbItems = 0;
                IReadOnlyCollection<IWebElement> webElementList = null;

                try
                {
                    webElementList = context.Driver.FindElements(By.XPath(findbyAttribute.Value));
                    nbItems = webElementList.Count;
                }
                catch (Exception ex)
                {
                    nbItems = 0;
                }

                if (expectedAttribute != null)
                {
                    int expected = int.Parse(expectedAttribute.Value);
                    Assert.IsTrue(expected == nbItems, "Le nombre d'éléments attendu est de : " + expected + ", nous en avons : " + nbItems);
                }
                else if (moreThanAttribute != null)
                {
                    int expected = int.Parse(moreThanAttribute.Value);
                    Assert.IsTrue(expected < nbItems, "Le nombre d'éléments attendu doit être supérieur à : " + expected + ", nous en avons : " + nbItems);
                }
            }
        }
        #endregion
    }
}
