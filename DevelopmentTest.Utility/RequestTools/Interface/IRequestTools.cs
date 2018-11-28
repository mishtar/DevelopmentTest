using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DevelopmentTest.Utility.RequestTools.Interface
{
    public interface IRequestTools
    {
        Task<T> Invoke<T>(HttpMethod httpMethod, string invokingUri,
            List<Tuple<string, string>> queryParameters = null, object content = null);
    }
}
