using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pfm.Models.Do
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid LocalId { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string ImageUrl { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        public string UserId { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        
    }
}