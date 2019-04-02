using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Curiox.Data.Entities
{
    class Category
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(30)]
        public String Name { get; set; }
    }
}
