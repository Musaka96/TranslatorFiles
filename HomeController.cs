using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Translate.MethodClasses;
using Translate.Models;

namespace Translate.Controllers
{
    public class HomeController : Controller
    {
        public static string currentInputText;

        public ActionResult Index(Translation translation)
        {
            if(translation.text == null)
            {
                return View();
            }

            ViewBag.translatedText = TranslationLogic.FindTranslation(translation.text);

            return View();
        }

        public ActionResult Submit()
        {
            ViewBag.translatedText = TranslationLogic.FindTranslation(currentInputText);

            return View();
        }

        public ActionResult SetCurrentText(string key)
        {
            currentInputText = key;
            return null;
        }
    }
}