using FDC.Sites.Web.UnitTest.Selenium.Specifics.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FDC.Sites.Web.UnitTest.Selenium.Specifics
{
    public class ActionScheduler
    {
        #region Public methods
        /// <summary>
        /// Crée une action spécifique à exécuter
        /// </summary>
        /// <returns></returns>
        public static IAction CreateOne(XElement action, Context context)
        {
            IAction realAction = null;
            XElement xmlElement = action.Descendants().First();

            if (xmlElement != null)
            {
                string typeName = string.Format("FDC.Sites.Web.UnitTest.Selenium.Specifics.Actions.{0}Action", xmlElement.Name);
                Type currentType = Type.GetType(typeName, false, true);

                realAction = (IAction)Activator.CreateInstance(currentType);
            }

            return realAction;
        }
        #endregion
    }
}
