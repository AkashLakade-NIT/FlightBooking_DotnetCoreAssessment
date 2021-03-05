using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("tblFlightBook", Schema = "dbo")]
    public class Flight_Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        public string Gender { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]     
        public int Age { get; set; }

        [Required]
        public DateTime DateOfJourney { get; set; }

        [ForeignKey("Color")]
        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }
    }
}
