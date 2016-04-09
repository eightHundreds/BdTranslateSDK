using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BdTranslateSDK.Model
{
    public class TranslateResult
    {
        /*
        字段名	类型	描述
        from	TEXT	翻译源语言
        to	TEXT	译文语言
        trans_result	MIXED LIST	翻译结果
        src	TEXT	原文
        dst	TEXT	译文 
         */
        public string from { get; set; }
        public string to { get; set; }
        public List<MixResult> trans_result { get; set; }
    }


}
