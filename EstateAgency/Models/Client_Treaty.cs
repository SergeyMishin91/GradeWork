namespace EstateAgency.Models
{
    public class Client_Treaty
    {
        public int TreatyID { get; set; }

        public int ClientID { get; set; }

        public Client Client { get; set; }

        public Treaty Treaty { get; set; }
    }
}
