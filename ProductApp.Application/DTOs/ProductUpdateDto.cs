using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.DTOs
{
    public class ProductUpdateDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(0, 100000)]
        public decimal Price { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
