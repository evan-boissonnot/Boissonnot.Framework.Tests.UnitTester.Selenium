using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Boissonnot.Framework.Tests.UnitTester.Selenium.Configuration
{
    public interface IConfiguration
    {
        /// <summary>
        /// Charge la configuration
        /// </summary>
        /// <param name="document">Document xml</param>
        void Load(XDocument document);

        /// <summary>
        /// Liste des sites par défaut
        /// </summary>
        IEnumerable<ISite> SiteList { get; set; }
    }
}
