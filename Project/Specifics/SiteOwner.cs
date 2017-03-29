using FDC.Sites.Web.UnitTest.Selenium.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FDC.Sites.Web.UnitTest.Selenium.Specifics
{
    public class SiteOwner : ISiteOwner
    {
        #region Public methods
        public ISite DefineSite(XElement element, IConfiguration configuration)
        {
            int siteId = -1;

            if(element.HasAttributes && element.Attribute("site-id") != null)
                siteId = int.Parse(element.Attribute("site-id").Value);

            return configuration.SiteList.FirstOrDefault(item => item.Id == siteId);
        }
        #endregion
    }
}
