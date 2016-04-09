using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BdTranslateSDK;
namespace BdTranslateSDKTests
{
    [TestClass]
    public class TranslateConfigTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("20160408000018044", TranslateConfig.AppId);
            Assert.AreEqual("http://api.fanyi.baidu.com/api/trans/vip/translate", TranslateConfig.ApiBaseUrl);
            Assert.AreEqual("0Mg24V_nZiC7Qpsvo55s", TranslateConfig.AppSecret);
        }
    }
}
