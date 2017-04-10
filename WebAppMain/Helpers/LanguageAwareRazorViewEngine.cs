using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMain.Helpers
{
    public class LanguageAwareRazorViewEngine : RazorViewEngine
    {
        /// <summary>
        /// when language switch, use target language by default
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="viewName"></param>
        /// <param name="masterName"></param>
        /// <param name="useCache"></param>
        /// <returns></returns>
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            var lang = controllerContext.RouteData.Values["lang"];

            if (lang != null && Convert.ToString(lang).StartsWith("en")) 
            {
                string newViewName = viewName + "_en";
                ViewEngineResult result = base.FindView(controllerContext, newViewName, masterName, useCache);
                if (result.View != null)
                {
                    return result;
                }
            }
            return base.FindView(controllerContext, viewName, masterName, useCache); ;
        }
    }
}