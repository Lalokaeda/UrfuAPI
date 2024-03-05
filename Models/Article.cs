using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UrfuAPI.Models
{
    public partial class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; } = null!;

        
        [Required]
        [Column(TypeName = "text")]
        public string ArticleText { get; set; } = null!;

        [Required]
        public DateTime CreationDate { get; set; }
    }
}