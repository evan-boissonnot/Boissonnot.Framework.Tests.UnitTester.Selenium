using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Boissonnot.Framework.Tests.UnitTester.Selenium.Configuration;

namespace Boissonnot.Framework.Tests.UnitTester.Selenium.Specifics.Actions
{
    public class BaseAction : IAction
    {
        #region Public methods
        public virtual void Execute(XElement element, Context context,
                                    Configuration.IConfiguration configuration, ISite site = null, ISiteOwner siteOwner = null)
        {
            this.CurrentSite = siteOwner.DefineSite(element, configuration);

            if (this.CurrentSite == null)
                this.CurrentSite = site;
        }
        #endregion

        #region Properties
        public ISite CurrentSite
        {
            get; set;
        }
        #endregion
    }
}
