using Boissonnot.Framework.Tests.UnitTester.Selenium.Configuration;
using OpenQA.Selenium;
using System.Xml.Linq;

namespace Boissonnot.Framework.Tests.UnitTester.Selenium.Specifics
{
    public interface IAssert : IWithSite
    {
        /// <summary>
        /// Lance une assertion sur l'url en cours d'analyse
        /// </summary>
        /// <param name="driver"></param>
        void Valid(Context context);

        /// <summary>
        /// Accès au contenu XML de la page
        /// </summary>
        XElement Page { get; }

        /// <summary>
        /// Accès au contenu xml de l'assertion
        /// </summary>
        XElement Item { get; }

        
    }
}