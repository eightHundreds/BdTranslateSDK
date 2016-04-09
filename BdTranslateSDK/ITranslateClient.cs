using BdTranslateSDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BdTranslateSDK
{
    public interface ITranslateClient
    {
        string Translate(string srcStr,string targetLang, string srcLang = "auto");
        List<MixResult> TranslateMultiple(string srcStr, string targetLang, string srcLang = "auto");
    }
}
