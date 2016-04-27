# BdTranslateSDK
简易的百度翻译SDK

#配置

```
<configuration>
  <configSections>
    <section name="BdTranslate" type="System.Configuration.NameValueSectionHandler,System, Version=4.0.0.0, Culture=neutral,PublicKeyToken=b77a5c561934e089" />
  </configSections>
  <BdTranslate>
    <add key="AppId" value="" />
    <add key="AppSecret" value="" />
    <add key="ApiBaseUrl" value="http://api.fanyi.baidu.com/api/trans/vip/translate" />
  </BdTranslate>
</configuration>
```

#使用

```
//中文变英文
var client = new TranslateClient();
string result=client.Translate("苹果", LanguageList.English);

//多段文本翻译,用\n能隔开文本
 string srcStr = "您好! 感谢您一直\n以来对百度翻译的信赖和支持。为了向您提供更稳定、高效、优质的服务,我们将百度翻译API服务全新升级至百度翻译开放云平台。 百度翻译开放云平台官网";
var result = client.TranslateMultiple(srcStr, LanguageList.English);

```