using Microsoft.VisualStudio.TestTools.UnitTesting;
using BdTranslateSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BdTranslateSDK.Tests
{
    [TestClass()]
    public class TranslateClientTests
    {
        public ITranslateClient client;
        //[TestMethod()]
        //public void TranslateClientTest()
        //{
        //   // Assert.Fail();
        //}

        [TestInitialize]
        public void Init()
        {
            client = new TranslateClient();
        }

        /// <summary>
        /// 一般测试
        /// </summary>
        [TestMethod()]
        public void TranslateTest()
        {
            string result=client.Translate("苹果", LanguageList.English);
            Assert.AreEqual("apple", result,true);
            //Assert.Fail();
        }
       
        [TestMethod]
        public void TranslateTestLong()
        {
            string srcStr = "您好! 感谢您一直以来对百度翻译的信赖和支持。为了向您提供更稳定、高效、优质的服务,我们将百度翻译API服务全新升级至百度翻译开放云平台。 百度翻译开放云平台官网";

            string expected = "Hello, thank you for your support and trust in Baidu translation. In order to provide you with a more stable, efficient, high-quality services, we will translate the new Baidu API service upgrade to Baidu translate Open Cloud platform. Baidu translate open cloud platform official website";
            string result = client.Translate(srcStr, LanguageList.English);
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// 多段测试
        /// </summary>
        [TestMethod]
        public void TranslateMultiple()
        {
            string srcStr = "您好! 感谢您一直\n以来对百度翻译的信赖和支持。为了向您提供更稳定、高效、优质的服务,我们将百度翻译API服务全新升级至百度翻译开放云平台。 百度翻译开放云平台官网";
            var result = client.TranslateMultiple(srcStr, LanguageList.English);
            Assert.AreEqual(2, result.Count);
        }


        /// <summary>
        /// 异常触发测试,该测试修改appid,secret即可触发
        /// </summary>
        [ExpectedException(typeof(BdTranslateSDK.TranslateException))]
        [TestMethod]
        public void TranslateError()
        {
            //TranslateConfig.AppId = "2222";
            var result = client.Translate("苹果", LanguageList.English);
            Assert.AreEqual("apple", result, true);
        }


    }
}