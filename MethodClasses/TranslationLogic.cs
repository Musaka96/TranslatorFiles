namespace Translate.MethodClasses
{
    public static class TranslationLogic
    {
        public static string FindTranslation(string toTranslate)
        {
            string transText = XMLTranslationHandler.FindTranslationInData(toTranslate);
            if (transText == null)
            {
                transText = GoogleTranslateServices.TranslateMe(toTranslate);
                XMLTranslationHandler.WriteTranslationData(toTranslate, transText);
            }

            XMLTranslationHandler.WriteTranslationLog(toTranslate, transText);

            return transText;
        }
    }
}