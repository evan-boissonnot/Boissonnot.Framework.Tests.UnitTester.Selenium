using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FDC.Sites.Web.UnitTest.Selenium.Configuration
{
    public class DefaultConfiguration : IConfiguration
    {
        #region Public methods
        public void Load(XDocument document)
        {
            List<ISite> list = new List<ISite>();

            foreach (var item in document.Descendants("site"))
            {
                ISite site = new DefaultSite()
                {
                    Id = int.Parse(item.Attribute("id").Value),
                    DefaultUrl = item.Attribute("url").Value
                };

                list.Add(site);
            }

            this.SiteList = list;
        }
        #endregion

        #region Properties
        public IEnumerable<ISite> SiteList { get; set; }
        #endregion
    }
}
