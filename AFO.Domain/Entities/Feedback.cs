namespace AFO.Domain.Entities
{
    public class Feedback
    {
        public Guid Id { get; set; }
        public required string Username { get; set; }
        public string? Role { get; set; }
        public required string Message { get; set; }
        private decimal _note;
        public string? Image { get; set; }
        public Guid? ServiceId { get; set; }
        public Service? Service { get; set; }


        public Feedback() { }

        public decimal Note
        {
            get => _note;
            set
            {
                if (value < 0 || value > 5)
                    throw new ArgumentOutOfRangeException(nameof(value), "Note should be between 0 and 5");

                if (value % 0.5m != 0)
                    throw new ArgumentException("Note should be a multiple of 0.5", nameof(value));

                _note = value;
            }
        }
    }
}
