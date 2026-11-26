namespace AFO.Domain.Entities
{
    internal class ClientsRequests
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; } = "";
        public string PhoneNumber { get; private set; } = "";
        public string Message { get; private set; } = "";
        public string? Objet {  get;private set; }

        private ClientsRequests() { }
    }
}
