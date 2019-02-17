
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Translation.V2;

namespace Translate.MethodClasses
{
    public static class GoogleTranslateServices
    {
        private static GoogleCredential gc = GoogleCredential.FromFile(
            System.AppContext.BaseDirectory + "/Content/GoogleCredentials.json");

        public static string TranslateMe(string toTranslate)
        {
            TranslationClient client = TranslationClient.Create(gc);

            return client.TranslateText(toTranslate, "en").TranslatedText;
        }
    }
}