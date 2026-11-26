namespace AFO.Domain.Entities
{
    public class ClientsRequests
    {
        public Guid Id { get; private set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Message { get; set; }
        public string? Objet {  get; set; }

        private ClientsRequests() { }
    }
}
