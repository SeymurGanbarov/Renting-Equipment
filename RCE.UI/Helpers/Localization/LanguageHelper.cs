using System;
using System.Globalization;
using System.Threading;

namespace RCE.UI.Helpers
{
    public class LanguageHelper
    {
        public const string DefaultLanguage = "en";
        /// <summary>
        /// This method change current culture by lang parameter
        /// </summary>
        /// <param name="lang"></param>
        public static void SetLanguage(string lang)
        {
            LanguageEnum languageEnum;
            if(Enum.TryParse<LanguageEnum>(lang,true,out languageEnum))
            {
                string culture;
                switch (languageEnum)
                {
                    case LanguageEnum.EN:
                        culture = "en-US";
                        break;
                    case LanguageEnum.RU:
                        culture = "ru-RU";
                        break;
                }
                try
                {
                    NumberFormatInfo numberInfo = CultureInfo.CreateSpecificCulture("nl-NL").NumberFormat;
                    CultureInfo info = new CultureInfo(lang);
                    info.NumberFormat = numberInfo;
                    Thread.CurrentThread.CurrentUICulture = info;
                    Thread.CurrentThread.CurrentCulture = info;
                }
                catch (Exception)
                {

                }
            }
            return;
        }
    }
}