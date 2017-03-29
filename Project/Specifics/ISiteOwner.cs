using Boissonnot.Framework.Tests.UnitTester.Selenium.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Boissonnot.Framework.Tests.UnitTester.Selenium.Specifics
{
    public interface ISiteOwner
    {
        /// <summary>
        /// Retrouve le site suivant une configuration donnée et l'élément xml donné
        /// </summary>
        /// <remarks>Il doit y avoir l'attribut : site-id</remarks>
        ISite DefineSite(XElement element, IConfiguration configuration);
    }
}
