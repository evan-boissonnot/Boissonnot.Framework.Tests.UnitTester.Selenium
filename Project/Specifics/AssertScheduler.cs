using FDC.Sites.Web.UnitTest.Selenium.Specifics.Asserts;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FDC.Sites.Web.UnitTest.Selenium.Specifics
{
    public class AssertScheduler
    {
        #region Public methods
        /// <summary>
        /// Crée la bonne assertion
        /// </summary>
        public static IAssert Create(XElement page, XElement item, Configuration.IConfiguration configuration, ISiteOwner siteOwner)
        {
            IAssert assert = null;
            
            if (item.Element("title") != null)
                assert = new TitleAssertItem(item, page, siteOwner, configuration);
            else if (item.Element("content") != null)
                assert = new ContentAssertItem(item, page, siteOwner, configuration);
            else if (item.Element("count") != null)
                assert = new CountAssertItem(item, page, siteOwner, configuration);

            return assert;
        }
        #endregion
    }
}
