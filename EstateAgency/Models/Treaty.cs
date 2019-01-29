using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EstateAgency.Models
{
    public class Treaty
    {
        public int ID { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SignDate { get; set; }

        public ICollection<Client_Treaty> Client_Treaties { get; set; }

    }
}
