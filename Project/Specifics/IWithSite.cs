using Boissonnot.Framework.Tests.UnitTester.Selenium.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boissonnot.Framework.Tests.UnitTester.Selenium.Specifics
{
    public interface IWithSite
    {
        /// <summary>
        /// Appartenance au site défini dans cette propriété
        /// </summary>
        ISite CurrentSite { get; set; }
    }
}
