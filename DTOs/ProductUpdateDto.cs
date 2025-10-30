using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Web.DTOs
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string ?Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        public string? Description { get; set; }
    }
}