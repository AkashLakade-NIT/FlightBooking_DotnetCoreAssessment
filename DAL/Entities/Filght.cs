using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("tblFlight", Schema = "dbo")]
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        public string SourceLocation { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        public string DestinationLocation { get; set; }

        [Column(TypeName = "varchar(100)")]
        [StringLength(15)]
        public string FlightAmount { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        public string AvailableTickets { get; set; }

        [Required]
        public DateTime FlightDate { get; set; }
        public ICollection<Flight_Book> Flight_Books { get; set; }
    }
}
