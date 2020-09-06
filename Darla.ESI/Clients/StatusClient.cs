using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Darla.ESI.Models;

namespace Darla.ESI.Clients
{
    public interface IStatusClient
    {
        Task<Status> GetAsync(
            Environment environment = Environment.Latest,
            Source source = Source.Tranquility,
            CancellationToken token = default);
    }

    public class StatusClient : BaseClient, IStatusClient
    {
        public StatusClient(HttpClient http) : base(http)
        {
        }

        public async Task<Status> GetAsync(
            Environment environment = Environment.Latest,
            Source source = Source.Tranquility,
            CancellationToken token = default)
        {
            var url = BuildUri($"/{environment.ToURLSegment()}/status", new[]
            {
                string.Format("{0}={1}", HttpUtility.UrlEncode("datasource"), HttpUtility.UrlEncode(source.ToURLSegment()))
            });

            var result = await _http.GetAsync(url, token);
            using (var stream = await result.Content.ReadAsStreamAsync())
            {
                if ((int)result.StatusCode == 420)
                {
                    var limit = await JsonSerializer.DeserializeAsync<RateLimitResponse>(stream, cancellationToken: token);
                    throw new RateLimitedException(limit.Error);
                }

                switch (result.StatusCode)
                {
                    case HttpStatusCode.InternalServerError:
                        var internalError = await JsonSerializer.DeserializeAsync<InternalServerErrorResponse>(stream, cancellationToken: token);
                        throw new ESIServerErrorException(internalError.Error);
                    case HttpStatusCode.ServiceUnavailable:
                        var unavailable = await JsonSerializer.DeserializeAsync<ServiceUnavailableResponse>(stream, cancellationToken: token);
                        throw new ESIServerErrorException(unavailable.Error);
                    case HttpStatusCode.GatewayTimeout:
                        var timeout = await JsonSerializer.DeserializeAsync<GatewayTimeoutResponse>(stream, cancellationToken: token);
                        throw new ESIServerErrorException(timeout.Error);
                }

                var status = await JsonSerializer.DeserializeAsync<Status>(stream, cancellationToken: token);

                return status;
            }
        }
    }
}
