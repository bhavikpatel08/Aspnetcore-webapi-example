using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreWebAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(20)]
        public string ProductNumber { get; set; }

        [StringLength(10)]
        public string Variant { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsActive{ get; set; }
    }
}
