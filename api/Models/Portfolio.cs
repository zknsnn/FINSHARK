using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Portfolios")]
    public class Portfolio
    {
        // Composite key properties
        public string AppUserId { get; set; } = null!;
        public int StockId { get; set; }

        // Navigation properties
        public AppUser AppUser { get; set; } = null!;
        public Stock Stock { get; set; } = null!;
    }

}