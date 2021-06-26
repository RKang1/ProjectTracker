namespace ProjectTracker.Services
{
    public interface IGoogleService
    {
        public string ClientId { get; }
    }

    public class GoogleService : IGoogleService
    {
        private readonly string _clientId;
        public GoogleService(string ClientId)
        {
            _clientId = ClientId;
        }

        public string ClientId { get { return _clientId; } }
    }
}
