﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boissonnot.Framework.Tests.UnitTester.Selenium.Specifics
{
    public class Context
    {
        #region Properties
        /// <summary>
        /// Driver d'accès à la page
        /// </summary>
        public IWebDriver Driver { get; set; }
        #endregion
    }
}
