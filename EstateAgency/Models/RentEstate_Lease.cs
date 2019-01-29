namespace EstateAgency.Models
{
    public class RentEstate_Lease
    {
        public int EstateID { get; set; }

        public int LeaseID { get; set; }

        public Estate Estate { get; set; }

        public Lease Lease { get; set; }

    }
}