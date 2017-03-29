using Boissonnot.Framework.Tests.UnitTester.Selenium.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Boissonnot.Framework.Tests.UnitTester.Selenium.Specifics.Actions
{
    public class GoToAction : BaseAction
    {
        #region Public methods
        public override void Execute(XElement element, Context context,
                                     Configuration.IConfiguration configuration, ISite site = null, ISiteOwner siteOwner = null)
        {
            base.Execute(element, context, configuration, site, siteOwner);

            string url = this.CurrentSite != null ? this.CurrentSite.DefaultUrl : string.Empty;
            context.Driver.Navigate().GoToUrl(url + element.Attribute("url").Value);
        }
        #endregion
    }
}
