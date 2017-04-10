using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace WebAppMain.Helpers
{
    public class LocalizationAttribute : ActionFilterAttribute
    {
        private string _DefaultLanguage = "en";

        public LocalizationAttribute(string defaultLanguage)
        {
            _DefaultLanguage = defaultLanguage;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string lang = (string)filterContext.RouteData.Values["lang"] ?? _DefaultLanguage;
            if (lang != _DefaultLanguage)
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture =
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
                }
                catch (Exception e)
                {
                    throw new NotSupportedException(String.Format("ERROR: Invalid language code '{0}; {1}'.", lang, e.Message));
                }
            }
        }

        private static CultureInfo ResolveCulture(ControllerContext filterContext)
        {
            // Priority 1: from a lang parameter in the query string
            var culture = CreateCulture(GetLanguageFromRouteData(filterContext));
            if (culture != null)
                return culture;

            // Priority 2: Get culture from user's browser
            culture = CreateCulture(GetRequestLanguage(filterContext));
            if (culture != null)
                return culture;

            return Thread.CurrentThread.CurrentCulture;
        }

        private static string GetLanguageFromRouteData(ControllerContext filterContext)
        {
            return filterContext.RouteData.Values["lang"] != null ?
                filterContext.RouteData.Values["lang"].ToString() : string.Empty;
        }

        private static string GetRequestLanguage(ControllerContext filterContext)
        {
            if (filterContext.HttpContext.Request.UserLanguages != null
                && filterContext.HttpContext.Request.UserLanguages.Count() > 0)
            {
                return filterContext.HttpContext.Request.UserLanguages[0];
            }

            return string.Empty;
        }

        private static CultureInfo CreateCulture(string name)
        {
            try
            {
                return CultureInfo.CreateSpecificCulture(name);
            }
            catch
            {
                return null;
            }
        }
    }
}