using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Practice3.Models
{
    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
