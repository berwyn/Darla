using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Darla.ESI.Clients
{
    public abstract class BaseClient
    {
        protected private HttpClient _http;

        protected private BaseClient(HttpClient http)
        {
            _http = http;
        }

        protected private Uri BuildUri(string path, IEnumerable<string> queryParams)
        {
            return new UriBuilder()
            {
                Scheme = _http.BaseAddress.Scheme,
                Host = _http.BaseAddress.Host,
                Path = path,
                Query = string.Join("&", queryParams)
            }.Uri;
        }
    }
}
