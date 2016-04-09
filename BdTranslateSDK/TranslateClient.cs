using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Extensions;
using BdTranslateSDK.Model;
namespace BdTranslateSDK
{
    public class TranslateClient : ITranslateClient
    {
        IRestClient restClient = new RestClient(TranslateConfig.ApiBaseUrl);

        /// <summary>
        /// 翻译单个内容
        /// </summary>
        /// <param name="srcStr"></param>
        /// <param name="targetLang"></param>
        /// <param name="srcLang"></param>
        /// <returns></returns>
        public string Translate(string srcStr, string targetLang, string srcLang = "auto")
        {
            return TranslateMultiple(srcStr, targetLang, srcLang)[0].dst;
        }

        /// <summary>
        /// 翻译多块内容
        /// </summary>
        /// <param name="srcStr"></param>
        /// <param name="targetLang"></param>
        /// <param name="srcLang"></param>
        /// <returns></returns>
        public List<MixResult> TranslateMultiple(string srcStr, string targetLang, string srcLang = "auto")
        {
            var requst = GetRequest(srcStr, targetLang, srcLang);
            IRestResponse<TranslateResult> response = null;
            response = restClient.Execute<TranslateResult>(requst);
            if (response.ErrorException != null || response.Data.trans_result == null)
            {
                throw new TranslateException("翻译失败",response);
            }
            return response.Data.trans_result;
        }

        /// <summary>
        /// 获得请求对象
        /// </summary>
        /// <param name="srcStr"></param>
        /// <param name="tarLang"></param>
        /// <param name="srcLang"></param>
        /// <returns></returns>
        private RestRequest GetRequest(string srcStr, string tarLang, string srcLang = "auto")
        {
            /*
            q	TEXT	Y	请求翻译query	UTF-8编码
            from	TEXT	Y	翻译源语言	语言列表(可设置为auto)
            to	TEXT	Y	译文语言	语言列表(不可设置为auto)
            appid	INT	Y	APP ID	可在管理控制台查看
            salt	INT	Y	随机数	
            sign 
             */

            RestRequest requst = new RestRequest();
            RequestParameter param = new RequestParameter(srcStr);
            requst.AddParameter("from", param.From);
            requst.AddParameter("to", tarLang);
            requst.AddParameter("q", param.Query);
            requst.AddParameter("appid", param.AppId);
            requst.AddParameter("salt", param.Salt);
            requst.AddParameter("sign", param.GetSign());
            requst.Method = Method.POST;
            return requst;
        }
    }
}
