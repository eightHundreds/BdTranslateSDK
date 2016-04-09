using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BdTranslateSDK
{
    public class CommonHelper
    {
        /// <summary>
        /// 生成MD5
        /// </summary>
        /// <param name="srcStr">源字符串</param>
        /// <param name="encodeFormate">编码格式</param>
        /// <returns></returns>
        public static string ToMD5(string srcStr,string encodeFormate="UTF-8")
        {
            MD5CryptoServiceProvider m5 = new MD5CryptoServiceProvider();
            byte[] inputBye;
            byte[] outputBye;
            //inputBye = System.Text.Encoding.Default.GetBytes(srcStr);
            inputBye = System.Text.Encoding.GetEncoding(encodeFormate).GetBytes(srcStr);
            outputBye = m5.ComputeHash(inputBye);
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < outputBye.Length; i++)
            {
                sBuilder.Append(outputBye[i].ToString("x2"));
            }
            return (sBuilder.ToString());
        }

        /// <summary>
        /// Json反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string content) where T : new()
        {
            var restResponse = new RestResponse { Content = content };
            var d = new JsonDeserializer();
            var payload = d.Deserialize<T>(restResponse);
            return payload;
        }
    }
}
