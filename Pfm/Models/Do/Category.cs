using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pfm.Models.Do
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public Category Parent { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public string ImageUrl { get; set; }
    }
}