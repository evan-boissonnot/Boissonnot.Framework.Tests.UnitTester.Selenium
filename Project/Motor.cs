using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boissonnot.Framework.Tests.UnitTester.Selenium
{
    public class Motor
    {
        #region Fields
        private static Motor __instance = new Motor();
        #endregion

        #region Constructors
        private Motor() { }
        #endregion

        #region Properties
        /// <summary>
        /// Configuration par défaut 
        /// </summary>
        public Configuration.IConfiguration Configuration { get; set; }
        
        /// <summary>
        /// Singleton
        /// </summary>
        public static Motor Instance { get { return __instance; } }
        #endregion
    }
}
