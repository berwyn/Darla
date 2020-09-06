using Darla.ESI.Clients;

namespace Darla.ESI
{
    public interface IESIClient
    {
        IStatusClient Status { get; }
        IMarketClient Market { get; }
    }

    public class ESIClient : IESIClient
    {
        public IStatusClient Status { get; private set; }
        public IMarketClient Market { get; private set; }

        public ESIClient(IStatusClient status, IMarketClient market)
        {
            Status = status;
            Market = market;
        }
    }
}
