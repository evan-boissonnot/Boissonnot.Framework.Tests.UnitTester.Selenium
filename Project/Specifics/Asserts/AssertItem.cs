using Boissonnot.Framework.Tests.UnitTester.Selenium.Configuration;
using Boissonnot.Framework.Tests.UnitTester.Selenium.Specifics.Actions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Boissonnot.Framework.Tests.UnitTester.Selenium.Specifics.Asserts
{
    public abstract class AssertItem : IAssert
    {
        #region Fields
        private XElement _page = null;
        private XElement _element = null;
        private ISiteOwner _siteOwner = null;
        private Configuration.IConfiguration _defaultConfiguration = null;
        #endregion

        #region Constructors
        public AssertItem(XElement item, XElement page, ISiteOwner siteOwner, Configuration.IConfiguration defaultConfiguration)
        {
            this._element = item;
            this._page = page;
            this._siteOwner = siteOwner;
            this._defaultConfiguration = defaultConfiguration;

            this.CurrentSite = siteOwner.DefineSite(this._page, defaultConfiguration);
        }
        #endregion

        #region Public methods
        public void Valid(Context context)
        {
            this.LaunchActionsBefore(context);
            this.DoValid(context);
            this.LaunchActionsAfter(context);
        }
        #endregion

        #region Internal methods
        private void LaunchActionsBefore(Context context)
        {
            this.LaunchActionList(this.Item.Element("before"), context);
        }

        private void LaunchActionsAfter(Context context)
        {
            this.LaunchActionList(this.Item.Element("after"), context);
        }

        private void LaunchActionList(XElement xmlItem, Context context)
        {
            if (xmlItem != null && xmlItem.Element("actions") != null)
                foreach (var action in xmlItem.Descendants("action").OrderBy(item => int.Parse(item.Attribute("order").Value)))
                {
                    IAction realAction = ActionScheduler.CreateOne(action, context);

                    if (realAction != null)
                    {
                        realAction.Execute(action.Descendants().First(), context, this._defaultConfiguration, this.CurrentSite, this._siteOwner);
                        System.Threading.Thread.Sleep(200);
                    }
                }
        }

        /// <summary>
        /// Surcharger cette méthode (obligatoire) pour appliquer les actions
        /// </summary>
        protected abstract void DoValid(Context context);
        #endregion

        #region Properties
        public XElement Page { get { return this._page; } }

        public XElement Item { get { return this._element; } }

        public ISite CurrentSite { get; set; }
        #endregion
    }
}
