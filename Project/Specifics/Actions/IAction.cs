using Boissonnot.Framework.Tests.UnitTester.Selenium.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Boissonnot.Framework.Tests.UnitTester.Selenium.Specifics.Actions
{
    public interface IAction : IWithSite
    {
        /// <summary>
        /// Exécute une action sur le driver
        /// </summary>
        void Execute(XElement element, Context context, Configuration.IConfiguration configuration, ISite site = null, ISiteOwner siteOwner = null);
    }
}
