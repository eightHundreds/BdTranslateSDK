using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Extensions;

namespace BdTranslateSDK
{
    public class RequestParameter
    {
        /*
         q	TEXT	Y	请求翻译query	UTF-8编码
from	TEXT	Y	翻译源语言	语言列表(可设置为auto)
to	TEXT	Y	译文语言	语言列表(不可设置为auto)
appid	INT	Y	APP ID	可在管理控制台查看
salt	INT	Y	随机数	
sign
         */


        public RequestParameter(string query)
        {
            Random r = new Random();
            AppId = TranslateConfig.AppId;
            Salt = r.Next(10000).ToString();
            Secret = TranslateConfig.AppSecret;
            From = LanguageList.Auto;
            Query = query;
        }

        /// <summary>
        /// 源语言
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// 随机值
        /// </summary>
        public string Salt { get; set; }
        /// <summary>
        /// 目标语言
        /// </summary>
        public string To { get; set; }
        /// <summary>
        /// 应用Id
        /// </summary>
        public string AppId { get; set; }
        ///// <summary>
        ///// 签名
        ///// </summary>
        //public string Sign { get; set; }
        /// <summary>
        /// 密钥
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// 翻译文本
        /// </summary>
        public string Query { get; set; }
        public string GetSign()
        {
            //System.Web.HttpUtility.UrlEncode
            //string encodeQuery = query.UrlEncode();
            //appid+q+salt+密钥
            return CommonHelper.ToMD5(AppId + Query + Salt + Secret);
        }
    }
}