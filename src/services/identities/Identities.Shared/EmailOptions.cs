namespace Identities.Shared
{
#nullable disable
    public class EmailOptions
    {
        public string Sender { get; set; }
        public string SenderId { get; set; }
        public string AuthenticationToken { get; set; }
        public string ServerAddress { get; set; }
        public string Port { get; set; }
    }
}
