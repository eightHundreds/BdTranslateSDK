using Microsoft.VisualStudio.TestTools.UnitTesting;
using BdTranslateSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BdTranslateSDK.Tests
{
    [TestClass()]
    public class RequestParameterTests
    {

        /// <summary>
        /// 参数测试
        /// </summary>
        [TestMethod()]
        public void RequestParameterTest()
        {
            var parameter = new RequestParameter("苹果");
            parameter.Salt = "1";
            Assert.AreEqual("9425afeed2b7892b7ee31055f328f2bd", parameter.GetSign());
            //parameter.Secret
            //Assert.Fail();
        }
    }
}