using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml.Linq;
using System.Reflection;
using Boissonnot.Framework.Tests.UnitTester.Selenium.Specifics;
using Boissonnot.Framework.Tests.UnitTester.Selenium.Configuration;

namespace Boissonnot.Framework.Tests.UnitTester.Selenium
{
    [TestClass]
    public class ValidPageListUnitTest
    {
        #region Fields
        private IWebDriver _driver = null;
        private System.Xml.Linq.XDocument _document = null;
        #endregion

        #region Public methods
        [TestInitialize]
        public void Initialize()
        {
            Motor.Instance.Configuration = new Configuration.DefaultConfiguration();
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            var options = new ChromeOptions();
            //options.AddArgument("--window-position=-32000,-32000");
            options.LeaveBrowserRunning = false;

            this._driver = new ChromeDriver(service, options);
            this._driver.Manage().Window.Maximize();

            if (!string.IsNullOrEmpty(Properties.Settings.Default.XML_PATH))
                this._document = XDocument.Load(Properties.Settings.Default.XML_PATH);
            else
                this._document = XDocument.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream("Boissonnot.Framework.Tests.UnitTester.Selenium.TestPageList.xml"));

            Motor.Instance.Configuration.Load(this._document);
        }

        [TestMethod]
        public void TestPageList()
        {
            foreach (var page in this._document.Descendants("page"))
            {
                ISite currentSite = new SiteOwner().DefineSite(page, Motor.Instance.Configuration);
                string url = currentSite != null ? currentSite.DefaultUrl : string.Empty;

                this._driver.Navigate().GoToUrl(url + page.Attribute("url").Value);

                foreach (var assert in page.Descendants("assert"))
                {
                    Specifics.IAssert asertItem = Specifics.AssertScheduler.Create(page, assert, 
                                                                                   Motor.Instance.Configuration, 
                                                                                   new SiteOwner());
                    
                    if(asertItem != null)
                        asertItem.Valid(new Specifics.Context() { Driver = this._driver });
                }
            }
        }

        [TestCleanup]
        public void EndTest()
        {
            this._driver.Close();
        }
        #endregion
    }
}
