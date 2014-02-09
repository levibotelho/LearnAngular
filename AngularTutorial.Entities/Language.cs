using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularTutorial.Entities
{
    public enum Language
    {
        English
    }

    static class LanguageExtensions
    {
        public static Language FromLanguageCode(this Language language, string languageCode)
        {
            if (languageCode.Substring(0, 2).Equals("EN", StringComparison.CurrentCultureIgnoreCase))
                return Language.English;

            throw new ArgumentException("The language code \"" + languageCode + "\" is not supported.");
        }
    }
}
