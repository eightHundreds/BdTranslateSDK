using System.Collections.Specialized;
using System.Configuration;

namespace BdTranslateSDK
{
    /// <summary>
    /// 百度翻译配置类
    /// </summary>
    public static class TranslateConfig
    {
        private static string _apiBaseUrl;
        private static string _appId ;
        private static string _appSecret;
        private static NameValueCollection TranslateSection = (NameValueCollection)ConfigurationManager.GetSection("BdTranslate");

        /// <summary>
        /// api根路径
        /// </summary>
        public static string ApiBaseUrl
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_apiBaseUrl))
                {
                    _apiBaseUrl =TranslateSection["ApiBaseUrl"];
                }
                return _apiBaseUrl;
            }
        }

        /// <summary>
        /// 应用Id
        /// </summary>
        public static string AppId
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_appId))
                {
                    _appId = TranslateSection["AppId"];
                }
                return _appId;
            }
        }

        /// <summary>
        /// 密钥
        /// </summary>
        public static string AppSecret
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_appSecret))
                {
                    _appSecret = TranslateSection["AppSecret"];
                }
                return _appSecret;
            }
        }
    }
}