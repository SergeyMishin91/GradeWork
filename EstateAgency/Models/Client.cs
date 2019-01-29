using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EstateAgency.Models
{
    public enum ClientStatus
    {
        Owner,
        Buyer,
        Tenant
    }

    public abstract class Client
    {
        public int ID { get; set; }

        [Required]
        public virtual string FullName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public ClientStatus ClientStatus { get; set; }

        public ICollection<Estate> Estates { get; set; }

        public ICollection<Client_Treaty> Client_Treaties { get; set; }
    }
}
