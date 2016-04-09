using BdTranslateSDK.Model;
using RestSharp;
using System;
using System.Runtime.Serialization;

namespace BdTranslateSDK
{
    [Serializable]
    public class TranslateException : Exception
    {
        public IRestResponse Response { get; private set; }
        public TranslateError error { get; private set; }

        public TranslateException()
        {
        }

        public TranslateException(string message, IRestResponse response) : base(message)
        {
            this.Response = response;
            try
            {
                this.error = CommonHelper.Deserialize<TranslateError>(response.Content);
            }
            catch
            {
                this.error = null;
            }
        }

        public TranslateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TranslateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}