using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDC.Sites.Web.UnitTest.Selenium.Configuration
{
    public interface ISite
    {
        /// <summary>
        /// Id du site lié
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Url par défaut du site
        /// </summary>
        string DefaultUrl { get; set; }
    }
}
