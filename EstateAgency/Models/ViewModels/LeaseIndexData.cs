using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateAgency.Models.ViewModels
{
    public class LeaseIndexData
    {
        public IEnumerable<Lease> Leases { get; set; }
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<Estate> Estates { get; set; }
    }
}
