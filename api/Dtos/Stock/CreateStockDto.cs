using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class CreateStockDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cannot exceed 10 characters.")]
        public string Symbol { get; set; } = string.Empty;

        [Required]
        [MaxLength(10, ErrorMessage = "CompanyName cannot exceed 10 characters.")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [Range(1, 10000000, ErrorMessage = "Purchase must be between 1 and 1,000,0000")]
        public decimal Purchase { get; set; }

        [Required]
        [Range(0.0001, 100, ErrorMessage = "LastDiv must be between 0.0001 and 100")]
        public decimal LastDiv { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Industry cannot exceed 10 characters.")]
        public string Industry { get; set; } = string.Empty;

        [Required]
        [Range(1, 50000000, ErrorMessage = "MarketCap must be between 1 and 50,000,000")]
        public long MarketCap { get; set; }
    }
}
