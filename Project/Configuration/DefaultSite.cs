using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boissonnot.Framework.Tests.UnitTester.Selenium.Configuration
{
    public class DefaultSite : ISite
    {
        #region Properties
        public string DefaultUrl
        {
            get; set;
        }

        public int Id
        {
            get;set;
        }
        #endregion
    }
}
